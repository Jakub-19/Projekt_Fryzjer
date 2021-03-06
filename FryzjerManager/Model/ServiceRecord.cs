﻿using FryzjerManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    //Klasa obsługuje spis dostępnych usług
    class ServiceRecord
    {
        public List<Service> Services { get; private set; }

        public ServiceRecord()
        {
            Data_Access data = Data_Access.getInstance();
            Services = new List<Service>();
            Services = data.ShowAllServices();
        }
    }
}
