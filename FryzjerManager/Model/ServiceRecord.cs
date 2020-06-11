using FryzjerManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    class ServiceRecord
    {
        public List<Service> Services { get; private set; }

        public ServiceRecord()
        {
            Data_Access data = Data_Access.getInstance();
            Services = new List<Service>();
            Services.Add(new Service(0, "Usługa 1", 30, 30));
            Services.Add(new Service(1, "Usługa 2", 30, 30));
            Services.Add(new Service(2, "Usługa 3", 30, 30));
            Services.Add(new Service(3, "Usługa 4", 30, 30));
            Services.Add(new Service(4, "Usługa 5", 30, 30));
            //Services = data.ShowAllServices();    GENERUJE WYJATEK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        //public List<string> GetServicesNames()
        //{
        //    List<string> servicesNames = new List<string>();
        //    foreach (var v in Services)
        //        servicesNames.Add(v.ToString());

        //    return servicesNames;
        //}
    }
}
