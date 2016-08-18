using System;
using System.IO;

namespace TcpFileExchange
{
	/// <summary>
	/// ファイルをバイナリで読み書きするためのクラス
	/// </summary>
	public class FileIO
	{
		//ファイルをバイナリ形式で読み込む
		public static Byte[] ReadFile(string filename)
		{
			FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
			Byte[] data = new Byte[fs.Length];

			int offset=0;
			int remaining = data.Length;

			while (remaining > 0)
			{
				int read = fs.Read(data, offset, remaining);
				remaining -= read;
				offset += read;
			}

			fs.Close();

			return data;
		}

		//ファイルをバイナリ形式で書き込む
		public static void WriteFile(string filename, Byte[] data)
		{
			FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
			fs.Write(data, 0, data.Length);
			fs.Flush();
			fs.Close();
		}
	}
}
