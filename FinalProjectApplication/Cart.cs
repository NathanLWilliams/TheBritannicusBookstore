using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectApplication
{
    /// <summary>
    /// Represents the shopping cart of the collector, used to store an invoice, transactions, and finalize the checkout process
    /// </summary>
    public static class Cart
    {
        /// <summary>
        /// The database invoice object containing invoice information and transactions
        /// </summary>
        public static DBInvoice Invoice = new DBInvoice();

        /// <summary>
        /// Finalizes the purchase process by committing the invoice and transactions to the database
        /// </summary>
        public static void FinalizePurchase()
        {

        }

    }
}
