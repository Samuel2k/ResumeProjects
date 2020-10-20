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
    public class InteriorRepositoryADO : IInteriorRepository
    {
        public List<Interior> RetrieveAll()
        {
            List<Interior> list = new List<Interior>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "RetrieveAllInteriors"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Interior currentRow = new Interior
                        {
                            InteriorId = int.Parse(dr["InteriorId"].ToString()),
                            InteriorName = dr["InteriorName"].ToString()
                        };

                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }

        public Interior RetrieveOne(int id)
        {
            Interior interior = new Interior();
            foreach (var item in RetrieveAll())
            {
                if (interior.InteriorId == id)
                {
                    interior = item;
                    break;
                }
                
            }
            return interior;
        }
    }
}