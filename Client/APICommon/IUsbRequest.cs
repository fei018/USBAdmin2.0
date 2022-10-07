using System;

namespace APICommon
{
    public interface IUsbRequest : IUsbBase
    {
        string RequestUserEmail { get; set; }

        string RequestComputerIdentity { get; set; }

        DateTime RequestTime { get; set; }

        string RequestReason { get; set; }
    }
}
