using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerBusiness
    {
        public List<Customer> GetCustomer()
        {
            List<Customer> customer = new List<Customer>();
            CustomerData data = new CustomerData();
            customer = data.GetCustomers();
            return customer;

        }
        public void InsertCustomer(Customer customer)
        {
            CustomerData data = new CustomerData();
            data.Insert(customer);
        }

        public void DeleteCustomer(string customerName)
        {
            CustomerData data = new CustomerData();
            data.Delete(customerName);
        }
    }
}
