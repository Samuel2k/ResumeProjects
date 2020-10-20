using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models.DataTypes
{
    public class DvdResponse
    {
        public Dvd Dvd { get; set; }
        public bool Success { get; set; }
        public bool Message { get; set; }
    }
}