using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace USBAdminTray
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ServerManage_Tray.Start();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ServerManage_Tray.Stop();
        }
    }
}
