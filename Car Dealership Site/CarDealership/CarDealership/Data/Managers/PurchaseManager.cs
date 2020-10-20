using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Managers
{
    public class PurchaseManager : IPurchaseRepository
    {
        private IPurchaseRepository repos;

        public PurchaseManager(IPurchaseRepository repo)
        {
            repos = repo;
        }

        public List<Purchase> Create(Purchase purchase)
        {
            return repos.Create(purchase);
        }

        public List<Purchase> RetrieveAll()
        {
            return repos.RetrieveAll();
        }
    }
}