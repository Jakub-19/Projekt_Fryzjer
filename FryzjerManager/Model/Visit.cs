﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    class Visit
    {
        public int ID { get; set; }
        //public int ID_k { get; set; }
        //Odczytalbym od razu jaka osoba jest pod tym id i trzymal tutaj obiekt Client
        public Client Person { get; set; }
        //public int ID_u { get; set; }
        //Z id uslugi zrobilbym podobnie jak z klientem
        //Nie powinno byc z tym problemu przy komunikacji z baza danych
        public Service TypeOfService { get; set; }
        public string NameOfService { get; set; }
        public DateTime Date { get; set; }
        public int FullPrice { get; set; }
        public Visit(int id,  string nameOfService, int fullPrice, Client client, Service service, DateTime date)
        {
            ID = id;
            //ID_k = id_k;
            //ID_u = id_u;
            NameOfService = nameOfService;
            FullPrice = fullPrice;
            Person = client;
            TypeOfService = service;
            Date = date;
        }
    }
}
