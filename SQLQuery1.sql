--create  DATABASE TUserDB;

--CREATE TABLE TenantTable (
--    TenantID int IDENTITY(1,1) PRIMARY KEY,
--    TenantName varchar(30),
--    Emaill varchar(100),
--    Phone varchar(20),
--	CreationDate datetime
--);


--CREATE TABLE UserTable (
--    UserID int IDENTITY(1,1) PRIMARY KEY,
--	TenantID int FOREIGN KEY REFERENCES TenantTable(TenantID),
--    FirstName varchar(255),
--	LastName varchar(255),
--	Phone varchar(20),
--    Emaill varchar(100),
--	CreationDate datetime
--);