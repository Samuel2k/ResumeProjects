using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models.Classes
{
    public class Make
    {
        public int MakeId { get; set; }

        [Required]
        public string MakeName { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
    }
}