using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class UpdateItemScreen : Screen
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
        private Label lblItemIdPrompt;
        private NumericUpDown nudItemID;
        private TableLayoutPanel tlpDiscountPanel;
        private CheckBox chkSetupDiscountTitle;
        private Label lblDiscountPricePrompt;
        private Label lblDateFrom;
        private DateTimePicker dtpDiscountFrom;
        private Label lblDateTo;
        private DateTimePicker dtpDiscountTo;
        private NumericUpDown nudDiscountPrice;
        private Button btnEndDiscount;
        private TableLayoutPanel tlpButtons;
        private Button btnDeactivate;
        private Button btnUpdate;
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

        //DBClasses
        private BindingList<DBCondition> conditions = DBCondition.GetConditions();
        private BindingList<DBItemType> itemTypes = DBItemType.GetItemTypes();
        private BindingList<DBGenre> genres = DBGenre.getGenres();
        private int itemID = 1;

        public UpdateItemScreen(Screen backScreen) : base("Update Item", backScreen, 1, 2)
        {
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.tlpConditionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tkbCondition = new System.Windows.Forms.TrackBar();
            this.lblMinCondition = new System.Windows.Forms.Label();
            this.lblMaxCondition = new System.Windows.Forms.Label();
            this.lblSelectedCondition = new System.Windows.Forms.Label();
            this.tlpTags = new System.Windows.Forms.TableLayoutPanel();
            this.lblTagsPrompt = new System.Windows.Forms.Label();
            this.tlpTagSelection = new System.Windows.Forms.TableLayoutPanel();
            this.lblPricePrompt = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblQuantityPrompt = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblItemTypePrompt = new System.Windows.Forms.Label();
            this.cbxItemType = new System.Windows.Forms.ComboBox();
            this.lblItemIdPrompt = new System.Windows.Forms.Label();
            this.nudItemID = new System.Windows.Forms.NumericUpDown();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblConditionPrompt = new System.Windows.Forms.Label();
            this.lblPublishDatePrompt = new System.Windows.Forms.Label();
            this.dtpPublishDate = new System.Windows.Forms.DateTimePicker();
            this.tlpDiscountPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDiscountFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDiscountTo = new System.Windows.Forms.DateTimePicker();
            this.chkSetupDiscountTitle = new System.Windows.Forms.CheckBox();
            this.btnEndDiscount = new System.Windows.Forms.Button();
            this.lblDiscountPricePrompt = new System.Windows.Forms.Label();
            this.nudDiscountPrice = new System.Windows.Forms.NumericUpDown();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.nudEdition = new NumericUpDown();
            this.lblEditionPrompt = new Label();

            // 
            // tlpForm
            // 
            this.tlpForm.BackColor = System.Drawing.Color.White;
            this.tlpForm.ColumnCount = 7;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.52252F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.AutoSize));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.52252F));
            this.tlpForm.Controls.Add(this.tlpConditionPanel, 2, 7);
            this.tlpForm.Controls.Add(this.tlpTags, 1, 8);
            this.tlpForm.Controls.Add(this.lblPricePrompt, 1, 4);
            this.tlpForm.Controls.Add(this.nudPrice, 2, 4);
            this.tlpForm.Controls.Add(this.lblQuantityPrompt, 1, 3);
            this.tlpForm.Controls.Add(this.nudQuantity, 2, 3);
            this.tlpForm.Controls.Add(this.lblItemTypePrompt, 1, 2);
            this.tlpForm.Controls.Add(this.cbxItemType, 2, 2);
            this.tlpForm.Controls.Add(this.lblItemIdPrompt, 1, 1);
            this.tlpForm.Controls.Add(this.nudItemID, 2, 1);
            this.tlpForm.Controls.Add(this.lblFormTitle, 0, 0);
            this.tlpForm.Controls.Add(this.lblConditionPrompt, 1, 7);
            this.tlpForm.Controls.Add(this.lblPublishDatePrompt, 1, 6);
            this.tlpForm.Controls.Add(this.dtpPublishDate, 2, 6);
            this.tlpForm.Controls.Add(this.nudEdition, 2, 5);
            this.tlpForm.Controls.Add(this.lblEditionPrompt, 1, 5);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.RowCount = 9;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.737864F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.737864F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.737864F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.737864F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.737864F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.737864F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.737864F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.83496F));
            this.tlpForm.TabIndex = 0;

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
            this.cbxGenre.DataSource = this.genres;
            this.cbxGenre.ValueMember = "ID";
            this.cbxGenre.DisplayMember = "Name";
            this.cbxGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            this.tlpForm.Controls.Add(this.txtTitle, 5, 1);
            this.tlpForm.Controls.Add(this.txtAuthorFirst, 5, 2);
            this.tlpForm.Controls.Add(this.txtAuthorLast, 5, 3);
            this.tlpForm.Controls.Add(this.txtPublisher, 5, 4);
            this.tlpForm.Controls.Add(this.cbxGenre, 5, 5);
            this.tlpForm.Controls.Add(this.lblGenrePrompt, 4, 5);
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
            // tlpConditionPanel
            // 
            this.tlpConditionPanel.ColumnCount = 2;
            this.tlpForm.SetColumnSpan(this.tlpConditionPanel, 4);
            this.tlpConditionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpConditionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpConditionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpConditionPanel.Controls.Add(this.tkbCondition, 0, 1);
            this.tlpConditionPanel.Controls.Add(this.lblMinCondition, 0, 2);
            this.tlpConditionPanel.Controls.Add(this.lblMaxCondition, 1, 2);
            this.tlpConditionPanel.Controls.Add(this.lblSelectedCondition, 0, 0);
            this.tlpConditionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditionPanel.RowCount = 3;
            this.tlpConditionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpConditionPanel.TabIndex = 18;
            this.tlpConditionPanel.AutoSize = true;
            // 
            // tkbCondition
            // 
            this.tkbCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpConditionPanel.SetColumnSpan(this.tkbCondition, 3);
            this.tkbCondition.TabIndex = 17;
            this.tkbCondition.Value = 5;
            this.tkbCondition.Minimum = 1;
            this.tkbCondition.Maximum = this.conditions.Count;
            this.tkbCondition.Value = (int)Math.Round((double)((this.conditions.Count - 1) / 2));
            this.tkbCondition.ValueChanged += TkbCondition_ValueChanged;
            // 
            // lblMinCondition
            // 
            this.lblMinCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinCondition.AutoSize = true;
            this.lblMinCondition.TabIndex = 18;
            this.lblMinCondition.Text = this.conditions.First().Type;
            this.lblMinCondition.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblMaxCondition
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
            this.lblSelectedCondition.Text = this.conditions[tkbCondition.Value-1].Type;
            this.lblSelectedCondition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tlpTags
            // 
            this.tlpTags.BackColor = Screen.PrimaryColor;
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
            this.tlpTagSelection.BackColor = System.Drawing.Color.White;
            this.tlpTagSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTagSelection.TabIndex = 1;
            this.tlpTagSelection.ColumnCount = 3;
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            this.tlpTagSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            this.tlpTagSelection.HorizontalScroll.Enabled = false;
            DBControlHelper.PopulateWithControls<DBTag, CheckBox>(this.tlpTagSelection, DBTag.GetTags(), "Description", "ID");
            // 
            // lblPricePrompt
            // 
            this.lblPricePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPricePrompt.AutoSize = true;
            this.lblPricePrompt.TabIndex = 3;
            this.lblPricePrompt.Text = "Price:";
            // 
            // nudPrice
            // 
            this.nudPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.TabIndex = 12;
            this.nudPrice.ThousandsSeparator = true;
            // 
            // lblQuantityPrompt
            // 
            this.lblQuantityPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuantityPrompt.AutoSize = true;
            this.lblQuantityPrompt.TabIndex = 2;
            this.lblQuantityPrompt.Text = "Quantity:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQuantity.TabIndex = 11;
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
            this.cbxItemType.DataSource = itemTypes;
            this.cbxItemType.ValueMember = "ID";
            this.cbxItemType.DisplayMember = "Name";
            this.cbxItemType.Enabled = false;
            this.cbxItemType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxItemType.SelectedValueChanged += CbxItemType_SelectedValueChanged;
            // 
            // lblGenrePrompt
            // 
            this.lblGenrePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGenrePrompt.AutoSize = true;
            this.lblGenrePrompt.TabIndex = 9;
            this.lblGenrePrompt.Text = "Genre:";
            // 
            // lblItemIdPrompt
            // 
            this.lblItemIdPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemIdPrompt.AutoSize = true;
            this.lblItemIdPrompt.TabIndex = 21;
            this.lblItemIdPrompt.Text = "Item ID:";
            // 
            // lblItemId
            // 
            this.nudItemID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudItemID.AutoSize = true;
            this.nudItemID.TabIndex = 22;
            this.nudItemID.Value = 1;
            this.nudItemID.Minimum = 1;
            this.nudItemID.ValueChanged += NudItemID_ValueChanged;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormTitle.AutoSize = true;
            this.tlpForm.SetColumnSpan(this.lblFormTitle, 7);
            this.lblFormTitle.TabIndex = 10;
            this.lblFormTitle.Text = "Basic Information";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblFormTitle.BackColor = Screen.PrimaryColor;
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
            // dtpPublishDate
            // 
            this.dtpPublishDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPublishDate.TabIndex = 19;
            // 
            // panel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(this.tlpForm, 0, 0);
            this.Controls.Add(this.tlpDiscountPanel, 0, 1);
            this.Controls.Add(this.tlpButtons, 0, 2);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowCount = 3;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.72727F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TabIndex = 0;
            this.ParentChanged += UpdateItemScreen_ParentChanged;
            //this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // tlpDiscountPanel
            // 
            this.tlpDiscountPanel.BackColor = System.Drawing.Color.White;
            this.tlpDiscountPanel.ColumnCount = 5;
            this.tlpDiscountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57895F));
            this.tlpDiscountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tlpDiscountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDiscountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tlpDiscountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tlpDiscountPanel.Controls.Add(this.lblDateFrom, 0, 2);
            this.tlpDiscountPanel.Controls.Add(this.dtpDiscountFrom, 1, 2);
            this.tlpDiscountPanel.Controls.Add(this.lblDateTo, 2, 2);
            this.tlpDiscountPanel.Controls.Add(this.dtpDiscountTo, 3, 2);
            this.tlpDiscountPanel.Controls.Add(this.chkSetupDiscountTitle, 0, 0);
            this.tlpDiscountPanel.Controls.Add(this.btnEndDiscount, 4, 2);
            this.tlpDiscountPanel.Controls.Add(this.lblDiscountPricePrompt, 0, 1);
            this.tlpDiscountPanel.Controls.Add(this.nudDiscountPrice, 1, 1);
            this.tlpDiscountPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDiscountPanel.RowCount = 3;
            this.tlpDiscountPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDiscountPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiscountPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiscountPanel.TabIndex = 2;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "From";
            // 
            // dtpDiscountFrom
            // 
            this.dtpDiscountFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDiscountFrom.TabIndex = 20;
            // 
            // lblDateTo
            // 
            this.lblDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.TabIndex = 21;
            this.lblDateTo.Text = "to";
            this.lblDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDiscountTo
            // 
            this.dtpDiscountTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDiscountTo.TabIndex = 22;
            // 
            // lblSetupDiscountTitle
            // 
            //this.chkSetupDiscountTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSetupDiscountTitle.Dock = DockStyle.None;
            this.chkSetupDiscountTitle.Anchor = AnchorStyles.None;
            this.chkSetupDiscountTitle.AutoSize = true;
            this.tlpDiscountPanel.SetColumnSpan(this.chkSetupDiscountTitle, 6);
            this.chkSetupDiscountTitle.TabIndex = 0;
            this.chkSetupDiscountTitle.Text = "Setup Discount";
            this.chkSetupDiscountTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkSetupDiscountTitle.BackColor = Screen.PrimaryColor;
            this.chkSetupDiscountTitle.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSetupDiscountTitle.Checked = true;
            this.chkSetupDiscountTitle.CheckedChanged += ChkSetupDiscountTitle_CheckedChanged;
            // 
            // btnEndDiscount
            // 
            this.btnEndDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEndDiscount.AutoSize = true;
            this.btnEndDiscount.BackColor = System.Drawing.SystemColors.Control;
            this.btnEndDiscount.TabIndex = 24;
            this.btnEndDiscount.Text = "End Prematurely";
            this.btnEndDiscount.UseVisualStyleBackColor = false;
            this.btnEndDiscount.Click += BtnEndDiscount_Click;
            // 
            // lblDiscountPricePrompt
            // 
            this.lblDiscountPricePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDiscountPricePrompt.AutoSize = true;
            this.lblDiscountPricePrompt.TabIndex = 1;
            this.lblDiscountPricePrompt.Text = "Discount Price:";
            // 
            // nudDiscountPrice
            // 
            this.nudDiscountPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDiscountPrice.DecimalPlaces = 2;
            this.nudDiscountPrice.TabIndex = 23;
            this.nudDiscountPrice.ThousandsSeparator = true;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 2;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Controls.Add(this.btnDeactivate, 1, 0);
            this.tlpButtons.Controls.Add(this.btnUpdate, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.TabIndex = 3;
            // 
            // btnRemoveFromInventory
            // 
            this.btnDeactivate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDeactivate.AutoSize = true;
            this.btnDeactivate.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeactivate.TabIndex = 1;
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Size = new System.Drawing.Size(250, 33);
            this.btnDeactivate.Click += BtnDeactivate_Click;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Size = new System.Drawing.Size(250, 33);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += BtnUpdate_Click;

            this.SetFontSizes(this.Controls);
        }

        private void ChkSetupDiscountTitle_CheckedChanged(object sender, EventArgs e)
        {
            bool isEnabled = (sender as CheckBox).Checked;
            this.dtpDiscountFrom.Enabled = isEnabled;
            this.dtpDiscountTo.Enabled = isEnabled;
            this.nudDiscountPrice.Enabled = isEnabled;
            this.btnEndDiscount.Enabled = isEnabled;
        }

        private void BtnEndDiscount_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            try
            {
                if(DBItem.DeleteDiscount((int)this.nudItemID.Value))
                {
                    this.dtpDiscountFrom.ResetText();
                    this.dtpDiscountTo.ResetText();
                    this.nudDiscountPrice.ResetText();
                    master.SetStatus("Discount has ended successfully.");
                }
            }
            catch(Exception ex)
            {
                master.SetStatus("Error! Failed to end discount: " + ex.Message);
            }
        }

        private void BtnDeactivate_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            try
            {
                if (DBItem.DeactivateItem((int)this.nudItemID.Value))
                {
                    master.SetStatus("Item has been deactivated.");
                    if (this.nudItemID.Value > this.nudItemID.Minimum)
                    {
                        this.nudItemID.Value--;
                    }
                }
            }
            catch (Exception ex)
            {
                master.SetStatus("Error! Deactivation failed: " + ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            try
            {

                //Input data gathered here to improve readability and centralize any processing
                //that needs to be done before insertion
                int itemID = (int)this.nudItemID.Value;
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
                decimal discountPrice = this.nudDiscountPrice.Value;
                DateTime discountFrom = this.dtpDiscountFrom.Value;
                DateTime discountTo = this.dtpDiscountTo.Value;

                string status = "";

                switch (cbxItemType.SelectedValue)
                {
                    case 1:
                        if (String.IsNullOrEmpty(status = DBBook.Validate(price, title, authorFirst, authorLast, publisher, publishDate)))
                        {
                            if (DBBook.UpdateBook(itemID, title, price, edition, genreID, authorFirst, authorLast, publisher, publishDate,
                            conditionID, quantity))
                            {
                                status = "Book " + title + " has been saved." + Environment.NewLine;
                            }
                        }
                        break;
                    case 2:
                        if (String.IsNullOrEmpty(status = DBMap.Validate(price, location, year, publisher)))
                        {
                            if (DBMap.UpdateMap(itemID, location, price, edition, publisher, year, conditionID, quantity))
                            {
                                status = "Map " + location + " has been saved." + Environment.NewLine;
                            }
                        }
                        break;
                    case 3:
                        if (String.IsNullOrEmpty(status = DBPeriodical.Validate(price, title, companyName, publishDate)))
                        {
                            if (DBPeriodical.UpdatePeriodical(itemID, title, price, edition, companyName, genreID, publishDate, conditionID,
                            quantity))
                            {
                                status = "Periodical " + title + " has been saved." + Environment.NewLine;
                            }
                        }
                        break;
                }

                if(quantity < Cart.Invoice.GetQuantityBeingSold(itemID))
                {
                    status += "Quantity cannot be less than the amount of the item currently being sold" + Environment.NewLine;
                }
                else
                {
                    for(var i = 0; i < Cart.Invoice.Transactions.Count; i++)
                    {
                        if(Cart.Invoice.Transactions[i].ItemID == itemID)
                        {
                            Cart.Invoice.Transactions[i].SetItemStock(quantity);
                        }
                    }
                }

                if(DBItem.UpdateItemTags(itemID, DBControlHelper.GetValuesFromCheckedControls(this.tlpTagSelection)))
                {
                    status += "Item tags have been saved." + Environment.NewLine;
                }

                if(this.chkSetupDiscountTitle.Checked)
                {
                    string discountError = DBItemDiscount.Validate(discountPrice, discountFrom, discountTo);
                    if (String.IsNullOrEmpty(discountError))
                    {
                        if (DBItem.SaveDiscount(itemID, discountPrice, discountFrom, discountTo))
                        {
                            status += "Discount has been saved." + Environment.NewLine;
                        }
                    }
                    else
                    {
                        status += discountError;
                    }
                }

                master.SetStatus(status);

            }
            catch (Exception ex)
            {
                master.SetStatus("Error! Update failed: " + ex.Message);
            }
        }

        private void UpdateItemScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnUpdate;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);

                this.itemTypes = DBItemType.GetItemTypes();
                this.cbxItemType.DataSource = this.itemTypes;
                this.cbxItemType.DisplayMember = "Name";
                this.cbxItemType.ValueMember = "ID";
                this.genres = DBGenre.getGenres();
                this.cbxGenre.DataSource = this.genres;
                this.cbxGenre.ValueMember = "ID";
                this.cbxGenre.DisplayMember = "Name";
                if(this.nudItemID.Value == itemID)
                {
                    ShowItem();
                }
                else
                {
                    this.nudItemID.Value = itemID;
                }
                
            }
        }

        public void SetItemID(int id)
        {
            itemID = id;
        }

        private void NudItemID_ValueChanged(object sender, EventArgs e)
        {
            ShowItem();
        }
        public void ShowItem()
        {
            int itemTypeID = DBItem.GetDBItemTypeOfId((int)nudItemID.Value);
            cbxItemType.SelectedValue = itemTypeID;
            DBItem tempItem = null;
            switch (itemTypeID)
            {
                case 1:
                    tempItem = DBBook.GetBookOfId((int)nudItemID.Value);
                    DBBook tempBook = (tempItem as DBBook);
                    this.txtTitle.Text = tempBook.Title;
                    this.txtAuthorFirst.Text = tempBook.GetAuthorFirst();
                    this.txtAuthorLast.Text = tempBook.GetAuthorLast();
                    this.cbxGenre.SelectedValue = tempBook.GetGenreID();
                    this.txtPublisher.Text = tempBook.Publisher;
                    this.dtpPublishDate.Value = tempBook.PublishDate;
                    break;
                case 2:
                    tempItem = DBMap.GetMapOfId((int)nudItemID.Value);
                    DBMap tempMap = (tempItem as DBMap);
                    this.txtPublisher.Text = tempMap.Publisher;
                    this.txtLocation.Text = tempMap.Location;
                    this.nudYear.Value = tempMap.Year;
                    break;
                case 3:
                    tempItem = DBPeriodical.GetPeriodicalOfId((int)nudItemID.Value);
                    DBPeriodical tempPeriodical = (tempItem as DBPeriodical);
                    this.txtTitle.Text = tempPeriodical.Title;
                    this.cbxGenre.SelectedValue = tempPeriodical.GetGenreID();
                    this.txtCompanyName.Text = tempPeriodical.CompanyName;
                    this.dtpPublishDate.Value = tempPeriodical.PublishDate;
                    break;
            }

            if (tempItem != null)
            {
                this.tkbCondition.Value = tempItem.GetConditionID();
                this.nudQuantity.Value = tempItem.GetQuantity();

                try
                {
                    DBControlHelper.PopulateWithControls<DBTag, CheckBox>(this.tlpTagSelection, DBTag.GetTags(), "Description", "ID", tempItem.GetTags());
                }
                catch (Exception ex)
                {
                    (this.Parent.Parent as MasterForm).SetStatus("Error! Failed to load tags: " + ex.Message);
                }

                this.nudPrice.Value = tempItem.GetRegularPrice();

                //Show the discount
                if (tempItem.HasDiscount())
                {
                    this.nudDiscountPrice.Value = tempItem.GetDiscount().Amount;
                    this.dtpDiscountFrom.Value = tempItem.GetDiscount().StartDate;
                    this.dtpDiscountTo.Value = tempItem.GetDiscount().EndDate;
                    this.chkSetupDiscountTitle.Checked = true;
                }
                else
                {
                    this.nudDiscountPrice.Value = 0;
                    this.dtpDiscountFrom.ResetText();
                    this.dtpDiscountTo.ResetText();
                    this.chkSetupDiscountTitle.Checked = false;
                }
            }
        }
        private void TkbCondition_ValueChanged(object sender, EventArgs e)
        {
            this.lblSelectedCondition.Text = this.conditions[(sender as TrackBar).Value-1].Type;
        }

        private void SetBookControls(bool isVisible)
        {
            tlpForm.SetRow(lblTitlePrompt, 1);
            tlpForm.SetRow(txtTitle, 1);
            lblTitlePrompt.Visible = isVisible;
            txtTitle.Visible = isVisible;
            tlpForm.SetRow(lblGenrePrompt, 5);
            tlpForm.SetRow(cbxGenre, 5);
            tlpForm.SetColumn(lblGenrePrompt, 4);
            tlpForm.SetColumn(cbxGenre, 5);
            lblGenrePrompt.Visible = isVisible;
            cbxGenre.Visible = isVisible;
            lblAuthorFirstPrompt.Visible = isVisible;
            lblAuthorLastPrompt.Visible = isVisible;
            txtAuthorFirst.Visible = isVisible;
            txtAuthorLast.Visible = isVisible;

            this.tlpForm.SetRow(lblPublisherPrompt, 4);
            this.tlpForm.SetRow(txtPublisher, 4);
            lblPublisherPrompt.Visible = isVisible;
            txtPublisher.Visible = isVisible;

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

            lblPublishDatePrompt.Visible = isVisible;
            dtpPublishDate.Visible = isVisible;
        }

        private void CbxItemType_SelectedValueChanged(object sender, EventArgs e)
        {
            if((sender as ComboBox).SelectedItem is DBItemType)
            {
                int selectedType = (int)(sender as ComboBox).SelectedValue;
                this.SetFormType(selectedType);
            }
            else
            {
                this.ResetForm();
            }
        }
        private void ResetForm()
        {
            this.txtTitle.ResetText();
            this.txtAuthorFirst.ResetText();
            this.txtAuthorLast.ResetText();
            this.cbxGenre.ResetText();
            this.txtPublisher.ResetText();
            this.dtpPublishDate.ResetText();
            this.txtLocation.ResetText();
            this.nudYear.ResetText();
            this.txtCompanyName.ResetText();
            this.tkbCondition.ResetText();
            this.nudQuantity.ResetText();
            this.nudPrice.ResetText();
            this.nudDiscountPrice.ResetText();
            this.dtpDiscountFrom.ResetText();
            this.dtpDiscountTo.ResetText();
            this.nudEdition.ResetText();
        }
        public void SetFormType(int itemType)
        {
            switch (itemType)
            {
                case 1:
                    SetPeriodicalControls(false);
                    SetMapControls(false);
                    SetBookControls(true);
                    break;
                case 2:
                    SetPeriodicalControls(false);
                    SetBookControls(false);
                    SetMapControls(true);
                    break;
                case 3:
                    SetBookControls(false);
                    SetMapControls(false);
                    SetPeriodicalControls(true);
                    break;
            }
        }
    }
}
