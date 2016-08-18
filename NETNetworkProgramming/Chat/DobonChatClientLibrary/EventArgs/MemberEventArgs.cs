using System;

namespace Dobon.Net.Chat
{
	/// <summary>
	/// MemberEventArgs の概要の説明です。
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
