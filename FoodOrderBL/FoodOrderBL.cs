using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DALLayer;

namespace BLLayer
{
    public class FoodOrderBL
    {
        /*
         * Customer Functionalities Business Logic
         */
        public Customers FindCustomers(string username)
        {
            Customers customer = new Customers();
            try
            {
                // write logic here

                //-----------------
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return customer;
        }
        public bool NewCustomerBL(Customers customer)
        {
            bool newcustadded = false;
            try
            {
                // write logic here

                //-----------------
                newcustadded = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return newcustadded;
        }
        public bool UpdateDetailsBL(Customers customer)
        {
            bool updated = false;
            try
            {
                // write logic here

                //-----------------
                updated = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return updated;
        }
        public bool ValidateExistingBL(Customers customer)
        {
            bool validuser = false;
            try
            {
                //write logic here

                //----------------
                validuser = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return validuser;
        }
        public IList<OrderDetails> OrderDetailsBL(Customers customer)
        {
            IList<OrderDetails> list = new List<OrderDetails>();
            try
            {
                // Write logic here

                //------------------
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IList<Payments> PaymentDetailsBL(Customers customer)
        {
            IList<Payments> list = new List<Payments>();
            try
            {
                // Write logic here

                //------------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public string TrackOrderBL(Customers customer)
        {
            string status="";
            try
            {
                // write logic here

                //-----------------
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return status;
        }
        public bool IsReadyForPayment(Customers customer)
        {
            bool ready = false;
            try
            {
                //write logic here

                //----------------
                ready = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ready;
        }
        public bool MakePaymentBL(Payments payments)
        {
            bool success = false;
            try
            {
                //write logic here

                //----------------
                success = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return success;
        }
        public IList<FoodItems> ShowAllFoodItemsBL()
        {
            IList<FoodItems> list = new List<FoodItems>();
            try
            {
                //write logic here

                //----------------
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IList<FoodItems> FilteredFoodItemsBL(FoodItems foodItems,string type)
        {
            IList<FoodItems> list = new List<FoodItems>();
            try
            {
                //write logic here

                //----------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IList<FoodItems> AddToOrderBL(OrderDetails orderDetails)
        {
            IList<FoodItems> list = new List<FoodItems>();
            try
            {
                //write logic here

                //-----------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public bool IsAddressNullBL(Customers customer)
        {
            bool addressnull = false;
            try
            {
                //write logic here

                //----------------
                addressnull = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return addressnull;
        }
        public bool EditAddressBL(Customers customer,string address)
        {
            bool addressedited = false;
            try
            {
                //write logic here

                //----------------
                addressedited = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return addressedited;
        }
        public void PlaceOrderBL(Customers customer,OrderDetails orderDetails,IList<FoodItems> foodItemsList)
        {
            try
            {

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool ModifyOrderBL(OrderDetails orderDetails)
        {
            bool modified = false;
            try
            {
                //write logic here

                //----------------
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return modified;
        }
        public bool CancelOrderBL(OrderDetails orderDetails)
        {
            bool cancel = false;
            try
            {
                //write logic here

                //---------------
                cancel = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return cancel;
        }
        public bool ValidateCustomersBL(Customers customer)
        {
            bool valid = true;
            try
            {
                //write code here

                //---------------
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return valid;
        }
        public bool ValidatePaymentDetailsBL(Payments payments)
        {
            bool pay = true;
            try
            {
                //write code here

                //---------------
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return pay;
        }
        public bool ValidateFoodItemsBL(FoodItems foodItems)
        {
            bool food = true;
            try
            {
                //write code here

                //---------------
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return food;
        }
        public bool ValidateOrderDetailsBL(OrderDetails orderDetails)
        {
            bool order = true;
            try
            {
                //write code here

                //---------------
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return order;
        }
        public bool ValidateOrdersBL(Orders orders)
        {
            bool order = true;
            try
            {
                //write code here

                //---------------
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return order;
        }
        /*
         * Admin Fucntionalities Business Logic
         */
    }
}
