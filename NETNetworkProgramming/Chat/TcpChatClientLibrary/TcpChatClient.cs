using System;
using System.Net;
using System.Net.Sockets;

namespace Dobon.Net.Chat
{
	#region デリゲ?ト
	/// <summary>
	/// 受信したデ??を持つイベントを処理するメ?ッドを?す
	/// </summary>
	public delegate void ReceivedDataEventHandler(object sender, ReceivedDataEventArgs e);
	#endregion

	/// <summary>
	/// TCP?ャットクライアントの基?的な??を提供する
	/// </summary>
	public class TcpChatClient : IDisposable
	{
		#region IDisposable メンバ
		/// <summary>
		/// 破棄する
		/// </summary>
		public virtual void Dispose()
		{
			this.Close();
		}
		#endregion

		#region イベント
		/// <summary>
		/// デ??を受信した
		/// </summary>
		public event ReceivedDataEventHandler ReceivedData;
		protected virtual void OnReceivedData(ReceivedDataEventArgs e)
		{
			if (this.ReceivedData != null)
			{
				this.ReceivedData(this, e);
			}
		}

		/// <summary>
		/// サ?バ?に接続した
		/// </summary>
		public event EventHandler Connected;
		protected virtual void OnConnected(EventArgs e)
		{
			if (this.Connected != null)
			{
				this.Connected(this, e);
			}
		}

		/// <summary>
		/// サ?バ?から切断された、あるいは切断した
		/// </summary>
		public event EventHandler Disconnected;
		protected virtual void OnDisconnected(EventArgs e)
		{
			if (this.Disconnected != null)
			{
				this.Disconnected(this, e);
			}
		}
		#endregion

		#region プロパティ
		private System.Text.Encoding _encoding;
		/// <summary>
		/// 使用する文字コ?ド
		/// </summary>
		protected System.Text.Encoding Encoding
		{
			get
			{
				return this._encoding;
			}
			set
			{
				_encoding = value;
			}
		}

		private Socket _socket;
		/// <summary>
		/// 基になるSocket
		/// </summary>
		protected Socket Client
		{
			get
			{
				return this._socket;
			}
		}

		private IPEndPoint _localEndPoint;
		/// <summary>
		/// ロ?カルエンド?イント
		/// </summary>
		public IPEndPoint LocalEndPoint
		{
			get
			{
				return this._localEndPoint;
			}
		}

		private IPEndPoint _remoteEndPoint;
		/// <summary>
		/// ロ?カルエンド?イント
		/// </summary>
		public IPEndPoint RemoteEndPoint
		{
			get
			{
				return this._remoteEndPoint;
			}
		}

		/// <summary>
		/// 閉じているか
		/// </summary>
		public bool IsClosed
		{
			get
			{
				return (this._socket == null);
			}
		}

		private int _maxReceiveLength;
		/// <summary>
		/// 一回で受信できる最大バイト
		/// </summary>
		protected int MaxReceiveLenght
		{
			get
			{
				return _maxReceiveLength;
			}
			set
			{
				_maxReceiveLength = value;
			}
		}

		private System.IO.MemoryStream _receivedBytes;
		/// <summary>
		/// 受信したデ??
		/// </summary>
		protected System.IO.MemoryStream ReceivedBytes
		{
			get
			{
				return _receivedBytes;
			}
		}
		#endregion

		#region フィ?ルド
		private bool startedReceiving = false;
		private readonly object syncSocket = new object();
		#endregion

		/// <summary>
		/// コンストラク?
		/// </summary>
		public TcpChatClient()
		{
			this.Initialize();
			
			this._socket = new Socket(AddressFamily.InterNetwork,
				SocketType.Stream, ProtocolType.Tcp);
		}
		public TcpChatClient(Socket soc)
		{
			this.Initialize();
			
			this._socket = soc;
			this._localEndPoint = (IPEndPoint) soc.LocalEndPoint;
			this._remoteEndPoint = (IPEndPoint) soc.RemoteEndPoint;
		}

		private void Initialize()
		{
			this.Encoding = System.Text.Encoding.UTF8;
			this.MaxReceiveLenght = int.MaxValue;
		}

		/// <summary>
		/// サ?バ?に接続する
		/// </summary>
		/// <param name="host">ホスト名</param>
		/// <param name="port">??ト番号</param>
		public void Connect(string host, int port)
		{
			if (this.IsClosed)
				throw new ApplicationException("閉じています。");
			if (this._socket.Connected)
				throw new ApplicationException("すでに接続されています。");

			//接続する
			IPEndPoint ipEnd = new IPEndPoint(
				Dns.Resolve(host).AddressList[0], port);
			this._socket.Connect(ipEnd);

			this._localEndPoint = (IPEndPoint) this._socket.LocalEndPoint;
			this._remoteEndPoint = (IPEndPoint) this._socket.RemoteEndPoint;

			//イベントを発生
			this.OnConnected(new EventArgs());

			//非同期デ??受信を開始する
			this.StartReceive();
		}

		/// <summary>
		/// 切断する
		/// </summary>
		public void Close()
		{
			lock (this.syncSocket)
			{
				if (this.IsClosed)
					return;

				//閉じる
				this._socket.Shutdown(SocketShutdown.Both);
				this._socket.Close();
				this._socket = null;
				if (this._receivedBytes != null)
				{
					this._receivedBytes.Close();
					this._receivedBytes = null;
				}
			}
			//イベントを発生
			this.OnDisconnected(new EventArgs());
		}

		/// <summary>
		/// 文字列を送信する
		/// </summary>
		/// <param name="str">送信する文字列</param>
		public void Send(string str)
		{
			if (this.IsClosed)
				throw new ApplicationException("閉じています。");

			//文字列をByte?配列に変換
			byte[] sendBytes = this.Encoding.GetBytes(str + "\r\n");

			lock (this.syncSocket)
			{
				//デ??を送信する
				this._socket.Send(sendBytes);
			}
		}

		/// <summary>
		/// メッセ?ジを送信する
		/// </summary>
		/// <param name="msg">送信するメッセ?ジ</param>
		public virtual void SendMessage(string msg)
		{
			//CRLFを削除
			msg = msg.Replace("\r\n", "");

			this.Send(msg);
		}

		/// <summary>
		/// デ??の非同期受信を開始する
		/// </summary>
		public void StartReceive()
		{
			if (this.IsClosed)
				throw new ApplicationException("閉じています。");
			if (this.startedReceiving)
				throw new ApplicationException("StartReceiveがすでに呼び出されています。");

			//初期化
			byte[] receiveBuffer = new byte[1024];
			this._receivedBytes = new System.IO.MemoryStream();
			this.startedReceiving = true;

			//非同期受信を開始
			this._socket.BeginReceive(receiveBuffer,
				0, receiveBuffer.Length,
				SocketFlags.None, new AsyncCallback(ReceiveDataCallback),
				receiveBuffer);
		}

		//BeginReceiveのコ?ルバック
		private void ReceiveDataCallback(IAsyncResult ar)
		{
			int len = -1;
			//読み込んだ長さを取得
			try
			{
				lock (this.syncSocket)
				{
					len = this._socket.EndReceive(ar);
				}
			}
			catch
			{
			}
			//切断されたか調べる
			if (len <= 0)
			{
				this.Close();
				return;
			}

			//受信したデ??を取得する
			byte[] receiveBuffer = (byte[]) ar.AsyncState;

			//受信したデ??を?積する
			this._receivedBytes.Write(receiveBuffer, 0, len);
			//最大値を超えた時は、接続を閉じる
			if (this._receivedBytes.Length > this.MaxReceiveLenght)
			{
				this.Close();
				return;
			}
			//最後まで受信したか調べる
			if (this._receivedBytes.Length >= 2)
			{
				this._receivedBytes.Seek(-2, System.IO.SeekOrigin.End);
				if (this._receivedBytes.ReadByte() == (int) '\r' &&
					this._receivedBytes.ReadByte() == (int) '\n')
				{
					//最後まで受信した時
					//受信したデ??を文字列に変換
					string str = this.Encoding.GetString(
						this._receivedBytes.ToArray());
					this._receivedBytes.Close();
					//一行ずつに分解する
					int startPos = 0, endPos;
					while ((endPos = str.IndexOf("\r\n", startPos)) >=0 )
					{
						string line = str.Substring(startPos, endPos - startPos);
						startPos = endPos + 2;
						//イベントを発生
						this.OnReceivedData(new ReceivedDataEventArgs(this, line));
					}
					this._receivedBytes = new System.IO.MemoryStream();
				}
				else
				{
					this._receivedBytes.Seek(0, System.IO.SeekOrigin.End);
				}
			}

			lock (this.syncSocket)
			{
				//再び受信開始
				this._socket.BeginReceive(receiveBuffer,
					0, receiveBuffer.Length,
					SocketFlags.None, new AsyncCallback(ReceiveDataCallback)
					, receiveBuffer);
			}
		}
	}
}
