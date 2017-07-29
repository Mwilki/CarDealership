USE master
GO

IF EXISTS(
	SELECT *
	FROM sys.databases
	WHERE name='CarDealership')
DROP DATABASE Cardealership
GO

CREATE DATABASE CarDealership
GO