using AgentLib;

namespace USBAdminService
{
    public class AdminServerManage
    {
        #region server entity
        public static NamedPipeServer NamedPipeServer { get; set; }

        public static TrayServer TrayServer { get; set; }

        public static PrintJobLogServer PrintJobLogServer { get; set; }

        public static USBFilterServer USBFilterServer { get; set; }

        public static ScheduleServer ScheduleServer { get; set; }
        #endregion

        #region OnStart
        public static void OnStart()
        {
            NamedPipeServer = new NamedPipeServer();
            NamedPipeServer.Start();

            USBFilterServer = new USBFilterServer();
            USBFilterServer.Start();

            TrayServer = new TrayServer();
            TrayServer.Start();

            PrintJobLogServer = new PrintJobLogServer();
            PrintJobLogServer.Start();

            ScheduleServer = new ScheduleServer();
            ScheduleServer.Start();
        }
        #endregion

        #region OnStop
        public static void OnStop()
        {
            ScheduleServer?.Stop();

            USBFilterServer?.Stop();

            TrayServer?.Stop();

            PrintJobLogServer?.Stop();

            NamedPipeServer?.Stop();
        }
        #endregion
    }
}
