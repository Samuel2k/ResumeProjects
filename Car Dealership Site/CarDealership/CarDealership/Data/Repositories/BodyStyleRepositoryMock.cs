using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class BodyStyleRepositoryMock : IBodyStyleRepository
    {
        List<BodyStyle> list = new List<BodyStyle>
        {
            new BodyStyle { BodyStyleId = 0, BodyStyleName = "Truck"},
            new BodyStyle { BodyStyleId = 1, BodyStyleName = "SUV"},
            new BodyStyle { BodyStyleId = 2, BodyStyleName = "Car"},
            new BodyStyle { BodyStyleId = 3, BodyStyleName = "Van"}
        };
        public List<BodyStyle> RetrieveAll()
        {
            return list;
        }

        public BodyStyle RetrieveOne(int id)
        {
            BodyStyle bodyStyle = new BodyStyle();
            foreach (var item in list)
            {
                if (item.BodyStyleId == id)
                {
                    bodyStyle = item;
                    break;
                }
            }
            return bodyStyle;
        }
    }
}