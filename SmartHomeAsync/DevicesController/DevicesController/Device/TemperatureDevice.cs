using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevicesController.Device
{
    public class TemperatureDevice : IDevice
    {
        public string Id {get;set;}
        public int CurrentTemp;


        public TemperatureDevice(string Id,int CurrentTemp)
        {
            this.Id = Id;
            this.CurrentTemp = CurrentTemp;
        }
        public TemperatureDevice(string Id)
        {
            this.Id = Id;
        }

        public async Task<string> ActionAsync(string Action, string Parametr) 
        {
            string result;

            if (Action == "ShowTemp")
                return result = await ShowTempAsync();
            else if (Action == "ChangeTemp")
                return result = await ChangeTempAsync(Convert.ToInt32(Parametr));
            else
                return "Wrong command";

        }

        public async Task<string> ShowTempAsync()
        {
            Random rnd = new Random();
            CurrentTemp = rnd.Next(10, 30);
            await Task.Delay(4000);
            return CurrentTemp.ToString();
        }

        public async Task<string> ChangeTempAsync(int NewTemperature)
        {
            CurrentTemp = NewTemperature;
            await Task.Delay(5000);

            return await ShowTempAsync();
        }


    }
}
