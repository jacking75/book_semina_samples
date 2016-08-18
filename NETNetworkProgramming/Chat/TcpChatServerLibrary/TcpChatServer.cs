using System;
using System.Net;
using System.Net.Sockets;

namespace Dobon.Net.Chat
{
	public delegate void ServerEventHandler(object sender, ServerEventArgs e);
	
	public enum ServerState
	{
		None,
		Listening,
		Stopped
	}
	
	public class TcpChatServer : IDisposable
	{
		public virtual void Dispose()
		{
			this.Close();
		}
				
		public event ServerEventHandler AcceptedClient;
		protected virtual void OnAcceptedClient(ServerEventArgs e)
		{
			if (this.AcceptedClient != null)
			{
				this.AcceptedClient(this, e);
			}
		}

		
		public event ReceivedDataEventHandler ReceivedData;
		protected virtual void OnReceivedData(ReceivedDataEventArgs e)
		{
			if (this.ReceivedData != null)
			{
				this.ReceivedData(this, e);
			}
		}

		public event ServerEventHandler DisconnectedClient;
		protected virtual void OnDisconnectedClient(ServerEventArgs e)
		{
			if (this.DisconnectedClient != null)
			{
				this.DisconnectedClient(this, e);
			}
		}
		


		private Socket _server;
		
		protected Socket Server
		{
			get
			{
				return this._server;
			}
		}

		protected ServerState _serverState;
		
		public ServerState ServerState
		{
			get
			{
				return this._serverState;
			}
		}

		private IPEndPoint _socketEP;
		
		public IPEndPoint LocalEndPoint
		{
			get
			{
				return this._socketEP;
			}
		}

		protected System.Collections.ArrayList _acceptedClients;
		
		public virtual TcpChatClient[] AcceptedClients
		{
			get
			{
				return (TcpChatClient[]) this._acceptedClients.ToArray(typeof(TcpChatClient));
			}
		}

		private int _maxClients;
		
		public int MaxClients
		{
			get
			{
				return this._maxClients;
			}
			set
			{
				this._maxClients = value;
			}
		}
		

		private readonly object syncSocket = new object();
		
		public TcpChatServer()
		{
			this._maxClients = 100;
			this._server = new Socket(AddressFamily.InterNetwork,
				                SocketType.Stream, ProtocolType.Tcp);
			this._acceptedClients =
				System.Collections.ArrayList.Synchronized(
				new System.Collections.ArrayList());
		}

		public void Listen(string host, int portNum, int backlog)
		{
			if (this._server == null)
				throw new ApplicationException("null server");
			if (this.ServerState != ServerState.None)
				throw new ApplicationException("fail Listen");

			this._socketEP = new IPEndPoint(
				            Dns.Resolve(host).AddressList[0], portNum);
			this._server.Bind(this._socketEP);
				
			this._server.Listen(backlog);
			this._serverState = ServerState.Listening;

			this._server.BeginAccept(new AsyncCallback(this.AcceptCallback), null);
		}
		public void Listen(string host, int portNum)
		{
			this.Listen(host, portNum, 100);
		}

		public virtual void SendMessageToAllClients(string msg)
		{
			//CRLF
			msg = msg.Replace("\r\n", "");

			this.SendToAllClients(msg);
		}

		protected virtual void SendErrorMessage(TcpChatClient client, string msg)
		{
			client.SendMessage(msg);
		}

		public void StopListen()
		{
			lock (this.syncSocket)
			{
				if (this._server == null)
					return;
				this._server.Close();
				this._server = null;
				this._serverState = ServerState.Stopped;
			}

		}

		public void Close()
		{
			this.StopListen();
			this.CloseAllClients();
		}

		public void CloseClient(TcpChatClient client)
		{
			this._acceptedClients.Remove(client);
			client.Close();
		}

		public void CloseAllClients()
		{
			lock (this._acceptedClients.SyncRoot)
			{
				while (this._acceptedClients.Count > 0)
				{
					this.CloseClient((TcpChatClient) this._acceptedClients[0]);
				}
			}
		}

		protected void SendToAllClients(string str)
		{
			lock (this._acceptedClients.SyncRoot)
			{
				for (int i = 0; i < this._acceptedClients.Count; i++)
				{
					((TcpChatClient) this._acceptedClients[i]).Send(str);
				}
			}
		}

		protected virtual TcpChatClient CreateChatClient(Socket soc)
		{
			return new TcpChatClient(soc);
		}

		private void AcceptCallback(IAsyncResult ar)
		{
			Socket soc = null;
			
            try
			{
				lock (this.syncSocket)
				{
					soc = this._server.EndAccept(ar);
				}
			}
			catch
			{
				this.Close();
				return;
			}

			TcpChatClient client = this.CreateChatClient(soc);
			
            if (this._acceptedClients.Count >= this.MaxClients)
			{
				client.Close();
			}
			else
			{
				this._acceptedClients.Add(client);
				
				client.Disconnected += new EventHandler(client_Disconnected);
				client.ReceivedData += new ReceivedDataEventHandler(client_ReceivedData);
				
				this.OnAcceptedClient(new ServerEventArgs(client));
				
				if (!client.IsClosed)
				{
					client.StartReceive();
				}
			}

			this._server.BeginAccept(new AsyncCallback(this.AcceptCallback), null);
		}

		private void client_Disconnected(object sender, EventArgs e)
		{
			this._acceptedClients.Remove((TcpChatClient) sender);
			this.OnDisconnectedClient(new ServerEventArgs((TcpChatClient) sender));
		}

		private void client_ReceivedData(object sender, ReceivedDataEventArgs e)
		{
			this.OnReceivedData(new ReceivedDataEventArgs(
				(TcpChatClient) sender, e.ReceivedString));
		}
		
	}
}
