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
    /// Represents an item condition in the database and contains related CRUD operations
    /// </summary>
    public class DBCondition
    {
        /// <summary>
        /// The unique identification number of an item condition
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The descriptive name of an item condition
        /// </summary>
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// Used to instantiate a new item condition with the passed id and type
        /// </summary>
        /// <param name="id">The unique identifier for an item condition</param>
        /// <param name="type">The descriptive name of an item condition</param>
        public DBCondition(int id, string type)
        {
            this.ID = id;
            this.Type = type;
        }

        /// <summary>
        /// Gets a list of all the conditions in the database
        /// </summary>
        /// <returns>A list of all the conditions in the database</returns>
        public static BindingList<DBCondition> GetConditions()
        {
            BindingList<DBCondition> conditions = new BindingList<DBCondition>();
            string query = "SELECT * FROM conditions";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DBCondition temp = new DBCondition((int)reader["conditionID"], (string)reader["conditionType"]);
                    conditions.Add(temp);
                }

            }
            return conditions;
        }
    }
}
