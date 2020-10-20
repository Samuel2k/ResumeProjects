using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class ColorRepositoryMock : IColorRepository
    {
        private static List<Color> list = new List<Color>
        {
            new Color { ColorId = 0, ColorName = "Black" },
            new Color { ColorId = 1, ColorName = "Red" },
            new Color { ColorId = 2, ColorName = "Yellow" },
            new Color { ColorId = 3, ColorName = "Blue" },
            new Color { ColorId = 4, ColorName = "Purple"}
        };
        public List<Color> RetrieveAll()
        {
            return list;
        }

        public Color RetrieveOne(int id)
        {
            Color color = new Color();
            foreach (var item in list)
            {
                if (item.ColorId == id)
                {
                    color = item;
                    break;
                }
            }
            return color;
        }
    }
}