using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHome.Controllers
{
    public class NavController : Controller
    {
        DeviceRepository repository = DeviceRepository.GetInstance();
        public PartialViewResult Menu(string Room = null)
        {
            ViewBag.room = Room;
            IEnumerable<int> Rooms = repository.Devices
                .Select(x => x.Room)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(Rooms);
        }

    }
}
