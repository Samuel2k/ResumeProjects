using CarDealership.UI.Models;
using CarDealership.UI.Models.Classes;
using System.Collections.Generic;

namespace CarDealership.UI.Data
{
    public class VehicleManager : IVehicleRepository
    {
        private IVehicleRepository repos;
        public VehicleManager(IVehicleRepository repo)
        {
            repos = repo;
        }

        public List<Vehicle> Create(Vehicle vehicle)
        {
            return repos.Create(vehicle);
        }

        public List<Vehicle> Delete(int id)
        {
            return repos.Delete(id);
        }

        public List<Vehicle> RetrieveAll()
        {
            return repos.RetrieveAll();
        }

        public List<Vehicle> NewSearch(string searchBar, decimal? MinPrice, decimal? MaxPrice, int? minYear, int? MaxYear)
        {
            return repos.NewSearch(searchBar, MinPrice, MaxPrice, minYear, MaxYear);
        }

        public List<Vehicle> Update(Vehicle vehicle)
        {
            return repos.Update(vehicle);
        }

        public Vehicle RetrieveOne(int id)
        {
            return repos.RetrieveOne(id);
        }

        public List<Vehicle> UsedSearch(string searchBar, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            return repos.UsedSearch(searchBar, minPrice, maxPrice, minYear, maxYear);
        }

        public List<Vehicle> Search(string searchBar, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            return repos.Search(searchBar, minPrice, maxPrice, minYear, maxYear);
        }
    }
}