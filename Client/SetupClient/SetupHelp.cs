using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace SetupClient
{
    public class SetupHelp
    {
        string _newAppDir;
        string _newDataDir;
        string InstallUtilExe;
        string _serviceExe;
        string _setupDir;

        string _installServiceBatch;
        string _uninstallServiceBatch;

        string _serviceName;
        string _DllDir;

        public SetupHelp()
        {
            InstallUtilExe = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\InstallUtil.exe";

            _serviceName = "USBAdminService";

            _setupDir = AppDomain.CurrentDomain.BaseDirectory;

            _newAppDir = Environment.ExpandEnvironmentVariables(@"%ProgramFiles%\USBAdmin");
            _newDataDir = Environment.ExpandEnvironmentVariables(@"%ProgramData%\USBAdmin");

            _serviceExe = Path.Combine(_newAppDir, "USBAdminService.exe");

            _installServiceBatch = Path.Combine(_newAppDir, "Service_Install.bat");

            _uninstallServiceBatch = Path.Combine(_newAppDir, "Service_Uninstall.bat");
            _DllDir = Path.Combine(_setupDir, "dll");
        }

        #region + public void Setup()
        public void Setup()
        {
            try
            {
                LogHelp.DeleteOldLogFile();

                SetupRegistryKey.InitialRegistryKey();

                UninstallService();

                CreateNewAppDir();
                CheckNewDataDir();

                CopyDllFile();

                WriteBatchFile();

                InstallService();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region + private void CreateNewAppDir()
        private void CreateNewAppDir()
        {
            // _newAppDir

            DirectoryInfo dir = new DirectoryInfo(_newAppDir);

            if (!dir.Exists)
            {
                dir.Create();
            }
            else
            {
                dir.Delete(true);
                dir.Create();
            }

            if (!dir.Exists)
            {
                throw new Exception("Error: " + dir.FullName + " create failed.");
            }

            // 設置權限
            try
            {
                var dirACL = dir.GetAccessControl();
                var rule = new FileSystemAccessRule("Authenticated Users",
                                FileSystemRights.ReadAndExecute,
                                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                PropagationFlags.None,
                                AccessControlType.Allow);
                dirACL.AddAccessRule(rule);
                dir.SetAccessControl(dirACL);
            }
            catch (Exception ex)
            {
                LogHelp.Log(ex.Message);
                throw;
            }
        }
        #endregion

        #region + CheckNewDataDir()
        private void CheckNewDataDir()
        {
            var rule = new FileSystemAccessRule("Authenticated Users",
                                FileSystemRights.Modify,
                                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                PropagationFlags.None,
                                AccessControlType.Allow);

            try
            {
                var dir = new DirectoryInfo(_newDataDir);

                if (!dir.Exists)
                {
                    dir.Create();
                }

                var dirACL = dir.GetAccessControl();

                dirACL.AddAccessRule(rule);
                dir.SetAccessControl(dirACL);
            }
            catch (Exception ex)
            {
                LogHelp.Log(ex.Message);
            }
        }
        #endregion

        #region + private bool InstallService()
        private void InstallService()
        {
            WinServiceHelper.Install(_serviceName, null, _serviceExe, null, ServiceStartType.Auto);

            //service

            var serviceExist = ServiceController.GetServices().Any(s => s.ServiceName.ToLower() == _serviceName.ToLower());
            if (!serviceExist)
            {
                throw new Exception("SetupHelp.InstallService() error: Service not exist.");
            }

            using (var serv = new ServiceController(_serviceName))
            {
                if (serv.Status == ServiceControllerStatus.Stopped)
                {
                    serv.Start();

                    serv.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(20));
                }
            }

            Console.WriteLine("Install service done.");
            LogHelp.Log("Install service done.");
        }
        #endregion

        #region + private bool UninstallService()
        private void UninstallService()
        {
            var serviceExist = ServiceController.GetServices().Any(s => s.ServiceName.ToLower() == _serviceName.ToLower());
            if (!serviceExist)
            {
                return;
            }

            Console.WriteLine("Unistall serive start...");

            WinServiceHelper.Uninstall(_serviceName);

            Console.WriteLine("Unistall serivce done.");
            LogHelp.Log("Unistall serivce done.");
        }
        #endregion

        #region WriteBatchFile
        private void WriteBatchFile()
        {
            var sb = new StringBuilder();

            try
            {
                // service_install.bat
                sb.AppendLine($"\"{InstallUtilExe}\" \"{_serviceExe}\"");
                sb.AppendLine($"net start {_serviceName}");

                File.WriteAllText(_installServiceBatch, sb.ToString(), new UTF8Encoding(false));

                // service_uninstall.bat
                sb.Clear();
                sb.AppendLine($"net stop {_serviceName}");
                sb.AppendLine($"\"{InstallUtilExe}\" /u \"{_serviceExe}\"");
                File.WriteAllText(_uninstallServiceBatch, sb.ToString(), new UTF8Encoding(false));
            }
            catch (Exception ex)
            {
                LogHelp.Log(ex.Message);
            }

            Console.WriteLine("Write batch file done.");
            LogHelp.Log("Write batch file done.");
        }
        #endregion


        #region + private void CopyDllFile()
        private void CopyDllFile()
        {
            var dll = new DirectoryInfo(_DllDir);
            if (!dll.Exists)
            {
                throw new Exception("SetupHelp.CopyDllFile(): dll folder not exist.");
            }

            foreach (var file in dll.EnumerateFiles())
            {
                string destName = Path.Combine(_newAppDir, file.Name);
                file.CopyTo(destName, true);
            }

            Console.WriteLine("Copy dll files done.");
            LogHelp.Log("Copy dll files done.");
        }
        #endregion


        // unsetup ------------------

        #region + public void UnSetup()
        public void UnSetup()
        {
            try
            {
                UninstallService();

                Thread.Sleep(2000);

                DeleteAllFile();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region + private void DeleteAllFile()
        private void DeleteAllFile()
        {
            try
            {
                Directory.Delete(_newAppDir, true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
