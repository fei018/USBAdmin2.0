using AgentLib;
using System;
using System.Timers;

namespace USBAdminService
{
    public class ScheduleServer : IAdminServer
    {
        private static Timer _Timer;

        private void ElapsedAction(object sender, ElapsedEventArgs e)
        {
            try
            {
                new AgentHttpHelp().PostComputerInfo();
            }
            catch (Exception ex)
            {
                AgentLogger.Error("ServiceTimer.ElapsedAction(): " + ex.Message);
            }

            #region UsbFilterEnabled
            try
            {
                if (AgentRegistry.UsbFilterEnabled)
                {
                    if (AdminServerManage.USBFilterServer == null)
                    {
                        AdminServerManage.USBFilterServer = new USBFilterServer();
                        AdminServerManage.USBFilterServer.Start();
                    }
                }
                else
                {
                    if (AdminServerManage.USBFilterServer != null)
                    {
                        AdminServerManage.USBFilterServer?.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                AgentLogger.Error("ServerSchedule.ElapsedAction(): " + ex.GetBaseException().Message);
            }
            #endregion

            #region PrintJobLogEnabled
            try
            {
                if (AgentRegistry.PrintJobLogEnabled)
                {
                    if (AdminServerManage.PrintJobLogServer == null)
                    {
                        AdminServerManage.PrintJobLogServer = new PrintJobLogServer();
                        AdminServerManage.PrintJobLogServer.Start();
                    }
                }
                else
                {
                    if (AdminServerManage.PrintJobLogServer != null)
                    {
                        AdminServerManage.PrintJobLogServer?.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                AgentLogger.Error("ServerSchedule.ElapsedAction(): " + ex.GetBaseException().Message);
            }
            #endregion

            #region Agent CheckAndUpdate 
            try
            {
                AgentUpdate.CheckAndUpdate();
            }
            catch (Exception ex)
            {
                AgentLogger.Error("ServerSchedule.ElapsedAction(): " + ex.GetBaseException().Message);
            }
            #endregion

            #region _timerReset();
            _timerReset();
            #endregion
        }

        public void Start()
        {
            try
            {
                _Timer = new Timer();
                _Timer.AutoReset = true;
                _Timer.Interval = GetInterval();
                _Timer.Elapsed += ElapsedAction;

                _Timer.Start();
            }
            catch (Exception ex)
            {
                AgentLogger.Error("ServerSchedule.Start(): " + ex.GetBaseException().Message);
            }
        }

        public void Stop()
        {
            if (_Timer != null)
            {
                try
                {
                    _Timer.Elapsed -= ElapsedAction;
                    _Timer.Stop();
                }
                catch (Exception)
                {
                }
            }
        }

        private void _timerReset()
        {
            try
            {
                _Timer.Enabled = false;
                _Timer.Interval = GetInterval();
                _Timer.Enabled = true;
            }
            catch (Exception)
            {
            }
        }

        #region + private double GetInterval()
        private double GetInterval()
        {
            int minutes;

            try
            {
                minutes = AgentRegistry.AgentTimerMinute;
            }
            catch (Exception)
            {
                return TimeSpan.FromMinutes(10).TotalMilliseconds;
            }

            // minimum 1 minutes
            if (minutes < 1)
            {
                minutes = 1;
            }

            // maximum 24 hours
            if (minutes > 1440)
            {
                minutes = 1440;
            }

            return TimeSpan.FromMinutes(minutes).TotalMilliseconds; ;
        }
        #endregion
    }
}
