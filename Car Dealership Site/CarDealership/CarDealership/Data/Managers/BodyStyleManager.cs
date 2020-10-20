using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Managers
{
    public class BodyStyleManager : IBodyStyleRepository
    {
        private IBodyStyleRepository repos;
        public BodyStyleManager(IBodyStyleRepository repo)
        {
            repos = repo;
        }
        public List<BodyStyle> RetrieveAll()
        {
            return repos.RetrieveAll();
        }

        public BodyStyle RetrieveOne(int id)
        {
            return repos.RetrieveOne(id);
        }
    }
}