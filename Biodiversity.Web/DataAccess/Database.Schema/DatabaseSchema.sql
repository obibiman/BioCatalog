USE [BiologyCatalog]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 3/6/2016 8:02:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorId] [int] NOT NULL,
	[Abbreviation] [nvarchar](10) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](30) NULL,
	[SurName] [nvarchar](30) NULL,
	[Comment] [nvarchar](125) NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Author_AuthorId] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Literature]    Script Date: 3/6/2016 8:02:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Literature](
	[LiteratureId] [int] NOT NULL,
	[ReferenceYear] [nvarchar](20) NOT NULL,
	[ReferenceYearSub] [varchar](2) NULL,
	[ReferenceDate] [datetime] NULL,
	[TitleofArticleBooktitle] [nvarchar](max) NULL,
	[InReferenceNumber] [int] NULL,
	[Journal] [nvarchar](255) NULL,
	[Volume] [nvarchar](50) NULL,
	[Page] [varchar](100) NULL,
	[Plate] [nvarchar](50) NULL,
	[Publisher] [nvarchar](255) NULL,
	[City] [nvarchar](50) NULL,
	[Comment] [nvarchar](255) NULL,
	[PdfId] [int] NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Literature_LiteratureId] PRIMARY KEY CLUSTERED 
(
	[LiteratureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LiteratureAuthor]    Script Date: 3/6/2016 8:02:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiteratureAuthor](
	[LiteratureAuthorId] [int] NOT NULL,
	[LiteratureId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Ordering] [smallint] NULL,
 CONSTRAINT [PK_LiteratureAuthor_LiteratureAuthorId] PRIMARY KEY CLUSTERED 
(
	[LiteratureAuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Taxon]    Script Date: 3/6/2016 8:02:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Taxon](
	[TaxonId] [int] NOT NULL,
	[TaxonName] [nvarchar](50) NOT NULL,
	[TaxonType] [nvarchar](1) NOT NULL,
	[Sex] [nvarchar](5) NULL,
	[Level] [smallint] NOT NULL,
	[Parent] [varchar](8000) NULL,
	[LevelUp] [bigint] NULL,
	[TypeSpecies] [nvarchar](1) NULL,
	[OrigGenus] [nvarchar](50) NULL,
	[OrigSpelling] [nvarchar](50) NULL,
	[StartAge] [smallint] NULL,
	[EndAge] [smallint] NULL,
	[GeologicAge] [nvarchar](1) NULL,
	[RecentGenera] [int] NULL,
	[FossilGenera] [int] NULL,
	[RecentSpecies] [int] NULL,
	[FossilSpecies] [int] NULL,
	[Page] [nvarchar](20) NULL,
	[Illustration] [nvarchar](50) NULL,
	[TaxonComment] [varchar](max) NULL,
	[Commonname] [nvarchar](50) NULL,
	[TypeForGroup] [int] NULL,
	[TaxonKey] [int] NULL,
	[PhylumKey] [int] NULL,
	[OldKey] [int] NULL,
	[OldId] [bigint] NULL,
	[LevelUpOld] [int] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Taxon_TaxonId] PRIMARY KEY CLUSTERED 
(
	[TaxonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxonAuthor]    Script Date: 3/6/2016 8:02:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonAuthor](
	[TaxonAuthorId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
	[TaxonId] [int] NOT NULL,
	[Ordering] [smallint] NULL,
 CONSTRAINT [PK_TaxonAuthor_TaxonAuthorId] PRIMARY KEY CLUSTERED 
(
	[TaxonAuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaxonLiterature]    Script Date: 3/6/2016 8:02:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonLiterature](
	[TaxonLiteratureId] [int] NOT NULL,
	[TaxonId] [int] NOT NULL,
	[LiteratureId] [int] NOT NULL,
 CONSTRAINT [PK_TaxonLiterature_TaxonLiteratureId] PRIMARY KEY CLUSTERED 
(
	[TaxonLiteratureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LiteratureAuthor]  WITH CHECK ADD  CONSTRAINT [FK_LiteratureAuthor_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([AuthorId])
GO
ALTER TABLE [dbo].[LiteratureAuthor] CHECK CONSTRAINT [FK_LiteratureAuthor_AuthorId]
GO
ALTER TABLE [dbo].[LiteratureAuthor]  WITH CHECK ADD  CONSTRAINT [FK_LiteratureAuthor_LiteratureId] FOREIGN KEY([LiteratureId])
REFERENCES [dbo].[Literature] ([LiteratureId])
GO
ALTER TABLE [dbo].[LiteratureAuthor] CHECK CONSTRAINT [FK_LiteratureAuthor_LiteratureId]
GO
ALTER TABLE [dbo].[TaxonAuthor]  WITH CHECK ADD  CONSTRAINT [FK_TaxonAuthor_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([AuthorId])
GO
ALTER TABLE [dbo].[TaxonAuthor] CHECK CONSTRAINT [FK_TaxonAuthor_AuthorId]
GO
ALTER TABLE [dbo].[TaxonAuthor]  WITH CHECK ADD  CONSTRAINT [FK_TaxonAuthor_TaxonId] FOREIGN KEY([TaxonId])
REFERENCES [dbo].[Taxon] ([TaxonId])
GO
ALTER TABLE [dbo].[TaxonAuthor] CHECK CONSTRAINT [FK_TaxonAuthor_TaxonId]
GO
ALTER TABLE [dbo].[TaxonLiterature]  WITH CHECK ADD  CONSTRAINT [FK_TaxonLiterature_LiteratureId] FOREIGN KEY([LiteratureId])
REFERENCES [dbo].[Literature] ([LiteratureId])
GO
ALTER TABLE [dbo].[TaxonLiterature] CHECK CONSTRAINT [FK_TaxonLiterature_LiteratureId]
GO
ALTER TABLE [dbo].[TaxonLiterature]  WITH CHECK ADD  CONSTRAINT [FK_TaxonLiterature_TaxonId] FOREIGN KEY([TaxonId])
REFERENCES [dbo].[Taxon] ([TaxonId])
GO
ALTER TABLE [dbo].[TaxonLiterature] CHECK CONSTRAINT [FK_TaxonLiterature_TaxonId]
GO

USE [BiologyCatalog]
GO
/****** Object:  Sequence [dbo].[AuthorSequence]    Script Date: 3/6/2016 8:05:24 AM ******/
CREATE SEQUENCE [dbo].[AuthorSequence] 
 AS [int]
 START WITH 2000000
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [BiologyCatalog]
GO
/****** Object:  Sequence [dbo].[LiteratureAuthorSequence]    Script Date: 3/6/2016 8:05:24 AM ******/
CREATE SEQUENCE [dbo].[LiteratureAuthorSequence] 
 AS [int]
 START WITH 6000000
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [BiologyCatalog]
GO
/****** Object:  Sequence [dbo].[LiteratureSequence]    Script Date: 3/6/2016 8:05:24 AM ******/
CREATE SEQUENCE [dbo].[LiteratureSequence] 
 AS [int]
 START WITH 3000000
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [BiologyCatalog]
GO
/****** Object:  Sequence [dbo].[TaxonAuthorSequence]    Script Date: 3/6/2016 8:05:24 AM ******/
CREATE SEQUENCE [dbo].[TaxonAuthorSequence] 
 AS [int]
 START WITH 4000000
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [BiologyCatalog]
GO
/****** Object:  Sequence [dbo].[TaxonLiteratureSequence]    Script Date: 3/6/2016 8:05:24 AM ******/
CREATE SEQUENCE [dbo].[TaxonLiteratureSequence] 
 AS [int]
 START WITH 5000000
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [BiologyCatalog]
GO
/****** Object:  Sequence [dbo].[TaxonSequence]    Script Date: 3/6/2016 8:05:24 AM ******/
CREATE SEQUENCE [dbo].[TaxonSequence] 
 AS [int]
 START WITH 1000000
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO