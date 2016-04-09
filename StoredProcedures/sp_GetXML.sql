CREATE PROCEDURE sp_GetXML
AS
	SELECT (
		(SELECT Book.Id, Book.Name, Book.PagesCount, Book.PublishedDate, 
			Book.Rating, Book.Description,
		(SELECT Author.Id, Author.FirstName, Author.SecondName
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
		FOR XML AUTO, ROOT('root'), TYPE)  
	) AS XML_FILE
RETURN 0