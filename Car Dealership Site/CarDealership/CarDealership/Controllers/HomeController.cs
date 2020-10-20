using CarDealership.Data.Managers;
using CarDealership.Models.Classes;
using CarDealership.Models.Classes.View_Model_Classes;
using CarDealership.UI.Data;
using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        //Done?
        private static RepoFactory repo = new RepoFactory();

        [HttpGet]
        public ActionResult Index()
        {
            HomeIndexVM homeIndex = new HomeIndexVM();
            homeIndex.Specials = new List<Special>();
            homeIndex.VehicleVMs = new List<VehicleVM>();

            foreach (var item in repo.SpecialFactory().RetrieveAll())
            {
                homeIndex.Specials.Add(item);
            }
            foreach (var item in repo.VehicleFactory().RetrieveAll())
            {
                if (item.Featured == true)
                {
                    Model model = repo.ModelFactory().RetrieveOne(item.ModelId);
                    homeIndex.VehicleVMs.Add(new VehicleVM
                    {
                        Vehicle = item,
                        BodyStyle = repo.BodyStyleFactory().RetrieveOne(item.BodyStyleId),
                        Color = repo.ColorFactory().RetrieveOne(item.ColorId),
                        Interior = repo.InteriorFactory().RetrieveOne(item.InteriorId),
                        Make = repo.MakeFactory().RetrieveOne(model.MakeId),
                        Model = model
                    });
                }
            }
            return View(homeIndex);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            return View(repo.SpecialFactory().RetrieveAll());
        }

        [HttpGet]
        public ActionResult Contact(int id)
        {
            ContactVM contactVM = new ContactVM
            {
                Vehicle = new Vehicle(),
                Contact = new Contact()
            };
            if (id >= 0)
            {
                contactVM.Vehicle = repo.VehicleFactory().RetrieveOne(id);
                contactVM.Contact.Message = "The VIN is: " + contactVM.Vehicle.VIN;
            }
            return View(contactVM);
        }

        [HttpPost]
        public ActionResult Contact(ContactVM contactVM)
        {
            bool fieldsFilled = false;
            if (!string.IsNullOrEmpty(contactVM.Contact.Phone))
            {
                fieldsFilled = true;
            }
            else
            {
                contactVM.Contact.Phone = "";
            }

            if (!string.IsNullOrEmpty(contactVM.Contact.Email))
            {
                fieldsFilled = true;
            }
            else
            {
                contactVM.Contact.Email = "";
            }

            if (fieldsFilled && ModelState.IsValid)
            {
                repo.ContactFactory().Create(contactVM.Contact);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Phone", "Phone or email required.");
                ModelState.AddModelError("Email", "Phone or email required.");
                return View(contactVM);
            }
        }
    }
}