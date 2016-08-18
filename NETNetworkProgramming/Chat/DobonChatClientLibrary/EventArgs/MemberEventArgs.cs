using System;

namespace Dobon.Net.Chat
{
	/// <summary>
	/// MemberEventArgs �̊T�v�̐����ł��B
	/// </summary>
	public class MemberEventArgs : EventArgs
	{
		private string _name;
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		public MemberEventArgs(string memName)
		{
			this._name = memName;
		}
	}
}
