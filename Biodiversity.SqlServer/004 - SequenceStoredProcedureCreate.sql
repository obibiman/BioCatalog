USE [BiologyCatalog]
GO

/****** Object:  StoredProcedure [dbo].[sp_BiologyCatalogSequence]    Script Date: 4/4/2016 5:55:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_BiologyCatalogSequence]
@SequenceName nvarchar(50),  
@SequenceValue INT OUTPUT
AS  

IF @SequenceName IS NULL
   BEGIN
       PRINT 'ERROR: You must specify a sequence name to execute.'
       RETURN(1)
   END
ELSE
	BEGIN
		IF @SequenceName = 'AuthorSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.AuthorSequence;
		IF @SequenceName = 'LiteratureAuthorSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.LiteratureAuthorSequence;
		IF @SequenceName = 'LiteratureSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.LiteratureSequence;
		IF @SequenceName = 'TaxonAuthorSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.TaxonAuthorSequence;
		IF @SequenceName = 'TaxonLiteratureSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.TaxonLiteratureSequence;
		IF @SequenceName = 'TaxonSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.TaxonSequence;
	END
SELECT @SequenceValue

GO

