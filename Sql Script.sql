IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'ProductDB')
DROP DATABASE [ProductDB]
GO

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
	[id] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[name] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[user_type] [varchar](50) NOT NULL
	);
GO

INSERT [dbo].[users] ([name], [password], [email], [user_type]) VALUES (N'Administrator', N'admin', N'oaklea21@gmail.com', N'administrator')

GO

CREATE TABLE [dbo].[orders](
	[id] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[client] [varchar](50) NOT NULL,
	[product] [varchar](250) NOT NULL,
	[amount] [int] NOT NULL,
	[price] [float] NOT NULL,
	[date] [date] NOT NULL,
	[orderShipped] [bit] NOT NULL
	);
GO

CREATE TABLE [dbo].[products](
	[id] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[name] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[price] [float] NOT NULL,
	[artist] [varchar](50) NOT NULL,
	[size] [varchar](50) NOT NULL,
	[image] [varchar](255) NULL,
	[description] [text] NOT NULL,
	[image_thumbnail] [varchar](255) NOT NULL
	);
GO

INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'Mesmerizing Green Eyes',N'Painting',480,N'Oak Lea',N'40x30',N'../Images/Product/product_image1.jpg',N'A beautiful blonde with red tips and hypnotic green eyes',N'../Images/product_thumbnail/product_image1.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'Black & White',N'Painting',460,N'Oak Lea',N'30x40',N'../Images/Product/product_image2.jpg',N'A black and white pencil and brush sketch',N'../Images/product_thumbnail/product_image2.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'Miscellaneous in the yard',N'Painting',450,N'Oak Lea',N'30x40',N'../Images/Product/product_image3.jpg',N'Miscellaneous items along with letters and a burned out candle thrown out on the lawn of a yard',N'../Images/product_thumbnail/product_image3.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'Femme fatale',N'Painting',500,N'Oak Lea',N'30x40',N'../Images/Product/product_image4.jpg',N'A beautiful nude drawing of a young femme fatale',N'../Images/product_thumbnail/product_image4.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'Newly-wed',N'Painting',33.99,N'Oak Lea',N'50x50',N'../Images/Product/product_image5.jpg',N'Picture of a middle aged bride in her newly furbished house',N'../Images/product_thumbnail/product_image5.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'Chibi Cthulhu Giclee Print On Canvas', N'Painting', 85, N'Mike Lea', N'12x12', N'../Images/Product/product_image6.jpg', N'Chibi Cthulhu is sad.... he is sad because he is homeless.... you could give him a home..... unless of course your heart is cold and dead like the pits of Rlyeh.',N'../Images/product_thumbnail/product_image6.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'Crow Abstract Giclee Print On Canvas', N'Painting', 310, N'Mike Lea', N'30x40', N'../Images/Product/product_image7.jpg', N'Watermarks will not be present on final printed images.',N'../Images/product_thumbnail/product_image7.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'No. 17 Abstract Giclee Print On Canvas', N'Painting', 85, N'Mike Lea', N'12x12', N'../Images/Product/product_image8.jpg', N'Watermarks will not be present on final printed images.',N'../Images/product_thumbnail/product_image8.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'Guess Who?', N'Board Game', 50, N'Clint David', N'6 players', N'../Images/Product/product_image9.jpg', N'Fun board game to play with family and friends',N'../Images/product_thumbnail/product_image9.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'The Logo Board Game',N'Board Game', 45, N'Clint David', N'4 players', N'../Images/Product/product_image10.jpg', N'Game involving knowledge of world-wide logos',N'../Images/product_thumbnail/product_image10.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'Pointless', N'Board Game', 99.99, N'Amy Dilger', N'8 players', N'../Images/Product/product_image11.jpg', N'The board game where a pointless answer is the best answer!',N'../Images/product_thumbnail/product_image11.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'The Elephant', N'Literature', 6.99, N'Thomas Merrik', N'Romance', N'../Images/Product/product_image12.jpg', N'A wonderful tale of an elephant falling in love',N'../Images/product_thumbnail/product_image12.jpg')
INSERT [dbo].[products] ([name], [type], [price], [artist], [size], [image], [description], [image_thumbnail]) VALUES (N'The Nerd Bird Owl', N'Literature', 6.99, N'Thomas Merrik', N'Sci-fi', N'../Images/Product/product_image13.jpg', N'The quest of an owl to possess infinite knowledge',N'../Images/product_thumbnail/product_image13.jpg')
GO

CREATE TABLE [dbo].[review](
	[id] [int] IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
	[review_text] [varchar](50) NOT NULL,
	[rating] [int] NOT NULL,
	[user_id] [int] NOT NULL FOREIGN KEY REFERENCES users(id),
	[product_id] [int] NOT NULL FOREIGN KEY REFERENCES products(id)
	);
GO

CREATE TABLE [dbo].[wishlist](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[productID] [int] NOT NULL,
	[userID] [int] NOT NULL
	);
GO