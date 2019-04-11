USE [ShoppingTestDb]
GO

DECLARE @id int

Declare @pass varchar(50)
Declare @salt varchar(36)
Declare @passAndSalt varchar(90)

Declare db_Cursor CURSOR FOR
Select ID from [dbo].[Customers]

OPEN db_Cursor
FETCH NEXT FROM db_Cursor INTO @id

WHILE @@FETCH_STATUS = 0
BEGIN
	SET @pass = 'pass'
	SET @salt = NEWID()

	SET @passAndSalt  = @pass + @salt

	--<algorithm>::= MD2 | MD4 | MD5 | SHA | SHA1 | SHA2_256 | SHA2_512

	UPDATE [dbo].[Customers]
	SET [salt] = @salt,
	[Password] = HASHBYTES('SHA2_512', @passAndSalt)
	WHERE [ID] = @id
	SELECT SCOPE_IDENTITY();
	FETCH NEXT FROM db_Cursor INTO @id
END

CLOSE db_Cursor
DEALLOCATE db_Cursor