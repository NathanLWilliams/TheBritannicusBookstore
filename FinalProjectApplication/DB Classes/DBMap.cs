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
    /// Represents a map in the database and contains related CRUD methods
    /// </summary>
    public class DBMap : DBItem
    {
        /// <summary>
        /// A unique identification number for a map
        /// </summary>
        public int MapID
        {
            get
            {
                return this.itemID;
            }
        }

        /// <summary>
        /// The publisher of the map
        /// </summary>
        public string Publisher
        {
            get;
            set;
        }

        /// <summary>
        /// The location depicted in the map
        /// </summary>
        public string Location
        {
            get
            {
                return this.GetDescription();
            }
        }

        /// <summary>
        /// The year the map was made
        /// </summary>
        public int Year
        {
            get;
            set;
        }

        /// <summary>
        /// The edition of the map
        /// </summary>
        public byte Edition
        {
            get
            {
                return this.edition;
            }
        }

        /// <summary>
        /// A description name for the condition of the map
        /// </summary>
        public string ConditionType
        {
            get
            {
                return this.conditionType;
            }
        }

        /// <summary>
        /// The number of the map in stock
        /// </summary>
        public int Quantity
        {
            get
            {
                return this.quantity;
            }
        }

        /// <summary>
        /// The price of the map
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.GetPrice();
            }
        }

        /// <summary>
        /// What is shown in comboboxes that are populated with maps
        /// </summary>
        public string ComboBoxDisplay
        {
            get
            {
                return this.Location + " (" + this.MapID + ")";
            }
        }

        /// <summary>
        /// Used to instantiate a new map with the passed arguments
        /// </summary>
        /// <param name="itemID">A unique identification number for the map</param>
        /// <param name="publisher">The publisher of the map</param>
        /// <param name="location">The location depicted in the map</param>
        /// <param name="year">The year the map was made</param>
        /// <param name="edition">The edition of the map</param>
        /// <param name="quantity">The number of the map in stock</param>
        /// <param name="conditionID">A unique indentification number for the condition of the map</param>
        /// <param name="price">The price of the map</param>
        public DBMap(int itemID, string publisher, string location, int year, byte edition, int quantity, int conditionID, decimal price) 
            : base(itemID, "Map", location, price, edition, quantity, conditionID)
        {
            this.Publisher = publisher;
            this.Year = year;
        }

        /// <summary>
        /// Validates a map using the passed arguments and returns an error message if invalid
        /// </summary>
        /// <param name="price">The price to validate</param>
        /// <param name="description">The description/location of the map to validate</param>
        /// <param name="year">The year to validate</param>
        /// <param name="publisher">The publisher to validate</param>
        /// <returns>An error message if invalid</returns>
        public static string Validate(decimal price, string description, int year, string publisher)
        {
            string errorMessage = DBItem.Validate(price, description);

            if (year > DateTime.Now.Year)
            {
                errorMessage += "Year cannot be greater than the current year." + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(publisher))
            {
                errorMessage += "Publisher cannot be empty." + Environment.NewLine;
            }

            return errorMessage;
        }

        /// <summary>
        /// Gets a list of maps pulled from the database
        /// </summary>
        /// <returns>A list of maps from the database</returns>
        public static BindingList<DBMap> GetMaps()
        {
            BindingList<DBMap> maps = new BindingList<DBMap>();
            string query = "SELECT mapID, publisher, itemDescription, year, edition, quantity, conditionID, price " +
                           "FROM maps, inventory, items " +
                           "WHERE inventory.itemID = maps.mapID AND maps.mapID = items.itemID AND items.isActive = 1";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        maps.Add(new DBMap((int)reader["mapID"], (string)reader["publisher"], (string)reader["itemDescription"], Convert.ToInt32(reader["year"]), (byte)reader["edition"], (int)reader["quantity"], (int)reader["conditionID"], (decimal)reader["price"]));
                    }
                } 
            }
            return maps;
        }

        /// <summary>
        /// Updates a map currently in the database with the passed mapID using the passed arguments
        /// </summary>
        /// <param name="mapID">The id of the map to update</param>
        /// <param name="itemDescription">The location/description of the map to update</param>
        /// <param name="price">The price to update</param>
        /// <param name="edition">The edition to update</param>
        /// <param name="publisher">The publisher to update</param>
        /// <param name="year">The year to update</param>
        /// <param name="conditionID">The unique identification number of the map to update</param>
        /// <param name="quantity">The stock of the map to update</param>
        /// <returns>If a map was updated successfully</returns>
        public static bool UpdateMap(int mapID, string itemDescription, decimal price, int edition, string publisher, int year, int conditionID, int quantity = 1)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("UpdateMap", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@mapID", SqlDbType.Int).Value = mapID;
                    command.Parameters.Add("@itemDescription", SqlDbType.VarChar).Value = itemDescription;
                    command.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                    command.Parameters.Add("@edition", SqlDbType.TinyInt).Value = edition;
                    command.Parameters.Add("@publisher", SqlDbType.VarChar).Value = publisher;
                    command.Parameters.Add("@year", SqlDbType.SmallInt).Value = year;
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
        /// Inserts a new map into the database with the passed arguments
        /// </summary>
        /// <param name="itemDescription">The location/description of the map</param>
        /// <param name="price">The price of the map</param>
        /// <param name="edition">The edition of the map</param>
        /// <param name="publisher">The publisher of the map</param>
        /// <param name="year">The year of the map</param>
        /// <param name="conditionID">The unique identification number for the condition of the map</param>
        /// <param name="quantity">The number of this map left in stock</param>
        /// <returns>The id of the inserted map if successful, otherwise null</returns>
        public static object InsertMap(string itemDescription, decimal price, int edition, string publisher, int year, int conditionID, int quantity = 1)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("InsertMap", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@itemDescription", SqlDbType.VarChar).Value = itemDescription;
                    command.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                    command.Parameters.Add("@edition", SqlDbType.TinyInt).Value = edition;
                    command.Parameters.Add("@publisher", SqlDbType.VarChar).Value = publisher;
                    command.Parameters.Add("@year", SqlDbType.SmallInt).Value = year;
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
        /// Gets a map with the passed id in the database
        /// </summary>
        /// <param name="id">The id of the map to pull</param>
        /// <returns>The map with the passed id</returns>
        public static DBMap GetMapOfId(int id)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("GetMapOfId", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                DBMap map;
                conn.Open();
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    map = new DBMap((int)reader["mapID"], (string)reader["publisher"], (string)reader["itemDescription"], Convert.ToInt32(reader["year"]), (byte)reader["edition"], (int)reader["quantity"], (int)reader["conditionID"], (decimal)reader["price"]);
                }
                else
                {
                    map = new DBMap(0, "", "", 0, 0, 0, 1, 0);
                }
                return map;
            }
        }
    }
}
