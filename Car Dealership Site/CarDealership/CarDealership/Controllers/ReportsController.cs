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
    public class ReportsController : Controller
    {
        private static RepoFactory repos = new RepoFactory();
        //Please complete Sales & Inventory with count
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Sales()
        {
            SalesVM salesVM = new SalesVM();

            //For each sale (purchase) that the user has successfully done, add to the count & add the price up
            foreach (var purchase in repos.PurchaseFactory().RetrieveAll())
            {
                SalesEntryVM sale = new SalesEntryVM
                {
                    TotalSales = 0,
                    TotalVehicles = 0
                };

                bool userHasSold = false;

                foreach (var item in salesVM.SalesEntries)
                {
                    if (purchase.UserId == item.UserId)
                    {
                        userHasSold = true;
                        sale.UserId = item.UserId;
                        sale.TotalVehicles = item.TotalVehicles + 1;
                        sale.TotalSales = item.TotalSales + purchase.PurchasePrice;
                        salesVM.SalesEntries.Remove(item);
                        salesVM.SalesEntries.Add(sale);
                    }
                }

                if (userHasSold == false)
                {
                    sale.UserId = purchase.UserId;
                    sale.TotalSales += purchase.PurchasePrice;
                    sale.TotalVehicles += 1;
                }
                salesVM.SalesEntries.Add(sale);
            }
            return View(salesVM);
        }

        //Use an if statement in the view for filtering out users that dont match
        [HttpPost]
        public ActionResult Sales(SalesVM salesVM)
        {
            //For each sale (purchase) that the user has successfully done, add to the count & add the price up
            foreach (var purchase in repos.PurchaseFactory().RetrieveAll())
            {
                SalesEntryVM sale = new SalesEntryVM
                {
                    TotalSales = 0,
                    TotalVehicles = 0
                };

                bool userHasSold = false;

                foreach (var item in salesVM.SalesEntries)
                {
                    if (purchase.UserId == item.UserId && purchase.DateCreated >= DateTime.Parse(salesVM.MinDate) && purchase.DateCreated <= DateTime.Parse(salesVM.MaxDate))
                    {
                        userHasSold = true;
                        sale.UserId = item.UserId;
                        sale.TotalVehicles = item.TotalVehicles + 1;
                        sale.TotalSales = item.TotalSales + purchase.PurchasePrice;
                        salesVM.SalesEntries.Remove(item);
                        salesVM.SalesEntries.Add(sale);
                    }
                }

                if (userHasSold == false && purchase.DateCreated >= DateTime.Parse(salesVM.MinDate) && purchase.DateCreated <= DateTime.Parse(salesVM.MaxDate))
                {
                    sale.UserId = purchase.UserId;
                    sale.TotalSales += purchase.PurchasePrice;
                    sale.TotalVehicles += 1;
                }
                salesVM.SalesEntries.Add(sale);
            }
            return View(salesVM);
        }

        [HttpGet]
        public ActionResult Inventory()
        {
            InventoryVM inventoryVM = new InventoryVM
            {
                NewVehicles = new List<CountVehicle>(),
                UsedVehicles = new List<CountVehicle>()
            };

            foreach (var vehicle in repos.VehicleFactory().RetrieveAll())
            {
                CountVehicle countVehicle = new CountVehicle
                {
                    Count = 0
                };

                countVehicle.VehicleVM = new Models.Classes.VehicleVM();

                bool isInList = false;

                foreach (var item in inventoryVM.NewVehicles)
                {
                    if (item.VehicleVM.Vehicle.VehicleId == vehicle.VehicleId && vehicle.Type.ToUpper() == "NEW")
                    {
                        isInList = true;
                        countVehicle.Count = item.Count + 1;
                        countVehicle.VehicleVM.Model = item.VehicleVM.Model;
                        countVehicle.VehicleVM.Make = item.VehicleVM.Make;
                        countVehicle.VehicleVM.Vehicle = item.VehicleVM.Vehicle;
                        inventoryVM.NewVehicles.Remove(item);
                        inventoryVM.NewVehicles.Add(countVehicle);
                    }
                }

                if (!isInList && vehicle.Type.ToUpper() == "NEW")
                {
                    countVehicle.Count += 1;
                    countVehicle.VehicleVM.Vehicle = vehicle;
                    Model model = repos.ModelFactory().RetrieveOne(vehicle.ModelId);
                    countVehicle.VehicleVM.Model = model;
                    countVehicle.VehicleVM.Make = repos.MakeFactory().RetrieveOne(model.MakeId);
                    inventoryVM.NewVehicles.Add(countVehicle);
                }

                foreach (var item in inventoryVM.UsedVehicles)
                {
                    if (item.VehicleVM.Vehicle.VehicleId == vehicle.VehicleId && vehicle.Type.ToUpper() == "USED")
                    {
                        isInList = true;
                        countVehicle.Count = item.Count + 1;
                        countVehicle.VehicleVM.Model = item.VehicleVM.Model;
                        countVehicle.VehicleVM.Make = item.VehicleVM.Make;
                        countVehicle.VehicleVM.Vehicle = item.VehicleVM.Vehicle;
                        inventoryVM.UsedVehicles.Remove(item);
                        inventoryVM.UsedVehicles.Add(countVehicle);
                    }
                }

                if (!isInList && vehicle.Type.ToUpper() == "USED")
                {
                    countVehicle.Count += 1;
                    countVehicle.VehicleVM.Vehicle = vehicle;
                    Model model = repos.ModelFactory().RetrieveOne(vehicle.ModelId);
                    countVehicle.VehicleVM.Model = model;
                    countVehicle.VehicleVM.Make = repos.MakeFactory().RetrieveOne(model.MakeId);
                    inventoryVM.UsedVehicles.Add(countVehicle);
                }
            }
            return View(inventoryVM);
        }
    }
}