using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    class Client
    {
        public int ID;
        public string Name;
        public string LastName;
        public string PhoneNumber;

        public Client(int id, string name, string lastName, string phoneNumber)
        {
            ID = id;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
