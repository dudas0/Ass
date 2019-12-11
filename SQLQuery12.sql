ALTER PROC AddUser
@FName varchar(100),
@LName varchar(100),
@Email varchar(100),
@Nick varchar(100),
@Password varchar(100)
AS
	INSERT INTO tableUser(FName,LName,Email,Nick,Password)
	VALUES (@FName,@LName,@Email,@Nick,@Password)