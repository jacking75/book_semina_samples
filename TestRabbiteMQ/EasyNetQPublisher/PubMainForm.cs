using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyNetQPublisher
{
    public partial class PubMainForm : Form
    {
        EasyNetQ.IBus AMPQBus;


        public PubMainForm()
        {
            InitializeComponent();
        }

        private void PubMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                AMPQBus = EasyNetQ.RabbitHutch.CreateBus("host=172.20.60.221;virtualHost=/;username=Dev1;password=~123qwe");
            }
            catch(Exception ex)
            {
                listBox1.Items.Add("Error: " + ex.ToString());
            }
        }

        private void PubMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AMPQBus.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AMPQBus.Publish(new CommonMessages.TextMessage
                {
                    Text = textBox1.Text
                });
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AMPQBus.Publish(new CommonMessages.TextMessage2
                {
                    Type = "[NTF]",
                    Text = textBox1.Text
                });
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error: " + ex.ToString());
            }
        }

        
    }
}
