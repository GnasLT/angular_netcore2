create DATABASE saledb;
use saledb;

-- Bảng Users
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    FullName NVARCHAR(100),
    Role NVARCHAR(20) NOT NULL DEFAULT 'customer'
        CHECK (Role IN ('customer', 'seller', 'admin')),
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

-- Bảng Sessions
CREATE TABLE Sessions (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- sessionId
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id) ON DELETE CASCADE,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    ExpiresAt DATETIME2 NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1
);

-- Bảng Products
CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(12,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

-- Bảng Orders
CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

-- Bảng OrderItems
CREATE TABLE OrderItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(Id) ON DELETE CASCADE,
    ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(12,2) NOT NULL
);

INSERT INTO Users (Username, PasswordHash, Email, FullName, Role)
VALUES
(N'customer', N'123456', N'customer@example.com', N'customer Nguyen', N'customer'),
(N'Seller',   N'123456', N'seller@example.com',   N'seller Tran',    N'seller'),
(N'admin',    N'123456', N'admin@example.com',    N'System Admin',   N'admin');

-- Insert Products
INSERT INTO Products (Name, Description, Price, Stock)
VALUES
(N'iPhone 15',        N'Apple smartphone 256GB', 29990000, 10),
(N'Samsung Galaxy S24', N'Samsung flagship 256GB', 25990000, 15),
(N'MacBook Air M2',   N'Apple laptop M2 13 inch', 32990000, 5),
(N'Logitech Mouse',   N'Wireless mouse',          499000, 100);

-- Insert Orders
INSERT INTO Orders (UserId) VALUES (1);
INSERT INTO Orders (UserId) VALUES (2);

-- Insert OrderItems
INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price)
VALUES
(1, 1, 1, 29990000), -- iPhone
(1, 4, 1,   499000), -- Mouse
(2, 3, 1, 32990000); -- MacBook