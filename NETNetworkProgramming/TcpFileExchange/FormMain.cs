// 출처: http://www.atmarkit.co.jp/fdotnet/special/networkprog/TcpFileExchange.zip

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

namespace TcpFileExchange
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBoxIPAddress;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.TextBox textBoxReceivedMessage;
		private System.Windows.Forms.Button buttonSend;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private TcpListener listener = null;

		private StreamWriter clientWriter = null;
		private StreamReader clientReader = null;

		private StreamWriter serverWriter = null;
		private StreamReader serverReader = null;

		Thread threadServer = null;

		Thread threadClient = null;

		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox textBoxFileName;
		private System.Windows.Forms.Button buttonOpen;

		private Int32 port = 9991;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxIPAddress = new System.Windows.Forms.TextBox();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.textBoxReceivedMessage = new System.Windows.Forms.TextBox();
			this.textBoxFileName = new System.Windows.Forms.TextBox();
			this.buttonSend = new System.Windows.Forms.Button();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// textBoxIPAddress
			// 
			this.textBoxIPAddress.Location = new System.Drawing.Point(16, 16);
			this.textBoxIPAddress.Name = "textBoxIPAddress";
			this.textBoxIPAddress.Size = new System.Drawing.Size(184, 20);
			this.textBoxIPAddress.TabIndex = 0;
			this.textBoxIPAddress.Text = "localhost";
			// 
			// buttonConnect
			// 
			this.buttonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonConnect.Location = new System.Drawing.Point(204, 16);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(72, 23);
			this.buttonConnect.TabIndex = 1;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// textBoxReceivedMessage
			// 
			this.textBoxReceivedMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxReceivedMessage.Location = new System.Drawing.Point(16, 164);
			this.textBoxReceivedMessage.Multiline = true;
			this.textBoxReceivedMessage.Name = "textBoxReceivedMessage";
			this.textBoxReceivedMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxReceivedMessage.Size = new System.Drawing.Size(260, 88);
			this.textBoxReceivedMessage.TabIndex = 2;
			this.textBoxReceivedMessage.Text = "";
			// 
			// textBoxFileName
			// 
			this.textBoxFileName.Location = new System.Drawing.Point(16, 112);
			this.textBoxFileName.Name = "textBoxFileName";
			this.textBoxFileName.Size = new System.Drawing.Size(184, 20);
			this.textBoxFileName.TabIndex = 3;
			this.textBoxFileName.Text = "";
			// 
			// buttonSend
			// 
			this.buttonSend.Enabled = false;
			this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSend.Location = new System.Drawing.Point(16, 136);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.Size = new System.Drawing.Size(260, 23);
			this.buttonSend.TabIndex = 4;
			this.buttonSend.Text = "Send";
			this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
			// 
			// buttonOpen
			// 
			this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOpen.Location = new System.Drawing.Point(204, 112);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(72, 23);
			this.buttonOpen.TabIndex = 5;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.buttonSend);
			this.Controls.Add(this.textBoxFileName);
			this.Controls.Add(this.textBoxReceivedMessage);
			this.Controls.Add(this.buttonConnect);
			this.Controls.Add(this.textBoxIPAddress);
			this.Name = "FormMain";
			this.Text = "TcpFileExchange";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.Closed += new System.EventHandler(this.FormMain_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		private void FormMain_Load(object sender, System.EventArgs e)
		{
			ServerStart();
		}

		private void ServerStart()
		{
			try
			{
				listener = new TcpListener(IPAddress.Any, port);
				listener.Start();

				WriteLineMessage("서버 시작");

				threadServer = new Thread(new ThreadStart(ServerListen));
				threadServer.Start();
			}
			catch (Exception exception)
			{
				WriteLineMessage(exception.Message + "\r\n" + exception.StackTrace);
			}
		}

		private void ServerListen()
		{
			try
			{
				TcpClient server = listener.AcceptTcpClient();

				this.textBoxReceivedMessage.BeginInvoke(new WriteLineMessageHandler(WriteLineMessage), new object[] {"긏깋귽귺깛긣궕먝뫏궢귏궢궫갃"});

				this.buttonConnect.Enabled = false;
				this.buttonSend.Enabled = true;

				NetworkStream ns = server.GetStream();

				serverReader = new StreamReader(ns, Encoding.UTF8);
				serverWriter = new StreamWriter(ns, Encoding.UTF8);

				while (true)
				{
					ProcessMessage(serverReader);
				}
			}
			catch (Exception exception)
			{
				this.textBoxReceivedMessage.BeginInvoke(new WriteLineMessageHandler(WriteLineMessage), new object[] { exception.Message  + "\r\n" + exception.StackTrace});
			}
		}

		private void ClientListen()
		{
			try
			{
				while (true)
				{
					ProcessMessage(clientReader);
				}
			}
			catch (Exception exception)
			{
				this.textBoxReceivedMessage.BeginInvoke(new WriteLineMessageHandler(WriteLineMessage), new object[] { exception.Message  + "\r\n" + exception.StackTrace});
			}
		}

		private void ProcessMessage(StreamReader reader)
		{
			lock(this)
			{
				string message = reader.ReadLine();

				string fileName = ProtocolEncoder.GetFileNameFromStreamText(message);

				Byte[] data = ProtocolEncoder.GetDataFromStreamText(message);

				FileIO.WriteFile(Application.StartupPath + "\\" + fileName, data);

				this.textBoxReceivedMessage.BeginInvoke(new WriteLineMessageHandler(WriteLineMessage), new object[] {fileName + "을 수신 하였습니다."});
			}
		}

		delegate void WriteLineMessageHandler(string message);

		private void WriteLineMessage(string message)
		{
			this.textBoxReceivedMessage.AppendText(message + "\r\n");
		}

		private void buttonConnect_Click(object sender, EventArgs e)
		{
			try
			{
				TcpClient client = new TcpClient(this.textBoxIPAddress.Text, port);

				NetworkStream ns = client.GetStream();

				clientReader = new StreamReader(ns, Encoding.UTF8);
				clientWriter = new StreamWriter(ns, Encoding.UTF8);

				WriteLineMessage("서버에 접속 하였습니다");

				this.buttonConnect.Enabled = false;
				this.buttonSend.Enabled = true;

				threadClient = new Thread(new ThreadStart(this.ClientListen));
				threadClient.Start();
			}
			catch (Exception exception)
			{
				WriteLineMessage(exception.Message + "\r\n" + exception.StackTrace);
			}
		}

		private void buttonSend_Click(object sender, EventArgs e)
		{
			string path = this.textBoxFileName.Text;
			string fileName = Path.GetFileName(path);

			Byte[] data = FileIO.ReadFile(path);

			WriteLineMessage(fileName + "을 읽었습니다.");

			try
			{
				if(clientWriter != null)
				{
					SendMessage(clientWriter, fileName, data);

					WriteLineMessage(fileName + "을 전송합니다.");
				}
                else if(serverWriter != null)
				{
					SendMessage(serverWriter, fileName, data);

                    WriteLineMessage(fileName + "을 전송합니다.");
				}
                else
				{
					this.WriteLineMessage("전송 실패");
				}
			}
			catch (Exception exception)
			{
				WriteLineMessage(exception.Message + "\r\n" + exception.StackTrace);
			}
		}

		private void SendMessage(StreamWriter writer, string fileName, Byte[] data)
		{
			writer.WriteLine(ProtocolEncoder.ToBase64EncodedData(fileName, data));

			writer.Flush();
		}

		private void FormMain_Closed(object sender, System.EventArgs e)
		{
			if(listener != null)
			{
				listener.Stop();
			}

			if(serverReader != null)
			{
				serverReader.BaseStream.Close();
				serverReader.Close();
			}

			if(clientReader != null)
			{
				clientReader.BaseStream.Close();
				clientReader.Close();
			}

			if(serverWriter != null)
			{
				serverWriter.Close();
			}

			if(clientWriter != null)
			{
				clientWriter.Close();
			}

			if (threadClient != null)
			{
				threadClient.Abort();
			}

			if(threadServer != null)
			{
				threadServer.Abort();
			}
		}

		private void buttonOpen_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				this.textBoxFileName.Text = openFileDialog1.FileName;
			}
		}
	}
}
