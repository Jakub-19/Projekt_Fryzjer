using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    public class SingleUseProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        public SingleUseProduct(int id, string name, int count, int price)
        {
            ID = id;
            Name = name;
            Count = count;
            Price = price;
        }
        public override string ToString()
        {
            return ID+" "+Name;
        }
    }
    public class Product : SingleUseProduct
    {
        public int Ml { get; set; }
        public int Capacity { get; set; }
        public Product(int id, string name, int count, int ml, int capacity, int price) : base(id, name, count, price)
        {
            Ml = ml;
            Capacity = capacity;
        }
    }
}
