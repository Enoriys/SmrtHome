using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<string> ActionAsync(string Action, string Parametr)
        {
            if (Action == "ON")
                return await LampOnAsync();
            else if (Action == "OFF")
                return await LampOffAsync();
            else
                return await CheckLampAsync();

        }

        public async Task<string> LampOnAsync()
        {
            await Task.Delay(3000);
            CurrentState = "ON";
            return CurrentState;
        }

        public async Task<string> LampOffAsync()
        {
            await Task.Delay(3000);
            CurrentState = "OFF";
            return CurrentState;
        }

        public async Task<string> CheckLampAsync()
        {
            await Task.Delay(3000);
            return CurrentState;
        }


    }
}
