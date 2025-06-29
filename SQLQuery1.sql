Create table Phones 
( ID int identity(1,1),
ProID int primary key,
Procat varchar(50),
Proname varchar(50),
Proquantity varchar(50) )

Create table Audit 
( ID int identity(1,1),
UserName nvarchar(50),
Password nvarchar(50),
UserType nvarchar(50),
Activity nvarchar(50),
Logindate date,
Logintime time )

Create table Buy
(ID int identity(1,1),
PurID int primary key,
EID int,
SID int,
PayID int,
PayType varchar(50),
ProID int,
ProCat varchar(50),
ProName varchar(50),
ProPrice varchar(50),
ProQuantity varchar(50),
Units varchar(50),
TPrice varchar(50),
PurDate Date,
PurTime Time,)

Create table Laptops           
(ID int identity(1,1),
ProID int primary key,
ProCat varchar(50),
ProName varchar(50),
ProQuantity nvarchar(50) )

Create table Supplier
( ID int identity(1,1),
SID int primary key,
SName varchar(50),
SAddress varchar(50),
SphoneNo varchar(50),
SEmailID varchar(50) )


Create table Employee 
( ID int identity(1,1),
EID int primary key,
EName varchar(50),
EPhone varchar(50),
EEmailID varchar(50),
UserName varchar(50),
Password varchar(50),
Retype varchar(50), 
UserType varchar(50))

Create table Supplier2
( ID int identity(1,1),
PayID int primary key,
PurID int,
SID int,
PID int,
PayType varchar(50),
Amt varchar(50),
PayDate Date,
PayTime Time, )

Create table Company2
( ID int identity(1,1),
PayID int primary key,
SalID int,
CID int,
PID int,
PayType varchar(50),
Amt varchar(50),
PayDate Date,
PayTime Time, )


Create table Sales 
( ID int identity(1,1),
SalID int primary key,
EID int,
CID int,
PayID int,
PayType varchar(50),
ProID int,
ProCat varchar(50),
ProName varchar(50),
ProPrice varchar(50),
ProQuantity varchar(50),
Units varchar(50),
DisPer varchar(50),
DisAmt varchar(50),
TPrice varchar(50),
RCash varchar(50),
Change varchar(50)
SalDate date,
SalTime time,)

Create table Company 
( ID int identity(1,1),
CID int primary key,
CName varchar(50),
CAddress varchar(50),
CPhoneNo varchar(50),
CEmail varchar(50) )

