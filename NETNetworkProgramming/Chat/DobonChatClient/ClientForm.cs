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
	/// Form1 �̊T�v�̐����ł��B
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
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ClientForm()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
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

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
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
			this.menuFile.Text = "�t�@�C��(&F)";
			// 
			// menuExit
			// 
			this.menuExit.Index = 0;
			this.menuExit.Text = "�I��(&X)";
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
			this.menuConnection.Text = "�ڑ�(C)";
			// 
			// menuConnect
			// 
			this.menuConnect.Index = 0;
			this.menuConnect.Text = "�T�[�o�[�ɐڑ�����...(&S)";
			this.menuConnect.Click += new System.EventHandler(this.menuConnect_Click);
			// 
			// menuDisconnect
			// 
			this.menuDisconnect.Enabled = false;
			this.menuDisconnect.Index = 1;
			this.menuDisconnect.Text = "�ؒf����(&D)";
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
			this.menuSendMessage.Text = "���b�Z�[�W�𑗐M(&M)";
			this.menuSendMessage.Click += new System.EventHandler(this.sendButton_Click);
			// 
			// menuSendPrivateMessage
			// 
			this.menuSendPrivateMessage.Enabled = false;
			this.menuSendPrivateMessage.Index = 4;
			this.menuSendPrivateMessage.Text = "�v���C�x�[�g���b�Z�[�W�𑗐M(&P)";
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
			this.sendButton.Text = "���M";
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
			this.columnHeader1.Text = "���O";
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
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ClientForm());
		}

		private delegate void PrintStringInvoker(string str, Color col);

		private DobonChatClient client;
		//�ڑ����̃����o�[�����X�g
		private System.Collections.Specialized.StringCollection membersList;

		/// <summary>
		/// �ڑ��_�C�A���O��\��
		/// </summary>
		public void ShowConnectDialog()
		{
			ConnectForm dlg = new ConnectForm();
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				//�ڑ�����
				this.Connect(dlg.HostName, dlg.Port, dlg.NickName);
			}
			dlg.Dispose();
		}

		/// <summary>
		/// �T�[�o�[�ɐڑ�����
		/// </summary>
		/// <param name="host"></param>
		/// <param name="port"></param>
		public void Connect(string host, int port, string nick)
		{
			if (this.client != null)
			{
				MessageBox.Show("���łɐڑ����Ă��܂��B");
				return;
			}

			DobonChatClient c = new DobonChatClient();
			//�C�x���g�n���h���̒ǉ�
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
				//�ڑ�����
				c.Connect(host, port, nick);
			}
			catch (Exception ex)
			{
				c.Close();
				MessageBox.Show(this,
					"�ڑ��Ɏ��s���܂����B\n(" + ex.Message + ")",
					"�G���[",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		/// <summary>
		/// ���b�Z�[�W�𑗐M����
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
					"�ڑ����Ă��܂���B",
					"�G���[",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (this.client.LoginState != LoginState.Joined)
			{
				MessageBox.Show(this,
					"�`���b�g�ɎQ�����Ă��܂���B",
					"�G���[",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (sendTextBox.Text.Length <= 0)
			{
				MessageBox.Show(this,
					"���M���镶�������͂��Ă��������B",
					"�G���[",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//�v���C�x�[�g���b�Z�[�W�̎�
			string to = "";
			if (privMsg)
			{
				if (memberListView.SelectedItems.Count == 0)
				{
					MessageBox.Show(this,
						"���M��̃����o�[���I������Ă��܂���B",
						"�G���[",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				to = memberListView.SelectedItems[0].Text;

				if (this.client.Name == to)
				{
					MessageBox.Show(this,
						"�������g�Ƀv���C�x�[�g���b�Z�[�W�͑���܂���B",
						"�G���[",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			try
			{
				//���b�Z�[�W�𑗐M
				if (!privMsg)
					this.client.SendMessage(sendTextBox.Text);
				else
					this.client.SendPrivateMessage(sendTextBox.Text, to);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,
					"���M�Ɏ��s���܂����B\n(" + ex.Message + ")",
					"�G���[",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			this.sendTextBox.Text = "";
			this.sendTextBox.Focus();
		}

		/// <summary>
		/// ���O�ɕ��������s�ǉ�����
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

			//MaxLength�𒴂��ĕ\�������Ƃ�
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
		/// �����o�[���X�g���X�V����
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

		//�ڑ���Ԃɂ���
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
			this.Text = Application.ProductName + " - �ڑ���(" +
				this.client.RemoteEndPoint.ToString() + ")";
		}

		//�ؒf��Ԃɂ���
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

		//����
		private void ClientForm_Closed(object sender, System.EventArgs e)
		{
			if (this.client != null)
				this.client.Close();
		}

		//�ڑ�����
		private void menuConnect_Click(object sender, System.EventArgs e)
		{
			this.ShowConnectDialog();
		}

		//�ؒf����
		private void menuDisconnect_Click(object sender, System.EventArgs e)
		{
			this.client.Close();
		}

		//���b�Z�[�W�𑗐M����
		private void sendButton_Click(object sender, System.EventArgs e)
		{
			this.Send();
		}

		//�v���C�x�[�g���b�Z�[�W�𑗐M����
		private void menuSendPrivateMessage_Click(object sender, System.EventArgs e)
		{
			this.Send(true);
		}

		//�I������
		private void menuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//�f�[�^����M����
		private void client_ReceivedData(object sender, ReceivedDataEventArgs e)
		{
			this.AddLog(e.ReceivedString, Color.LightGray);
		}

		//�T�[�o�[�ɐڑ�����
		private void client_Connected(object sender, EventArgs e)
		{
			this.client = (DobonChatClient) sender;
			this.Invoke(new MethodInvoker(this.SetToConnected));
			this.AddLog("�T�[�o�[�ɐڑ����܂����B",
				Color.Blue);
		}

		//�ؒf����
		private void client_Disconnected(object sender, EventArgs e)
		{
			this.client = null;
			this.Invoke(new MethodInvoker(this.SetToDisconnected));
			this.AddLog("�T�[�o�[����ؒf���܂����B",
				Color.Blue);
			if (this.membersList != null)
			{
				this.membersList.Clear();
				this.UpdateMembersList();
			}
		}

		//�����o�[���Q������
		private void client_JoinedMember(object sender, MemberEventArgs e)
		{
			if (this.client.Name == e.Name)
			{
				//���������O�C�������Ƃ�
				this.membersList = new System.Collections.Specialized.StringCollection();
				this.AddLog("�`���b�g�ւ̎Q���ɐ������܂����B",
					Color.Blue);
			}
			else
			{
				//�N�������O�C�������Ƃ�
				this.AddLog(string.Format("[{0}]���񂪎Q�����܂����B", e.Name),
					Color.Blue);
			}

			//�����o�[���X�g���X�V
			this.membersList.Add(e.Name);
			this.UpdateMembersList();
		}

		//�����o�[���ގ�����
		private void client_PartedMember(object sender, MemberEventArgs e)
		{
			if (this.client.Name == e.Name)
			{
				//���������O�A�E�g�����Ƃ�
				this.membersList.Clear();
				this.AddLog("�ގ����܂����B",
					Color.Blue);
			}
			else
			{
				//�N�������O�A�E�g�����Ƃ�
				this.membersList.Remove(e.Name);
				this.AddLog(string.Format("[{0}]���񂪑ގ����܂����B", e.Name),
					Color.Blue);
			}

			//�����o�[���X�g���X�V
			this.UpdateMembersList();
		}

		//���b�Z�[�W����M����
		private void client_ReceivedMessage(object sender, ReceivedMessageEventArgs e)
		{
			if (!e.PrivateMessage)
				this.AddLog(e.From + " > " + e.Message, Color.Black);
			else
				this.AddLog(e.From + " > " + e.Message, Color.Brown);
		}

		//�����o�[���X�g����M����
		private void client_UpdatedMembers(object sender, MembersListEventArgs e)
		{
			//�����o�[���X�g���X�V
			this.membersList.Clear();
			this.membersList.AddRange(e.Members);
			this.UpdateMembersList();
		}

		//�G���[����M����
		private void client_ReceivedError(object sender, ReceivedErrorEventArgs e)
		{
			this.AddLog("�G���[ : " + e.ErrorMessage, Color.Red);

			if (this.client.LoginState != LoginState.Joined)
			{
				//�G���[�ŕ���
				this.client.Close();
			}
		}
	}
}
