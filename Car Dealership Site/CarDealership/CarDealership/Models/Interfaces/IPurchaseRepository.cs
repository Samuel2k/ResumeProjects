using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.UI.Models.Interfaces
{
    public interface IPurchaseRepository
    {
        List<Purchase> Create(Purchase purchase);
        List<Purchase> RetrieveAll();
    }
}
