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
    public class ContactRepositoryADO : IContactRepository
    {
        public List<Contact> RetrieveAll()
        {
            List<Contact> list = new List<Contact>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "RetrieveAllContacts"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contact currentRow = new Contact
                        {
                            ContactId = int.Parse(dr["ContactId"].ToString()),
                            Email = dr["Email"].ToString(),
                            Message = dr["Message"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            Name =dr["Name"].ToString()
                        };

                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }
        public List<Contact> Create(Contact contact)
        {
            
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "CreateContact"
                };

                cmd.Parameters.AddWithValue("@Message", contact.Message);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RetrieveAll();
        }
    }
}