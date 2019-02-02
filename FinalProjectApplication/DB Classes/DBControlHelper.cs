using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    /// <summary>
    /// This is used to hold methods and properties related to the interaction between database layer classes and form controls
    /// </summary>
    public static class DBControlHelper
    {
        /// <summary>
        /// Populates a passed panel with the specified control containing info of the passed items
        /// </summary>
        /// <typeparam name="T1">The type of item</typeparam>
        /// <typeparam name="T2">The type of control, must have a text and tag property</typeparam>
        /// <param name="panel">The panel to populate</param>
        /// <param name="items">The items to represent as the control</param>
        /// <param name="displayMember">The name of the items member to display as control text</param>
        /// <param name="valueMember">The name of the items member to set the tag property of the control</param>
        /// <param name="values">Passes a list of integers that if matching a value of a control, will check it</param>
        public static void PopulateWithControls<T1, T2>(Panel panel, BindingList<T1> items, string displayMember, string valueMember, List<int> values) where T2 : Control, new()
        {
            panel.Controls.Clear();
            foreach(T1 item in items)
            {
                T2 controlToAdd = new T2();
                controlToAdd.Text = item.GetType().GetProperty(displayMember).GetValue(item).ToString();
                controlToAdd.Tag = item.GetType().GetProperty(valueMember).GetValue(item).ToString();
                controlToAdd.AutoSize = true;

                for (var i = 0; i < values.Count; i++)
                {
                    if(Convert.ToInt32(controlToAdd.Tag) == values[i])
                    {
                        if(controlToAdd is CheckBox)
                        {
                            (controlToAdd as CheckBox).Checked = true;
                        }
                        else if(controlToAdd is RadioButton)
                        {
                            (controlToAdd as RadioButton).Checked = true;
                        }
                    }
                }

                panel.Controls.Add(controlToAdd);
            }
        }

        /// <summary>
        /// Populates a passed panel with the specified control containing info of the passed items
        /// </summary>
        /// <typeparam name="T1">The type of item</typeparam>
        /// <typeparam name="T2">The type of control, must have a text and tag property</typeparam>
        /// <param name="panel">The panel to populate</param>
        /// <param name="items">The items to represent as the control</param>
        /// <param name="displayMember">The name of the items member to display as control text</param>
        /// <param name="valueMember">The name of the items member to set the tag property of the control</param>
        public static void PopulateWithControls<T1, T2>(Panel panel, BindingList<T1> items, string displayMember, string valueMember) where T2 : Control, new()
        {
            PopulateWithControls<T1, T2>(panel, items, displayMember, valueMember, new List<int>());
        }

        /// <summary>
        /// Check checkboxes or radiobuttons on the passed panel which have a tag (Control.Tag) matching the passed values
        /// </summary>
        /// <param name="panel">The panel of controls</param>
        /// <param name="values">The list of tags of controls which should be checked</param>
        public static void CheckControlsWithValues(Panel panel, List<int> values)
        {
            //TODO: This could use some cleaning
            foreach(Control c in panel.Controls)
            {
                if(c is CheckBox)
                {
                    (c as CheckBox).Checked = false;
                }
                else if(c is RadioButton)
                {
                    (c as RadioButton).Checked = false;
                }
                for(var i = 0; i < values.Count; i++)
                {
                    if (Convert.ToInt32(c.Tag) == values[i])
                    {
                        if (c is CheckBox)
                        {
                            (c as CheckBox).Checked = true;
                        }
                        else if (c is RadioButton)
                        {
                            (c as RadioButton).Checked = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Filters through a list of collectors and returns a new list with collectors that have similar names and phone numbers
        /// to the passed values
        /// </summary>
        /// <param name="collectors">The collectors to filter through</param>
        /// <param name="name">The name to look for</param>
        /// <param name="phoneNumber">The phone number to look for</param>
        /// <returns></returns>
        public static BindingList<DBCollector> GetFilteredCollectors(BindingList<DBCollector> collectors, string name, string phoneNumber)
        {
            BindingList<DBCollector> filteredCollectors = new BindingList<DBCollector>();
            foreach (DBCollector c in collectors)
            {
                if (c.FullName.ToLower().Contains(name.Trim().ToLower()) && DBEmployee.IsPhoneNumberMatching(c.PhoneNumber, phoneNumber.ToLower()))
                {
                    filteredCollectors.Add(c);
                }
            }

            return filteredCollectors;
        }

        /// <summary>
        /// Filters through a list of items and returns a new list with items that have a similar description
        /// to the passed value and updates the quantity of items to reflect transactions in the cart
        /// </summary>
        /// <typeparam name="T">The type of item to search. Either a book, periodical, or map</typeparam>
        /// <param name="items">The list of items to filter through</param>
        /// <param name="description">The description to look for</param>
        /// <param name="transactions">The transactions to update the item quantity based off</param>
        /// <returns></returns>
        public static BindingList<T> GetFilteredItemsAndUpdateQuantity<T>(BindingList<T> items, string description, List<int> tagIds, BindingList<DBTransaction> transactions) where T : DBItem
        {
            BindingList<T> filteredItems = new BindingList<T>();
            foreach (T item in items)
            {

                //Update the quantity of the displayed item based on transactions currently in cart
                foreach(DBTransaction t in transactions)
                {
                    if(t.ItemID == item.GetItemID())
                    {
                        item.SetQuantity(item.GetQuantity() - t.Quantity);
                    }
                }

                //Check that the entered search description (title or location) matches the item's description
                if (item.GetDescription().ToLower().Contains(description.Trim().ToLower()))
                {

                    //Check to ensure the item has tags matching the tags selected
                    int tagsMatching = 0;
                    for(var i = 0; i < tagIds.Count; i++)
                    {
                        for(var j = 0; j < item.Tags.Count; j++)
                        {
                            if(tagIds[i] == item.Tags[j])
                            {
                                tagsMatching++;
                            }
                        }
                    }

                    if(tagsMatching == tagIds.Count)
                    {
                        filteredItems.Add(item);
                    }
                    
                }
            }
            return filteredItems;   
        }

        /// <summary>
        /// Filters through a list of items and returns a new list with items that have a similar description
        /// to the passed value and updates the quantity of items to reflect transactions in the cart
        /// </summary>
        /// <typeparam name="T">The type of item to search. Either a book, periodical, or map</typeparam>
        /// <param name="items">The list of items to filter through</param>
        /// <param name="description">The description to look for</param>
        /// <param name="transactions">The transactions to update the item quantity based off</param>
        /// <returns></returns>
        public static BindingList<T> GetFilteredItems<T>(BindingList<T> items, string description, List<int> tagIds) where T : DBItem
        {
            return DBControlHelper.GetFilteredItemsAndUpdateQuantity<T>(items, description, tagIds, new BindingList<DBTransaction>());
        }

        /// <summary>
        /// Gets a list of the tag values of checkboxes or radiobuttons which are checked on the passed panel
        /// </summary>
        /// <param name="panel">The panel of controls</param>
        /// <returns>A list of the tag values of checkboxes or radiobuttons which are checked on the passed panel</returns>
        public static List<int> GetValuesFromCheckedControls(Panel panel)
        {
            List<int> result = new List<int>();

            foreach (Control c in panel.Controls)
            {
                if ((c is CheckBox && (c as CheckBox).Checked) || (c is RadioButton && (c as RadioButton).Checked))
                {
                    result.Add(Int32.Parse(c.Tag.ToString()));
                }
            }

            return result;
        }

        //Maximum input size for textboxes on all screens
        public static int MaximumUsernameLength = 15;
        public static int MaximumPasswordLength = 64;
        public static int MaximumTagNameLength = 15;
        public static int MaximumFirstNameLength = 25;
        public static int MaximumLastNameLength = 25;
        public static int MaximumPhoneNumberLength;
        public static int MaximumTitleLength = 50;
        public static int MaximumPublisherLength = 30;
        public static int MaximumLocationLength = 50;
        public static int MaximumCompanyNameLength = 30;
        public static int MaximumFullNameLength
        {
            get
            {
                return MaximumFirstNameLength + MaximumLastNameLength + 1;
            }
        }

    }
}
