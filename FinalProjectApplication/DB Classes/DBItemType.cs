using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectApplication
{
    /// <summary>
    /// Used to represent an item type in the database and contains any related CRUD operations
    /// </summary>
    public class DBItemType
    {
        /// <summary>
        /// A unique identification number for an item type in the database
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The descriptive name for the type of item
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Used to instantiate a new item type with the passed id and name
        /// </summary>
        /// <param name="id">A unique identification number for an item type</param>
        /// <param name="name">The descriptive name for the item type</param>
        public DBItemType(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets a list of all the item types in the database
        /// </summary>
        /// <returns>A list of all the item types in the database</returns>
        public static BindingList<DBItemType> GetItemTypes()
        {
            BindingList<DBItemType> itemTypes = new BindingList<DBItemType>();
            string query = "SELECT * FROM itemTypes";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DBItemType temp = new DBItemType((int)reader["itemTypeID"], (string)reader["itemTypeName"]);
                    itemTypes.Add(temp);
                }

            }
            return itemTypes;
        }
    }
}
