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
    /// Represents a collector in the database and contains related CRUD operations
    /// </summary>
    public class DBCollector
    {
        /// <summary>
        /// The unique identification number for the collector
        /// </summary>
        public int CollectorID
        {
            get;
            set;
        }

        /// <summary>
        /// The descriptive name for the type of collector
        /// </summary>
        public string CollectorType
        {
            get;
            set;
        }

        /// <summary>
        /// The unique identification number for the type of collector
        /// </summary>
        public int CollectorTypeID
        {
            get;
            set;
        }

        /// <summary>
        /// The first name of the collector
        /// </summary>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// The last name of the collector
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// The full name of the collector
        /// </summary>
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        /// <summary>
        /// The phone number of the collector
        /// </summary>
        public string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Used as the display value for comboboxes which contain collectors
        /// </summary>
        public string ComboBoxDisplay
        {
            get
            {
                return this.FullName + " (" + this.CollectorID + ")";
            }
        }

        /// <summary>
        /// Instantiates a new collector with the passed arguments
        /// </summary>
        /// <param name="collectorID">The unique identification number of the collector</param>
        /// <param name="typeID">The unique identification number for the type of the collector</param>
        /// <param name="firstName">The first name of the collector</param>
        /// <param name="lastName">The last name of the collector</param>
        /// <param name="phoneNum">The phone number of the collector</param>
        public DBCollector(int collectorID, int typeID, string firstName, string lastName, string phoneNum)
        {
            this.CollectorID = collectorID;
            this.CollectorTypeID = typeID;
            this.CollectorType = GetCollectorTypeName();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNum;
        }

        /// <summary>
        /// Validates a collector with the passed arguments and returns an error message if invalid
        /// </summary>
        /// <param name="firstName">The first name to validate</param>
        /// <param name="lastName">The last name to validate</param>
        /// <param name="phoneNumber">The phone number to validate</param>
        /// <returns></returns>
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
                errorMessage += "Phone number must have a length of 10 and be numeric." + Environment.NewLine;
            }

            return errorMessage;
        }

        /// <summary>
        /// Gets the descriptive name for the type of this collector
        /// </summary>
        /// <returns>The descriptive name for the type of this collector</returns>
        public string GetCollectorTypeName()
        {
            string typeName = "";
            string query = "SELECT customerTypeName FROM customerTypes WHERE customerTypeID = '" + this.CollectorTypeID + "'";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    typeName = (string)reader[0];
                }

            }
            return typeName;
        }

        /// <summary>
        /// Gets a list of all the collectors in the database
        /// </summary>
        /// <returns>A list of all the collectors in the database</returns>
        public static BindingList<DBCollector> GetCollectors()
        {
            BindingList<DBCollector> collectors = new BindingList<DBCollector>();
            string query = "SELECT * FROM customers";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    DBCollector temp = new DBCollector((int)reader["customerID"], (int)reader["customerTypeID"], 
                        (string)reader["firstName"], (string)reader["lastName"], (string)reader["phoneNumber"]);
                    collectors.Add(temp);
                }
                
            }
            return collectors;
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
            bool isValid = true;
            for (var i = 0; i < phoneNumber2.Length; i++)
            {
                if (Char.IsDigit(phoneNumber2[i]) && !phoneNumber1.ToLower()[i].Equals(phoneNumber2.ToLower()[i]))
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Gets a collector from the database with the passed id
        /// </summary>
        /// <param name="id">The id of the collector to pull from the database</param>
        /// <returns>A collector from the database with the passed id</returns>
        public static DBCollector GetCollectorById(int id)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("GetCollectorById", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                var reader = command.ExecuteReader();
                DBCollector tempCollector;
                if(reader.Read())
                {
                    tempCollector = new DBCollector((int)reader["customerID"], (int)reader["customerTypeID"],
                        (string)reader["firstName"], (string)reader["lastName"], (string)reader["phoneNumber"]);
                }
                else
                {
                    tempCollector = new DBCollector(id, 0, "", "", "");
                }

                return tempCollector;
            }
        }
        /*public List<int> GetInterestsOfType(int itemTypeID) {
            return DBCollector.getInterestsOfType(this.CollectorID, itemTypeID);
        }*/

        /// <summary>
        /// Gets all the interests from the database which are associated with the passed collectorID and are for the passed item type
        /// </summary>
        /// <param name="collectorID">The unique identification number for a collector</param>
        /// <param name="itemTypeID">The unique identification number for a type of item</param>
        /// <returns></returns>
        public static List<int> GetInterestsOfType(int collectorID, int itemTypeID)
        {
            List<int> tagIds = new List<int>();

            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("GetInterestsOfType", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add("@customerID", SqlDbType.Int).Value = collectorID;
                command.Parameters.Add("@itemTypeID", SqlDbType.Int).Value = itemTypeID;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tagIds.Add((int)reader["tagID"]);
                }

                return tagIds;
            }
        }

        /// <summary>
        /// Inserts a list of interests associated with the passed collectorID for the passed item type
        /// </summary>
        /// <param name="collectorID">The unique identification number of the collector</param>
        /// <param name="itemTypeID">The unique identification number for the type of item</param>
        /// <param name="tagIds">The tag/interests ids to insert</param>
        /// <returns>If the interests were inserted successfully</returns>
        public static bool InsertInterests(int collectorID, int itemTypeID, List<int> tagIds)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("InsertInterest", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                int tagsInserted = 0;

                command.Parameters.Add("@collectorID", SqlDbType.Int).Value = collectorID;
                command.Parameters.Add("@tagID", SqlDbType.Int);
                command.Parameters.Add("@itemTypeID", SqlDbType.Int).Value = itemTypeID;

                //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                for(var i = 0; i < tagIds.Count; i++)
                {
                    command.Parameters["@tagID"].Value = tagIds[i];
                    command.ExecuteNonQuery();
                    if(returnParameter.Value != null)
                    {
                        tagsInserted += (int)returnParameter.Value;
                    }
                }

                return tagsInserted == tagIds.Count;
            }
        }

        /// <summary>
        /// Deletes the interests associated with the passed collectorID and item type
        /// </summary>
        /// <param name="collectorID">The unique identification number of the collector</param>
        /// <param name="itemTypeID">The unique identification number of a type of item</param>
        /// <returns></returns>
        public static bool DeleteInterests(int collectorID, int itemTypeID)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("DeleteInterests", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();

                command.Parameters.Add("@collectorID", SqlDbType.Int).Value = collectorID;
                command.Parameters.Add("@itemTypeID", SqlDbType.Int).Value = itemTypeID;

                //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                return (int)returnParameter.Value > 0;
            }
        }
        /*public bool UpdateInterests(int itemTypeID, List<int> tagIds)
        {
            return DBCollector.UpdateInterests(this.CollectorID, itemTypeID, tagIds);
        }*/

        /// <summary>
        /// Combines the DeleteInterests and InsertInterests method to update the interests associated with the passed collectorID
        /// for the passed item type
        /// </summary>
        /// <param name="collectorID">The id of the collector to update interests for</param>
        /// <param name="itemTypeID">The id of the type of item the interests are for</param>
        /// <param name="tagIds">The tag ids of the interests</param>
        /// <returns></returns>
        public static bool UpdateInterests(int collectorID, int itemTypeID, List<int> tagIds)
        {
            bool result = false;
            DBCollector.DeleteInterests(collectorID, itemTypeID);
            if (DBCollector.InsertInterests(collectorID, itemTypeID, tagIds))
            {
                result = true;
            }

            return result;
        }
        

        /// <summary>
        /// Deletes a collector from the database based on it's collectorID
        /// </summary>
        /// <param name="collectorID">A unique identifier for a collector</param>
        /// <returns>If a collector was deleted</returns>
        public static bool DeleteCollector(int collectorID)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("DeleteCollector", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@collectorID", SqlDbType.Int).Value = collectorID;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;
                }

            }
        }

        /// <summary>
        /// Deletes this collector from the database
        /// </summary>
        /// <returns>If a collector was deleted</returns>
        public bool Delete()
        {
            return DBCollector.DeleteCollector(this.CollectorID);
        }

        /// <summary>
        /// Inserts a collector into the database with the passed arguments and returns the inserted id if successful, otherwise null
        /// </summary>
        /// <param name="typeID">The unique identification number for the type of collector</param>
        /// <param name="firstName">The first name of the collector</param>
        /// <param name="lastName">The last name of the collector</param>
        /// <param name="phoneNumber">The phone number of the collector</param>
        /// <returns>The id of the inserted collector if successful, otherwise null</returns>
        public static object InsertCollector(int typeID, string firstName, string lastName, string phoneNumber)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("InsertCollector", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@customerTypeID", SqlDbType.Int).Value = typeID;
                    command.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName;
                    command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;
                    command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return returnParameter.Value;

                }
            }
        }

        /// <summary>
        /// Updates a collector in the database with the passed collectorID using the passed arguments
        /// </summary>
        /// <param name="collectorID">The id of the collector to update</param>
        /// <param name="typeID">The collector type id to update</param>
        /// <param name="firstName">The first name to update</param>
        /// <param name="lastName">The last name to update</param>
        /// <param name="phoneNumber">The phone number to update</param>
        /// <returns></returns>
        public static bool UpdateCollector(int collectorID, int typeID, string firstName, string lastName, string phoneNumber)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("UpdateCollector", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@customerID", SqlDbType.Int).Value = collectorID;
                    command.Parameters.Add("@customerTypeID", SqlDbType.Int).Value = typeID;
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
