CREATE DATABASE PizzaStoreDB;
GO
CREATE SCHEMA PS;
GO

-- DROP TABLE PS.Users;

CREATE TABLE PS.Users 
(
	ID INT IDENTITY NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
);

GO
CREATE TABLE PS.UserLocation 
(
	ID INT IDENTITY NOT NULL,
	UserID INT NOT NULL,
	Address NVARCHAR(128) NOT NULL,
	State NVARCHAR(128) NOT NULL
);
GO
-- DROP TABLE PS.Orders;

CREATE TABLE PS.Orders
(
	ID INT IDENTITY NOT NULL,
	UserLocationID INT NOT NULL,
	ShopID INT NOT NULL,
	OrderTime DATETIME2 NOT NULL,
	TotalDue FLOAT NOT NULL
);
GO
CREATE TABLE PS.Store
(
	ID INT IDENTITY NOT NULL,
	Address NVARCHAR(128) NOT NULL,
	State NVARCHAR(128) NOT NULL
);
GO

CREATE TABLE PS.Ingredients 
(
	ID INT IDENTITY NOT NULL,
	Name NVARCHAR(128) NOT NULL,
	StockNumber INT NOT NULL,
	StoreID INT NOT NULL,
);

GO
-- DROP TABLE PS.Product;
CREATE TABLE PS.PizzaIngredients
(
	ID INT IDENTITY NOT NULL,
	Name NVARCHAR(128) NOT NULL,
	IngredientID INT NOT NULL,
	PizzaID INT NOT NULL
);

GO

CREATE TABLE PS.Pizza
(
	ID INT IDENTITY NOT NULL,
	Name NVARCHAR(128) NOT NULL,
	CrustType NVARCHAR(128) NOT NULL,
	LinePrice MONEY NOT NULL
);
-- DROP TABLE PS.Location;
GO
CREATE TABLE PS.PizzaOrder 
(
	ID INT IDENTITY NOT NULL,
	OrderID INT NOT NULL,
	PizzaID INT NOT NULL
);


-------------------- START OF ASSIGNING PRIMARY KEYS -----------------------------
ALTER TABLE PS.Users ADD
	CONSTRAINT PK_Users_ID PRIMARY KEY (ID);
GO

ALTER TABLE PS.UserLocation  ADD
	CONSTRAINT PK_User_Location_ID PRIMARY KEY (ID);
GO

ALTER TABLE PS.Orders ADD
	CONSTRAINT PK_Orders_ID PRIMARY KEY (ID);
GO

ALTER TABLE PS.Store ADD
	CONSTRAINT PK_Store_ID PRIMARY KEY (ID);
GO

ALTER TABLE PS.Ingredients ADD
	CONSTRAINT PK_Ingredients_ID PRIMARY KEY (ID);
GO

ALTER TABLE PS.PizzaIngredients ADD
	CONSTRAINT PK_Pizza_Ingredients_ID PRIMARY KEY (ID);
GO

ALTER TABLE PS.Pizza ADD
	CONSTRAINT PK_Pizza_ID PRIMARY KEY (ID);
GO

ALTER TABLE PS.PizzaOrder ADD
	CONSTRAINT PK_Pizza_Order_ID PRIMARY KEY (ID);
GO

-------------------- START OF ASSIGNING FOREIGN KEYS -----------------------------

ALTER TABLE PS.UserLocation 
	ADD CONSTRAINT FK_User_Location
	FOREIGN KEY (UserID) REFERENCES PS.Users (ID);

GO

ALTER TABLE PS.Orders 
	ADD CONSTRAINT FK_Orders_User_Address
	FOREIGN KEY (UserLocationID) REFERENCES PS.UserLocation (ID);

GO

ALTER TABLE PS.Orders 
	ADD CONSTRAINT FK_Store_Address
	FOREIGN KEY (ShopID) REFERENCES PS.Store (ID);

GO

ALTER TABLE PS.Ingredients 
	ADD CONSTRAINT FK_Store_Ingredients
	FOREIGN KEY (StoreID) REFERENCES PS.Store (ID);

GO

ALTER TABLE PS.PizzaIngredients
	ADD CONSTRAINT FK_Pizza_Ingredients_ID
	FOREIGN KEY (IngredientID) REFERENCES PS.Ingredients (ID);

GO

ALTER TABLE PS.Pizza
ADD PizzaIngredientID INT NOT NULL;

GO

SELECT *
FROM PS.Pizza;

GO

ALTER TABLE PS.PizzaIngredients
	ADD CONSTRAINT FK_Pizza_ID_With_Ingredients
	FOREIGN KEY (PizzaID) REFERENCES PS.Pizza (ID);

GO
ALTER TABLE PS.PizzaOrder
	ADD CONSTRAINT FK_Pizza_Order_ID
	FOREIGN KEY (PizzaID) REFERENCES PS.Pizza (ID);

GO
ALTER TABLE PS.PizzaOrder
	ADD CONSTRAINT FK_Orders_ID
	FOREIGN KEY (OrderID) REFERENCES PS.Orders (ID);

INSERT INTO PS.Users(FirstName, LastName) VALUES
('Axel', 'Tovar'),
('Malcom', 'McCormick'),
('Will', 'Smith'),
('Elon', 'Musk');

INSERT INTO PS.UserLocation(UserID, Address, State) VALUES
((SELECT TOP(1)ID FROM PS.Users WHERE ID = 1), '211 Farmer Rd.', 'TX'),
((SELECT TOP(1)ID FROM PS.Users WHERE ID = 2), '314 Wings Dr.', 'PA'),
((SELECT TOP(1)ID FROM PS.Users WHERE ID = 3), '956 Bel Air.', 'CA'),
((SELECT TOP(1)ID FROM PS.Users WHERE ID = 4), '111 Silicon Valey', 'CA');

INSERT INTO PS.Store(Address, State) VALUES
('201 South Street', 'TX'),
('417 E. Arlington Road', 'TX'),
('808 First Street', 'CA'),
('606 Second Street', 'CA');
GO

SELECT *
FROM PS.Ingredients;
-- ALTER TABLE PS.PizzaIngredients DROP COLUMN Name;
GO


INSERT INTO PS.Ingredients(Name, StockNumber, StoreID) VALUES
('Pepperoni', 5, (SELECT TOP(1)ID FROM PS.Store WHERE ID = 1)),
('Pepperoni', 4, (SELECT TOP(1)ID FROM PS.Store WHERE ID = 2)),
('Cheese', 10, (SELECT TOP(1)ID FROM PS.Store WHERE ID = 1)),
('Cheese', 4, (SELECT TOP(1)ID FROM PS.Store WHERE ID = 2)),
('Bacon', 7, (SELECT TOP(1)ID FROM PS.Store WHERE ID = 1)),
('Bacon', 5, (SELECT TOP(1)ID FROM PS.Store WHERE ID = 2));

GO

ALTER TABLE PS.Pizza
ADD PizzaIngredientID INT NOT NULL;

GO
INSERT INTO PS.Pizza(Name, CrustType, LinePrice) VALUES
('Large', 'Stuffed Crust', 10.50),
('Deep Dish', 'Regular', 9.50),
('Medium', 10, (SELECT TOP(1)ID FROM PS.Store WHERE ID = 1)),
('Cheese', 4, (SELECT TOP(1)ID FROM PS.Store WHERE ID = 2)),
('Bacon', 7, (SELECT TOP(1)ID FROM PS.Store WHERE ID = 1)),
('Bacon', 5, (SELECT TOP(1)ID FROM PS.Store WHERE ID = 2));

GO

SELECT *
FROM PS.Users
	INNER JOIN PS.UserLocation AS ul ON PS.Users.ID = ul.UserID
WHERE PS.Users.ID = ul.UserID;