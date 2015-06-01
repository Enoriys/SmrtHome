using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHome.Models
{
    public class TemperatureDevice : IDevice
    {
        public int DeviceID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public int Room { get; set; }
        public string status { get; set; }
        public string[] Actions { get; set; }
        public TemperatureDevice(int DeviceID,string Name,string Type,string Description,string Owner,int Room,string status)
        {
            Actions = new string[2];
            this.DeviceID = DeviceID;
            this.Name = Name;
            this.Type = Type;
            this.Description = Description;
            this.Owner = Owner;
            this.Room = Room;
            this.status = status;
            Actions[0] = "ShowTemp";
            Actions[1] = "ChangeTemp";
        }
    }
}