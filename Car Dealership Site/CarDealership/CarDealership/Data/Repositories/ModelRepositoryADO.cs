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
    public class ModelRepositoryADO : IModelRepository
    {
        public List<Model> Create(Model model)
        {
            model.ModelId = RetrieveAll().Max(c => c.ModelId) + 1;
            model.DateCreated = DateTime.Today;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "CreateModel"
                };

                cmd.Parameters.AddWithValue("@DateCreated", model.DateCreated.ToString());
                cmd.Parameters.AddWithValue("@MakeId", model.MakeId);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@UserId", "76c17ab7-e079-42b4-83ba-72d39154477c"); //Temporary
                cmd.Parameters.AddWithValue("@ModelYear", model.ModelYear);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            List<Model> list = RetrieveAll();
            return list;
        }

        public List<Model> RetrieveAll()
        {
            List<Model> list = new List<Model>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "RetrieveAllModels"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model
                        {
                            DateCreated = DateTime.Parse(dr["DateCreated"].ToString()),
                            MakeId = int.Parse(dr["MakeId"].ToString()),
                            ModelId = int.Parse(dr["ModelId"].ToString()),
                            ModelName = dr["ModelName"].ToString(),
                            UserId = dr["UserId"].ToString(),
                            ModelYear = int.Parse(dr["ModelYear"].ToString()),
                        };

                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }

        public Model RetrieveOne(int id)
        {
            Model model = new Model();
            foreach (var item in RetrieveAll())
            {
                if (item.MakeId == id)
                {
                    model = item;
                    break;
                }
            }
            return model;
        }
    }
}