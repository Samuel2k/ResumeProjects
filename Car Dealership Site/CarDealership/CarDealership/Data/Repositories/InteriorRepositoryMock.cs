using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class InteriorRepositoryMock : IInteriorRepository
    {
        private static List<Interior> list = new List<Interior>
        {
            new Interior { InteriorId = 0, InteriorName = "Black leather" },
            new Interior { InteriorId = 1, InteriorName = "Beige leather" },
            new Interior { InteriorId = 2, InteriorName = "Black fabric" },
            new Interior { InteriorId = 3, InteriorName = "Beige fabric" }
        };
        public List<Interior> RetrieveAll()
        {
            return list;
        }

        public Interior RetrieveOne(int id)
        {
            Interior interior = new Interior();
            foreach (var item in RetrieveAll())
            {
                if (item.InteriorId == id)
                {
                    interior = item;
                    break;
                }
            }
            return interior;
        }
    }
}