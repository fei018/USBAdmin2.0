using AgentLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AgentLib
{
    public class USBFilterService
    {
        private static USBFilterForm _USBFilterForm;

        public void Start()
        {
            try
            {
                if (_USBFilterForm != null)
                {
                    _USBFilterForm.Stop();
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
                _USBFilterForm?.Stop();
            }
            catch (Exception)
            {
            }
        }
    }
}
