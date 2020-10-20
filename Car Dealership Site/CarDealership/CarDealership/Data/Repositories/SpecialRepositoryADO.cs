using CarDealership.Models.Classes;
using CarDealership.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealership.Data.Repositories
{
    public class SpecialRepositoryADO : ISpecialRepository
    {
        public List<Special> Create(Special special)
        {
            special.SpecialId = RetrieveAll().Max(c => c.SpecialId) + 1;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "CreateSpecial"
                };

                cmd.Parameters.AddWithValue("@SpecialDescription", special.SpecialDescription);
                cmd.Parameters.AddWithValue("@SpecialTitle", special.SpecialTitle);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            List<Special> list = RetrieveAll();
            return list;
        }

        public List<Special> Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DeleteSpecial";

                cmd.Parameters.AddWithValue("@SpecialId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RetrieveAll();
        }

        public List<Special> RetrieveAll()
        {
            List<Special> list = new List<Special>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "RetrieveAllSpecials"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special currentRow = new Special
                        {
                            SpecialDescription = dr["SpecialDescription"].ToString(),
                            SpecialTitle = dr["SpecialTitle"].ToString(),
                            SpecialId = int.Parse(dr["SpecialId"].ToString()),
                        };

                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }

        public Special RetrieveOne(int id)
        {
            Special special = new Special();
            foreach (var item in RetrieveAll())
            {
                if (item.SpecialId == id)
                {
                    special = item;
                    break;
                }
            }
            return special;
        }
    }
}