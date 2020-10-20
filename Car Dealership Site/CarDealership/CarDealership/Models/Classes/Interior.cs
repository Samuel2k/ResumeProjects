using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models.Classes
{
    public class Interior
    {
        public int InteriorId { get; set; }

        [Required]
        public string InteriorName { get; set; }
    }
}