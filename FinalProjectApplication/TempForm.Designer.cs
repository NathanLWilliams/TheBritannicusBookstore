using System.Windows.Forms;

namespace FinalProjectApplication
{
    partial class TempForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.TableLayoutPanel();
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
            this.cbxIsCollector = new System.Windows.Forms.CheckBox();
            this.lblItemsTitle = new System.Windows.Forms.Label();
            this.lblCollectorsTitle = new System.Windows.Forms.Label();
            this.lblItemSearchPrompt = new System.Windows.Forms.Label();
            this.txtSearchTitle = new System.Windows.Forms.TextBox();
            this.tlpItemTypes = new System.Windows.Forms.TableLayoutPanel();
            this.rbnBooks = new System.Windows.Forms.RadioButton();
            this.rbnMaps = new System.Windows.Forms.RadioButton();
            this.rbnPeriodicals = new System.Windows.Forms.RadioButton();
            this.lblCollectorSearchPrompt = new System.Windows.Forms.Label();
            this.txtSearchCollectorName = new System.Windows.Forms.TextBox();
            this.mtxtCollectorSearchPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblCollectorSearchNamePrompt = new System.Windows.Forms.Label();
            this.lblCollectorSearchPhoneNumberPrompt = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.tlpItemCollector.SuspendLayout();
            this.tlpItems.SuspendLayout();
            this.tlpItemsSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.tlpCollectors.SuspendLayout();
            this.tlpCollectorsSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollectors)).BeginInit();
            this.tlpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.tlpItemTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.ColumnCount = 1;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel.Controls.Add(this.tlpCollectors, 0, 2);
            this.panel.Controls.Add(this.tlpItemCollector, 0, 0);
            this.panel.Controls.Add(this.tlpItems, 0, 1);
            this.panel.Controls.Add(this.tlpButtons, 0, 3);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.RowCount = 4;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.Size = new System.Drawing.Size(1330, 1061);
            this.panel.TabIndex = 0;
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
            this.tlpItemCollector.Controls.Add(this.cbxIsCollector, 2, 1);
            this.tlpItemCollector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItemCollector.Location = new System.Drawing.Point(3, 3);
            this.tlpItemCollector.Name = "tlpItemCollector";
            this.tlpItemCollector.RowCount = 2;
            this.tlpItemCollector.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItemCollector.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItemCollector.Size = new System.Drawing.Size(1324, 92);
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
            this.tlpItems.Location = new System.Drawing.Point(3, 101);
            this.tlpItems.Name = "tlpItems";
            this.tlpItems.RowCount = 3;
            this.tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItems.Size = new System.Drawing.Size(1324, 422);
            this.tlpItems.TabIndex = 1;
            // 
            // tlpItemsSearch
            // 
            this.tlpItemsSearch.AutoSize = true;
            this.tlpItemsSearch.ColumnCount = 5;
            this.tlpItemsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.89948F));
            this.tlpItemsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.71959F));
            this.tlpItemsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.38093F));
            this.tlpItemsSearch.Controls.Add(this.lblItemSearchPrompt, 0, 0);
            this.tlpItemsSearch.Controls.Add(this.txtSearchTitle, 1, 0);
            this.tlpItemsSearch.Controls.Add(this.tlpItemTypes, 3, 0);
            this.tlpItemsSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItemsSearch.Location = new System.Drawing.Point(3, 41);
            this.tlpItemsSearch.Name = "tlpItemsSearch";
            this.tlpItemsSearch.RowCount = 1;
            this.tlpItemsSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItemsSearch.Size = new System.Drawing.Size(1318, 34);
            this.tlpItemsSearch.TabIndex = 0;
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(3, 81);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(1318, 338);
            this.dgvItems.TabIndex = 1;
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
            this.tlpCollectors.Location = new System.Drawing.Point(3, 529);
            this.tlpCollectors.Name = "tlpCollectors";
            this.tlpCollectors.RowCount = 3;
            this.tlpCollectors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCollectors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCollectors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCollectors.Size = new System.Drawing.Size(1324, 422);
            this.tlpCollectors.TabIndex = 2;
            // 
            // tlpCollectorsSearch
            // 
            this.tlpCollectorsSearch.AutoSize = true;
            this.tlpCollectorsSearch.ColumnCount = 5;
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.66432F));
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.67758F));
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.66432F));
            this.tlpCollectorsSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.99378F));
            this.tlpCollectorsSearch.Controls.Add(this.txtSearchCollectorName, 0, 1);
            this.tlpCollectorsSearch.Controls.Add(this.lblCollectorSearchPrompt, 0, 0);
            this.tlpCollectorsSearch.Controls.Add(this.mtxtCollectorSearchPhoneNumber, 2, 1);
            this.tlpCollectorsSearch.Controls.Add(this.lblCollectorSearchNamePrompt, 1, 0);
            this.tlpCollectorsSearch.Controls.Add(this.lblCollectorSearchPhoneNumberPrompt, 2, 0);
            this.tlpCollectorsSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCollectorsSearch.Location = new System.Drawing.Point(3, 41);
            this.tlpCollectorsSearch.Name = "tlpCollectorsSearch";
            this.tlpCollectorsSearch.RowCount = 2;
            this.tlpCollectorsSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCollectorsSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCollectorsSearch.Size = new System.Drawing.Size(1318, 72);
            this.tlpCollectorsSearch.TabIndex = 0;
            // 
            // dgvCollectors
            // 
            this.dgvCollectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCollectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCollectors.Location = new System.Drawing.Point(3, 119);
            this.dgvCollectors.Name = "dgvCollectors";
            this.dgvCollectors.Size = new System.Drawing.Size(1318, 300);
            this.dgvCollectors.TabIndex = 1;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 2;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Controls.Add(this.btnCheckout, 1, 0);
            this.tlpButtons.Controls.Add(this.btnAddToCart, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(3, 957);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Size = new System.Drawing.Size(1324, 101);
            this.tlpButtons.TabIndex = 3;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddToCart.AutoSize = true;
            this.btnAddToCart.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddToCart.Location = new System.Drawing.Point(561, 36);
            this.btnAddToCart.MaximumSize = new System.Drawing.Size(250, 33);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(98, 28);
            this.btnAddToCart.TabIndex = 0;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCheckout.AutoSize = true;
            this.btnCheckout.BackColor = System.Drawing.SystemColors.Control;
            this.btnCheckout.Location = new System.Drawing.Point(665, 36);
            this.btnCheckout.MaximumSize = new System.Drawing.Size(250, 33);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(94, 28);
            this.btnCheckout.TabIndex = 1;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = false;
            // 
            // lblItemPrompt
            // 
            this.lblItemPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemPrompt.AutoSize = true;
            this.lblItemPrompt.Location = new System.Drawing.Point(121, 14);
            this.lblItemPrompt.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblItemPrompt.Name = "lblItemPrompt";
            this.lblItemPrompt.Size = new System.Drawing.Size(41, 18);
            this.lblItemPrompt.TabIndex = 0;
            this.lblItemPrompt.Text = "Item:";
            // 
            // lblCollectorPrompt
            // 
            this.lblCollectorPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCollectorPrompt.AutoSize = true;
            this.lblCollectorPrompt.Location = new System.Drawing.Point(88, 60);
            this.lblCollectorPrompt.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblCollectorPrompt.Name = "lblCollectorPrompt";
            this.lblCollectorPrompt.Size = new System.Drawing.Size(74, 18);
            this.lblCollectorPrompt.TabIndex = 1;
            this.lblCollectorPrompt.Text = "Collector:";
            // 
            // cbxSelectedItem
            // 
            this.cbxSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectedItem.FormattingEnabled = true;
            this.cbxSelectedItem.Location = new System.Drawing.Point(168, 12);
            this.cbxSelectedItem.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.cbxSelectedItem.Name = "cbxSelectedItem";
            this.cbxSelectedItem.Size = new System.Drawing.Size(159, 26);
            this.cbxSelectedItem.TabIndex = 2;
            // 
            // cbxSelectedCollector
            // 
            this.cbxSelectedCollector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectedCollector.FormattingEnabled = true;
            this.cbxSelectedCollector.Location = new System.Drawing.Point(168, 56);
            this.cbxSelectedCollector.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.cbxSelectedCollector.Name = "cbxSelectedCollector";
            this.cbxSelectedCollector.Size = new System.Drawing.Size(159, 26);
            this.cbxSelectedCollector.TabIndex = 3;
            // 
            // lblQuantityPrompt
            // 
            this.lblQuantityPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuantityPrompt.AutoSize = true;
            this.lblQuantityPrompt.Location = new System.Drawing.Point(424, 14);
            this.lblQuantityPrompt.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblQuantityPrompt.Name = "lblQuantityPrompt";
            this.lblQuantityPrompt.Size = new System.Drawing.Size(68, 18);
            this.lblQuantityPrompt.TabIndex = 4;
            this.lblQuantityPrompt.Text = "Quantity:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQuantity.Location = new System.Drawing.Point(498, 10);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(159, 26);
            this.nudQuantity.TabIndex = 5;
            // 
            // lblConditionPrompt
            // 
            this.lblConditionPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblConditionPrompt.AutoSize = true;
            this.lblConditionPrompt.Location = new System.Drawing.Point(743, 14);
            this.lblConditionPrompt.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblConditionPrompt.Name = "lblConditionPrompt";
            this.lblConditionPrompt.Size = new System.Drawing.Size(79, 18);
            this.lblConditionPrompt.TabIndex = 6;
            this.lblConditionPrompt.Text = "Condition:";
            // 
            // lblCondition
            // 
            this.lblCondition.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCondition.AutoSize = true;
            this.lblCondition.Location = new System.Drawing.Point(828, 14);
            this.lblCondition.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(42, 18);
            this.lblCondition.TabIndex = 7;
            this.lblCondition.Text = "Poor";
            // 
            // lblTotalPricePrompt
            // 
            this.lblTotalPricePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalPricePrompt.AutoSize = true;
            this.lblTotalPricePrompt.Location = new System.Drawing.Point(1067, 14);
            this.lblTotalPricePrompt.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblTotalPricePrompt.Name = "lblTotalPricePrompt";
            this.lblTotalPricePrompt.Size = new System.Drawing.Size(85, 18);
            this.lblTotalPricePrompt.TabIndex = 8;
            this.lblTotalPricePrompt.Text = "Total Price:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(1158, 14);
            this.lblTotalPrice.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(119, 18);
            this.lblTotalPrice.TabIndex = 9;
            this.lblTotalPrice.Text = "5.99 discounted";
            // 
            // cbxIsCollector
            // 
            this.cbxIsCollector.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbxIsCollector.AutoSize = true;
            this.tlpItemCollector.SetColumnSpan(this.cbxIsCollector, 2);
            this.cbxIsCollector.Location = new System.Drawing.Point(458, 58);
            this.cbxIsCollector.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.cbxIsCollector.Name = "cbxIsCollector";
            this.cbxIsCollector.Size = new System.Drawing.Size(199, 22);
            this.cbxIsCollector.TabIndex = 10;
            this.cbxIsCollector.Text = "Customer is a Collector?";
            this.cbxIsCollector.UseVisualStyleBackColor = true;
            // 
            // lblItemsTitle
            // 
            this.lblItemsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemsTitle.AutoSize = true;
            this.lblItemsTitle.Location = new System.Drawing.Point(3, 10);
            this.lblItemsTitle.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblItemsTitle.Name = "lblItemsTitle";
            this.lblItemsTitle.Size = new System.Drawing.Size(1318, 18);
            this.lblItemsTitle.TabIndex = 2;
            this.lblItemsTitle.Text = "What would you like to sell?";
            this.lblItemsTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCollectorsTitle
            // 
            this.lblCollectorsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCollectorsTitle.AutoSize = true;
            this.lblCollectorsTitle.Location = new System.Drawing.Point(3, 10);
            this.lblCollectorsTitle.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblCollectorsTitle.Name = "lblCollectorsTitle";
            this.lblCollectorsTitle.Size = new System.Drawing.Size(1318, 18);
            this.lblCollectorsTitle.TabIndex = 2;
            this.lblCollectorsTitle.Text = "Who would you like to sell to?";
            this.lblCollectorsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemSearchPrompt
            // 
            this.lblItemSearchPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemSearchPrompt.AutoSize = true;
            this.lblItemSearchPrompt.Location = new System.Drawing.Point(3, 8);
            this.lblItemSearchPrompt.Name = "lblItemSearchPrompt";
            this.lblItemSearchPrompt.Size = new System.Drawing.Size(114, 18);
            this.lblItemSearchPrompt.TabIndex = 0;
            this.lblItemSearchPrompt.Text = "Search by Title:";
            // 
            // txtSearchTitle
            // 
            this.txtSearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchTitle.Location = new System.Drawing.Point(123, 4);
            this.txtSearchTitle.Name = "txtSearchTitle";
            this.txtSearchTitle.Size = new System.Drawing.Size(235, 26);
            this.txtSearchTitle.TabIndex = 1;
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
            this.tlpItemTypes.Location = new System.Drawing.Point(557, 3);
            this.tlpItemTypes.Name = "tlpItemTypes";
            this.tlpItemTypes.RowCount = 1;
            this.tlpItemTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItemTypes.Size = new System.Drawing.Size(259, 28);
            this.tlpItemTypes.TabIndex = 2;
            // 
            // rbnBooks
            // 
            this.rbnBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnBooks.AutoSize = true;
            this.rbnBooks.Location = new System.Drawing.Point(3, 3);
            this.rbnBooks.Name = "rbnBooks";
            this.rbnBooks.Size = new System.Drawing.Size(71, 22);
            this.rbnBooks.TabIndex = 0;
            this.rbnBooks.TabStop = true;
            this.rbnBooks.Text = "Books";
            this.rbnBooks.UseVisualStyleBackColor = true;
            // 
            // rbnMaps
            // 
            this.rbnMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnMaps.AutoSize = true;
            this.rbnMaps.Location = new System.Drawing.Point(191, 3);
            this.rbnMaps.Name = "rbnMaps";
            this.rbnMaps.Size = new System.Drawing.Size(65, 22);
            this.rbnMaps.TabIndex = 1;
            this.rbnMaps.TabStop = true;
            this.rbnMaps.Text = "Maps";
            this.rbnMaps.UseVisualStyleBackColor = true;
            // 
            // rbnPeriodicals
            // 
            this.rbnPeriodicals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnPeriodicals.AutoSize = true;
            this.rbnPeriodicals.Location = new System.Drawing.Point(80, 3);
            this.rbnPeriodicals.Name = "rbnPeriodicals";
            this.rbnPeriodicals.Size = new System.Drawing.Size(105, 22);
            this.rbnPeriodicals.TabIndex = 2;
            this.rbnPeriodicals.TabStop = true;
            this.rbnPeriodicals.Text = "Periodicals";
            this.rbnPeriodicals.UseVisualStyleBackColor = true;
            // 
            // lblCollectorSearchPrompt
            // 
            this.lblCollectorSearchPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCollectorSearchPrompt.AutoSize = true;
            this.lblCollectorSearchPrompt.Location = new System.Drawing.Point(3, 27);
            this.lblCollectorSearchPrompt.Name = "lblCollectorSearchPrompt";
            this.tlpCollectorsSearch.SetRowSpan(this.lblCollectorSearchPrompt, 2);
            this.lblCollectorSearchPrompt.Size = new System.Drawing.Size(62, 18);
            this.lblCollectorSearchPrompt.TabIndex = 1;
            this.lblCollectorSearchPrompt.Text = "Search:";
            // 
            // txtSearchCollectorName
            // 
            this.txtSearchCollectorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchCollectorName.Location = new System.Drawing.Point(71, 41);
            this.txtSearchCollectorName.Name = "txtSearchCollectorName";
            this.txtSearchCollectorName.Size = new System.Drawing.Size(377, 26);
            this.txtSearchCollectorName.TabIndex = 2;
            // 
            // mtxtCollectorSearchPhoneNumber
            // 
            this.mtxtCollectorSearchPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mtxtCollectorSearchPhoneNumber.Location = new System.Drawing.Point(454, 41);
            this.mtxtCollectorSearchPhoneNumber.Mask = "(000) 000-0000";
            this.mtxtCollectorSearchPhoneNumber.Name = "mtxtCollectorSearchPhoneNumber";
            this.mtxtCollectorSearchPhoneNumber.Size = new System.Drawing.Size(189, 26);
            this.mtxtCollectorSearchPhoneNumber.TabIndex = 3;
            this.mtxtCollectorSearchPhoneNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblCollectorSearchNamePrompt
            // 
            this.lblCollectorSearchNamePrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCollectorSearchNamePrompt.AutoSize = true;
            this.lblCollectorSearchNamePrompt.Location = new System.Drawing.Point(71, 18);
            this.lblCollectorSearchNamePrompt.Name = "lblCollectorSearchNamePrompt";
            this.lblCollectorSearchNamePrompt.Size = new System.Drawing.Size(377, 18);
            this.lblCollectorSearchNamePrompt.TabIndex = 4;
            this.lblCollectorSearchNamePrompt.Text = "Name";
            this.lblCollectorSearchNamePrompt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCollectorSearchPhoneNumberPrompt
            // 
            this.lblCollectorSearchPhoneNumberPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCollectorSearchPhoneNumberPrompt.AutoSize = true;
            this.lblCollectorSearchPhoneNumberPrompt.Location = new System.Drawing.Point(454, 18);
            this.lblCollectorSearchPhoneNumberPrompt.Name = "lblCollectorSearchPhoneNumberPrompt";
            this.lblCollectorSearchPhoneNumberPrompt.Size = new System.Drawing.Size(189, 18);
            this.lblCollectorSearchPhoneNumberPrompt.TabIndex = 5;
            this.lblCollectorSearchPhoneNumberPrompt.Text = "Phone Number";
            this.lblCollectorSearchPhoneNumberPrompt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TempForm
            // 
            this.ClientSize = new System.Drawing.Size(1330, 1061);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TempForm";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.tlpItemCollector.ResumeLayout(false);
            this.tlpItemCollector.PerformLayout();
            this.tlpItems.ResumeLayout(false);
            this.tlpItems.PerformLayout();
            this.tlpItemsSearch.ResumeLayout(false);
            this.tlpItemsSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.tlpCollectors.ResumeLayout(false);
            this.tlpCollectors.PerformLayout();
            this.tlpCollectorsSearch.ResumeLayout(false);
            this.tlpCollectorsSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollectors)).EndInit();
            this.tlpButtons.ResumeLayout(false);
            this.tlpButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.tlpItemTypes.ResumeLayout(false);
            this.tlpItemTypes.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.TableLayoutPanel panel;

        #endregion

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
        private CheckBox cbxIsCollector;
        private Label lblCollectorsTitle;
        private Label lblItemsTitle;
        private Label lblItemSearchPrompt;
        private TextBox txtSearchTitle;
        private TableLayoutPanel tlpItemTypes;
        private RadioButton rbnPeriodicals;
        private RadioButton rbnMaps;
        private RadioButton rbnBooks;
        private Label lblCollectorSearchPrompt;
        private TextBox txtSearchCollectorName;
        private MaskedTextBox mtxtCollectorSearchPhoneNumber;
        private Label lblCollectorSearchNamePrompt;
        private Label lblCollectorSearchPhoneNumberPrompt;
    }
}