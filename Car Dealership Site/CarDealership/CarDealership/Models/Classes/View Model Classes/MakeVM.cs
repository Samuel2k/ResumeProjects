using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models.Classes.View_Model_Classes
{
    public class MakeVM
    {
        public Make Make { get; set; }
        public List<Make> MakeList { get; set; }
    }
}