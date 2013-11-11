IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'ProductDB')
DROP DATABASE [ProductDB]
GO

/****** Object:  Database [ProductDB]    Script Date: 06/11/2013 15:40:00 ******/
CREATE DATABASE [ProductDB] ON  PRIMARY 
( NAME = N'ProductDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ProductDB.mdf' , SIZE = 5012KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProductDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ProductDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [ProductDB] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ProductDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ProductDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ProductDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ProductDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ProductDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [ProductDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ProductDB] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [ProductDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ProductDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ProductDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ProductDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ProductDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ProductDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ProductDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ProductDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ProductDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ProductDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ProductDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ProductDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ProductDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ProductDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ProductDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ProductDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ProductDB] SET  READ_WRITE 
GO

ALTER DATABASE [ProductDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ProductDB] SET  MULTI_USER 
GO

ALTER DATABASE [ProductDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ProductDB] SET DB_CHAINING OFF 
GO

USE [ProductDB]

CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[user_type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[users] ([name], [password], [email], [user_type]) VALUES (N'John', N'pass', N'johndoe@hotmail.com', N'administrator')
/****** Object:  Table [dbo].[orders]    Script Date: 06/11/2013 15:41:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client] [varchar](50) NOT NULL,
	[product] [varchar](250) NOT NULL,
	[amount] [int] NOT NULL,
	[price] [float] NOT NULL,
	[date] [date] NOT NULL,
	[orderShipped] [bit] NOT NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'Beatle', N'Café Au Lait', 5, 2.5, CAST(0xFF360B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'beatle', N'Café Au Lait', 2, 2.5, CAST(0x0B370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'beatle', N'Café Au Lait', 8, 2.5, CAST(0x0B370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'beatle', N'Café Au Lait', 5, 2.5, CAST(0x17370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'Customer', N'Café Au Lait', 10, 2.5, CAST(0x17370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'Customer', N'Café Au Lait', 25, 2.5, CAST(0x17370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'Customer', N'Café Au Lait', 5, 2.5, CAST(0x18370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'jane', N'Café Au Lait', 100, 2.5, CAST(0x18370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'beatle', N'Café Au Lait', 2, 2.5, CAST(0x18370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'beatle', N'Galao', 4, 2.8, CAST(0x18370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'beatle', N'White Chocalate Peppermint Mocha', 5, 3.4, CAST(0x18370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'John', N'Galao', 10, 2.8, CAST(0x18370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'John', N'White Chocalate Peppermint Mocha', 5, 3.4, CAST(0x18370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'beatle', N'White Chocalate Peppermint Mocha', 5, 3.4, CAST(0x1E370B00 AS Date), 0)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'beatle', N'Café Au Lait', 5, 2.5, CAST(0x2B370B00 AS Date), 1)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'beatle', N'Galao', 4, 2.8, CAST(0x2B370B00 AS Date), 1)
INSERT [dbo].[orders] ([client], [product], [amount], [price], [date], [orderShipped]) VALUES (N'beatle', N'White Chocalate Peppermint Mocha', 3, 3.4, CAST(0x2B370B00 AS Date), 1)
/****** Object:  Table [dbo].[Product]    Script Date: 06/11/2013 15:41:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[price] [float] NOT NULL,
	[artist] [varchar](50) NOT NULL,
	[size] [varchar](50) NOT NULL,
	[image] [varchar](255) NULL,
	[review] [text] NOT NULL,
 CONSTRAINT [PK_products_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [review]) VALUES (N'Crow Abstract Giclee Print On Canvas', N'Painting', 310.00, N'Mike Lea', N'30x40', N'../Images/Product/crow.jpg', N'Watermarks will not be present on final printed images.')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [review]) VALUES (N'Chibi Cthulhu Giclee Print On Canvas', N'Painting', 85, N'Mike Lea', N'12x12', N'../Images/Product/Chibi-Cthulhu.jpg', N'Chibi Cthulhu is sad.... he is sad because he is homeless.... you could give him a home..... unless of course your heart is cold and dead like the pits of Rlyeh.')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [review]) VALUES (N'No. 17 Abstract Giclee Print On Canvas', N'Painting', 85, N'Mike Lea', N'12x12', N'../Images/Product/No_17.jpg', N'Watermarks will not be present on final printed images.')
