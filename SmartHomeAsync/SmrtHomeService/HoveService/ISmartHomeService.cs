using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HomeService
{
    [ServiceContract]
    public interface ISmartHomeService
    {
        [OperationContract]
        Task<string[]> MakeAction(string[] ID, string type, string Action, string Parametr);
    }
}
