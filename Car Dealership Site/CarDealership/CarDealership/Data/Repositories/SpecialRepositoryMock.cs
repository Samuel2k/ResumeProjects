using CarDealership.Models.Classes;
using CarDealership.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Data.Repositories
{
    public class SpecialRepositoryMock : ISpecialRepository
    {
        private static List<Special> list = new List<Special>
        {
            new Special { SpecialDescription = "Save $200 on any purchase of swiss cheese!", SpecialId = 0, SpecialTitle = "CHEEZIT OUT"},
            new Special { SpecialDescription = "Save $400 on a second vehicle purchase after a first purchase.", SpecialId = 1, SpecialTitle = "Two with discounted 2nd"},
            new Special { SpecialDescription = "If you spend $2 on any product, you get your choice of ANY other product free!", SpecialId = 2, SpecialTitle = "Bad For Business"},
        };
        public List<Special> Create(Special special)
        {
            special.SpecialId = list.Max(c => c.SpecialId) + 1;
            list.Add(special);
            return list;
        }

        public List<Special> Delete(int id)
        {
            foreach (var item in RetrieveAll())
            {
                if (item.SpecialId == id)
                {
                    list.Remove(item);
                }
            }
            return list;
        }

        public List<Special> RetrieveAll()
        {
            return list;
        }

        public Special RetrieveOne(int id)
        {
            Special special = new Special();
            foreach (var item in list)
            {
                if (item.SpecialId == id)
                {
                    special = item;
                    break;
                }
            }
            return special;
        }
    }
}