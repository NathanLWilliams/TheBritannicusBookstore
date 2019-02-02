using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class SellItemScreen : Screen
    {
        private TableLayoutPanel tlpCollectors;
        private TableLayoutPanel tlpCollectorsSearch;
        private DataGridView dgvCollectors;
        private TableLayoutPanel tlpItemCollector;
        private TableLayoutPanel tlpItems;
        private TableLayoutPanel tlpItemsSearch;
        private DataGridView dgvItems;
        private TableLayoutPanel tlpButtons;
        private Button btnAddToCart;
        private Button btnCheckout;
        private Label lblItemPrompt;
        private Label lblCollectorPrompt;
        private ComboBox cbxSelectedItem;
        private ComboBox cbxSelectedCollector;
        private Label lblTotalPrice;
        private Label lblTotalPricePrompt;
        private Label lblCondition;
        private Label lblConditionPrompt;
        private Label lblQuantityPrompt;
        private NumericUpDown nudQuantity;
        private CheckBox chkIsCollector;
        private Label lblCollectorsTitle;
        private Label lblItemsTitle;
        private Label lblItemSearchPrompt;
        private TextBox txtSearch;
        private TableLayoutPanel tlpItemTypes;
        private RadioButton rbnPeriodicals;
        private RadioButton rbnMaps;
        private RadioButton rbnBooks;
        private Label lblCollectorSearchPrompt;
        private TextBox txtSearchCollectorName;
        private MaskedTextBox mtxtCollectorSearchPhoneNumber;
        private Label lblCollectorSearchNamePrompt;
        private Label lblCollectorSearchPhoneNumberPrompt;
        private int selectedItemValue;
        private string selectedItemType;

        private BindingList<DBCollector> collectors;
        private BindingList<DBBook> books;
        private BindingList<DBMap> maps;
        private BindingList<DBPeriodical> periodicals;

        public SellItemScreen(Screen backScreen) : base("Sell Item", backScreen, 1, 2, 3)
        {
            this.tlpItemCollector = new System.Windows.Forms.TableLayoutPanel();
            this.tlpItems = new System.Windows.Forms.TableLayoutPanel();
            this.tlpItemsSearch = new System.Windows.Forms.TableLayoutPanel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.tlpCollectors = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCollectorsSearch = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCollectors = new System.Windows.Forms.DataGridView();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblItemPrompt = new System.Windows.Forms.Label();
            this.lblCollectorPrompt = new System.Windows.Forms.Label();
            this.cbxSelectedItem = new System.Windows.Forms.ComboBox();
            this.cbxSelectedCollector = new System.Windows.Forms.ComboBox();
            this.lblQuantityPrompt = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblConditionPrompt = new System.Windows.Forms.Label();
            this.lblCondition = new System.Windows.Forms.Label();
            this.lblTotalPricePrompt = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.chkIsCollector = new System.Windows.Forms.CheckBox();
            this.lblItemsTitle = new System.Windows.Forms.Label();
            this.lblCollectorsTitle = new System.Windows.Forms.Label();
            this.lblItemSearchPrompt = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tlpItemTypes = new System.Windows.Forms.TableLayoutPanel();
            this.rbnBooks = new System.Windows.Forms.RadioButton();
            this.rbnMaps = new System.Windows.Forms.RadioButton();
            this.rbnPeriodicals = new System.Windows.Forms.RadioButton();
            this.lblCollectorSearchPrompt = new System.Windows.Forms.Label();
            this.txtSearchCollectorName = new System.Windows.Forms.TextBox();
            this.mtxtCollectorSearchPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblCollectorSearchNamePrompt = new System.Windows.Forms.Label();
            this.lblCollectorSearchPhoneNumberPrompt = new System.Windows.Forms.Label();
            // 
            // panel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(this.tlpCollectors, 0, 2);
            this.Controls.Add(this.tlpItemCollector, 0, 0);
            this.Controls.Add(this.tlpItems, 0, 1);
            this.Controls.Add(this.tlpButtons, 0, 3);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowCount = 4;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ParentChanged += SellItemScreen_ParentChanged;
            // 
            // tlpItemCollector
            // 
            this.tlpItemCollector.AutoSize = true;
            this.tlpItemCollector.BackColor = System.Drawing.Color.White;
            this.tlpItemCollector.ColumnCount = 8;
            this.tlpItemCollector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpItemCollector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpItemCollector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpItemCollector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpItemCollector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpItemCollector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpItemCollector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpItemCollector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpItemCollector.Controls.Add(this.lblTotalPrice, 7, 0);
            this.tlpItemCollector.Controls.Add(this.lblTotalPricePrompt, 6, 0);
            this.tlpItemCollector.Controls.Add(this.lblCondition, 5, 0);
            this.tlpItemCollector.Controls.Add(this.lblConditionPrompt, 4, 0);
            this.tlpItemCollector.Controls.Add(this.lblQuantityPrompt, 2, 0);
            this.tlpItemCollector.Controls.Add(this.lblItemPrompt, 0, 0);
            this.tlpItemCollector.Controls.Add(this.lblCollectorPrompt, 0, 1);
            this.tlpItemCollector.Controls.Add(this.cbxSelectedItem, 1, 0);
            this.tlpItemCollector.Controls.Add(this.cbxSelectedCollector, 1, 1);
            this.tlpItemCollector.Controls.Add(this.nudQuantity, 3, 0);
            this.tlpItemCollector.Controls.Add(this.chkIsCollector, 2, 1);
            this.tlpItemCollector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItemCollector.RowCount = 2;
            this.tlpItemCollector.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItemCollector.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItemCollector.TabIndex = 0;
            // 
            // tlpItems
            // 
            this.tlpItems.BackColor = System.Drawing.Color.White;
            this.tlpItems.ColumnCount = 1;
            this.tlpItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItems.Controls.Add(this.tlpItemsSearch, 0, 1);
            this.tlpItems.Controls.Add(this.dgvItems, 0, 2);
            this.tlpItems.Controls.Add(this.lblItemsTitle, 0, 0);
            this.tlpItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItems.RowCount = 3;
            this.tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItems.TabIndex = 1;
            // 
            // tlpItemsSearch
            // 
            this.tlpItemsSearch.AutoSize = true;
            this.tlpItemsSearch.ColumnCount = 5;
            this.tlpItemsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.89948F));
            this.tlpItemsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.71959F));
            this.tlpItemsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.38093F));
            this.tlpItemsSearch.Controls.Add(this.lblItemSearchPrompt, 0, 0);
            this.tlpItemsSearch.Controls.Add(this.txtSearch, 1, 0);
            this.tlpItemsSearch.Controls.Add(this.tlpItemTypes, 3, 0);
            this.tlpItemsSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItemsSearch.RowCount = 1;
            this.tlpItemsSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItemsSearch.TabIndex = 0;
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.TabIndex = 1;
            this.dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // tlpCollectors
            // 
            this.tlpCollectors.BackColor = System.Drawing.Color.White;
            this.tlpCollectors.ColumnCount = 1;
            this.tlpCollectors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCollectors.Controls.Add(this.tlpCollectorsSearch, 0, 1);
            this.tlpCollectors.Controls.Add(this.dgvCollectors, 0, 2);
            this.tlpCollectors.Controls.Add(this.lblCollectorsTitle, 0, 0);
            this.tlpCollectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCollectors.RowCount = 3;
            this.tlpCollectors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCollectors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCollectors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCollectors.TabIndex = 2;
            // 
            // tlpCollectorsSearch
            // 
            this.tlpCollectorsSearch.AutoSize = true;
            this.tlpCollectorsSearch.ColumnCount = 5;
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.66432F));
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.66432F));
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.99378F));
            this.tlpCollectorsSearch.Controls.Add(this.txtSearchCollectorName, 1, 1);
            this.tlpCollectorsSearch.Controls.Add(this.lblCollectorSearchPrompt, 0, 1);
            this.tlpCollectorsSearch.Controls.Add(this.mtxtCollectorSearchPhoneNumber, 3, 1);
            this.tlpCollectorsSearch.Controls.Add(this.lblCollectorSearchNamePrompt, 1, 0);
            this.tlpCollectorsSearch.Controls.Add(this.lblCollectorSearchPhoneNumberPrompt, 3, 0);
            this.tlpCollectorsSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCollectorsSearch.RowCount = 2;
            this.tlpCollectorsSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCollectorsSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCollectorsSearch.TabIndex = 0;
            // 
            // dgvCollectors
            // 
            this.dgvCollectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCollectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCollectors.TabIndex = 1;
            this.dgvCollectors.DataSource = DBCollector.GetCollectors();
            this.dgvCollectors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCollectors.ReadOnly = true;
            this.dgvCollectors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 2;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Controls.Add(this.btnCheckout, 1, 0);
            this.tlpButtons.Controls.Add(this.btnAddToCart, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.TabIndex = 3;
            this.tlpButtons.AutoSize = true;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddToCart.AutoSize = true;
            this.btnAddToCart.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddToCart.MaximumSize = new System.Drawing.Size(250, 33);
            this.btnAddToCart.TabIndex = 0;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += BtnAddToCart_Click;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCheckout.AutoSize = true;
            this.btnCheckout.BackColor = System.Drawing.SystemColors.Control;
            this.btnCheckout.MaximumSize = new System.Drawing.Size(250, 33);
            this.btnCheckout.TabIndex = 1;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += BtnCheckout_Click;
            // 
            // lblItemPrompt
            // 
            this.lblItemPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemPrompt.AutoSize = true;
            this.lblItemPrompt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblItemPrompt.TabIndex = 0;
            this.lblItemPrompt.Text = "Item:";
            // 
            // lblCollectorPrompt
            // 
            this.lblCollectorPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCollectorPrompt.AutoSize = true;
            this.lblCollectorPrompt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblCollectorPrompt.TabIndex = 1;
            this.lblCollectorPrompt.Text = "Collector:";
            // 
            // cbxSelectedItem
            // 
            this.cbxSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectedItem.FormattingEnabled = true;
            this.cbxSelectedItem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbxSelectedItem.TabIndex = 2;
            this.cbxSelectedItem.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxSelectedItem.SelectedValueChanged += CbxSelectedItem_SelectedValueChanged;
            // 
            // cbxSelectedCollector
            // 
            this.cbxSelectedCollector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectedCollector.FormattingEnabled = true;
            this.cbxSelectedCollector.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbxSelectedCollector.TabIndex = 3;
            this.cbxSelectedCollector.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxSelectedCollector.SelectedValue = 1;
            // 
            // lblQuantityPrompt
            // 
            this.lblQuantityPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuantityPrompt.AutoSize = true;
            this.lblQuantityPrompt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblQuantityPrompt.TabIndex = 4;
            this.lblQuantityPrompt.Text = "Quantity:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.nudQuantity.TabIndex = 5;
            this.nudQuantity.Minimum = 0;
            this.nudQuantity.ValueChanged += NudQuantity_ValueChanged;
            // 
            // lblConditionPrompt
            // 
            this.lblConditionPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblConditionPrompt.AutoSize = true;
            this.lblConditionPrompt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblConditionPrompt.TabIndex = 6;
            this.lblConditionPrompt.Text = "Condition:";
            // 
            // lblCondition
            // 
            this.lblCondition.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCondition.AutoSize = true;
            this.lblCondition.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblCondition.TabIndex = 7;
            this.lblCondition.Text = "Poor";
            // 
            // lblTotalPricePrompt
            // 
            this.lblTotalPricePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalPricePrompt.AutoSize = true;
            this.lblTotalPricePrompt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblTotalPricePrompt.TabIndex = 8;
            this.lblTotalPricePrompt.Text = "Total Price:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblTotalPrice.TabIndex = 9;
            this.lblTotalPrice.Text = "5.99 discounted";
            // 
            // cbxIsCollector
            // 
            this.chkIsCollector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIsCollector.AutoSize = true;
            this.tlpItemCollector.SetColumnSpan(this.chkIsCollector, 2);
            this.chkIsCollector.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chkIsCollector.TabIndex = 10;
            this.chkIsCollector.Text = "Customer is a Collector?";
            this.chkIsCollector.UseVisualStyleBackColor = true;
            this.chkIsCollector.Checked = true;
            this.chkIsCollector.CheckedChanged += ChkIsCollector_CheckedChanged;
            // 
            // lblItemsTitle
            // 
            this.lblItemsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemsTitle.AutoSize = true;
            this.lblItemsTitle.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblItemsTitle.TabIndex = 2;
            this.lblItemsTitle.Text = "What would you like to sell?";
            this.lblItemsTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCollectorsTitle
            // 
            this.lblCollectorsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCollectorsTitle.AutoSize = true;
            this.lblCollectorsTitle.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblCollectorsTitle.TabIndex = 2;
            this.lblCollectorsTitle.Text = "Who would you like to sell to?";
            this.lblCollectorsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemSearchPrompt
            // 
            this.lblItemSearchPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemSearchPrompt.AutoSize = true;
            this.lblItemSearchPrompt.TabIndex = 0;
            this.lblItemSearchPrompt.Text = "Search by Title:";
            // 
            // txtSearchTitle
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += Item_SearchTextChanged;
            // 
            // tlpItemTypes
            // 
            this.tlpItemTypes.AutoSize = true;
            this.tlpItemTypes.ColumnCount = 3;
            this.tlpItemTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemTypes.Controls.Add(this.rbnBooks, 0, 0);
            this.tlpItemTypes.Controls.Add(this.rbnMaps, 2, 0);
            this.tlpItemTypes.Controls.Add(this.rbnPeriodicals, 1, 0);
            this.tlpItemTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItemTypes.RowCount = 1;
            this.tlpItemTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItemTypes.TabIndex = 2;
            // 
            // rbnBooks
            // 
            this.rbnBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnBooks.AutoSize = true;
            this.rbnBooks.TabIndex = 0;
            this.rbnBooks.TabStop = true;
            this.rbnBooks.Text = "Books";
            this.rbnBooks.UseVisualStyleBackColor = true;
            this.rbnBooks.CheckedChanged += ItemType_CheckedChanged;
            // 
            // rbnMaps
            // 
            this.rbnMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnMaps.AutoSize = true;
            this.rbnMaps.TabIndex = 1;
            this.rbnMaps.TabStop = true;
            this.rbnMaps.Text = "Maps";
            this.rbnMaps.UseVisualStyleBackColor = true;
            this.rbnMaps.CheckedChanged += ItemType_CheckedChanged;
            // 
            // rbnPeriodicals
            // 
            this.rbnPeriodicals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnPeriodicals.AutoSize = true;
            this.rbnPeriodicals.TabIndex = 2;
            this.rbnPeriodicals.TabStop = true;
            this.rbnPeriodicals.Text = "Periodicals";
            this.rbnPeriodicals.UseVisualStyleBackColor = true;
            this.rbnPeriodicals.CheckedChanged += ItemType_CheckedChanged;
            // 
            // lblCollectorSearchPrompt
            // 
            this.lblCollectorSearchPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCollectorSearchPrompt.AutoSize = true;
            //this.tlpCollectorsSearch.SetRowSpan(this.lblCollectorSearchPrompt, 2);
            this.lblCollectorSearchPrompt.TabIndex = 1;
            this.lblCollectorSearchPrompt.Text = "Search:";
            // 
            // txtSearchCollectorName
            // 
            this.txtSearchCollectorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchCollectorName.TabIndex = 2;
            this.txtSearchCollectorName.TextChanged += Collector_SearchTextChanged;
            // 
            // mtxtCollectorSearchPhoneNumber
            // 
            this.mtxtCollectorSearchPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mtxtCollectorSearchPhoneNumber.Mask = "(000) 000-0000";
            this.mtxtCollectorSearchPhoneNumber.TabIndex = 3;
            this.mtxtCollectorSearchPhoneNumber.Size = new System.Drawing.Size(200, 33);
            this.mtxtCollectorSearchPhoneNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            this.mtxtCollectorSearchPhoneNumber.TextChanged += Collector_SearchTextChanged;
            // 
            // lblCollectorSearchNamePrompt
            // 
            this.lblCollectorSearchNamePrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCollectorSearchNamePrompt.AutoSize = true;
            this.lblCollectorSearchNamePrompt.TabIndex = 4;
            this.lblCollectorSearchNamePrompt.Text = "Name";
            this.lblCollectorSearchNamePrompt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCollectorSearchPhoneNumberPrompt
            // 
            this.lblCollectorSearchPhoneNumberPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCollectorSearchPhoneNumberPrompt.AutoSize = true;
            this.lblCollectorSearchPhoneNumberPrompt.TabIndex = 5;
            this.lblCollectorSearchPhoneNumberPrompt.Text = "Phone Number";
            this.lblCollectorSearchPhoneNumberPrompt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            selectedItemType = "Book";

            this.SetFontSizes(this.Controls);
        }

        private void Item_SearchTextChanged(object sender, EventArgs e)
        {
            this.DisplayItems();
        }

        private void Collector_SearchTextChanged(object sender, EventArgs e)
        {
            this.DisplayCollectors();
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if(this.nudQuantity.Value == 0) {
                (this.Parent.Parent as MasterForm).SetStatus("Error! Failed to add to cart. Quantity must be greater than zero.");
            }
            else if(!(this.cbxSelectedCollector.SelectedItem is DBCollector))
            {
                (this.Parent.Parent as MasterForm).SetStatus("Error! Failed to add to cart. Please select a collector.");
            }
            else if(!(this.cbxSelectedItem.SelectedItem is DBItem))
            {
                (this.Parent.Parent as MasterForm).SetStatus("Error! Failed to add to cart. Please select an item.");
            }
            else
            {
                Cart.Invoice.AddUncommittedTransaction(new DBTransaction(0, (this.cbxSelectedItem.SelectedItem as DBItem), (int)this.nudQuantity.Value));

                (this.Parent.Parent as MasterForm).SetStatus("Item \"" + this.cbxSelectedItem.Text + "\" has been added to the cart with a quantity of " + (int)this.nudQuantity.Value);
                this.DisplayItems();
                this.UpdateStock();
            }
        }
        public void SetSelectedItem(int id, string type)
        {
            this.selectedItemValue = id;
            this.selectedItemType = type;
        }

        private void NudQuantity_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateTotalPrice();
        }

        private void SellItemScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnAddToCart;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);

                this.DisplayItems();
                this.DisplayCollectors();

                switch (this.selectedItemType)
                {
                    case "Book":
                        rbnBooks.Checked = true;
                        break;
                    case "Map":
                        rbnMaps.Checked = true;
                        break;
                    case "Periodical":
                        rbnPeriodicals.Checked = true;
                        break;
                }
                this.cbxSelectedCollector.SelectedValue = Cart.Invoice.Collector.CollectorID;
                this.cbxSelectedItem.SelectedValue = selectedItemValue;
            }
            else if(this.cbxSelectedCollector.SelectedItem is DBCollector)
            {
                Cart.Invoice.Collector = (this.cbxSelectedCollector.SelectedItem as DBCollector);
            }
        }
        private void CbxSelectedItem_SelectedValueChanged(object sender, EventArgs e)
        {
            if(this.cbxSelectedItem.SelectedItem is DBItem)
            {
                if (this.cbxSelectedItem.SelectedItem is DBBook)
                {
                    this.lblItemSearchPrompt.Text = "Search by Title:";
                    //this.txtSearch.Text = (this.cbxSelectedItem.SelectedItem as DBBook).Title;
                }
                else if (this.cbxSelectedItem.SelectedItem is DBMap)
                {
                    this.lblItemSearchPrompt.Text = "Search by Location:";
                    //this.txtSearch.Text = (this.cbxSelectedItem.SelectedItem as DBMap).Location;
                }
                else if (this.cbxSelectedItem.SelectedItem is DBPeriodical)
                {
                    this.lblItemSearchPrompt.Text = "Search by Title:";
                    //this.txtSearch.Text = (this.cbxSelectedItem.SelectedItem as DBPeriodical).Title;
                }

                DBItem tempItem = (this.cbxSelectedItem.SelectedItem as DBItem);
                this.lblCondition.Text = tempItem.GetConditionType();
                this.UpdateTotalPrice();
                this.UpdateStock();
                
            }            
        }
        private void UpdateStock()
        {
            if(this.cbxSelectedItem.SelectedItem is DBItem)
            {
                DBItem tempItem = (this.cbxSelectedItem.SelectedItem as DBItem);
                //int stock = tempItem.GetQuantity() - Cart.Invoice.GetQuantityBeingSold(tempItem.GetItemID());
                int stock = tempItem.GetQuantity();
                if((int)this.nudQuantity.Value > stock)
                {
                    this.nudQuantity.Value = stock;
                }
                this.nudQuantity.Maximum = stock;
            }
        }
        private void UpdateTotalPrice()
        {
            if (this.cbxSelectedItem.SelectedItem is DBItem)
            {
                DBItem tempItem = (this.cbxSelectedItem.SelectedItem as DBItem);
                this.lblTotalPrice.Text = tempItem.GetTotalPrice((int)this.nudQuantity.Value).ToString("C");
            }
        }
        private void ItemType_CheckedChanged(object sender, EventArgs e)
        {
            this.DisplayItems();
        }
        private void DisplayItems()
        {
            this.UpdateDataSources();
            if(rbnBooks.Checked)
            {
                this.DisplayBooks();
            }
            else if(rbnPeriodicals.Checked)
            {
                this.DisplayPeriodicals();
            }
            else if(rbnMaps.Checked)
            {
                this.DisplayMaps();
            }
        }
        private void DisplayCollectors()
        {
            try
            {
                BindingList<DBCollector> filteredCollectors = DBControlHelper.GetFilteredCollectors(this.collectors,
                this.txtSearchCollectorName.Text, this.mtxtCollectorSearchPhoneNumber.Text);
                this.dgvCollectors.DataSource = filteredCollectors;
                this.cbxSelectedCollector.DataSource = filteredCollectors;

                //Setup the datagridview
                this.dgvCollectors.Columns["CollectorID"].HeaderText = "Collector ID";
                this.dgvCollectors.Columns["CollectorType"].HeaderText = "Type";
                this.dgvCollectors.Columns["CollectorTypeID"].Visible = false;
                this.dgvCollectors.Columns["FirstName"].Visible = false;
                this.dgvCollectors.Columns["LastName"].Visible = false;
                this.dgvCollectors.Columns["PhoneNumber"].HeaderText = "Phone Number";
                this.dgvCollectors.Columns["ComboBoxDisplay"].Visible = false;

                //Setup the selected collector combobox
                this.cbxSelectedCollector.DisplayMember = "ComboBoxDisplay";
                this.cbxSelectedCollector.ValueMember = "CollectorID";
            }
            catch(Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Failed to display collectors: " + ex.Message);
            }
            
        }
        private void DisplayBooks()
        {
            try
            {
                BindingList<DBBook> filteredBooks = DBControlHelper.GetFilteredItemsAndUpdateQuantity(this.books, this.txtSearch.Text, new List<int>(), Cart.Invoice.Transactions);
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
            }
            catch (Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Failed to display books: " + ex.Message);
            }
        }
        private void DisplayMaps()
        {
            try
            {
                BindingList<DBMap> filteredMaps = DBControlHelper.GetFilteredItemsAndUpdateQuantity(this.maps, this.txtSearch.Text, new List<int>(), Cart.Invoice.Transactions);
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
            }
            catch (Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Failed to display maps: " + ex.Message);
            }
        }
        private void DisplayPeriodicals()
        {
            try
            {
                BindingList<DBPeriodical> filteredPeriodicals = DBControlHelper.GetFilteredItemsAndUpdateQuantity(this.periodicals, this.txtSearch.Text, new List<int>(), Cart.Invoice.Transactions);
                this.dgvItems.DataSource = filteredPeriodicals;
                this.cbxSelectedItem.DataSource = filteredPeriodicals;

                //Setup combobox
                this.cbxSelectedItem.DisplayMember = "ComboBoxDisplay";
                this.cbxSelectedItem.ValueMember = "PeriodicalID";

                //Setup datagridview
                this.dgvItems.Columns["PeriodicalID"].HeaderText = "Periodical ID";
                this.dgvItems.Columns["ConditionType"].HeaderText = "Condition";
                this.dgvItems.Columns["GenreName"].HeaderText = "Genre";
                this.dgvItems.Columns["CompanyName"].HeaderText = "Company";
                this.dgvItems.Columns["PublishDate"].HeaderText = "Publish Date";
                this.dgvItems.Columns["ComboBoxDisplay"].Visible = false;
                this.dgvItems.Columns["ShowDiscount"].Visible = false;
            }
            catch (Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Failed to display periodicals: " + ex.Message);
            }
        }
        private void UpdateDataSources()
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

            try
            {
                collectors = DBCollector.GetCollectors();
            }
            catch(Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Failed to load collectors: " + ex.Message);
            }
        }

        private void ChkIsCollector_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as CheckBox).Checked)
            {
                this.cbxSelectedCollector.Enabled = true;
                this.dgvCollectors.Enabled = true;
            }
            else
            {
                this.cbxSelectedCollector.Enabled = false;
                this.dgvCollectors.Enabled = false;

                //Select the anonymous collector
                if (this.cbxSelectedCollector.Items.Count > 0)
                {
                    this.cbxSelectedCollector.SelectedValue = 1;
                }
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            Cart.Invoice.Collector = (this.cbxSelectedCollector.SelectedItem as DBCollector);
            master.SetScreen(master.screenCheckout, true);
        }
    }
}
