using AgentLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsbMonitor;

namespace USBAdminFilter
{
    public partial class USBFilterForm : UsbMonitorForm
    {
        public USBFilterForm()
        {
            InitializeComponent();

            _usbFilter = new UsbFilter();
            _usbFilter.UsbDeviceNotRegister += _usbFilter_UsbDeviceNotRegister;
        }

        private UsbFilter _usbFilter;

        private void _usbFilter_UsbDeviceNotRegister(object sender, UsbBase e)
        {
            // send message to tray
        }

        public override void OnUsbInterface(UsbEventDeviceInterfaceArgs args)
        {
            if (args.Action == UsbDeviceChangeEvent.Arrival)
            {
                if (args.DeviceInterface == UsbMonitor.UsbDeviceInterface.Disk)
                {
                    When_UsbDisk_Arrival(args.Name);
                }
            }
        }

        private void When_UsbDisk_Arrival(string diskPath)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    _usbFilter.Filter_UsbDevice_Class_Is_UsbDisk_By_DiskPath(diskPath);
                }
                catch (Exception)
                {
                }

                try
                {
                    // post usb log to http server
                    new AgentHttpHelp().PostUsbLog_byDisk(diskPath);
                }
                catch (Exception)
                {
                }
            });
        }
    }
}
