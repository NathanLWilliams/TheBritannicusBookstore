using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectApplication
{
    /// <summary>
    /// Used to represent a book in the database and contains related CRUD operations
    /// </summary>
    public class DBBook : DBItem
    {
        /// <summary>
        /// A unique identification number for a book
        /// </summary>
        public int BookID
        {
            get
            {
                return this.itemID;
            }
        }
        
        /// <summary>
        /// The title of the book
        /// </summary>
        public string Title
        {
            get
            {
                return this.GetDescription();
            }
        }

        /// <summary>
        /// A unique identification number for the book's genre
        /// </summary>
        private int genreID;

        /// <summary>
        /// The genre of the book
        /// </summary>
        public string GenreName
        {
            get;
            set;
        }

        /// <summary>
        /// The first name of the author of the book
        /// </summary>
        private string authorFirst;

        /// <summary>
        /// The last name of the author of the book
        /// </summary>
        private string authorLast;

        /// <summary>
        /// The full name of the author of the book
        /// </summary>
        public string Author
        {
            get
            {
                return this.authorFirst + " " + this.authorLast;
            }
        }

        /// <summary>
        /// The publisher of the book
        /// </summary>
        public string Publisher
        {
            get;
            set;
        }

        /// <summary>
        /// The date the book was published
        /// </summary>
        public DateTime PublishDate
        {
            get;
            set;
        }

        /// <summary>
        /// The book edition
        /// </summary>
        public byte Edition
        {
            get
            {
                return this.edition;
            }
        }

        /// <summary>
        /// The descriptive name for the condition of the book
        /// </summary>
        public string ConditionType
        {
            get
            {
                return this.conditionType;
            }
        }

        /// <summary>
        /// The number of this book in stock
        /// </summary>
        public int Quantity
        {
            get
            {
                return this.quantity;
            }
        }

        /// <summary>
        /// The price of the book
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.GetPrice();
            }
        }

        /// <summary>
        /// What is displayed when populating a combobox with books
        /// </summary>
        public string ComboBoxDisplay
        {
            get
            {
                return this.Title + " (" + this.BookID + ")";
            }
        }

        /// <summary>
        /// Used to instantiate a new book with the passed arguments
        /// </summary>
        /// <param name="bookID">A unique identification number for the book</param>
        /// <param name="title">The title of the book</param>
        /// <param name="genreID">A unique identification number for the book's genre</param>
        /// <param name="authorFirst">The first name of the author of the book</param>
        /// <param name="authorLast">The last name of the author of the book</param>
        /// <param name="publisher">The publisher of the book</param>
        /// <param name="publishDate">The date the book was published</param>
        /// <param name="edition">The book edition</param>
        /// <param name="quantity">The number of this book in stock</param>
        /// <param name="conditionID">A unique identification number for the condition of the book</param>
        /// <param name="price">The price of the book</param>
        public DBBook(int bookID, string title, int genreID, string authorFirst, string authorLast, string publisher, DateTime publishDate, byte edition, int quantity, int conditionID, decimal price) : base(bookID, "Book", title, price, edition, quantity, conditionID)
        {
            this.genreID = genreID;
            this.GenreName = GetGenreName();
            this.authorFirst = authorFirst;
            this.authorLast = authorLast;
            this.Publisher = publisher;
            this.PublishDate = publishDate;
        }

        /// <summary>
        /// Validates a book with the passed arguments and returns an error message if invalid
        /// </summary>
        /// <param name="price">The price of the book</param>
        /// <param name="description">The title/description of the book</param>
        /// <param name="authorFirst">The first name of the author of the book</param>
        /// <param name="authorLast">The last name of the author of the book</param>
        /// <param name="publisher">The publisher of the book</param>
        /// <param name="publishDate">The date the book was published</param>
        /// <returns>An error message if invalid</returns>
        public static string Validate(decimal price, string description, string authorFirst, string authorLast, string publisher, DateTime publishDate)
        {
            string errorMessage = DBItem.Validate(price, description);

            if (String.IsNullOrEmpty(authorFirst))
            {
                errorMessage += "Author first name cannot be empty." + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(authorLast))
            {
                errorMessage += "Author last name cannot be empty." + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(publisher))
            {
                errorMessage += "Publisher cannot be empty." + Environment.NewLine;
            }
            if(publishDate > DateTime.Now)
            {
                errorMessage += "Publish date cannot be greater than the current date." + Environment.NewLine;
            }

            return errorMessage;
        }

        /// <summary>
        /// Gets the first name of the author of the book
        /// </summary>
        /// <returns>The first name of the author of the book</returns>
        public string GetAuthorFirst()
        {
            return this.authorFirst;
        }

        /// <summary>
        /// Gets the last name of the author of the book
        /// </summary>
        /// <returns>The last name of the author of the book</returns>
        public string GetAuthorLast()
        {
            return this.authorLast;
        }

        /// <summary>
        /// Gets the unique identification number for the genre of the book
        /// </summary>
        /// <returns>The unique identification number for the genre of the book</returns>
        public int GetGenreID()
        {
            return this.genreID;
        }

        /// <summary>
        /// Gets a list of all the books in the database
        /// </summary>
        /// <returns>A list of all the books in the database</returns>
        public static BindingList<DBBook> GetBooks()
        {
            BindingList<DBBook> books = new BindingList<DBBook>();
            string query = "SELECT bookID, itemDescription, genreID, authorFirst, authorLast, publisher, publishDate, edition, quantity, conditionID, price " +
                           "FROM books, inventory, items " +
                           "WHERE inventory.itemID = books.bookID AND books.bookID = items.itemID AND items.isActive = 1";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new DBBook((int)reader["bookID"], (string)reader["itemDescription"], (int)reader["genreID"], (string)reader["authorFirst"], (string)reader["authorLast"], (string)reader["publisher"], (DateTime)reader["publishDate"], (byte)reader["edition"], (int)reader["quantity"], (int)reader["conditionID"], (decimal)reader["price"]));
                    }
                }   
            }
            return books;
        }

        /// <summary>
        /// Gets the descriptive name of the genre of the book
        /// </summary>
        /// <returns>The descriptive name of the genre of the book</returns>
        public string GetGenreName()
        {
            string genreName = "";
            string query = "SELECT genreName FROM genres WHERE genreID = '" + this.genreID + "'";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    genreName = (string)reader[0];
                }

            }
            return genreName;
        }

        /// <summary>
        /// Updates an existing book matching the passed bookID with the passed arguments
        /// </summary>
        /// <param name="bookID">The id of the book to update</param>
        /// <param name="itemDescription">The title/description to update</param>
        /// <param name="price">The price to update</param>
        /// <param name="edition">The edition of the book to update</param>
        /// <param name="genreID">The unique identifier of the genre of the book to update</param>
        /// <param name="authorFirst">The first name of the author of the book to update</param>
        /// <param name="authorLast">The last name of the author of the book to update</param>
        /// <param name="publisher">The publisher of the book to update</param>
        /// <param name="publishDate">The publish date of the book to update</param>
        /// <param name="conditionID">The unique identifier for the condition of the book to update</param>
        /// <param name="quantity">The number of this book left in stock to update</param>
        /// <returns>If the book was updated successfully</returns>
        public static bool UpdateBook(int bookID, string itemDescription, decimal price, int edition, int genreID, string authorFirst, string authorLast, string publisher, DateTime publishDate, int conditionID, int quantity = 1)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("UpdateBook", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@bookID", SqlDbType.Int).Value = bookID;
                    command.Parameters.Add("@itemDescription", SqlDbType.VarChar).Value = itemDescription;
                    command.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                    command.Parameters.Add("@edition", SqlDbType.TinyInt).Value = edition;
                    command.Parameters.Add("@genreID", SqlDbType.Int).Value = genreID;
                    command.Parameters.Add("@authorFirst", SqlDbType.VarChar).Value = authorFirst;
                    command.Parameters.Add("@authorLast", SqlDbType.VarChar).Value = authorLast;
                    command.Parameters.Add("@publisher", SqlDbType.VarChar).Value = publisher;
                    command.Parameters.Add("@publishDate", SqlDbType.Date).Value = publishDate;
                    command.Parameters.Add("@conditionID", SqlDbType.Int).Value = conditionID;
                    command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;

                }
            }
        }
        /*public bool UpdateBook()
        {
            return DBBook.UpdateBook(this.BookID, this.Title, this.Price, this.Edition, this.GetGenreID(), this.GetAuthorFirst(), this.GetAuthorLast(), this.Publisher, this.PublishDate, this.GetConditionID(), this.Quantity);
        }*/

        /// <summary>
        /// Inserts a new book into the database with the passed arguments and then returns the id of the inserted book
        /// </summary>
        /// <param name="itemDescription">The title/description of the book</param>
        /// <param name="price">The price of the book</param>
        /// <param name="edition">The edition of the book</param>
        /// <param name="genreID">The unique identifier for the genre of the book</param>
        /// <param name="authorFirst">The first name of the author of the book</param>
        /// <param name="authorLast">The last name of the author of the book</param>
        /// <param name="publisher">The publisher of the book</param>
        /// <param name="publishDate">The date the book was published</param>
        /// <param name="conditionID">The unique identifier for the condition of the book</param>
        /// <param name="quantity">The number of the book in stock</param>
        /// <returns>The id of the inserted book if successful, otherwise null</returns>
        public static object InsertBook(string itemDescription, decimal price, int edition, int genreID, string authorFirst, string authorLast, string publisher, DateTime publishDate, int conditionID, int quantity = 1)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("InsertBook", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@itemDescription", SqlDbType.VarChar).Value = itemDescription;
                    command.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                    command.Parameters.Add("@edition", SqlDbType.TinyInt).Value = edition;
                    command.Parameters.Add("@genreID", SqlDbType.Int).Value = genreID;
                    command.Parameters.Add("@authorFirst", SqlDbType.VarChar).Value = authorFirst;
                    command.Parameters.Add("@authorLast", SqlDbType.VarChar).Value = authorLast;
                    command.Parameters.Add("@publisher", SqlDbType.VarChar).Value = publisher;
                    command.Parameters.Add("@publishDate", SqlDbType.Date).Value = publishDate;
                    command.Parameters.Add("@conditionID", SqlDbType.Int).Value = conditionID;
                    command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return returnParameter.Value;

                }
            }
        }

        /// <summary>
        /// Gets a book with the passed id from the database
        /// </summary>
        /// <param name="id">The id of the book to pull from the database</param>
        /// <returns>A book with the passed id</returns>
        public static DBBook GetBookOfId(int id)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("GetBookOfId", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                DBBook book;
                conn.Open();
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    book = new DBBook((int)reader["bookID"], (string)reader["itemDescription"], (int)reader["genreID"], (string)reader["authorFirst"], (string)reader["authorLast"], (string)reader["publisher"], (DateTime)reader["publishDate"], (byte)reader["edition"], (int)reader["quantity"], (int)reader["conditionID"], (decimal)reader["price"]);
                }
                else
                {
                    book = new DBBook(0, "", 1, "", "", "", DateTime.Now, 0, 0, 1, 0);
                }
                return book;
            }
        }
    }
}
