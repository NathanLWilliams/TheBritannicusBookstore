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
    /// Used to represent an invoice from the database and contains related CRUD operations
    /// </summary>
    public class DBInvoice
    {
        /// <summary>
        /// The unique identification number of an invoice
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        //TODO: Think about doing this for other DB classes as well instead of foreign keys?
        /// <summary>
        /// The collector associated with this invoice
        /// </summary>
        public DBCollector Collector
        {
            get;
            set;
        }

        /// <summary>
        /// The date this invoice was created
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// What is displayed in comboboxes which are populated with invoices
        /// </summary>
        public string ComboBoxDisplay
        {
            get
            {
                return "Invoice " + ID + " (" + Collector.FullName + ")";
            }
        }

        /// <summary>
        /// Holds the transactions which are on the invoice
        /// </summary>
        public BindingList<DBTransaction> Transactions
        {
            get;
            set;
        }

        /// <summary>
        /// Used to instantiate a new invoice with the passed arguments
        /// </summary>
        /// <param name="id">The unique identification number of an invoice</param>
        /// <param name="customerID">The unique identification number of the collector associated with this invoice</param>
        /// <param name="date">The date this invoice was created</param>
        public DBInvoice(int id, int customerID, DateTime date)
        {
            this.ID = id;
            this.Collector = DBCollector.GetCollectorById(customerID);
            this.Date = date;
            this.Transactions = new BindingList<DBTransaction>();
        }

        /// <summary>
        /// Used to instantiate a default invoice with no arguments
        /// </summary>
        public DBInvoice() : this(-1, 1, DateTime.MinValue)
        {
            
        }

        /// <summary>
        /// Gets a list of all the invoices in the database
        /// </summary>
        /// <returns>A list of all the invoices in the database</returns>
        public static BindingList<DBInvoice> GetInvoices()
        {
            BindingList<DBInvoice> invoices = new BindingList<DBInvoice>();
            string query = "SELECT * FROM invoice";
            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                var command = new SqlCommand(query, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DBInvoice tempInvoice = new DBInvoice((int)reader["invoiceID"], (int)reader["customerID"], (DateTime)reader["invoiceDate"]);
                    invoices.Add(tempInvoice);
                }

            }
            return invoices;
        }

        /// <summary>
        /// Validates this invoice to check if it is suitable for the checkout process
        /// and returns an error message if it is invalid
        /// </summary>
        /// <returns>An error message if invalid</returns>
        public string ValidateForCheckout()
        {
            string errorMessage = "";
            if(this.Collector.CollectorID == -1)
            {
                errorMessage += "A collector must be selected." + Environment.NewLine;
            }
            if(this.Transactions.Count == 0)
            {
                errorMessage += "You must have at least one item to purchase." + Environment.NewLine;
            }

            return errorMessage;
        }

        /// <summary>
        /// Inserts this invoice and all it's transaction into the database
        /// </summary>
        public int InsertInvoice()
        {
            int result = -1;

            using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
            {
                conn.Open();

                //Insert an invoice into the database
                using (var command = new SqlCommand("InsertInvoice", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                        
                    command.Parameters.Add("@customerID", SqlDbType.Int).Value = this.Collector.CollectorID;

                    //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                    var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    if(returnParameter.Value != null)
                    {
                        this.ID = (int)returnParameter.Value; //Set the invoice ID of this object
                        result = 1; //Invoice inserted successfully
                    }
                }

                //Check if the invoice was inserted successfully before inserting transactions
                if(result == 1)
                {
                    //Insert transactions into the database
                    using (var command = new SqlCommand("InsertTransaction", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        int transactionsInserted = 0;

                        command.Parameters.Add("@invoiceID", SqlDbType.Int).Value = this.ID;
                        command.Parameters.Add("@itemID", SqlDbType.Int);
                        command.Parameters.Add("@quantity", SqlDbType.Int);
                        command.Parameters.Add("@conditionID", SqlDbType.Int);
                        command.Parameters.Add("@totalPrice", SqlDbType.Decimal);

                        //This needs to be done because ExecuteNonQuery only returns -1 for stored procedures
                        var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        //Loop through each transaction in this invoice and insert them into the database
                        for (var i = 0; i < this.Transactions.Count; i++)
                        {
                            command.Parameters["@itemID"].Value = this.Transactions[i].ItemID;
                            command.Parameters["@quantity"].Value = this.Transactions[i].Quantity;
                            command.Parameters["@conditionID"].Value = this.Transactions[i].GetConditionID();
                            command.Parameters["@totalPrice"].Value = this.Transactions[i].TotalPrice;

                            command.ExecuteNonQuery();
                            if ((int)returnParameter.Value > 0)
                            {
                                transactionsInserted++;
                            }
                        }

                        if(transactionsInserted == this.Transactions.Count)
                        {
                            result = 2; //All transactions inserted successfully
                        }
                    }
                }

                conn.Close();
                    
            }

            return result;

        }

        /// <summary>
        /// Adds a transaction to the list of transactions in this invoice, but not to the database
        /// </summary>
        /// <param name="transaction">The transaction to add</param>
        public void AddUncommittedTransaction(DBTransaction transaction)
        {
            if (transaction.Quantity > 0)
            {
                bool isExisting = false;
                foreach (DBTransaction t in this.Transactions)
                {
                    if (t.ItemID == transaction.ItemID && t.Condition == transaction.Condition)
                    {
                        //
                        t.Quantity += transaction.Quantity;
                        t.SetItemStock(transaction.getItemStock() + t.Quantity - transaction.Quantity);
                        isExisting = true;
                    }
                }

                if (!isExisting)
                {
                    this.Transactions.Add(transaction);
                }
            }
        }

        /// <summary>
        /// Gets the quantity being sold of an item with the passed itemID
        /// </summary>
        /// <param name="itemID">The id of the item to get the quantity being sold of</param>
        /// <returns>The quantity of the item being sold</returns>
        public int GetQuantityBeingSold(int itemID)
        {
            int quantity = 0;
            foreach (DBTransaction t in this.Transactions)
            {
                if (t.ItemID == itemID)
                {
                    quantity = t.Quantity;
                }
            }
            return quantity;
        }
    }
}
