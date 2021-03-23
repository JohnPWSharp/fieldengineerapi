/****** Object:  Database [InventoryDB]    Script Date: 23/03/2021 17:32:03 ******/
CREATE DATABASE [InventoryDB]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [InventoryDB] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [InventoryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryDB] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [InventoryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [InventoryDB] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryDB] SET ENCRYPTION ON
GO
ALTER DATABASE [InventoryDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [InventoryDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[BoilerParts]    Script Date: 23/03/2021 17:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoilerParts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CategoryId] [nvarchar](max) NULL,
	[Price] [money] NOT NULL,
	[Overview] [nvarchar](max) NULL,
	[NumberInStock] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_BoilerParts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 23/03/2021 17:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BoilerPartId] [bigint] NOT NULL,
	[quantity] [bigint] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[OrderedDateTime] [datetime2](7) NOT NULL,
	[Delivered] [bit] NOT NULL,
	[DeliveredDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BoilerParts] ON 

INSERT [dbo].[BoilerParts] ([Id], [Name], [CategoryId], [Price], [Overview], [NumberInStock], [ImageUrl]) VALUES (1, N'Pumped Water Controller', N'PCB Assembly', 45.9900, N'Water pump controller for combination boiler', 0, N'http://contoso.com/image1')
INSERT [dbo].[BoilerParts] ([Id], [Name], [CategoryId], [Price], [Overview], [NumberInStock], [ImageUrl]) VALUES (2, N'3.5 W/S Heater', N'Heat Exchanger', 125.5000, N'Small heat exchanger for domestic boiler', 5, N'http://contoso.com/image2')
INSERT [dbo].[BoilerParts] ([Id], [Name], [CategoryId], [Price], [Overview], [NumberInStock], [ImageUrl]) VALUES (3, N'Inlet Valve', N'Valve', 120.2000, N'Water inlet valve with one-way operation', 13, N'http://contoso.com/image3')
INSERT [dbo].[BoilerParts] ([Id], [Name], [CategoryId], [Price], [Overview], [NumberInStock], [ImageUrl]) VALUES (4, N'Mid-position Valve', N'Valve', 180.9000, N'Bi-directional pressure release', 8, N'http://contoso.com/image4')
INSERT [dbo].[BoilerParts] ([Id], [Name], [CategoryId], [Price], [Overview], [NumberInStock], [ImageUrl]) VALUES (5, N'5.0 W/S Heater', N'Heat Exchanger', 145.9000, N'Medium heat exchanger for canteen boiler', 1, N'http://contoso.com/image5')
INSERT [dbo].[BoilerParts] ([Id], [Name], [CategoryId], [Price], [Overview], [NumberInStock], [ImageUrl]) VALUES (6, N'Fan Controller', N'PCB Assembly', 28.3500, N'Controller for air-con unit', 7, N'http://contoso.com/image6')
SET IDENTITY_INSERT [dbo].[BoilerParts] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [BoilerPartId], [quantity], [TotalPrice], [OrderedDateTime], [Delivered], [DeliveredDateTime]) VALUES (1, 1, 30, 243.0000, CAST(N'2021-03-12T14:08:22.1155148' AS DateTime2), 0, NULL)
INSERT [dbo].[Orders] ([Id], [BoilerPartId], [quantity], [TotalPrice], [OrderedDateTime], [Delivered], [DeliveredDateTime]) VALUES (2, 3, 20, 39.6000, CAST(N'2021-03-10T14:08:22.1181359' AS DateTime2), 1, CAST(N'2021-03-13T14:08:22.1181383' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
/****** Object:  Index [IX_Orders_BoilerPartId]    Script Date: 23/03/2021 17:32:04 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_BoilerPartId] ON [dbo].[Orders]
(
	[BoilerPartId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_BoilerParts_BoilerPartId] FOREIGN KEY([BoilerPartId])
REFERENCES [dbo].[BoilerParts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_BoilerParts_BoilerPartId]
GO
ALTER DATABASE [InventoryDB] SET  READ_WRITE 
GO
