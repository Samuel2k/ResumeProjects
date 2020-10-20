using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models.Classes
{
    public class Model
    {
        public int ModelId { get; set; }

        [Required]
        public string ModelName { get; set; }

        [Required]
        public int ModelYear { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        public int MakeId { get; set; }
        public string UserId { get; set; }
    }
}