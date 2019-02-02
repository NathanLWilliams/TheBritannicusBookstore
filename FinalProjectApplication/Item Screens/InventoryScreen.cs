using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class InventoryScreen : Screen
    {
        private RadioButton rbnPeriodical;
        private TableLayoutPanel tlpItemTypes;
        private RadioButton rbnMap;
        private RadioButton rbnBook;
        private TableLayoutPanel tlpSearch;
        private Label lblSearchByTitlePrompt;
        private Label lblSelectedItemPrompt;
        private TextBox txtSearch;
        private ComboBox cbxSelectedItem;
        private TableLayoutPanel tlpTags;
        private Label lblTagSelectPrompt;
        private TableLayoutPanel tlpTagSelection;
        private System.Windows.Forms.TableLayoutPanel tlpSearchBar;
        private System.Windows.Forms.TableLayoutPanel tlpEditOptions;
        private System.Windows.Forms.Label lblEditOptionsPrompt;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnSellSelectedItem;
        private System.Windows.Forms.Button btnUpdateItem;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnDeactivateItem;

        private BindingList<DBBook> books;
        private BindingList<DBMap> maps;
        private BindingList<DBPeriodical> periodicals;

        public InventoryScreen(Screen backScreen) : base("Inventory", backScreen, 1, 2, 3)
        {
            this.tlpSearchBar = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEditOptions = new System.Windows.Forms.TableLayoutPanel();
            this.lblEditOptionsPrompt = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDeactivateItem = new System.Windows.Forms.Button();
            this.btnUpdateItem = new System.Windows.Forms.Button();
            this.btnSellSelectedItem = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.rbnPeriodical = new System.Windows.Forms.RadioButton();
            this.rbnBook = new System.Windows.Forms.RadioButton();
            this.tlpItemTypes = new System.Windows.Forms.TableLayoutPanel();
            this.rbnMap = new System.Windows.Forms.RadioButton();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearchByTitlePrompt = new System.Windows.Forms.Label();
            this.lblSelectedItemPrompt = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbxSelectedItem = new System.Windows.Forms.ComboBox();
            this.tlpTags = new System.Windows.Forms.TableLayoutPanel();
            this.lblTagSelectPrompt = new System.Windows.Forms.Label();
            this.tlpTagSelection = new System.Windows.Forms.TableLayoutPanel();
            // 
            // tlpSearchBar
            // 
            this.tlpSearchBar.AutoSize = true;
            this.tlpSearchBar.BackColor = System.Drawing.Color.White;
            this.tlpSearchBar.ColumnCount = 1;
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearchBar.Controls.Add(this.tlpItemTypes, 0, 1);
            this.tlpSearchBar.Controls.Add(this.tlpSearch, 0, 0);
            this.tlpSearchBar.Controls.Add(this.tlpTags, 0, 2);
            this.tlpSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearchBar.Padding = new System.Windows.Forms.Padding(10);
            this.tlpSearchBar.RowCount = 3;
            this.tlpSearchBar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSearchBar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSearchBar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSearchBar.TabIndex = 0;
            // 
            // tlpEditOptions
            // 
            this.tlpEditOptions.AutoSize = true;
            this.tlpEditOptions.BackColor = System.Drawing.Color.White;
            this.tlpEditOptions.ColumnCount = 7;
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpEditOptions.Controls.Add(this.lblEditOptionsPrompt, 1, 0);
            this.tlpEditOptions.Controls.Add(this.btnAddItem, 2, 0);
            this.tlpEditOptions.Controls.Add(this.btnDeactivateItem, 3, 0);
            this.tlpEditOptions.Controls.Add(this.btnUpdateItem, 4, 0);
            this.tlpEditOptions.Controls.Add(this.btnSellSelectedItem, 5, 0);
            this.tlpEditOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEditOptions.RowCount = 1;
            this.tlpEditOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEditOptions.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.tlpEditOptions.TabIndex = 1;
            // 
            // lblEditOptionsPrompt
            // 
            this.lblEditOptionsPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblEditOptionsPrompt.AutoSize = true;
            //this.lblEditOptionsPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditOptionsPrompt.TabIndex = 1;
            this.lblEditOptionsPrompt.Text = "Edit Options";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.AutoSize = true;
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.Click += BtnAddItem_Click;
            this.btnAddItem.BackColor = DefaultBackColor;
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            // 
            // btnRemoveItem
            // 
            this.btnDeactivateItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeactivateItem.AutoSize = true;
            this.btnDeactivateItem.TabIndex = 2;
            this.btnDeactivateItem.Text = "Deactivate Item";
            this.btnDeactivateItem.BackColor = DefaultBackColor;
            this.btnDeactivateItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnDeactivateItem.Click += BtnRemoveItem_Click;
            // 
            // btnUpdateItem
            // 
            this.btnUpdateItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateItem.AutoSize = true;
            this.btnUpdateItem.TabIndex = 3;
            this.btnUpdateItem.Text = "Update Item";
            this.btnUpdateItem.BackColor = DefaultBackColor;
            this.btnUpdateItem.Click += BtnUpdateItem_Click;
            this.btnUpdateItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            // 
            // btnSellSelectedItem
            // 
            this.btnSellSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSellSelectedItem.AutoSize = true;
            this.btnSellSelectedItem.TabIndex = 4;
            this.btnSellSelectedItem.Text = "Sell Selected Item";
            this.btnSellSelectedItem.BackColor = DefaultBackColor;
            this.btnSellSelectedItem.Click += BtnSellSelectedItem_Click;
            this.btnSellSelectedItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            // 
            // dgvItems
            // 
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.TabIndex = 2;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvItems.RowHeadersVisible = false;
            // 
            // panel
            // 
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(this.tlpEditOptions, 0, 0);
            this.Controls.Add(this.tlpSearchBar, 0, 1);
            this.Controls.Add(this.dgvItems, 0, 2);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowCount = 3;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TabIndex = 0;
            this.ParentChanged += InventoryScreen_ParentChanged;
            //this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // rbnPeriodical
            // 
            this.rbnPeriodical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnPeriodical.AutoSize = true;
            this.rbnPeriodical.TabIndex = 6;
            this.rbnPeriodical.TabStop = true;
            this.rbnPeriodical.Text = "Periodicals";
            this.rbnPeriodical.UseVisualStyleBackColor = true;
            this.rbnPeriodical.CheckedChanged += ItemType_CheckedChanged;
            // 
            // rbnBook
            // 
            this.rbnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnBook.AutoSize = true;
            this.rbnBook.TabIndex = 7;
            this.rbnBook.TabStop = true;
            this.rbnBook.Text = "Books";
            this.rbnBook.UseVisualStyleBackColor = true;
            this.rbnBook.Checked = true;
            this.rbnBook.CheckedChanged += ItemType_CheckedChanged;
            
            // 
            // tlpItemTypes
            // 
            this.tlpItemTypes.AutoSize = true;
            this.tlpItemTypes.ColumnCount = 4;
            this.tlpItemTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItemTypes.Controls.Add(this.rbnMap, 2, 0);
            this.tlpItemTypes.Controls.Add(this.rbnBook, 0, 0);
            this.tlpItemTypes.Controls.Add(this.rbnPeriodical, 1, 0);
            this.tlpItemTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItemTypes.RowCount = 1;
            this.tlpItemTypes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItemTypes.TabIndex = 8;
            // 
            // rbnMap
            // 
            this.rbnMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnMap.AutoSize = true;
            this.rbnMap.TabIndex = 8;
            this.rbnMap.TabStop = true;
            this.rbnMap.Text = "Maps";
            this.rbnMap.UseVisualStyleBackColor = true;
            this.rbnMap.CheckedChanged += ItemType_CheckedChanged;
            // 
            // tlpSearchPanel
            // 
            this.tlpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSearch.AutoSize = true;
            this.tlpSearch.ColumnCount = 4;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearch.Controls.Add(this.lblSearchByTitlePrompt, 0, 0);
            this.tlpSearch.Controls.Add(this.lblSelectedItemPrompt, 2, 0);
            this.tlpSearch.Controls.Add(this.txtSearch, 1, 0);
            this.tlpSearch.Controls.Add(this.cbxSelectedItem, 3, 0);
            this.tlpSearch.RowCount = 1;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSearch.TabIndex = 9;
            // 
            // lblSearchByTitlePrompt
            // 
            this.lblSearchByTitlePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSearchByTitlePrompt.AutoSize = true;
            //this.lblSearchByTitlePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchByTitlePrompt.TabIndex = 0;
            this.lblSearchByTitlePrompt.Text = "Search by Title:";
            // 
            // lblSelectedItemPrompt
            // 
            this.lblSelectedItemPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSelectedItemPrompt.AutoSize = true;
            //this.lblSelectedItemPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedItemPrompt.TabIndex = 1;
            this.lblSelectedItemPrompt.Text = "Selected Item:";
            // 
            // txtSearchByTitleInput
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.TabIndex = 2;
            this.txtSearch.MaxLength = DBControlHelper.MaximumTitleLength;
            this.txtSearch.TextChanged += Search_TextChanged;
            // 
            // cbxSelectedItemInput
            // 
            this.cbxSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectedItem.FormattingEnabled = true;
            this.cbxSelectedItem.TabIndex = 3;
            this.cbxSelectedItem.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // tlpTagPanel
            // 
            this.tlpTags.AutoSize = true;
            this.tlpTags.ColumnCount = 1;
            this.tlpTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTags.Controls.Add(this.lblTagSelectPrompt, 0, 0);
            this.tlpTags.Controls.Add(this.tlpTagSelection, 0, 1);
            this.tlpTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTags.RowCount = 2;
            this.tlpTags.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTags.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTags.TabIndex = 10;
            this.tlpTags.BackColor = Screen.PrimaryColor;
            // 
            // lblTagSelectPrompt
            // 
            this.lblTagSelectPrompt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTagSelectPrompt.AutoSize = true;
            //this.lblTagSelectPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagSelectPrompt.TabIndex = 0;
            this.lblTagSelectPrompt.Text = "Tag";
            // 
            // tlpTagSelection
            // 
            this.tlpTagSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTagSelection.AutoScroll = true;
            this.tlpTagSelection.Dock = DockStyle.Fill;
            this.tlpTagSelection.ColumnCount = 6;
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            this.tlpTagSelection.TabIndex = 1;
            this.tlpTagSelection.BackColor = System.Drawing.Color.White;
            DBControlHelper.PopulateWithControls<DBTag, CheckBox>(this.tlpTagSelection, DBTag.GetTags(), "Description", "ID");
            foreach (CheckBox c in this.tlpTagSelection.Controls)
            {
                c.CheckedChanged += Tag_CheckedChanged;
            }

            this.SetFontSizes(this.Controls);
        }

        private void Tag_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowItems();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            this.ShowItems();
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            if (this.cbxSelectedItem.SelectedItem is DBItem)
            {
                try
                {
                    DBItem tempItem = (this.cbxSelectedItem.SelectedItem as DBItem);

                    //Attempt to deactivate
                    if (tempItem.DeactivateItem())
                    {
                        //Deactivation successful

                        master.SetStatus("Item " + tempItem.GetDescription() + " has been deactivated");

                        //Remove all related datagridview rows
                        for (var i = 0; i < this.dgvItems.Rows.Count; i++)
                        {
                            if ((int)this.dgvItems.Rows[i].Cells[0].Value == tempItem.GetItemID())
                            {
                                this.dgvItems.Rows.RemoveAt(i);
                            }
                        }
                        if (rbnBook.Checked)
                        {
                            this.books.Remove(tempItem as DBBook);
                        }
                        else if (rbnMap.Checked)
                        {
                            this.maps.Remove(tempItem as DBMap);
                        }
                        else if(rbnPeriodical.Checked)
                        {
                            this.periodicals.Remove(tempItem as DBPeriodical);
                        }
                    }
                }
                catch (Exception ex)
                {
                    master.SetStatus("Error! Deactivation failed: " + ex.Message);
                }
            }
            else
            {
                master.SetStatus("Error! You must select an item to deactivate");
            }
        }

        private void InventoryScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnUpdateItem;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);

                try
                {
                    DBControlHelper.PopulateWithControls<DBTag, CheckBox>(this.tlpTagSelection, DBTag.GetTags(), "Description", "ID");
                    foreach (CheckBox c in this.tlpTagSelection.Controls)
                    {
                        c.CheckedChanged += Tag_CheckedChanged;
                    }
                }
                catch (Exception ex)
                {
                    master.SetStatus("Error! Failed to load tags: " + ex.Message);
                }

                this.UpdateItems();
                this.ShowItems();
            }
        }

        private void ItemType_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowItems();
        }
        private void ShowItems()
        {
            if(rbnBook.Checked)
            {
                try
                {
                    BindingList<DBBook> filteredBooks = DBControlHelper.GetFilteredItems(this.books, this.txtSearch.Text, DBControlHelper.GetValuesFromCheckedControls(this.tlpTagSelection));
                    this.dgvItems.DataSource = filteredBooks;
                    this.cbxSelectedItem.DataSource = filteredBooks;

                    //Setup combobox
                    this.cbxSelectedItem.DisplayMember = "ComboBoxDisplay";
                    this.cbxSelectedItem.ValueMember = "BookID";

                    //Setup datagridview
                    this.dgvItems.Columns["BookID"].HeaderText = "Book ID";
                    this.dgvItems.Columns["GenreName"].HeaderText = "Genre";
                    this.dgvItems.Columns["PublishDate"].HeaderText = "Publish Date";
                    this.dgvItems.Columns["ConditionType"].HeaderText = "Condition";
                    this.dgvItems.Columns["ComboBoxDisplay"].Visible = false;
                    this.dgvItems.Columns["ShowDiscount"].Visible = false;
                    this.lblSearchByTitlePrompt.Text = "Search by Title:";
                }
                catch (Exception ex)
                {
                    (this.Parent.Parent as MasterForm).SetStatus("Failed to show books: " + ex.Message);
                }
            }
            else if(rbnMap.Checked)
            {
                try
                {
                    BindingList<DBMap> filteredMaps = DBControlHelper.GetFilteredItems(this.maps, this.txtSearch.Text, DBControlHelper.GetValuesFromCheckedControls(this.tlpTagSelection));
                    this.dgvItems.DataSource = filteredMaps;
                    this.cbxSelectedItem.DataSource = filteredMaps;

                    //Setup combobox
                    this.cbxSelectedItem.DisplayMember = "ComboBoxDisplay";
                    this.cbxSelectedItem.ValueMember = "MapID";

                    //Setup datagridview
                    this.dgvItems.Columns["MapID"].HeaderText = "Map ID";
                    this.dgvItems.Columns["ConditionType"].HeaderText = "Condition";
                    this.dgvItems.Columns["ComboBoxDisplay"].Visible = false;
                    this.dgvItems.Columns["ShowDiscount"].Visible = false;
                    this.lblSearchByTitlePrompt.Text = "Search by Location:";
                }
                catch (Exception ex)
                {
                    (this.Parent.Parent as MasterForm).SetStatus("Failed to show maps: " + ex.Message);
                }
            }
            else if(rbnPeriodical.Checked)
            {
                try
                {
                    
                    BindingList<DBPeriodical> filteredPeriodicals = DBControlHelper.GetFilteredItems(this.periodicals, this.txtSearch.Text, DBControlHelper.GetValuesFromCheckedControls(this.tlpTagSelection));
                    this.dgvItems.DataSource = filteredPeriodicals;
                    this.cbxSelectedItem.DataSource = filteredPeriodicals;

                    //Setup datagridview
                    this.dgvItems.Columns["PeriodicalID"].HeaderText = "Periodical ID";
                    this.dgvItems.Columns["ConditionType"].HeaderText = "Condition";
                    this.dgvItems.Columns["GenreName"].HeaderText = "Genre";
                    this.dgvItems.Columns["CompanyName"].HeaderText = "Company";
                    this.dgvItems.Columns["PublishDate"].HeaderText = "Publish Date";
                    this.dgvItems.Columns["ComboBoxDisplay"].Visible = false;
                    this.dgvItems.Columns["ShowDiscount"].Visible = false;
                    this.lblSearchByTitlePrompt.Text = "Search by Title:";

                    //Setup combobox
                    this.cbxSelectedItem.DisplayMember = "ComboBoxDisplay";
                    this.cbxSelectedItem.ValueMember = "PeriodicalID";

                }
                catch (Exception ex)
                {
                    (this.Parent.Parent as MasterForm).SetStatus("Failed to show periodicals: " + ex.Message);
                }
            }
        }
        private void UpdateItems()
        {
            //Pull books from the database, if it fails show a status message
            try
            {
                books = DBBook.GetBooks();
            }
            catch (Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Failed to load books: " + ex.Message);
            }

            //Pull maps from the database, if it fails show a status message
            try
            {
                maps = DBMap.GetMaps();
            }
            catch (Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Failed to load maps: " + ex.Message);
            }

            //Pull periodicals from the database, if it fails show a status message
            try
            {
                periodicals = DBPeriodical.GetPeriodicals();
            }
            catch (Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Failed to load periodicals: " + ex.Message);
            }
        }

        private void BtnUpdateItem_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            if(cbxSelectedItem.SelectedItem is DBItem)
            {
                master.screenUpdateItem.SetItemID((int)cbxSelectedItem.SelectedValue);
            }
            master.SetScreen(master.screenUpdateItem, true);
        }

        private void BtnSellSelectedItem_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            if (this.cbxSelectedItem.SelectedItem is DBItem)
            {
                if(rbnBook.Checked)
                {
                    master.screenSellItem.SetSelectedItem((int)this.cbxSelectedItem.SelectedValue, "Book");
                }
                else if(rbnMap.Checked)
                {
                    master.screenSellItem.SetSelectedItem((int)this.cbxSelectedItem.SelectedValue, "Map");
                }
                else if(rbnPeriodical.Checked)
                {
                    master.screenSellItem.SetSelectedItem((int)this.cbxSelectedItem.SelectedValue, "Periodical");
                }
            }
            master.SetScreen(master.screenSellItem, true);
            master.screenSellItem.BackScreen = this;
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenAddItem, true);
        }
    }
}
