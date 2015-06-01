using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesController.Device
{
    public class LockDevice : IDevice
    {
        public string Id { get; set; }

        public LockDevice(string ID)
        {
            Id = ID;
        }
        public async Task<string> ActionAsync(string Action, string Parametr)
        {
            if (Action == "Locked")
                return await LockON();
            else  
                return await LockOFF();

        }
        public async Task<string> LockON()
        {
            await Task.Delay(2500);
            return "Locked";

        }
        public async Task<string> LockOFF()
        {
            await Task.Delay(2500);
            return "Unlocked";

        }
    }
}
