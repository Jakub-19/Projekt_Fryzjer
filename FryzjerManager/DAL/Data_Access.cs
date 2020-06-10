using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FryzjerManager.DAL
{
    using Model;
    class Data_Access
    {
        private static Data_Access instance;
        MySqlConnection mySqlConnection;
        MySqlConnection con;
        string cs = @"server=localhost;userid=root;password=;database=fryzjer";
        private Data_Access()
        {
            mySqlConnection = new MySqlConnection(cs);
            con = mySqlConnection;
        }
        public static Data_Access getInstance()
        {
            if(instance==null)
            {
                instance = new Data_Access();
            }
            return instance;
        }
        #region Client
        public bool ClientExists(string name, string lastName)
        {
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT EXISTS(SELECT * FROM clients WHERE name like\"" + name + "\" AND surname like \"" + lastName + "\")";
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
            return ClientExists(client.Name, client.LastName);
        }

        public List<Client> FindClient(string name, string lastName)
        {
            List<Client> clients = new List<Client>();
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT * FROM clients WHERE name like\"" + name + "%\" AND surname like \"" + lastName + "%\"";
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

        public List<Client> ShowAllClients()
        {
            List<Client> clients = new List<Client>();
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT * FROM clients ";
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
            MySqlDataReader rdr = cmd.ExecuteReader();
            con.Close();

        }
        #endregion

        #region Product
        public List<SingleUseProduct> ShowAllProducts()
        {
            List<SingleUseProduct> products = new List<SingleUseProduct>();
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT * FROM disposable_products ";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SingleUseProduct product = new SingleUseProduct(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3));
                products.Add(product);
            }
            rdr.Close();
            command = "SELECT * FROM products ";
            cmd = new MySqlCommand(command, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Product product = new Product(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5));
                products.Add(product);
            }
            con.Close();

            return products;
        }

        public void UpdateProductCount(SingleUseProduct product, int newCount)
        {
            try
            {
                con.Open();
            }
            catch { }
            string command = "UPDATE products set quantity_item=" + newCount.ToString() + " Where id_p=" + product.ID.ToString();
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();
            command = "UPDATE disposable_products set quantity=" + newCount.ToString() + " Where id_p=" + product.ID.ToString();
            cmd = new MySqlCommand(command, con);
            rdr = cmd.ExecuteReader();
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
        public List<SingleUseProduct> SearchProductByName(string name)
        {
            List<SingleUseProduct> products = new List<SingleUseProduct>();
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT * FROM disposable_products where name like \"" + name + "%\"";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SingleUseProduct product = new SingleUseProduct(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3));
                products.Add(product);
            }
            rdr.Close();
            command = "Select *from products where name like \"" + name + "%\"";
            cmd = new MySqlCommand(command, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Product product = new Product(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5));
                products.Add(product);
            }

            con.Close();
            return products;
        }
        public List<SingleUseProduct> ShowAvailableProducts()
        {
            List<SingleUseProduct> products = new List<SingleUseProduct>();
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT * FROM disposable_products where quantity <> 0";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SingleUseProduct product = new SingleUseProduct(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3));
                products.Add(product);
            }
            rdr.Close();
            command = "SELECT * FROM products where quantity_item <> 0 and ml <> 0 ";
            cmd = new MySqlCommand(command, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Product product = new Product(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5));
                products.Add(product);
            }
            con.Close();

            return products;
        }
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
            string command = "INSERT INTO products(name, quantity_item,capacity, price) VALUES('" + name + "','" + count + "','" + ml + "','" + capacity + "','" + price + "')";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            con.Close();

        }
        public bool ProductExists(string name)
        {
            int l = 0;
            try
            {
                con.Open();
            }
            catch { }
            string command = "SELECT EXISTS(SELECT * FROM disposable_products where name like \"" + name + "\")";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                l += rdr.GetInt32(0);
            }
            rdr.Close();
            command = "SELECT EXISTS(Select *from products where name like \"" + name + "\")";
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
        #endregion
    }
}
