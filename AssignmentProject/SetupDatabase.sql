-- ============================================
-- Grifindo Toy Store Database Setup Script
-- ============================================

-- Create Database if not exists
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Grifindo')
BEGIN
    CREATE DATABASE Grifindo;
    PRINT 'Database Grifindo created successfully!';
END
ELSE
BEGIN
    PRINT 'Database Grifindo already exists!';
END
GO

USE Grifindo;
GO

-- ============================================
-- Create Login Table
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Login]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Login](
        [ID] [int] IDENTITY(1,1) NOT NULL,
        [UserName] [nvarchar](50) NOT NULL,
        [Password] [nvarchar](50) NOT NULL,
        [Role] [nvarchar](50) NOT NULL,
        CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([ID] ASC)
    );
    PRINT 'Table Login created successfully!';
END
ELSE
BEGIN
    PRINT 'Table Login already exists!';
END
GO

-- Insert default admin user if not exists
IF NOT EXISTS (SELECT * FROM [dbo].[Login] WHERE [UserName] = 'admin')
BEGIN
    INSERT INTO [dbo].[Login] ([UserName], [Password], [Role]) VALUES ('admin', 'admin123', 'Admin');
    INSERT INTO [dbo].[Login] ([UserName], [Password], [Role]) VALUES ('user', 'user123', 'User');
    PRINT 'Default users inserted!';
END
GO

-- ============================================
-- Create Registration (Employee) Table
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Registration]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Registration](
        [SerialNo] [int] IDENTITY(1,1) NOT NULL,
        [EmpID] [nvarchar](20) NOT NULL,
        [EmpName] [nvarchar](100) NOT NULL,
        [DOB] [datetime] NOT NULL,
        [Gender] [nvarchar](10) NOT NULL,
        [CS] [nvarchar](20) NOT NULL,
        [ConNo] [nvarchar](15) NOT NULL,
        [NIC] [nvarchar](20) NOT NULL,
        [EAddress] [nvarchar](200) NOT NULL,
        [Email] [nvarchar](100) NOT NULL,
        [MSal] [decimal](18, 2) NOT NULL,
        [ORate] [decimal](18, 2) NOT NULL,
        [Allowance] [decimal](18, 2) NOT NULL,
        CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED ([SerialNo] ASC)
    );
    PRINT 'Table Registration created successfully!';
END
ELSE
BEGIN
    PRINT 'Table Registration already exists!';
END
GO

-- ============================================
-- Create Setting Table
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Setting](
        [ID] [int] IDENTITY(1,1) NOT NULL,
        [DRange] [int] NOT NULL,
        [SCBeginDate] [datetime] NOT NULL,
        [SCEndDate] [datetime] NOT NULL,
        [NLeaves] [int] NOT NULL,
        [GovRange] [decimal](18, 2) NOT NULL,
        CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED ([ID] ASC)
    );
    PRINT 'Table Setting created successfully!';
END
ELSE
BEGIN
    PRINT 'Table Setting already exists!';
END
GO

-- Insert default settings if not exists
IF NOT EXISTS (SELECT * FROM [dbo].[Setting])
BEGIN
    INSERT INTO [dbo].[Setting] ([DRange], [SCBeginDate], [SCEndDate], [NLeaves], [GovRange]) 
    VALUES (30, '2024-01-01', '2024-12-31', 14, 10.00);
    PRINT 'Default settings inserted!';
END
GO

-- ============================================
-- Create Salary Table
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Salary]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Salary](
        [ID] [int] IDENTITY(1,1) NOT NULL,
        [EmpID] [nvarchar](20) NOT NULL,
        [EMonth] [nvarchar](20) NOT NULL,
        [DRange] [int] NOT NULL,
        [BeginDate] [datetime] NOT NULL,
        [EndDate] [datetime] NOT NULL,
        [NoOfLeaves] [int] NOT NULL,
        [NoOfAbDays] [int] NOT NULL,
        [NoOfHoliDays] [int] NOT NULL,
        [OTWH] [decimal](18, 2) NOT NULL,
        [BasePay] [decimal](18, 2) NOT NULL,
        [NoPay] [decimal](18, 2) NOT NULL,
        [GrossPay] [decimal](18, 2) NOT NULL,
        CONSTRAINT [PK_Salary] PRIMARY KEY CLUSTERED ([ID] ASC)
    );
    PRINT 'Table Salary created successfully!';
END
ELSE
BEGIN
    PRINT 'Table Salary already exists!';
END
GO

PRINT '========================================';
PRINT 'Database Setup Completed Successfully!';
PRINT '========================================';
GO
