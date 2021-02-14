create Table Brands(
Id int identity(1,1) primary key,
Name varchar(255)
)

create Table Colors(
Id int identity(1,1) primary key,
Name varchar(255)
)

CREATE TABLE Cars (
Id int identity(1,1) primary key,
BrandId int,
ColorId int,
ModelYear varchar(255),
DailyPrice money,
Description varchar(255),

Foreign key (BrandId) REFERENCES Brands(Id),
Foreign key (ColorId) REFERENCES Colors(Id)
)

Create TAble Colors (
Id int identity(1,1) primary key,
Name varchar(255)
)

create table Users (
Id int identity(1,1) primary key,
FirstName varchar(255),
LastName varchar(255),
Email varchar(255),
Password varchar(255)
)

create table Customers (
Id int identity(1,1) primary key,
UserId int ,
CompanyName varchar(255),

Foreign key (UserId) REFERENCES Users(Id),
)

create table Rentals (
Id int identity(1,1) primary key,
CarId int,
CustomerId int,
RentDate Date,
ReturnDate Date,

Foreign key (CarId) References Cars(Id),
Foreign key (CustomerId) References Customers(Id)
)