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
            string username, password;
            Console.WriteLine("Enter UserName: ");
            username=Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            password=Console.ReadLine();
            /*
             * if id exists verify and proceed to show options otherwise redirect to create new userid
             */
            bool valid = ValidateCustomer(username, password);
            if (!valid)
            {
                Console.WriteLine("\nYou do not have an account with this credentials.\nDo you want to create a new account?");
                string ans=Console.ReadLine();
                if (ans == "y" || ans == "yes" || ans=="Yes" || ans=="YES")
                {
                    CreateNewCustomer(username, password);
                }
                else
                {
                    Console.WriteLine("Invalid choices. Program exited");
                    return;
                }
            }
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
                        Console.WriteLine("Invalid coice");
                        break;
                }

            } while (choice != 0);
        }

        private static void Logout()
        {
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
            Console.WriteLine("\nNew customer acccount created");
        }

        private static bool ValidateCustomer(string userid, string password)
        {
            return false;
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
