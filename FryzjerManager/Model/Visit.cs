using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    //Encja visits 
    public class Visit
    {
        public int? ID { get; set; }
        public Client Person { get; set; }
        public List<Service> TypeOfService { get; set; }
        public DateTime Date { get; set; }
        public double FullPrice { get; set; }
        public Visit(  double fullPrice, Client client, List<Service> service, DateTime date, int? id=null)
        {
            FullPrice = fullPrice;
            Person = client;
            TypeOfService = service;
            Date = date;
            ID = id;
        }
    }
}
