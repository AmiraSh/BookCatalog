namespace BookCatalog.DAL.Concrete
{
    #region Using
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Xml;
    using Interfaces;
    using Models;
    #endregion

    /// <summary>
    /// Implementation of book repository interface.
    /// </summary>
    public sealed class BookRepository : GenericRepository<BookCatalogContext, Book>, IBookRepository
    {
        /// <summary>
        /// Gets book's authors.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        /// <returns>Book's authors.</returns>
        public IEnumerable<Author> GetAuthors(int bookId)
        {
            List<Author> authors = new List<Author>();
            Book book = FindById(bookId);
            foreach (Author author in book.Authors)
            {
                authors.Add(author);
            }

            return authors;
        }
        
        /// <summary>
        /// Set a new book author.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        /// <param name="author">New book author.</param>
        public void SetAuthor(int bookId, Author author)
        {
            Book book = FindById(bookId);
            book.Authors.Add(author);
        }

        /// <summary>
        /// Set a book authors.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        /// <param name="authorsIds">Book authors' ids.</param>
        public void SetAuthors(int bookId, List<int> authorsIds)
        {
            Book book = FindById(bookId);
            foreach (int authorId in authorsIds)
            {
                Author author = this.Context.Set<Author>().Find(authorId);
                book.Authors.Add(author);
            }
        }
        
        /// <summary>
        /// Gets data in XML document.
        /// </summary>
        /// <returns>XML document.</returns>
        public XmlDocument GetXML()
        {
            SqlConnection sqlConnection = new SqlConnection(base.Context.Database.Connection.ConnectionString);
            SqlCommand command = new SqlCommand();

            command.CommandText = "sp_GetXMLExpand";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = sqlConnection;

            sqlConnection.Open();
            XmlDocument document = new XmlDocument();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    document.LoadXml((string)reader["XML_FILE"]);
                }
            }

            sqlConnection.Close();
            return document;
        }
    }
}