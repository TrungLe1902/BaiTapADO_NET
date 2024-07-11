USE ShopDB;
GO
CREATE TABLE Products
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CategoryId INT,
    Name NVARCHAR(50),
    CPU NVARCHAR(50),
    ScreenSize NVARCHAR(50),
    RAM NVARCHAR(50),
    Price INT
)

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(255) NOT NULL
);

INSERT INTO Categories (CategoryName)
VALUES (N'Máy tính xách tay');

INSERT INTO Products (Id, CategoryId, Name, CPU, ScreenSize, RAM, Price)
VALUES
    (1, 1, N'Máy tính DELL X1', 'core i5', '15 inch', '8GB', 10000000),
    (2, 1, N'Máy tính DELL X1', 'core i7', '15 inch', '16GB', 15000000),
    (3, 1, N'Máy tính DELL X1', 'core i9', '15 inch', '32GB', 20000000);

-- Stored Procedure: Thêm danh mục
CREATE PROCEDURE AddCategory
    @CategoryName NVARCHAR(100)
AS
BEGIN
    INSERT INTO Categories (CategoryName)
    VALUES (@CategoryName);
END

-- Stored Procedure: Thêm sản phẩm
CREATE PROCEDURE AddProduct
    @Id INT,
    @CategoryId INT,
    @Name NVARCHAR(100),
    @CPU NVARCHAR(50),
    @ScreenSize NVARCHAR(50),
    @RAM INT,
    @Price INT
AS
BEGIN
    INSERT INTO Products (Id, CategoryId, Name, CPU, ScreenSize, RAM, Price)
    VALUES (@Id, @CategoryId, @Name, @CPU, @ScreenSize, @RAM, @Price);
END

-- Stored Procedure: Sửa sản phẩm
CREATE PROCEDURE UpdateProduct
    @Id INT,
    @CategoryId INT,
    @Name NVARCHAR(100),
    @CPU NVARCHAR(50),
    @ScreenSize NVARCHAR(50),
    @RAM INT,
    @Price INT
AS
BEGIN
    UPDATE Products
    SET CategoryId = @CategoryId,
        Name = @Name,
        CPU = @CPU,
        ScreenSize = @ScreenSize,
        RAM = @RAM,
        Price = @Price
    WHERE Id = @Id;
END
-- Stored Procedure: Xóa sản phẩm
CREATE PROCEDURE DeleteProduct
    @Id INT
AS
BEGIN
    DELETE FROM Products
    WHERE Id = @Id;
END
GO

--Stored Procedure: Hiển thị sản phẩm
CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SELECT Id, CategoryId, Name, CPU, ScreenSize, RAM, Price
    FROM Products;
END
GO


ALTER TABLE Products
ALTER COLUMN Price INT;