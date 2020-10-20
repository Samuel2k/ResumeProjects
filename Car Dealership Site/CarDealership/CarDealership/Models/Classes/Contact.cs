using CarDealership.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.Models.Classes
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "The message field is required. (What do you want to tell us?)")]
        public string Message { get; set; }
    }
}