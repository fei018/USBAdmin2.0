﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICommon
{
    public interface IUsbLog : IUsbBase
    {

        string ComputerIdentity { get; set; }

        DateTime PluginTime { get; set; }

        string PluginTimeString { get; }
    }
}
