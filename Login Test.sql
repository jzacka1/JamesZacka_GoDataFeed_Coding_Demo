
USE [ShoppingTestDb]
GO

DECLARE @pass varchar(50) = 'pass'
DECLARE @id int = 1
Declare @salt varchar(36) = (SELECT [Salt] From [dbo].[Customers] WHERE [ID] = @id)

DECLARE @hash varbinary(MAX) = (SELECT [Password] From [dbo].[Customers] WHERE [ID] = @id)

Declare @passAndSalt varchar(90) = @pass + @salt

if (@hash = HASHBYTES('SHA2_512', @passAndSalt))
	BEGIN
		PRINT 'Access Granted'

		SET @salt = NEWID();
		SET @passAndSalt = @pass + @salt

		UPDATE [dbo].[Customers]
		SET [salt] = @salt,
		[Password] = HASHBYTES('SHA2_512', @passAndSalt)
		WHERE [ID] = @id
	END
else
	PRINT 'Access Denied'