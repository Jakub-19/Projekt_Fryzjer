using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace FryzjerManager.DAL
{
    using Model;

    class Data_Access
    {
        private static Data_Access instance;
        MySqlConnection con;
        private Data_Access()
        {
            con = DBConnection.Instance.Connection;
        }
        public static Data_Access getInstance()
        {
            if (instance == null)
            {
                instance = new Data_Access();
            }
            return instance;
        }
        //Funkcja uruchamiająca połączenie z bazą danych
        public void Start()
        {
            con.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "use fryzjer";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #region repozytoria

        #region Client
        
        //Funkcja sprawdzająca czy klient o podanym imieniu, nazwisku i numerze telefonu już istnieje
        public bool ClientExists(string name, string lastName, string number)
        {
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT EXISTS(SELECT * FROM clients WHERE name like\"" + name + "\" AND surname like \"" + lastName + "\" AND  phone_number like \"" + number + "\")";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            int l = 0;
            while (rdr.Read())
            {
                l = rdr.GetInt32(0);

            }
            con.Close();
            if (l != 0)
                return true;
            else
                return false;
        }
        public bool ClientExists(Client client)
        {
            return ClientExists(client.Name, client.LastName, client.PhoneNumber);
        }

        //Funckja znajdująca klienta na podstawie podanego imienia i nazwiska
        public List<Client> FindClient(string name, string lastName)
        {
            List<Client> clients = new List<Client>();
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT * FROM clients WHERE name like\"%" + name + "%\" AND surname like \"%" + lastName + "%\"";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Client client = new Client(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));
                clients.Add(client);
            }
            con.Close();
            return clients;
        }

        //Funcja dodająca klienta do bazy danych
        public void AddClient(Client client)
        {
            string name = client.Name;
            string lastName = client.LastName;
            string phone = client.PhoneNumber;
            try
            {
                con.Open();
            }
            catch { }
            string command = "INSERT INTO clients(name, surname, phone_number) VALUES('" + name + "','" + lastName + "','" + phone + "')";
            MySqlCommand cmd = new MySqlCommand(command, con);
            cmd.ExecuteReader();
            con.Close();

        }
        #endregion

        #region Product

        //Funkcja auktualniająca ilość produktu w bazie danych
        public void UpdateProductCount(SingleUseProduct product, int newCount)
        {
            try
            {
                con.Open();
            }
            catch { }
            if (product is Product)
            {
                string command = "UPDATE products set quantity_item=" + newCount.ToString() + " Where id_p=" + product.ID.ToString();
                MySqlCommand cmd = new MySqlCommand(command, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
            }
            else if (product is SingleUseProduct)
            {
                string command = "UPDATE disposable_products set quantity=" + newCount.ToString() + " Where id_dp=" + product.ID.ToString();
                MySqlCommand cmd = new MySqlCommand(command, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
            }
            con.Close();
        }
        public void UpdateProductMl(Product product, int newml)
        {
            try
            {
                con.Open();
            }
            catch { }
            string command = "UPDATE products set ml=" + newml.ToString() + " Where id_p=" + product.ID.ToString();
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            con.Close();
        }

        //Funkcje szukajce produktów na podstawie ich nazwy
        public List<SingleUseProduct> SearchSingleUseProductByName(string name)
        {
            List<SingleUseProduct> products = new List<SingleUseProduct>();
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT * FROM disposable_products WHERE name like \"%" + name + "%\"";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SingleUseProduct product = new SingleUseProduct(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3));
                products.Add(product);
                Console.WriteLine(product.ToString());
            }
            rdr.Close();
            con.Close();
            return products;
        }
        public List<Product> SearchProductByName(string name)
        {
            List<Product> products = new List<Product>();
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT * FROM products WHERE name like \"%" + name + "%\"";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Product product = new Product(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5));
                products.Add(product);
                Console.WriteLine(product.ToString());
            }
            rdr.Close();
            con.Close();
            return products;
        }

        //Funkcje szukajce produktów na podstawie ich nazwy wśród dostępnych produktów
        public List<Product> SearchAvailableProducts(string name)
        {
            List<Product> products = new List<Product>();


            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT * FROM products WHERE (quantity_item <>0 AND ml<>0) " +
                "AND name LIKE \"%" + name + "%\"";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Product product = new Product(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5));
                products.Add(product);
            }
            rdr.Close();
            con.Close();
            return products;
        }
        public List<SingleUseProduct> SearchAvailableSingleUseProducts(string name)
        {
            List<SingleUseProduct> products = new List<SingleUseProduct>();
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT * FROM disposable_products WHERE quantity<>0 " +
                "AND name like\"%" + name + "%\"";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SingleUseProduct product = new SingleUseProduct(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3));
                products.Add(product);
            }

            rdr.Close();
            con.Close();

            return products;
        }

        //Funckje dodające nowy produkt do inwentarza
        public void AddSingleUseProduct(SingleUseProduct product)
        {
            string name = product.Name;
            int count = product.Count;
            int price = product.Price;
            try
            {
                con.Open();
            }
            catch { }
            string command = "INSERT INTO disposable_products(name, quantity, price) VALUES('" + name + "','" + count + "','" + price + "')";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            con.Close();

        }
        public void AddProduct(Product product)
        {
            string name = product.Name;
            int count = product.Count;
            int price = product.Price;
            int ml = product.Ml;
            int capacity = product.Capacity;
            try
            {
                con.Open();
            }
            catch { }
            string command = "INSERT INTO products(name, quantity_item,ml,capacity, price) VALUES('" + name + "','" + count + "','" + ml + "','" + capacity + "','" + price + "')";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            con.Close();

        }

        //Funckje sprawdzający czy dany produkt już istnieje w inwentarzu
        public bool ProductExists(string name)
        {
            int l = 0;
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT EXISTS(SELECT * FROM disposable_products WHERE name like \"" + name + "\")";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                l += rdr.GetInt32(0);
            }
            rdr.Close();
            command = "SELECT EXISTS(Select *from products WHERE name like \"" + name + "\")";
            cmd = new MySqlCommand(command, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                l += rdr.GetInt32(0);
            }

            con.Close();
            if (l != 0)
                return true;
            else
                return false;
        }
        public bool ProductExists(Product product)
        {
            return ProductExists(product.Name);
        }
        public bool ProductExists(SingleUseProduct product)
        {
            return ProductExists(product.Name);
        }

        //Funkcje przypisujące produkt oraz ilośc jaka została zużyta do wizyty w bazie danych
        public void AddProductToVisit(Product product, int? id_v)
        {
            try
            {
                con.Open();
            }
            catch { }
            string command = "INSERT productvisit " +
                "(id_v,id_p,quantity)  " +
                "VALUES " +
                "(" + id_v + "," + product.ID + "," + product.SuggestedConsumption + ")";
            MySqlCommand cmd = new MySqlCommand(command, con);
            cmd.ExecuteReader();
            con.Close();
        }
        public void AddSingleUseProductToVisit(SingleUseProduct product, int? id_v)
        {
            try
            {
                con.Open();
            }
            catch { }
            string command = "INSERT dproductvisit " +
                "(id_v,id_dp,quantity)  " +
                "VALUES " +
                "(" + id_v + "," + product.ID + "," + product.SuggestedConsumption + ")";
            MySqlCommand cmd = new MySqlCommand(command, con);
            cmd.ExecuteReader();
            con.Close();
        }
        #endregion

        //Funckja wyświetlająca usługi oferowane przez salon
        public List<Service> ShowAllServices()
        {
            List<Service> services = new List<Service>();

            con.Open();

            string command = "SELECT * FROM services ";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Service service = new Service(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2));
                services.Add(service);
                Console.WriteLine(service.ToString());
            }
            con.Close();
            return services;
        }

        #region Visits

        //Funkcja dodająca wizytę do bazy danych
        public void AddVisit(Visit visit)
        {
            var id_c = visit.Person.ID;
            int id_v = 0;
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "INSERT INTO visits (id_c,date,price) VALUES (" + id_c + ",'" + visit.Date.ToString("yyyy-MM-dd") + "'," + visit.FullPrice + ")";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT MAX(id_v) FROM visits";
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                id_v = rdr.GetInt32(0);
            }
            rdr.Close();
            foreach (var s in visit.TypeOfService)
            {
                cmd.CommandText = "INSERT INTO servicevisit (id_s,id_v) VALUES (" + s.ID + "," + id_v + ")";
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        public void AddVisit(Visit visit, List<Product> products, List<SingleUseProduct>singleUseProducts)
        {
            var id_c = visit.Person.ID;
            int id_v = 0;
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "INSERT INTO visits (id_c,date,price) VALUES (" + id_c + ",'" + visit.Date.ToString("yyyy-MM-dd") + "'," + visit.FullPrice + ")";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT MAX(id_v) FROM visits";
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                id_v = rdr.GetInt32(0);
            }
            rdr.Close();
            foreach (var s in visit.TypeOfService)
            {
                cmd.CommandText = "INSERT INTO servicevisit (id_s,id_v) VALUES (" + s.ID + "," + id_v + ")";
                cmd.ExecuteNonQuery();
            }
            con.Close();
            foreach (var product in products)
                AddProductToVisit(product, id_v);
            foreach (var product in singleUseProducts)
                AddSingleUseProductToVisit(product, id_v);
        }

        //Funkcja wypisująca wszystkie wizyty jednego klienta
        public List<Visit> ShowVisitsForClient(Client client)
        {
            List<Visit> visits = new List<Visit>();
            List<Service> services = new List<Service>();
            con.Open();
            string command = "SELECT id_v, price,date " +
                "FROM visits " +
                "WHERE " +
                "id_c=" + client.ID;
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Visit visit = new Visit(rdr.GetDouble(1), client, services, rdr.GetDateTime(2), rdr.GetInt32(0));
                visits.Add(visit);
            }
            con.Close();
            foreach (var v in visits)
            {
                v.TypeOfService = GetServicesFromOneVisit(v.ID);
            }

            return visits;
        }

        //Funkcja wypisująca wszystkie usług ykonane podczas jednej wizyty
        public List<Service> GetServicesFromOneVisit(int? id_v)
        {
            List<Service> services = new List<Service>();
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT s.id_s,s.name, s.price "
               + "FROM visits v left join servicevisit sv on "
               + "v.id_v = sv.id_v " +
               "left join services s on " +
               "sv.id_s = s.id_s " +
               "where v.id_v = " + id_v;
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Service service = new Service(rdr.GetInt32(0), rdr.GetString(1), rdr.GetDouble(2));
                services.Add(service);
            }

            rdr.Close();
            con.Close();
            return services;
        }
        #endregion


        #endregion
    }
}
