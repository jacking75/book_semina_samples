using System;

namespace Dobon.Net.Chat
{
	public class ServerEventArgs
	{
		private TcpChatClient _client;
		public TcpChatClient Client
		{
			get
			{
				return _client;
			}
		}

		public ServerEventArgs(TcpChatClient c)
		{
			this._client = c;
		}
	}
}
