using FryzjerManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    class ClientRecord
    {
        private List<Client> clients;

        public void AddNew(string name, string lastname, string phone)
        {
            Client client = new Client(name, lastname, phone);
            Data_Access data = Data_Access.getInstance();
            if(!data.ClientExists(client))
            {
                data.AddClient(client);
            }
        }
    }
}
