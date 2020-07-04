using FryzjerManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerManager.Model
{
    //Klasa obsługuje spis wizyt
    public class VisitRecord
    {
        public List<Visit> Visits { get; private set; }

        public VisitRecord()
        {
            Visits = new List<Visit>();
        }
        // Pobranie na listę wizyt konkretnego klienta
        public void GetVisits(Client client)
        {
            Data_Access data = Data_Access.getInstance();
            Visits = data.ShowVisitsForClient(client);
        }

        public void Add(Visit visit)
        {
            Data_Access data = Data_Access.getInstance();
            data.AddVisit(visit);
        }
        public void Clear()
        {
            Visits = new List<Visit>();
        }
    }
}
