using NetAdapterController.Properties;
using System;
using System.Collections.Generic;
using System.Management;

namespace NetAdapterController
{
    internal class NetworkAdapter
    {
        #region NetworkAdapter Properties 


        /// <summary> 
        /// The DeviceId of the NetworkAdapter 
        /// </summary> 
        public int DeviceId
        {
            get;
            private set;
        }

        /// <summary> 
        /// The ProductName of the NetworkAdapter 
        /// </summary> 
        public string Name
        {
            get;
            private set;
        }


        /// <summary> 
        /// The NetEnabled status of the NetworkAdapter 
        /// </summary> 
        public int NetEnabled
        {
            get;
            private set;
        }


        /// <summary> 
        /// The Net Connection Status Value 
        /// </summary> 
        public int NetConnectionStatus
        {
            get;
            private set;
        }


        /// <summary> 
        /// The Net Connection Status Description 
        /// </summary> 
        public static string[] SaNetConnectionStatus =
        {
        Resources.NetConnectionStatus0,
        Resources.NetConnectionStatus1,
        Resources.NetConnectionStatus2,
        Resources.NetConnectionStatus3,
        Resources.NetConnectionStatus4,
        Resources.NetConnectionStatus5,
        Resources.NetConnectionStatus6,
        Resources.NetConnectionStatus7,
        Resources.NetConnectionStatus8,
        Resources.NetConnectionStatus9,
        Resources.NetConnectionStatus10,
        Resources.NetConnectionStatus11,
        Resources.NetConnectionStatus12
    };


        /// <summary> 
        /// Enum the NetEnabled Status 
        /// </summary> 
        private enum EnumNetEnabledStatus
        {
            Disabled = -1,
            Unknow,
            Enabled
        }


        /// <summary> 
        /// Enum the Operation reuslt of Enable and Disable  Network Adapter 
        /// </summary> 
        private enum EnumEnableDisableResult
        {
            Fail = -1,
            Unknow,
            Success
        }


        #endregion


        #region Construct NetworkAdapter 


        public NetworkAdapter(int deviceId,
            string name,
            int netEnabled,
            int netConnectionStatus)
        {
            DeviceId = deviceId;
            Name = name;
            NetEnabled = netEnabled;
            NetConnectionStatus = netConnectionStatus;
        }
        #endregion


        #region Get All NetworkAdapters

        /// <summary>
        /// List all the NetworkAdapters
        /// </summary>
        /// <returns>The list of all NetworkAdapter of the machine</returns>
        public static List<NetworkAdapter> GetAllNetworkAdapter()
        {
            List<NetworkAdapter> allNetworkAdapter = new List<NetworkAdapter>();

            // Manufacturer <> 'Microsoft'to get all none virtual devices.
            // Because the AdapterType property will be null if the NetworkAdapter is 
            // disabled, so we do not use NetworkAdapter = 'Ethernet 802.3' or 
            // NetworkAdapter = 'Wireless’
            string strWQuery = "SELECT DeviceID, ProductName, "
                + "NetEnabled, NetConnectionStatus "
                + "FROM Win32_NetworkAdapter "
                + "WHERE Manufacturer <> 'Microsoft'";

            ManagementObjectCollection networkAdapters = WMIQuery(strWQuery);
            foreach (ManagementObject moNetworkAdapter in networkAdapters)
            {
                try
                {
                    allNetworkAdapter.Add(new NetworkAdapter(
                        Convert.ToInt32(moNetworkAdapter["DeviceID"].ToString()),
                        moNetworkAdapter["ProductName"].ToString(),
                        (Convert.ToBoolean(moNetworkAdapter["NetEnabled"].ToString()))
                            ? (int)EnumNetEnabledStatus.Enabled
                            : (int)EnumNetEnabledStatus.Disabled,
                        Convert.ToInt32(moNetworkAdapter["NetConnectionStatus"].ToString()
                        )));
                }
                catch (NullReferenceException)
                {
                    // Ignore some other devices (like the bluetooth), that need user 
                    // interaction to enable or disable.
                }
            }

            return allNetworkAdapter;
        }

        #endregion

        #region ManagerCollection

        public static ManagementObjectCollection WMIQuery(string strwQuery)
        {
            ObjectQuery oQuery = new ObjectQuery(strwQuery);
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oQuery);
            ManagementObjectCollection oReturnCollection = oSearcher.Get();
            return oReturnCollection;
        }

        #endregion

        #region ManagerConnection

        public static void EnableDisabledConnection (int deviceID, bool enableDisableConnection)
        {
            ManagementObject currentMObject = new ManagementObject();
            string strWQuery = "SELECT DeviceID,ProductName,Description,NetEnabled "
                + "FROM Win32_NetworkAdapter "
                + "WHERE DeviceID = " + deviceID.ToString();
            ObjectQuery oQuery = new ObjectQuery(strWQuery);
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oQuery);
            ManagementObjectCollection oReturnCollection = oSearcher.Get();


            foreach (ManagementObject mo in oReturnCollection)
            {
                currentMObject = mo;
            }

            //Enable the Network Adapter 
            if (enableDisableConnection)
            {
                currentMObject.InvokeMethod("Enable", null);
            }
            else
            {
                currentMObject.InvokeMethod("Disable", null);
            }
        }
        #endregion
    }
}