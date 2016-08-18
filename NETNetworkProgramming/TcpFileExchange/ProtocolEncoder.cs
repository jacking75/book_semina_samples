using System;
using System.Text;

namespace TcpFileExchange
{
	/// <summary>
	/// �t?�C��?���̂��߂ɒ�?�����v���g�R���Ɋ�Â��ăf??���G���R?�h/�f�R?�h����N���X
	/// �f??��?����
	/// [filename]?[BASE64�ŃG���R?�h���ꂽ�t?�C���̒��g]
	/// �̂悤��?�ŋ�؂�ꂽ�Q�̕�����
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
