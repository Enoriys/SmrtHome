using DevicesController.Device;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevicesController.Controller
{
    public class Controller
    {
        public IEnumerable<IDevice> Devices;
        public List<IDevice> DevicesList;
        string Action;
        string ActionParametr;
        public string[] ResultAllActions;
        public string LastActionTime;

        public Controller(IEnumerable<IDevice> devices)
        {
            Devices = devices;
        }

        public string[] MakeActionAcyns()
        {

            ResultAllActions = new string[Devices.Count()];
            int i = 0;
            foreach (var devices in Devices)
            {
                ResultAllActions[i] = MakeOneAction(devices);
                i++;
                Thread.Sleep(2000);
            }
            return ResultAllActions;
        }

        string MakeOneAction(IDevice SomeDevice)
        {
            return SomeDevice.ActionAsync(Action, ActionParametr);
        }

        public void InsertAction(string Action,string ActionParametr)
        {
            this.Action = Action;
            this.ActionParametr = ActionParametr;
        }
    }
}
