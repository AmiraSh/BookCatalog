CREATE PROCEDURE sp_GetTopAuthors
	@count int = 5,
	@beginDate date,
	@endDate date
AS
	IF(datediff(year, @beginDate, @endDate) <= 10)
	BEGIN

		SELECT TOP (@count)	author.*, SUM(book.Rating) AS TotalRating
		FROM Author author
		INNER JOIN BookAuthor map ON map.Author_Id = author.Id
		INNER JOIN Book book ON book.Id = map.Book_Id
		WHERE datediff(day, book.PublishedDate, @beginDate) <= 0 AND 
			datediff(day, @endDate, book.PublishedDate) <= 0
		GROUP BY author.Id, author.FirstName, author.SecondName
		ORDER BY SUM(book.Rating) DESC

	END;
RETURN 0