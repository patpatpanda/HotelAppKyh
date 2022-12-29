USE [master]
GO
/****** Object:  Database [EmilHotelApp]    Script Date: 2022-12-29 11:57:12 ******/
CREATE DATABASE [EmilHotelApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmilHotelApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EmilHotelApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmilHotelApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EmilHotelApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmilHotelApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmilHotelApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmilHotelApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmilHotelApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmilHotelApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmilHotelApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmilHotelApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmilHotelApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmilHotelApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmilHotelApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmilHotelApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmilHotelApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmilHotelApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmilHotelApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmilHotelApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmilHotelApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmilHotelApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EmilHotelApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmilHotelApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmilHotelApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmilHotelApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmilHotelApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmilHotelApp] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EmilHotelApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmilHotelApp] SET RECOVERY FULL 
GO
ALTER DATABASE [EmilHotelApp] SET  MULTI_USER 
GO
ALTER DATABASE [EmilHotelApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmilHotelApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmilHotelApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmilHotelApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmilHotelApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmilHotelApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmilHotelApp', N'ON'
GO
ALTER DATABASE [EmilHotelApp] SET QUERY_STORE = OFF
GO
USE [EmilHotelApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2022-12-29 11:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guests]    Script Date: 2022-12-29 11:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guests](
	[GuestId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Guests] PRIMARY KEY CLUSTERED 
(
	[GuestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 2022-12-29 11:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateStart] [datetime2](7) NOT NULL,
	[DateEnd] [datetime2](7) NOT NULL,
	[GuestId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 2022-12-29 11:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomType] [nvarchar](max) NOT NULL,
	[RoomSize] [int] NOT NULL,
	[NumberOfBeds] [int] NOT NULL,
	[RoomPrice] [int] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_GuestId]    Script Date: 2022-12-29 11:57:12 ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_GuestId] ON [dbo].[Reservations]
(
	[GuestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_RoomId]    Script Date: 2022-12-29 11:57:12 ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_RoomId] ON [dbo].[Reservations]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Guests_GuestId] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guests] ([GuestId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Guests_GuestId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([RoomId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Rooms_RoomId]
GO
USE [master]
GO
ALTER DATABASE [EmilHotelApp] SET  READ_WRITE 
GO
