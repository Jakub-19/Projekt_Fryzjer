using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    //encja disposable product
    public class SingleUseProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int SuggestedConsumption { get; set; }

        public SingleUseProduct(int id, string name, int count, double price)
        {
            ID = id;
            Name = name;
            Count = count;
            Price = price;
            SuggestedConsumption = 0;
        }
        public override string ToString()
        {
            return ID+" "+Name;
        }
    }
    //encja product klasa dziedziczy po klasie singleUseProduct
    public class Product : SingleUseProduct
    {
        public int Ml { get; set; }
        public int Capacity { get; set; }
        public Product(int id, string name, int count, int ml, int capacity, double price) : base(id, name, count, price)
        {
            Ml = ml;
            Capacity = capacity;
        }
    }
}
