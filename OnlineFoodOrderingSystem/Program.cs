using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Enter UserID: ");
            username=Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            password=Console.ReadLine();
            /*
             * if id exists verify and proceed to show options otherwise redirect to create new userid
             */
            bool valid = ValidateCustomer(username, password);
            if (!valid)
            {
                Console.WriteLine("Do you want to create a new account?");
                string ans=Console.ReadLine();
                if (ans == "y" || ans == "yes" || ans=="Yes" || ans=="YES")
                {
                    CreateNewCustomer(username, password);
                }
                else
                {
                    Console.WriteLine("Invalid choices.Program exited");
                    return;
                }
            }
            /*
             * show customer the choice of actions and ask to select one action
             */
            int choice;
            do
            {
                DisplayMenu();
                choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {

                }

            } while (choice != 0);
        }

        private static void CreateNewCustomer(string username, string password)
        {
            Console.WriteLine("New customer acccount created");
        }

        private static bool ValidateCustomer(string userid, string password)
        {
            return false;
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Choose the any functionality specified below: ");
            Console.WriteLine("1.Show Food Menu");
            Console.WriteLine("2.");
        }
    }
}
