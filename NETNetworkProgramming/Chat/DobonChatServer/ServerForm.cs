using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Dobon.Net.Chat;

namespace DobonChatServerApplication
{
	/// <summary>
	/// ServerForm の概要の説明です。
	/// </summary>
	public class ServerForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu menuMain;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.RichTextBox logTextBox;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ListView clientViewList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.StatusBar mainStatusbar;
		private System.Windows.Forms.MenuItem menuConnect;
		private System.Windows.Forms.MenuItem menuListen;
		private System.Windows.Forms.MenuItem menuStopListen;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuDisconnectClient;
		private System.Windows.Forms.MenuItem menuDisconnectAllClient;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ServerForm()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
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

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.menuMain = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuConnect = new System.Windows.Forms.MenuItem();
			this.menuListen = new System.Windows.Forms.MenuItem();
			this.menuStopListen = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuDisconnectClient = new System.Windows.Forms.MenuItem();
			this.menuDisconnectAllClient = new System.Windows.Forms.MenuItem();
			this.logTextBox = new System.Windows.Forms.RichTextBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.clientViewList = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.mainStatusbar = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.menuConnect});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuExit});
			this.menuFile.Text = "ファイル(&F)";
			// 
			// menuExit
			// 
			this.menuExit.Index = 0;
			this.menuExit.Text = "終了(&X)";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuConnect
			// 
			this.menuConnect.Index = 1;
			this.menuConnect.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuListen,
																						this.menuStopListen,
																						this.menuItem1,
																						this.menuDisconnectClient,
																						this.menuDisconnectAllClient});
			this.menuConnect.Text = "接続(C)";
			// 
			// menuListen
			// 
			this.menuListen.Index = 0;
			this.menuListen.Text = "Listenを開始する(&L)";
			this.menuListen.Click += new System.EventHandler(this.menuListen_Click);
			// 
			// menuStopListen
			// 
			this.menuStopListen.Enabled = false;
			this.menuStopListen.Index = 1;
			this.menuStopListen.Text = "Listenを中止する(&S)";
			this.menuStopListen.Click += new System.EventHandler(this.menuStopListen_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 2;
			this.menuItem1.Text = "-";
			// 
			// menuDisconnectClient
			// 
			this.menuDisconnectClient.Enabled = false;
			this.menuDisconnectClient.Index = 3;
			this.menuDisconnectClient.Text = "選択したクライアントを切断する(&K)";
			this.menuDisconnectClient.Click += new System.EventHandler(this.menuDisconnectClient_Click);
			// 
			// menuDisconnectAllClient
			// 
			this.menuDisconnectAllClient.Enabled = false;
			this.menuDisconnectAllClient.Index = 4;
			this.menuDisconnectAllClient.Text = "すべてのクライアントを切断する(&A)";
			this.menuDisconnectAllClient.Click += new System.EventHandler(this.menuDisconnectAllClient_Click);
			// 
			// logTextBox
			// 
			this.logTextBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.logTextBox.Location = new System.Drawing.Point(0, 0);
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.Size = new System.Drawing.Size(264, 229);
			this.logTextBox.TabIndex = 0;
			this.logTextBox.Text = "";
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(264, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 229);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// clientViewList
			// 
			this.clientViewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader1,
																							 this.columnHeader2});
			this.clientViewList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clientViewList.Location = new System.Drawing.Point(267, 0);
			this.clientViewList.Name = "clientViewList";
			this.clientViewList.Size = new System.Drawing.Size(149, 229);
			this.clientViewList.TabIndex = 2;
			this.clientViewList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "名前";
			this.columnHeader1.Width = 103;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "IP";
			this.columnHeader2.Width = 79;
			// 
			// mainStatusbar
			// 
			this.mainStatusbar.Location = new System.Drawing.Point(0, 229);
			this.mainStatusbar.Name = "mainStatusbar";
			this.mainStatusbar.Size = new System.Drawing.Size(416, 16);
			this.mainStatusbar.TabIndex = 3;
			// 
			// ServerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(416, 245);
			this.Controls.Add(this.clientViewList);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.logTextBox);
			this.Controls.Add(this.mainStatusbar);
			this.Menu = this.menuMain;
			this.Name = "ServerForm";
			this.Text = "Dobon Chat Server";
			this.Load += new System.EventHandler(this.ServerForm_Load);
			this.Closed += new System.EventHandler(this.ServerForm_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ServerForm());
		}

		private delegate void PrintStringInvoker(string str, Color col);

		private DobonChatServer server;

		#region メソッド
		/// <summary>
		/// Listenを開始する
		/// </summary>
		/// <param name="hostName"></param>
		/// <param name="port"></param>
		public void Listen(string hostName, int port)
		{
			if (this.server != null)
			{
				MessageBox.Show(this,
					"すでにListen中です。",
					"エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.server = new DobonChatServer();
			try
			{
				this.server.Listen(hostName, port);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,
					"Listenに失敗しました。\n(" + ex.Message + ")",
					"エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//イベントハンドラを追加
			this.server.AcceptedClient += new ServerEventHandler(server_AcceptedClient);
			this.server.DisconnectedClient += new ServerEventHandler(server_DisconnectClient);
			this.server.ReceivedData += new ReceivedDataEventHandler(server_ReceivedData);
			this.server.LoggedinMember += new ServerEventHandler(server_LoggedinMember);
			this.server.LoggedoutMember += new ServerEventHandler(server_LoggedoutMember);

			//ステータスバーに表示
			this.ShowMessage(this.server.LocalEndPoint.ToString() + "をListen中...");
			this.AddLog(this.server.LocalEndPoint.ToString() + 
				"のListenを開始しました。", Color.Gray);

			this.menuListen.Enabled = false;
			this.menuDisconnectAllClient.Enabled = true;
			this.menuDisconnectClient.Enabled = true;
			this.menuStopListen.Enabled = true;
		}
		public void Listen()
		{
			this.Listen("0.0.0.0", 2345);
		}

		/// <summary>
		/// Listenを中止する
		/// </summary>
		public void StopListen()
		{
			if (this.server == null)
			{
				MessageBox.Show(this,
					"Listenしていません。",
					"エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.server.Close();
			this.server = null;

			//ステータスバーに表示
			this.ShowMessage("Listenしていません");
			this.AddLog("Listenを中止しました。", Color.Gray);

			this.menuListen.Enabled = true;
			this.menuDisconnectAllClient.Enabled = false;
			this.menuDisconnectClient.Enabled = false;
			this.menuStopListen.Enabled = false;
		}

		/// <summary>
		/// ステータスバーに文字列を表示する
		/// </summary>
		/// <param name="str"></param>
		public void ShowMessage(string str)
		{
			if (this.InvokeRequired)
				this.Invoke(new PrintStringInvoker(PrivateShowMessage),
					new object[] {str, Color.Empty});
			else
				this.PrivateShowMessage(str, Color.Empty);
		}
		private void PrivateShowMessage(string str, Color col)
		{
			this.mainStatusbar.Text = str;
		}

		/// <summary>
		/// ログに文字列を一行追加する
		/// </summary>
		/// <param name="str"></param>
		/// <param name="col"></param>
		public void AddLog(string str, Color col)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new PrintStringInvoker(PrivateAddLog),
					new object[] {str, col});
			}
			else
			{
				this.PrivateAddLog(str, col);
			}
		}
		private void PrivateAddLog(string str, Color col)
		{
			string addText = DateTime.Now.ToLongTimeString() + " : " + str + "\n";

			//MaxLengthを超えて表示されるとき
			if (logTextBox.TextLength + addText.Length > logTextBox.MaxLength)
			{
				int delLen = logTextBox.TextLength + addText.Length - logTextBox.MaxLength;
				delLen = logTextBox.Text.IndexOf('\n', delLen) + 1;
				logTextBox.Select(0, delLen);
				logTextBox.SelectedText = "";
			}

			logTextBox.SelectionStart = logTextBox.TextLength;
			logTextBox.SelectionLength = 0;
			logTextBox.SelectionColor = col;
			logTextBox.AppendText(addText);
			logTextBox.SelectionStart = logTextBox.TextLength;
			logTextBox.Focus();
			logTextBox.ScrollToCaret();
		}

		/// <summary>
		/// メンバーリストを更新する
		/// </summary>
		public void UpdateClientList()
		{
			if (this.InvokeRequired)
				this.Invoke(new MethodInvoker(PrivateUpdateClientList),
					new object[] {});
			else
				this.PrivateUpdateClientList();
		}
		private void PrivateUpdateClientList()
		{
			TcpChatClient[] clients = this.server.AcceptedClients;
			//リストをクリア
			this.clientViewList.Items.Clear();
			//クライアントをリストに追加
			foreach (AcceptedChatClient c in clients)
			{
				ListViewItem item = new ListViewItem();
				if (c.LoginState == LoginState.Joined)
				{
					item.Text = c.Name;
				}
				else
				{
					item.Text = "(参加していません)";
				}
				item.Tag = c;
				item.SubItems.Add(c.RemoteEndPoint.Address.ToString());
				this.clientViewList.Items.Add(item);
			}
		}
		#endregion

		#region フォームとコントロールのイベントハンドラ
		//フォームのロード
		private void ServerForm_Load(object sender, System.EventArgs e)
		{
			this.Listen();
		}

		//フォームを閉じた時
		private void ServerForm_Closed(object sender, System.EventArgs e)
		{
			if (this.server != null)
			{
				this.server.Close();
			}
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//Listen開始
		private void menuListen_Click(object sender, System.EventArgs e)
		{
			this.Listen();
		}

		//Listen終了
		private void menuStopListen_Click(object sender, System.EventArgs e)
		{
			this.StopListen();
		}

		//クライアント切断
		private void menuDisconnectClient_Click(object sender, System.EventArgs e)
		{
			if (clientViewList.SelectedItems.Count == 0)
			{
				MessageBox.Show(this,
					"クライアントが選択されていません。",
					"エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			foreach (ListViewItem item in clientViewList.SelectedItems)
			{
				((AcceptedChatClient) item.Tag).Close();
			}
		}

		//すべてのクライアントを切断
		private void menuDisconnectAllClient_Click(object sender, System.EventArgs e)
		{
			this.server.CloseAllClients();
		}
		#endregion

		#region DobonChatServerのイベントハンドラ
		//クライアントを受け入れた時
		private void server_AcceptedClient(object sender, ServerEventArgs e)
		{
			this.UpdateClientList();
			this.AddLog(string.Format("({0})が接続しました。",
				e.Client.RemoteEndPoint.Address.ToString()),
				Color.Black);
		}

		//クライアントが切断した時
		private void server_DisconnectClient(object sender, ServerEventArgs e)
		{
			this.UpdateClientList();
			this.AddLog(string.Format("[{0}]({1})が切断しました。",
				((AcceptedChatClient) e.Client).Name,
				e.Client.RemoteEndPoint.Address.ToString()),
				Color.Black);
		}

		//クライアントからデータを受信した時
		private void server_ReceivedData(object sender, ReceivedDataEventArgs e)
		{
			string str =
				e.Client.RemoteEndPoint.Address.ToString() +
				" > " + e.ReceivedString;
			this.AddLog(str, Color.LightGray);
		}

		//メンバーがログインしたとき
		private void server_LoggedinMember(object sender, ServerEventArgs e)
		{
			this.UpdateClientList();
			this.AddLog(string.Format("{0}が参加しました。",
				((AcceptedChatClient) e.Client).Name),
				Color.Black);
		}

		//メンバーがログアウトした時
		private void server_LoggedoutMember(object sender, ServerEventArgs e)
		{
			this.UpdateClientList();
			this.AddLog(string.Format("{0}が退室しました。",
				((AcceptedChatClient) e.Client).Name),
				Color.Black);
		}
		#endregion
	}
}
