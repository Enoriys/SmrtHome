using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHome.Models
{
    public sealed class DeviceRepository
    {
        private static DeviceRepository repository = new DeviceRepository();
        public List<IDevice> Devices = new List<IDevice>();
        CurrentUser User;
        private DeviceRepository()
        {
            User = new CurrentUser();
            IDevice device = new LampDevice(1,"100VatLamp","Lamp","Shining and lighting",User.Login,1,"OFF");
            Devices.Add(device);
            device = new LampDevice(2, "80VatLamp", "Lamp", "Shining and lighting", User.Login, 1, "ON");
            Devices.Add(device);
            device = new TemperatureDevice(3, "Termostat123", "Tempr", "For controlling temperature", User.Login, 1, "22");
            Devices.Add(device);
            device = new LockDevice(12,"AlarmLock","Lock","Security System",User.Login,1,"Locked");
            Devices.Add(device);

            device = new LampDevice(4, "120VatLamp", "Lamp", "Shining and lighting", User.Login, 2, "ON");
            Devices.Add(device);
            device = new LampDevice(5, "80VatLamp", "Lamp", "Shining and lighting", User.Login, 2, "ON");
            Devices.Add(device);
            device = new TemperatureDevice(6, "Termostat123", "Tempr", "For controlling temperature", User.Login, 2, "18");
            Devices.Add(device);
            device = new LockDevice(13, "AlarmLock", "Lock", "Security System", User.Login, 2, "Unlocked");
            Devices.Add(device);


            device = new LampDevice(7, "120VatLamp", "Lamp", "Shining and lighting", User.Login, 3, "OFF");
            Devices.Add(device);
            device = new LampDevice(8, "80VatLamp", "Lamp", "Shining and lighting", User.Login, 3, "OFF");
            Devices.Add(device);
            device = new TemperatureDevice(9, "Termostat123", "Tempr", "For controlling temperature", User.Login, 3, "5");
            Devices.Add(device);
            device = new LockDevice(14, "AlarmLock", "Lock", "Security System", User.Login, 3, "Unlocked");
            Devices.Add(device);

            device = new LampDevice(10, "100VatLamp", "Lamp", "Shining and lighting", User.Login, 4, "OFF");
            Devices.Add(device);
            device = new TemperatureDevice(11, "Termostat123", "Tempr", "For controlling temperature", User.Login, 4, "17");
            Devices.Add(device);
            device = new LockDevice(15, "AlarmLock", "Lock", "Security System", User.Login, 4, "Locked");
            Devices.Add(device);

            Devices = Devices.OrderBy(x => x.DeviceID).ToList();

        }

        public static DeviceRepository GetInstance()
        {
            return repository;
        }
    }
}