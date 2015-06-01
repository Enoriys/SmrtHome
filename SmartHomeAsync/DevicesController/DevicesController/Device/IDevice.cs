using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesController.Device
{
    public interface IDevice
    {
        string Id {get;set;}

        Task<string> ActionAsync(string Action,string Parametr);
    }
}
