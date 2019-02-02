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
    /// Represents a tag in the database and contains all CRUD operations for it
    /// </summary>
    public class DBTag
    {
        /// <summary>
        /// A unique identification number for a tag
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The description of the tag
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Used to instantiate a tag using an id and description
        /// </summary>
        /// <param name="id">The passed id</param>
        /// <param name="desc">The passed description</param>
        public DBTag(int id, string desc)
        {
            this.ID = id;
            this.Description = desc;
        }

        /// <summary>
        /// Validates the passed tag description and returns and error message
        /// if invalid
        /// </summary>
        /// <param name="desc">The tag description</param>
        /// <returns>An error message if invalid</returns>
        public static string Validate(string desc)
        {
            string errorMessage = "";

            if (String.IsNullOrEmpty(desc))
            {
                errorMessage = "Tag name cannot be blank";
            }

            return errorMessage;
        }

        /// <summary>
        /// Gets a list of tags used data pulled from the database
        /// </summary>
        /// <returns>A list of tags</returns>
        public static BindingList<DBTag> GetTags()
        {
            BindingList<DBTag> tags = new BindingList<DBTag>();
            string query = "SELECT * FROM tags WHERE isActive = 1 ORDER BY tagDescription ASC";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DBTag temp = new DBTag((int)reader["tagID"], (string)reader["tagDescription"]);
                    tags.Add(temp);
                }

            }
            return tags;
        }

        /// <summary>
        /// Inserts a new tag with the passed description into the database
        /// and returns the inserted record's id
        /// </summary>
        /// <param name="desc">The tag description</param>
        /// <returns>The inserted record's id, or null if it failed</returns>
        public static object InsertTag(string desc)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("InsertTag", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@tagDescription", SqlDbType.VarChar).Value = desc;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return returnParameter.Value;
                }

            }
        }

        /// <summary>
        /// Updates the description of a tag in the database with the passed tagID
        /// </summary>
        /// <param name="tagID">The tag id of the tag to update</param>
        /// <param name="desc">The tag description to update</param>
        /// <returns>If it was updated successfully</returns>
        public static bool UpdateTag(int tagID, string desc)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("UpdateTag", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@tagID", SqlDbType.Int).Value = tagID;
                    command.Parameters.Add("@tagDescription", SqlDbType.VarChar).Value = desc;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;
                }

            }
        }

        /// <summary>
        /// Deactivates a tag in the database, making it disappear from all select queries
        /// </summary>
        /// <param name="tagID">The id of the tag to deactivate</param>
        /// <returns>If it was successfully deactivated</returns>
        public static bool DeactivateTag(int tagID)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("DeactivateTag", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@tagID", SqlDbType.Int).Value = tagID;

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
