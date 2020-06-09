using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public Client(int id, string name, string lastName, string phoneNumber)
        {
            ID = id;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
