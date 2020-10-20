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
    public class BodyStyleRepositoryADO : IBodyStyleRepository
    {
        public List<BodyStyle> RetrieveAll()
        {
            List<BodyStyle> list = new List<BodyStyle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "RetrieveAllBodyStyles"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle currentRow = new BodyStyle
                        {
                            BodyStyleId = int.Parse(dr["BodyStyleId"].ToString()),
                            BodyStyleName = dr["BodyStyleName"].ToString()
                        };

                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }

        public BodyStyle RetrieveOne(int id)
        {
            BodyStyle bodyStyle = new BodyStyle();
            foreach (var item in RetrieveAll())
            {
                if (bodyStyle.BodyStyleId == id)
                {
                    bodyStyle = item;
                    break;
                }   
            }
            return bodyStyle;
        }
    }
}