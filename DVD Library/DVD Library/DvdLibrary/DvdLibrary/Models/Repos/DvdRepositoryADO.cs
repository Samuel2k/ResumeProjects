using DvdLibrary.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models.Repos
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public List<Dvd> Create(Dvd dvd)
        {
            List<Dvd> list = RetrieveAll();
            dvd.DvdId = list.Max(c => c.DvdId) + 1;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CreateNew";

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@RealeaseYear", dvd.RealeaseYear);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            list.Add(dvd);
            return list;
        }

        public List<Dvd> Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DeleteFrom" ;

                cmd.Parameters.AddWithValue("@DvdId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            List<Dvd> list = RetrieveAll();
            return list;
        }

        public List<Dvd> RetrieveAll()
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SelectAll";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.DvdId = int.Parse(dr["DvdId"].ToString());
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = int.Parse(dr["RealeaseYear"].ToString());

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public Dvd RetrieveById(int id)
        {
            List<Dvd> list = RetrieveAll();
            Dvd newDvd = new Dvd();

            foreach (Dvd dvd in list)
            {
                if (id == dvd.DvdId)
                {
                    newDvd = dvd;
                    break;
                }
            }
            return newDvd;
        }

        public List<Dvd> RetrieveByName(string name)
        {
            List<Dvd> list = RetrieveAll();
            List<Dvd> newList = new List<Dvd>();
            foreach (Dvd dvd in list)
            {
                if (dvd.Director.Contains(name))
                {
                    newList.Add(dvd);
                }
            }
            return newList;
        }

        public List<Dvd> RetrieveByRating(string rating)
        {
            List<Dvd> list = RetrieveAll();
            List<Dvd> newList = new List<Dvd>();
            foreach (Dvd dvd in list)
            {
                if (dvd.Rating.Contains(rating))
                {
                    newList.Add(dvd);
                }
            }
            return newList;
        }

        public List<Dvd> RetrieveByTitle(string title)
        {
            List<Dvd> list = RetrieveAll();
            List<Dvd> newList = new List<Dvd>();
            foreach (Dvd dvd in list)
            {
                if (dvd.Title.Contains(title))
                {
                    newList.Add(dvd);
                }
            }
            return newList;
        }

        public List<Dvd> RetrieveByYear(int year)
        {
            List<Dvd> list = RetrieveAll();
            List<Dvd> newList = new List<Dvd>();
            foreach (Dvd dvd in list)
            {
                if (dvd.RealeaseYear == year)
                {
                    newList.Add(dvd);
                }
            }
            return newList;
        }

        public List<Dvd> Update(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateThis";

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@RealeaseYear", dvd.RealeaseYear);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            List<Dvd> list = RetrieveAll();
            return list;
        }
    }
}