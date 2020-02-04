USE [master]
GO
/****** Object:  Database [Library]    Script Date: 2/4/2020 4:53:41 PM ******/
CREATE DATABASE [LibraryUnitTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryUnitTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\LibraryUnitTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryUnitTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\LibraryUnitTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryUnitTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryUnitTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryUnitTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryUnitTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryUnitTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryUnitTest] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryUnitTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryUnitTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryUnitTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryUnitTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryUnitTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryUnitTest] SET QUERY_STORE = OFF
GO
USE [LibraryUnitTest]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](50) NOT NULL,
	[Last_Name] [varchar](50) NOT NULL,
	[Bio] [varchar](1000) NULL,
	[DateOfBirth] [datetime] NULL,
	[BirthLocation] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[Book_Description] [varchar](1000) NULL,
	[Book_Price] [money] NOT NULL,
	[Book_IsPaperBack] [varchar](1) NOT NULL,
	[Book_AuthorID_FK] [int] NULL,
	[GenreID_FK] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Genre_Description] [varchar](1000) NULL,
	[Is_Fiction] [varchar](1) NOT NULL,
	[Genre_Name] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_Book_Genre_Author]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vw_Book_Genre_Author] AS
SELECT Title, Book_Description, Genre_Name, 
First_Name + ' ' + Last_Name AS Author FROM Book b
INNER JOIN Genre g ON g.GenreID = b.GenreID_FK
INNER JOIN Author a ON a.AuthorID = b.Book_AuthorID_FK;
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](255) NULL,
 CONSTRAINT [PKRolesC4B278203D96CD14] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[RoleID_FK] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_Users_Role]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[vw_Users_Role] AS
SELECT	UserId, 
		FirstName, 
		LastName, UserName, Password, RoleID, RoleName from Users u
INNER JOIN Roles r ON r.RoleID = u.RoleID_FK;
GO
/****** Object:  Table [dbo].[Lending]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lending](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookID_FK] [int] NOT NULL,
	[UserID_FK] [int] NOT NULL,
	[DueDateBack] [datetime] NOT NULL,
	[CheckOutDate] [datetime] NOT NULL,
	[ReturnedDate] [datetime] NULL,
 CONSTRAINT [PK_Lending] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_Books_Main]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE VIEW [dbo].[vw_Books_Main] AS
  SELECT BookID, Title, 
  [First_Name] + ' ' + [Last_Name] AS Author, 
  Genre_Name AS Genre,
  jn.UserID,
  jn.Borrower, 
  [CheckOutDate],[DueDateBack], [ReturnedDate]
  FROM Book b 
  INNER JOIN Author a ON a.AuthorID = b.Book_AuthorID_FK
  INNER JOIN Genre g ON g.GenreID = b.GenreID_FK 
  LEFT JOIN (SELECT BookID_FK, UserID_FK AS UserID, LastName + ', ' + FirstName AS Borrower, [DueDateBack],
   [CheckOutDate], [ReturnedDate] FROM Lending l 
  INNER JOIN Users u ON u.UserID = l.UserID_FK) jn ON jn.BookID_FK = b.BookID
GO
/****** Object:  Table [dbo].[LoggingError]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoggingError](
	[Logid] [bigint] IDENTITY(1,1) NOT NULL,
	[ExceptionStackTrace] [varchar](max) NULL,
	[ExceptionMessage] [varchar](max) NULL,
	[ExceptionSource] [varchar](max) NULL,
	[ExceptionURL] [varchar](max) NULL,
	[Logdate] [datetime] NULL,
 CONSTRAINT [PK_Tbl_LoggingError] PRIMARY KEY CLUSTERED 
(
	[Logid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 
GO
INSERT [dbo].[Author] ([AuthorID], [First_Name], [Last_Name], [Bio], [DateOfBirth], [BirthLocation]) VALUES (1, N'Sam', N'Stall', N'Sam Stall is an author, freelance writer, and former editor of Indianapolis Monthly magazine. He has written more than a dozen books specializing in humor and pop culture, including the South Park episode guides. Sam lives in Indianapolis, Indiana.', NULL, NULL)
GO
INSERT [dbo].[Author] ([AuthorID], [First_Name], [Last_Name], [Bio], [DateOfBirth], [BirthLocation]) VALUES (2, N'Michelle', N'Obama', N'Michelle Robinson was born in Chicago, Illinois on January 17, 1964. She studied sociology and African-American studies at Princeton University', CAST(N'1964-01-17T00:00:00.000' AS DateTime), N'Chicago, IL')
GO
INSERT [dbo].[Author] ([AuthorID], [First_Name], [Last_Name], [Bio], [DateOfBirth], [BirthLocation]) VALUES (3, N'Sheila', N'Weller', NULL, NULL, NULL)
GO
INSERT [dbo].[Author] ([AuthorID], [First_Name], [Last_Name], [Bio], [DateOfBirth], [BirthLocation]) VALUES (4, N'J. R. R.', N'Tolkien', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([BookID], [Title], [Book_Description], [Book_Price], [Book_IsPaperBack], [Book_AuthorID_FK], [GenreID_FK]) VALUES (1, N'Dancing with Jesus: Featuring a Host of Miraculous Moves', N'Are you cursed with two left feet? Are your dance moves unrighteous? Do you refrain from getting down lest others judge you cruelly? Fear not. Salvation is at hand.', 59.0000, N'N', 1, 1)
GO
INSERT [dbo].[Book] ([BookID], [Title], [Book_Description], [Book_Price], [Book_IsPaperBack], [Book_AuthorID_FK], [GenreID_FK]) VALUES (3, N'Becoming', N'In a life filled with meaning and accomplishment, Michelle Obama has emerged as one of the most iconic and compelling women of our era. As First Lady of the United States of America, she helped create the most welcoming and inclusive White House in history', 19.9900, N'Y', 2, 4)
GO
INSERT [dbo].[Book] ([BookID], [Title], [Book_Description], [Book_Price], [Book_IsPaperBack], [Book_AuthorID_FK], [GenreID_FK]) VALUES (4, N'Carrie Fisher
A Life on the Edge', N'Sourced by friends, colleagues, and witnesses to all stages of Fisher''s life, this work is an affectionate and even-handed portrayal of a woman whose unsurpassed honesty is a reminder of how things should be.', 9.9900, N'Y', 3, 4)
GO
INSERT [dbo].[Book] ([BookID], [Title], [Book_Description], [Book_Price], [Book_IsPaperBack], [Book_AuthorID_FK], [GenreID_FK]) VALUES (6, N'The Hobbit; or, There and Back Again (Hardcover)', N'"In a hole in the ground, there lived a hobbit." So begins one of the most beloved and delightful tales in the English language. Set in the imaginary world of Middle-earth, at once a classic myth and a modern fairy tale, The Hobbit is one of literature''s most enduring and well-loved novels. Presented in the standard hardcover edition using the author''s original jacket design.', 25.9900, N'N', 4, 3)
GO
INSERT [dbo].[Book] ([BookID], [Title], [Book_Description], [Book_Price], [Book_IsPaperBack], [Book_AuthorID_FK], [GenreID_FK]) VALUES (7, N'The Fellowship of the Ring: Being the First Part of The Lord of the Rings (1)', N'In ancient times the Rings of Power were crafted by the Elven-smiths, and Sauron, the Dark Lord, forged the One Ring, filling it with his own power so that he could rule all others. But the One Ring was taken from him, and though he sought it throughout Middle-earth, it remained lost to him. After many ages it fell into the hands of Bilbo Baggins, as told in The Hobbit. In a sleepy village in the Shire, young Frodo Baggins finds himself faced with an immense task, as his elderly cousin Bilbo entrusts the Ring to hi', 9.9700, N'Y', 4, 3)
GO
INSERT [dbo].[Book] ([BookID], [Title], [Book_Description], [Book_Price], [Book_IsPaperBack], [Book_AuthorID_FK], [GenreID_FK]) VALUES (8, N'The Two Towers: Being the Second Part of The Lord of the Rings (2) ', N'Frodo and his Companions of the Ring have been beset by danger during their quest to prevent the Ruling Ring from falling into the hands of the Dark Lord by destroying it in the Cracks of Doom. They have lost the wizard, Gandalf, in a battle in the Mines of Moria. And Boromir, seduced by the power of the Ring, tried to seize it by force. While Frodo and Sam made their escape, the rest of the company was', 9.9700, N'Y', 4, 3)
GO
INSERT [dbo].[Book] ([BookID], [Title], [Book_Description], [Book_Price], [Book_IsPaperBack], [Book_AuthorID_FK], [GenreID_FK]) VALUES (9, N'The Return of the King: Being the Third Part of the Lord of the Rings', N'As the Shadow of Mordor grows across the land, the Companions of the Ring have become involved in separate adventures. Aragorn, revealed as the hidden heir of the ancient Kings of the West, has joined with the Riders of Rohan against the forces of Isengard, and takes part in the desperate victory of the Hornburg. Merry and Pippin, captured by Orcs, escape into Fangorn Forest and there encounter the', 11.1600, N'Y', 4, 3)
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 
GO
INSERT [dbo].[Genre] ([GenreID], [Genre_Description], [Is_Fiction], [Genre_Name]) VALUES (1, N'A comic novel is usually a work of fiction in which the writer seeks to amuse the reader, sometimes with subtlety and as part of a carefully woven narrative, sometimes above all other considerations. It could indeed be said that comedy fiction is literary work that aims primarily to provoke laughter, but this is not always as obvious as it first may seem.', N'Y', N'Humor')
GO
INSERT [dbo].[Genre] ([GenreID], [Genre_Description], [Is_Fiction], [Genre_Name]) VALUES (3, NULL, N'Y', N'Fiction')
GO
INSERT [dbo].[Genre] ([GenreID], [Genre_Description], [Is_Fiction], [Genre_Name]) VALUES (4, NULL, N'N', N'Autobiography')
GO
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Lending] ON 
GO
INSERT [dbo].[Lending] ([ID], [BookID_FK], [UserID_FK], [DueDateBack], [CheckOutDate], [ReturnedDate]) VALUES (2, 4, 4, CAST(N'2020-02-25T00:00:00.000' AS DateTime), CAST(N'2020-02-04T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Lending] ([ID], [BookID_FK], [UserID_FK], [DueDateBack], [CheckOutDate], [ReturnedDate]) VALUES (3, 4, 2, CAST(N'2019-02-25T00:00:00.000' AS DateTime), CAST(N'2019-02-04T00:00:00.000' AS DateTime), CAST(N'2019-02-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Lending] ([ID], [BookID_FK], [UserID_FK], [DueDateBack], [CheckOutDate], [ReturnedDate]) VALUES (4, 1, 3, CAST(N'2002-06-21T00:00:00.000' AS DateTime), CAST(N'2002-06-01T00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Lending] OFF
GO
SET IDENTITY_INSERT [dbo].[LoggingError] ON 
GO
INSERT [dbo].[LoggingError] ([Logid], [ExceptionStackTrace], [ExceptionMessage], [ExceptionSource], [ExceptionURL], [Logdate]) VALUES (1, N'   at System.Data.ProviderBase.FieldNameLookup.GetOrdinal(String fieldName)
   at System.Data.SqlClient.SqlDataReader.GetOrdinal(String name)
   at LibraryDatabaseAccessLayer.UserOperationsDAL.LoginUserToDatabase(User inUser) in D:\GitHub\giancarlorhodes\LibraryWebAppSolution\LibraryDatabaseAccessLayer\UserOperationsDAL.cs:line 238', N'FirstNam', N'System.Data', N'GetOrdinal', CAST(N'2020-01-31T13:08:46.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[LoggingError] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Administrator')
GO
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'Librarian')
GO
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (3, N'Patron')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (1, N'Rhodes', N'Giancarlo', N'grhodes29', N'password123', 1)
GO
INSERT [dbo].[Users] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (2, N'Adams', N'Dillan', N'dillan.adams', N'password123', 3)
GO
INSERT [dbo].[Users] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (3, N'Wells', N'Heather', N'heather.wells', N'password123', 3)
GO
INSERT [dbo].[Users] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (4, N'Colton', N'Nichols', N'colton.nichols', N'password123', 3)
GO
INSERT [dbo].[Users] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (5, N'Teter', N'Derek', N'derek.teter', N'password123', 2)
GO
INSERT [dbo].[Users] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (6, N'tester1', N'tester1', N'tester123', N'password123', 3)
GO
INSERT [dbo].[Users] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (8, N'tester2', N'tester2', N'tester2', N'password123', 3)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthor] FOREIGN KEY([Book_AuthorID_FK])
REFERENCES [dbo].[Author] ([AuthorID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_BookAuthor]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Genre] FOREIGN KEY([GenreID_FK])
REFERENCES [dbo].[Genre] ([GenreID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Genre]
GO
ALTER TABLE [dbo].[Lending]  WITH CHECK ADD  CONSTRAINT [FK_Lending_Book] FOREIGN KEY([BookID_FK])
REFERENCES [dbo].[Book] ([BookID])
GO
ALTER TABLE [dbo].[Lending] CHECK CONSTRAINT [FK_Lending_Book]
GO
ALTER TABLE [dbo].[Lending]  WITH CHECK ADD  CONSTRAINT [FK_Lending_Users] FOREIGN KEY([UserID_FK])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Lending] CHECK CONSTRAINT [FK_Lending_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID_FK])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_books_main]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_books_main] 
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	@parm_UserID int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	IF (@parm_UserID = 0)
		BEGIN
			SELECT 
			   [BookID]
			  ,[Title]
			  ,[Author]
			  ,[Genre]
			  ,[UserID]
			  ,[Borrower]
			  ,[CheckOutDate]
			  ,[DueDateBack]
			  ,[ReturnedDate]
			FROM [Library].[dbo].[vw_Books_Main]
		END
	ELSE 
		BEGIN
			SELECT 
			   [BookID]
			  ,[Title]
			  ,[Author]
			  ,[Genre]
			  ,[UserID]
			  ,[Borrower]
			  ,[CheckOutDate]
			  ,[DueDateBack]
			  ,[ReturnedDate]
			FROM [Library].[dbo].[vw_Books_Main]
			WHERE UserID IS NULL OR UserID = @parm_UserID
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_users]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_users] 
	-- Add the parameters for the stored procedure here
	@parm_userid int= 0, 
	@parm_username varchar(255) = '',
	@parm_password varchar(255) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@parm_userid = 0 AND @parm_username = '' AND @parm_password = '')
	BEGIN
		SELECT [UserID]
		  ,[LastName]
		  ,[FirstName]
		  ,[UserName]
		  ,[Password]
		  ,[RoleID_FK]
		FROM [Library].[dbo].[Users];
	END
	ELSE IF (@parm_userid <> 0)
	BEGIN
		SELECT 
			[UserID]
		   ,[LastName]
		   ,[FirstName]
		   ,[UserName]
		   ,[Password]
		   ,[RoleID_FK]
		FROM [Library].[dbo].[Users]
		WHERE UserID = @parm_userid;
	END
	-- checking for duplicates for register process
	ELSE IF (@parm_username <> '' AND @parm_password = '')
	BEGIN
		SELECT 
			[UserID]
		   ,[LastName]
		   ,[FirstName]
		   ,[UserName]
		   ,[Password]
		   ,[RoleID_FK]
		FROM [Library].[dbo].[Users]
		WHERE [UserName] = @parm_username;
	END
	-- checking for login process
	ELSE IF (@parm_username <> '' AND @parm_password <> '')
	BEGIN
		SELECT 
			[UserID]
		   ,[LastName]
		   ,[FirstName]
		   ,[UserName]
		   ,[Password]
		   ,[RoleID_FK]
		FROM [Library].[dbo].[Users]
		WHERE [UserName] = @parm_username and [Password] = @parm_password;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LogException]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Giancarlo Rhodes
-- Create date: 10/07/2019
-- Description:	using to log exception to the database
-- =============================================
CREATE PROCEDURE [dbo].[sp_LogException] 
	-- Add the parameters for the stored procedure here
	@parmExceptionStackTrace varchar(max),
	@parmExceptionMessage varchar(max),
	@parmExceptionSource varchar(max),
	@parmExceptionURL varchar(max),
	@parmLogdate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	INSERT INTO [dbo].[LoggingError]
           ([ExceptionStackTrace]
           ,[ExceptionMessage]
           ,[ExceptionSource]
           ,[ExceptionURL]
           ,[Logdate])
     VALUES
           (@parmExceptionStackTrace,
            @parmExceptionMessage,
            @parmExceptionSource,
            @parmExceptionURL,
            @parmLogdate)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_register_user]    Script Date: 2/4/2020 4:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_register_user] 
	-- Add the parameters for the stored procedure here
	@parm_FirstName varchar(255),
	@parm_LastName varchar(255),
	@parm_UserName varchar(255),
	@parm_Password varchar(255),
	@parm_RoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Users 
		(
			[FirstName],
			[LastName],
			[UserName],
			[Password], 
			[RoleID_FK]
		) 
	VALUES 
		(
			@parm_FirstName, 
			@parm_LastName, 
			@parm_UserName, 
			@parm_Password, 
			@parm_RoleID
		);

END
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
