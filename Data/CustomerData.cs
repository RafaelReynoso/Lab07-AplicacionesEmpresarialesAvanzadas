using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class CustomerData
    {
        public string connectionString = "Data Source=LAB1504-28\\SQLEXPRESS;Initial Catalog=lab07;User Id=reynoso;Password=123";
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("USP_GetAllCustomers", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.customer_id = Convert.ToInt32(reader["customer_id"]);
                        customer.name = reader["name"].ToString();
                        customer.address = reader["address"].ToString();
                        customer.phone = reader["phone"].ToString();
                        customer.active = Convert.ToBoolean(reader["active"]);

                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }

        public void Insert()
        {
            
        }

        public void Update()
        {
            
        }

        public void Delete()
        {
            
        }
    }
}
