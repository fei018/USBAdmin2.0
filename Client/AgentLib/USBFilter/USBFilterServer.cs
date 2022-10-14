using AgentLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AgentLib
{
    public class USBFilterServer : IAdminServer
    {
        private static USBFilterForm _USBFilterForm;

        public void Start()
        {
            try
            {
                if (_USBFilterForm != null)
                {
                    _USBFilterForm.Stop();
                    _USBFilterForm = null;
                }

                _USBFilterForm = new USBFilterForm();
                Thread thread = new Thread(() =>
                {
                    Application.Run(_USBFilterForm);
                });

                thread.Start();
            }
            catch (Exception)
            {
            }
        }

        public void Stop()
        {
            try
            {
                if (_USBFilterForm != null)
                {
                    _USBFilterForm.Stop();
                    _USBFilterForm = null;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
