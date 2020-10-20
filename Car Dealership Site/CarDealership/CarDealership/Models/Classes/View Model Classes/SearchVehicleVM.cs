using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models.Classes.View_Model_Classes
{
    public class SearchVehicleVM
    {
        public string SearchBar { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public List<SelectListItem> PriceList { get; set; }
        public List<SelectListItem> YearList { get; set; }
        public List<VehicleVM> VehicleList { get; set; }

        public SearchVehicleVM()
        {
            PriceList = new List<SelectListItem>();
            YearList = new List<SelectListItem>();
            VehicleList = new List<VehicleVM>();
        }
        public void SetPriceItems(IEnumerable<decimal> prices)
        {
            foreach (var price in prices)
            {
                PriceList.Add(new SelectListItem()
                {
                    Value = price.ToString(),
                    Text = price.ToString()
                });
            }
        }
        public void SetYearItems(IEnumerable<int> years)
        {
            foreach (var year in years)
            {
                YearList.Add(new SelectListItem()
                {
                    Value = year.ToString(),
                    Text = year.ToString()
                });
            }
        }
    }
}