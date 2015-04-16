CREATE DATABASE OrderManagement
GO

USE OrderManagement
GO

CREATE TABLE Customer
(
	CustomerId	INT				NOT NULL	IDENTITY (1, 1),
	Name		NVARCHAR(100)	NOT NULL,
	[Address]	NVARCHAR(256)	NULL,
	CONSTRAINT PK_Customer PRIMARY KEY (CustomerId)
)
GO

CREATE TABLE Product
(
	ProductId	INT				NOT NULL	IDENTITY (1, 1),
	Name		NVARCHAR(100)	NOT NULL,
	UnitPrice	MONEY			NOT NULL,
	CONSTRAINT PK_Product PRIMARY KEY (ProductId)
)
GO

CREATE TABLE [Order]
(
	OrderId		INT				NOT NULL	IDENTITY (1, 1),
	CustomerId	INT				NOT NULL,
	OrderDate	DATETIME		NOT NULL,
	CONSTRAINT PK_Order PRIMARY KEY (OrderId),
	CONSTRAINT FK_Order_Customer FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
)
GO

CREATE TABLE OrderItem
(
	OrderId		INT				NOT NULL,
	ProductId	INT				NOT NULL,
	Quantity	INT				NOT NULL,
	CONSTRAINT PK_OrderItem PRIMARY KEY (OrderId, ProductId),
	CONSTRAINT FK_OrderItem_Order FOREIGN KEY (OrderId) REFERENCES [Order](OrderId),
	CONSTRAINT FK_OrderItem_Product FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
)
GO

CREATE INDEX IX_Order_CustomerId
ON [Order](CustomerId);

CREATE INDEX IX_Order_OrderDate
ON [Order](OrderDate);
GO

use OrderManagement;
Go
INSERT INTO CUSTOMER(Name, [Address])
VALUES
	('John Smith', 'Bellevue, WA'),
	('Pual Abebe', 'Seattle, WA'),
	('Yalew Kebede', 'Redmond, WA'),
	('Michael Belayneh', 'Renton, WA')

INSERT INTO product(Name, UnitPrice)
VALUES
	('Orange', $1.00),
	('Avocado', $3.00)

select * FROM [OrderManagement].[dbo].[Order]
select * FROM [OrderManagement].[dbo].[Customer]
select * FROM [OrderManagement].[dbo].[OrderItem]

INSERT INTO [Order](CustomerId, OrderDate)
VALUES
	(1, '1/4/2010'),
	(1, '2/4/2010'),
	(2, '3/4/2010'),
	(3, '1/4/2010'),
	(3, '2/4/2011'),
	(3, '3/4/2012'),
	(4, '1/4/2010'),
	(4, '2/4/2011'),
	(4, '3/4/2012'),
	(1, '1/4/2013'),
	(1, '2/4/2014'),
	(1, '3/4/2015'),
	(2, '1/4/2013'),
	(2, '2/4/2014'),
	(2, '3/4/2015'),
	(3, '1/4/2013'),
	(3, '2/4/2014'),
	(3, '3/4/2015'),
	(4, '1/4/2013'),
	(4, '2/4/2014'),
	(4, '3/4/2015')

INSERT INTO OrderItem(OrderId, ProductId, Quantity)
VALUES
	(1, 1, 8),
	(1, 2, 6),
	(2, 1, 11),
	(2, 2, 23),
	(3, 1, 18),
	(3, 2, 7),
	(4, 1, 8),
	(4, 2, 6),
	(5, 1, 11),
	(5, 2, 23),
	(6, 1, 18),
	(7, 1, 8),
	(7, 2, 6),
	(8, 1, 11),
	(9, 2, 23),
	(9, 1, 18),
	(10, 1, 8),
	(10, 2, 6),
	(11, 1, 11),
	(11, 2, 23),
	(12, 1, 18),
	(12, 2, 8),
	(13, 2, 6),
	(14, 1, 11),
	(14, 2, 23),
	(15, 1, 18),
	(16, 1, 8),
	(16, 2, 6),
	(17, 1, 11),
	(18, 2, 23),
	(19, 1, 18),
	(19, 2, 8),
	(20, 2, 6),
	(21, 1, 11),
	(21, 2, 23)


--INSERT INTO [Order](CustomerId, OrderDate) VALUES({0}, '{1}')
--                    SELECT SCOPE_IDENTITY() AS OrderId;

-- OrderId, CustomerId, CustomerName, OrderDate	-- , TotalPrice	-- TODO