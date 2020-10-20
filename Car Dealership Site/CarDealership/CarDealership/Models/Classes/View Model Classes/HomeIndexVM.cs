using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models.Classes.View_Model_Classes
{
    public class HomeIndexVM
    {
        public List<VehicleVM> VehicleVMs { get; set; }
        public List<Special> Specials { get; set; }
    }
}