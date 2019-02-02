DROP TABLE IF EXISTS books;
DROP TABLE IF EXISTS maps;
DROP TABLE IF EXISTS periodicals;
DROP TABLE IF EXISTS itemDiscounts;
DROP TABLE IF EXISTS itemTags;
DROP TABLE IF EXISTS customerInterests;
DROP TABLE IF EXISTS employeeAccount;
DROP TABLE IF EXISTS [transaction];
DROP TABLE IF EXISTS invoice;
DROP TABLE IF EXISTS inventory;
DROP TABLE IF EXISTS employees;
DROP TABLE IF EXISTS customers;
DROP TABLE IF EXISTS items;
DROP TABLE IF EXISTS genres;
DROP TABLE IF EXISTS itemTypes;
DROP TABLE IF EXISTS tags;
DROP TABLE IF EXISTS conditions;
DROP TABLE IF EXISTS customerTypes;
DROP TABLE IF EXISTS employeePositions;

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
    [tagDescription] VARCHAR(15) NOT NULL,
	[isActive] BIT NOT NULL DEFAULT 1
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
	[itemDescription] VARCHAR(50) NOT NULL,
    [price] DECIMAL(7, 2) NOT NULL, 
    [edition] TINYINT NOT NULL,
	[isActive] BIT NOT NULL DEFAULT 1
)
CREATE TABLE [dbo].[maps]
(
	[mapID] INT REFERENCES [items]([itemID]) NOT NULL PRIMARY KEY,
    [publisher] VARCHAR(30) NOT NULL, 
    [year] SMALLINT NOT NULL
)
CREATE TABLE [dbo].[periodicals]
(
	[periodicalID] INT REFERENCES [items]([itemID]) NOT NULL PRIMARY KEY,
    [companyName] VARCHAR(30) NOT NULL,  
    [genreID] INT REFERENCES [genres]([genreID]) NOT NULL,
    [date] DATE NOT NULL
)
CREATE TABLE [dbo].[books]
(
	[bookID] INT REFERENCES [items]([itemID]) NOT NULL PRIMARY KEY,
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
CREATE TABLE [dbo].[customerInterests] (
    [customerID] INT NOT NULL,
    [tagID]      INT NOT NULL,
    [itemTypeID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([customerID] ASC, [tagID] ASC, [itemTypeID] ASC),
    FOREIGN KEY ([customerID]) REFERENCES [dbo].[customers] ([customerID]),
    FOREIGN KEY ([tagID]) REFERENCES [dbo].[tags] ([tagID]),
    FOREIGN KEY ([itemTypeID]) REFERENCES [dbo].[itemTypes] ([itemTypeID])
)
CREATE TABLE [dbo].[employeeAccount]
(
	[username] VARCHAR(15) NOT NULL PRIMARY KEY,
    [employeeID] INT REFERENCES [employees]([employeeID]) NOT NULL,  
    [password] VARCHAR(64) NOT NULL, 
    [dateCreated] DATE NOT NULL, 
    [lastAccess] DATE NOT NULL
)

/* genres Table */
insert into genres (genreName) values ('Young Adult');
insert into genres (genreName) values ('Fantasy');
insert into genres (genreName) values ('Literary Fiction');
insert into genres (genreName) values ('Childrens');
insert into genres (genreName) values ('Science Fiction');
insert into genres (genreName) values ('Thriller');
insert into genres (genreName) values ('Horror');
insert into genres (genreName) values ('Romance');
insert into genres (genreName) values ('Historical');
insert into genres (genreName) values ('Womens Fiction');
insert into genres (genreName) values ('News');
insert into genres (genreName) values ('Lifestyle');
insert into genres (genreName) values ('Nature');
/* itemTypes Table */
insert into itemTypes (itemTypeName) values ('Book');
insert into itemTypes (itemTypeName) values ('Map');
insert into itemTypes (itemTypeName) values ('Periodical');
/* tags Table */
insert into tags (tagDescription, isActive) values ('Medieval', 1);
insert into tags (tagDescription, isActive) values ('World War 1', 1);
insert into tags (tagDescription, isActive) values ('World War 2', 1);
insert into tags (tagDescription, isActive) values ('Finance', 1);
insert into tags (tagDescription, isActive) values ('Cyberpunk', 1);
insert into tags (tagDescription, isActive) values ('Dystopia', 1);
insert into tags (tagDescription, isActive) values ('Utopia', 1);
insert into tags (tagDescription, isActive) values ('Ghosts', 1);
insert into tags (tagDescription, isActive) values ('Gothic', 1);
insert into tags (tagDescription, isActive) values ('North America', 1);
insert into tags (tagDescription, isActive) values ('South America', 1);
insert into tags (tagDescription, isActive) values ('Central America', 1);
insert into tags (tagDescription, isActive) values ('Europe', 1);
insert into tags (tagDescription, isActive) values ('Asia', 1);
insert into tags (tagDescription, isActive) values ('Oceania', 1);
insert into tags (tagDescription, isActive) values ('Africa', 1);
/* conditions Table */
insert into conditions (conditionType) values ('Very Damaged');
insert into conditions (conditionType) values ('Damaged');
insert into conditions (conditionType) values ('Very Poor');
insert into conditions (conditionType) values ('Poor');
insert into conditions (conditionType) values ('Fair');
insert into conditions (conditionType) values ('Good');
insert into conditions (conditionType) values ('Very Good');
insert into conditions (conditionType) values ('Excellent');
insert into conditions (conditionType) values ('Near-Perfect');
insert into conditions (conditionType) values ('Perfect');
/* customerTypes Table */
insert into customerTypes (customerTypeName) values ('Collector');
insert into customerTypes (customerTypeName) values ('Buyer');
/* employeePositions Table */
insert into employeePositions (positionName) values ('Manager');
insert into employeePositions (positionName) values ('A. Manager');
insert into employeePositions (positionName) values ('CSR');

/* items Table */
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'It', 12.35, 7);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Witches, The', 12.74, 7);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Arcana', 10.49, 4);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Siones Wedding', 16.62, 3);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Albuquerque', 23.49, 7);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'The Tenant of Wildfell Hall', 20.67, 6);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Brunet Will Call', 17.74, 7);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Anna', 23.42, 7);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'In China They Eat Dogs', 15.06, 9);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Takedown', 14.35, 8);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Nobodys Fool', 20.91, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Hero Wanted', 23.22, 10);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Accomplices (Complices)', 11.46, 9);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Last Frontier, The', 24.11, 7);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Star Trek Into Darkness', 12.47, 8);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'First Power, The', 24.41, 10);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Yella', 14.28, 2);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Secret of the Wings', 6.83, 7);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Earth vs. The Spider', 16.03, 4);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'At the Death House Door', 5.48, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Where East Is East', 22.56, 7);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Café Metropole', 12.32, 10);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Tom Sawyer', 21.8, 8);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Beverly Hills Chihuahua 2', 24.27, 6);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Zatoichis Revenge', 5.96, 4);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Ten Inch Hero', 7.49, 10);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Ip Man: The Final Fight', 5.3, 3);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Flight from Death: The Quest for Immortality', 19.05, 4);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Children of the Century, The', 12.93, 6);
insert into items (itemTypeID, itemDescription, price, edition) values (1, 'Appointment in Tokyo', 8.14, 2);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Lewodoli', 16.02, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Xinji', 30.13, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Tocok', 25.84, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Ruma', 29.7, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Mmaaf', 27.27, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Tuochuan', 21.21, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Rongwo', 16.79, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Ban Bueng', 32.31, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Kostyantynivka', 28.75, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Usman', 35.26, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Salacgrīva', 18.66, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Kedungwungu', 18.15, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'La Plata', 15.48, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Santo Domingo Este', 15.16, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Bradford', 15.27, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Sidirókastro', 31.37, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Bakar', 15.01, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Ballylinan', 21.97, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Laoxialu', 25.01, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Medvedok', 16.81, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Cibangban Girang', 18.18, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Sochi', 37.67, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Néo Psychikó', 17.13, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Ubay', 36.86, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Ntoroko', 26.96, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Čelinac', 20.04, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Szczecin', 30.76, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Arroteia', 35.33, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Orerokpe', 25.99, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (2, 'Pandean', 16.46, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Toronto Star', 9.33, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'National Geographic', 17.24, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Time', 10.34, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'People', 18.59, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Readers Digest', 7.62, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Vogue', 23.19, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Sports Illustrated', 9.51, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Cosmopoltian', 12.33, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Prevention', 14.35, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Maxim', 15.76, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'AAA Living', 9.74, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Glamour', 12.8, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Parenting', 20.5, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Globe and Mail, The', 6.65, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Le Journal de Montreal', 23.18, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'La Presse', 9.1, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Financial Post', 7.61, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Metro Montreal', 16.3, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, '24 Heures Montreal', 18.5, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'The Province', 13.51, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Vancouver Sun', 20.87, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Toronto Sun', 8.46, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'The New York Times', 9.95, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Washington Post', 11.82, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'USA Today', 13.86, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Houston Chronicle', 20.07, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'The Wall Street Journal', 19.69, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Chicago Tribune', 19.09, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'Los Angeles Times', 9.97, 1);
insert into items (itemTypeID, itemDescription, price, edition) values (3, 'New York Post)', 19.3, 1);
/* books Table */
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (1, 9, 'Cly', 'Lawlee', 'Langworth Group', '1979-12-17');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (2, 10, 'Berenice', 'Heiton', 'Leannon-Hane', '1982-08-01');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (3, 5, 'Margie', 'Tedstone', 'Bernier Inc', '1981-08-25');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (4, 8, 'Lindsay', 'Lambertazzi', 'Swift-Davis', '1975-12-06');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (5, 5, 'Dode', 'Woodnutt', 'Breitenberg, Towne and Pacocha', '2005-12-19');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (6, 5, 'Jamill', 'Witheridge', 'Mills-VonRueden', '1985-02-02');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (7, 7, 'Flin', 'Fay', 'Konopelski, Kilback and Rippin', '1979-07-28');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (8, 9, 'Maggy', 'Grishukov', 'Hoeger-Ernser', '2018-02-26');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (9, 1, 'Ray', 'Vannikov', 'Pollich, Dicki and Durgan', '1994-05-24');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (10, 10, 'Luther', 'Goadby', 'Simonis-Batz', '2005-09-30');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (11, 1, 'Wolfy', 'Kilsby', 'Bartell, Hills and Hane', '1999-10-25');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (12, 8, 'Anni', 'Clohessy', 'Sanford, Sporer and White', '1971-05-20');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (13, 7, 'Powell', 'Darton', 'Goodwin, Bradtke and Ziemann', '2010-02-14');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (14, 10, 'Allyn', 'Westcarr', 'Gusikowski-Tremblay', '2010-07-18');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (15, 8, 'Kandace', 'Willcock', 'Ondricka and Sons', '1972-02-28');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (16, 4, 'Patrica', 'Lepper', 'Daniel-Lubowitz', '1994-06-05');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (17, 4, 'Berry', 'Gogie', 'Macejkovic, Prosacco', '2017-04-28');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (18, 2, 'Huntley', 'Simonett', 'Goldner-Koelpin', '2005-11-17');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (19, 4, 'Harley', 'Patriskson', 'Windler, Senger and Renner', '2004-04-21');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (20, 10, 'Goraud', 'Van Son', 'Bradtke LLC', '1976-09-26');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (21, 4, 'Fernandina', 'Baynes', 'Nolan, Gerlach and Reichert', '1971-11-01');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (22, 1, 'Ray', 'Grinsted', 'Schaden Inc', '2010-10-24');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (23, 3, 'Curtis', 'Mc Combe', 'O Reilly, Kulas and Kilback', '2006-02-11');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (24, 10, 'Dulce', 'Trivett', 'Upton, Connelly and Stracke', '2005-01-01');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (25, 2, 'Bili', 'Heber', 'Harvey, McGlynn and Murray', '1992-01-02');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (26, 5, 'Ephrem', 'Benfield', 'Beer Inc', '2016-02-08');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (27, 2, 'Janice', 'Heintz', 'Kiehn Inc', '2014-05-03');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (28, 5, 'Cass', 'Stubley', 'Borer-Herzog', '2016-12-05');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (29, 1, 'Clarinda', 'Whatham', 'Anderson and Sons', '1977-09-26');
insert into books (bookID, genreID, authorFirst, authorLast, publisher, publishDate) values (30, 7, 'Karl', 'Hands', 'Ziemann, West and Ratke', '1989-11-14');
/* maps Table */
insert into maps (mapID, publisher, year) values (31, 'Hane Group', 1944);
insert into maps (mapID, publisher, year) values (32, 'Greenholt and Sons', 2017);
insert into maps (mapID, publisher, year) values (33, 'Skiles and Sons', 1972);
insert into maps (mapID, publisher, year) values (34, 'Hartmann LLC', 1967);
insert into maps (mapID, publisher, year) values (35, 'Robel, Kshlerin and Fadel', 2015);
insert into maps (mapID, publisher, year) values (36, 'Sipes and Sons', 1982);
insert into maps (mapID, publisher, year) values (37, 'Rice-Legros', 1952);
insert into maps (mapID, publisher, year) values (38, 'Dare, Schimmel and Sauer', 2018);
insert into maps (mapID, publisher, year) values (39, 'Murazik Inc', 1917);
insert into maps (mapID, publisher, year) values (40, 'Homenick-Prosacco', 1911);
insert into maps (mapID, publisher, year) values (41, 'Ondricka, Marvin and Gleason', 1986);
insert into maps (mapID, publisher, year) values (42, 'Herzog Group', 1982);
insert into maps (mapID, publisher, year) values (43, 'Kihn-Howell', 1959);
insert into maps (mapID, publisher, year) values (44, 'Mohr, Kemmer and Considine', 1903);
insert into maps (mapID, publisher, year) values (45, 'Osinski, Spinka and Kris', 1936);
insert into maps (mapID, publisher, year) values (46, 'Turner, Stanton and Block', 2008);
insert into maps (mapID, publisher, year) values (47, 'Jerde Group', 2000);
insert into maps (mapID, publisher, year) values (48, 'Sawayn, Tillman and Jaskolski', 2014);
insert into maps (mapID, publisher, year) values (49, 'Mitchell Inc', 2010);
insert into maps (mapID, publisher, year) values (50, 'Wisozk, Mosciski and Langosh', 1996);
insert into maps (mapID, publisher, year) values (51, 'Blanda Inc', 1976);
insert into maps (mapID, publisher, year) values (52, 'Mayer, Cummings and Wolf', 1988);
insert into maps (mapID, publisher, year) values (53, 'Ullrich, Leannon and Johns', 1905);
insert into maps (mapID, publisher, year) values (54, 'Powlowski-Herman', 2010);
insert into maps (mapID, publisher, year) values (55, 'Johnston Inc', 1994);
insert into maps (mapID, publisher, year) values (56, 'Schimmel LLC', 1996);
insert into maps (mapID, publisher, year) values (57, 'O Keefe-Kreiger', 1927);
insert into maps (mapID, publisher, year) values (58, 'Gaylord, Boyer and Haley', 1937);
insert into maps (mapID, publisher, year) values (59, 'Heller, Brown and Kiehn', 1975);
insert into maps (mapID, publisher, year) values (60, 'Jast-Crooks', 1988);
/* periodicals Table */
insert into periodicals (periodicalID, companyName, genreID, date) values (61, 'Orn-Renner', 11, '2007-05-07');
insert into periodicals (periodicalID, companyName, genreID, date) values (62, 'Koelpin-Gislason', 12, '2013-02-07');
insert into periodicals (periodicalID, companyName, genreID, date) values (63, 'Collier, Schmitt and Haag', 13, '2018-11-24');
insert into periodicals (periodicalID, companyName, genreID, date) values (64, 'Heidenreich LLC', 13, '2013-10-24');
insert into periodicals (periodicalID, companyName, genreID, date) values (65, 'Welch, Quigley and Keeling', 13, '2012-07-03');
insert into periodicals (periodicalID, companyName, genreID, date) values (66, 'Prosacco-Mante', 13, '2012-09-14');
insert into periodicals (periodicalID, companyName, genreID, date) values (67, 'Schaefer, Nienow and Koepp', 13, '2008-08-16');
insert into periodicals (periodicalID, companyName, genreID, date) values (68, 'Schmeler Group', 13, '2006-09-18');
insert into periodicals (periodicalID, companyName, genreID, date) values (69, 'Keeling-Morissette', 13, '2013-09-14');
insert into periodicals (periodicalID, companyName, genreID, date) values (70, 'Nitzsche, Mosciski', 13, '2015-01-12');
insert into periodicals (periodicalID, companyName, genreID, date) values (71, 'Daniel-Rau', 13, '2016-10-28');
insert into periodicals (periodicalID, companyName, genreID, date) values (72, 'Thiel, Koepp and Farrell', 13, '2007-09-10');
insert into periodicals (periodicalID, companyName, genreID, date) values (73, 'Johnston Group', 13, '2018-07-29');
insert into periodicals (periodicalID, companyName, genreID, date) values (74, 'Altenwerth and Sons', 12, '2014-09-22');
insert into periodicals (periodicalID, companyName, genreID, date) values (75, 'Stehr, Gibson and Ferry', 12, '2008-09-28');
insert into periodicals (periodicalID, companyName, genreID, date) values (76, 'Barrows-Parisian', 12, '2013-01-25');
insert into periodicals (periodicalID, companyName, genreID, date) values (77, 'Williamson, Bartell and Gibson', 12, '2011-09-23');
insert into periodicals (periodicalID, companyName, genreID, date) values (78, 'Parisian and Sons', 12, '2006-03-11');
insert into periodicals (periodicalID, companyName, genreID, date) values (79, 'Hickle Inc', 12, '2009-11-28');
insert into periodicals (periodicalID, companyName, genreID, date) values (80, 'Mueller Group', 12, '2007-07-01');
insert into periodicals (periodicalID, companyName, genreID, date) values (81, 'Gulgowski, Carter and Russel', 12, '2009-06-09');
insert into periodicals (periodicalID, companyName, genreID, date) values (82, 'Nienow LLC', 12, '2007-05-22');
insert into periodicals (periodicalID, companyName, genreID, date) values (83, 'Cruickshank, Waelchi and Bins', 12, '2012-01-15');
insert into periodicals (periodicalID, companyName, genreID, date) values (84, 'Hyatt Group', 12, '2010-10-20');
insert into periodicals (periodicalID, companyName, genreID, date) values (85, 'Farrell and Sons', 12, '2009-07-20');
insert into periodicals (periodicalID, companyName, genreID, date) values (86, 'Williamson and Sons', 12, '2015-12-26');
insert into periodicals (periodicalID, companyName, genreID, date) values (87, 'Crist, Jacobs and Conroy', 12, '2015-02-27');
insert into periodicals (periodicalID, companyName, genreID, date) values (88, 'Kuhlman-Adams', 12, '2015-07-29');
insert into periodicals (periodicalID, companyName, genreID, date) values (89, 'Skiles-Ullrich', 12, '2016-08-24');
insert into periodicals (periodicalID, companyName, genreID, date) values (90, 'Deckow Inc', 12, '2010-06-13');
/* customers Table */
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Anonymous', 'User', '9999999999');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Sibelle', 'Tremaine', '6164274107');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Westbrooke', 'Vasovic', '1115668680');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Eddy', 'Batalini', '9145204936');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Arlan', 'Choffin', '6208646155');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Evin', 'Beekman', '6002790424');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Duffie', 'Belle', '7248576678');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Phylis', 'Dewerson', '9726695832');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Leshia', 'Babb', '6131603623');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Timmy', 'Heazel', '7197265944');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Kin', 'Le-Good', '2871370183');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Engelbert', 'Deneve', '2496151092');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Justinian', 'Mounce', '7099723909');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Libby', 'McAllister', '2028238821');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Reese', 'Martt', '2092676741');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Kacy', 'Maron', '9456754028');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Artair', 'Strattan', '8575745160');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Minni', 'Sellers', '2946433143');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Christyna', 'Romaint', '7069445590');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Delinda', 'Sandcraft', '2779297835');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Antony', 'Rahill', '6456441920');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Mariana', 'Perse', '7602718717');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Jolyn', 'Kee', '2719060419');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Vannie', 'Romanin', '5218538817');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Bengt', 'Elsbury', '3527251358');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Roselia', 'Fricker', '9353216507');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Sidonia', 'Benda', '2823086943');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Aksel', 'Wain', '9485835471');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Diahann', 'Caldera', '5693048412');
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (1, 'Gabi', 'Warnock', '9758384923');
/* employees Table */
insert into employees (positionID, firstName, lastName, phoneNumber) values (1, 'Connor', 'Whyte', '8504988352');
insert into employees (positionID, firstName, lastName, phoneNumber) values (2, 'Luceiia', 'Whyte', '3096828999');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Derek', 'Arthurs', '8338819384');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Esma', 'Iacomi', '7406620301');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Onofredo', 'Fotherby', '5612555436');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Doloritas', 'Olenchenko', '7367714410');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Idalia', 'Toplis', '2727534546');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Wallace', 'Winchurst', '9016785112');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Dino', 'Bock', '4907009829');
insert into employees (positionID, firstName, lastName, phoneNumber) values (2, 'Annora', 'Yankin', '1874326790');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Miltie', 'Prinett', '6644719980');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Blanch', 'Stimpson', '6198781842');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Amaleta', 'Haseldine', '3801857932');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'De witt', 'Starmore', '6988776782');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Rebeka', 'Rarity', '7397761529');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Elaina', 'Manna', '9428223104');
insert into employees (positionID, firstName, lastName, phoneNumber) values (2, 'Christi', 'Dutt', '7467859174');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Cord', 'Dalley', '6235475721');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Chantal', 'Dundredge', '3719948402');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Fairlie', 'Drane', '2039007263');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Shelley', 'Godilington', '6468478570');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Brion', 'Paffot', '9432561143');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Tate', 'Jannequin', '5784751935');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Aldous', 'Bonanno', '7818410312');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Blondell', 'MacAlees', '7703958389');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Miof mela', 'Wenman', '6395079382');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Kahaleel', 'Cloney', '3584606278');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Thor', 'Lines', '5659614429');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Oswald', 'Yarn', '5786234465');
insert into employees (positionID, firstName, lastName, phoneNumber) values (3, 'Brande', 'Summerbell', '9252801004');
/* inventory Table */
insert into inventory (itemID, conditionID, quantity) values (1, 6, 34);
insert into inventory (itemID, conditionID, quantity) values (2, 9, 8);
insert into inventory (itemID, conditionID, quantity) values (3, 9, 44);
insert into inventory (itemID, conditionID, quantity) values (4, 2, 25);
insert into inventory (itemID, conditionID, quantity) values (5, 5, 38);
insert into inventory (itemID, conditionID, quantity) values (6, 3, 7);
insert into inventory (itemID, conditionID, quantity) values (7, 10, 31);
insert into inventory (itemID, conditionID, quantity) values (8, 5, 48);
insert into inventory (itemID, conditionID, quantity) values (9, 9, 100);
insert into inventory (itemID, conditionID, quantity) values (10, 2, 82);
insert into inventory (itemID, conditionID, quantity) values (11, 2, 63);
insert into inventory (itemID, conditionID, quantity) values (12, 1, 24);
insert into inventory (itemID, conditionID, quantity) values (13, 4, 39);
insert into inventory (itemID, conditionID, quantity) values (14, 4, 10);
insert into inventory (itemID, conditionID, quantity) values (15, 4, 48);
insert into inventory (itemID, conditionID, quantity) values (16, 1, 11);
insert into inventory (itemID, conditionID, quantity) values (17, 2, 82);
insert into inventory (itemID, conditionID, quantity) values (18, 9, 16);
insert into inventory (itemID, conditionID, quantity) values (19, 8, 48);
insert into inventory (itemID, conditionID, quantity) values (20, 5, 7);
insert into inventory (itemID, conditionID, quantity) values (21, 1, 58);
insert into inventory (itemID, conditionID, quantity) values (22, 3, 91);
insert into inventory (itemID, conditionID, quantity) values (23, 2, 3);
insert into inventory (itemID, conditionID, quantity) values (24, 7, 68);
insert into inventory (itemID, conditionID, quantity) values (25, 6, 97);
insert into inventory (itemID, conditionID, quantity) values (26, 7, 76);
insert into inventory (itemID, conditionID, quantity) values (27, 3, 76);
insert into inventory (itemID, conditionID, quantity) values (28, 9, 61);
insert into inventory (itemID, conditionID, quantity) values (29, 5, 26);
insert into inventory (itemID, conditionID, quantity) values (30, 8, 89);
insert into inventory (itemID, conditionID, quantity) values (31, 10, 36);
insert into inventory (itemID, conditionID, quantity) values (32, 6, 5);
insert into inventory (itemID, conditionID, quantity) values (33, 1, 79);
insert into inventory (itemID, conditionID, quantity) values (34, 3, 65);
insert into inventory (itemID, conditionID, quantity) values (35, 3, 19);
insert into inventory (itemID, conditionID, quantity) values (36, 1, 43);
insert into inventory (itemID, conditionID, quantity) values (37, 2, 29);
insert into inventory (itemID, conditionID, quantity) values (38, 3, 1);
insert into inventory (itemID, conditionID, quantity) values (39, 3, 50);
insert into inventory (itemID, conditionID, quantity) values (40, 7, 69);
insert into inventory (itemID, conditionID, quantity) values (41, 6, 67);
insert into inventory (itemID, conditionID, quantity) values (42, 8, 25);
insert into inventory (itemID, conditionID, quantity) values (43, 3, 17);
insert into inventory (itemID, conditionID, quantity) values (44, 2, 14);
insert into inventory (itemID, conditionID, quantity) values (45, 3, 96);
insert into inventory (itemID, conditionID, quantity) values (46, 7, 81);
insert into inventory (itemID, conditionID, quantity) values (47, 6, 74);
insert into inventory (itemID, conditionID, quantity) values (48, 10, 48);
insert into inventory (itemID, conditionID, quantity) values (49, 8, 41);
insert into inventory (itemID, conditionID, quantity) values (50, 2, 47);
insert into inventory (itemID, conditionID, quantity) values (51, 1, 72);
insert into inventory (itemID, conditionID, quantity) values (52, 7, 36);
insert into inventory (itemID, conditionID, quantity) values (53, 3, 96);
insert into inventory (itemID, conditionID, quantity) values (54, 3, 57);
insert into inventory (itemID, conditionID, quantity) values (55, 1, 4);
insert into inventory (itemID, conditionID, quantity) values (56, 10, 67);
insert into inventory (itemID, conditionID, quantity) values (57, 8, 84);
insert into inventory (itemID, conditionID, quantity) values (58, 2, 3);
insert into inventory (itemID, conditionID, quantity) values (59, 8, 70);
insert into inventory (itemID, conditionID, quantity) values (60, 5, 74);
insert into inventory (itemID, conditionID, quantity) values (61, 4, 5);
insert into inventory (itemID, conditionID, quantity) values (62, 10, 6);
insert into inventory (itemID, conditionID, quantity) values (63, 1, 74);
insert into inventory (itemID, conditionID, quantity) values (64, 10, 73);
insert into inventory (itemID, conditionID, quantity) values (65, 8, 45);
insert into inventory (itemID, conditionID, quantity) values (66, 1, 9);
insert into inventory (itemID, conditionID, quantity) values (67, 3, 45);
insert into inventory (itemID, conditionID, quantity) values (68, 9, 71);
insert into inventory (itemID, conditionID, quantity) values (69, 8, 17);
insert into inventory (itemID, conditionID, quantity) values (70, 4, 32);
insert into inventory (itemID, conditionID, quantity) values (71, 2, 100);
insert into inventory (itemID, conditionID, quantity) values (72, 2, 89);
insert into inventory (itemID, conditionID, quantity) values (73, 3, 5);
insert into inventory (itemID, conditionID, quantity) values (74, 8, 11);
insert into inventory (itemID, conditionID, quantity) values (75, 1, 46);
insert into inventory (itemID, conditionID, quantity) values (76, 4, 100);
insert into inventory (itemID, conditionID, quantity) values (77, 8, 89);
insert into inventory (itemID, conditionID, quantity) values (78, 6, 83);
insert into inventory (itemID, conditionID, quantity) values (79, 2, 83);
insert into inventory (itemID, conditionID, quantity) values (80, 3, 42);
insert into inventory (itemID, conditionID, quantity) values (81, 5, 38);
insert into inventory (itemID, conditionID, quantity) values (82, 8, 90);
insert into inventory (itemID, conditionID, quantity) values (83, 1, 89);
insert into inventory (itemID, conditionID, quantity) values (84, 8, 22);
insert into inventory (itemID, conditionID, quantity) values (85, 4, 17);
insert into inventory (itemID, conditionID, quantity) values (86, 6, 42);
insert into inventory (itemID, conditionID, quantity) values (87, 9, 54);
insert into inventory (itemID, conditionID, quantity) values (88, 4, 74);
insert into inventory (itemID, conditionID, quantity) values (89, 10, 19);
insert into inventory (itemID, conditionID, quantity) values (90, 8, 42);
/* itemDiscounts Table */
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (1, 5.12, '2018/09/01', '2019/08/15');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (2, 4.57, '2018/10/08', '2019/06/14');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (3, 2.19, '2018/07/13', '2018/11/30');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (4, 4.8, '2018/02/03', '2019/03/07');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (5, 6.82, '2017/10/24', '2019/11/08');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (6, 5.15, '2018/03/22', '2018/12/27');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (7, 2.09, '2018/09/07', '2019/11/14');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (8, 1.83, '2018/05/15', '2019/05/24');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (9, 6.68, '2018/03/01', '2019/06/05');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (10, 2.08, '2018/06/16', '2019/10/25');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (11, 0.27, '2018/07/17', '2019/01/11');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (12, 3.15, '2018/11/04', '2019/06/14');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (13, 2.73, '2018/09/21', '2018/12/21');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (14, 0.78, '2018/02/13', '2019/08/15');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (15, 3.03, '2018/03/29', '2019/08/08');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (16, 0.1, '2017/10/27', '2019/09/02');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (17, 5.71, '2018/07/09', '2019/01/13');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (18, 6.44, '2018/06/07', '2019/09/01');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (19, 5.05, '2018/03/24', '2019/09/07');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (20, 5.69, '2017/11/14', '2019/11/08');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (21, 2.13, '2018/09/21', '2019/09/16');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (22, 4.91, '2017/10/11', '2019/04/04');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (23, 3.75, '2018/06/08', '2019/05/01');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (24, 0.43, '2018/05/09', '2018/11/24');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (25, 2.88, '2017/12/25', '2019/02/03');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (26, 2.02, '2018/10/31', '2019/04/05');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (27, 1.71, '2018/02/25', '2019/05/29');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (28, 3.19, '2018/04/18', '2019/08/24');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (29, 5.44, '2018/01/20', '2019/02/26');
insert into itemDiscounts (discountID, discountAmount, startDate, endDate) values (30, 3.51, '2018/02/22', '2019/03/14');
/* itemTags Table */
insert into itemTags (itemID, tagID) values (31, 14);
insert into itemTags (itemID, tagID) values (32, 14);
insert into itemTags (itemID, tagID) values (33, 14);
insert into itemTags (itemID, tagID) values (34, 13);
insert into itemTags (itemID, tagID) values (35, 10);
insert into itemTags (itemID, tagID) values (36, 10);
insert into itemTags (itemID, tagID) values (37, 14);
insert into itemTags (itemID, tagID) values (38, 14);
insert into itemTags (itemID, tagID) values (39, 13);
insert into itemTags (itemID, tagID) values (40, 13);
insert into itemTags (itemID, tagID) values (41, 14);
insert into itemTags (itemID, tagID) values (42, 14);
insert into itemTags (itemID, tagID) values (43, 11);
insert into itemTags (itemID, tagID) values (44, 10);
insert into itemTags (itemID, tagID) values (45, 13);
insert into itemTags (itemID, tagID) values (46, 13);
insert into itemTags (itemID, tagID) values (47, 14);
insert into itemTags (itemID, tagID) values (48, 13);
insert into itemTags (itemID, tagID) values (49, 14);
insert into itemTags (itemID, tagID) values (50, 13);
insert into itemTags (itemID, tagID) values (51, 14);
insert into itemTags (itemID, tagID) values (52, 13);
insert into itemTags (itemID, tagID) values (53, 13);
insert into itemTags (itemID, tagID) values (54, 14);
insert into itemTags (itemID, tagID) values (55, 16);
insert into itemTags (itemID, tagID) values (56, 13);
insert into itemTags (itemID, tagID) values (57, 13);
insert into itemTags (itemID, tagID) values (58, 15);
insert into itemTags (itemID, tagID) values (59, 16);
insert into itemTags (itemID, tagID) values (60, 12);
/* customerInterests Table */
insert into customerInterests (customerID, tagID, itemTypeID) values (1, 10, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (2, 9, 1);
insert into customerInterests (customerID, tagID, itemTypeID) values (3, 1, 1);
insert into customerInterests (customerID, tagID, itemTypeID) values (4, 2, 2);
insert into customerInterests (customerID, tagID, itemTypeID) values (5, 9, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (6, 5, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (7, 10, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (8, 7, 2);
insert into customerInterests (customerID, tagID, itemTypeID) values (9, 10, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (10, 9, 1);
insert into customerInterests (customerID, tagID, itemTypeID) values (11, 1, 1);
insert into customerInterests (customerID, tagID, itemTypeID) values (12, 2, 2);
insert into customerInterests (customerID, tagID, itemTypeID) values (13, 10, 2);
insert into customerInterests (customerID, tagID, itemTypeID) values (14, 3, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (15, 9, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (16, 4, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (17, 1, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (18, 4, 2);
insert into customerInterests (customerID, tagID, itemTypeID) values (19, 10, 2);
insert into customerInterests (customerID, tagID, itemTypeID) values (20, 2, 1);
insert into customerInterests (customerID, tagID, itemTypeID) values (21, 1, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (22, 1, 2);
insert into customerInterests (customerID, tagID, itemTypeID) values (23, 1, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (24, 7, 1);
insert into customerInterests (customerID, tagID, itemTypeID) values (25, 8, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (26, 8, 1);
insert into customerInterests (customerID, tagID, itemTypeID) values (27, 9, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (28, 9, 3);
insert into customerInterests (customerID, tagID, itemTypeID) values (29, 5, 1);
insert into customerInterests (customerID, tagID, itemTypeID) values (30, 3, 3);
/* invoice Table */
insert into invoice (customerID, invoiceDate) values (18, '2018-09-25');
insert into invoice (customerID, invoiceDate) values (21, '2018-03-14');
insert into invoice (customerID, invoiceDate) values (13, '2018-05-22');
insert into invoice (customerID, invoiceDate) values (9, '2018-07-16');
insert into invoice (customerID, invoiceDate) values (17, '2018-03-15');
insert into invoice (customerID, invoiceDate) values (28, '2018-05-21');
insert into invoice (customerID, invoiceDate) values (13, '2018-01-26');
insert into invoice (customerID, invoiceDate) values (16, '2018-03-27');
insert into invoice (customerID, invoiceDate) values (4, '2018-07-26');
insert into invoice (customerID, invoiceDate) values (8, '2018-08-09');
insert into invoice (customerID, invoiceDate) values (23, '2018-01-25');
insert into invoice (customerID, invoiceDate) values (10, '2018-07-11');
insert into invoice (customerID, invoiceDate) values (21, '2018-03-15');
insert into invoice (customerID, invoiceDate) values (8, '2018-06-21');
insert into invoice (customerID, invoiceDate) values (23, '2018-10-09');
insert into invoice (customerID, invoiceDate) values (5, '2018-02-08');
insert into invoice (customerID, invoiceDate) values (5, '2018-02-05');
insert into invoice (customerID, invoiceDate) values (30, '2017-12-18');
insert into invoice (customerID, invoiceDate) values (20, '2017-12-27');
insert into invoice (customerID, invoiceDate) values (2, '2018-02-11');
insert into invoice (customerID, invoiceDate) values (11, '2018-08-11');
insert into invoice (customerID, invoiceDate) values (27, '2018-02-20');
insert into invoice (customerID, invoiceDate) values (27, '2018-02-06');
insert into invoice (customerID, invoiceDate) values (9, '2018-01-29');
insert into invoice (customerID, invoiceDate) values (17, '2017-12-08');
insert into invoice (customerID, invoiceDate) values (1, '2018-04-01');
insert into invoice (customerID, invoiceDate) values (8, '2018-11-05');
insert into invoice (customerID, invoiceDate) values (29, '2018-02-01');
insert into invoice (customerID, invoiceDate) values (24, '2018-09-18');
insert into invoice (customerID, invoiceDate) values (21, '2018-03-17');
/* transaction Table */
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (1, 69, 1, 14.53);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (2, 77, 2, 15.22);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (3, 11, 3, 62.73);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (4, 79, 2, 37.00);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (5, 82, 2, 16.92);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (6, 32, 3, 90.39);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (7, 80, 1, 13.51);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (8, 58, 1, 35.33);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (9, 36, 3, 63.63);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (10, 58, 1, 35.33);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (11, 23, 2, 43.60);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (12, 24, 3, 72.81);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (13, 71, 1, 9.74);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (14, 67, 2, 19.02);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (15, 21, 3, 67.68);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (16, 43, 3, 46.44);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (17, 79, 3, 55.50);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (18, 43, 1, 15.48);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (19, 11, 1, 20.91);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (20, 84, 2, 23.64);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (21, 85, 1, 13.86);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (22, 27, 1, 5.30);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (23, 81, 2, 118.44);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (24, 88, 1, 41.74);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (25, 48, 1, 21.97);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (26, 52, 1, 37.67);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (27, 73, 1, 20.50);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (28, 28, 1, 19.05);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (29, 32, 3, 90.93);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (30, 88, 1, 19.09);

insert into employeeAccount (username, employeeID, password, dateCreated, lastAccess) values ('connor123', 1, '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '11/11/2000', '11/11/2000');
insert into employeeAccount (username, employeeID, password, dateCreated, lastAccess) values ('test123', 2, '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '11/11/2000', '11/11/2000');
insert into employeeAccount (username, employeeID, password, dateCreated, lastAccess) values ('bobby123', 3, '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '11/11/2000', '11/11/2000');