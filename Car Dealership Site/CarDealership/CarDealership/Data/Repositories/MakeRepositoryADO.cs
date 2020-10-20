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
    public class MakeRepositoryADO : IMakeRepository
    {
        public List<Make> Create(Make make)
        {
            make.MakeId = RetrieveAll().Max(c => c.MakeId) + 1;
            make.DateCreated = DateTime.Today;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "CreateMake"
                };

                cmd.Parameters.AddWithValue("@DateCreated", make.DateCreated);
                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@UserId", "76c17ab7-e079-42b4-83ba-72d39154477c");

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            List<Make> list = RetrieveAll();
            return list;
        }

        public List<Make> RetrieveAll()
        {
            List<Make> list = new List<Make>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "RetrieveAllMakes"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make
                        {
                            DateCreated = DateTime.Parse(dr["DateCreated"].ToString()),
                            MakeId = int.Parse(dr["MakeId"].ToString()),
                            MakeName = dr["MakeName"].ToString(),
                            UserId = dr["UserId"].ToString()
                        };

                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }

        public Make RetrieveOne(int id)
        {
            Make make = new Make();
            foreach (var item in RetrieveAll())
            {
                if (item.MakeId == id)
                {
                    make = item;
                    break;
                }
            }
            return make;
        }
    }
}