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
    /// Used to represent a genre in the database and contains related CRUD operations
    /// </summary>
    public class DBGenre
    {
        /// <summary>
        /// The unique identification number of the genre
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The descriptive name of the genre
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Used to instantiate a new genre with the specified id and descriptive name
        /// </summary>
        /// <param name="id">The unique identifier of the genre</param>
        /// <param name="name">The descriptive name of the genre</param>
        public DBGenre(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets a list of all the genres in the database
        /// </summary>
        /// <returns>A list of all the genres in the database</returns>
        public static BindingList<DBGenre> getGenres()
        {
            BindingList<DBGenre> genres = new BindingList<DBGenre>();
            string query = "SELECT * FROM genres";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DBGenre temp = new DBGenre((int)reader["genreID"], (string)reader["genreName"]);
                    genres.Add(temp);
                }

            }
            return genres;
        }
    }
}
