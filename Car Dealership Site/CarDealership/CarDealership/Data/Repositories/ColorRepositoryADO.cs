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
    public class ColorRepositoryADO : IColorRepository
    {
        public List<Color> RetrieveAll()
        {
            List<Color> list = new List<Color>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "RetrieveAllColors"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Color currentRow = new Color
                        {
                            ColorId = int.Parse(dr["ColorId"].ToString()),
                            ColorName = dr["ColorName"].ToString()
                        };

                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }

        public Color RetrieveOne(int id)
        {
            Color color = new Color();
            foreach (var item in RetrieveAll())
            {
                if (item.ColorId == id)
                {
                    color = item;
                    break;
                }
            }
            return color;
        }
    }
}