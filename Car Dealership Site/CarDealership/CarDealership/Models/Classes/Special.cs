using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.Models.Classes
{
    public class Special
    {
        public int SpecialId { get; set; }
        
        [Required]
        public string SpecialTitle { get; set; }
        
        [Required]
        public string SpecialDescription { get; set; }
    }
}