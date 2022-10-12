Go
-------Create Database----------------------------------------------------
Create Database FoodSystem;
GO
use FoodSystem;
GO
--------------------------------------Customers----------------------------------------
Create Table Customers(
CustID int Identity(1000,1) Not null Primary key,
Name Varchar(50) Null,
Username Varchar(50) Not Null Unique,
Mobile Varchar(15) Not null Unique,
Email Varchar(25) null, 
Gender Char(1) null,
Address varchar(50) null,
city Varchar(20) null,
Pincode Varchar(10) null,
);
Go
--------------------------------------------------------Orders------------------------------------------- 
Create Table Orders(
OrderID int Identity(2000,1) not null Primary key,
CustID int Foreign Key References Customers(CustID),
Address Varchar(50) not null,
Status Varchar(20) null,
OrderDate Date not null
);
--------------------------------------Food Items------------------------------------------
Create Table FoodItems(
FoodId int Identity(3000,1) not null primary key,
Name NVarchar(30) not null,
Details NVarchar(255) null,
Price Money not null default(0),
Category Varchar(100) null,
Restaurant Varchar(100) null,
Status Varchar(20) null,
Type Varchar(20) null
);
GO
------------------------------------Order Details---------------------------------------
Create Table OrderDetails(
OrderID int not null,
FoodID int not null,
UnitPrice Money not null CONSTRAINT
"Order_details_unitPrice" Default(0),
Quantity int not null  CONSTRAINT
"Order_details_qty" Default(1),
Discount float not null CONSTRAINT "Order_Details_Discount" DEFAULT (0),
Constraint "PK_Order_details" Primary Key
(OrderID,FoodID),
Constraint "FK_Order_details_Orders" Foreign key
(OrderId) references Orders(OrderID),
Constraint "FK_Order_details_FoodItems" Foreign Key (FoodId) references FoodItems(FoodID),
CONSTRAINT "CK_Quantity" CHECK (Quantity > 0),
CONSTRAINT "CK_UnitPrice" CHECK (UnitPrice >= 0)
);
----------------Payments Table----------------------------------------

Create Table Payments(
PaymentID int Identity(4000,1) not null Primary key,
OrderID int not null,
PayType Varchar(15) not null,
CardNo Varchar(30) null,
CVV int null,
UpiID Varchar(55) null,
Amount Money not null CONSTRAINT
"Payment_amount" Default(0),
PayStatus Varchar(10) null,
CONSTRAINT "Ck_Amount" CHECK (Amount >= 0)
);
Alter table Payments Add CONSTRAINT fk_Orders  Foreign key (OrderID) references Orders(OrderID); 



