# DapperMVC
ASP.NET Core MVCRUD with dapper and MSSQL stored procedures 

1] using Database first approch first database named ProductDemo is created then using it table named dbo.Product is created as per following query
 create table dbo.Product(
ProductID int primary key identity,
ProductName nvarchar(50) not null,
ProductDesc nvarchar(100) not null,
Price int, Qty int )
2] Stored Procedures are created
 a) Stored Procedure for Adding records ->
    create procedure sp_create_product
    (@ProductName nvarchar(50), @ProductDesc nvarchar(100), @price int, @Qty int)
    as begin
	  insert into dbo.Product (ProductName,ProductDesc,Price,Qty) values (@ProductName,@ProductDesc,@price,@Qty) 
	  end
b) Stored Procedure for updating records ->
  create procedure sp_update_product
  (@ProductID int,@ProductName nvarchar(50), @ProductDesc nvarchar(100), @price int, @Qty int)
  as begin
	update dbo.Product set ProductName = @ProductName,ProductDesc=@ProductDesc,Price=@Price, Qty=@Qty where ProductID = @ProductID
	end
c) Stored Procedure for retrieving single record ->
  create procedure sp_get_product
  (@ProductID int)
  as begin
	select * from dbo.Product where ProductID = @ProductID
	end
d) Stored Procedure for retrieving all records ->
  create procedure sp_get_products
  as begin
	select * from dbo.Product
	end
e) Stored Procedure for deleting a record ->
  create procedure sp_delete_product
  (@ProductID int)
  as begin
	delete from dbo.Product where ProductID = @ProductID
	end
 3] Connection String for connecting database with backend is written in appsetting.json file
 4] Dapper and other required packages are installed
 5] Create a new folder inside the project name called “Models” and add a new class which should have product’s id, name, Qty and price. 
 6] Repository Interface is created and all methods are overridden in the corresponding class.
 7] Controller class is written then finally
 8] Views are created which will display our records on frontend.
 SNAPSHOTS of the Projects =>
 
 ![DapperMVC — Mozilla Firefox 20-06-2023 00_24_41](https://github.com/bketan/DapperMVC/assets/113464974/ca01daed-19ea-4299-be31-45399bccfb5a)
![DapperMVC — Mozilla Firefox 20-06-2023 00_27_18](https://github.com/bketan/DapperMVC/assets/113464974/8764a5dd-0bb5-4474-9e53-bbd17bfa8389)
![DapperMVC — Mozilla Firefox 20-06-2023 00_28_10](https://github.com/bketan/DapperMVC/assets/113464974/e4a2fd9c-5470-495a-9232-13abfa857f14)
![DapperMVC — Mozilla Firefox 20-06-2023 00_28_40](https://github.com/bketan/DapperMVC/assets/113464974/dad29a23-1158-437e-9982-5211bfb3f38a)
