using CarDealership.Models.Classes;
using CarDealership.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Data.Managers
{
    public class SpecialManager : ISpecialRepository
    {
        private ISpecialRepository repos;
        public SpecialManager(ISpecialRepository repo)
        {
            repos = repo;
        }
        public List<Special> Create(Special special)
        {
            return repos.Create(special);
        }

        public List<Special> RetrieveAll()
        {
            return repos.RetrieveAll();
        }

        public Special RetrieveOne(int id)
        {
            return repos.RetrieveOne(id);
        }

        public List<Special> Delete(int id)
        {
            return repos.Delete(id);
        }
    }
}