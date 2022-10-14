using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using AgentLib;

namespace USBAdminService
{
    public partial class AdminService : ServiceBase
    {
        public AdminService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            AdminServerManage.OnStart();
        }

        protected override void OnStop()
        {
            AdminServerManage.OnStop();
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            if (changeDescription.Reason == SessionChangeReason.SessionLogon)
            {
                AdminServerManage.TrayServer.CreateTray();
            }

            base.OnSessionChange(changeDescription);
        }
    }
}
