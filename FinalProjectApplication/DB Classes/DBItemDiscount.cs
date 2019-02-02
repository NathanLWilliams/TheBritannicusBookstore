using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectApplication
{
    /// <summary>
    /// Used to represent an item discount in the database and contains related CRUD operations
    /// </summary>
    public class DBItemDiscount
    {
        /// <summary>
        /// The unique identification number for an item discount
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// The discount price
        /// </summary>
        public decimal Amount
        {
            get;
            set;
        }

        /// <summary>
        /// The date the discount starts
        /// </summary>
        public DateTime StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// The date the discount ends
        /// </summary>
        public DateTime EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Used to instantiate a new item discount using the passed arguments
        /// </summary>
        /// <param name="id">The unique identifier for the item discount</param>
        /// <param name="amount">The price of the item discount</param>
        /// <param name="startDate">The date the discount starts</param>
        /// <param name="endDate">The date the discount ends</param>
        public DBItemDiscount(int id, decimal amount, DateTime startDate, DateTime endDate)
        {
            this.ID = id;
            this.Amount = amount;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        /// <summary>
        /// Validates and item discount with the passed arguments and returns an error message if invalid
        /// </summary>
        /// <param name="price">The price to validate</param>
        /// <param name="startDate">The start date to validate</param>
        /// <param name="endDate">The end date to validate</param>
        /// <returns></returns>
        public static string Validate(decimal price, DateTime startDate, DateTime endDate)
        {
            string errorMessage = "";

            if (price == 0)
            {
                errorMessage += "Discount price must be greater than zero." + Environment.NewLine;
            }
            if(endDate < DateTime.Now)
            {
                errorMessage += "Discount end date cannot be earlier than the current date." + Environment.NewLine;
            }
            if(startDate > endDate)
            {
                errorMessage += "Discount end date cannot be before the start date." + Environment.NewLine;
            }

            return errorMessage;
        }

    }
}
