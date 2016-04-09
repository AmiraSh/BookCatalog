CREATE PROCEDURE sp_GetXMLBookExpand
AS
	SELECT (
		(SELECT Book.Id, Book.Name, Book.PagesCount, Book.PublishedDate, 
			Book.Rating, Book.Description,
		(SELECT Author.Id AS Id, 
			Author.FirstName AS FirstName, 
			Author.SecondName AS LastName
			FROM Author INNER JOIN BookAuthor
			ON BookAuthor.Author_Id = Author.Id
			WHERE BookAuthor.Book_Id = Book.Id
			ORDER BY Author.Id
			FOR XML AUTO, ROOT('Authors'), TYPE)
		FROM BookAuthor INNER JOIN Book
			ON BookAuthor.Book_Id = Book.Id
			GROUP BY Book.Id, Book.Name, Book.PagesCount, Book.PublishedDate, 
				Book.Rating, Book.Description
			ORDER BY Book.Id
		FOR XML AUTO, ROOT('root'), ELEMENTS)  
	) AS XML_FILE
RETURN 0