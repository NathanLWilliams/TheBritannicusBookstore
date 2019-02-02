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
    /// Used to represent an employee position in the database and contains related CRUD operations
    /// </summary>
    public class DBEmployeePosition
    {
        /// <summary>
        /// The unique identification number of the employee position
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The descriptive name of the employee position
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Used to instantiate a new employee position with the specified id and descriptive name
        /// </summary>
        /// <param name="id">The unique identification number of an employee position</param>
        /// <param name="name">The descriptive name of the employee position</param>
        public DBEmployeePosition(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets a list of all the employee positions in the database
        /// </summary>
        /// <returns>A list of all the employee positions in the database</returns>
        public static BindingList<DBEmployeePosition> GetEmployeePositions()
        {
            BindingList<DBEmployeePosition> employeePositions = new BindingList<DBEmployeePosition>();
            string query = "SELECT * FROM employeePositions";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DBEmployeePosition temp = new DBEmployeePosition((int)reader["positionID"], (string)reader["positionName"]);
                    employeePositions.Add(temp);
                }

            }
            return employeePositions;
        }
    }
}
