using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyNetQSubscriber
{
    public partial class SubMainForm : Form
    {
        EasyNetQ.IBus AMPQBus;
        
        delegate void SetTextCallback(string text);


        public SubMainForm()
        {
            InitializeComponent();
        }

        private void SubMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                AMPQBus = EasyNetQ.RabbitHutch.CreateBus("host=172.20.60.221;virtualHost=/;username=Dev1;password=~123qwe");
                AMPQBus.Subscribe<CommonMessages.TextMessage>("test", this.HandleTextMessage);
                AMPQBus.Subscribe<CommonMessages.TextMessage2>("test", this.HandleTextMessage2);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error: " + ex.ToString());
            }
        }

        private void SubMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AMPQBus.Dispose();
        }

        void HandleTextMessage(CommonMessages.TextMessage textMessage)
        {
            SetText(string.Format("[{0}] Got message: {1}", DateTime.Now, textMessage.Text));
        }
        void HandleTextMessage2(CommonMessages.TextMessage2 textMessage)
        {
            SetText(string.Format("[{0}] Got message: {1} {2}", DateTime.Now, textMessage.Type, textMessage.Text));
        }


        void SetText(string textMessage)
        {
            if (this.listBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { textMessage });
            }
            else
            {
                this.listBox1.Items.Add(textMessage);
            }
        }

        
    }
}
