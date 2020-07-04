using FryzjerManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    //Klasa obsługująca stan magazynu
    public class Inventory
    {
        public List<Product> Products { get; private set; }
        public List<SingleUseProduct> SingleUseProducts { get; private set; }
        public Inventory()
        {
            Products = new List<Product>();
            SingleUseProducts = new List<SingleUseProduct>();
        }

        // AddNew dodaje nowy (nieistniejący wcześniej) produkt do bazy danych
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
        // Add aktualizuje ilość produktów będących już w bazie danych
        public void Add(SingleUseProduct product, uint quantity)
        {
            Data_Access data = Data_Access.getInstance();
            data.UpdateProductCount(product, (int)(quantity));
        }
        public void Add(Product product, uint quantity)
        {
            Data_Access data = Data_Access.getInstance();
            data.UpdateProductCount(product, (int)(quantity));
        }
        // UseUp aktualizuje ilość produktów będących w bazie danych (zużycie)
        public void UseUp(SingleUseProduct product, uint quantity)
        {
            Data_Access data = Data_Access.getInstance();
            product.Count = (int)((uint)product.Count - quantity);
            data.UpdateProductCount(product, product.Count);
        }
        public void UseUp(Product product, uint milliliters)
        {
            Data_Access data = Data_Access.getInstance();
            //Obliczenie zużycia
            while (milliliters > 0)
            {
                if (milliliters <= product.Ml)//Jeśli w otwartym opakowaniu jest więcej produktu niż zużyto
                {
                    product.Ml = (int)((uint)product.Ml - milliliters);//odejmij

                    data.UpdateProductMl(product, product.Ml);//zaktualizuj
                    data.UpdateProductCount(product, product.Count);
                    return;
                }
                else
                {
                    milliliters = milliliters - (uint)product.Ml;//otwórz nowe opakowanie
                    product.Ml = product.Capacity;
                    product.Count--;
                }
            }
        }

        //Pobieranie list produktów
        public void GetProducts(string name)
        {
            Data_Access data = Data_Access.getInstance();
            Products = data.SearchAvailableProducts(name);
        }
        public void GetSingleUseProducts(string name)
        {
            Data_Access data = Data_Access.getInstance();
            SingleUseProducts = data.SearchAvailableSingleUseProducts(name);
        }
        public void GetAllProducts(string name)
        {
            Data_Access data = Data_Access.getInstance();
            Products = data.SearchProductByName(name);
        }
        public void GetAllSingleUseProducts(string name)
        {
            Data_Access data = Data_Access.getInstance();
            SingleUseProducts = data.SearchSingleUseProductByName(name);
        }
        public void Clear()
        {
            Products = new List<Product>();
            SingleUseProducts = new List<SingleUseProduct>();
        }
    }
}
