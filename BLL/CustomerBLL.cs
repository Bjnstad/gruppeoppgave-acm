using System;
using System.Collections.Generic;
using oslomet_film.Model;
using oslomet_film.DAL;

namespace oslomet_film.BLL
{
    public class CustomerBLL
    {
        public List<Customer> getAll()
        {
            var CustomerDAL = new CustomerDAL();
            List<Customer> allCustomers = CustomerDAL.getAll();
            return allCustomers;
        }
        public bool addCustomer(Customer customerModel)
        {
            var CustomerDAL = new CustomerDAL();
            return CustomerDAL.addCustomer(customerModel);
        }

        public bool login(Customer loginModel)
        {
            var CustomerDAL = new CustomerDAL();
            return CustomerDAL.login(loginModel);
        }
        public bool editUser(int id, Customer editModel)
        {
            var CustomerDAL = new CustomerDAL();
            return CustomerDAL.editUser(id, editModel);
        }

        public bool EditPassword(int id, Customer editModel)
        {
            var CustomerDAL = new CustomerDAL();
            return CustomerDAL.editUser(id, editModel);
        }
        public bool deleteUser(int id)
        {
            var CustomerDAL = new CustomerDAL();
            return CustomerDAL.deleteUser(id);
        }
        public Customer fetchCustomer(int id)
        {
            var CustomerDAL = new CustomerDAL();
            return CustomerDAL.fetchCustomer(id);
        }

        public Customer fetchCustomerByUsername(String username)
        {
            var CustomerDAL = new CustomerDAL();
            return CustomerDAL.fetchCustomerByUsername(username);
        }
    }
}
