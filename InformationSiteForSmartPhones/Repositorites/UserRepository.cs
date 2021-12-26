using InformationSiteForSmartPhones.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InformationSiteForSmartPhones.Repositorites
{
    public class UserRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        public User GetById(int id)
        {
            User item = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
              SELECT
                    Id,
                    Username,
                    Password,
                    FirstName,
                    LastName
             FROM
                    Users
            WHERE
                Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new User();
                    item.Id = Convert.ToInt32(reader["Id"]);
                    item.Username = Convert.ToString(reader["Username"]);
                    item.Password = Convert.ToString(reader["Password"]);
                    item.FirstName = Convert.ToString(reader["FirstName"]);
                    item.LastName = Convert.ToString(reader["LastName"]);
                }

            }
            finally
            {
                reader.Close();
                conn.Close();
            }

            return item;
        }

        public List<User> GetAll()
        {
            List<User> items = new List<User>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                SELECT                  
                    Id,
                    Username,
                    Password,
                    FirstName,
                    LastName
             FROM
                    Users

            ";
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User item = new User();
                    item.Id = Convert.ToInt32(reader["Id"]);
                    item.Username = Convert.ToString(reader["Username"]);
                    item.Password = Convert.ToString(reader["Password"]);
                    item.FirstName = Convert.ToString(reader["FirstName"]);
                    item.LastName = Convert.ToString(reader["LastName"]);
                    items.Add(item);
                }
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return items;
        }

        public void Insert(User item)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                INSERT INTO Users (
                    Username,
                    Password,
                    FirstName,
                    LastName
                )
                VALUES (
                    @Username,
                    @Password,
                    @FirstName,
                    @LastName
                )";
            cmd.Parameters.AddWithValue("@Username", item.Username);
            cmd.Parameters.AddWithValue("@Password", item.Password);
            cmd.Parameters.AddWithValue("@FirstName", item.FirstName);
            cmd.Parameters.AddWithValue("@Lastname", item.LastName);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }


        }
        public void Update(User item)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                UPDATE Users SET
                    Username = @Username,
                    Password  = @Password, 
                    FirstName = @FirstName,
                    LastName = @LastName
                WHERE
                    Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Username", item.Username);
            cmd.Parameters.AddWithValue("@Password", item.Password);
            cmd.Parameters.AddWithValue("@FirstName", item.FirstName);
            cmd.Parameters.AddWithValue("@LastName", item.LastName);
            cmd.Parameters.AddWithValue("@Id", item.Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }


        }



        public void Delete(int Id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
            DELETE FROM Users
            WHERE 
                Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }

        public void Save(User item)
        {
            if (item.Id > 0)
            {
                Update(item);
            }
            else
            {
                Insert(item);

            }

        }

        /*---------------------------------------*/

        public User GetUsernameAndPassword(string username, string password)
        {
            User item = null;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
            SELECT 
                Id,
                Username,
                Password,   
                FirstName,
                LastName
            FROM
                Users
            WHERE

            Username = @Username and Password = @Password

            ";

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    item = new User();
                    item.Id = Convert.ToInt32(reader["Id"]);
                    item.Username = Convert.ToString(reader["Username"]);
                    item.Password = Convert.ToString(reader["Password"]);
                    item.FirstName = Convert.ToString(reader["FirstName"]);
                    item.LastName = Convert.ToString(reader["LastName"]);
                }

            }
            finally
            {
                reader.Close();
                conn.Close();
            }


            return item;
        }
    }
}