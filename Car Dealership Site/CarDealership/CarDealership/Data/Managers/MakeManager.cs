using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Managers
{
    public class MakeManager : IMakeRepository
    {
        private IMakeRepository repos;

        public MakeManager (IMakeRepository repo)
        {
            repos = repo;
        }

        public List<Make> Create(Make make)
        {
            return repos.Create(make);
        }

        public List<Make> RetrieveAll()
        {
            return repos.RetrieveAll();
        }

        public Make RetrieveOne(int id)
        {
            return repos.RetrieveOne(id);
        }
    }
}