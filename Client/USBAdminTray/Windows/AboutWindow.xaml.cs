using System;
using System.Windows;

namespace USBAdminTray
{
    /// <summary>
    /// AboutWindow.xaml 的互動邏輯
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void btnCheckUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServerManage_Tray.NamedPipeClient_Tray?.SendMsg_CheckAndUpdateAgent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            UniqueOpenWindow.AoutWindow = false;
        }
    }
}
