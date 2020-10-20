using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models.Classes
{
    public class VehicleVM
    {
        public Vehicle Vehicle { get; set; }
        public Color Color { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public Interior Interior { get; set; }
        public bool Purchased { get; set; }

    }
}