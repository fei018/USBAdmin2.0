using AgentLib;
using NamedPipeWrapper;
using System;
using System.Windows;

namespace USBAdminTray
{
    public class NamedPipeClient_Tray
    {
        // private
        private string _pipeName;

        private NamedPipeClient<NamedPipeMsg> _client;


        #region Stop()
        public void Stop()
        {
            try
            {
                if (_client != null)
                {
                    _client.ServerMessage -= _client_ServerMessage;
                    _client.Stop();
                    _client = null;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Start()
        public void Start()
        {
            try
            {
                Stop();

                _pipeName = AgentRegistry.AgentHttpKey;

                if (string.IsNullOrWhiteSpace(_pipeName))
                {
                    AgentLogger.Error("NamedPipeClient_Tray.PipeName is empty");
                    return;
                }

                _client = new NamedPipeClient<NamedPipeMsg>(_pipeName);
                _client.AutoReconnect = true;

                _client.ServerMessage += _client_ServerMessage;
                _client.Error += _client_Error;

                _client.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        private void _client_Error(Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
        #endregion

        #region _client_ServerMessage
        private void _client_ServerMessage(NamedPipeConnection<NamedPipeMsg, NamedPipeMsg> connection, NamedPipeMsg pipeMsg)
        {
            try
            {
                if (pipeMsg == null)
                {
                    throw new Exception("NamedPipeClient_Tray ServerMessage is null.");
                }

                switch (pipeMsg.MsgType)
                {
                    case NamedPipeMsgType.Msg_TrayHandle:
                        Msg_TrayHandle(pipeMsg);
                        break;

                    case NamedPipeMsgType.UsbNotRegister_TrayHandle:
                        UsbNotRegister_TrayHandle(pipeMsg);
                        break;

                    case NamedPipeMsgType.ToCloseProcess_TrayHandle:
                        ToCloseProcess_TrayHandle();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        private void Msg_TrayHandle(NamedPipeMsg msg)
        {
            MessageBox.Show(msg.Message);
        }

        private void UsbNotRegister_TrayHandle(NamedPipeMsg msg)
        {
            App.Current.Dispatcher.Invoke(new Action(() =>
            {
                try
                {
                    if (msg.Usb == null)
                    {
                        throw new Exception("NamedPipeClient_Tray.UsbNotRegister_TrayHandle(): msg.Usb == null");
                    }

                    var usbQRWin = new UsbQRCodeWindow();
                    usbQRWin.SetUSBInfo(msg.Usb);
                    usbQRWin.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "USB Control");
                }
            }));
        }

        private void ToCloseProcess_TrayHandle()
        {
            try
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    App.Current.MainWindow.Close();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Send Message
        public void SendMsg_CheckAndUpdateAgent()
        {
            try
            {
                NamedPipeMsg msg = new NamedPipeMsg
                {
                    MsgType = NamedPipeMsgType.UpdateAgent_ServerHandle
                };

                _client.PushMessage(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SendMsg_UpdateSetting()
        {
            try
            {
                NamedPipeMsg msg = new NamedPipeMsg
                {
                    MsgType = NamedPipeMsgType.UpdateSetting_ServerHandle
                };

                _client.PushMessage(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
