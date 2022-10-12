using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using BLLayer;
using EntityLayer;

namespace OnlineFoodOrderingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * ask the user credential
             */
            #region Get credentials

            string username, password;
            Console.WriteLine("******* Welcome to the Food Ordering System *******");
            Console.WriteLine("\nEnter UserName: ");
            username=Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            password=Console.ReadLine();

            #endregion
            /*
             * if id exists verify and proceed to show options otherwise redirect to create new userid
             */
            #region Log In/ Create Account

            try
            {
                bool validcustomer = ValidateExistingCustomer(username, password);
                if (!validcustomer)
                {
                    Console.WriteLine("\nYou do not have an account with this credentials.\nDo you want to create a new account?");
                    string ans = Console.ReadLine();
                    if (ans == "y" || ans == "yes" || ans == "Yes" || ans == "YES")
                    {
                        CreateNewCustomer(username, password);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choices. Program exited");
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            #endregion
            /*
             * show customer the choice of actions and ask to select one action
             */
            int choice;
            do
            {
                DisplayChoice();
                choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        DisplayFoodMenu();break;
                    case 2:
                        PlaceOrder();break;
                    case 3:
                        ModifyOrder();break;
                    case 4:
                        TrackOrder();break;
                    case 5:
                        MakePayment();break;
                    case 6:
                        CheckPaymentStatus();break;
                    case 7:
                        UpdateUserDetails();break;
                    case 8:
                        Logout();
                        choice = 0; break;
                    default:
                        Console.WriteLine("\nInvalid coice");
                        break;
                }

            } while (choice != 0);
        }

        private static void Logout()
        {
            Console.Clear();
            Console.WriteLine("\nYou have been successfully logged out.");
            return;
        }

        private static void UpdateUserDetails()
        {
            throw new NotImplementedException();
        }

        private static void CheckPaymentStatus()
        {
            throw new NotImplementedException();
        }

        private static void MakePayment()
        {
            throw new NotImplementedException();
        }

        private static void TrackOrder()
        {
            throw new NotImplementedException();
        }

        private static void ModifyOrder()
        {
            throw new NotImplementedException();
        }

        private static void PlaceOrder()
        {
            throw new NotImplementedException();
        }

        private static void DisplayFoodMenu()
        {
            throw new NotImplementedException();
        }


        private static void CreateNewCustomer(string username, string password)
        {
            try
            {
                Customer customer = new Customer();
                FoodOrderBL foodOrderBL = new FoodOrderBL();
                bool newcustadded = foodOrderBL.NewCustomerBL(username, password);
                if (newcustadded)
                {
                    Console.WriteLine("\nYour customer acccount created");
                    Console.WriteLine("\nEnter few details to complete your profile**** ");
                    Console.WriteLine("\nEnter Your Name: ");
                    customer.Name = Console.ReadLine();
                    Console.WriteLine("Enter Mobile Number: ");
                    customer.Mobile=Console.ReadLine();
                    Console.WriteLine("Enter Email address: ");
                    customer.Email=Console.ReadLine();
                    Console.WriteLine("Enter Gender: ");
                    customer.Gender = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine("Enter City: ");
                    customer.City=Console.ReadLine();
                    Console.WriteLine("Enter Pincode: ");
                    customer.Pincode=Console.ReadLine();
                    Console.WriteLine("Enter Food Delivery Address");
                    customer.Address = Console.ReadLine();
                    bool updated = foodOrderBL.UpdateDetailsBL(customer);
                    if (updated)
                    {
                        Console.Clear();
                        Console.WriteLine("Your profile is updated\n");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool ValidateExistingCustomer(string userid, string password)
        {
            return true;
        }

        private static void DisplayChoice()
        {
            Console.WriteLine("\nPlease find the functionalities specified below: ");
            Console.WriteLine("1.Show Food Menu");
            Console.WriteLine("2.Place Order");
            Console.WriteLine("3.Modify Order");
            Console.WriteLine("4.Track Order");
            Console.WriteLine("5.Make Payment");
            Console.WriteLine("6.Payment Status");
            Console.WriteLine("7.Update User Details");
            Console.WriteLine("8.Log out");
            Console.WriteLine("0.Exit");
            Console.WriteLine("Enter your choice:");
        }
    }
}
