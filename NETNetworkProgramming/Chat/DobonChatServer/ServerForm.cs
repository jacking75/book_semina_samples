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
	/// ServerForm �̊T�v�̐����ł��B
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
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ServerForm()
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
			this.menuFile.Text = "�t�@�C��(&F)";
			// 
			// menuExit
			// 
			this.menuExit.Index = 0;
			this.menuExit.Text = "�I��(&X)";
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
			this.menuConnect.Text = "�ڑ�(C)";
			// 
			// menuListen
			// 
			this.menuListen.Index = 0;
			this.menuListen.Text = "Listen���J�n����(&L)";
			this.menuListen.Click += new System.EventHandler(this.menuListen_Click);
			// 
			// menuStopListen
			// 
			this.menuStopListen.Enabled = false;
			this.menuStopListen.Index = 1;
			this.menuStopListen.Text = "Listen�𒆎~����(&S)";
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
			this.menuDisconnectClient.Text = "�I�������N���C�A���g��ؒf����(&K)";
			this.menuDisconnectClient.Click += new System.EventHandler(this.menuDisconnectClient_Click);
			// 
			// menuDisconnectAllClient
			// 
			this.menuDisconnectAllClient.Enabled = false;
			this.menuDisconnectAllClient.Index = 4;
			this.menuDisconnectAllClient.Text = "���ׂẴN���C�A���g��ؒf����(&A)";
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
			this.columnHeader1.Text = "���O";
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
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ServerForm());
		}

		private delegate void PrintStringInvoker(string str, Color col);

		private DobonChatServer server;

		#region ���\�b�h
		/// <summary>
		/// Listen���J�n����
		/// </summary>
		/// <param name="hostName"></param>
		/// <param name="port"></param>
		public void Listen(string hostName, int port)
		{
			if (this.server != null)
			{
				MessageBox.Show(this,
					"���ł�Listen���ł��B",
					"�G���[",
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
					"Listen�Ɏ��s���܂����B\n(" + ex.Message + ")",
					"�G���[",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//�C�x���g�n���h����ǉ�
			this.server.AcceptedClient += new ServerEventHandler(server_AcceptedClient);
			this.server.DisconnectedClient += new ServerEventHandler(server_DisconnectClient);
			this.server.ReceivedData += new ReceivedDataEventHandler(server_ReceivedData);
			this.server.LoggedinMember += new ServerEventHandler(server_LoggedinMember);
			this.server.LoggedoutMember += new ServerEventHandler(server_LoggedoutMember);

			//�X�e�[�^�X�o�[�ɕ\��
			this.ShowMessage(this.server.LocalEndPoint.ToString() + "��Listen��...");
			this.AddLog(this.server.LocalEndPoint.ToString() + 
				"��Listen���J�n���܂����B", Color.Gray);

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
		/// Listen�𒆎~����
		/// </summary>
		public void StopListen()
		{
			if (this.server == null)
			{
				MessageBox.Show(this,
					"Listen���Ă��܂���B",
					"�G���[",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.server.Close();
			this.server = null;

			//�X�e�[�^�X�o�[�ɕ\��
			this.ShowMessage("Listen���Ă��܂���");
			this.AddLog("Listen�𒆎~���܂����B", Color.Gray);

			this.menuListen.Enabled = true;
			this.menuDisconnectAllClient.Enabled = false;
			this.menuDisconnectClient.Enabled = false;
			this.menuStopListen.Enabled = false;
		}

		/// <summary>
		/// �X�e�[�^�X�o�[�ɕ������\������
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
		private void PrivateAddLog(string str, Color col)
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
		}

		/// <summary>
		/// �����o�[���X�g���X�V����
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
			//���X�g���N���A
			this.clientViewList.Items.Clear();
			//�N���C�A���g�����X�g�ɒǉ�
			foreach (AcceptedChatClient c in clients)
			{
				ListViewItem item = new ListViewItem();
				if (c.LoginState == LoginState.Joined)
				{
					item.Text = c.Name;
				}
				else
				{
					item.Text = "(�Q�����Ă��܂���)";
				}
				item.Tag = c;
				item.SubItems.Add(c.RemoteEndPoint.Address.ToString());
				this.clientViewList.Items.Add(item);
			}
		}
		#endregion

		#region �t�H�[���ƃR���g���[���̃C�x���g�n���h��
		//�t�H�[���̃��[�h
		private void ServerForm_Load(object sender, System.EventArgs e)
		{
			this.Listen();
		}

		//�t�H�[���������
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

		//Listen�J�n
		private void menuListen_Click(object sender, System.EventArgs e)
		{
			this.Listen();
		}

		//Listen�I��
		private void menuStopListen_Click(object sender, System.EventArgs e)
		{
			this.StopListen();
		}

		//�N���C�A���g�ؒf
		private void menuDisconnectClient_Click(object sender, System.EventArgs e)
		{
			if (clientViewList.SelectedItems.Count == 0)
			{
				MessageBox.Show(this,
					"�N���C�A���g���I������Ă��܂���B",
					"�G���[",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			foreach (ListViewItem item in clientViewList.SelectedItems)
			{
				((AcceptedChatClient) item.Tag).Close();
			}
		}

		//���ׂẴN���C�A���g��ؒf
		private void menuDisconnectAllClient_Click(object sender, System.EventArgs e)
		{
			this.server.CloseAllClients();
		}
		#endregion

		#region DobonChatServer�̃C�x���g�n���h��
		//�N���C�A���g���󂯓��ꂽ��
		private void server_AcceptedClient(object sender, ServerEventArgs e)
		{
			this.UpdateClientList();
			this.AddLog(string.Format("({0})���ڑ����܂����B",
				e.Client.RemoteEndPoint.Address.ToString()),
				Color.Black);
		}

		//�N���C�A���g���ؒf������
		private void server_DisconnectClient(object sender, ServerEventArgs e)
		{
			this.UpdateClientList();
			this.AddLog(string.Format("[{0}]({1})���ؒf���܂����B",
				((AcceptedChatClient) e.Client).Name,
				e.Client.RemoteEndPoint.Address.ToString()),
				Color.Black);
		}

		//�N���C�A���g����f�[�^����M������
		private void server_ReceivedData(object sender, ReceivedDataEventArgs e)
		{
			string str =
				e.Client.RemoteEndPoint.Address.ToString() +
				" > " + e.ReceivedString;
			this.AddLog(str, Color.LightGray);
		}

		//�����o�[�����O�C�������Ƃ�
		private void server_LoggedinMember(object sender, ServerEventArgs e)
		{
			this.UpdateClientList();
			this.AddLog(string.Format("{0}���Q�����܂����B",
				((AcceptedChatClient) e.Client).Name),
				Color.Black);
		}

		//�����o�[�����O�A�E�g������
		private void server_LoggedoutMember(object sender, ServerEventArgs e)
		{
			this.UpdateClientList();
			this.AddLog(string.Format("{0}���ގ����܂����B",
				((AcceptedChatClient) e.Client).Name),
				Color.Black);
		}
		#endregion
	}
}
