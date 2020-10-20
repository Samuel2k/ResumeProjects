using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models.Classes
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }

        [Required]
        public string Name { get; set; }


        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [Required]
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string PurchaseType { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
    }
}