using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class AddItemScreen : Screen
    {
        private TableLayoutPanel tlpForm;
        private Label lblItemTypePrompt;
        private ComboBox cbxItemType;
        private Label lblQuantityPrompt;
        private Label lblPricePrompt;
        private Label lblConditionPrompt;
        private Label lblPublishDatePrompt;
        private Label lblFormTitle;
        private NumericUpDown nudQuantity;
        private NumericUpDown nudPrice;
        private TrackBar tkbCondition;
        private TableLayoutPanel tlpConditionPanel;
        private Label lblMinCondition;
        private Label lblMaxCondition;
        private Label lblSelectedCondition;
        private DateTimePicker dtpPublishDate;
        private TableLayoutPanel tlpTags;
        private Label lblTagsPrompt;
        private TableLayoutPanel tlpTagSelection;
        private Button btnAdd;
        private NumericUpDown nudEdition;
        private Label lblEditionPrompt;

        //Book
        private TextBox txtTitle;
        private Label lblTitlePrompt;
        private Label lblAuthorFirstPrompt;
        private Label lblAuthorLastPrompt;
        private Label lblPublisherPrompt;
        private Label lblGenrePrompt;
        private TextBox txtAuthorFirst;
        private TextBox txtAuthorLast;
        private TextBox txtPublisher;
        private ComboBox cbxGenre;

        //Map
        private Label lblLocationPrompt;
        private TextBox txtLocation;
        private Label lblYearPrompt;
        private NumericUpDown nudYear;

        //Periodical
        private Label lblCompanyNamePrompt;
        private TextBox txtCompanyName;

        //DB Classes
        private BindingList<DBCondition> conditions;
        private BindingList<DBTag> tags;

        public AddItemScreen(Screen backScreen) : base("Add Item", backScreen, 1, 2)
        {
            //DB Classes
            this.conditions = DBCondition.GetConditions();
            this.tags = DBTag.GetTags();

            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.lblItemTypePrompt = new System.Windows.Forms.Label();
            this.cbxItemType = new System.Windows.Forms.ComboBox();
            this.lblQuantityPrompt = new System.Windows.Forms.Label();
            this.lblPricePrompt = new System.Windows.Forms.Label();
            this.lblConditionPrompt = new System.Windows.Forms.Label();
            this.lblPublishDatePrompt = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.tkbCondition = new System.Windows.Forms.TrackBar();
            this.tlpConditionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblMinCondition = new System.Windows.Forms.Label();
            this.lblMaxCondition = new System.Windows.Forms.Label();
            this.lblSelectedCondition = new System.Windows.Forms.Label();
            this.dtpPublishDate = new System.Windows.Forms.DateTimePicker();
            this.tlpTags = new System.Windows.Forms.TableLayoutPanel();
            this.lblTagsPrompt = new System.Windows.Forms.Label();
            this.tlpTagSelection = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nudEdition = new NumericUpDown();
            this.lblEditionPrompt = new Label();

            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(this.tlpForm, 0, 0);
            this.Controls.Add(this.btnAdd, 0, 1);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowCount = 2;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TabIndex = 0;
            this.ParentChanged += AddItemScreen_ParentChanged;
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 7;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.52252F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.AutoSize));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.52252F));
            this.tlpForm.Controls.Add(this.lblPublishDatePrompt, 4, 5);
            this.tlpForm.Controls.Add(this.lblConditionPrompt, 1, 6);
            this.tlpForm.Controls.Add(this.lblPricePrompt, 1, 3);
            this.tlpForm.Controls.Add(this.lblQuantityPrompt, 1, 2);
            this.tlpForm.Controls.Add(this.lblItemTypePrompt, 1, 1);
            this.tlpForm.Controls.Add(this.cbxItemType, 2, 1);
            this.tlpForm.Controls.Add(this.lblFormTitle, 0, 0);
            this.tlpForm.SetColumnSpan(this.lblFormTitle, 7);
            this.tlpForm.Controls.Add(this.nudQuantity, 2, 2);
            this.tlpForm.Controls.Add(this.nudPrice, 2, 3);
            this.tlpForm.Controls.Add(this.tlpConditionPanel, 2, 6);
            this.tlpForm.SetColumnSpan(this.tlpConditionPanel, 4);
            this.tlpForm.Controls.Add(this.dtpPublishDate, 5, 5);
            this.tlpForm.Controls.Add(this.tlpTags, 1, 7);
            this.tlpForm.Controls.Add(this.nudEdition, 2, 4);
            this.tlpForm.Controls.Add(this.lblEditionPrompt, 1, 4);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.RowCount = 8;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpForm.TabIndex = 0;
            this.tlpForm.BackColor = System.Drawing.Color.White;

            //Book
            this.lblTitlePrompt = new System.Windows.Forms.Label();
            this.lblTitlePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTitlePrompt.AutoSize = true;
            this.lblTitlePrompt.TabIndex = 6;
            this.lblTitlePrompt.Text = "Title:";
            this.lblAuthorFirstPrompt = new System.Windows.Forms.Label();
            this.lblAuthorFirstPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuthorFirstPrompt.AutoSize = true;
            this.lblAuthorFirstPrompt.TabIndex = 7;
            this.lblAuthorFirstPrompt.Text = "Author First:";
            this.lblAuthorLastPrompt = new System.Windows.Forms.Label();
            this.lblAuthorLastPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuthorLastPrompt.AutoSize = true;
            this.lblAuthorLastPrompt.TabIndex = 7;
            this.lblAuthorLastPrompt.Text = "Author Last:";
            this.lblPublisherPrompt = new System.Windows.Forms.Label();
            this.lblPublisherPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPublisherPrompt.AutoSize = true;
            this.lblPublisherPrompt.TabIndex = 8;
            this.lblPublisherPrompt.Text = "Publisher:";
            this.lblGenrePrompt = new System.Windows.Forms.Label();
            this.lblGenrePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGenrePrompt.AutoSize = true;
            this.lblGenrePrompt.TabIndex = 9;
            this.lblGenrePrompt.Text = "Genre:";
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.TabIndex = 13;
            this.txtTitle.MaxLength = DBControlHelper.MaximumTitleLength;
            this.txtAuthorFirst = new System.Windows.Forms.TextBox();
            this.txtAuthorFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthorFirst.TabIndex = 14;
            this.txtAuthorFirst.MaxLength = DBControlHelper.MaximumFirstNameLength;
            this.txtAuthorLast = new System.Windows.Forms.TextBox();
            this.txtAuthorLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthorLast.TabIndex = 14;
            this.txtAuthorLast.MaxLength = DBControlHelper.MaximumLastNameLength;
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublisher.TabIndex = 15;
            this.txtPublisher.MaxLength = DBControlHelper.MaximumPublisherLength;
            this.cbxGenre = new System.Windows.Forms.ComboBox();
            this.cbxGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxGenre.FormattingEnabled = true;
            this.cbxGenre.TabIndex = 16;
            this.cbxGenre.DataSource = DBGenre.getGenres();
            this.cbxGenre.DisplayMember = "Name";
            this.cbxGenre.ValueMember = "ID";
            this.cbxGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            this.tlpForm.Controls.Add(this.txtTitle, 5, 1);
            this.tlpForm.Controls.Add(this.txtAuthorFirst, 5, 2);
            this.tlpForm.Controls.Add(this.txtAuthorLast, 5, 3);
            this.tlpForm.Controls.Add(this.txtPublisher, 5, 4);
            this.tlpForm.Controls.Add(this.cbxGenre, 2, 5);
            this.tlpForm.Controls.Add(this.lblGenrePrompt, 1, 5);
            this.tlpForm.Controls.Add(this.lblPublisherPrompt, 4, 4);
            this.tlpForm.Controls.Add(this.lblAuthorFirstPrompt, 4, 2);
            this.tlpForm.Controls.Add(this.lblAuthorLastPrompt, 4, 3);
            this.tlpForm.Controls.Add(this.lblTitlePrompt, 4, 1);

            //Map
            this.lblLocationPrompt = new Label();
            this.lblLocationPrompt.AutoSize = true;
            this.lblLocationPrompt.Text = "Location:";
            this.lblLocationPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLocationPrompt.Visible = false;
            this.txtLocation = new TextBox();
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Visible = false;
            this.txtLocation.MaxLength = DBControlHelper.MaximumLocationLength;
            this.lblYearPrompt = new Label();
            this.lblYearPrompt.AutoSize = true;
            this.lblYearPrompt.Text = "Year:";
            this.lblYearPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblYearPrompt.Visible = false;
            this.nudYear = new NumericUpDown();
            this.nudYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudYear.Visible = false;
            this.nudYear.Minimum = 1200;
            this.nudYear.Maximum = DateTime.Now.Year;
            this.tlpForm.Controls.Add(this.lblLocationPrompt, 4, 1);
            this.tlpForm.Controls.Add(this.txtLocation, 5, 1);
            this.tlpForm.Controls.Add(this.lblYearPrompt, 4, 2);
            this.tlpForm.Controls.Add(this.nudYear, 5, 2);

            //Periodical
            this.lblCompanyNamePrompt = new Label();
            this.lblCompanyNamePrompt.AutoSize = true;
            this.lblCompanyNamePrompt.Text = "Company Name:";
            this.lblCompanyNamePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCompanyNamePrompt.Visible = false;
            this.txtCompanyName = new TextBox();
            this.txtCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompanyName.Visible = false;
            this.txtCompanyName.MaxLength = DBControlHelper.MaximumCompanyNameLength;
            this.tlpForm.Controls.Add(this.lblCompanyNamePrompt, 4, 1);
            this.tlpForm.Controls.Add(this.txtCompanyName, 5, 1);

            //lblEditionPrompt
            this.lblEditionPrompt.Text = "Edition:";
            this.lblEditionPrompt.Anchor = AnchorStyles.Right;
            this.lblEditionPrompt.AutoSize = true;

            //nudEdition
            this.nudEdition.Value = 1;
            this.nudEdition.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lblItemTypePrompt
            // 
            this.lblItemTypePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemTypePrompt.AutoSize = true;
            this.lblItemTypePrompt.TabIndex = 0;
            this.lblItemTypePrompt.Text = "Type:";
            // 
            // cbxItemType
            // 
            this.cbxItemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxItemType.FormattingEnabled = true;
            this.cbxItemType.TabIndex = 1;
            this.cbxItemType.DataSource = DBItemType.GetItemTypes();
            this.cbxItemType.ValueMember = "ID";
            this.cbxItemType.DisplayMember = "Name";
            this.cbxItemType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxItemType.SelectedIndexChanged += CbxItemType_SelectedIndexChanged;
            // 
            // lblQuantityPrompt
            // 
            this.lblQuantityPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuantityPrompt.AutoSize = true;
            this.lblQuantityPrompt.TabIndex = 2;
            this.lblQuantityPrompt.Text = "Quantity:";
            // 
            // lblPricePrompt
            // 
            this.lblPricePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPricePrompt.AutoSize = true;
            this.lblPricePrompt.TabIndex = 3;
            this.lblPricePrompt.Text = "Price:";
            // 
            // lblConditionPrompt
            // 
            this.lblConditionPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblConditionPrompt.AutoSize = true;
            this.lblConditionPrompt.TabIndex = 4;
            this.lblConditionPrompt.Text = "Condition:";
            // 
            // lblPublishDatePrompt
            // 
            this.lblPublishDatePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPublishDatePrompt.AutoSize = true;
            this.lblPublishDatePrompt.TabIndex = 5;
            this.lblPublishDatePrompt.Text = "Publish Date:";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Anchor = System.Windows.Forms.AnchorStyles.Left | AnchorStyles.Right;
            this.lblFormTitle.TabIndex = 10;
            this.lblFormTitle.Text = "Basic Information";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormTitle.BackColor = Screen.PrimaryColor;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQuantity.TabIndex = 11;
            // 
            // nudPrice
            // 
            this.nudPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.TabIndex = 12;
            this.nudPrice.ThousandsSeparator = true;
            // 
            // tkbCondition
            // 
            this.tkbCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tkbCondition.TabIndex = 17;
            this.tkbCondition.ValueChanged += TkbCondition_ValueChanged;
            this.tkbCondition.Minimum = 1;
            this.tkbCondition.Maximum = this.conditions.Count;
            this.tkbCondition.Value = (int)Math.Round((double)((this.conditions.Count - 1) / 2));
            // 
            // tlpConditionPanel
            // 
            this.tlpConditionPanel.ColumnCount = 3;
            this.tlpConditionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpConditionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpConditionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpConditionPanel.Controls.Add(this.tkbCondition, 0, 1);
            this.tlpConditionPanel.Controls.Add(this.lblMinCondition, 0, 2);
            this.tlpConditionPanel.Controls.Add(this.lblMaxCondition, 2, 2);
            this.tlpConditionPanel.Controls.Add(this.lblSelectedCondition, 0, 0);
            this.tlpConditionPanel.SetColumnSpan(this.tkbCondition, 3);
            this.tlpConditionPanel.SetColumnSpan(this.lblSelectedCondition, 3);
            this.tlpConditionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditionPanel.RowCount = 3;
            this.tlpConditionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpConditionPanel.TabIndex = 18;
            this.tlpConditionPanel.AutoSize = true;
            // 
            // lblMaxCondition
            // 
            this.lblMinCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinCondition.AutoSize = true;
            this.lblMinCondition.TabIndex = 18;
            this.lblMinCondition.Text = this.conditions.First().Type;
            this.lblMinCondition.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblMinCondition
            // 
            this.lblMaxCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxCondition.AutoSize = true;
            this.lblMaxCondition.TabIndex = 19;
            this.lblMaxCondition.Text = this.conditions.Last().Type;
            this.lblMaxCondition.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSelectedCondition
            // 
            this.lblSelectedCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedCondition.AutoSize = true;
            this.tlpConditionPanel.SetColumnSpan(this.lblSelectedCondition, 3);
            this.lblSelectedCondition.TabIndex = 20;
            this.lblSelectedCondition.Text = this.conditions[tkbCondition.Value - 1].Type;
            this.lblSelectedCondition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dtpPublishDate
            // 
            this.dtpPublishDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPublishDate.TabIndex = 19;
            // 
            // tlpTags
            // 
            this.tlpTags.ColumnCount = 1;
            this.tlpForm.SetColumnSpan(this.tlpTags, 5);
            this.tlpTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTags.Controls.Add(this.lblTagsPrompt, 0, 0);
            this.tlpTags.Controls.Add(this.tlpTagSelection, 0, 1);
            this.tlpTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTags.RowCount = 2;
            this.tlpTags.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTags.TabIndex = 20;
            this.tlpTags.BackColor = Screen.PrimaryColor;
            this.tlpTags.Margin = new Padding(0, 5, 0, 15);
            // 
            // lblTagsPrompt
            // 
            this.lblTagsPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTagsPrompt.AutoSize = true;
            this.lblTagsPrompt.TabIndex = 0;
            this.lblTagsPrompt.Text = "Tags";
            this.lblTagsPrompt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlTagSelection
            // 
            this.tlpTagSelection.AutoScroll = true;
            this.tlpTagSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTagSelection.TabIndex = 1;
            this.tlpTagSelection.BackColor = System.Drawing.Color.White;
            this.tlpTagSelection.ColumnCount = 4;
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTagSelection.HorizontalScroll.Enabled = false;
            DBControlHelper.PopulateWithControls<DBTag, CheckBox>(this.tlpTagSelection, DBTag.GetTags(), "Description", "ID");
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.AutoSize = true;
            this.btnAdd.Size = new System.Drawing.Size(200, 32);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.BackColor = DefaultBackColor;
            this.btnAdd.Click += BtnAdd_Click;

            this.SetFontSizes(this.Controls);
        }

        private void AddItemScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnAdd;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);

                this.tags = DBTag.GetTags();
                try
                {
                    DBControlHelper.PopulateWithControls<DBTag, CheckBox>(this.tlpTagSelection, this.tags, "Description", "ID");
                }
                catch (Exception ex)
                {
                    master.SetStatus("Error! Failed to load tags: " + ex.Message);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            try
            {
                
                //Input data gathered here to improve readability and centralize any processing
                //that needs to be done before insertion
                decimal price = this.nudPrice.Value;
                string publisher = this.txtPublisher.Text.Trim();
                string title = this.txtTitle.Text.Trim();
                string authorFirst = this.txtAuthorFirst.Text.Trim();
                string authorLast = this.txtAuthorLast.Text.Trim();
                string location = this.txtLocation.Text.Trim();
                string companyName = this.txtCompanyName.Text.Trim();
                DateTime publishDate = this.dtpPublishDate.Value;
                int year = (int)this.nudYear.Value;
                int genreID = (int)this.cbxGenre.SelectedValue;
                int conditionID = this.tkbCondition.Value;
                int quantity = (int)this.nudQuantity.Value;
                int edition = (int)this.nudEdition.Value;

                object insertedID = null;
                string status = "";

                switch (this.cbxItemType.SelectedValue)
                {
                    case 1:
                        if(String.IsNullOrEmpty(status = DBBook.Validate(price, title, authorFirst, authorLast, publisher, publishDate)))
                        {
                            insertedID = DBBook.InsertBook(title, price, edition, genreID, authorFirst, authorLast, publisher, 
                                publishDate, conditionID, quantity);

                            if (insertedID != null)
                            {
                                status = "Book " + title + " has been added successfully";
                            }
                        }
                        
                        break;
                    case 2:
                        if(String.IsNullOrEmpty(status = DBMap.Validate(price, location, year, publisher)))
                        {
                            insertedID = DBMap.InsertMap(location, price, edition, publisher, year, conditionID, quantity);

                            if (insertedID != null)
                            {
                                status = "Map " + location + " has been added successfully";
                            }
                        }
                        
                        break;
                    case 3:
                        if(String.IsNullOrEmpty(status = DBPeriodical.Validate(price, title, companyName, publishDate)))
                        {
                            insertedID = DBPeriodical.InsertPeriodical(title, price, edition, companyName, genreID, publishDate, 
                                conditionID, quantity);

                            if (insertedID != null)
                            {
                                status = "Periodical " + title + " has been added successfully";
                            }
                        }
                        
                        break;
                }

                if(insertedID != null)
                {
                    List<int> tagValues = DBControlHelper.GetValuesFromCheckedControls(this.tlpTagSelection);
                    if (tagValues.Count > 0 && DBItem.InsertItemTags((int)insertedID, tagValues))
                    {
                        status += Environment.NewLine + "Item tags added.";
                    }
                }

                master.SetStatus(status);
                
            }
            catch(Exception ex)
            {
                master.SetStatus("Error! Failed to add item: " + ex.Message);
            }
        }

        private void TkbCondition_ValueChanged(object sender, EventArgs e)
        {
            this.lblSelectedCondition.Text = this.conditions[(sender as TrackBar).Value - 1].Type;
        }

        private void SetBookControls(bool isVisible)
        {
            tlpForm.SetRow(lblTitlePrompt, 1);
            tlpForm.SetRow(txtTitle, 1);
            lblTitlePrompt.Visible = isVisible;
            txtTitle.Visible = isVisible;

            tlpForm.SetRow(lblGenrePrompt, 5);
            tlpForm.SetRow(cbxGenre, 5);
            tlpForm.SetColumn(lblGenrePrompt, 1);
            tlpForm.SetColumn(cbxGenre, 2);
            lblGenrePrompt.Visible = isVisible;
            cbxGenre.Visible = isVisible;

            lblAuthorFirstPrompt.Visible = isVisible;
            lblAuthorLastPrompt.Visible = isVisible;
            txtAuthorFirst.Visible = isVisible;
            txtAuthorLast.Visible = isVisible;

            this.tlpForm.SetRow(lblPublisherPrompt, 4);
            lblPublisherPrompt.Visible = isVisible;
            this.tlpForm.SetRow(txtPublisher, 4);
            txtPublisher.Visible = isVisible;

            tlpForm.SetRow(dtpPublishDate, 5);
            tlpForm.SetRow(lblPublishDatePrompt, 5);

            lblPublishDatePrompt.Visible = isVisible;
            dtpPublishDate.Visible = isVisible;
        }
        private void SetMapControls(bool isVisible)
        {
            this.tlpForm.SetRow(lblPublisherPrompt, 3);
            this.tlpForm.SetRow(txtPublisher, 3);
            lblPublisherPrompt.Visible = isVisible;
            txtPublisher.Visible = isVisible;
            this.lblLocationPrompt.Visible = isVisible;
            this.txtLocation.Visible = isVisible;
            this.lblYearPrompt.Visible = isVisible;
            this.nudYear.Visible = isVisible;

        }
        private void SetPeriodicalControls(bool isVisible)
        {
            lblCompanyNamePrompt.Visible = isVisible;
            txtCompanyName.Visible = isVisible;

            tlpForm.SetRow(lblTitlePrompt, 2);
            tlpForm.SetRow(txtTitle, 2);
            lblTitlePrompt.Visible = isVisible;
            txtTitle.Visible = isVisible;

            tlpForm.SetRow(lblGenrePrompt, 3);
            tlpForm.SetRow(cbxGenre, 3);
            tlpForm.SetColumn(lblGenrePrompt, 4);
            tlpForm.SetColumn(cbxGenre, 5);
            lblGenrePrompt.Visible = isVisible;
            cbxGenre.Visible = isVisible;

            tlpForm.SetRow(dtpPublishDate, 4);
            tlpForm.SetRow(lblPublishDatePrompt, 4);

            lblPublishDatePrompt.Visible = isVisible;
            dtpPublishDate.Visible = isVisible;
        }

        private void CbxItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = (sender as ComboBox).Text;
            switch(selectedType)
            {
                case "Book":
                    SetPeriodicalControls(false);
                    SetMapControls(false);
                    SetBookControls(true);
                    break;
                case "Map":
                    SetPeriodicalControls(false);
                    SetBookControls(false);
                    SetMapControls(true);
                    break;
                case "Periodical":
                    SetBookControls(false);
                    SetMapControls(false);
                    SetPeriodicalControls(true);
                    break;
            }
        }
    }
}
