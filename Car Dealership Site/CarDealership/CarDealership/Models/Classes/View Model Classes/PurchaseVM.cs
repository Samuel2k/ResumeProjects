using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models.Classes.View_Model_Classes
{
    public class PurchaseVM
    {
        public List<SelectListItem> FinanceList {get; set;}
        public List<SelectListItem> StateList { get; set; }
        public Purchase Purchase { get; set; }
        public VehicleVM VehicleVM { get; set; }

        public PurchaseVM()
        {
            FinanceList = new List<SelectListItem>();
            StateList = new List<SelectListItem>();
            Purchase = new Purchase();
            VehicleVM = new VehicleVM();
            VehicleVM.Vehicle = new Vehicle();
            VehicleVM.Model = new Model();
            VehicleVM.Make = new Make();
            VehicleVM.Interior = new Interior();
            VehicleVM.Color = new Color();
            VehicleVM.BodyStyle = new BodyStyle();
        }

        public void SetFinanceItems(IEnumerable<string> finances)
        {
            foreach (var financeType in finances)
            {
                FinanceList.Add(new SelectListItem()
                {
                    Value = financeType.ToString(),
                    Text = financeType
                });
            }
        }

        public void SetStateItems(IEnumerable<string> states)
        {
            foreach (var stateType in states)
            {
                StateList.Add(new SelectListItem()
                {
                    Value = stateType.ToString(),
                    Text = stateType
                });
            }
        }
    }
}