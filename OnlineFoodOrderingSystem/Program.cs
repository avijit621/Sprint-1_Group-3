using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                    if (string.Equals(ans, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(ans, "yes", StringComparison.OrdinalIgnoreCase))
                    {
                        CreateNewCustomer(username, password);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choices. Program exited");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nLogged In suucessfully.");
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
            #region Display Customer Choices
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
                        PlaceOrder(username);break;
                    case 3:
                        ModifyOrder(username);break;
                    case 4:
                        TrackOrder(username);break;
                    case 5:
                        MakePayment(username);break;
                    case 6:
                        ShowOrderDetails(username);break;
                    case 7:
                        UpdateUserDetails(username);break;
                    case 8:
                        Logout();
                        choice = 0; break;
                    default:
                        Console.WriteLine("\nInvalid coice");
                        break;
                }

            } while (choice != 0);
            #endregion
        }
        /*
         * Customer Choice Methods
         */
        #region Customer Functionalities

        private static void Logout()
        {
            Console.WriteLine("Do you really want to Log Out?");
            string ans = Console.ReadLine();
            if (string.Equals(ans, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(ans, "yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("\nYou have been successfully logged out.");
                return;
            }
        }

        private static void MakePayment(string username)
        {
            FoodOrderBL foodOrderBL = new FoodOrderBL();
            Customers customer = foodOrderBL.FindCustomers(username);
            Payments payments = new Payments();
            payments.OrderId =customer.Orders.OrderID;
            bool ready = foodOrderBL.IsReadyForPayment(customer);
            if (ready)
            {
                try
                {
                    bool success = false;
                    Console.WriteLine("Choose Payment Mode:\n\t1. Card\n\t2. UPI");
                    int choice=Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Card Number: ");
                            payments.cardNo=Console.ReadLine();
                            Console.WriteLine("Enter CVV: ");
                            payments.CVV=Convert.ToInt32(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Enter UPI Id: ");
                            payments.UpiId=Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice.");
                            break;
                    }
                    Console.WriteLine("Are you sure to proceed?");
                    string ans=Console.ReadLine();
                    if (string.Equals(ans, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(ans, "yes", StringComparison.OrdinalIgnoreCase))
                    {
                        success = foodOrderBL.MakePaymentBL(payments);
                    }
                    if (success)
                    {
                        Console.WriteLine("Payment Successful. Order Placed.");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }

        private static void ShowOrderDetails(string username)
        {
            FoodOrderBL foodOrderBL = new FoodOrderBL();
            Customers customer = new Customers();
            customer =foodOrderBL.FindCustomers(username);
            IList<OrderDetails> orderDetails = new List<OrderDetails>();
            IList<Payments> paymentDetails = new List<Payments>(); 
            try
            {
                orderDetails = foodOrderBL.OrderDetailsBL(customer);
                Console.WriteLine($"{"OrderDate",-12}{"OrderId",-10}{"FoodItem",-20}{"Quantity",-10}{"Amount",-10}");
                foreach (var data in orderDetails)                      // display order details
                {
                    Console.WriteLine($"{data.Orders.OrderDate,-12}{data.OrderID,-10}{data.FoodItem.Name,-20}{data.Quantity,-10}{data.Quantity*data.UnitPrice*(1-data.Discount/100),-10}");
                }
                Console.WriteLine("Do you want to see the payment details?");
                string ans=Console.ReadLine();
                if(string.Equals(ans, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(ans, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    paymentDetails=foodOrderBL.PaymentDetailsBL(customer);
                    Console.WriteLine($"{"OrderDate",-12}{"OrderId",-10}{"TransactionId",-10}{"PayMode",-10}{"Card",-12}{"UPI",-12}{"Amount",-10}");
                    foreach (var data in paymentDetails)                    // display payment details
                    {
                        Console.WriteLine($"{data.Orders.OrderDate,-12}{data.OrderId,-10}{data.PaymentID,-10}{data.PayType,-10}{data.cardNo,-12}{data.UpiId,-12}{data.Amount,-10}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void TrackOrder(string username)
        {
            Customers customer = new Customers();
            customer.UserName = username;
            FoodOrderBL foodOrderBL = new FoodOrderBL();
            try
            {
                string status = $"{foodOrderBL.TrackOrderBL(customer)}";
                Console.WriteLine($"\n{status}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ModifyOrder(string username)
        {
            FoodOrderBL foodOrderBL = new FoodOrderBL();
            Customers customer=foodOrderBL.FindCustomers(username);
            OrderDetails orderDetails = new OrderDetails();
            try
            {
                Console.WriteLine("Do you want to modify address?");
                string ans=Console.ReadLine();
                if (string.Equals(ans, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(ans, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter Address: ");
                    string addr=Console.ReadLine();
                    bool edited=foodOrderBL.EditAddressBL(customer, addr);
                    if (edited)
                    {
                        Console.WriteLine("Address updated");
                    }
                }
                Console.WriteLine("Do you want to modify fooditems?");
                ans = Console.ReadLine();
                if (string.Equals(ans, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(ans, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter the foodItem ID: ");
                    orderDetails.FoodID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Quantity: ");
                    orderDetails.Quantity=Convert.ToInt32(Console.ReadLine());
                    bool updated=foodOrderBL.ModifyOrderBL(orderDetails);
                    if (updated)
                    {
                        Console.WriteLine("Order updated");
                    }
                }
                Console.WriteLine("Do you want to cancel Order?");
                ans=Console.ReadLine();
                if (string.Equals(ans, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(ans, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    bool canceled = foodOrderBL.CancelOrderBL(orderDetails);
                    if (canceled)
                    {
                        Console.WriteLine("Order Cancelled....");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PlaceOrder(string username)
        {
            FoodOrderBL foodOrderBL=new FoodOrderBL();
            Customers customer=foodOrderBL.FindCustomers(username);
            OrderDetails orderDetails=new OrderDetails();
            IList<FoodItems> foodItemsList=new List<FoodItems>();
            try
            {
                Console.Clear();
                DisplayFoodMenu();
                int choice = 1;
                do
                {
                    Console.WriteLine("\n\nDo you want to add fooditem to order?\n\t1. Yes\n\t0. No");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nEnter FoodItem ID to add: ");
                    orderDetails.FoodID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter quantity of the above fooditem: ");
                    orderDetails.Quantity = Convert.ToInt32(Console.ReadLine());
                    foodItemsList=foodOrderBL.AddToOrderBL(orderDetails);
                } while (choice != 0);
                bool addressnull = foodOrderBL.IsAddressNullBL(customer);
                if (addressnull)
                {
                    Console.WriteLine("Enter Delivery Address:");
                    string address=Console.ReadLine();
                    bool addressupdated =foodOrderBL.EditAddressBL(customer, address);
                    if (addressupdated)
                    {
                        Console.WriteLine("Delivary Address Updated");
                    }
                }
                Console.WriteLine("Do you want to confirm the order and proceed to payment?");
                string ans=Console.ReadLine();
                if (string.Equals(ans, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(ans, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    foodOrderBL.PlaceOrderBL(customer,orderDetails,foodItemsList);
                    MakePayment(username);
                }
                else
                {
                    ModifyOrder(username);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DisplayFoodMenu()
        {
            FoodOrderBL foodOrderBL = new FoodOrderBL();
            FoodItems foodItems = new FoodItems();
            IList<FoodItems> foodItemsList = new List<FoodItems>();
            try
            {
                Console.Clear();
                foodItemsList=foodOrderBL.ShowAllFoodItemsBL();
                DisplayFoodItems(foodItemsList);
                Console.WriteLine("Choose Food Type:\n\t1. Veg\n\t2. Non-Veg\n\t3. Vegan");
                int choice1 = Convert.ToInt32(Console.ReadLine());
                string type = "";
                switch (choice1)
                {
                    case 1:
                        type = "Veg";
                        foodItemsList = foodOrderBL.FilteredFoodItemsBL(foodItems,type);
                        DisplayFoodItems(foodItemsList);
                        break;
                    case 2:
                        type = "Non-Veg";
                        foodItemsList = foodOrderBL.FilteredFoodItemsBL(foodItems,type);
                        DisplayFoodItems(foodItemsList);
                        break;
                    case 3:
                        type = "Vegan";
                        foodItemsList = foodOrderBL.FilteredFoodItemsBL(foodItems, type);
                        DisplayFoodItems(foodItemsList);
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DisplayFoodItems(IList<FoodItems> foodItemsList)
        {
            try
            {
                if(foodItemsList == null)
                {
                    throw new Exception($"No Food Items Available of such type");
                }
                Console.WriteLine($"{"FoodID",-10}{"FoodName",-20}{"FoodPrice",-8}{"Category",-10}{"Restaurant",-15}{"Type",-10}");
                foreach (var data in foodItemsList) 
                {
                    Console.WriteLine($"{data.FoodID,-10}{data.Name,-20}{data.Price,-8}{data.Category,-10}{data.Restaurant,-15}{data.Type,-10}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateUserDetails(string username)
        {
            Customers customer = new Customers();
            FoodOrderBL foodOrderBL = new FoodOrderBL();
            customer=foodOrderBL.FindCustomers(username);
            try
            {
                Console.WriteLine("\nYour customer acccount created");
                Console.WriteLine("\nEnter few details to complete your profile **** ");
                Console.WriteLine("\nEnter Your Name: ");
                customer.Name = Console.ReadLine();
                Console.WriteLine("Enter Mobile Number: ");
                customer.Mobile = Console.ReadLine();
                Console.WriteLine("Enter Email address: ");
                customer.Email = Console.ReadLine();
                Console.WriteLine("Enter Gender: ");
                customer.Gender = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter City: ");
                customer.City = Console.ReadLine();
                Console.WriteLine("Enter Pincode: ");
                customer.Pincode = Console.ReadLine();
                Console.WriteLine("Enter Food Delivery Address");
                customer.Address = Console.ReadLine();
                bool updated = foodOrderBL.UpdateDetailsBL(customer);
                if (updated)
                {
                    Console.Clear();
                    Console.WriteLine("Your profile is updated\n");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CreateNewCustomer(string username, string password)
        {
            Customers customer = new Customers();
            customer.UserName = username;
            customer.Password= password;
            FoodOrderBL foodOrderBL = new FoodOrderBL();
            try
            {
                bool newcustadded = foodOrderBL.NewCustomerBL(customer);
                if (newcustadded)
                {
                    UpdateUserDetails(username);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool ValidateExistingCustomer(string username, string password)
        {
            bool valid = false;
            try
            {
                Customers customer = new Customers();
                customer.UserName = username;
                customer.Password = password;
                FoodOrderBL foodOrderBL = new FoodOrderBL();
                valid = foodOrderBL.ValidateExistingBL(customer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return valid;
        }

        private static void DisplayChoice()
        {
            Console.WriteLine("\nPlease find the functionalities specified below: ");
            Console.WriteLine("1.Show Food Menu");
            Console.WriteLine("2.Place Order");
            Console.WriteLine("3.Modify Order");
            Console.WriteLine("4.Track Order");
            Console.WriteLine("5.Make Payment");
            Console.WriteLine("6.Show Order Details");
            Console.WriteLine("7.Update User Details");
            Console.WriteLine("8.Log out");
            Console.WriteLine("0.Exit");
            Console.WriteLine("Enter your choice:");
        }

        #endregion

        /*
         * Admin Choice Methods
         */
        #region Admin Functionalities


        #endregion
    }
}
