using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Managers
{
    public class ColorManager : IColorRepository
    {
        private IColorRepository repos;

        public ColorManager(IColorRepository repo)
        {
            repos = repo;
        }

        public List<Color> RetrieveAll()
        {
            return repos.RetrieveAll();
        }

        public Color RetrieveOne(int id)
        {
            return repos.RetrieveOne(id);
        }
    }
}