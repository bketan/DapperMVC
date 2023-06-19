Create
use ProductDemo
create table dbo.Product(


create procedure sp_create_product
(@ProductName nvarchar(50), @ProductDesc nvarchar(100), @price int, @Qty int)

as begin
	insert into dbo.Product (ProductName,ProductDesc,Price,Qty) values (@ProductName,@ProductDesc,@price,@Qty) 
	end

create procedure sp_update_product
(@ProductID int,@ProductName nvarchar(50), @ProductDesc nvarchar(100), @price int, @Qty int)

as begin
	update dbo.Product set ProductName = @ProductName,ProductDesc=@ProductDesc,Price=@Price, Qty=@Qty
	where ProductID = @ProductID
	end

create procedure sp_get_product
(@ProductID int)

as begin
	select * from dbo.Product
	where ProductID = @ProductID
	end

create procedure sp_get_products

as begin
	select * from dbo.Product
	end

create procedure sp_delete_product
(@ProductID int)

as begin
	delete from dbo.Product
	where ProductID = @ProductID
	end
