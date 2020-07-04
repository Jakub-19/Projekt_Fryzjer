using FryzjerManager.DAL;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    //Klasa obsługująca spis klientów
    class ClientRecord
    {
        public List<Client> Clients { get; private set; }

        public ClientRecord()
        {
            Clients = new List<Client>();
        }

        public void GetClients(string name = "", string surname = "")
        {
            Data_Access data = Data_Access.getInstance();
            Clients = data.FindClient(name, surname);
        }

        public void AddNew(string name, string lastname, string phone)
        {
            Client client = new Client(name, lastname, phone);
            Data_Access data = Data_Access.getInstance();
            if(!data.ClientExists(client))// Czy taki klient już istnieje?
            {
                data.AddClient(client);
            }
        }
        public void Clear()
        {
            Clients = new List<Client>();
        }
    }
}
