using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models.Classes.View_Model_Classes
{
    public class InventoryVM
    {
        public List<CountVehicle> NewVehicles { get; set; } 
        public List<CountVehicle> UsedVehicles { get; set; }

        public InventoryVM()
        {
            NewVehicles = new List<CountVehicle>();
            UsedVehicles = new List<CountVehicle>();
        }
    }
}