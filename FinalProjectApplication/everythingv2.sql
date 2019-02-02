
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
CREATE TABLE [dbo].[customerInterests] (
    [customerID] INT NOT NULL,
    [tagID]      INT NOT NULL,
    [itemTypeID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([customerID] ASC, [tagID] ASC, [itemTypeID] ASC),
    FOREIGN KEY ([customerID]) REFERENCES [dbo].[customers] ([customerID]),
    FOREIGN KEY ([tagID]) REFERENCES [dbo].[tags] ([tagID]),
    FOREIGN KEY ([itemTypeID]) REFERENCES [dbo].[itemTypes] ([itemTypeID])
);
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
/* itemTypes Table */
insert into itemTypes (itemTypeName) values ('Book');
insert into itemTypes (itemTypeName) values ('Map');
insert into itemTypes (itemTypeName) values ('Periodical');
/* tags Table */
insert into tags (tagDescription) values ('Medieval');
insert into tags (tagDescription) values ('World War 1');
insert into tags (tagDescription) values ('World War 2');
insert into tags (tagDescription) values ('Finance');
insert into tags (tagDescription) values ('Cyberpunk');
insert into tags (tagDescription) values ('Dystopia');
insert into tags (tagDescription) values ('Utopia');
insert into tags (tagDescription) values ('Ghosts');
insert into tags (tagDescription) values ('Gothic');
insert into tags (tagDescription) values ('Psychological');
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
insert into items (itemTypeID, price, edition) values (1, 13.94, 4);
insert into items (itemTypeID, price, edition) values (1, 60.45, 3);
insert into items (itemTypeID, price, edition) values (1, 20.72, 5);
insert into items (itemTypeID, price, edition) values (1, 25.56, 7);
insert into items (itemTypeID, price, edition) values (1, 84.21, 6);
insert into items (itemTypeID, price, edition) values (1, 50.97, 8);
insert into items (itemTypeID, price, edition) values (1, 65.31, 7);
insert into items (itemTypeID, price, edition) values (1, 91.01, 6);
insert into items (itemTypeID, price, edition) values (1, 43.07, 9);
insert into items (itemTypeID, price, edition) values (1, 97.63, 9);
insert into items (itemTypeID, price, edition) values (1, 38.64, 9);
insert into items (itemTypeID, price, edition) values (1, 59.38, 4);
insert into items (itemTypeID, price, edition) values (1, 45.34, 7);
insert into items (itemTypeID, price, edition) values (1, 74.85, 4);
insert into items (itemTypeID, price, edition) values (1, 81.46, 9);
insert into items (itemTypeID, price, edition) values (1, 87.33, 3);
insert into items (itemTypeID, price, edition) values (1, 57.03, 1);
insert into items (itemTypeID, price, edition) values (1, 85.39, 4);
insert into items (itemTypeID, price, edition) values (1, 81.06, 1);
insert into items (itemTypeID, price, edition) values (1, 68.19, 2);
insert into items (itemTypeID, price, edition) values (1, 7.57, 10);
insert into items (itemTypeID, price, edition) values (1, 60.91, 3);
insert into items (itemTypeID, price, edition) values (1, 79.09, 2);
insert into items (itemTypeID, price, edition) values (1, 58.76, 10);
insert into items (itemTypeID, price, edition) values (1, 50.19, 3);
insert into items (itemTypeID, price, edition) values (1, 77.21, 10);
insert into items (itemTypeID, price, edition) values (1, 72.51, 9);
insert into items (itemTypeID, price, edition) values (1, 64.95, 10);
insert into items (itemTypeID, price, edition) values (1, 77.55, 8);
insert into items (itemTypeID, price, edition) values (1, 74.68, 3);
insert into items (itemTypeID, price, edition) values (2, 74.13, 8);
insert into items (itemTypeID, price, edition) values (2, 30.6, 5);
insert into items (itemTypeID, price, edition) values (2, 51.71, 6);
insert into items (itemTypeID, price, edition) values (2, 96.16, 8);
insert into items (itemTypeID, price, edition) values (2, 89.99, 6);
insert into items (itemTypeID, price, edition) values (2, 7.56, 8);
insert into items (itemTypeID, price, edition) values (2, 7.51, 10);
insert into items (itemTypeID, price, edition) values (2, 65.3, 4);
insert into items (itemTypeID, price, edition) values (2, 17.19, 6);
insert into items (itemTypeID, price, edition) values (2, 35.22, 3);
insert into items (itemTypeID, price, edition) values (2, 33.75, 2);
insert into items (itemTypeID, price, edition) values (2, 18.63, 7);
insert into items (itemTypeID, price, edition) values (2, 50.37, 5);
insert into items (itemTypeID, price, edition) values (2, 89.06, 9);
insert into items (itemTypeID, price, edition) values (2, 14.39, 6);
insert into items (itemTypeID, price, edition) values (2, 44.79, 2);
insert into items (itemTypeID, price, edition) values (2, 72.9, 6);
insert into items (itemTypeID, price, edition) values (2, 65.27, 6);
insert into items (itemTypeID, price, edition) values (2, 35.41, 3);
insert into items (itemTypeID, price, edition) values (2, 58.55, 2);
insert into items (itemTypeID, price, edition) values (2, 43.12, 2);
insert into items (itemTypeID, price, edition) values (2, 92.4, 1);
insert into items (itemTypeID, price, edition) values (2, 63.78, 10);
insert into items (itemTypeID, price, edition) values (2, 69.29, 4);
insert into items (itemTypeID, price, edition) values (2, 36.26, 2);
insert into items (itemTypeID, price, edition) values (2, 11.24, 2);
insert into items (itemTypeID, price, edition) values (2, 69.86, 8);
insert into items (itemTypeID, price, edition) values (2, 21.56, 7);
insert into items (itemTypeID, price, edition) values (2, 33.45, 7);
insert into items (itemTypeID, price, edition) values (2, 25.63, 8);
insert into items (itemTypeID, price, edition) values (3, 38.37, 2);
insert into items (itemTypeID, price, edition) values (3, 75.78, 7);
insert into items (itemTypeID, price, edition) values (3, 27.93, 1);
insert into items (itemTypeID, price, edition) values (3, 77.57, 10);
insert into items (itemTypeID, price, edition) values (3, 14.35, 5);
insert into items (itemTypeID, price, edition) values (3, 31.62, 9);
insert into items (itemTypeID, price, edition) values (3, 23.26, 4);
insert into items (itemTypeID, price, edition) values (3, 84.01, 7);
insert into items (itemTypeID, price, edition) values (3, 97.53, 7);
insert into items (itemTypeID, price, edition) values (3, 8.16, 8);
insert into items (itemTypeID, price, edition) values (3, 43.05, 6);
insert into items (itemTypeID, price, edition) values (3, 48.49, 8);
insert into items (itemTypeID, price, edition) values (3, 65.91, 4);
insert into items (itemTypeID, price, edition) values (3, 93.28, 7);
insert into items (itemTypeID, price, edition) values (3, 74.17, 2);
insert into items (itemTypeID, price, edition) values (3, 54.72, 9);
insert into items (itemTypeID, price, edition) values (3, 28.57, 4);
insert into items (itemTypeID, price, edition) values (3, 61.54, 2);
insert into items (itemTypeID, price, edition) values (3, 32.85, 4);
insert into items (itemTypeID, price, edition) values (3, 82.95, 6);
insert into items (itemTypeID, price, edition) values (3, 59.22, 1);
insert into items (itemTypeID, price, edition) values (3, 67.35, 7);
insert into items (itemTypeID, price, edition) values (3, 22.38, 7);
insert into items (itemTypeID, price, edition) values (3, 41.34, 8);
insert into items (itemTypeID, price, edition) values (3, 16.16, 5);
insert into items (itemTypeID, price, edition) values (3, 40.33, 2);
insert into items (itemTypeID, price, edition) values (3, 44.34, 7);
insert into items (itemTypeID, price, edition) values (3, 81.48, 3);
insert into items (itemTypeID, price, edition) values (3, 96.93, 5);
insert into items (itemTypeID, price, edition) values (3, 58.17, 8);
/* books Table */
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (1, 'My Father and My Son (Babam ve oglum)', 4, 'Rochelle', 'Gurnay', 'Gabcube', '1981-11-17');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (2, 'Gone Nutty', 10, 'Welbie', 'Kleinzweig', 'Gigazoom', '1979-08-10');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (3, 'Disneyland Dream', 5, 'Israel', 'O''Kynsillaghe', 'Rhybox', '1932-08-10');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (4, 'Until Death', 7, 'Fabiano', 'Watt', 'Aibox', '1948-01-18');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (5, 'The Great Scout & Cathouse Thursday', 1, 'Humfrey', 'Belle', 'Gabtype', '1935-12-02');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (6, 'Much Ado About Nothing', 5, 'Babbie', 'Leghorn', 'Photobean', '1978-08-01');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (7, 'Counsellor at Law', 1, 'Andriana', 'Livermore', 'Ainyx', '2000-10-21');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (8, 'Sube y Baja', 4, 'Tally', 'McElroy', 'Rhyloo', '2003-10-06');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (9, 'Yolki 2', 2, 'Rod', 'Strudwick', 'Kwideo', '1940-09-15');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (10, 'McQ', 8, 'Olly', 'Husset', 'Rhyzio', '1999-04-17');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (11, 'Four Christmases', 7, 'Gerianna', 'McCleverty', 'Trilith', '1975-09-21');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (12, 'Fired Up', 8, 'Harmonie', 'Slewcock', 'Feedfire', '1961-01-18');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (13, 'Heartbreakers', 3, 'Tuck', 'Kydd', 'Jayo', '1932-05-16');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (14, 'Blue Umbrella, The', 7, 'Palm', 'Leechman', 'Twitterwire', '1990-11-17');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (15, 'O Amor das Três Romãs', 3, 'Gussie', 'Tumility', 'Zoovu', '1992-09-17');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (16, 'Tin Drum, The (Blechtrommel, Die)', 8, 'Dyan', 'Greenough', 'Gigabox', '1987-12-09');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (17, 'Hulk Vs.', 5, 'Ivette', 'Routhorn', 'Oyoloo', '2000-08-21');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (18, 'Million Dollar Baby', 5, 'Daisey', 'Prevost', 'Vitz', '1976-08-04');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (19, 'Corruption (a.k.a. Carnage)', 4, 'Berthe', 'Purviss', 'Skipfire', '1932-10-22');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (20, 'Nico Icon', 6, 'Celeste', 'Stollwerck', 'Oyondu', '1950-05-20');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (21, 'Who Killed the Electric Car?', 10, 'Tressa', 'Brailey', 'Zoonder', '1999-12-21');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (22, 'Pekka ja Pätkä puistotäteinä', 9, 'Titus', 'Woodberry', 'Edgeclub', '1930-08-09');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (23, 'After Innocence', 8, 'Alane', 'Lanning', 'Meetz', '1941-12-23');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (24, 'Enigma of Kaspar Hauser', 1, 'Bartolemo', 'Sperwell', 'Mita', '1944-09-30');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (25, 'Flying Home', 8, 'Charlotte', 'Bizzey', 'Thoughtstorm', '1980-09-14');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (26, 'Janie Jones', 8, 'Niko', 'Keitch', 'Shuffletag', '2001-07-27');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (27, 'Much Ado About Nothing', 1, 'Riannon', 'Chard', 'Bluezoom', '2004-10-08');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (28, 'Saddest Music in the World, The', 7, 'Thaddus', 'Fannon', 'Rhyloo', '1990-05-18');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (29, 'Presumed Guilty (Presunto culpable)', 1, 'Mel', 'Baptist', 'LiveZ', '1931-12-05');
insert into books (bookID, title, genreID, authorFirst, authorLast, publisher, publishDate) values (30, 'Movie Movie', 6, 'Sax', 'Ahren', 'Buzzshare', '1981-11-14');
/* maps Table */
insert into maps (mapID, publisher, location, year) values (31, 'Voonyx', 'Tonglin', 1963);
insert into maps (mapID, publisher, location, year) values (32, 'Blogtag', 'Guanban', 1992);
insert into maps (mapID, publisher, location, year) values (33, 'Snaptags', 'Shinjō', 1983);
insert into maps (mapID, publisher, location, year) values (34, 'Gigazoom', 'Nikolayevka', 1940);
insert into maps (mapID, publisher, location, year) values (35, 'Innojam', 'Xumai', 1972);
insert into maps (mapID, publisher, location, year) values (36, 'Wikivu', 'Salamwates', 1936);
insert into maps (mapID, publisher, location, year) values (37, 'Skilith', 'Sundbyberg', 1960);
insert into maps (mapID, publisher, location, year) values (38, 'Kayveo', 'Agadez', 1923);
insert into maps (mapID, publisher, location, year) values (39, 'Cogilith', 'Tirat Karmel', 1927);
insert into maps (mapID, publisher, location, year) values (40, 'Jabberstorm', 'Volzhskiy', 1939);
insert into maps (mapID, publisher, location, year) values (41, 'Meemm', 'Cirangrang', 1904);
insert into maps (mapID, publisher, location, year) values (42, 'Photospace', 'Jishu', 1906);
insert into maps (mapID, publisher, location, year) values (43, 'Rhyzio', 'Triolet', 1906);
insert into maps (mapID, publisher, location, year) values (44, 'Youopia', 'Concepción del Bermejo', 1986);
insert into maps (mapID, publisher, location, year) values (45, 'Minyx', 'Dnipryany', 1999);
insert into maps (mapID, publisher, location, year) values (46, 'Latz', 'Văn Giang', 1993);
insert into maps (mapID, publisher, location, year) values (47, 'Aimbu', 'Leiden', 1929);
insert into maps (mapID, publisher, location, year) values (48, 'Geba', 'Dagang', 1944);
insert into maps (mapID, publisher, location, year) values (49, 'Kanoodle', 'Santa María de Jesús', 1952);
insert into maps (mapID, publisher, location, year) values (50, 'Agivu', 'Al Muharraq', 1985);
insert into maps (mapID, publisher, location, year) values (51, 'Jaxnation', 'Esplanada', 1942);
insert into maps (mapID, publisher, location, year) values (52, 'Twinte', 'Vila Chã do Monte', 1904);
insert into maps (mapID, publisher, location, year) values (53, 'Tagfeed', 'Manjing', 1988);
insert into maps (mapID, publisher, location, year) values (54, 'Kare', 'Radenka', 1921);
insert into maps (mapID, publisher, location, year) values (55, 'Oodoo', 'Kalembutillu', 1912);
insert into maps (mapID, publisher, location, year) values (56, 'Shuffledrive', 'Tessalit', 1920);
insert into maps (mapID, publisher, location, year) values (57, 'Youfeed', 'Ingenio La Esperanza', 1979);
insert into maps (mapID, publisher, location, year) values (58, 'Rooxo', 'Bang Racham', 1922);
insert into maps (mapID, publisher, location, year) values (59, 'Dabfeed', 'Kakamega', 1914);
insert into maps (mapID, publisher, location, year) values (60, 'Feedspan', 'Meziměstí', 1901);
/* periodicals Table */
insert into periodicals (periodicalID, companyName, title, genreID, date) values (61, 'Camimbo', 'New York Times', 8, '2008-07-05');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (62, 'Skinder', 'Forbes', 5, '1999-10-31');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (63, 'Pixonyx', 'Time', 3, '2011-09-05');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (64, 'Livefish', 'Toronto Sun', 3, '2008-02-18');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (65, 'Twiyo', 'National Geographic', 10, '2006-06-13');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (66, 'Realmix', 'Suzhou River', 4, '2005-06-05');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (67, 'Trudoo', 'White House Down', 9, '2015-02-26');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (68, 'Divavu', 'Fly Away Home', 8, '1995-10-11');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (69, 'Photolist', 'Alone with Her', 3, '2006-07-31');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (70, 'Ozu', 'Center Stage', 7, '2003-12-29');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (71, 'Browsetype', 'Smooth Talk', 5, '2001-04-15');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (72, 'Oloo', 'Between Two Worlds', 2, '1996-01-01');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (73, 'Kwilith', 'Farmers Daughter', 6, '2017-03-31');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (74, 'Divape', 'Beach Party', 9, '1995-08-01');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (75, 'Kazu', '3 Ninjas Knuckle Up', 4, '1994-04-16');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (76, 'Ntag', 'Goddess (Devi)', 3, '2008-03-24');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (77, 'Roodel', 'Step Up Revolution', 1, '2009-11-30');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (78, 'Voolith', 'Cabinet of Dr. Ramirez, The', 9, '1997-10-29');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (79, 'Tagfeed', 'Body Double', 2, '2006-06-29');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (80, 'Zoozzy', 'Lucy', 9, '2008-03-26');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (81, 'Shuffledrive', 'Stranger on the Prowl', 3, '2014-07-11');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (82, 'Centizu', 'Keane', 5, '2009-04-27');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (83, 'Tagchat', 'Terri', 9, '2002-05-23');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (84, 'Quaxo', 'Laffghanistan: Comedy Down Range', 7, '2000-01-18');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (85, 'Innojam', 'That Obscure Object of Desire', 10, '2015-12-09');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (86, 'Kamba', 'Right at Your Door', 3, '2010-01-06');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (87, 'Agimba', 'Good Work', 4, '2006-01-04');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (88, 'Oba', 'Secret Admirer', 2, '1993-02-06');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (89, 'Buzzbean', 'Peggy Sue Got Married', 7, '2007-07-01');
insert into periodicals (periodicalID, companyName, title, genreID, date) values (90, 'Mita', 'Loins of Punjab Presents', 5, '2008-04-19');
/* customers Table */
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
insert into customers (customerTypeID, firstName, lastName, phoneNumber) values (2, 'Dannie', 'Blesing', '7777917741');
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
insert into itemTags (itemID, tagID) values (1, 9);
insert into itemTags (itemID, tagID) values (2, 8);
insert into itemTags (itemID, tagID) values (3, 3);
insert into itemTags (itemID, tagID) values (4, 3);
insert into itemTags (itemID, tagID) values (5, 7);
insert into itemTags (itemID, tagID) values (6, 10);
insert into itemTags (itemID, tagID) values (7, 1);
insert into itemTags (itemID, tagID) values (8, 5);
insert into itemTags (itemID, tagID) values (9, 8);
insert into itemTags (itemID, tagID) values (10, 8);
insert into itemTags (itemID, tagID) values (11, 3);
insert into itemTags (itemID, tagID) values (12, 10);
insert into itemTags (itemID, tagID) values (13, 6);
insert into itemTags (itemID, tagID) values (14, 3);
insert into itemTags (itemID, tagID) values (15, 6);
insert into itemTags (itemID, tagID) values (16, 2);
insert into itemTags (itemID, tagID) values (17, 9);
insert into itemTags (itemID, tagID) values (18, 3);
insert into itemTags (itemID, tagID) values (19, 7);
insert into itemTags (itemID, tagID) values (20, 4);
insert into itemTags (itemID, tagID) values (21, 3);
insert into itemTags (itemID, tagID) values (22, 8);
insert into itemTags (itemID, tagID) values (23, 3);
insert into itemTags (itemID, tagID) values (24, 5);
insert into itemTags (itemID, tagID) values (25, 8);
insert into itemTags (itemID, tagID) values (26, 7);
insert into itemTags (itemID, tagID) values (27, 8);
insert into itemTags (itemID, tagID) values (28, 5);
insert into itemTags (itemID, tagID) values (29, 9);
insert into itemTags (itemID, tagID) values (30, 5);
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

insert into employeeAccount (username, employeeID, password, dateCreated, lastAccess) values ('connor123', 1, '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '11/11/2000', '11/11/2000');
insert into employeeAccount (username, employeeID, password, dateCreated, lastAccess) values ('test', 2, '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '11/11/2000', '11/11/2000');

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
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (1, 69, 1, 97.53);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (2, 77, 2, 57.06);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (3, 11, 3, 115.92);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (4, 79, 2, 65.64);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (5, 82, 2, 134.70);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (6, 32, 3, 91.80);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (7, 80, 1, 15.48);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (8, 58, 1, 21.56);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (9, 36, 3, 22.68);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (10, 58, 1, 64.68);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (11, 23, 2, 158.18);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (12, 24, 3, 176.28);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (13, 71, 1, 43.05);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (14, 67, 2, 46.52);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (15, 21, 3, 22.71);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (16, 43, 3, 151.11);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (17, 79, 3, 98.55);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (18, 43, 1, 50.37);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (19, 11, 1, 38.64);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (20, 84, 2, 82.68);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (21, 85, 1, 16.16);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (22, 27, 1, 72.51);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (23, 81, 2, 118.44);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (24, 88, 1, 81.48);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (25, 48, 1, 65.27);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (26, 52, 1, 92.40);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (27, 73, 1, 65.91);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (28, 28, 1, 64.95);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (29, 32, 3, 91.80);
insert into [transaction] (invoiceID, itemID, quantity, totalPrice) values (30, 88, 1, 81.48);