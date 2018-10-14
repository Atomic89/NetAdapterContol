using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetAdapterController
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            EnableButton.Enabled = false; 
            DisableButton.Enabled = false;
        }
        
        private void searchAdapters_Click(object sender, EventArgs e)
        {
            List<NetworkAdapter> netList = NetworkAdapter.GetAllNetworkAdapter();
            adaptersListTextBox.Text = "";
            foreach (NetworkAdapter netAdapter in netList)
            {
                adaptersListTextBox.Text += "Имя подключения:" + netAdapter.Name + Environment.NewLine;
                adaptersListTextBox.Text += "Статус подключения:" + NetworkAdapter.SaNetConnectionStatus[netAdapter.NetConnectionStatus] + Environment.NewLine;
                adaptersListTextBox.Text += "Id устройства:" + netAdapter.DeviceId + Environment.NewLine;
            }

            EnableButton.Enabled = true;
            DisableButton.Enabled = true;
        }

        private void EnableButton_Click(object sender, EventArgs e)
        {
            if (ConnectionStatus.Text != "Устройство включено!" && IdDeviceTextBox.Text != "")
            {
                ConnectionStatus.Text = "";
                NetworkAdapter.EnableDisabledConnection(Convert.ToInt32(IdDeviceTextBox.Text), true);
                ConnectionStatus.Text = "Устройство включено!";
            }
        }

        private void DisableButton_Click(object sender, EventArgs e)
        {
            if (ConnectionStatus.Text != "Устройство выключено!" && IdDeviceTextBox.Text != "")
            {
                ConnectionStatus.Text = "";
                NetworkAdapter.EnableDisabledConnection(Convert.ToInt32(IdDeviceTextBox.Text), false);
                ConnectionStatus.Text = "Устройство выключено!";
            }
        }
    }
}
