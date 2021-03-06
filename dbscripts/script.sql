USE [master]
GO
/****** Object:  Database [Mentoring]    Script Date: 7/24/2015 5:48:53 PM ******/
CREATE DATABASE [Mentoring]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mentoring', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\Mentoring.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Mentoring_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\Mentoring_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Mentoring] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mentoring].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mentoring] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mentoring] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mentoring] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mentoring] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mentoring] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mentoring] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mentoring] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mentoring] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mentoring] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mentoring] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mentoring] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mentoring] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mentoring] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mentoring] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mentoring] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mentoring] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mentoring] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mentoring] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mentoring] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mentoring] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mentoring] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mentoring] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mentoring] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mentoring] SET  MULTI_USER 
GO
ALTER DATABASE [Mentoring] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mentoring] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mentoring] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mentoring] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Mentoring] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Mentoring]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](100) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[employee]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[id] [nvarchar](50) NULL,
	[employee] [nvarchar](50) NULL,
	[gender] [nvarchar](50) NULL,
	[birthdate] [datetime] NULL,
	[address] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProducts]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProducts](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Desc] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_tblProducts] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTransactionDetails]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransactionDetails](
	[Transaction_Details_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_ID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_tblTransactionDetails] PRIMARY KEY CLUSTERED 
(
	[Transaction_Details_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTransactions]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransactions](
	[Transaction_ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL CONSTRAINT [DF_tblTransactions_Date]  DEFAULT (getdate()),
	[Customer_ID] [int] NOT NULL,
 CONSTRAINT [PK_tblTransactions] PRIMARY KEY CLUSTERED 
(
	[Transaction_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (1, N'Joe-An Enriquez', N'Pasay City')
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (2, N'Jojo Aquino Jr.', N'Mandaluyong City')
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (3, N'MD Monir', N'Quezon City')
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (4, N'Anacquels Lumbres', N'Makati City')
SET IDENTITY_INSERT [dbo].[Customer] OFF
INSERT [dbo].[employee] ([id], [employee], [gender], [birthdate], [address]) VALUES (N'1', N'a', N'a', CAST(N'2015-07-24 00:00:00.000' AS DateTime), N'a')
INSERT [dbo].[employee] ([id], [employee], [gender], [birthdate], [address]) VALUES (N'2', N'b', N'b', CAST(N'2015-07-24 00:00:00.000' AS DateTime), N'b')
INSERT [dbo].[employee] ([id], [employee], [gender], [birthdate], [address]) VALUES (N'3', N'c', N'c', CAST(N'2015-07-24 00:00:00.000' AS DateTime), N'c')
SET IDENTITY_INSERT [dbo].[tblProducts] ON 

INSERT [dbo].[tblProducts] ([Product_ID], [Product_Desc], [Price]) VALUES (1, N'Monitor', 5000)
INSERT [dbo].[tblProducts] ([Product_ID], [Product_Desc], [Price]) VALUES (2, N'Mouse', 100)
INSERT [dbo].[tblProducts] ([Product_ID], [Product_Desc], [Price]) VALUES (3, N'Keyboard', 300)
INSERT [dbo].[tblProducts] ([Product_ID], [Product_Desc], [Price]) VALUES (4, N'CPU', 7000)
INSERT [dbo].[tblProducts] ([Product_ID], [Product_Desc], [Price]) VALUES (5, N'RAM', 4000)
INSERT [dbo].[tblProducts] ([Product_ID], [Product_Desc], [Price]) VALUES (6, N'Video Card', 2000)
INSERT [dbo].[tblProducts] ([Product_ID], [Product_Desc], [Price]) VALUES (7, N'Mouse Pad', 50)
INSERT [dbo].[tblProducts] ([Product_ID], [Product_Desc], [Price]) VALUES (8, N'LAN', 30)
INSERT [dbo].[tblProducts] ([Product_ID], [Product_Desc], [Price]) VALUES (10, N'External Drive', 3000)
INSERT [dbo].[tblProducts] ([Product_ID], [Product_Desc], [Price]) VALUES (11, N'Fan', 700)
SET IDENTITY_INSERT [dbo].[tblProducts] OFF
SET IDENTITY_INSERT [dbo].[tblTransactionDetails] ON 

INSERT [dbo].[tblTransactionDetails] ([Transaction_Details_ID], [Product_ID], [Quantity]) VALUES (2, 1, 15)
INSERT [dbo].[tblTransactionDetails] ([Transaction_Details_ID], [Product_ID], [Quantity]) VALUES (3, 5, 40)
INSERT [dbo].[tblTransactionDetails] ([Transaction_Details_ID], [Product_ID], [Quantity]) VALUES (4, 7, 50)
INSERT [dbo].[tblTransactionDetails] ([Transaction_Details_ID], [Product_ID], [Quantity]) VALUES (5, 7, 25)
INSERT [dbo].[tblTransactionDetails] ([Transaction_Details_ID], [Product_ID], [Quantity]) VALUES (6, 4, 10)
INSERT [dbo].[tblTransactionDetails] ([Transaction_Details_ID], [Product_ID], [Quantity]) VALUES (7, 3, 5)
INSERT [dbo].[tblTransactionDetails] ([Transaction_Details_ID], [Product_ID], [Quantity]) VALUES (9, 2, 15)
INSERT [dbo].[tblTransactionDetails] ([Transaction_Details_ID], [Product_ID], [Quantity]) VALUES (10, 3, 70)
SET IDENTITY_INSERT [dbo].[tblTransactionDetails] OFF
SET IDENTITY_INSERT [dbo].[tblTransactions] ON 

INSERT [dbo].[tblTransactions] ([Transaction_ID], [Date], [Customer_ID]) VALUES (1, CAST(N'2015-07-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tblTransactions] ([Transaction_ID], [Date], [Customer_ID]) VALUES (2, CAST(N'2015-07-03 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[tblTransactions] ([Transaction_ID], [Date], [Customer_ID]) VALUES (3, CAST(N'2015-07-05 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tblTransactions] ([Transaction_ID], [Date], [Customer_ID]) VALUES (4, CAST(N'2015-07-07 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tblTransactions] ([Transaction_ID], [Date], [Customer_ID]) VALUES (5, CAST(N'2015-07-08 00:00:00.000' AS DateTime), 4)
INSERT [dbo].[tblTransactions] ([Transaction_ID], [Date], [Customer_ID]) VALUES (6, CAST(N'2015-07-08 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tblTransactions] ([Transaction_ID], [Date], [Customer_ID]) VALUES (7, CAST(N'2015-07-10 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[tblTransactions] ([Transaction_ID], [Date], [Customer_ID]) VALUES (8, CAST(N'2015-07-02 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[tblTransactions] ([Transaction_ID], [Date], [Customer_ID]) VALUES (9, CAST(N'2015-07-02 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[tblTransactions] ([Transaction_ID], [Date], [Customer_ID]) VALUES (10, CAST(N'2015-07-12 00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[tblTransactions] OFF
/****** Object:  StoredProcedure [dbo].[sprCustomerFlag]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprCustomerFlag] 
	@ID AS nvarchar(10)
AS
BEGIN
    SELECT COUNT(*) FROM Customer WHERE Id = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[sprDeleteCustomer]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprDeleteCustomer] 
	@ID AS int
AS
BEGIN

    DELETE FROM Customer WHERE ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[sprDeleteTransaction]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprDeleteTransaction] 
	@Transaction_ID AS int
AS
BEGIN

    DELETE FROM tblTransactions WHERE Transaction_ID = @Transaction_ID
END


GO
/****** Object:  StoredProcedure [dbo].[sprInsertCustomer]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprInsertCustomer] 
	@Name AS VARCHAR(50),
	@Address AS VARCHAR(100)
AS
BEGIN

    INSERT INTO Customer (Name, Address) VALUES (@Name, @Address)
END


GO
/****** Object:  StoredProcedure [dbo].[sprInsertTransaction]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprInsertTransaction] 
	@Date AS VARCHAR(50),
	@Customer_ID AS VARCHAR(100)
AS
BEGIN

    INSERT INTO tblTransactions (Date, Customer_ID) VALUES (@Date, @Customer_ID)
END


GO
/****** Object:  StoredProcedure [dbo].[sprSelectAllCustomer]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprSelectAllCustomer] 
	@strWhere AS VARCHAR(1000),
	@strOrderBy AS VARCHAR(1000)
AS
BEGIN
	DECLARE @query varchar(1000)
    SET @query = 'SELECT id, name, address FROM Customer' + @strWhere + @strOrderBy
	EXEC(@query)
END


GO
/****** Object:  StoredProcedure [dbo].[sprSelectAllTransaction]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprSelectAllTransaction] 
	@strWhere AS VARCHAR(1000),
	@strOrderBy AS VARCHAR(1000)
AS
BEGIN
	DECLARE @query varchar(1000)
    SET @query = 'SELECT Transaction_ID, Date, Customer_ID FROM tblTransactions ' + @strWhere + ' ' + @strOrderBy
	EXEC(@query)
	PRINT(@query)
END


GO
/****** Object:  StoredProcedure [dbo].[sprSelectAllTransactionsByCustomerID]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprSelectAllTransactionsByCustomerID] 
	@CustomerID AS int
AS
BEGIN

    SELECT * FROM Transactions WHERE Customer_ID = @CustomerID
END


GO
/****** Object:  StoredProcedure [dbo].[sprSelectCustomerByID]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprSelectCustomerByID] 
	@ID AS int
AS
BEGIN

    SELECT * FROM Customer WHERE ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[sprSelectTransactionByID]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprSelectTransactionByID] 
	@Transaction_ID AS int
AS
BEGIN

    SELECT * FROM tblTransactions WHERE Transaction_ID = @Transaction_ID
END


GO
/****** Object:  StoredProcedure [dbo].[sprTransactionFlag]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprTransactionFlag] 
	@Transaction_ID AS nvarchar(10)
AS
BEGIN
    SELECT COUNT(*) FROM tblTransactions WHERE Transaction_ID = @Transaction_ID
END


GO
/****** Object:  StoredProcedure [dbo].[sprUpdateCustomer]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprUpdateCustomer] 
	@ID AS nvarchar(10),
	@NAME AS VARCHAR(50),
	@ADDRESS AS VARCHAR(100)
AS
BEGIN

    UPDATE Customer SET Name = @NAME, Address = @ADDRESS WHERE ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[sprUpdateTransaction]    Script Date: 7/24/2015 5:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sprUpdateTransaction] 
	@Transaction_ID AS nvarchar(10),
	@Date AS VARCHAR(50),
	@Customer_ID AS VARCHAR(100)
AS
BEGIN

    UPDATE tblTransactions SET Date = @Date, Customer_ID = @Customer_ID WHERE Transaction_ID = @Transaction_ID
END


GO
USE [master]
GO
ALTER DATABASE [Mentoring] SET  READ_WRITE 
GO
