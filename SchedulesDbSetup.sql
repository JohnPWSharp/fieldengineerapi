/****** Object:  Database [SchedulesDB]    Script Date: 23/03/2021 17:35:39 ******/
CREATE DATABASE [SchedulesDB]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [SchedulesDB] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [SchedulesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SchedulesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SchedulesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SchedulesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SchedulesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SchedulesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchedulesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchedulesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchedulesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SchedulesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchedulesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SchedulesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchedulesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchedulesDB] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [SchedulesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchedulesDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SchedulesDB] SET  MULTI_USER 
GO
ALTER DATABASE [SchedulesDB] SET ENCRYPTION ON
GO
ALTER DATABASE [SchedulesDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [SchedulesDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 23/03/2021 17:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[ProblemDetails] [nvarchar](max) NULL,
	[AppointmentStatusId] [bigint] NOT NULL,
	[EngineerGuid] [uniqueidentifier] NOT NULL,
	[StartDateTime] [datetime2](7) NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppointmentStatuses]    Script Date: 23/03/2021 17:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentStatuses](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppointmentStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 23/03/2021 17:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[ContactNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Engineers]    Script Date: 23/03/2021 17:35:39 ******/
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
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([Id], [CustomerId], [ProblemDetails], [AppointmentStatusId], [EngineerGuid], [StartDateTime], [Notes], [ImageUrl]) VALUES (1, 1, N'Boiler wont start', 3, N'ab9f4790-05f2-4cc3-9f01-8dfa7d848179', CAST(N'2021-03-13T12:37:13.8748842' AS DateTime2), N'Installed a new diverter valve', NULL)
INSERT [dbo].[Appointments] ([Id], [CustomerId], [ProblemDetails], [AppointmentStatusId], [EngineerGuid], [StartDateTime], [Notes], [ImageUrl]) VALUES (2, 2, N'Can''t change temperature', 2, N'ab9f4790-05f2-4cc3-9f01-8dfa7d84817a', CAST(N'2021-03-15T12:37:13.8773255' AS DateTime2), N'Needed a new heat exchanger', NULL)
INSERT [dbo].[Appointments] ([Id], [CustomerId], [ProblemDetails], [AppointmentStatusId], [EngineerGuid], [StartDateTime], [Notes], [ImageUrl]) VALUES (3, 3, N'Radiators aren''t working', 2, N'ab9f4790-05f2-4cc3-9f01-8dfa7d84817a', CAST(N'2021-03-16T12:37:13.8773282' AS DateTime2), N'Bled radiators.', NULL)
INSERT [dbo].[Appointments] ([Id], [CustomerId], [ProblemDetails], [AppointmentStatusId], [EngineerGuid], [StartDateTime], [Notes], [ImageUrl]) VALUES (4, 1, N'Boiler wont start', 3, N'ab9f4790-05f2-4cc3-9f01-8dfa7d848179', CAST(N'2021-03-18T12:37:13.8773287' AS DateTime2), N'Installed a second new diverter valve', NULL)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[AppointmentStatuses] ON 

INSERT [dbo].[AppointmentStatuses] ([Id], [StatusName]) VALUES (1, N'Unresolved')
INSERT [dbo].[AppointmentStatuses] ([Id], [StatusName]) VALUES (2, N'Parts Ordered')
INSERT [dbo].[AppointmentStatuses] ([Id], [StatusName]) VALUES (3, N'Fixed')
SET IDENTITY_INSERT [dbo].[AppointmentStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Name], [Address], [ContactNumber]) VALUES (1, N'Damayanti Basumatary', N'4567 Main St Buffalo, NY 98052', N'555-0199')
INSERT [dbo].[Customers] ([Id], [Name], [Address], [ContactNumber]) VALUES (2, N'Deepali Haloi', N'4568 Main St Buffalo, NY 98052', N'555-0200')
INSERT [dbo].[Customers] ([Id], [Name], [Address], [ContactNumber]) VALUES (3, N'Hua Long', N'4569 Main St Buffalo, NY 98052', N'555-0201')
INSERT [dbo].[Customers] ([Id], [Name], [Address], [ContactNumber]) VALUES (4, N'Volha Pashkevich', N'4570 Main St Buffalo, NY 98052', N'555-0202')
INSERT [dbo].[Customers] ([Id], [Name], [Address], [ContactNumber]) VALUES (5, N'Veselin Iliev', N'4571 Main St Buffalo, NY 98053', N'555-0203')
INSERT [dbo].[Customers] ([Id], [Name], [Address], [ContactNumber]) VALUES (6, N'Tsehayetu Abera', N'4572 Main St Buffalo, NY 98054', N'555-0204')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
INSERT [dbo].[Engineers] ([guid], [Name], [ContactNumber]) VALUES (N'ab9f4790-05f2-4cc3-9f01-8dfa7d848179', N'Sara Perez', N'554-1000')
INSERT [dbo].[Engineers] ([guid], [Name], [ContactNumber]) VALUES (N'ab9f4790-05f2-4cc3-9f01-8dfa7d84817a', N'Michelle Harris', N'554-1001')
INSERT [dbo].[Engineers] ([guid], [Name], [ContactNumber]) VALUES (N'ab9f4790-05f2-4cc3-9f01-8dfa7d84817b', N'Quincy Watson', N'554-1002')
GO
/****** Object:  Index [IX_Appointments_AppointmentStatusId]    Script Date: 23/03/2021 17:35:40 ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_AppointmentStatusId] ON [dbo].[Appointments]
(
	[AppointmentStatusId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointments_CustomerId]    Script Date: 23/03/2021 17:35:40 ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_CustomerId] ON [dbo].[Appointments]
(
	[CustomerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointments_EngineerGuid]    Script Date: 23/03/2021 17:35:40 ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_EngineerGuid] ON [dbo].[Appointments]
(
	[EngineerGuid] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_AppointmentStatuses_AppointmentStatusId] FOREIGN KEY([AppointmentStatusId])
REFERENCES [dbo].[AppointmentStatuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_AppointmentStatuses_AppointmentStatusId]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Engineers_EngineerGuid] FOREIGN KEY([EngineerGuid])
REFERENCES [dbo].[Engineers] ([guid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Engineers_EngineerGuid]
GO
ALTER DATABASE [SchedulesDB] SET  READ_WRITE 
GO
