using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Managers
{
    public class ModelManager : IModelRepository
    {
        private IModelRepository repos;


        public ModelManager(IModelRepository repo)
        {
            repos = repo;
        }

        public List<Model> Create(Model model)
        {
            return repos.Create(model);
        }

        public List<Model> RetrieveAll()
        {
            return repos.RetrieveAll();
        }

        public Model RetrieveOne(int id)
        {
            return repos.RetrieveOne(id);
        }
    }
}