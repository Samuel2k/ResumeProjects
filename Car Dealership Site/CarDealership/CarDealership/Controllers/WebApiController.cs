using CarDealership.Models.Classes;
using CarDealership.UI.Data;
using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.Controllers
{
    public class WebApiController : ApiController
    {
        //Reports vehicle search, populating dropdowns in add & edit

        private static RepoFactory repo = new RepoFactory();

        //Dont forget the localhost portion of the URL BEFORE route
        [Route("admin/vehicles/{searchBar}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult AdminSearch(string searchBar, string minPrice, string maxPrice, string minYear, string maxYear)
        {
            VehicleVM vehicleVM = new VehicleVM();

            int? mP;
            if (minPrice == "null")
            {
                mP = null;
            }
            else
            {
                mP = int.Parse(minPrice);
            }

            int? MP;
            if (maxPrice == "null")
            {
                MP = null;
            }
            else
            {
                MP = int.Parse(maxPrice);
            }

            int? mY;
            if (minYear == "null")
            {
                mY = null;
            }
            else
            {
                mY = int.Parse(minYear);
            }

            int? MY;
            if (minYear == "null")
            {
                MY = null;
            }
            else
            {
                MY = int.Parse(maxYear);
            }

            List<Vehicle> list = repo.VehicleFactory().Search(searchBar, mP, MP, mY, MY);
            foreach (var vehicle in list)
            {
                vehicleVM.Vehicle = vehicle;
                vehicleVM.Model = repo.ModelFactory().RetrieveOne(vehicle.ModelId);
                vehicleVM.Make = repo.MakeFactory().RetrieveOne(repo.ModelFactory().RetrieveOne(vehicle.ModelId).MakeId);
                vehicleVM.Interior = repo.InteriorFactory().RetrieveOne(vehicle.InteriorId);
                vehicleVM.Color = repo.ColorFactory().RetrieveOne(vehicle.ColorId);
                vehicleVM.BodyStyle = repo.BodyStyleFactory().RetrieveOne(vehicle.BodyStyleId);
            }
            return Ok(list);
        }

        [Route("sales/vehicles/{searchBar}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SalesSearch(string searchBar, string minPrice, string maxPrice, string minYear, string maxYear)
        {
            VehicleVM vehicleVM = new VehicleVM();

            int? mP;
            if (minPrice == "null")
            {
                mP = null;
            }
            else
            {
                mP = int.Parse(minPrice);
            }

            int? MP;
            if (maxPrice == "null")
            {
                MP = null;
            }
            else
            {
                MP = int.Parse(maxPrice);
            }

            int? mY;
            if (minYear == "null")
            {
                mY = null;
            }
            else
            {
                mY = int.Parse(minYear);
            }

            int? MY;
            if (minYear == "null")
            {
                MY = null;
            }
            else
            {
                MY = int.Parse(maxYear);
            }

            List<Vehicle> list = repo.VehicleFactory().Search(searchBar, mP, MP, mY, MY);
            foreach (var vehicle in list)
            {
                vehicleVM.Vehicle = vehicle;
                vehicleVM.Model = repo.ModelFactory().RetrieveOne(vehicle.ModelId);
                vehicleVM.Make = repo.MakeFactory().RetrieveOne(repo.ModelFactory().RetrieveOne(vehicle.ModelId).MakeId);
                vehicleVM.Interior = repo.InteriorFactory().RetrieveOne(vehicle.InteriorId);
                vehicleVM.Color = repo.ColorFactory().RetrieveOne(vehicle.ColorId);
                vehicleVM.BodyStyle = repo.BodyStyleFactory().RetrieveOne(vehicle.BodyStyleId);
            }
            return Ok(list);
        }

        [Route("inventory/used/{searchBar}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult UsedSearch(string searchBar, string minPrice, string maxPrice, string minYear, string maxYear)
        {
            VehicleVM vehicleVM = new VehicleVM();

            int? mP;
            if (minPrice == "null")
            {
                mP = null;
            }
            else
            {
                mP = int.Parse(minPrice);
            }

            int? MP;
            if (maxPrice == "null")
            {
                MP = null;
            }
            else
            {
                MP = int.Parse(maxPrice);
            }

            int? mY;
            if (minYear == "null")
            {
                mY = null;
            }
            else
            {
                mY = int.Parse(minYear);
            }

            int? MY;
            if (minYear == "null")
            {
                MY = null;
            }
            else
            {
                MY = int.Parse(maxYear);
            }

            List<Vehicle> list = repo.VehicleFactory().UsedSearch(searchBar, mP, MP, mY, MY);
            foreach (var vehicle in list)
            {
                vehicleVM.Vehicle = vehicle;
                vehicleVM.Model = repo.ModelFactory().RetrieveOne(vehicle.ModelId);
                vehicleVM.Make = repo.MakeFactory().RetrieveOne(repo.ModelFactory().RetrieveOne(vehicle.ModelId).MakeId);
                vehicleVM.Interior = repo.InteriorFactory().RetrieveOne(vehicle.InteriorId);
                vehicleVM.Color = repo.ColorFactory().RetrieveOne(vehicle.ColorId);
                vehicleVM.BodyStyle = repo.BodyStyleFactory().RetrieveOne(vehicle.BodyStyleId);
            }
            return Ok(list);
        }

        [Route("inventory/new/{searchBar}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult NewSearch(string searchBar, string minPrice, string maxPrice, string minYear, string maxYear)
        {
            VehicleVM vehicleVM = new VehicleVM();

            int? mP;
            if (minPrice == "null")
            {
                mP = null;
            }
            else
            {
                mP = int.Parse(minPrice);
            }

            int? MP;
            if (maxPrice == "null")
            {
                MP = null;
            }
            else
            {
                MP = int.Parse(maxPrice);
            }

            int? mY;
            if (minYear == "null")
            {
                mY = null;
            }
            else
            {
                mY = int.Parse(minYear);
            }

            int? MY;
            if (minYear == "null")
            {
                MY = null;
            }
            else
            {
                MY = int.Parse(maxYear);
            }

            List<Vehicle> list = repo.VehicleFactory().NewSearch(searchBar, mP, MP, mY, MY);
            foreach (var vehicle in list)
            {
                vehicleVM.Vehicle = vehicle;
                vehicleVM.Model = repo.ModelFactory().RetrieveOne(vehicle.ModelId);
                vehicleVM.Make = repo.MakeFactory().RetrieveOne(repo.ModelFactory().RetrieveOne(vehicle.ModelId).MakeId);
                vehicleVM.Interior = repo.InteriorFactory().RetrieveOne(vehicle.InteriorId);
                vehicleVM.Color = repo.ColorFactory().RetrieveOne(vehicle.ColorId);
                vehicleVM.BodyStyle = repo.BodyStyleFactory().RetrieveOne(vehicle.BodyStyleId);
            }
            return Ok(list);
        }
    }
}
