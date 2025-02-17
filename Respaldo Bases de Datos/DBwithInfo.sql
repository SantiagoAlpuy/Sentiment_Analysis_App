USE [DBwithInfo]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/20/2020 6:15:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlertAs]    Script Date: 6/20/2020 6:15:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlertAs](
	[AlertAId] [int] IDENTITY(1,1) NOT NULL,
	[Entity] [nvarchar](max) NULL,
	[Category] [int] NOT NULL,
	[Posts] [int] NOT NULL,
	[Days] [int] NOT NULL,
	[Hours] [int] NOT NULL,
	[Activated] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AlertAs] PRIMARY KEY CLUSTERED 
(
	[AlertAId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlertBAuthors]    Script Date: 6/20/2020 6:15:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlertBAuthors](
	[AuthorId] [int] NOT NULL,
	[AlertBId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AlertBAuthors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC,
	[AlertBId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlertBs]    Script Date: 6/20/2020 6:15:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlertBs](
	[AlertBId] [int] IDENTITY(1,1) NOT NULL,
	[Category] [int] NOT NULL,
	[Posts] [int] NOT NULL,
	[Days] [int] NOT NULL,
	[Hours] [int] NOT NULL,
	[Activated] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AlertBs] PRIMARY KEY CLUSTERED 
(
	[AlertBId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 6/20/2020 6:15:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Born] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entities]    Script Date: 6/20/2020 6:15:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entities](
	[EntityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Entities] PRIMARY KEY CLUSTERED 
(
	[EntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phrases]    Script Date: 6/20/2020 6:15:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phrases](
	[PhraseId] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[Date] [datetime] NOT NULL,
	[Entity] [nvarchar](max) NULL,
	[Category] [int] NOT NULL,
	[Author_AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Phrases] PRIMARY KEY CLUSTERED 
(
	[PhraseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sentiments]    Script Date: 6/20/2020 6:15:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sentiments](
	[SentimentId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Category] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Sentiments] PRIMARY KEY CLUSTERED 
(
	[SentimentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AlertBAuthors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AlertBAuthors_dbo.AlertBs_AlertBId] FOREIGN KEY([AlertBId])
REFERENCES [dbo].[AlertBs] ([AlertBId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlertBAuthors] CHECK CONSTRAINT [FK_dbo.AlertBAuthors_dbo.AlertBs_AlertBId]
GO
ALTER TABLE [dbo].[AlertBAuthors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AlertBAuthors_dbo.Authors_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlertBAuthors] CHECK CONSTRAINT [FK_dbo.AlertBAuthors_dbo.Authors_AuthorId]
GO
ALTER TABLE [dbo].[Phrases]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Phrases_dbo.Authors_Author_AuthorId] FOREIGN KEY([Author_AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Phrases] CHECK CONSTRAINT [FK_dbo.Phrases_dbo.Authors_Author_AuthorId]
GO
