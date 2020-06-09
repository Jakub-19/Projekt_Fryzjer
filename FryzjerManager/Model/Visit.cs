using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    class Visit
    {
        public int ID { get; set; }
        public int ID_k { get; set; }
        public int ID_u { get; set; }
        public string NameOfService { get; set; }
        //public DataTime Data { get; set; }
        public int FullPrice { get; set; }
        public Visit(int id, int id_k, int id_u, string nameOfService, int fullPrice)
        {
            ID = id;
            ID_k = id_k;
            ID_u = id_u;
            NameOfService = nameOfService;
            FullPrice = fullPrice;
        }
    }
}
