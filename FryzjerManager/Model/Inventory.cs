using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    public class Inventory
    {
        private List<Product> products;
        private List<SingleUseProduct> singleUseProducts;

        public bool AddNew(SingleUseProduct product)
        {

            return false;
        }
        public bool AddNew(Product product)
        {

            return false;
        }
        public bool AddN(SingleUseProduct product, uint quantity)
        {

            return false;
        }
        public bool Add(SingleUseProduct product, uint quantity)
        {

            return false;
        }
        public bool UseUp(SingleUseProduct product, uint quantity)
        {

            return false;
        }
        public bool UseUp(Product product, uint milliliters)
        {

            return false;
        }
    }
}
