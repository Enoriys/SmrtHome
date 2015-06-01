using DevicesController.Device;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

        public async Task<string[]> MakeActionAcyns()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            IEnumerable<Task<string>> tasks = from device in Devices select MakeOneAction(device);
            Task<string>[] DeviceListAction = tasks.ToArray();
            ResultAllActions = await Task.WhenAll(DeviceListAction);
            stopwatch.Stop();
            LastActionTime = stopwatch.ElapsedMilliseconds.ToString();
            return ResultAllActions;
        }

        async Task<string> MakeOneAction(IDevice SomeDevice)
        {
            return await SomeDevice.ActionAsync(Action, ActionParametr);
        }

        public void InsertAction(string Action,string ActionParametr)
        {
            this.Action = Action;
            this.ActionParametr = ActionParametr;
        }
    }
}
