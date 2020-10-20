using CarDealership.UI.Models.Classes;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class PurchaseRepositoryADO : IPurchaseRepository
    {
        public List<Purchase> Create(Purchase purchase)
        {
            purchase.PurchaseId = RetrieveAll().Max(c => c.PurchaseId) + 1;
            purchase.DateCreated = DateTime.Today;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "CreatePurchase"
                };

                cmd.Parameters.AddWithValue("@City", purchase.City);
                cmd.Parameters.AddWithValue("@DateCreated", purchase.DateCreated);
                cmd.Parameters.AddWithValue("@Email", purchase.Email);
                cmd.Parameters.AddWithValue("@Name", purchase.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", purchase.PhoneNumber);
                cmd.Parameters.AddWithValue("@PurchasePrice", purchase.PurchasePrice);
                cmd.Parameters.AddWithValue("@State", purchase.State);
                cmd.Parameters.AddWithValue("@Street1", purchase.Street1);
                cmd.Parameters.AddWithValue("@Street2", purchase.Street2);
                cmd.Parameters.AddWithValue("@VehicleId", purchase.VehicleId);
                cmd.Parameters.AddWithValue("@ZipCode", purchase.ZipCode);
                cmd.Parameters.AddWithValue("@PurchaseType", purchase.PurchaseType);
                cmd.Parameters.AddWithValue("@UserId", "(Temporarily Unavailable.)");

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            List<Purchase> list = RetrieveAll();
            return list;
        }

        public List<Purchase> RetrieveAll()
        {
            List<Purchase> list = new List<Purchase>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "RetrieveAllPurchases"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Purchase currentRow = new Purchase
                        {
                            City = dr["City"].ToString(),
                            DateCreated = DateTime.Parse(dr["DateCreated"].ToString()),
                            Email = dr["Email"].ToString(),
                            Name = dr["Name"].ToString(),
                            PhoneNumber = dr["PhoneNumber"].ToString(),
                            PurchaseId = int.Parse(dr["PurchaseId"].ToString()),
                            PurchasePrice = decimal.Parse(dr["PurchasePrice"].ToString()),
                            State = dr["StateAbbreviation"].ToString(),
                            Street1 = dr["Street1"].ToString(),
                            Street2 = dr["Street2"].ToString(),
                            VehicleId = int.Parse(dr["VehicleId"].ToString()),
                            ZipCode = dr["ZipCode"].ToString(),
                            PurchaseType = dr["PurchaseType"].ToString(),
                            UserId = dr["UserId"].ToString()
                        };

                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }
    }
}