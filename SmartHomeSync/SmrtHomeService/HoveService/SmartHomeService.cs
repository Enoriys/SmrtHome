using DevicesController.Controller;
using DevicesController.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple
        )]
    public class SmartHomeService : ISmartHomeService
    {
        
        public string[] MakeAction(string[] ID, string type, string Action, string Parametr)
        {
            string[] result = new string[ID.Length];           
            List<IDevice> devicelist = new List<IDevice>();
            IEnumerable<IDevice> DeviceList;
            foreach(string IdList in ID)
            {
                 IDevice device = CreateOneDevice(IdList,type,Action,Parametr);
                devicelist.Add(device);
            }
            DeviceList = devicelist;
            Controller controller = new Controller(DeviceList);
            controller = InsertActController(controller,type, Action, Parametr);
            result = controller.MakeActionAcyns();
            return result;
        }

        ////////

        public static IDevice CreateOneDevice(string ID, string type, string Action, string Parametr)
        {
            IDevice device = new LampDevice("1");///такоє собі
            //if (type == "Tempr")
            //{
               // device = new TemperatureDevice(ID);
            //}
            //else if (type == "Lamp")
                device = new LampDevice(ID);
            //else if (type == "Lock")
            //    device = new LockDevice(ID);
            return device;
        }

        public static Controller InsertActController(Controller controller, string type, string Action, string Parametr)
        {
            Controller SomeController = controller;

            if (Parametr != null)
            {
                SomeController.InsertAction(Action, Parametr);            
            }
            else
                SomeController.InsertAction(Action, null);
            return SomeController;
        }
    }
}
