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