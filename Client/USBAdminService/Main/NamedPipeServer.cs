using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using AgentLib;
using NamedPipeWrapper;

namespace USBAdminService
{
    public class NamedPipeServer : IAdminServer
    {
        private string _pipeName;

        private NamedPipeServer<NamedPipeMsg> _server;

        #region + public void Start()
        public void Start()
        {
            try
            {
                _pipeName = AgentRegistry.AgentHttpKey;

                if (string.IsNullOrWhiteSpace(_pipeName))
                {
                    AgentLogger.Error("NamedPipeServer.Start(): PipeName is empty");
                    return;
                }

                Stop();

                PipeSecurity pipeSecurity = new PipeSecurity();

                pipeSecurity.AddAccessRule(new PipeAccessRule("CREATOR OWNER", PipeAccessRights.FullControl, AccessControlType.Allow));
                pipeSecurity.AddAccessRule(new PipeAccessRule("SYSTEM", PipeAccessRights.FullControl, AccessControlType.Allow));

                // Allow Everyone read and write access to the pipe.
                pipeSecurity.AddAccessRule(
                            new PipeAccessRule(
                            "Authenticated Users",
                            PipeAccessRights.ReadWrite | PipeAccessRights.CreateNewInstance,
                            AccessControlType.Allow));

                _server = new NamedPipeServer<NamedPipeMsg>(_pipeName, pipeSecurity);

                _server.ClientMessage += _server_ClientMessage; ;

                _server.Error += pipeConnection_Error;

                _server.Start();
            }
            catch (Exception)
            {
            }
        }

        private void pipeConnection_Error(Exception exception)
        {
            AgentLogger.Error("NamedPipeServe.pipeConnection_Error(): " + exception.Message);
        }
        #endregion

        #region + public void Stop()
        public void Stop()
        {
            try
            {
                if (_server != null)
                {
                    _server.Error -= pipeConnection_Error;
                    _server.ClientMessage -= _server_ClientMessage;
                    _server.Stop();
                    _server = null;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region ClientMessage
        private void _server_ClientMessage(NamedPipeConnection<NamedPipeMsg, NamedPipeMsg> connection, NamedPipeMsg pipeMsg)
        {
            try
            {
                if (pipeMsg == null)
                {
                    throw new Exception("NamedPipeServer.ClientMessage is null.");
                }

                switch (pipeMsg.MsgType)
                {
                    case NamedPipeMsgType.UpdateAgent_ServerHandle:

                        break;

                    case NamedPipeMsgType.UpdateSetting_ServerHandle:

                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Send Message
        public void SendMsg_To_Tray_USBNotRegister(UsbBase usbBase)
        {
            NamedPipeMsg msg = new NamedPipeMsg
            {
                MsgType = NamedPipeMsgType.UsbNotRegister_TrayHandle,
                Usb = usbBase
            };
            _server.PushMessage(msg);
        }

        public void SendMsg_To_Tray_Close()
        {
            NamedPipeMsg msg = new NamedPipeMsg
            {
                MsgType = NamedPipeMsgType.ToCloseProcess_TrayHandle
            };
            _server.PushMessage(msg);
        }
        #endregion
    }
}
