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
            try
            {
                if (IdDeviceTextBox.Text != "")
                {
                    ConnectionStatus.Text = "";
                    bool connectStatus = NetworkAdapter.EnableDisabledConnection(Convert.ToInt32(IdDeviceTextBox.Text), true);

                    if (connectStatus)
                    {
                        ConnectionStatus.Text = "Устройство включено!";
                    }
                    else
                    {
                        ConnectionStatus.Text = "Такого устройства нет!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);
            }
        }


        private void DisableButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdDeviceTextBox.Text != "")
                {
                    ConnectionStatus.Text = "";
                    bool connectStatus = NetworkAdapter.EnableDisabledConnection(Convert.ToInt32(IdDeviceTextBox.Text), false);

                    if (connectStatus)
                    {
                        ConnectionStatus.Text = "Устройство выключено!";
                    }
                    else
                    {
                        ConnectionStatus.Text = "Такого устройства нет!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);

            }

        }
    }
}

