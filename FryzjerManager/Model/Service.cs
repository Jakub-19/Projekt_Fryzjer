using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    public class Service
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Service(int id, string name, double price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
