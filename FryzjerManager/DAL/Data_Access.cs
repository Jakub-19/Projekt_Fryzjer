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
        MySqlConnection mySqlConnection;
        MySqlConnection con;
        string cs = @"server=localhost;userid=root;password=;database=fryzjer";
        public Data_Access()
        {
            mySqlConnection = new MySqlConnection(cs);
            con = mySqlConnection;
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
    }
}
