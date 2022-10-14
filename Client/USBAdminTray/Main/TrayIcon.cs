using AgentLib;
using System;
using System.Windows;

namespace USBAdminTray
{
    public class TrayIcon
    {

        private System.Windows.Forms.NotifyIcon _trayIcon;

        #region + public void Stop()
        public void Stop()
        {
            if (_trayIcon != null)
            {
                _trayIcon.Visible = false;
                _trayIcon.Dispose();
                _trayIcon = null;
            }
        }
        #endregion

        #region + public void Start()
        public void Start()
        {
#if DEBUG
            //Debugger.Break();
#endif
            try
            {
                Stop();

                _trayIcon = new System.Windows.Forms.NotifyIcon
                {
                    Icon = Properties.Resources.USB,
                    Text = "USBAdmin"
                };

                _trayIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();


                _trayIcon.ContextMenuStrip.Items.Add("Update Setting", null, UpdateSettingItem_Click);
                _trayIcon.ContextMenuStrip.Items.Add("About", null, AboutItem_Click);
                _trayIcon.ContextMenuStrip.Items.Add("Close", null, CloseTrayItem_Click);
                _trayIcon.ContextMenuStrip.Items.Add("");

                _trayIcon.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }
        #endregion

        // Tray Item Click

        #region UpdateSettingItem_Click
        private void UpdateSettingItem_Click(object sender, EventArgs e)
        {
            try
            {
                ServerManage_Tray.NamedPipeClient_Tray.SendMsg_UpdateSetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region AboutItem_Click
        private void AboutItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (UniqueOpenWindow.AoutWindow)
                {
                    return;
                }

                App.Current.Dispatcher.Invoke(new Action(() =>
                {
                    var about = new AboutWindow();
                    about.txtAgentVersion.Text = AgentRegistry.AgentVersion;
                    about.Show();

                    UniqueOpenWindow.AoutWindow = true;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region CloseTrayItem_Click
        private void CloseTrayItem_Click(object sender, EventArgs e)
        {
            try
            {
                App.Current.Dispatcher.Invoke(new Action(() =>
                {
                    App.Current.MainWindow.Close();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
