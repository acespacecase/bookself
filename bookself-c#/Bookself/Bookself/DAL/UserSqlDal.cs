using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookself.Models;
using System.Data.SqlClient;
using Dapper;

namespace Bookself.DAL
{
    public class UserSqlDal : IUserSource
    {
        private const string SQL_GetOneUser = "SELECT * FROM bookself_user WHERE id = @id;";
        readonly string connectionString;

        public UserSqlDal(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public User GetUser(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    User user = conn.QueryFirstOrDefault<User>(SQL_GetOneUser, new { id = id });
                    return user;
                }
            }
            catch
            {
                throw;
            }
            
        }

        public List<User> GetUsers()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    List<User> users = conn.Query<User>("SELECT * FROM bookself_users;").ToList();
                    return users;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}