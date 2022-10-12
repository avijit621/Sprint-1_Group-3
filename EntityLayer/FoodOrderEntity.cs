using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Customer
    {
        public int CustID { get; set; }
        public string? Name { get; set; }    
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string? Email { get;set;}
        public char? Gender { get; set; }    
        public string? Address { get;set;}
        public string? City { get;set;}
        public string? Pincode { get;set;}
    }
    public class Orders
    {
        public int OrderID { get; set; }
        public int CustID { get; set; } 
        public string Address { get; set; } 
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

    }
    public class OrderDeatils
    {
        public int OrderID {get;set; }
        public int FoodID { get;set;}
        public float UnitPrice { get; set; }=0;
        public int Quantity { get; set; }=1;
        public float Discount { get; set; }
    }
    public class PaymentDetails
    {
        public int PaymentID { get; set; }
        public int OrderId { get; set; }
        public string PayType { get; set; }
        public string cardNo { get; set; }
        public int CVV { get;set;}
        public string UpiId { get;set;}
        public float Amount { get; set; }=0;
        public string PayStatus { get;set;}
       
    }
    public class FoodItem
    {
        public int FoodID { get;set;}
        public string Name { get; set; }
        public float Price { get;set;}
        public string Category { get;set;}
        public string Restaurant { get;set;}
        public string Status { get;set;}
        public string Type { get;set;}


    }
}
