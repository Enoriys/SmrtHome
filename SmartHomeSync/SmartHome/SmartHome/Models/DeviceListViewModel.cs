using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHome.Models
{
    public class DeviceListViewModel
    {
        public IEnumerable<IDevice> Devices { get; set; }
        public int CurrentRoom { get; set; }
    }
}