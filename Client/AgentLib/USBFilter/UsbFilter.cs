﻿using System;

namespace AgentLib
{
    public partial class UsbFilter
    {
        private readonly UsbBusController _usbBus;

        public event EventHandler<UsbBase> UsbDeviceNotRegister;

        public UsbFilter()
        {
            _usbBus = new UsbBusController();
        }

        // Filter usb

        #region + public void Filter_UsbDevice_Class_By_UsbDisk_By_DriveLetter(char driveLetter)
        public void Filter_UsbDevice_Class_By_UsbDisk_By_DriveLetter(char driveLetter)
        {
            try
            {
                var usb = Get_UsbDisk_DiskPath_by_DriveLetter_WMI(driveLetter);
                if (usb != null)
                {
                    Filter_UsbDevice_Class_Is_UsbDisk_By_DiskPath(usb.DiskPath);
                }
                else
                {
                    throw new Exception("Cannot find disk by driveLetter: " + driveLetter);
                }
            }
            catch (Exception ex)
            {
                AgentLogger.Error(ex.Message);
            }
        }
        #endregion

        #region + public viod Filter_UsbDevice_Class_Is_UsbDisk_By_DiskPath(string diskPath)
        /// <summary>
        /// 
        /// </summary>
        public void Filter_UsbDevice_Class_Is_UsbDisk_By_DiskPath(string diskPath)
        {
            try
            {
                if (!AgentRegistry.UsbFilterEnabled)
                {
                    Set_Disk_IsReadOnly_by_DiskPath_WMI(diskPath, false);
                    return;
                }

                UsbDisk usb = Get_USBInfo_FromUsbDisk_By_DiskPath(diskPath);
                
                if (usb == null)
                {
                    // 找不到 大多數係 非 USB device
                    throw new Exception ("Filter_UsbDevice_Class_Is_UsbDisk_By_DiskPath():\r\n" + usb.ToString());
                }            

                if (!_usbBus.Fill_USB_Info_By_USBDeviceId(usb))
                {
                    // should not happen
                    // set readonly true
                    Set_Disk_IsReadOnly_by_DiskPath_WMI(usb.DiskPath, true);
                    return;
                }

                if (UsbWhitelist.IsFind(usb))
                {
                    // set ReadOnly false
                    Set_Disk_IsReadOnly_by_DiskPath_WMI(usb.DiskPath, false);
                    return;
                }
                else
                {
                    // set readonly true
                    Set_Disk_IsReadOnly_by_DiskPath_WMI(usb.DiskPath, true);
                    UsbDeviceNotRegister?.Invoke(null, usb);
                    return;
                }
            }
            catch (Exception ex)
            {
                AgentLogger.Error(ex.GetBaseException().Message);
            }
        }
        #endregion

        #region + public void Scan_All_USBDisk_To_Filter()
        /// <summary>
        /// 重新全局 scan usb disk to filter
        /// </summary>
        public void Scan_All_USBDisk_To_Filter()
        {
            try
            {
                var usbList = Get_All_UsbDisk_DiskPath_by_BusType_USB_WMI();
                if (usbList.Count > 0)
                {
                    foreach (var usb in usbList)
                    {
                        try
                        {
                            Filter_UsbDevice_Class_Is_UsbDisk_By_DiskPath(usb.DiskPath);
                        }
                        catch (Exception ex)
                        {
                            AgentLogger.Error(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AgentLogger.Error(ex.Message);
            }
        }
        #endregion

        #region + public void Scan_All_USBDisk_Set_NotReadOnly()
        public void Scan_All_USBDisk_Set_NotReadOnly()
        {
            try
            {
                var usbList = Get_All_UsbDisk_DiskPath_by_BusType_USB_WMI();
                if (usbList.Count > 0)
                {
                    foreach (var usb in usbList)
                    {
                        Set_Disk_IsReadOnly_by_DiskPath_WMI(usb.DiskPath, false);
                    }
                }
            }
            catch (Exception ex)
            {
                AgentLogger.Error(ex.Message);
            }
        }
        #endregion

        //Get usb info

        #region + public UsbDisk Get_UsbDisk_By_DriveLetter(char driveLetter)
        public UsbDisk Get_UsbDisk_By_DriveLetter(char driveLetter)
        {
            try
            {
                var usb = Get_UsbDisk_DiskPath_by_DriveLetter_WMI(driveLetter);
                if (usb != null)
                {
                    if (Get_UsbDeviceId_By_DiskPath_SetupDi(usb))
                    {
                        if (_usbBus.Fill_USB_Info_By_USBDeviceId(usb))
                        {
                            return usb;
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region + public UsbDisk Get_USBInfo_FromUsbDisk_By_DiskPath(string diskPath)
        public UsbDisk Get_USBInfo_FromUsbDisk_By_DiskPath(string diskPath)
        {
            try
            {
                var usb = new UsbDisk { DiskPath = diskPath };
                if (Get_UsbDeviceId_By_DiskPath_SetupDi(usb))
                {
                    if (_usbBus.Fill_USB_Info_By_USBDeviceId(usb))
                    {
                        return usb;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}