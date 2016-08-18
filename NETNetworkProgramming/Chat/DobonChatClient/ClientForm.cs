using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Dobon.Net.Chat;

namespace DobonChatClientApplication
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public class ClientForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RichTextBox logTextBox;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TextBox sendTextBox;
		private System.Windows.Forms.Button sendButton;
		private System.Windows.Forms.ListView memberListView;
		private System.Windows.Forms.MainMenu menuMain;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuDisconnect;
		private System.Windows.Forms.MenuItem menuConnection;
		private System.Windows.Forms.MenuItem menuConnect;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuSendMessage;
		private System.Windows.Forms.MenuItem menuSendPrivateMessage;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ClientForm()
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
			this.menuConnection = new System.Windows.Forms.MenuItem();
			this.menuConnect = new System.Windows.Forms.MenuItem();
			this.menuDisconnect = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuSendMessage = new System.Windows.Forms.MenuItem();
			this.menuSendPrivateMessage = new System.Windows.Forms.MenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.sendButton = new System.Windows.Forms.Button();
			this.sendTextBox = new System.Windows.Forms.TextBox();
			this.logTextBox = new System.Windows.Forms.RichTextBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.memberListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.menuConnection});
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
			// menuConnection
			// 
			this.menuConnection.Index = 1;
			this.menuConnection.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.menuConnect,
																						   this.menuDisconnect,
																						   this.menuItem1,
																						   this.menuSendMessage,
																						   this.menuSendPrivateMessage});
			this.menuConnection.Text = "接続(C)";
			// 
			// menuConnect
			// 
			this.menuConnect.Index = 0;
			this.menuConnect.Text = "サーバーに接続する...(&S)";
			this.menuConnect.Click += new System.EventHandler(this.menuConnect_Click);
			// 
			// menuDisconnect
			// 
			this.menuDisconnect.Enabled = false;
			this.menuDisconnect.Index = 1;
			this.menuDisconnect.Text = "切断する(&D)";
			this.menuDisconnect.Click += new System.EventHandler(this.menuDisconnect_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 2;
			this.menuItem1.Text = "-";
			// 
			// menuSendMessage
			// 
			this.menuSendMessage.Enabled = false;
			this.menuSendMessage.Index = 3;
			this.menuSendMessage.Text = "メッセージを送信(&M)";
			this.menuSendMessage.Click += new System.EventHandler(this.sendButton_Click);
			// 
			// menuSendPrivateMessage
			// 
			this.menuSendPrivateMessage.Enabled = false;
			this.menuSendPrivateMessage.Index = 4;
			this.menuSendPrivateMessage.Text = "プライベートメッセージを送信(&P)";
			this.menuSendPrivateMessage.Click += new System.EventHandler(this.menuSendPrivateMessage_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.sendButton);
			this.panel1.Controls.Add(this.sendTextBox);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 253);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(424, 24);
			this.panel1.TabIndex = 0;
			// 
			// sendButton
			// 
			this.sendButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.sendButton.Enabled = false;
			this.sendButton.Location = new System.Drawing.Point(376, 1);
			this.sendButton.Name = "sendButton";
			this.sendButton.Size = new System.Drawing.Size(48, 23);
			this.sendButton.TabIndex = 1;
			this.sendButton.Text = "送信";
			this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
			// 
			// sendTextBox
			// 
			this.sendTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.sendTextBox.Location = new System.Drawing.Point(0, 3);
			this.sendTextBox.Name = "sendTextBox";
			this.sendTextBox.Size = new System.Drawing.Size(376, 19);
			this.sendTextBox.TabIndex = 0;
			this.sendTextBox.Text = "";
			// 
			// logTextBox
			// 
			this.logTextBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.logTextBox.Location = new System.Drawing.Point(0, 0);
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.Size = new System.Drawing.Size(304, 253);
			this.logTextBox.TabIndex = 1;
			this.logTextBox.Text = "";
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(304, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 253);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// memberListView
			// 
			this.memberListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader1});
			this.memberListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memberListView.Location = new System.Drawing.Point(307, 0);
			this.memberListView.Name = "memberListView";
			this.memberListView.Size = new System.Drawing.Size(117, 253);
			this.memberListView.TabIndex = 3;
			this.memberListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "名前";
			this.columnHeader1.Width = 106;
			// 
			// ClientForm
			// 
			this.AcceptButton = this.sendButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(424, 277);
			this.Controls.Add(this.memberListView);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.logTextBox);
			this.Controls.Add(this.panel1);
			this.Menu = this.menuMain;
			this.Name = "ClientForm";
			this.Text = "Dobon Chat Client";
			this.Closed += new System.EventHandler(this.ClientForm_Closed);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ClientForm());
		}

		private delegate void PrintStringInvoker(string str, Color col);

		private DobonChatClient client;
		//接続中のメンバー名リスト
		private System.Collections.Specialized.StringCollection membersList;

		/// <summary>
		/// 接続ダイアログを表示
		/// </summary>
		public void ShowConnectDialog()
		{
			ConnectForm dlg = new ConnectForm();
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				//接続する
				this.Connect(dlg.HostName, dlg.Port, dlg.NickName);
			}
			dlg.Dispose();
		}

		/// <summary>
		/// サーバーに接続する
		/// </summary>
		/// <param name="host"></param>
		/// <param name="port"></param>
		public void Connect(string host, int port, string nick)
		{
			if (this.client != null)
			{
				MessageBox.Show("すでに接続しています。");
				return;
			}

			DobonChatClient c = new DobonChatClient();
			//イベントハンドラの追加
			c.Connected += new EventHandler(client_Connected);
			c.Disconnected += new EventHandler(client_Disconnected);
			c.ReceivedData += new ReceivedDataEventHandler(client_ReceivedData);
			c.JoinedMember += new MemberEventHandler(client_JoinedMember);
			c.PartedMember += new MemberEventHandler(client_PartedMember);
			c.ReceivedMessage += new ReceivedMessageEventHandler(client_ReceivedMessage);
			c.UpdatedMembers += new MembersListEventHandler(client_UpdatedMembers);
			c.ReceivedError += new ReceivedErrorEventHandler(client_ReceivedError);

			try
			{
				//接続する
				c.Connect(host, port, nick);
			}
			catch (Exception ex)
			{
				c.Close();
				MessageBox.Show(this,
					"接続に失敗しました。\n(" + ex.Message + ")",
					"エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		/// <summary>
		/// メッセージを送信する
		/// </summary>
		public void Send()
		{
			this.Send(false);
		}
		public void Send(bool privMsg)
		{
			if (this.client == null)
			{
				MessageBox.Show(this,
					"接続していません。",
					"エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (this.client.LoginState != LoginState.Joined)
			{
				MessageBox.Show(this,
					"チャットに参加していません。",
					"エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (sendTextBox.Text.Length <= 0)
			{
				MessageBox.Show(this,
					"送信する文字列を入力してください。",
					"エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//プライベートメッセージの時
			string to = "";
			if (privMsg)
			{
				if (memberListView.SelectedItems.Count == 0)
				{
					MessageBox.Show(this,
						"送信先のメンバーが選択されていません。",
						"エラー",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				to = memberListView.SelectedItems[0].Text;

				if (this.client.Name == to)
				{
					MessageBox.Show(this,
						"自分自身にプライベートメッセージは送れません。",
						"エラー",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			try
			{
				//メッセージを送信
				if (!privMsg)
					this.client.SendMessage(sendTextBox.Text);
				else
					this.client.SendPrivateMessage(sendTextBox.Text, to);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,
					"送信に失敗しました。\n(" + ex.Message + ")",
					"エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			this.sendTextBox.Text = "";
			this.sendTextBox.Focus();
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
		public void PrivateAddLog(string str, Color col)
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

			sendTextBox.Focus();
		}

		/// <summary>
		/// メンバーリストを更新する
		/// </summary>
		public void UpdateMembersList()
		{
			if (this.InvokeRequired)
				this.Invoke(new MethodInvoker(PrivateUpdateMembersList),
					new object[] {});
			else
				this.PrivateUpdateMembersList();
		}
		private void PrivateUpdateMembersList()
		{
			this.memberListView.Items.Clear();
			foreach (string nick in this.membersList)
			{
				ListViewItem item = new ListViewItem(nick);
				if (this.client.Name == nick)
				{
					item.ForeColor = Color.Red;
				}
				this.memberListView.Items.Add(item);
			}
		}

		//接続状態にする
		public void SetToConnected()
		{
			if (this.InvokeRequired)
				this.Invoke(new MethodInvoker(PrivateSetToConnected),
					new object[] {});
			else
				this.PrivateSetToConnected();
		}
		private void PrivateSetToConnected()
		{
			this.sendButton.Enabled = true;
			this.menuConnect.Enabled = false;
			this.menuDisconnect.Enabled = true;
			this.menuSendMessage.Enabled = true;
			this.menuSendPrivateMessage.Enabled = true;
			this.Text = Application.ProductName + " - 接続中(" +
				this.client.RemoteEndPoint.ToString() + ")";
		}

		//切断状態にする
		public void SetToDisconnected()
		{
			if (this.InvokeRequired)
				this.Invoke(new MethodInvoker(PrivateSetToDisconnected),
					new object[] {});
			else
				this.PrivateSetToDisconnected();
		}
		private void PrivateSetToDisconnected()
		{
			this.sendButton.Enabled = false;
			this.menuConnect.Enabled = true;
			this.menuDisconnect.Enabled = false;
			this.menuSendMessage.Enabled = false;
			this.menuSendPrivateMessage.Enabled = false;
			this.Text = Application.ProductName;
			this.client = null;
		}

		//閉じる
		private void ClientForm_Closed(object sender, System.EventArgs e)
		{
			if (this.client != null)
				this.client.Close();
		}

		//接続する
		private void menuConnect_Click(object sender, System.EventArgs e)
		{
			this.ShowConnectDialog();
		}

		//切断する
		private void menuDisconnect_Click(object sender, System.EventArgs e)
		{
			this.client.Close();
		}

		//メッセージを送信する
		private void sendButton_Click(object sender, System.EventArgs e)
		{
			this.Send();
		}

		//プライベートメッセージを送信する
		private void menuSendPrivateMessage_Click(object sender, System.EventArgs e)
		{
			this.Send(true);
		}

		//終了する
		private void menuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//データを受信した
		private void client_ReceivedData(object sender, ReceivedDataEventArgs e)
		{
			this.AddLog(e.ReceivedString, Color.LightGray);
		}

		//サーバーに接続した
		private void client_Connected(object sender, EventArgs e)
		{
			this.client = (DobonChatClient) sender;
			this.Invoke(new MethodInvoker(this.SetToConnected));
			this.AddLog("サーバーに接続しました。",
				Color.Blue);
		}

		//切断した
		private void client_Disconnected(object sender, EventArgs e)
		{
			this.client = null;
			this.Invoke(new MethodInvoker(this.SetToDisconnected));
			this.AddLog("サーバーから切断しました。",
				Color.Blue);
			if (this.membersList != null)
			{
				this.membersList.Clear();
				this.UpdateMembersList();
			}
		}

		//メンバーが参加した
		private void client_JoinedMember(object sender, MemberEventArgs e)
		{
			if (this.client.Name == e.Name)
			{
				//自分がログインしたとき
				this.membersList = new System.Collections.Specialized.StringCollection();
				this.AddLog("チャットへの参加に成功しました。",
					Color.Blue);
			}
			else
			{
				//誰かがログインしたとき
				this.AddLog(string.Format("[{0}]さんが参加しました。", e.Name),
					Color.Blue);
			}

			//メンバーリストを更新
			this.membersList.Add(e.Name);
			this.UpdateMembersList();
		}

		//メンバーが退室した
		private void client_PartedMember(object sender, MemberEventArgs e)
		{
			if (this.client.Name == e.Name)
			{
				//自分がログアウトしたとき
				this.membersList.Clear();
				this.AddLog("退室しました。",
					Color.Blue);
			}
			else
			{
				//誰かがログアウトしたとき
				this.membersList.Remove(e.Name);
				this.AddLog(string.Format("[{0}]さんが退室しました。", e.Name),
					Color.Blue);
			}

			//メンバーリストを更新
			this.UpdateMembersList();
		}

		//メッセージを受信した
		private void client_ReceivedMessage(object sender, ReceivedMessageEventArgs e)
		{
			if (!e.PrivateMessage)
				this.AddLog(e.From + " > " + e.Message, Color.Black);
			else
				this.AddLog(e.From + " > " + e.Message, Color.Brown);
		}

		//メンバーリストを受信した
		private void client_UpdatedMembers(object sender, MembersListEventArgs e)
		{
			//メンバーリストを更新
			this.membersList.Clear();
			this.membersList.AddRange(e.Members);
			this.UpdateMembersList();
		}

		//エラーを受信した
		private void client_ReceivedError(object sender, ReceivedErrorEventArgs e)
		{
			this.AddLog("エラー : " + e.ErrorMessage, Color.Red);

			if (this.client.LoginState != LoginState.Joined)
			{
				//エラーで閉じる
				this.client.Close();
			}
		}
	}
}
