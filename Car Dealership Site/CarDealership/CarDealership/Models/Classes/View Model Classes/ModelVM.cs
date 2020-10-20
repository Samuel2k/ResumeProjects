using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models.Classes.View_Model_Classes
{
    public class ModelVM
    {
        public Model Model {get; set;}
        public List<MakeModel> MakeModelList { get; set; }
        public List<SelectListItem> MakeList { get; set; }

        public ModelVM()
        {
            MakeModelList = new List<MakeModel>();
            MakeList = new List<SelectListItem>();
        }

        public void SetMakeItems(IEnumerable<Make> makes)
        {
            foreach (var make in makes)
            {
                MakeList.Add(new SelectListItem()
                {
                    Value = make.MakeId.ToString(),
                    Text = make.MakeName
                });
            }
        }
    }
}