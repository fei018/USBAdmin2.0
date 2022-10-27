using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace USBAdminService
{
    public static class ToolsHelp
    {
        public static bool CheckNetworkConnectivity()
        {
            try
            {
                NetworkInterface nic = NetworkInterface.GetAllNetworkInterfaces()
                                    .Where(n => n.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                                    .Where(n => n.OperationalStatus == OperationalStatus.Up)
                                    .FirstOrDefault();

                //如果 wire nic 搵唔到, 嘗試搵 wireless nic
                if (nic == null)
                {
                    nic = NetworkInterface.GetAllNetworkInterfaces()
                                        .Where(n => n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                                        .Where(n => n.OperationalStatus == OperationalStatus.Up)
                                        .FirstOrDefault();
                }

                if (nic == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
