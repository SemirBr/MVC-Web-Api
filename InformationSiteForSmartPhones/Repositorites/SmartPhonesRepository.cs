using InformationSiteForSmartPhones.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InformationSiteForSmartPhones.Repositorites
{
    public class SmartPhonesRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        public SmartPhones GetById(int id)
        {
            SmartPhones item = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
              SELECT                  
                    Id,
                    IdToSmartPhone,
                    Manufacturer,
                    Model,
                    InteralMemory,
                    RamMemory,
                    ResolutionOfCamera
             FROM
                    SmartPhones
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
                    item = new SmartPhones();
                    item.Id = Convert.ToInt32(reader["Id"]);
                    item.Manufacturer = Convert.ToString(reader["Manufacturer"]);
                    item.Model = Convert.ToString(reader["Model"]);
                    item.InteralMemory = Convert.ToString(reader["InteralMemory"]);
                    item.RamMemory = Convert.ToString(reader["RamMemory"]);
                    item.ResolutionOfCamera = Convert.ToString(reader["ResolutionOfCamera"]);
                }

            }
            finally
            {
                reader.Close();
                conn.Close();
            }

            return item;
        }
        public List<SmartPhones> GetAll(int IdToSmartPhone)
        {
            List<SmartPhones> item = new List<SmartPhones>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                SELECT                  
                    Id,
                    IdToSmartPhone,
                    Manufacturer,
                    Model,
                    InteralMemory,
                    RamMemory,
                    ResolutionOfCamera
             FROM
                    SmartPhones
             WHERE
                    IdToSmartPhone = @IdToSmartPhone";

            cmd.Parameters.AddWithValue("@IdToSmartPhone", IdToSmartPhone);

            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SmartPhones items = new SmartPhones();
                    items.Id = Convert.ToInt32(reader["Id"]);
                    items.IdToSmartPhone = Convert.ToInt32(reader["IdToSmartPhone"]);
                    items.Manufacturer = Convert.ToString(reader["Manufacturer"]);
                    items.Model = Convert.ToString(reader["Model"]);
                    items.InteralMemory = Convert.ToString(reader["InteralMemory"]);
                    items.RamMemory = Convert.ToString(reader["RamMemory"]);
                    items.ResolutionOfCamera = Convert.ToString(reader["ResolutionOfCamera"]);
                    item.Add(items);
                }
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return item;
        }


        public void Insert(SmartPhones item)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                INSERT INTO SmartPhones (
                    Manufacturer,
                    Model,
                    InteralMemory,
                    RamMemory,
                    ResolutionOfCamera
                )
                VALUES (
                    @Manufacturer,
                    @Model,
                    @InteralMemory,
                    @RamMemory,
                    @ResolutionOfCamera
                )";
            cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
            cmd.Parameters.AddWithValue("@Model", item.Model);
            cmd.Parameters.AddWithValue("@InteralMemory", item.InteralMemory);
            cmd.Parameters.AddWithValue("@RamMemory", item.RamMemory);
            cmd.Parameters.AddWithValue("@ResolutionOfCamera", item.ResolutionOfCamera);
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
        public void Update(SmartPhones item)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                UPDATE SmartPhones SET
                    Manufacturer = @Manufacturer,
                    Model = @Model,
                    InteralMemory = @InteralMemory,
                    RamMemory = @RamMemory,
                    ResolutionOfCamera = @ResolutionOfCamera
                WHERE
                    Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
            cmd.Parameters.AddWithValue("@Model", item.Model);
            cmd.Parameters.AddWithValue("@InteralMemory", item.InteralMemory);
            cmd.Parameters.AddWithValue("@RamMemory", item.RamMemory);
            cmd.Parameters.AddWithValue("@ResolutionOfCamera", item.ResolutionOfCamera);
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
            DELETE 
            FROM 
            SmartPhones
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
        public void Save(SmartPhones item)
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

    }
}