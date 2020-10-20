using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class ModelRepositoryMock : IModelRepository
    {
        private static List<Model> list = new List<Model>
        {
            new Model { DateCreated = new DateTime(1/1/13), MakeId = 0, ModelId = 0, ModelName = "A1", UserId = "76c17ab7-e079-42b4-83ba-72d39154477c", ModelYear = 2010},
            new Model { DateCreated = new DateTime(2/2/14), MakeId = 1, ModelId = 1, ModelName = "B2", UserId = "76c17ab7-e079-42b4-83ba-72d39154477c", ModelYear = 2014},
            new Model { DateCreated = new DateTime(6/6/16), MakeId = 2, ModelId = 2, ModelName = "C3", UserId = "76c17ab7-e079-42b4-83ba-72d39154477c", ModelYear = 2002}
        };

        public List<Model> Create(Model model)
        {
            model.ModelId = list.Max(c => c.ModelId) + 1;
            model.DateCreated = DateTime.Today;
            list.Add(model);
            return list;
        }

        public List<Model> RetrieveAll()
        {
            return list;
        }

        public Model RetrieveOne(int id)
        {
            Model model = new Model();
            foreach (var item in RetrieveAll())
            {
                if (item.MakeId == id)
                {
                    model = item;
                    break;
                }
            }
            return model;
        }
    }
}