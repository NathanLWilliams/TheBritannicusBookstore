/* SOME PRIMARY KEYS CHANGED TO INCLUDE IDENTITY CONSTRAINT, WHICH MAKES IT SO INSERTING NEW RECORDS AUTO-INCREMENTS THE FIELD */
/* CHANGED GENRE FIELD TO GENREID SO THAT THE NAME MATCHES WHAT IT REFERENCES */
/* changed maps, periodicals, books, itemDiscounts to reference items */
/* changed authorLast field to be after authorFirst in the books table */
/* changed transactions totalPrice to be a decimal matching currency field seen in items price */
/* removed default for customers phone number and changed datatype and length to match employee phone numbers */

/* LOOKUP TABLES */
CREATE TABLE [dbo].[genres]
(
	[genreID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [genreName] VARCHAR(25) NOT NULL
)
CREATE TABLE [dbo].[itemTypes]
(
	[itemTypeID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [itemTypeName] VARCHAR(10) NULL
)
CREATE TABLE [dbo].[tags]
(
	[tagID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [tagDescription] VARCHAR(15) NOT NULL
)
CREATE TABLE [dbo].[conditions]
(
	[conditionID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [conditionType] VARCHAR(15) NOT NULL
)
CREATE TABLE [dbo].[customerTypes]
(
	[customerTypeID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [customerTypeName] VARCHAR(10) NULL
)
CREATE TABLE [dbo].[employeePositions]
(
	[positionID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [positionName] VARCHAR(10) NULL
)

/* ITEMS */
CREATE TABLE [dbo].[items]
(
	[itemID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [itemTypeID] INT REFERENCES [itemTypes]([itemTypeID]) NOT NULL, 
    [price] DECIMAL(7, 2) NOT NULL, 
    [edition] TINYINT NOT NULL
)
CREATE TABLE [dbo].[maps]
(
	[mapID] INT REFERENCES [items]([itemID]) NOT NULL PRIMARY KEY,
    [publisher] VARCHAR(30) NOT NULL, 
    [location] VARCHAR(50) NOT NULL, 
    [year] SMALLINT NOT NULL
)
CREATE TABLE [dbo].[periodicals]
(
	[periodicalID] INT REFERENCES [items]([itemID]) NOT NULL PRIMARY KEY,
    [companyName] VARCHAR(30) NOT NULL, 
    [title] VARCHAR(50) NOT NULL, 
    [genreID] INT REFERENCES [genres]([genreID]) NOT NULL,
    [date] DATE NOT NULL
)
CREATE TABLE [dbo].[books]
(
	[bookID] INT REFERENCES [items]([itemID]) NOT NULL PRIMARY KEY,
    [title] VARCHAR(50) NOT NULL, 
    [genreID] INT REFERENCES [genres]([genreID]) NOT NULL, 
    [authorFirst] VARCHAR(25) NOT NULL, 
	[authorLast] VARCHAR(25) NOT NULL,
    [publisher] VARCHAR(30) NOT NULL, 
    [publishDate] DATE NOT NULL
)

/* OTHERS */
CREATE TABLE [dbo].[customers]
(
	[customerID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [customerTypeID] INT REFERENCES [customerTypes]([customerTypeID]) NOT NULL, 
    [firstName] VARCHAR(25) NULL, 
    [lastName] VARCHAR(25) NULL, 
    [phoneNumber] NVARCHAR(10) NULL
)
CREATE TABLE [dbo].[employees]
(
	[employeeID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [positionID] INT REFERENCES [employeePositions]([positionID]) NOT NULL, 
    [firstName] VARCHAR(25) NOT NULL, 
    [lastName] VARCHAR(25) NOT NULL, 
    [phoneNumber] NVARCHAR(10) NOT NULL
)
CREATE TABLE [dbo].[inventory]
(
	[itemID] INT REFERENCES [items]([itemID]) NOT NULL, 
    [conditionID] INT REFERENCES [conditions]([conditionID]) NOT NULL, 
    [quantity] INT NOT NULL,
	PRIMARY KEY ([itemID],[conditionID])
)
CREATE TABLE [dbo].[invoice]
(
    [invoiceID] INT NOT NULL IDENTITY PRIMARY KEY, 
    [customerID] INT REFERENCES [customers]([customerID]) NOT NULL, 
    [invoiceDate] DATE NOT NULL
)
CREATE TABLE [dbo].[itemDiscounts]
(
	[discountID] INT REFERENCES [items]([itemID]) NOT NULL PRIMARY KEY,
    [discountAmount] DECIMAL(7, 2) NOT NULL, 
    [startDate] DATE NOT NULL, 
    [endDate] DATE NOT NULL
)
CREATE TABLE [dbo].[itemTags]
(
	[itemID] INT REFERENCES [items]([itemID]) NOT NULL, 
    [tagID] INT REFERENCES [tags]([tagID]) NOT NULL, 
    PRIMARY KEY ([itemID],[tagID])
)
CREATE TABLE [dbo].[transaction]
(
    [invoiceID] INT REFERENCES [invoice]([invoiceID]) NOT NULL , 
    [itemID] INT REFERENCES [items]([itemID]) NOT NULL, 
    [quantity] INT NOT NULL, 
    [totalPrice] DECIMAL(7, 2) NOT NULL,
    PRIMARY KEY ([invoiceID], [itemID])
)
CREATE TABLE [dbo].[customerInterests]
(
	[customerID] INT REFERENCES [customers]([customerID]) NOT NULL , 
    [tagID] INT REFERENCES [tags]([tagID]) NOT NULL, 
    [itemTypeID] INT REFERENCES [itemTypes]([itemTypeID]) NOT NULL, 
    PRIMARY KEY ([customerID],[tagID])
)
CREATE TABLE [dbo].[employeeAccount]
(
	[username] VARCHAR(15) NOT NULL PRIMARY KEY,
    [employeeID] INT REFERENCES [employees]([employeeID]) NOT NULL,  
    [password] VARCHAR(64) NOT NULL, 
    [dateCreated] DATE NOT NULL, 
    [lastAccess] DATE NOT NULL
)