using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsCommon;

namespace AgentLib
{
    public class UsbWhitelist
    {
        private static string _UsbWhitelistFile;

        private static List<string> _CacheDb;

        private static readonly object _Locker_CacheDb = new object();

        private static readonly object _Locker_Whitelist = new object();

        public UsbWhitelist()
        {
            try
            {
                _UsbWhitelistFile = AgentRegistry.UsbWhitelistPath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usbwhitelist.dat");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region + private void Reload_UsbWhitelistCache()
        private void Reload_UsbWhitelistCache()
        {
            try
            {
                var table = ReadFile_UsbWhitelist();

                lock (_Locker_CacheDb)
                {
                    if (_CacheDb == null)
                    {
                        _CacheDb = new List<string>(table.Length);
                    }
                    else
                    {
                        _CacheDb.Clear();
                        _CacheDb.Capacity = table.Length;
                    }

                    foreach (string line in table)
                    {
                        try
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                _CacheDb.Add(line);
                            }
                        }
                        catch (Exception) { throw; }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region + private string[] ReadFile_UsbWhitelist()

        private string[] ReadFile_UsbWhitelist()
        {
            lock (_Locker_Whitelist)
            {
                try
                {
                    if (File.Exists(_UsbWhitelistFile))
                    {
                        return File.ReadAllLines(_UsbWhitelistFile, new UTF8Encoding(false));
                    }
                    else
                    {
                        throw new Exception(_UsbWhitelistFile + " not exist.");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion

        #region + private void WriteFile_UsbWhitelist(string txt)
        private void WriteFile_UsbWhitelist(string txt)
        {
            lock (_Locker_Whitelist)
            {
                try
                {
                    File.WriteAllText(_UsbWhitelistFile, txt, new UTF8Encoding(false));
                }
                catch (Exception ex)
                {
                    throw new Exception(_UsbWhitelistFile + "\r\nWrite file Error:\r\n" + ex.GetBaseException().Message);
                }
            }
        }
        #endregion

        #region + public static bool IsFind(UsbBase usb)
        public static bool IsFind(UsbBase usb)
        {
            try
            {
                //if (_CacheDb == null || _CacheDb.Count <= 0)
                //{
                //    new UsbWhitelist().Reload_UsbWhitelistCache();
                //}

                //if (_CacheDb != null && _CacheDb.Count >= 1)
                //{
                //    if(_CacheDb.Any(c=> c.Equals(usb.UsbIdentity)))
                //    {
                //        return true;
                //    }
                //}

                UsbWhitelist whiteList = new UsbWhitelist();
                string[] table = whiteList.ReadFile_UsbWhitelist();

                if (table.Length >= 1)
                {
                    foreach (string t in table)
                    {
                        if (t.Equals(usb.UsbIdentity))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                AgentLogger.Error(ex.Message);
                return false;
            }
        }
        #endregion

        #region + public static void Set_UsbWhitelist_byHttp(UsbFilterDbHttp setting)
        public static void Set_And_Load_UsbWhitelist_byHttp(string usbWhitelist)
        {
            try
            {
                UsbWhitelist white = new UsbWhitelist();
                white.WriteFile_UsbWhitelist(UtilityTools.Base64Decode(usbWhitelist));
                white.Reload_UsbWhitelistCache();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion      
    }
}
