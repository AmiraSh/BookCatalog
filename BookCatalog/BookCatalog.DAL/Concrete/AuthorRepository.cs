namespace BookCatalog.DAL.Concrete
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using BookCatalog.DAL.Models;
    using Interfaces;
    #endregion

    /// <summary>
    /// Implementation of author repository interface.
    /// </summary>
    public sealed class AuthorRepository : GenericRepository<BookCatalogContext, Author>, IAuthorRepository
    {
        /// <summary>
        /// Gets author's books.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <returns>Author's books.</returns>
        public IEnumerable<Book> GetBooks(int authorId)
        {
            List<Book> books = new List<Book>();
            Author author = FindById(authorId);
            foreach (Book book in author.Books)
            {
                books.Add(book);
            }

            return books;
        }

        /// <summary>
        /// Set a new author book.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <param name="book">New author book.</param>
        public void SetBook(int authorId, Book book)
        {
            Author author = FindById(authorId);
            author.Books.Add(book);
        }

        /// <summary>
        /// Gets top x authors in specific period, no longer then 10 years.
        /// </summary>
        /// <param name="count">Count of authors to return.</param>
        /// <param name="beginDate">Begin date.</param>
        /// <param name="endDate">End date.</param>
        /// <returns>Top authors.</returns>
        public IDictionary<Author, int> GetTopAuthors(int count, DateTime beginDate, DateTime endDate)
        {
            SqlConnection sqlConnection = new SqlConnection(base.Context.Database.Connection.ConnectionString);
            SqlCommand command = new SqlCommand();

            command.CommandText = "sp_GetTopAuthors";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@beginDate", SqlDbType.Date).Value = beginDate.Date;
            command.Parameters.Add("@endDate", SqlDbType.Date).Value = endDate.Date;
            command.Connection = sqlConnection;

            sqlConnection.Open();

            Dictionary<Author, int> authors = new Dictionary<Author, int>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    authors.Add(
                        new Author()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = Convert.ToString(reader["FirstName"]),
                            SecondName = Convert.ToString(reader["SecondName"])
                        },
                        Convert.ToInt32(reader["TotalRating"]));
                }
            }

            sqlConnection.Close();
            return authors;
        }
    }
}