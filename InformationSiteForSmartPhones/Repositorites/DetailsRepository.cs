using InformationSiteForSmartPhones.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InformationSiteForSmartPhones.Repositorites
{
    public class DetailsRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        public List<SmartPhonesDetails> GetAll(int PhoneId)
        {
            List<SmartPhonesDetails> item = new List<SmartPhonesDetails>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                SELECT                  
                    Id,
                    PhoneId,
                    NameOfSmartPhone,
                    Details
                    
             FROM
                    DetailedInfromarionAboutSmartPhones
             WHERE
                    PhoneId = @PhoneId";

            cmd.Parameters.AddWithValue("@PhoneId", PhoneId);

            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SmartPhonesDetails items = new SmartPhonesDetails();
                    items.Id = Convert.ToInt32(reader["Id"]);
                    items.PhoneId = Convert.ToInt32(reader["PhoneId"]);
                    items.NameOfSmartPhone = Convert.ToString(reader["NameOfSmartPhone"]);
                    items.Details= Convert.ToString(reader["Details"]);
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
    }
}