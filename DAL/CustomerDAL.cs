using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oslomet_film.Model;

namespace oslomet_film.DAL
{
    public class CustomerDAL
    {
        public List<Customer> getAll()
        {
            var db = new DB();
            List<Customer> customers = db.Customer.ToList();
            return customers;
        }

        public bool addCustomer(Customer customerModel)
        {
            var db = new DB();
            try
            {
                db.Customer.Add(customerModel);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool login(Customer loginModel)
        {
            var db = new DB();

            var userData = db.Customer.Where(user => user.Username == loginModel.Username && user.Password == loginModel.Password).FirstOrDefault();
            Console.WriteLine(userData.ToString());
            //Customer userData = db.Customer.FirstOrDefault(user => user.Username == loginModel.Username);
            if(userData == null)
            {
                return false;
            } else
            {
                return true;
            }
            
        }

        public bool editUser(int id, Customer editModel)
        {
            var db = new DB();

            try
            {
                Customer editCustomer = db.Customer.Find(id);
                db.Entry(editModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch
            {
                return false;
            }
        }

        public bool deleteUser(int id)
        {
            var db = new DB();
            try
            {
                Customer deleteCustomer = db.Customer.Find(id);
                db.Customer.Remove(deleteCustomer);
                db.SaveChanges();
                return true;
            } catch (Exception feil)
            {
                return false;
            }
        }

        public Customer fetchCustomer (int id)
        {
            var db = new DB();
            var customer = db.Customer.Find(id);

            if (customer == null)
            {
                return null;
            } else
            {
                var customerDetails = new Customer()
                {
                    ID = customer.ID,
                    Username = customer.Username,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    Password = customer.Password
                };
                return customerDetails;
            }
        }

    }
}
