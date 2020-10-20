using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class MakeRepositoryMock :IMakeRepository
    {
        private static List<Make> list = new List<Make>
        {
            new Make { DateCreated = new DateTime(2020,1,1), MakeId = 0, MakeName = "VehicleLand", UserId = "76c17ab7-e079-42b4-83ba-72d39154477c"},
            new Make { DateCreated = new DateTime(2019,2,2), MakeId = 1, MakeName = "John's cars", UserId = "76c17ab7-e079-42b4-83ba-72d39154477c"},
            new Make { DateCreated = new DateTime(2018,3,3), MakeId = 2, MakeName = "Super Motors", UserId = "76c17ab7-e079-42b4-83ba-72d39154477c"}
        };

        public List<Make> Create(Make make)
        {
            make.MakeId = list.Max(c => c.MakeId) + 1;
            make.DateCreated = DateTime.Today;
            list.Add(make);
            return list;
        }

        public List<Make> RetrieveAll()
        {
            return list;
        }

        public Make RetrieveOne(int id)
        {
            Make make = new Make();
            foreach (var item in list)
            {
                if (item.MakeId == id)
                {
                    make = item;
                    break;
                }
            }
            return make;
        }
    }
}