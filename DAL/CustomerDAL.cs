﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oslomet_film.Model;
using System.Diagnostics;
using System.Security.Cryptography;


namespace oslomet_film.DAL
{
    public class CustomerDAL
    {
        public List<Customer> getAll()
        {
            var db = new DB();
            List<Customer> allCutsomers = db.Customers.Select(c => new Customer()
            {
                ID = c.ID,
                Username = c.Username,
                Name = c.Name,
                Surname = c.Surname,
                Phone = c.Phone,
                Email = c.Email,
                Password = null
            }
            ).ToList();
            return allCutsomers;
            
        }

        public bool addCustomer(Customer customerModel)
        {
            var db = new DB();
            byte[] salt = createSalt();
            byte[] hash = createHash(customerModel.Password, salt);
            bool test = checkUser(customerModel.Username, customerModel.Email, customerModel.Phone);

            var newCustomer = new DBCustomer()
            {
                Username = customerModel.Username,
                Name = customerModel.Username,
                Surname = customerModel.Surname,
                Phone = customerModel.Phone,
                Email = customerModel.Email,
                Password = hash,
                Salt = salt
            };
            
            try
            {
                //var checkUser = db.Customers.Where(user => user.Username == customerModel.Username || user.Email == customerModel.Email || user.Phone == customerModel.Phone).FirstOrDefault();
                if (test == true)
                {
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private static bool checkUser(String inputUsername, String inputEmail, String inputPhone)
        {
            var db = new DB();
            var checkUser = db.Customers.Where(user => user.Username == inputUsername || user.Email == inputEmail || user.Phone == inputPhone).FirstOrDefault();
            if(checkUser == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static byte[] createHash(String inputPassword, byte[] inputSalt)
        {
            const int keyLength = 24;
            var pbkd2 = new Rfc2898DeriveBytes(inputPassword, inputSalt, 1000);
            return pbkd2.GetBytes(keyLength);
        } 

        public static byte[] createSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }


        public bool login(Customer loginModel)
        {
            var db = new DB();

            var userData = db.Customers.Where(user => user.Username == loginModel.Username).FirstOrDefault();
            if(userData == null)
            {
                return false;
            } else
            {
                byte[] testPassword = createHash(loginModel.Password, userData.Salt);
                bool passwordCorrect = userData.Password.SequenceEqual(testPassword);
                return passwordCorrect;
            }
            
        }

        public bool editUser(int id, Customer editModel)
        {
            var db = new DB();
            byte[] salt = createSalt();
            byte[] hash = createHash(editModel.Password, salt);
            bool test = checkUser(editModel.Username, editModel.Email, editModel.Phone);

            try
            {
                DBCustomer editCustomer = db.Customers.Find(id);
                editCustomer.Username = editModel.Username;
                editCustomer.Name = editModel.Name;
                editCustomer.Surname = editModel.Surname;
                editCustomer.Phone = editModel.Phone;
                editCustomer.Email = editModel.Email;
                editCustomer.Password = hash;
                editCustomer.Salt = salt;

                //db.Entry(editModel).State = System.Data.Entity.EntityState.Modified;

                //if(test == true)
               // {
                    db.SaveChanges();
                    return true;
               // }
               // else
               // {
                //}
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
                DBCustomer deleteUser = db.Customers.Find(id);
                db.Customers.Remove(deleteUser);
                db.SaveChanges();
                return true;
            } catch
            {
                return false;
            }
        }



        public Customer fetchCustomer (int id)
        {
            var db = new DB();
            var customer = db.Customers.Find(id);

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
                };
                return customerDetails;
            }
        }
    } 
}
