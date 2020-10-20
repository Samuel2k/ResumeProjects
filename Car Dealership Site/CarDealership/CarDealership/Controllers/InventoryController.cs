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
    public class InventoryController : Controller
    {
        private static RepoFactory repo = new RepoFactory();
        //Done?
        [HttpGet]
        public ActionResult Details(int id)
        {
            VehicleVM vehicleVM = new VehicleVM();
            Vehicle vehicle = repo.VehicleFactory().RetrieveOne(id);
            vehicleVM.Purchased = false;
            foreach (var item in repo.PurchaseFactory().RetrieveAll())
            {
                if (item.VehicleId == id)
                {
                    vehicleVM.Purchased = true;
                }
            }
            vehicleVM.Vehicle = vehicle;
            vehicleVM.Model = repo.ModelFactory().RetrieveOne(vehicle.ModelId);
            vehicleVM.Make = repo.MakeFactory().RetrieveOne(repo.ModelFactory().RetrieveOne(vehicle.ModelId).MakeId);
            vehicleVM.Interior = repo.InteriorFactory().RetrieveOne(vehicle.InteriorId);
            vehicleVM.Color = repo.ColorFactory().RetrieveOne(vehicle.ColorId);
            vehicleVM.BodyStyle = repo.BodyStyleFactory().RetrieveOne(vehicle.BodyStyleId);
            return View(vehicleVM);
        }
        [HttpGet]
        public ActionResult New()
        {
            SearchVehicleVM searchVehicleVM = new SearchVehicleVM { SearchBar = "" };
            List<decimal> priceList = new List<decimal>();
            List<int> yearList = new List<int> { 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021 };
            decimal highestPrice = 0;
            decimal newPrice = 0;

            priceList.Add(0);
            foreach (var item in repo.VehicleFactory().RetrieveAll())
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
        public ActionResult New(SearchVehicleVM svVM)
        {
            if (svVM.SearchBar == null)
            {
                svVM.SearchBar = "";
            }
            foreach (var vehicle in repo.VehicleFactory().NewSearch(svVM.SearchBar, svVM.MinPrice, svVM.MaxPrice, svVM.MinYear, svVM.MaxYear))
            {
                Model model = repo.ModelFactory().RetrieveOne(vehicle.ModelId);
                VehicleVM vehicleVM = new VehicleVM
                {
                    Vehicle = vehicle,
                    BodyStyle = repo.BodyStyleFactory().RetrieveOne(vehicle.BodyStyleId),
                    Color = repo.ColorFactory().RetrieveOne(vehicle.ColorId),
                    Interior = repo.InteriorFactory().RetrieveOne(vehicle.InteriorId),
                    Model = model,
                    Make = repo.MakeFactory().RetrieveOne(model.MakeId),
                };

                svVM.VehicleList.Add(vehicleVM);

            }

            List<decimal> priceList = new List<decimal>();
            List<int> yearList = new List<int> { 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021 };
            decimal highestPrice = 0;
            decimal newPrice = 0;

            priceList.Add(0);
            foreach (var item in repo.VehicleFactory().RetrieveAll())
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

        [HttpGet]
        public ActionResult Used()
        {
            SearchVehicleVM searchVehicleVM = new SearchVehicleVM { SearchBar = "" };
            List<decimal> priceList = new List<decimal>();
            List<int> yearList = new List<int> { 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021 };
            decimal highestPrice = 0;
            decimal newPrice = 0;

            priceList.Add(0);
            foreach (var item in repo.VehicleFactory().RetrieveAll())
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
        public ActionResult Used(SearchVehicleVM svVM)
        {
            if (svVM.SearchBar == null)
            {
                svVM.SearchBar = "";
            }
            foreach (var vehicle in repo.VehicleFactory().UsedSearch(svVM.SearchBar, svVM.MinPrice, svVM.MaxPrice, svVM.MinYear, svVM.MaxYear))
            {

                Model model = repo.ModelFactory().RetrieveOne(vehicle.ModelId);
                VehicleVM vehicleVM = new VehicleVM
                {
                    Vehicle = vehicle,
                    BodyStyle = repo.BodyStyleFactory().RetrieveOne(vehicle.BodyStyleId),
                    Color = repo.ColorFactory().RetrieveOne(vehicle.ColorId),
                    Interior = repo.InteriorFactory().RetrieveOne(vehicle.InteriorId),
                    Model = model,
                    Make = repo.MakeFactory().RetrieveOne(model.MakeId),
                };
                svVM.VehicleList.Add(vehicleVM);

            }

            List<decimal> priceList = new List<decimal>();
            List<int> yearList = new List<int> { 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021 };
            decimal highestPrice = 0;
            decimal newPrice = 0;

            priceList.Add(0);
            foreach (var item in repo.VehicleFactory().RetrieveAll())
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