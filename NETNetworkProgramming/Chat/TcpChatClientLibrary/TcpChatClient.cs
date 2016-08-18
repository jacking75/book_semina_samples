using System;
using System.Net;
using System.Net.Sockets;

namespace Dobon.Net.Chat
{
	#region �f���Q?�g
	/// <summary>
	/// ��M�����f??�����C�x���g���������郁?�b�h��?��
	/// </summary>
	public delegate void ReceivedDataEventHandler(object sender, ReceivedDataEventArgs e);
	#endregion

	/// <summary>
	/// TCP?���b�g�N���C�A���g�̊�?�I��??��񋟂���
	/// </summary>
	public class TcpChatClient : IDisposable
	{
		#region IDisposable �����o
		/// <summary>
		/// �j������
		/// </summary>
		public virtual void Dispose()
		{
			this.Close();
		}
		#endregion

		#region �C�x���g
		/// <summary>
		/// �f??����M����
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
		/// �T?�o?�ɐڑ�����
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
		/// �T?�o?����ؒf���ꂽ�A���邢�͐ؒf����
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

		#region �v���p�e�B
		private System.Text.Encoding _encoding;
		/// <summary>
		/// �g�p���镶���R?�h
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
		/// ��ɂȂ�Socket
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
		/// ��?�J���G���h?�C���g
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
		/// ��?�J���G���h?�C���g
		/// </summary>
		public IPEndPoint RemoteEndPoint
		{
			get
			{
				return this._remoteEndPoint;
			}
		}

		/// <summary>
		/// ���Ă��邩
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
		/// ���Ŏ�M�ł���ő�o�C�g
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
		/// ��M�����f??
		/// </summary>
		protected System.IO.MemoryStream ReceivedBytes
		{
			get
			{
				return _receivedBytes;
			}
		}
		#endregion

		#region �t�B?���h
		private bool startedReceiving = false;
		private readonly object syncSocket = new object();
		#endregion

		/// <summary>
		/// �R���X�g���N?
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
		/// �T?�o?�ɐڑ�����
		/// </summary>
		/// <param name="host">�z�X�g��</param>
		/// <param name="port">??�g�ԍ�</param>
		public void Connect(string host, int port)
		{
			if (this.IsClosed)
				throw new ApplicationException("���Ă��܂��B");
			if (this._socket.Connected)
				throw new ApplicationException("���łɐڑ�����Ă��܂��B");

			//�ڑ�����
			IPEndPoint ipEnd = new IPEndPoint(
				Dns.Resolve(host).AddressList[0], port);
			this._socket.Connect(ipEnd);

			this._localEndPoint = (IPEndPoint) this._socket.LocalEndPoint;
			this._remoteEndPoint = (IPEndPoint) this._socket.RemoteEndPoint;

			//�C�x���g�𔭐�
			this.OnConnected(new EventArgs());

			//�񓯊��f??��M���J�n����
			this.StartReceive();
		}

		/// <summary>
		/// �ؒf����
		/// </summary>
		public void Close()
		{
			lock (this.syncSocket)
			{
				if (this.IsClosed)
					return;

				//����
				this._socket.Shutdown(SocketShutdown.Both);
				this._socket.Close();
				this._socket = null;
				if (this._receivedBytes != null)
				{
					this._receivedBytes.Close();
					this._receivedBytes = null;
				}
			}
			//�C�x���g�𔭐�
			this.OnDisconnected(new EventArgs());
		}

		/// <summary>
		/// ������𑗐M����
		/// </summary>
		/// <param name="str">���M���镶����</param>
		public void Send(string str)
		{
			if (this.IsClosed)
				throw new ApplicationException("���Ă��܂��B");

			//�������Byte?�z��ɕϊ�
			byte[] sendBytes = this.Encoding.GetBytes(str + "\r\n");

			lock (this.syncSocket)
			{
				//�f??�𑗐M����
				this._socket.Send(sendBytes);
			}
		}

		/// <summary>
		/// ���b�Z?�W�𑗐M����
		/// </summary>
		/// <param name="msg">���M���郁�b�Z?�W</param>
		public virtual void SendMessage(string msg)
		{
			//CRLF���폜
			msg = msg.Replace("\r\n", "");

			this.Send(msg);
		}

		/// <summary>
		/// �f??�̔񓯊���M���J�n����
		/// </summary>
		public void StartReceive()
		{
			if (this.IsClosed)
				throw new ApplicationException("���Ă��܂��B");
			if (this.startedReceiving)
				throw new ApplicationException("StartReceive�����łɌĂяo����Ă��܂��B");

			//������
			byte[] receiveBuffer = new byte[1024];
			this._receivedBytes = new System.IO.MemoryStream();
			this.startedReceiving = true;

			//�񓯊���M���J�n
			this._socket.BeginReceive(receiveBuffer,
				0, receiveBuffer.Length,
				SocketFlags.None, new AsyncCallback(ReceiveDataCallback),
				receiveBuffer);
		}

		//BeginReceive�̃R?���o�b�N
		private void ReceiveDataCallback(IAsyncResult ar)
		{
			int len = -1;
			//�ǂݍ��񂾒������擾
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
			//�ؒf���ꂽ�����ׂ�
			if (len <= 0)
			{
				this.Close();
				return;
			}

			//��M�����f??���擾����
			byte[] receiveBuffer = (byte[]) ar.AsyncState;

			//��M�����f??��?�ς���
			this._receivedBytes.Write(receiveBuffer, 0, len);
			//�ő�l�𒴂������́A�ڑ������
			if (this._receivedBytes.Length > this.MaxReceiveLenght)
			{
				this.Close();
				return;
			}
			//�Ō�܂Ŏ�M���������ׂ�
			if (this._receivedBytes.Length >= 2)
			{
				this._receivedBytes.Seek(-2, System.IO.SeekOrigin.End);
				if (this._receivedBytes.ReadByte() == (int) '\r' &&
					this._receivedBytes.ReadByte() == (int) '\n')
				{
					//�Ō�܂Ŏ�M������
					//��M�����f??�𕶎���ɕϊ�
					string str = this.Encoding.GetString(
						this._receivedBytes.ToArray());
					this._receivedBytes.Close();
					//��s���ɕ�������
					int startPos = 0, endPos;
					while ((endPos = str.IndexOf("\r\n", startPos)) >=0 )
					{
						string line = str.Substring(startPos, endPos - startPos);
						startPos = endPos + 2;
						//�C�x���g�𔭐�
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
				//�Ăю�M�J�n
				this._socket.BeginReceive(receiveBuffer,
					0, receiveBuffer.Length,
					SocketFlags.None, new AsyncCallback(ReceiveDataCallback)
					, receiveBuffer);
			}
		}
	}
}
