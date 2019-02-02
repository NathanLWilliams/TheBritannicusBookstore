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
    /// Represents an item in the database and has related CRUD operations
    /// </summary>
    public class DBItem
    {
        /// <summary>
        /// A unique identification number for an item
        /// </summary>
        protected int itemID;
        
        /// <summary>
        /// A description for an item
        /// </summary>
        protected string description;

        /// <summary>
        /// The price of an item
        /// </summary>
        protected decimal price;

        /// <summary>
        /// The discount of an item if it has one
        /// </summary>
        protected DBItemDiscount discount;

        /// <summary>
        /// The item edition
        /// </summary>
        protected byte edition;

        /// <summary>
        /// The number of an item in stock
        /// </summary>
        protected int quantity;

        /// <summary>
        /// A unique identifier for an item condition
        /// </summary>
        protected int conditionID;

        /// <summary>
        /// A descriptive name for a condition
        /// </summary>
        protected string conditionType;

        /// <summary>
        /// A descriptive name for an item type
        /// </summary>
        protected string itemType;

        /// <summary>
        /// Whether the discount price or the regular price should be shown
        /// </summary>
        public bool ShowDiscount
        {
            get;
            set;
        }

        /// <summary>
        /// A list of tags describing this item
        /// </summary>
        public List<int> Tags
        {
            get;
            set;
        }

        /// <summary>
        /// Used to instantiate a new item with the passed arguments
        /// </summary>
        /// <param name="itemID">The unique identifier for this item</param>
        /// <param name="itemType">The type of item</param>
        /// <param name="description">The item description</param>
        /// <param name="price">The price of the item</param>
        /// <param name="edition">The item edition</param>
        /// <param name="quantity">The number of the item in stock</param>
        /// <param name="conditionID">The unique identifier for the item condition</param>
        public DBItem(int itemID, string itemType, string description, decimal price, byte edition, int quantity, int conditionID)
        {
            this.itemID = itemID;
            this.itemType = itemType;
            this.description = description;
            this.price = price;
            this.discount = this.GetDBDiscount();
            this.edition = edition;
            this.quantity = quantity;
            this.conditionID = conditionID;
            this.conditionType = this.GetDBConditionType();
            this.ShowDiscount = true;
            this.Tags = this.GetTags();
        }

        /// <summary>
        /// Validates the price and description of an item and returns an error message if invalid
        /// </summary>
        /// <param name="price">The price to validate</param>
        /// <param name="description">The description to validate</param>
        /// <returns>An error message if invalid</returns>
        public static string Validate(decimal price, string description)
        {
            string errorMessage = "";

            if(price == 0)
            {
                errorMessage += "Price must be greater than zero." + Environment.NewLine;
            }
            if(String.IsNullOrEmpty(description))
            {
                errorMessage += "Description (title or location) cannot be empty." + Environment.NewLine;
            }

            return errorMessage;
        }

        /// <summary>
        /// Gets the price of the item
        /// </summary>
        /// <returns>The price of the item</returns>
        public decimal GetPrice()
        {
            if (this.HasDiscount())
            {
                return this.discount.Amount;

            }
            else
            {
                return this.price;
            }
        }

        /// <summary>
        /// Gets the descriptive name for the item type
        /// </summary>
        /// <returns>The descriptive name for the item type</returns>
        public string GetItemType()
        {
            return this.itemType;
        }

        /// <summary>
        /// Gets the item description
        /// </summary>
        /// <returns>The item description</returns>
        public string GetDescription()
        {
            return this.description;
        }

        /// <summary>
        /// Gets the regular item price
        /// </summary>
        /// <returns>The regular item price</returns>
        public decimal GetRegularPrice()
        {
            return this.price;
        }

        /// <summary>
        /// Gets the discount of the item
        /// </summary>
        /// <returns>The item discount object</returns>
        public DBItemDiscount GetDiscount()
        {
            return this.discount;
        }

        /// <summary>
        /// Checks if the item has a discount
        /// </summary>
        /// <returns>If the item has a discount</returns>
        public bool HasDiscount()
        {
            return this.discount.Amount != -1 && ShowDiscount;
        }

        /// <summary>
        /// Gets the descriptive name for the item condition type
        /// </summary>
        /// <returns>The descriptive name of the item condition type</returns>
        public string GetConditionType()
        {
            return this.conditionType;
        }

        //TODO: Consider moving this elsewhere?
        /// <summary>
        /// Gets the total price of the item using the passed quantity
        /// </summary>
        /// <param name="quantity">The quantity to calculate for</param>
        /// <returns>The total price of the items</returns>
        public decimal GetTotalPrice(int quantity)
        {
            return this.GetPrice() * quantity;
        }

        /// <summary>
        /// Gets the number of this item in stock
        /// </summary>
        /// <returns>The number of this item in stock</returns>
        public int GetQuantity()
        {
            return this.quantity;
        }

        /// <summary>
        /// Sets the quantity of this item in stock
        /// </summary>
        /// <param name="qty">The quantity to set it to</param>
        public void SetQuantity(int qty)
        {
            this.quantity = qty;
        }

        /// <summary>
        /// Gets the unique identification number of this item
        /// </summary>
        /// <returns>The unique identification number of this item</returns>
        public int GetItemID()
        {
            return this.itemID;
        }

        /// <summary>
        /// Gets the unique identification number of this item's condition
        /// </summary>
        /// <returns>The unique identification number of this item's condition</returns>
        public int GetConditionID()
        {
            return this.conditionID;
        }

        /// <summary>
        /// Gets the item edition
        /// </summary>
        /// <returns>The item edition</returns>
        public byte GetEdition()
        {
            return this.edition;
        }

        /// <summary>
        /// Updates a discount in the database if it exists, otherwise inserts a new discount
        /// </summary>
        /// <param name="discountID">The unique identification number of the discount to update</param>
        /// <param name="discountAmount">The discount price</param>
        /// <param name="startDate">The date the discount period starts</param>
        /// <param name="endDate">The date the discount period ends</param>
        /// <returns>If the saving of the discount was successful</returns>
        public static bool SaveDiscount(int discountID, decimal discountAmount, DateTime startDate, DateTime endDate)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("SaveDiscount", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@discountID", SqlDbType.Int).Value = discountID;
                    command.Parameters.Add("@discountAmount", SqlDbType.Decimal).Value = discountAmount;
                    command.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
                    command.Parameters.Add("@endDate", SqlDbType.Date).Value = endDate;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;

                }
            }
        }
        /*public static bool UpdateDiscount(int discountID, decimal discountAmount, DateTime startDate, DateTime endDate)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("UpdateDiscount", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@discountID", SqlDbType.Int).Value = discountID;
                    command.Parameters.Add("@discountAmount", SqlDbType.Decimal).Value = discountAmount;
                    command.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
                    command.Parameters.Add("@endDate", SqlDbType.Date).Value = endDate;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;

                }
            }
        }
        public static bool InsertDiscount(int discountID, decimal discountAmount, DateTime startDate, DateTime endDate)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("InsertDiscount", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@discountID", SqlDbType.Int).Value = discountID;
                    command.Parameters.Add("@discountAmount", SqlDbType.Decimal).Value = discountAmount;
                    command.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
                    command.Parameters.Add("@endDate", SqlDbType.Date).Value = endDate;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;

                }
            }
        }*/

        /// <summary>
        /// Removes a discount from the database with the specified discount id (should match item id)
        /// </summary>
        /// <param name="discountID">The id of the discount to remove</param>
        /// <returns>If the removal was successful</returns>
        public static bool DeleteDiscount(int discountID)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("DeleteDiscount", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@discountID", SqlDbType.Int).Value = discountID;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (int)returnParameter.Value > 0;

                }
            }
        }

        /// <summary>
        /// Gets a discount associated with this item in the database
        /// </summary>
        /// <returns>The discount associated with this item</returns>
        public DBItemDiscount GetDBDiscount()
        {
            DBItemDiscount discount;
            string query = "SELECT discountAmount, startDate, endDate FROM itemDiscounts WHERE discountID = '" + this.GetItemID() + "' AND GETDATE() < endDate";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    discount = new DBItemDiscount(this.GetItemID(), (decimal)reader["discountAmount"], (DateTime)reader["startDate"], (DateTime)reader["endDate"]);
                }
                else
                {
                    discount = new DBItemDiscount(this.GetItemID(), -1, DateTime.Now, DateTime.Now);
                }

            }
            return discount;
        }

        /// <summary>
        /// Gets the descriptive name for this item's condition
        /// </summary>
        /// <returns>The descriptive name for this item's condition</returns>
        public string GetDBConditionType()
        {
            string conditionType = "";
            string query = "SELECT conditionType FROM conditions WHERE conditionID = '" + this.conditionID + "'";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    conditionType = (string)reader[0];
                }

            }
            return conditionType;
        }

        /// <summary>
        /// Gets the unique identification number for an item type associated with the passed item id
        /// </summary>
        /// <param name="id">The id of the item the item type is associated with</param>
        /// <returns>The item type id</returns>
        public static int GetDBItemTypeOfId(int id)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("GetItemTypeOfId", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                int itemTypeID = 0;
                var result = command.ExecuteScalar();
                if(result is int)
                {
                    itemTypeID = (int)result;
                }
                return itemTypeID;
            }
        }

        /// <summary>
        /// Gets a list of tag ids associated with the passed item id
        /// </summary>
        /// <param name="itemID">The item id to get tags for</param>
        /// <returns>A list of the tag ids associated with the passed item id</returns>
        public static List<int> GetTagsOfItemID(int itemID)
        {
            List<int> tagIds = new List<int>();

            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("GetTagsOfItemID", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add("@itemID", SqlDbType.Int).Value = itemID;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tagIds.Add((int)reader["tagID"]);
                }

                return tagIds;
            }
        }

        /// <summary>
        /// Gets a list of tag ids associated with this item
        /// </summary>
        /// <returns>A list of tag ids associated with this item</returns>
        public List<int> GetTags()
        {
            return DBItem.GetTagsOfItemID(this.itemID);
        }

        /// <summary>
        /// Deactivates the item with the passed item id, excluding it from any future select queries
        /// </summary>
        /// <param name="itemID">The id of the item to deactivate</param>
        /// <returns>If the deactivation was successful</returns>
        public static bool DeactivateItem(int itemID)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("DeactivateItem", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@itemID", SqlDbType.VarChar).Value = itemID;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return returnParameter.Value is int && (int)returnParameter.Value > 0;

                }
            }
        }

        /// <summary>
        /// Deactivates this item, excluding it from future select queries
        /// </summary>
        /// <returns>If it was deactivated successfully</returns>
        public bool DeactivateItem()
        {
            return DBItem.DeactivateItem(this.itemID);
        }

        /// <summary>
        /// Inserts a list of tag ids into the database associated with the passed item id
        /// </summary>
        /// <param name="itemID">The id of the item to add tags to</param>
        /// <param name="tagIds">The ids of the tags to associate with the item id</param>
        /// <returns>If all tags were inserted successfully</returns>
        public static bool InsertItemTags(int itemID, List<int> tagIds)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("InsertItemTag", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                int tagsInserted = 0;

                command.Parameters.Add("@itemID", SqlDbType.Int).Value = itemID;
                command.Parameters.Add("@tagID", SqlDbType.Int);

                //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                for (var i = 0; i < tagIds.Count; i++)
                {
                    command.Parameters["@tagID"].Value = tagIds[i];
                    command.ExecuteNonQuery();
                    if (returnParameter.Value != null)
                    {
                        tagsInserted += (int)returnParameter.Value;
                    }
                }

                return tagsInserted == tagIds.Count;
            }
        }

        /// <summary>
        /// Deletes all tags associated with the passed item id
        /// </summary>
        /// <param name="itemID">The item id to delete the associated tags for</param>
        /// <returns>If the deletion was successful</returns>
        public static bool DeleteItemTags(int itemID)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            using (var command = new SqlCommand("DeleteItemTags", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();

                command.Parameters.Add("@itemID", SqlDbType.Int).Value = itemID;

                //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                return (int)returnParameter.Value > 0;
            }
        }

        /// <summary>
        /// Updates the tag ids associated with the passed item id in the database
        /// </summary>
        /// <param name="itemID">The item id to update the tags for</param>
        /// <param name="tagIds">The tag ids to associate with the item id</param>
        /// <returns>If the tags were updated successfully</returns>
        public static bool UpdateItemTags(int itemID, List<int> tagIds)
        {
            bool result = false;
            DBItem.DeleteItemTags(itemID);
            if (DBItem.InsertItemTags(itemID, tagIds))
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Updates the tag ids associated with this item in the database
        /// </summary>
        /// <param name="tagIds">The tag ids to associate with this item</param>
        /// <returns>If the tags were updated successfully</returns>
        public bool UpdateItemTags(List<int> tagIds)
        {
            return DBItem.UpdateItemTags(this.GetItemID(), tagIds);
        }

    }
}
