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
            string userid, password;
            Console.WriteLine("Enter UserID: ");
            userid=Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            password=Console.ReadLine();
            /*
             * if id exists verify and proceed to show options otherwise redirect to create new userid
             */
            int choice=1;
            do
            {
                Console.WriteLine();

            } while (choice != 0);
        }
    }
}
