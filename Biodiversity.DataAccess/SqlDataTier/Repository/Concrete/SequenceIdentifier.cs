namespace Biodiversity.DataAccess.SqlDataTier.Repository.Concrete
{
    public enum SequenceIdentifier
    {
        AuthorSequence,
        LiteratureAuthorSequence,
        LiteratureSequence,
        TaxonAuthorSequence,
        TaxonLiteratureSequence,
        TaxonSequence
    }
}

/*
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

    */

