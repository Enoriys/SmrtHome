using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SmartHome.Controllers
{
    public class HomeController : Controller
    {
        DeviceRepository repository = DeviceRepository.GetInstance();
        public ActionResult Index()
        {
            ViewBag.room = "Home";
            return View(repository.Devices);
        }

        public ActionResult List(int Rooms)
        {
            DeviceListViewModel viewModel = new DeviceListViewModel
            {
                Devices = repository.Devices
                .Where(p => p.Room == Rooms),
                CurrentRoom = Rooms
            };
            return View(viewModel);
        }

        public async Task<ActionResult> DeviceActionLamp(string ID, string type, string Action, string Parametr)
        {
            HomeService.SmartHomeServiceClient client = new HomeService.SmartHomeServiceClient();
            string[] result;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string[] IdDevice = new string[1];
            IdDevice[0] = ID;
            result = new string[IdDevice.Length];
            result = await client.MakeActionAsync(IdDevice, type, Action, Parametr);
            sw.Stop();
            ViewBag.ID = ID;
            ViewBag.type = type;
            ViewBag.Action = Action;
            foreach(var device in repository.Devices)
            {
                if (device.DeviceID.ToString() == ID)
                {
                    device.status = result[0];
                }
            }
            return PartialView(result);
        }

        public async Task<ActionResult> DeviceActionTempr(string ID, string type, string Action, string Parametr)
        {

            HomeService.SmartHomeServiceClient client = new HomeService.SmartHomeServiceClient();
            string[] result;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string[] IdDevice = new string[1];
            IdDevice[0] = ID;
            result = new string[IdDevice.Length];
            result = await client.MakeActionAsync(IdDevice, type, Action, Parametr);
            sw.Stop();
            ViewBag.ID = ID;
            ViewBag.type = type;
            ViewBag.Action = Action;
            ViewBag.status = result[0];
            foreach (var device in repository.Devices)
            {
                if (device.DeviceID.ToString() == ID)
                {
                    device.status = result[0];
                }
            }
            return PartialView(result);
        }

        public async Task<ActionResult> DeviceActionLock(string ID, string type, string Action, string Parametr)
        {

            HomeService.SmartHomeServiceClient client = new HomeService.SmartHomeServiceClient();
            string[] result;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string[] IdDevice = new string[1];
            IdDevice[0] = ID;
            result = new string[IdDevice.Length];
            result = await client.MakeActionAsync(IdDevice, type, Action, Parametr);
            sw.Stop();
            ViewBag.ID = ID;
            ViewBag.type = type;
            ViewBag.Action = Action;
            ViewBag.status = result[0];
            foreach (var device in repository.Devices)
            {
                if (device.DeviceID.ToString() == ID)
                {
                    device.status = result[0];
                }
            }
            return PartialView(result);
        }

        public ActionResult OtherActions()
        {
            DeviceListViewModel viewModel = new DeviceListViewModel
            {
                Devices = repository.Devices
                .Where(p => (p.Type == "Lamp")||(p.Type =="Tempr") ||(p.Type =="Lock"))
            };
            return View(viewModel);
        }

        public async Task<ActionResult> DeviceGlobalAction(string type, string Action, string Parametr)
        {
            HomeService.SmartHomeServiceClient client = new HomeService.SmartHomeServiceClient();
            Stopwatch sw = new Stopwatch();
            string[] result;

            DeviceListViewModel viewModel = new DeviceListViewModel
            {
                Devices = repository.Devices
                .Where(p => p.Type == type)
            };

            string[] IdDevice = new string[viewModel.Devices.Count()];
            int i = 0;
            foreach (var dev in viewModel.Devices)
            {
                IdDevice[i] = dev.DeviceID.ToString();
                i++;
            }

            result = new string[IdDevice.Length];
            sw.Start();
            result = await client.MakeActionAsync(IdDevice, type, Action, Parametr);
            sw.Stop();
            ViewBag.DeviceType = type;
            ViewBag.DeviceList = viewModel;
            i = 0;
            foreach (var device in repository.Devices)
            {
                if (device.Type == type)
                {
                    device.status = result[i];
                    i++;
                }
            }
            viewModel = new DeviceListViewModel
            {
                Devices = repository.Devices
                .Where(p => p.Type == type)
            };
            return PartialView(viewModel);
        }
    }
}
