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
    /// Used to represent an employee in the database and contains related CRUD operations
    /// </summary>
    public class DBEmployee
    {
        /// <summary>
        /// The unique identification number of an employee
        /// </summary>
        public int EmployeeID
        {
            get;
            set;
        }

        /// <summary>
        /// The unique identification number of the position of an employee
        /// </summary>
        public int PositionID
        {
            get;
            set;
        }

        /// <summary>
        /// The descriptive name of the position of an employee
        /// </summary>
        public string PositionName
        {
            get;
            set;
        }

        /// <summary>
        /// The first name of an employee
        /// </summary>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// The last name of an employee
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// The full name of an employee
        /// </summary>
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        /// <summary>
        /// The phone number of an employee
        /// </summary>
        public string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// What is displayed when a combobox is populated with employees
        /// </summary>
        public string ComboBoxDisplay
        {
            get
            {
                return this.FullName + " (" + this.EmployeeID + ")";
            }
        }

        /// <summary>
        /// Used to instantiate a new employee with the passed arguments
        /// </summary>
        /// <param name="empID">The unique identification number of an employee</param>
        /// <param name="posID">The unique identification number of the position of an employee</param>
        /// <param name="firstName">The first name of the employee</param>
        /// <param name="lastName">The last name of the employee</param>
        /// <param name="phoneNum">The phone number of the employee</param>
        public DBEmployee(int empID, int posID, string firstName, string lastName, string phoneNum)
        {
            this.EmployeeID = empID;
            this.PositionID = posID;
            this.PositionName = GetEmployeePositionName();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNum;
        }

        /// <summary>
        /// Validates an employee with the passed arguments, returns an error message if invalid
        /// </summary>
        /// <param name="firstName">The first name to validate</param>
        /// <param name="lastName">The last name to validate</param>
        /// <param name="phoneNumber">The phone number to validate</param>
        /// <returns>An error message if invalid</returns>
        public static string Validate(string firstName, string lastName, string phoneNumber)
        {
            string errorMessage = "";

            if (String.IsNullOrEmpty(firstName))
            {
                errorMessage = "First name cannot be blank." + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(lastName))
            {
                errorMessage += "Last name cannot be blank." + Environment.NewLine;
            }
            if (phoneNumber.Length != 10 || !long.TryParse(phoneNumber, out long result))
            {
                errorMessage += "Phone number must have a length of 10 and be numeric.";
            }

            return errorMessage;
        }

        /// <summary>
        /// Gets a list of all the employees in the database
        /// </summary>
        /// <returns>A list of all the employees in the database</returns>
        public static BindingList<DBEmployee> GetEmployees()
        {
            BindingList<DBEmployee> employees = new BindingList<DBEmployee>();
            string query = "SELECT * FROM employees";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    DBEmployee temp = new DBEmployee((int)reader["employeeID"], (int)reader["positionID"], 
                        (string)reader["firstName"], (string)reader["lastName"], (string)reader["phoneNumber"]);
                    employees.Add(temp);
                }
                
            }
            return employees;
        }

        /// <summary>
        /// Checks if the characters and their positions in a phone number match another phone number.
        /// Blank characters are ignored.
        /// </summary>
        /// <param name="phoneNumber1">The first phone number</param>
        /// <param name="phoneNumber2">The second phone number</param>
        /// <returns></returns>
        public static bool IsPhoneNumberMatching(string phoneNumber1, string phoneNumber2)
        {
            return DBCollector.IsPhoneNumberMatching(phoneNumber1, phoneNumber2);
        }

        /// <summary>
        /// Gets the descriptive name of the position of this employee
        /// </summary>
        /// <returns>The descriptive name of the position of this employee</returns>
        private string GetEmployeePositionName()
        {
            string positionName = "";
            string query = "SELECT positionName FROM employeePositions WHERE positionID = '" + this.PositionID + "'";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    positionName = (string)reader[0];
                }

            }
            return positionName;
        }

        /// <summary>
        /// Gets an employee from the database with the matching id, returning an empty employee otherwise
        /// </summary>
        /// <param name="id">The id of the employee to pull from the database</param>
        /// <returns>An employee from the database with the matching id, returning an empty employee otherwise</returns>
        public static DBEmployee GetEmployee(int id)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("GetEmployeeById", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                var reader = command.ExecuteReader();
                DBEmployee tempEmployee;
                if(reader.Read())
                {
                    tempEmployee = new DBEmployee((int)reader["employeeID"], (int)reader["positionID"],
                    (string)reader["firstName"], (string)reader["lastName"], (string)reader["phoneNumber"]);
                }
                else
                {
                    tempEmployee = new DBEmployee(id, 0, "", "", "");
                }

                return tempEmployee;
            }
        }

        /// <summary>
        /// Attempts to update and employee, and if it does not exist inserts it instead
        /// </summary>
        /// <param name="employeeID">A unique identifier for employees</param>
        /// <param name="positionID">A unique identifiers for an employee position</param>
        /// <param name="firstName">The first name of the employee</param>
        /// <param name="lastName">The last name of the employee</param>
        /// <param name="phoneNumber">The phone number of the employee</param>
        /// <returns>Returns true if an employee was either updated or inserted</returns>
        public static bool SaveEmployee(int employeeID, int positionID, string firstName, string lastName, string phoneNumber)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("SaveEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@employeeID", SqlDbType.Int).Value = employeeID;
                    command.Parameters.Add("@positionID", SqlDbType.Int).Value = positionID;
                    command.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName;
                    command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;
                    command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;
                }

            }
        }
        /*public bool Save()
        {
            return DBEmployee.SaveEmployee(this.EmployeeID, this.PositionID, this.FirstName, this.LastName, this.PhoneNumber);
        }*/

        /// <summary>
        /// Deletes an employee from the database based on it's employeeID
        /// </summary>
        /// <param name="employeeID">A unique identifier for an employee</param>
        /// <returns>If an employee was deleted</returns>
        public static bool DeleteEmployee(int employeeID)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("DeleteEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@employeeID", SqlDbType.Int).Value = employeeID;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;
                }

            }
        }

        /// <summary>
        /// Deletes an employee from the database based on the id of this employee
        /// </summary>
        /// <returns>If an employee was deleted</returns>
        public bool Delete()
        {
            return DBEmployee.DeleteEmployee(this.EmployeeID);
        }

        /// <summary>
        /// Inserts a new employee into the database with the passed arguments, returning true if successful
        /// </summary>
        /// <param name="positionID">The unique identification number of the position of the employee</param>
        /// <param name="firstName">The first name of the employee</param>
        /// <param name="lastName">The last name of the employee</param>
        /// <param name="phoneNumber">The phone number of the employee</param>
        /// <returns>If the employee was inserted successfully</returns>
        public static bool InsertEmployee(int positionID, string firstName, string lastName, string phoneNumber)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("InsertEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@positionID", SqlDbType.Int).Value = positionID;
                    command.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName;
                    command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;
                    command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;
                }

            }
        }

        /// <summary>
        /// Updates an employee matching the passed employeeID in the database with the passed arguments
        /// </summary>
        /// <param name="employeeID">The id of the employee to update</param>
        /// <param name="positionID">The unique identification number of the position of the employee to update</param>
        /// <param name="firstName">The first name of the employee to update</param>
        /// <param name="lastName">The last name of the employee to update</param>
        /// <param name="phoneNumber">The phone number of the employee to update</param>
        /// <returns>If the employee was updated successfully</returns>
        public static bool UpdateEmployee(int employeeID, int positionID, string firstName, string lastName, string phoneNumber)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("UpdateEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@employeeID", SqlDbType.Int).Value = employeeID;
                    command.Parameters.Add("@positionID", SqlDbType.Int).Value = positionID;
                    command.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName;
                    command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;
                    command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;
                }

            }
        }
    }
}
