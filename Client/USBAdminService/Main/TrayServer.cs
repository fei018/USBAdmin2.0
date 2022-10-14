using AgentLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace USBAdminService
{
    public class TrayServer : IAdminServer
    {
        private static List<Process> _trayProcessList;

        public string TrayFullPath { get; private set; }

        public void Start()
        {
            try
            {
                Stop();

                _trayProcessList = new List<Process>();
            }
            catch (Exception ex)
            {
                AgentLogger.Error("TrayServer.Start(): " + ex.GetBaseException().Message);
            }
        }

        public void Stop()
        {
            try
            {
                if (_trayProcessList != null)
                {
                    foreach (Process p in _trayProcessList)
                    {
                        try
                        {
                            AdminServerManage.NamedPipeServer.SendMsg_To_Tray_Close();
                            Thread.Sleep(1000);
                            AppProcessHelp.CloseOrKillProcess(p);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    _trayProcessList.Clear();
                    _trayProcessList = null;
                }
            }
            catch (Exception ex)
            {
                AgentLogger.Error("TrayServer.Stop(): " + ex.GetBaseException().Message);
            }
        }

        public void CreateTray()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    if (_trayProcessList == null)
                    {
                        throw new Exception("_trayProcessList is null.");
                    }

                    try
                    {
                        TrayFullPath = AgentRegistry.USBAdminTrayPath;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("AgentRegistry.USBAdminTrayPath : " + ex.Message);
                    }

                    Process proc = AppProcessHelp.StartupAppAsLogonUser(TrayFullPath);

                    _trayProcessList.Add(proc);
                }
                catch (Exception ex)
                {
                    AgentLogger.Error("TrayServer.CreateTray(): " + ex.GetBaseException().Message);
                }
            });
        }
    }
}
