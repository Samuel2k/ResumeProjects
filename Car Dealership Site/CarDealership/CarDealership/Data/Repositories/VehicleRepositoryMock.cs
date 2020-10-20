using CarDealership.UI.Models;
using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class VehicleRepositoryMock : IVehicleRepository
    {
        //SEVERAL repositories

        private static List<Vehicle> list = new List<Vehicle>
        {
            new Vehicle {BodyStyleId = 0, ColorId = 0, DateCreated = new DateTime(16,1,1), Description = "A cool vehicle.", InteriorId = 0,
                         Mileage = 30000, ModelId = 0, MSRP = 45000.00m, Price = 14999.99m, Transmission = "Automatic", Type = "Used",
                         UserId = "76c17ab7-e079-42b4-83ba-72d39154477c", VehicleId = 0, VIN = "1a1a1a1a1a1a1a1a1", Picture = "/Pictures/BlackTruck.jpg", Featured = true},
            new Vehicle {BodyStyleId = 1, ColorId = 1, DateCreated = new DateTime(13,2,2), Description = "An alright SUV.", InteriorId = 1,
                         Mileage = 50000, ModelId = 1, MSRP = 55000.00m, Price = 25000, Transmission = "Manual", Type = "Used",
                         UserId = "76c17ab7-e079-42b4-83ba-72d39154477c", VehicleId = 1, VIN = "2b2b2b2b2b2b2b2b2", Picture = "/Pictures/RedSUV.jpg", Featured = false},
            new Vehicle {BodyStyleId = 2, ColorId = 2, DateCreated = new DateTime(20,3,3), Description = "A bad car.", InteriorId = 2,
                         Mileage = 5, ModelId = 2, MSRP = 77777.77m, Price = 44444.44m, Transmission = "Automatic", Type = "New",
                         UserId = "76c17ab7-e079-42b4-83ba-72d39154477c", VehicleId = 2, VIN = "3c3c3c3c3c3c3c3c3", Picture = "/Pictures/YellowSedan.png", Featured = true}
        };

        public List<Vehicle> Create(Vehicle vehicle)
        {
            vehicle.VehicleId = list.Max(c => c.VehicleId) + 1;
            vehicle.DateCreated = DateTime.Today;
            list.Add(vehicle);
            return list;
        }

        public List<Vehicle> Delete(int id)
        {
            Vehicle vehicle = new Vehicle();
            foreach (var item in list)
            {
                if (item.VehicleId == id)
                {
                    vehicle = item;
                    list.Remove(vehicle);
                    break;
                }
            }
            return list;
        }

        public List<Vehicle> RetrieveAll()
        {
            return list;
        }

        public List<Vehicle> NewSearch(string searchBar, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            List<Vehicle> newList = Search(searchBar, minPrice, maxPrice, minYear, maxYear);

            return newList.Where(x => x.Type.ToUpper() == "NEW").ToList();
        }

        public List<Vehicle> Update(Vehicle vehicle)
        {
            foreach (var item in list)
            {
                if (item.VehicleId == vehicle.VehicleId)
                {
                    list.Remove(item);
                    list.Add(vehicle);
                    break;
                }
            }

            return list;
        }

        public List<Vehicle> UsedSearch(string searchBar, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            List<Vehicle> newList = Search(searchBar, minPrice, maxPrice, minYear, maxYear);

            return newList.Where(x => x.Type.ToUpper() == "USED").ToList();
        }

        public Vehicle RetrieveOne(int id)
        {
            Vehicle vehicle = new Vehicle();
            foreach (var item in list)
            {
                if (item.VehicleId == id)
                {
                    vehicle = item;
                }
            }
            return vehicle;
        }

        public List<Vehicle> Search(string searchBar, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            List<Vehicle> searchResults = new List<Vehicle>();

            List<Vehicle> searchBarMakeList = new List<Vehicle>();
            List<Vehicle> searchBarModelList = new List<Vehicle>();
            List<Vehicle> searchBarYearList = new List<Vehicle>();

            RepoFactory repo = new RepoFactory();

            //Searchbar
            if (!string.IsNullOrEmpty(searchBar))
            {
                //Check for matching makes & add them to the list.
                foreach (var make in repo.MakeFactory().RetrieveAll())
                {
                    //Check to see if the searchbar contains the make name
                    if (make.MakeName.Contains(searchBar))
                    {
                        foreach (var model in repo.ModelFactory().RetrieveAll())
                        {
                            //If the make Id is matching the model Id, use the model Id to add any vehicles with that model.
                            if (make.MakeId == model.MakeId)
                            {
                                foreach (var vehicle in RetrieveAll())
                                {
                                    //Save to the searchbar list for matching vehicles.
                                    if (model.ModelId == vehicle.ModelId)
                                    {
                                        searchBarMakeList.Add(vehicle);
                                    }
                                }
                            }
                        }
                    }
                }

                //Check for matching models & add them to the list
                foreach (var model in repo.ModelFactory().RetrieveAll())
                {
                    //If the searchbar contains a part at least of the model name (same goes for all "contains")
                    if (model.ModelName.Contains(searchBar))
                    {
                        foreach (var vehicle in RetrieveAll())
                        {
                            //Add if the vehicle(s) has/have the matching modelId
                            if (model.ModelId == vehicle.ModelId)
                            {
                                searchBarModelList.Add(vehicle);
                            }
                        }
                    }

                    //Check if the year is matching any digits inside the searchbar
                    if (model.ModelYear.ToString().Contains(searchBar))
                    {
                        foreach (var vehicle in RetrieveAll())
                        {
                            //Add if the vehicle(s) has/have the matching modelId
                            if (model.ModelId == vehicle.ModelId)
                            {
                                searchBarYearList.Add(vehicle);
                            }
                        }
                    }
                }

                //Combine the list's elements & remove duplicates
                searchResults = searchResults.Union(searchBarMakeList).ToList();
                searchResults = searchResults.Union(searchBarModelList).ToList();
                searchResults = searchResults.Union(searchBarYearList).ToList();
            }
            else
            {
                searchResults = list;
            }

            //If minPrice is available
            if (minPrice != null)
            {

                //Remove any vehicles that have a lower price than the minimum
                searchResults.RemoveAll(x => x.Price < minPrice);
            }

            //If maxPrice is available
            if (maxPrice != null)
            {
                //Remove any vehicles that have a price higher than maximum
                searchResults.RemoveAll(x => x.Price > maxPrice);
            }

            //If minYear is available
            if (minYear != null)
            {
                foreach (var model in repo.ModelFactory().RetrieveAll())
                {
                    //If the model's year is less than the minimum
                    if (model.ModelYear < minYear)
                    {

                        //Remove any vehicle that has that model
                        searchResults.RemoveAll(x => x.ModelId == model.ModelId);

                    }
                }
            }

            //If maxYear is available
            if (maxYear != null)
            {
                foreach (var model in repo.ModelFactory().RetrieveAll())
                {
                    //If the model's year is over the maximum
                    if (model.ModelYear > maxYear)
                    {
                        searchResults.RemoveAll(x => x.ModelId == model.ModelId);
                    }
                }
            }

            searchResults = searchResults.OrderByDescending(v => v.MSRP).ToList();

            return searchResults;
        }
    }
}