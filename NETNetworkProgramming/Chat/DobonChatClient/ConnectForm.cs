using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DobonChatClientApplication
{
	/// <summary>
	/// ConnectForm の概要の説明です。
	/// </summary>
	public class ConnectForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox hostTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.NumericUpDown portUpDown;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox nameTextBox;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConnectForm()
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
				if(components != null)
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.portUpDown = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.hostTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.portUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.nameTextBox);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.portUpDown);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.hostTextBox);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(240, 120);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(96, 88);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(128, 19);
			this.nameTextBox.TabIndex = 5;
			this.nameTextBox.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 90);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "名前(&N):";
			// 
			// portUpDown
			// 
			this.portUpDown.Location = new System.Drawing.Point(96, 56);
			this.portUpDown.Maximum = new System.Decimal(new int[] {
																	   65535,
																	   0,
																	   0,
																	   0});
			this.portUpDown.Name = "portUpDown";
			this.portUpDown.Size = new System.Drawing.Size(128, 19);
			this.portUpDown.TabIndex = 3;
			this.portUpDown.Value = new System.Decimal(new int[] {
																	 2345,
																	 0,
																	 0,
																	 0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "ポート番号(&P):";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "ホスト名(&H):";
			// 
			// hostTextBox
			// 
			this.hostTextBox.Location = new System.Drawing.Point(96, 24);
			this.hostTextBox.Name = "hostTextBox";
			this.hostTextBox.Size = new System.Drawing.Size(128, 19);
			this.hostTextBox.TabIndex = 1;
			this.hostTextBox.Text = "localhost";
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(16, 136);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 1;
			this.okButton.Text = "接続";
			// 
			// closeButton
			// 
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(104, 136);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 2;
			this.closeButton.Text = "キャンセル";
			// 
			// ConnectForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(258, 170);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ConnectForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "サーバーへの接続";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.portUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public string HostName
		{
			get
			{
				return hostTextBox.Text;
			}
		}

		public int Port
		{
			get
			{
				return (int) portUpDown.Value;
			}
		}

		public string NickName
		{
			get
			{
				return nameTextBox.Text;
			}
		}
	}
}
