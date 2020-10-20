using CarDealership.Models.Classes;
using CarDealership.Models.Classes.View_Model_Classes;
using CarDealership.UI.Data;
using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    [Authorize(Roles = "Admin, Sales")]
    public class SalesController : Controller
    {
        private RepoFactory repos = new RepoFactory();


        [HttpGet]
        public ActionResult Purchase(int id)
        {
            VehicleVM vehicleVM = new VehicleVM();
            Vehicle vehicle = repos.VehicleFactory().RetrieveOne(id);
            
            vehicleVM.Vehicle = vehicle;
            vehicleVM.Model = repos.ModelFactory().RetrieveOne(vehicle.ModelId);
            vehicleVM.Make = repos.MakeFactory().RetrieveOne(repos.ModelFactory().RetrieveOne(vehicle.ModelId).MakeId);
            vehicleVM.Interior = repos.InteriorFactory().RetrieveOne(vehicle.InteriorId);
            vehicleVM.Color = repos.ColorFactory().RetrieveOne(vehicle.ColorId);
            vehicleVM.BodyStyle = repos.BodyStyleFactory().RetrieveOne(vehicle.BodyStyleId);

            PurchaseVM purchaseVM = new PurchaseVM
            {
                Purchase = new Purchase(),
                VehicleVM = vehicleVM
            };
            purchaseVM.SetFinanceItems(new List<string> { "Bank Finance", "Cash", "Dealer Finance" });
            purchaseVM.SetStateItems(new List<string> { "MN", "AZ", "LA" });
            return View(purchaseVM);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseVM purchaseVM)
        {
            bool fieldsFilled = false;
            if (!string.IsNullOrEmpty(purchaseVM.Purchase.PhoneNumber))
            {
                fieldsFilled = true;
            }
            else if (!string.IsNullOrEmpty(purchaseVM.Purchase.Email))
            {
                fieldsFilled = true;
            }
            else
            {
                ModelState.AddModelError("PhoneNumber", "Phone or email required.");
                ModelState.AddModelError("Email", "Phone or email required.");
            }

            bool fiveInZip = false;
            if (purchaseVM.Purchase.ZipCode.Count() == 5)
            {
                fiveInZip = true;
            }
            else
            {
                ModelState.AddModelError("ZipCode", "Zip Code must be 5 digits.");
            }

            bool goodEmail = false;
            if (purchaseVM.Purchase.Email.Contains('@'))
            {
                goodEmail = true;
            }
            else
            {
                ModelState.AddModelError("Email", "Please a proper email.");
            }

            bool goodPrice = false;
            if (!(purchaseVM.Purchase.PurchasePrice > purchaseVM.VehicleVM.Vehicle.MSRP) && !(purchaseVM.Purchase.PurchasePrice < (purchaseVM.VehicleVM.Vehicle.MSRP * 0.95m)))
            {
                goodPrice = true;
            }
            else
            {
                ModelState.AddModelError("PurchasePrice", "Price can't be over MSRP, & not less than 95% of the MSRP.");
            }

            if (ModelState.IsValid && fieldsFilled && goodPrice && goodEmail && fiveInZip)
            {
                purchaseVM.Purchase.DateCreated = DateTime.Today;
                new RepoFactory().PurchaseFactory().Create(purchaseVM.Purchase);

                return RedirectToAction("Vehicles");
            }
            else
            {
                purchaseVM.SetFinanceItems(new List<string> { "Bank Finance", "Cash", "Dealer Finance" });
                purchaseVM.SetStateItems(new List<string> { "MN", "AZ", "LA" });
                return View(purchaseVM);
            }
        }

        [HttpGet]
        public ActionResult Vehicles()
        {
            SearchVehicleVM searchVehicleVM = new SearchVehicleVM { SearchBar = "" };
            List<decimal> priceList = new List<decimal>();
            List<int> yearList = new List<int> { 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021 };
            decimal highestPrice = 0;
            decimal newPrice = 0;

            priceList.Add(0);
            foreach (var item in repos.VehicleFactory().RetrieveAll())
            {
                if (highestPrice < item.Price)
                {
                    highestPrice = item.Price;
                }
            }
            while (true)
            {
                if (!(newPrice > (highestPrice + 5000)))
                {
                    newPrice += 5000;
                    priceList.Add(newPrice);
                }
                else
                {
                    break;
                }
            }

            searchVehicleVM.SetPriceItems(priceList);
            searchVehicleVM.SetYearItems(yearList);

            return View(searchVehicleVM);
        }

        [HttpPost]
        public ActionResult Vehicles(SearchVehicleVM svVM)
        {
            if (svVM.SearchBar == null)
            {
                svVM.SearchBar = "";
            }
            foreach (var vehicle in repos.VehicleFactory().Search(svVM.SearchBar, svVM.MinPrice, svVM.MaxPrice, svVM.MinYear, svVM.MaxYear))
            {
                bool purchased = false;
                foreach (var purchase in repos.PurchaseFactory().RetrieveAll())
                {
                    if (purchase.VehicleId == vehicle.VehicleId)
                    {
                        purchased = true;
                        break;
                    }
                }

                if (!purchased)
                {
                    Model model = repos.ModelFactory().RetrieveOne(vehicle.ModelId);
                    VehicleVM vehicleVM = new VehicleVM
                    {
                        Vehicle = vehicle,
                        BodyStyle = repos.BodyStyleFactory().RetrieveOne(vehicle.BodyStyleId),
                        Color = repos.ColorFactory().RetrieveOne(vehicle.ColorId),
                        Interior = repos.InteriorFactory().RetrieveOne(vehicle.InteriorId),
                        Model = model,
                        Make = repos.MakeFactory().RetrieveOne(model.MakeId)
                    };
                    svVM.VehicleList.Add(vehicleVM);
                }
            }

            List<decimal> priceList = new List<decimal>();
            List<int> yearList = new List<int> { 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021 };
            decimal highestPrice = 0;
            decimal newPrice = 0;

            priceList.Add(0);
            foreach (var item in repos.VehicleFactory().RetrieveAll())
            {
                if (highestPrice < item.Price)
                {
                    highestPrice = item.Price;
                }
            }
            while (true)
            {
                if (!(newPrice > (highestPrice + 5000)))
                {
                    newPrice += 5000;
                    priceList.Add(newPrice);
                }
                else
                {
                    break;
                }
            }

            svVM.SetPriceItems(priceList);
            svVM.SetYearItems(yearList);

            return View(svVM);
        }
    }
}