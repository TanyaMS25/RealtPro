using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtProWpfApp.Entities
{
    public partial class Realtor
    {
        public string FullName
        {
            get
            {
                var fullName = $"{LastName} {FirstName}";

                if (string.IsNullOrWhiteSpace(Patronymic) == false)
                {
                    fullName += $" {Patronymic}";
                }

                return fullName;
            }
        }
        public int NumberOfObjects
        {
            get
            {
                int numberOfApart= Apartments.Count();
                int numberOfHouse = Houses.Count();
                return numberOfApart+numberOfHouse;
            }
        }
        public int NumberOfObjectsInWork
        {
            get
            {
                int numberOfApartInWork = Apartments.Where(p => p.ObjectStatusId == 1).Count();
                int numberOfHouseInWork = Houses.Where(p => p.ObjectStatusId == 1).Count();
                return numberOfApartInWork + numberOfHouseInWork;
            }
        }
        public int NumberOfClosedObjects
        {
            get
            {
                int numberOfClosedApart = Apartments.Where(p => p.ObjectStatusId == 3).Count();
                int numberOfClosedHouse = Houses.Where(p => p.ObjectStatusId == 3).Count();
                return numberOfClosedApart+numberOfClosedHouse;
            }
        }
        public int NumberOfClients
        {
            get
            {
                return Clients.Count();
            }
        }
        public int NumberOfClosedClients
        {
            get
            {
                return Clients.Where(p => p.ObjectStatusId == 3).Count();
            }
        }
        public int NumberOfClientsInWork
        {
            get
            {
                return Clients.Where(p => p.ObjectStatusId == 1).Count();
            }
        }
    }
}
