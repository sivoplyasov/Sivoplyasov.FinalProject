USE [master]
GO
/****** Object:  Database [ForumDB]    Script Date: 02.08.2018 15:29:58 ******/
CREATE DATABASE [ForumDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ForumDB', FILENAME = N'C:\Users\Admin\ForumDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ForumDB_log', FILENAME = N'C:\Users\Admin\ForumDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ForumDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ForumDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ForumDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ForumDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ForumDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ForumDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ForumDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ForumDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ForumDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ForumDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ForumDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ForumDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ForumDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ForumDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ForumDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ForumDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ForumDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ForumDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ForumDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ForumDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ForumDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ForumDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ForumDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ForumDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ForumDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ForumDB] SET  MULTI_USER 
GO
ALTER DATABASE [ForumDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ForumDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ForumDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ForumDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ForumDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ForumDB] SET QUERY_STORE = OFF
GO
USE [ForumDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ForumDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 02.08.2018 15:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Section_Id] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 02.08.2018 15:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Topic_Id] [int] NOT NULL,
	[Post_Text] [nvarchar](1000) NOT NULL,
	[Date_Of_Creation] [datetime] NOT NULL,
	[User_Id] [int] NOT NULL,
	[Reply_Id] [int] NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sections]    Script Date: 02.08.2018 15:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 02.08.2018 15:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category_Id] [int] NOT NULL,
	[Author_Id] [int] NOT NULL,
	[Date_Of_Creation] [datetime] NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Is_Closed] [int] NOT NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02.08.2018 15:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Login] [varchar](20) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Role] [varchar](30) NOT NULL,
	[Avatar_Link] [varchar](150) NULL,
	[Is_Banned] [int] NOT NULL,
	[Date_Of_Registration] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Section_Id], [Description]) VALUES (1, N'.Net Community Thread', 1, N'.Net Community раздел.')
INSERT [dbo].[Categories] ([Id], [Name], [Section_Id], [Description]) VALUES (2, N'.Net Core', 1, N'Темы, связанные с .Net Core')
INSERT [dbo].[Categories] ([Id], [Name], [Section_Id], [Description]) VALUES (3, N'Java SE Discussions', 2, N'Дискуссии, связанные с Java SE')
INSERT [dbo].[Categories] ([Id], [Name], [Section_Id], [Description]) VALUES (4, N'Java EE Discussions', 2, N'Обсуждение Java EE. ')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Topic_Id], [Post_Text], [Date_Of_Creation], [User_Id], [Reply_Id]) VALUES (8005, 1002, N'Привет. Вот, собственно, демонстрация темы форума. Понимаю, немного некрасиво и кривовато, но я старался. Правда.', CAST(N'2018-08-01T22:26:13.880' AS DateTime), 1, NULL)
INSERT [dbo].[Posts] ([Id], [Topic_Id], [Post_Text], [Date_Of_Creation], [User_Id], [Reply_Id]) VALUES (8010, 1002, N'На посты так же можно отвечать. При клике на ссылку, находящуюся вверху поста будет переход к посту, на который мы отвечаем.', CAST(N'2018-08-01T22:37:36.767' AS DateTime), 1, 8005)
INSERT [dbo].[Posts] ([Id], [Topic_Id], [Post_Text], [Date_Of_Creation], [User_Id], [Reply_Id]) VALUES (8011, 1002, N'Кстати, логин админа - "admin", а пароль - "12345678". Это на случай, если вдруг захочется поиграться с возможностями админа. Админом можно банить, повышать пользователей. Удалять и создавать всякое. Классика, короче.', CAST(N'2018-08-01T22:39:57.997' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[Posts] OFF
SET IDENTITY_INSERT [dbo].[Sections] ON 

INSERT [dbo].[Sections] ([Id], [Name]) VALUES (1, N'.NET')
INSERT [dbo].[Sections] ([Id], [Name]) VALUES (2, N'Java')
SET IDENTITY_INSERT [dbo].[Sections] OFF
SET IDENTITY_INSERT [dbo].[Topics] ON 

INSERT [dbo].[Topics] ([Id], [Name], [Category_Id], [Author_Id], [Date_Of_Creation], [Description], [Is_Closed]) VALUES (1002, N'Финальный проект', 1, 1, CAST(N'2018-08-01T22:26:13.870' AS DateTime), N'Тут находится описание темы. Может быть null.', 0)
SET IDENTITY_INSERT [dbo].[Topics] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [Email], [Role], [Avatar_Link], [Is_Banned], [Date_Of_Registration]) VALUES (1, N'Admin', N'admin', N'fCIvspJ9goryL1khNOiTJIBjfA0=', N'sivoplasov_96@mail.ru', N'Admin', NULL, 0, CAST(N'2018-07-30T19:33:02.500' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [Email], [Role], [Avatar_Link], [Is_Banned], [Date_Of_Registration]) VALUES (2, N'John Doe', N'johndoe', N'fCIvspJ9goryL1khNOiTJIBjfA0=', N'asdasdS@gmail.com', N'User', NULL, 1, CAST(N'2018-07-30T21:18:55.467' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [Email], [Role], [Avatar_Link], [Is_Banned], [Date_Of_Registration]) VALUES (1002, N'JaneD', N'JaneDoe', N'iKS1KStu6qXIQ6PLeCdGxAn3VsI=', N'blabla@gmail.com', N'User', NULL, 0, CAST(N'2018-07-31T23:20:39.777' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categories]    Script Date: 02.08.2018 15:29:59 ******/
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [IX_Categories] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users]    Script Date: 02.08.2018 15:29:59 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_1]    Script Date: 02.08.2018 15:29:59 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [IX_Users_1] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Topics] ADD  CONSTRAINT [DF_Topics_Is_Closed]  DEFAULT ((0)) FOR [Is_Closed]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Is_Banned]  DEFAULT ((0)) FOR [Is_Banned]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Sections] FOREIGN KEY([Section_Id])
REFERENCES [dbo].[Sections] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Sections]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Topic] FOREIGN KEY([Topic_Id])
REFERENCES [dbo].[Topics] ([Id])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Topic]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Users] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Users]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_Topic_Categories] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_Topic_Categories]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_Topics_Users] FOREIGN KEY([Author_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_Topics_Users]
GO
USE [master]
GO
ALTER DATABASE [ForumDB] SET  READ_WRITE 
GO
