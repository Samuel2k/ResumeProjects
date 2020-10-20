using CarDealership.Models.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealership.Data.Repositories
{

    class UserRole
    {
        public string RoleId { get; set; }
        public string UserId { get; set; }
    }

    class Role
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class UserRepository
    {
        public List<User> RetrieveAll()
        {
            List<User> userList = new List<User>();
            List<Role> roleList = new List<Role>();
            List<UserRole> userRoleList = new List<UserRole>();


            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "RetrieveAllRoles"
                };

                //Roles
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        Role currentRow = new Role
                        {
                            RoleId = dr["Id"].ToString(),
                            RoleName = dr["Name"].ToString()
                        };

                        roleList.Add(currentRow);
                    }
                }
                conn.Close();

                cmd.CommandText = "RetrieveAllUserRoles";

                //UserRoles
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        UserRole currentRow = new UserRole
                        {
                            RoleId = dr["RoleId"].ToString(),
                            UserId = dr["UserId"].ToString()
                        };

                        userRoleList.Add(currentRow);
                    }
                }
                conn.Close();

                cmd.CommandText = "RetrieveAllUsers";
                
                //User
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        User currentRow = new User
                        {
                            Email = dr["Email"].ToString(),
                            //Role = dr["Role"].ToString(),
                            UserId = dr["Id"].ToString()
                        };

                        foreach (var userRole in userRoleList)
                        {
                            foreach (var role in roleList)
                            {
                                if (userRole.RoleId == role.RoleId && userRole.UserId == currentRow.UserId)
                                {
                                    currentRow.Role = role.RoleName;
                                    userList.Add(currentRow);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return userList;
        }
    }
}