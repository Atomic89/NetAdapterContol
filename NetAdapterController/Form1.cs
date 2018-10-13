using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Management;
using System.Threading;

namespace NetAdapterController
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            label2.Text = "Устройство включено!";
            button2.Enabled = false; 
            button3.Enabled = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            List<NetworkAdapter> netList = NetworkAdapter.GetAllNetworkAdapter();
            richTextBox1.Text = "";
            foreach (NetworkAdapter netAdapter in netList)
            {
                richTextBox1.Text +="Имя подключения:" + netAdapter.Name + Environment.NewLine;
                richTextBox1.Text +="Статус подключения:" + NetworkAdapter.SaNetConnectionStatus[netAdapter.NetConnectionStatus] + Environment.NewLine;
                richTextBox1.Text += "Id устройства:" + netAdapter.DeviceId;
            }

            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text != "Устройство включено!" && textBox1.Text != "")
            {
                label2.Text = "";
                NetworkAdapter.EnableDisabledConnection(Convert.ToInt32(textBox1.Text), true);
                label2.Text = "Устройство включено!";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text != "Устройство выключено!" && textBox1.Text != "")
            {
                label2.Text = "";
                NetworkAdapter.EnableDisabledConnection(Convert.ToInt32(textBox1.Text), false);
                label2.Text = "Устройство выключено!";
            }
        }
    }
}
