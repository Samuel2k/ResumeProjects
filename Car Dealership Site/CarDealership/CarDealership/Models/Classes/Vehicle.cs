using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models.Classes
{
    //Make the tables equivalent to the SQL side
    public class Vehicle
    {
        public int VehicleId { get; set; }


        public string Type { get; set; }

 
        public string Transmission { get; set; }

        [Required]
        public int Mileage { get; set; }

        [StringLength(17, ErrorMessage = "VIN must be 17 characters.")]
        public string VIN { get; set; }

        [Required]
        public decimal MSRP { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public int BodyStyleId { get; set; }

        [Required]
        public int ColorId { get; set; }

        
        public int InteriorId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public bool Featured { get; set; }
    }
}