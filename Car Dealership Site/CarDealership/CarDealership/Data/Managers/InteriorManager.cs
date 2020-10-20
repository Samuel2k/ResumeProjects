using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Managers
{
    public class InteriorManager : IInteriorRepository
    {
        private IInteriorRepository repos;

        public InteriorManager(IInteriorRepository repo)
        {
            repos = repo;
        }

        public List<Interior> RetrieveAll()
        {
            return repos.RetrieveAll();
        }

        public Interior RetrieveOne(int id)
        {
            return repos.RetrieveOne(id);
        }
    }
}