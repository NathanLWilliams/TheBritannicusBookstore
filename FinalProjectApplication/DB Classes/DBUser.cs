using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectApplication
{
    /// <summary>
    /// A class used to represent an employeeAccount record in the database and the currently logged in user.
    /// Includes methods to login or logout a user.
    /// </summary>
    public static class DBUser
    {

        /// <summary>
        /// A unique identifier for a user, used along with the password
        //  to login
        /// </summary>
        public static string Username
        {
            get;
            set;
        }

        /// <summary>
        /// The employee which this user is attached to
        /// </summary>
        public static DBEmployee Employee;

        /// <summary>
        /// The date which this user last logged in
        /// </summary>
        public static DateTime LastAccess
        {
            get;
            set;
        }

        /// <summary>
        /// Used to validate the username, password, and confirm password fields
        /// and return an error message if invalid
        /// </summary>
        /// <param name="username">The username to validate</param>
        /// <param name="password">The password to validate</param>
        /// <param name="confirmPassword">The confirm password to validate</param>
        /// <returns>An error message if invalid</returns>
        public static string Validate(string username, string password, string confirmPassword)
        {
            string errorMessage = "";

            if(String.IsNullOrEmpty(username))
            {
                errorMessage = "Username cannot be empty." + Environment.NewLine;
            }
            if(String.IsNullOrEmpty(password))
            {
                errorMessage += "Password cannot be empty." + Environment.NewLine;
            }
            if(!password.Equals(confirmPassword))
            {
                errorMessage += "Confirm password must match password.";
            }

            return errorMessage;
        }

        /// <summary>
        /// Queries the database to find a matching combination of username and password
        /// then grabs the employee the account belongs to
        /// </summary>
        /// <param name="username">The username to query for</param>
        /// <param name="password">The password to query for</param>
        /// <returns>True if successful</returns>
        public static bool Login(string username, string password)
        {
            bool result = false;

            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("Login", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = sha256(password);
                var reader = command.ExecuteReader();
                if(reader.Read())
                {
                    DBUser.Employee = new DBEmployee((int)reader["employeeID"], (int)reader["positionID"], (string)reader["firstName"], (string)reader["lastName"], (string)reader["phoneNumber"]);
                    DBUser.Username = username;
                    DBUser.LastAccess = (DateTime)reader["lastAccess"];
                    result = true;
                }
            }

            return result;
            
        }

        /// <summary>
        /// Updates the last access date of the account with the passed username
        /// to the database current date
        /// </summary>
        /// <param name="username">The username to query for</param>
        /// <returns>True if successful</returns>
        public static bool UpdateLastAccess(string username)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("UpdateLastAccess", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                return (int)command.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Attempts to insert a new employeeAccount into the database
        /// </summary>
        /// <param name="username">The new accounts username</param>
        /// <param name="password">The new accounts unhashed password</param>
        /// <param name="employeeID">The employeeID of the employee associated with this account</param>
        /// <returns>true if successful</returns>
        public static bool Register(string username, string password, int employeeID)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("Register", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = sha256(password);
                command.Parameters.Add("@employeeID", SqlDbType.Int).Value = employeeID;

                //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                return (int)returnParameter.Value > 0;
            }
        }

        /// <summary>
        /// Encrypts and returns the passed string using SHA256
        /// Method found here: https://stackoverflow.com/questions/12416249/hashing-a-string-with-sha256
        /// </summary>
        /// <param name="randomString">The string to encrypt</param>
        /// <returns>The encrypted string</returns>
        private static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        /// <summary>
        /// Logs the user out of the system
        /// </summary>
        public static void Logout()
        {
            DBUser.Username = "";
            DBUser.Employee = null;
            DBUser.LastAccess = DateTime.Now;
        }

        /// <summary>
        /// Returns the positionID of the attached employee, or -1 if there
        /// is no attached employee
        /// </summary>
        /// <returns>The positionID of the attached employee, or -1 if there is no attached employee</returns>
        public static int GetRole()
        {
            if(DBUser.Employee == null)
            {
                return -1;
            }
            else
            {
                return DBUser.Employee.PositionID;
            }
        }
    }
}
