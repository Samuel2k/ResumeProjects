using CarDealership.UI.Models;
using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class VehicleRepositoryADO : IVehicleRepository
    {
        public List<Vehicle> Create(Vehicle vehicle)
        {
            vehicle.VehicleId = RetrieveAll().Max(c => c.VehicleId) + 1;
            vehicle.DateCreated = DateTime.Today;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "CreateVehicle"
                };

                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.ColorId);
                cmd.Parameters.AddWithValue("@DateCreated", vehicle.DateCreated);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@InteriorId", vehicle.InteriorId);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Picture", vehicle.Picture);
                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                cmd.Parameters.AddWithValue("@UserId", vehicle.UserId);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            List<Vehicle> list = RetrieveAll();
            return list;
        }

        public List<Vehicle> Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "DeleteVehicle"
                };

                cmd.Parameters.AddWithValue("@VehicleId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            List<Vehicle> list = RetrieveAll();
            return list;
        }

        public List<Vehicle> RetrieveAll()
        {
            List<Vehicle> list = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "RetrieveAllVehicles"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle
                        {
                            BodyStyleId = int.Parse(dr["BodyStyleId"].ToString()),
                            ColorId = int.Parse(dr["ColorId"].ToString()),
                            DateCreated = DateTime.Parse(dr["DateCreated"].ToString()),
                            Description = dr["Description"].ToString(),
                            InteriorId = int.Parse(dr["InteriorId"].ToString()),
                            Mileage = int.Parse(dr["Mileage"].ToString()),
                            ModelId = int.Parse(dr["ModelId"].ToString()),
                            MSRP = decimal.Parse(dr["MSRP"].ToString()),
                            Picture = dr["Picture"].ToString(),
                            Price = decimal.Parse(dr["Price"].ToString()),
                            Transmission = dr["Transmission"].ToString(),
                            Type = dr["Type"].ToString(),
                            UserId = dr["UserId"].ToString(),
                            VehicleId = int.Parse(dr["VehicleId"].ToString()),
                            VIN = dr["VIN"].ToString(),
                            Featured = bool.Parse(dr["Featured"].ToString())
                        };

                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }

        public List<Vehicle> NewSearch(string searchBar, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            List<Vehicle> newList = Search(searchBar, minPrice, maxPrice, minYear, maxYear);
            newList.RemoveAll(x => x.Type.ToUpper() != "NEW");

            return newList;
        }

        public List<Vehicle> Update(Vehicle vehicle)
        {
            vehicle.DateCreated = DateTime.Today;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "UpdateVehicle"
                };

                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.ColorId);
                cmd.Parameters.AddWithValue("@DateCreated", vehicle.DateCreated);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@InteriorId", vehicle.InteriorId);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Picture", vehicle.Picture);
                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                cmd.Parameters.AddWithValue("@UserId", vehicle.UserId);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            List<Vehicle> list = RetrieveAll();
            return list;
        }

        public List<Vehicle> UsedSearch(string searchBar, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            List<Vehicle> newList = Search(searchBar, minPrice, maxPrice, minYear, maxYear);
            newList.RemoveAll(x => x.Type.ToUpper() != "USED");

            return newList;
        }

        public Vehicle RetrieveOne(int id)
        {
            Vehicle vehicle = new Vehicle();
            foreach (var item in RetrieveAll())
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
            List<Vehicle> list = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "VehicleSearch"
                };

                cmd.Parameters.AddWithValue("@searchTerm", searchBar);
                cmd.Parameters.AddWithValue("@minPrice", minPrice);
                cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
                cmd.Parameters.AddWithValue("@minYear", minYear);
                cmd.Parameters.AddWithValue("@maxYear", maxYear);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle
                        {
                            BodyStyleId = int.Parse(dr["BodyStyleId"].ToString()),
                            ColorId = int.Parse(dr["ColorId"].ToString()),
                            InteriorId = int.Parse(dr["InteriorId"].ToString()),
                            Mileage = int.Parse(dr["Mileage"].ToString()),
                            ModelId = int.Parse(dr["ModelId"].ToString()),
                            MSRP = decimal.Parse(dr["MSRP"].ToString()),
                            Picture = dr["Picture"].ToString(),
                            Price = decimal.Parse(dr["Price"].ToString()),
                            Transmission = dr["Transmission"].ToString(),
                            VehicleId = int.Parse(dr["VehicleId"].ToString()),
                            VIN = dr["VIN"].ToString(),
                            Type = dr["Type"].ToString()
                        };

                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }
    }
}