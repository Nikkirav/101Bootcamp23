USE [Library]
GO

/****** Object:  Table [dbo].[Author]    Script Date: 4/28/2021 7:35:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ExeceptionLogging](
	[ExeceptionLoggingID] [int] IDENTITY(1,1) NOT NULL,
	[StackTrace] [nvarchar](1000) NOT NULL,
	[Message] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](100) NULL,
	[Url] [nvarchar](100) NULL,
	[LogDate] [datetime] NOT NULL,
 CONSTRAINT [PK__ExeceptionLogging] PRIMARY KEY CLUSTERED 
(
	[ExeceptionLoggingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, 
OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


