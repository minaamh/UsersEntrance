USE [UsersEntrance]
GO

/****** Object:  Table [dbo].[UsersEntrance]    Script Date: 2018-10-05 10:16:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsersEntrance](
	[EntranceID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nchar](10) NOT NULL,
	[FirstName] [nchar](10) NOT NULL,
	[LastName] [nchar](10) NOT NULL,
	[Gate] [numeric](18, 0) NOT NULL,
	[TimeStamp] [text] NULL,
 CONSTRAINT [PK_UsersEntrance] PRIMARY KEY CLUSTERED 
(
	[EntranceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

