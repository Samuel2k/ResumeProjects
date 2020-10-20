using CarDealership.Data.Repositories;
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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private static RepoFactory repo = new RepoFactory();

        [HttpGet]
        public ActionResult Vehicles()
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
        public ActionResult Vehicles(SearchVehicleVM svVM)
        {
            if (svVM.SearchBar == null)
            {
                svVM.SearchBar = "";
            }
            foreach (var vehicle in repo.VehicleFactory().Search(svVM.SearchBar, svVM.MinPrice, svVM.MaxPrice, svVM.MinYear, svVM.MaxYear))
            {
                bool purchased = false;
                foreach (var purchase in repo.PurchaseFactory().RetrieveAll())
                {
                    if (purchase.VehicleId == vehicle.VehicleId)
                    {
                        purchased = true;
                        break;
                    }
                }

                if (!purchased)
                {
                    Model model = repo.ModelFactory().RetrieveOne(vehicle.ModelId);
                    VehicleVM vehicleVM = new VehicleVM
                    {
                        Vehicle = vehicle,
                        BodyStyle = repo.BodyStyleFactory().RetrieveOne(vehicle.BodyStyleId),
                        Color = repo.ColorFactory().RetrieveOne(vehicle.ColorId),
                        Interior = repo.InteriorFactory().RetrieveOne(vehicle.InteriorId),
                        Model = model,
                        Make = repo.MakeFactory().RetrieveOne(model.MakeId)
                    };
                    svVM.VehicleList.Add(vehicleVM);
                }
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
        public ActionResult AddVehicle()
        {
            VehicleAddEditVM VM = new VehicleAddEditVM();
            VM.SetBodyStyleItems(repo.BodyStyleFactory().RetrieveAll());
            VM.SetColorItems(repo.ColorFactory().RetrieveAll());
            VM.SetInteriorItems(repo.InteriorFactory().RetrieveAll());
            VM.SetMakeItems(repo.MakeFactory().RetrieveAll());
            VM.SetModelItems(repo.ModelFactory().RetrieveAll());
            VM.SetTransmissionItems(new List<string> { "Automatic", "Manual" });
            VM.SetTypeItems(new List<string> { "New", "Used" });
            return View(VM);
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleAddEditVM VM)
        {
            VM.Vehicle.UserId = "76c17ab7-e079-42b4-83ba-72d39154477c"; //Temp
            ModelState.Remove("Vehicle.UserId");
            ModelState.Remove("Type");
            ModelState.Remove("InteriorId");
            bool validType = false;
            if ((VM.Vehicle.Type.ToUpper() == "NEW" && VM.Vehicle.Mileage <= 1000) || (VM.Vehicle.Type.ToUpper() == "USED" && VM.Vehicle.Mileage > 1000))
            {
                validType = true;
            }
            else
            {
                ModelState.AddModelError("Type", "New vehicles have 0 to 1000 miles. Used have more. Try again.");
            }

            bool validPricing = false;
            if (VM.Vehicle.Price <= VM.Vehicle.MSRP && VM.Vehicle.MSRP > 0 && VM.Vehicle.Price > 0)
            {
                validPricing = true;
            }
            else
            {
                ModelState.AddModelError("Price", "Invalid price. Make sure is not 0 or less, nor is higher than MSRP.");
            }

            if (ModelState.IsValid && validType && validPricing)
            {
                VM.Vehicle.DateCreated = DateTime.Today;
                repo.VehicleFactory().Create(VM.Vehicle);
                return RedirectToAction("Vehicles");
            }
            else
            {
                VM.SetBodyStyleItems(repo.BodyStyleFactory().RetrieveAll());
                VM.SetColorItems(repo.ColorFactory().RetrieveAll());
                VM.SetInteriorItems(repo.InteriorFactory().RetrieveAll());
                VM.SetMakeItems(repo.MakeFactory().RetrieveAll());
                VM.SetModelItems(repo.ModelFactory().RetrieveAll());
                VM.SetTransmissionItems(new List<string> { "Automatic", "Manual" });
                VM.SetTypeItems(new List<string> { "New", "Used" });
                return View(VM);
            }

        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            VehicleAddEditVM VM = new VehicleAddEditVM
            {
                Vehicle = repo.VehicleFactory().RetrieveOne(id)
            };

            VM.SetBodyStyleItems(repo.BodyStyleFactory().RetrieveAll());
            VM.SetColorItems(repo.ColorFactory().RetrieveAll());
            VM.SetInteriorItems(repo.InteriorFactory().RetrieveAll());
            VM.SetMakeItems(repo.MakeFactory().RetrieveAll());
            VM.SetModelItems(repo.ModelFactory().RetrieveAll());
            VM.SetTransmissionItems(new List<string> { "Automatic", "Manual" });
            VM.SetTypeItems(new List<string> { "New", "Used" });
            return View(VM);
        }

        [HttpPost]
        public ActionResult EditVehicle(VehicleAddEditVM VM)
        {
            VM.Vehicle.UserId = "76c17ab7-e079-42b4-83ba-72d39154477c"; //Temp
            ModelState.Remove("Vehicle.UserId");
            bool validType = false;
            if ((VM.Vehicle.Type.ToUpper() == "NEW" && VM.Vehicle.Mileage <= 1000) || (VM.Vehicle.Type.ToUpper() == "USED" && VM.Vehicle.Mileage > 1000))
            {
                validType = true;
            }
            else
            {
                ModelState.AddModelError("Type", "New vehicles have 0 to 1000 miles. Used have more. Try again.");
            }

            bool validPricing = false;
            if (VM.Vehicle.Price <= VM.Vehicle.MSRP && VM.Vehicle.MSRP > 0 && VM.Vehicle.Price > 0)
            {
                validPricing = true;
            }
            else
            {
                ModelState.AddModelError("Price", "Invalid price. Make sure is not 0 or less, nor is higher than MSRP.");
            }

            if (ModelState.IsValid && validType && validPricing)
            {
                VM.Vehicle.DateCreated = DateTime.Today;
                repo.VehicleFactory().Update(VM.Vehicle);
                return RedirectToAction("Vehicles");
            }
            else
            {
                return View(VM);
            }
        }
        //ViewModel with list & new entry
        [HttpGet]
        public ActionResult Makes()
        {
            MakeVM makeVM = new MakeVM
            {
                Make = new Make(),
                MakeList = repo.MakeFactory().RetrieveAll()
            };

            return View(makeVM);
        }

        [HttpPost]
        public ActionResult Makes(MakeVM makeVM, string id)
        {
            makeVM.Make.DateCreated = DateTime.Today;
            makeVM.Make.UserId = id;
            repo.MakeFactory().Create(makeVM.Make);
            return RedirectToAction("Makes");
        }

        //ViewModel with list & new entry
        [HttpGet]
        public ActionResult Models()
        {
            ModelVM modelVM = new ModelVM
            {
                MakeModelList = new List<MakeModel>()
            };
            modelVM.SetMakeItems(repo.MakeFactory().RetrieveAll());
            foreach (var item in repo.ModelFactory().RetrieveAll())
            {
                MakeModel makeModel = new MakeModel
                {
                    Make = repo.MakeFactory().RetrieveOne(item.MakeId),
                    Model = item
                };
                modelVM.MakeModelList.Add(makeModel);
            }
            return View(modelVM);
        }
        [HttpPost]
        public ActionResult Models(ModelVM modelVM)
        {

            modelVM.SetMakeItems(repo.MakeFactory().RetrieveAll());
            foreach (var item in repo.ModelFactory().RetrieveAll())
            {
                MakeModel makeModel = new MakeModel
                {
                    Make = repo.MakeFactory().RetrieveOne(item.MakeId),
                    Model = item
                };
                modelVM.MakeModelList.Add(makeModel);
            }

            bool validYear = false;
            if (modelVM.Model.ModelYear >= 2000 && modelVM.Model.ModelYear <= 2021)
            {
                validYear = true;
            }
            else
            {
                ModelState.AddModelError("ModelYear", "That model year is invalid. Must be after 2000 thru 2021.");
            }

            if (ModelState.IsValid && validYear)
            {
                modelVM.Model.DateCreated = DateTime.Today;
                //UserId
                repo.ModelFactory().Create(modelVM.Model);
                return RedirectToAction("Models");
            }
            else
            {
                return View(modelVM);
            }
        }

        //ViewModel with list & new entry
        [HttpGet]
        public ActionResult Specials()
        {
            SpecialVM specialVM = new SpecialVM
            {
                SpecialList = repo.SpecialFactory().RetrieveAll()
            };
            return View(specialVM);
        }
        [HttpPost]
        public ActionResult Specials(SpecialVM specialVM)
        {
            repo.SpecialFactory().Create(specialVM.Special);
            return RedirectToAction("Specials");
        }

        [HttpGet]
        public ActionResult DeleteSpecial(int id)
        {
            return View(repo.SpecialFactory().RetrieveOne(id));
        }

        [HttpPost]
        public ActionResult DeleteSpecial(Special special)
        {
            repo.SpecialFactory().Delete(special.SpecialId);
            return RedirectToAction("Specials");
        }

        [HttpGet]
        public ActionResult DeleteVehicle(int id)
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

        [HttpPost]
        public ActionResult DeleteVehicle(VehicleVM vehicleVM)
        {
            repo.VehicleFactory().Delete(vehicleVM.Vehicle.VehicleId);
            return RedirectToAction("Vehicles");
        }

        public ActionResult Users()
        {
            return View(new UserRepository().RetrieveAll());
        }
    }
}