using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevicesController.Device
{
    public class LampDevice : IDevice
    {
        public string Id {get;set;}
        string CurrentState;

        public LampDevice(string Id)
        {
            this.Id = Id;
        }

        public string ActionAsync(string Action, string Parametr)
        {
            if (Action == "ON")
                return LampOnAsync();
            else if (Action == "OFF")
                return  LampOffAsync();
            else
                return CheckLampAsync();

        }

        public string LampOnAsync()
        {
            Thread.Sleep(1000);
            CurrentState = "ON";
            return CurrentState;
        }

        public string LampOffAsync()
        {
            Thread.Sleep(1000);
            CurrentState = "OFF";
            return CurrentState;
        }

        public string CheckLampAsync()
        {
            Thread.Sleep(1000);
            return CurrentState;
        }
    }
}
