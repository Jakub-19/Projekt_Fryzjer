using FryzjerManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    public class Inventory
    {
        public List<Product> Products { get; private set; }
        public List<SingleUseProduct> SingleUseProducts { get; private set; }

        public void AddNew(SingleUseProduct product)
        {
            Data_Access data = Data_Access.getInstance();
            if(!data.ProductExists(product))
            {
                data.AddSingleUseProduct(product);
            }
        }
        public void AddNew(Product product)
        {
            Data_Access data = Data_Access.getInstance();
            if (!data.ProductExists(product))
            {
                data.AddProduct(product);
            }
        }
        public bool Add(SingleUseProduct product, uint quantity)
        {

            return false;
        }
        public bool Add(Product product, uint quantity)
        {

            return false;
        }
        public void UseUp(SingleUseProduct product, uint quantity)
        {
            Data_Access data = Data_Access.getInstance();
            product.Count = (int)((uint)product.Count - quantity);
            //data.UpdateProductCount(product, product.Count);
        }
        public void UseUp(Product product, uint milliliters)
        {
            Data_Access data = Data_Access.getInstance();
            while (milliliters > 0)
            {
                if (milliliters <= product.Ml)
                {
                    product.Ml = (int)((uint)product.Ml - milliliters);

                    data.UpdateProductMl(product, product.Ml);
                    //data.UpdateProductCount(product, product.Count);
                    return;
                }
                else
                {
                    milliliters = milliliters - (uint)product.Ml;
                    product.Ml = product.Capacity;
                    product.Count--;
                }
            }
        }
        public void Clear()
        {
            Products = new List<Product>();
            SingleUseProducts = new List<SingleUseProduct>();
        }
    }
}
