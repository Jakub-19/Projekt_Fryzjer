using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    class Service
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }

        public Service(int id, string name, int time, int price)
        {
            ID = id;
            Name = name;
            Time = time;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
