using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class PurchaseRepositoryMock : IPurchaseRepository
    {
        private static List<Purchase> list = new List<Purchase>
        {
            new Purchase { City = "Cheeseland", DateCreated = new DateTime(1/1/20), Email = "Example@Example.com", Name = "Michael Shoe",
            PhoneNumber = "111-222-3333", PurchaseId = 0, PurchasePrice = 14999.99m, State = "XA", Street1 = "123 Soap Avenue", Street2 = "",
            VehicleId = 0, ZipCode = "55555", UserId = "21bfa463-552e-4750-ab4d-7fb1cf2539a4", PurchaseType = "Cash"}
            
        };

        public List<Purchase> Create(Purchase purchase)
        {
            purchase.PurchaseId = list.Max(c => c.PurchaseId) + 1;
            purchase.DateCreated = DateTime.Today;
            list.Add(purchase);
            return list;
        }

        public List<Purchase> RetrieveAll()
        {
            return list;
        }
    }
}