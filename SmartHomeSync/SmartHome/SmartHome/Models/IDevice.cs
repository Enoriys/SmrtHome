using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHome.Models
{
    public interface IDevice
    {
        int DeviceID { get; set; }
        string Name { get; set; }
        string Type { get; set; }
        string Description { get; set; }
        string Owner { get; set; }
        int Room { get; set; }
        string status { get; set; }
        string[] Actions { get; set; }
    }
}