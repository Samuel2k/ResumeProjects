using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models.Classes
{
    public class Color
    {
        public int ColorId { get; set; }
        
        [Required]
        public string ColorName { get; set; }
    }
}