USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'ChatDB'
)
CREATE DATABASE [ChatDB]
GO

USE [ChatDB]
GO

-- Create a new table called 'Users' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
DROP TABLE dbo.Users
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Users
(
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, -- primary key column
    Username [NVARCHAR](50) NOT NULL,
    Password [NVARCHAR](250) NOT NULL,
    Salt [NVARCHAR](250) NOT NULL,
    ImageUrl [NVARCHAR](250) NULL,
    Created [Datetime] NOT NULL,
    LastLoggedIn [Datetime] NOT NULL
);
GO

-- Create a new table called 'Rooms' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Rooms', 'U') IS NOT NULL
DROP TABLE dbo.Rooms
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Rooms
(
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, -- primary key column
    Name [NVARCHAR](50) NOT NULL,
    Password [NVARCHAR](250) NOT NULL,
    Salt [NVARCHAR](250) NOT NULL,
    FOREIGN Key (OwnerId) REFERENCES dbo.Users(Id)
    -- specify more columns here
);
GO