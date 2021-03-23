/****** Object:  Database [KnowledgeDB]    Script Date: 23/03/2021 17:33:51 ******/
CREATE DATABASE [KnowledgeDB]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [KnowledgeDB] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [KnowledgeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KnowledgeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KnowledgeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KnowledgeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KnowledgeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [KnowledgeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KnowledgeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KnowledgeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KnowledgeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KnowledgeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KnowledgeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KnowledgeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KnowledgeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KnowledgeDB] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [KnowledgeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KnowledgeDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [KnowledgeDB] SET  MULTI_USER 
GO
ALTER DATABASE [KnowledgeDB] SET ENCRYPTION ON
GO
ALTER DATABASE [KnowledgeDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [KnowledgeDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[BoilerParts]    Script Date: 23/03/2021 17:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoilerParts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Overview] [nvarchar](max) NULL,
 CONSTRAINT [PK_BoilerParts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Engineers]    Script Date: 23/03/2021 17:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Engineers](
	[guid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ContactNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Engineers] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tips]    Script Date: 23/03/2021 17:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tips](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[KnowledgeBaseBoilerPartId] [bigint] NOT NULL,
	[KnowledgeBaseEngineerGuid] [uniqueidentifier] NOT NULL,
	[Subject] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tips] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[BoilerParts] ON 

INSERT [dbo].[BoilerParts] ([Id], [Name], [Overview]) VALUES (1, N'Pumped Water Controller', N'Water pump controller for combination boiler')
INSERT [dbo].[BoilerParts] ([Id], [Name], [Overview]) VALUES (2, N'3.5 W/S Heater', N'Small heat exchanger for domestic boiler')
INSERT [dbo].[BoilerParts] ([Id], [Name], [Overview]) VALUES (3, N'Inlet Valve', N'Water inlet valve with one-way operation')
INSERT [dbo].[BoilerParts] ([Id], [Name], [Overview]) VALUES (4, N'Mid-position Valve', N'Bi-directional pressure release')
INSERT [dbo].[BoilerParts] ([Id], [Name], [Overview]) VALUES (5, N'5.0 W/S Heater', N'Medium heat exchanger for canteen boiler')
INSERT [dbo].[BoilerParts] ([Id], [Name], [Overview]) VALUES (6, N'Fan Controller', N'Controller for air-con unit')
SET IDENTITY_INSERT [dbo].[BoilerParts] OFF
GO
INSERT [dbo].[Engineers] ([guid], [Name], [ContactNumber]) VALUES (N'f97f7495-101d-45b3-ac62-45a15e4d56c5', N'Sara Perez', N'554-1001')
INSERT [dbo].[Engineers] ([guid], [Name], [ContactNumber]) VALUES (N'cd3ed834-49fe-42c0-9b57-6627fe13c8ba', N'Quincy Watson', N'554-1002')
INSERT [dbo].[Engineers] ([guid], [Name], [ContactNumber]) VALUES (N'ab9f4790-05f2-4cc3-9f01-8dfa7d848179', N'Michelle Harris', N'554-1000')
GO
SET IDENTITY_INSERT [dbo].[Tips] ON 

INSERT [dbo].[Tips] ([Id], [KnowledgeBaseBoilerPartId], [KnowledgeBaseEngineerGuid], [Subject], [Body]) VALUES (1, 1, N'cd3ed834-49fe-42c0-9b57-6627fe13c8ba', N'How to get water to the right temperature', N'If water doesn''t get hot when radiators are on, replace the diverter valve.')
INSERT [dbo].[Tips] ([Id], [KnowledgeBaseBoilerPartId], [KnowledgeBaseEngineerGuid], [Subject], [Body]) VALUES (2, 1, N'cd3ed834-49fe-42c0-9b57-6627fe13c8ba', N'Where to site this boiler', N'When installing this unit, don''t place it more that 5 feet higher than the fuel tank, without a fuel pump.')
INSERT [dbo].[Tips] ([Id], [KnowledgeBaseBoilerPartId], [KnowledgeBaseEngineerGuid], [Subject], [Body]) VALUES (3, 3, N'ab9f4790-05f2-4cc3-9f01-8dfa7d848179', N'How to get this nozzle to light the furnace correctly', N'Sometimes the nozzle gets clogged with old oil or dirt. You can use a fine point to clear it, or replace.')
SET IDENTITY_INSERT [dbo].[Tips] OFF
GO
/****** Object:  Index [IX_Tips_KnowledgeBaseBoilerPartId]    Script Date: 23/03/2021 17:33:51 ******/
CREATE NONCLUSTERED INDEX [IX_Tips_KnowledgeBaseBoilerPartId] ON [dbo].[Tips]
(
	[KnowledgeBaseBoilerPartId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tips_KnowledgeBaseEngineerGuid]    Script Date: 23/03/2021 17:33:51 ******/
CREATE NONCLUSTERED INDEX [IX_Tips_KnowledgeBaseEngineerGuid] ON [dbo].[Tips]
(
	[KnowledgeBaseEngineerGuid] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tips]  WITH CHECK ADD  CONSTRAINT [FK_Tips_BoilerParts_KnowledgeBaseBoilerPartId] FOREIGN KEY([KnowledgeBaseBoilerPartId])
REFERENCES [dbo].[BoilerParts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tips] CHECK CONSTRAINT [FK_Tips_BoilerParts_KnowledgeBaseBoilerPartId]
GO
ALTER TABLE [dbo].[Tips]  WITH CHECK ADD  CONSTRAINT [FK_Tips_Engineers_KnowledgeBaseEngineerGuid] FOREIGN KEY([KnowledgeBaseEngineerGuid])
REFERENCES [dbo].[Engineers] ([guid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tips] CHECK CONSTRAINT [FK_Tips_Engineers_KnowledgeBaseEngineerGuid]
GO
ALTER DATABASE [KnowledgeDB] SET  READ_WRITE 
GO
