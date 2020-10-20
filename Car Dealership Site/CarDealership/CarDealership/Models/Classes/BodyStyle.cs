using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models.Classes
{
    public class BodyStyle
    {
        public int BodyStyleId { get; set; }

        [Required]
        public string BodyStyleName { get; set; }
    }
}