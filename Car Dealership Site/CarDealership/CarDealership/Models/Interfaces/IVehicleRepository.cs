using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.UI.Models
{
    public interface IVehicleRepository
    {
        List<Vehicle> Create(Vehicle vehicle);
        List<Vehicle> Update(Vehicle vehicle);
        List<Vehicle> Delete(int id);
        List<Vehicle> RetrieveAll();
        Vehicle RetrieveOne(int id);
        List<Vehicle> NewSearch(string searchBar, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear);
        List<Vehicle> UsedSearch(string searchBar, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear);
        List<Vehicle> Search(string searchBar, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear);
    }
}
