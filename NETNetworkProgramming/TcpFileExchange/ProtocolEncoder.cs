using System;
using System.Text;

namespace TcpFileExchange
{
	/// <summary>
	/// フ?イル?送のために定?したプロトコルに基づいてデ??をエンコ?ド/デコ?ドするクラス
	/// デ??の?式は
	/// [filename]?[BASE64でエンコ?ドされたフ?イルの中身]
	/// のように?で区切られた２つの文字列
	/// </summary>
	public class ProtocolEncoder
	{
		private const char Separator = '?';

		public static string GetFileNameFromStreamText(string data)
		{
			string[] partString = data.Split(new char[]{Separator});

			return partString[0];
		}

		public static Byte[] GetDataFromStreamText(string data)
		{
			string[] partString = data.Split(new char[]{Separator});

			return Convert.FromBase64String(partString[1]);
		}

		public static string ToBase64EncodedData(string filename, Byte[] data)
		{
			return filename + "?" + Convert.ToBase64String(data); 
		}
	}
}
