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
    /// Represents a periodical in the database and includes all related CRUD operations
    /// </summary>
    public class DBPeriodical : DBItem
    {
        /// <summary>
        /// A unique identifier for a periodical
        /// </summary>
        public int PeriodicalID
        {
            get
            {
                return this.itemID;
            }
        }

        /// <summary>
        /// The title of the periodical
        /// </summary>
        public string Title
        {
            get
            {
                return this.GetDescription();
            }
        }

        /// <summary>
        /// The unique identification number for the periodical genre
        /// </summary>
        private int genreID;

        /// <summary>
        /// The genre of the periodical
        /// </summary>
        public string GenreName
        {
            get;
            set;
        }

        /// <summary>
        /// The company of the periodical
        /// </summary>
        public string CompanyName
        {
            get;
            set;
        }

        /// <summary>
        /// The publish date of the periodical
        /// </summary>
        public DateTime PublishDate
        {
            get;
            set;
        }

        /// <summary>
        /// The periodical edition
        /// </summary>
        public byte Edition
        {
            get
            {
                return this.edition;
            }
        }

        /// <summary>
        /// The descriptive name of the condition this item is in
        /// </summary>
        public string ConditionType
        {
            get
            {
                return this.conditionType;
            }
        }

        /// <summary>
        /// The quantity of this periodical in stock
        /// </summary>
        public int Quantity
        {
            get
            {
                return this.quantity;
            }
        }

        /// <summary>
        /// The price of this periodical
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.GetPrice();
            }
        }

        /// <summary>
        /// The text used as the display member when populating comboboxes with periodicals
        /// </summary>
        public string ComboBoxDisplay
        {
            get
            {
                return this.Title + " (" + this.PeriodicalID + ")";
            }
        }

        /// <summary>
        /// Used to instantiate a new periodical
        /// </summary>
        /// <param name="itemID">A unique identifier for an item</param>
        /// <param name="companyName">The company name of the periodical</param>
        /// <param name="title">The title of the periodical</param>
        /// <param name="genreID">The unique identification number of the periodical genre</param>
        /// <param name="publishDate">The publish date of the periodical</param>
        /// <param name="edition">The periodical edition</param>
        /// <param name="quantity">The quantity of this periodical in stock</param>
        /// <param name="conditionID">A unique indentification number for the conditino of this periodical</param>
        /// <param name="price">The price of this periodical</param>
        public DBPeriodical(int itemID, string companyName, string title, int genreID, DateTime publishDate, byte edition, int quantity, int conditionID, decimal price) : base(itemID, "Periodical", title, price, edition, quantity, conditionID)
        {
            this.CompanyName = companyName;
            this.genreID = genreID;
            this.GenreName = GetGenreName();
            this.PublishDate = publishDate;
        }

        /// <summary>
        /// Validates a periodical using the passed parameters and returns an error message if invalid
        /// </summary>
        /// <param name="price">The price of the periodical</param>
        /// <param name="description">The title of the periodical</param>
        /// <param name="companyName">The company name of the periodical</param>
        /// <param name="publishDate">The publish date of the periodical</param>
        /// <returns>An error message if invalid</returns>
        public static string Validate(decimal price, string description, string companyName, DateTime publishDate)
        {
            string errorMessage = DBItem.Validate(price, description);

            if (String.IsNullOrEmpty(companyName))
            {
                errorMessage += "Company name cannot be empty." + Environment.NewLine;
            }
            if (publishDate > DateTime.Now)
            {
                errorMessage += "Publish date cannot be greater than the current date." + Environment.NewLine;
            }

            return errorMessage;
        }

        /// <summary>
        /// Gets the unique identification number for this periodical's associated genre
        /// </summary>
        /// <returns>A unique genre indentification number</returns>
        public int GetGenreID()
        {
            return this.genreID;
        }

        /// <summary>
        /// Gets the descriptive name for this periodical's associated genre
        /// </summary>
        /// <returns>A descriptive name for a genre</returns>
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
        /// Gets a list of all the periodicals in the database
        /// </summary>
        /// <returns>A list of all the periodicals in the database</returns>
        public static BindingList<DBPeriodical> GetPeriodicals()
        {
            BindingList<DBPeriodical> periodicals = new BindingList<DBPeriodical>();
            string query = "SELECT periodicalID, companyName, itemDescription, genreID, date, edition, quantity, conditionID, price " +
                           "FROM periodicals, inventory, items " +
                           "WHERE inventory.itemID = periodicals.periodicalID AND periodicals.periodicalID = items.itemID AND items.isActive = 1";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        periodicals.Add(new DBPeriodical((int)reader["periodicalID"], (string)reader["companyName"], (string)reader["itemDescription"], (int)reader["genreID"], (DateTime)reader["date"], (byte)reader["edition"], (int)reader["quantity"], (int)reader["conditionID"], (decimal)reader["price"]));
                    }
                }
            }
            return periodicals;
        }

        /// <summary>
        /// Updates a periodical in the database with the specified periodicalID using the passed arguments
        /// </summary>
        /// <param name="periodicalID">The unique id of a periodical</param>
        /// <param name="itemDescription">The description/title of the periodical</param>
        /// <param name="price">The price of the periodical</param>
        /// <param name="edition">The periodical edition</param>
        /// <param name="companyName">The company name of the periodical</param>
        /// <param name="genreID">A unique identification number for a genre</param>
        /// <param name="date">The publish date of the periodical</param>
        /// <param name="conditionID">A unique identification number for a condition</param>
        /// <param name="quantity">The number of this periodical in stock</param>
        /// <returns>If the update was successful</returns>
        public static bool UpdatePeriodical(int periodicalID, string itemDescription, decimal price, int edition, string companyName, int genreID, DateTime date, int conditionID, int quantity = 1)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("UpdatePeriodical", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@periodicalID", SqlDbType.Int).Value = periodicalID;
                    command.Parameters.Add("@itemDescription", SqlDbType.VarChar).Value = itemDescription;
                    command.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                    command.Parameters.Add("@edition", SqlDbType.TinyInt).Value = edition;
                    command.Parameters.Add("@companyName", SqlDbType.VarChar).Value = companyName;
                    command.Parameters.Add("@genreID", SqlDbType.Int).Value = genreID;
                    command.Parameters.Add("@date", SqlDbType.Date).Value = date;
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

        /// <summary>
        /// Inserts a new periodical into the database using the passed arguments
        /// </summary>
        /// <param name="itemDescription">The title/description of the periodical</param>
        /// <param name="price">The price of the periodical</param>
        /// <param name="edition">The periodical edition</param>
        /// <param name="companyName">The company name of the periodical</param>
        /// <param name="genreID">A unique identification number for a genre</param>
        /// <param name="date">The publish date of the periodical</param>
        /// <param name="conditionID">A unique identification number for a condition</param>
        /// <param name="quantity">The number of the periodical in stock</param>
        /// <returns>The id of the inserted periodical, or null if it fails</returns>
        public static object InsertPeriodical(string itemDescription, decimal price, int edition, string companyName, int genreID, DateTime date, int conditionID, int quantity = 1)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("InsertPeriodical", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@itemDescription", SqlDbType.VarChar).Value = itemDescription;
                    command.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                    command.Parameters.Add("@edition", SqlDbType.TinyInt).Value = edition;
                    command.Parameters.Add("@companyName", SqlDbType.VarChar).Value = companyName;
                    command.Parameters.Add("@genreID", SqlDbType.Int).Value = genreID;
                    command.Parameters.Add("@date", SqlDbType.Date).Value = date;
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
        /// Gets a periodical from the database with the passed id
        /// </summary>
        /// <param name="id">A unique identification number for a periodical</param>
        /// <returns>The periodical with the passed id</returns>
        public static DBPeriodical GetPeriodicalOfId(int id)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("GetPeriodicalOfId", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                DBPeriodical periodical;
                conn.Open();
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    periodical = new DBPeriodical((int)reader["periodicalID"], (string)reader["companyName"], (string)reader["itemDescription"], (int)reader["genreID"], (DateTime)reader["date"], (byte)reader["edition"], (int)reader["quantity"], (int)reader["conditionID"], (decimal)reader["price"]);
                }
                else
                {
                    periodical = new DBPeriodical(0, "", "", 1, DateTime.Now, 1, 0, 1, 0);
                }
                return periodical;
            }
        }
    }
}
