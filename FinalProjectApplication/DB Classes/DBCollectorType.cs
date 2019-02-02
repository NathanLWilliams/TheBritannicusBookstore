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
    /// Represents a type of collector in the database and contains related CRUD operations
    /// </summary>
    public class DBCollectorType
    {
        /// <summary>
        /// The unique identification number of a type of collector
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The descriptive name for a type of collector
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Used to instantiate a type of collector with the passed id and name
        /// </summary>
        /// <param name="id">The unique identification number of a type of collector</param>
        /// <param name="name">The descriptive name for a type of collector</param>
        public DBCollectorType(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets a list of all the types of collectors in the database
        /// </summary>
        /// <returns>A list of all the types of collectors in the database</returns>
        public static BindingList<DBCollectorType> GetCollectorTypes()
        {
            BindingList<DBCollectorType> customerTypes = new BindingList<DBCollectorType>();
            string query = "SELECT * FROM customerTypes";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DBCollectorType temp = new DBCollectorType((int)reader["customerTypeID"], (string)reader["customerTypeName"]);
                    customerTypes.Add(temp);
                }

            }
            return customerTypes;
        }
    }
}
