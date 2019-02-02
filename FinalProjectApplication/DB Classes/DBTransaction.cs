using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectApplication
{
    public class DBTransaction
    {
        /// <summary>
        /// The ID of the invoice this transaction is a part of
        /// </summary>
        private int invoiceID;

        /// <summary>
        /// The ID of the item sold in this transaction
        /// </summary>
        public int ItemID
        {
            get;
            set;
        }

        /// <summary>
        /// The title or location of the item sold in this transaction
        /// </summary>
        public string Desc
        {
            get;
            set;
        }

        /// <summary>
        /// The type of item sold in this transaction
        /// </summary>
        public string ItemType
        {
            get;
            set;
        }

        /// <summary>
        /// The edition of the item sold in this transaction
        /// </summary>
        public int Edition
        {
            get;
            set;
        }

        /// <summary>
        /// The unique identifier for the condition
        /// </summary>
        private int conditionID;

        /// <summary>
        /// The descriptive condition name of the item sold in this transaction
        /// </summary>
        public string Condition
        {
            get;
            set;
        }

        /// <summary>
        /// The price of the item sold in this transaction
        /// </summary>
        public decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// The number of items sold in this transaction
        /// </summary>
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// The total price of this transaction (qty * price)
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                return this.Price * this.Quantity;
            }
        }

        //TODO: Consider if there is a better location for this
        /// <summary>
        /// The stock left of the item being sold
        /// </summary>
        private int itemStock;

        /// <summary>
        /// Used to instantiate a new transaction
        /// </summary>
        /// <param name="invoiceID">The invoice the transaction belongs to</param>
        /// <param name="item">The item being sold</param>
        /// <param name="quantity">How many of the item is being sold</param>
        public DBTransaction(int invoiceID, DBItem item, int quantity)
        {
            this.invoiceID = invoiceID;
            this.ItemID = item.GetItemID();
            this.Desc = item.GetDescription();
            this.ItemType = item.GetItemType();
            this.Edition = item.GetEdition();
            this.Condition = item.GetConditionType();
            this.conditionID = item.GetConditionID();
            this.Price = item.GetPrice();
            this.Quantity = quantity;
            this.itemStock = item.GetQuantity();
        }

        /// <summary>
        /// Gets the stock left of the item being sold
        /// </summary>
        /// <returns>The stock left of the item being sold</returns>
        public int getItemStock()
        {
            return this.itemStock;
        }

        /// <summary>
        /// Sets the stock left of the item being sold
        /// </summary>
        /// <param name="stock">The stock left of the item being sold</param>
        public void SetItemStock(int stock)
        {
            this.itemStock = stock;
        }

        /// <summary>
        /// Get the condition id of the item in the transaction
        /// </summary>
        /// <returns>The condition id of the item in the transaction</returns>
        public int GetConditionID()
        {
            return this.conditionID;
        }

        /// <summary>
        /// Inserts a transaction into the database as part of the passed invoice
        /// and returns true if the insertion was successful
        /// </summary>
        /// <param name="invoiceID">The id of the invoice it belongs to</param>
        /// <param name="itemID">The id of the item being sold</param>
        /// <param name="quantity">The number of the item being sold</param>
        /// <returns>If the insertion was successful</returns>
        public static bool InsertTransaction(int invoiceID, int itemID, int quantity)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {

                conn.Open();

                using (var command = new SqlCommand("InsertTransaction", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@invoiceID", SqlDbType.Int).Value = invoiceID;
                    command.Parameters.Add("@itemID", SqlDbType.Int).Value = itemID;
                    command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;

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
