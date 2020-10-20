using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models.Classes.View_Model_Classes
{
    public class SalesVM
    {
        public List<SalesEntryVM> SalesEntries { get; set; }

        public string SelectedUserId { get; set; }
        public List<SelectListItem> UserList { get; set; }
        public string MinDate { get; set; }
        public string MaxDate { get; set; }
        
        public SalesVM()
        {
            SalesEntries = new List<SalesEntryVM>();
            UserList = new List<SelectListItem>();
        }
        public void SetUserItems(IEnumerable<string> users)
        {
            foreach (var user in users)
            {
                UserList.Add(new SelectListItem()
                {
                    Value = user.ToString(),
                    Text = user.ToString()
                });
            }
        }
    }
}