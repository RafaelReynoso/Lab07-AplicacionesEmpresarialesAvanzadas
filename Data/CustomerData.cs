using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Data
{
    public class CustomerData
    {
        public string connectionString = "Data Source=LAB1504-24\\SQLEXPRESS;Initial Catalog=lab08;User Id=reynoso;Password=123";
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("USP_ObtenerClientes", connection);
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

        public void Insert(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand("USP_InsertarCliente", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", customer.name);
                command.Parameters.AddWithValue("@Address", customer.address);
                command.Parameters.AddWithValue("@Phone", customer.phone);
                
                command.ExecuteNonQuery();
            }
        }



        public void Update()
        {
            
        }

        public void Delete(string customerName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("USP_EliminarCliente", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", customerName);

                command.ExecuteNonQuery();
            }
        }

    }
}
