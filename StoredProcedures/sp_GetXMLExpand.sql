CREATE PROCEDURE sp_GetXMLExpand
AS
	SET NOCOUNT ON;
	DECLARE @Catalog XML, @Authors XML;
	SET @Catalog = '<root></root>';
	DECLARE @BookStr XML, @AuthorStr XML;
	DECLARE @book_id int, @author_id int;

	DECLARE book_cursor CURSOR FOR 
		SELECT book.Id FROM Book book
	OPEN book_cursor

	FETCH NEXT FROM book_cursor
		INTO @book_id

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @BookStr = (SELECT * FROM Book WHERE Id = @book_id
			FOR XML PATH(''), ROOT('Book'), ELEMENTS)

		SET @Catalog.modify('insert sql:variable("@BookStr") as last into /root[1]')

		DECLARE author_cursor CURSOR FOR 
			SELECT author.Id
			FROM Author author
			WHERE author.Id IN 
				(SELECT Author_Id FROM BookAuthor
				WHERE Book_Id = @book_id)

		OPEN author_cursor
		FETCH NEXT FROM author_cursor INTO @author_id
		SET @Authors = '<Authors></Authors>'

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @AuthorStr = (SELECT * FROM Author WHERE Id = @author_id
				FOR XML PATH(''), ROOT('Author'), ELEMENTS)
			
			SET @Authors.modify('insert sql:variable("@AuthorStr") as last into (/Authors)[1]')
			
			FETCH NEXT FROM author_cursor INTO @author_id
		END

		CLOSE author_cursor
		DEALLOCATE author_cursor
		
		SET @Catalog.modify('insert sql:variable("@Authors") as last into (/root/Book[Id = sql:variable("@book_id")])[1]')

		FETCH NEXT FROM book_cursor
			INTO @book_id
	END 
	CLOSE book_cursor;
	DEALLOCATE book_cursor;
	SELECT (@Catalog) AS XML_FILE
RETURN 0