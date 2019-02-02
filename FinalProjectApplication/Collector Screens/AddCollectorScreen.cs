using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class AddCollectorScreen : Screen
    {
        private TextBox txtFirstNameInput;
        private TextBox txtLastNameInput;
        private MaskedTextBox mtxtPhoneNumberInput;
        private ComboBox cbxTypeInput;
        private Button btnAdd;
        TableLayoutPanel tlpBookTagsSelection;
        TableLayoutPanel tlpMapTagsSelection;
        TableLayoutPanel tlpPeriodicalTagsSelection;
        BindingList<DBTag> tagList = DBTag.GetTags();

        public AddCollectorScreen(Screen backScreen) : base("Add Collector", backScreen, 1, 2, 3)
        {
            #region Init Screen
            this.Dock = DockStyle.Fill;
            this.ColumnCount = 1;
            this.RowCount = 3;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ParentChanged += AddCollectorScreen_ParentChanged;
            #endregion

            #region Collector Panel
            TableLayoutPanel tlpCollector = new TableLayoutPanel();
            tlpCollector.Dock = DockStyle.Fill;
            tlpCollector.BackColor = Color.White;
            tlpCollector.Margin = new Padding(0, 10, 0, 20);
            tlpCollector.ColumnCount = 2;
            tlpCollector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            tlpCollector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            tlpCollector.RowCount = 8;
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));

            Label lblFirstNamePrompt = new Label();
            lblFirstNamePrompt.Text = "First Name:";
            lblFirstNamePrompt.Dock = DockStyle.None;
            lblFirstNamePrompt.Anchor = AnchorStyles.Right;
            lblFirstNamePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblFirstNamePrompt.AutoSize = true;
            //lblFirstNamePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(lblFirstNamePrompt, 0, 1);

            txtFirstNameInput = new TextBox();
            txtFirstNameInput.Anchor = AnchorStyles.Left;
            //txtFirstNameInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFirstNameInput.Width = 150;
            txtFirstNameInput.MaxLength = DBControlHelper.MaximumFirstNameLength;
            tlpCollector.Controls.Add(txtFirstNameInput, 1, 1);

            Label lblLastNamePrompt = new Label();
            lblLastNamePrompt.Text = "Last Name:";
            lblLastNamePrompt.Dock = DockStyle.None;
            lblLastNamePrompt.Anchor = AnchorStyles.Right;
            lblLastNamePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblLastNamePrompt.AutoSize = true;
            //lblLastNamePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(lblLastNamePrompt, 0, 2);

            txtLastNameInput = new TextBox();
            txtLastNameInput.Anchor = AnchorStyles.Left;
            //txtLastNameInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtLastNameInput.Width = 150;
            txtLastNameInput.MaxLength = DBControlHelper.MaximumLastNameLength;
            tlpCollector.Controls.Add(txtLastNameInput, 1, 2);

            Label lblPhoneNumberPrompt = new Label();
            lblPhoneNumberPrompt.Text = "Phone Number:";
            lblPhoneNumberPrompt.Dock = DockStyle.None;
            lblPhoneNumberPrompt.Anchor = AnchorStyles.Right;
            lblPhoneNumberPrompt.TextAlign = ContentAlignment.MiddleRight;
            lblPhoneNumberPrompt.AutoSize = true;
            //lblPhoneNumberPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(lblPhoneNumberPrompt, 0, 3);

            mtxtPhoneNumberInput = new MaskedTextBox();
            mtxtPhoneNumberInput.Anchor = AnchorStyles.Left;
            mtxtPhoneNumberInput.Width = 150;
            mtxtPhoneNumberInput.Mask = "(000) 000-0000";
            mtxtPhoneNumberInput.TabIndex = 5;
            mtxtPhoneNumberInput.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //mtxtPhoneNumberInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(mtxtPhoneNumberInput, 1, 3);

            Label lblTypePrompt = new Label();
            lblTypePrompt.Text = "Type:";
            lblTypePrompt.Dock = DockStyle.None;
            lblTypePrompt.Anchor = AnchorStyles.Right;
            lblTypePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblTypePrompt.AutoSize = true;
            //lblTypePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(lblTypePrompt, 0, 4);

            cbxTypeInput = new ComboBox();
            cbxTypeInput.DataSource = DBCollectorType.GetCollectorTypes();
            cbxTypeInput.DisplayMember = "Name";
            cbxTypeInput.ValueMember = "ID";
            cbxTypeInput.Anchor = AnchorStyles.Left;
            //cbxTypeInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cbxTypeInput.Width = 150;
            cbxTypeInput.DropDownStyle = ComboBoxStyle.DropDownList;
            tlpCollector.Controls.Add(cbxTypeInput, 1, 4);
            #endregion

            #region Interests Panel
            //Holds the "interests" title, and all the different types of tag selections
            TableLayoutPanel tlpInterests = new TableLayoutPanel();
            tlpInterests.Dock = DockStyle.Fill;
            //tlpInterests.BackColor = Color.White;
            tlpInterests.BackColor = Screen.PrimaryColor;
            tlpInterests.ColumnCount = 3;
            tlpInterests.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            tlpInterests.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            tlpInterests.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            tlpInterests.RowCount = 2;
            tlpInterests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpInterests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpInterests.Margin = new Padding(0, 0, 0, 10);

            //The main title
            Label lblInterestsTitle = new Label();
            lblInterestsTitle.Text = "Interests";
            //lblInterestsTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblInterestsTitle.Margin = new Padding(0, 0, 0, 25);
            lblInterestsTitle.Dock = DockStyle.None;
            lblInterestsTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblInterestsTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            
            #region Book Tags Panel
            //The main panel holding both the tags selection and the title
            TableLayoutPanel tlpBookTags = new TableLayoutPanel();
            tlpBookTags.Dock = DockStyle.Fill;
            tlpBookTags.BackColor = Color.White;
            tlpBookTags.ColumnCount = 1;
            tlpBookTags.RowCount = 2;
            tlpBookTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpBookTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            //The title above the tag selection
            Label lblBookTagsTitle = new Label();
            lblBookTagsTitle.Text = "Books";
            //tagsTypeTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblBookTagsTitle.Dock = DockStyle.Fill;
            lblBookTagsTitle.Anchor = AnchorStyles.Left & AnchorStyles.Right;

            //The panel holding the tags to select from
            tlpBookTagsSelection = new TableLayoutPanel();
            tlpBookTagsSelection.Dock = DockStyle.Fill;
            tlpBookTagsSelection.ColumnCount = 2;
            tlpBookTagsSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpBookTagsSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpBookTagsSelection.BackColor = Color.White;
            tlpBookTagsSelection.Margin = new Padding(10, 10, 10, 10);
            tlpBookTagsSelection.AutoScroll = true;

            //Populate the tags selection with test data
            DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpBookTagsSelection, tagList, "Description", "ID");

            //Add the controls to the parent panel
            tlpBookTags.Controls.Add(lblBookTagsTitle, 0, 0);
            tlpBookTags.Controls.Add(tlpBookTagsSelection, 0, 1);
            #endregion

            #region Periodicals Tags Panel
            //The main panel holding both the tags selection and the title
            TableLayoutPanel tlpPeriodicalTags = new TableLayoutPanel();
            tlpPeriodicalTags.Dock = DockStyle.Fill;
            tlpPeriodicalTags.BackColor = Color.White;
            tlpPeriodicalTags.ColumnCount = 1;
            tlpPeriodicalTags.RowCount = 2;
            tlpPeriodicalTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpPeriodicalTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            //The title above the tag selection
            Label lblPeriodicalTagsTitle = new Label();
            lblPeriodicalTagsTitle.Text = "Periodicals";
            //tagsPeriodicalTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPeriodicalTagsTitle.Dock = DockStyle.Fill;
            lblPeriodicalTagsTitle.Anchor = AnchorStyles.Left & AnchorStyles.Right;

            //The panel holding the tags to select from
            tlpPeriodicalTagsSelection = new TableLayoutPanel();
            tlpPeriodicalTagsSelection.Dock = DockStyle.Fill;
            tlpPeriodicalTagsSelection.ColumnCount = 2;
            tlpPeriodicalTagsSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpPeriodicalTagsSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpPeriodicalTagsSelection.BackColor = Color.White;
            tlpPeriodicalTagsSelection.Margin = new Padding(10, 10, 10, 10);
            tlpPeriodicalTagsSelection.AutoScroll = true;

            //Populate the tags selection with test data
            DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpPeriodicalTagsSelection, tagList, "Description", "ID");

            //Add the controls to the parent panel
            tlpPeriodicalTags.Controls.Add(lblPeriodicalTagsTitle, 0, 0);
            tlpPeriodicalTags.Controls.Add(tlpPeriodicalTagsSelection, 0, 1);
            #endregion

            #region Maps Tags Panel
            //The main panel holding both the tags selection and the title
            TableLayoutPanel tlpMapTagsPanel = new TableLayoutPanel();
            tlpMapTagsPanel.Dock = DockStyle.Fill;
            tlpMapTagsPanel.BackColor = Color.White;
            tlpMapTagsPanel.ColumnCount = 1;
            tlpMapTagsPanel.RowCount = 2;
            tlpMapTagsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpMapTagsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            //The title above the tag selection
            Label lblMapTagsTitle = new Label();
            lblMapTagsTitle.Text = "Maps";
            //tagsMapTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblMapTagsTitle.Dock = DockStyle.Fill;
            lblMapTagsTitle.Anchor = AnchorStyles.Left & AnchorStyles.Right;

            //The panel holding the tags to select from
            tlpMapTagsSelection = new TableLayoutPanel();
            tlpMapTagsSelection.Dock = DockStyle.Fill;
            tlpMapTagsSelection.ColumnCount = 2;
            tlpMapTagsSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpMapTagsSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpMapTagsSelection.BackColor = Color.White;
            tlpMapTagsSelection.Margin = new Padding(10, 10, 10, 10);
            tlpMapTagsSelection.AutoScroll = true;

            //Populate the tags selection with test data
            DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpMapTagsSelection, tagList, "Description", "ID");

            //Add the controls to the parent panel
            tlpMapTagsPanel.Controls.Add(lblMapTagsTitle, 0, 0);
            tlpMapTagsPanel.Controls.Add(tlpMapTagsSelection, 0, 1);
            #endregion

            tlpInterests.Controls.Add(lblInterestsTitle, 1, 0);
            //tlpInterests.SetColumnSpan(lblInterestsTitle, 3);
            tlpInterests.Controls.Add(tlpBookTags, 0, 1);
            tlpInterests.Controls.Add(tlpPeriodicalTags, 1, 1);
            tlpInterests.Controls.Add(tlpMapTagsPanel, 2, 1);
            #endregion

            #region Bottom Buttons Panel
            TableLayoutPanel tlpButtons = new TableLayoutPanel();
            tlpButtons.Dock = DockStyle.Fill;
            tlpButtons.ColumnCount = 1;
            tlpButtons.RowCount = 1;
            tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));

            btnAdd = new Button();
            btnAdd.Text = "Add";
            btnAdd.Dock = DockStyle.None;
            //btnAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnAdd.Size = new Size(250, 30);
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.BackColor = DefaultBackColor;
            btnAdd.Click += BtnAdd_Click;

            tlpButtons.Controls.Add(btnAdd, 0, 0);
            #endregion

            this.Controls.Add(tlpCollector, 0, 0);
            this.Controls.Add(tlpInterests, 0, 1);
            this.Controls.Add(tlpButtons, 0, 2);

            this.SetFontSizes(this.Controls);
        }

        private void AddCollectorScreen_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnAdd;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);

                try
                {
                    tagList = DBTag.GetTags();
                    DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpBookTagsSelection, tagList, "Description", "ID");
                    DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpMapTagsSelection, tagList, "Description", "ID");
                    DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpPeriodicalTagsSelection, tagList, "Description", "ID");
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
                string firstName = this.txtFirstNameInput.Text.Trim();
                string lastName = this.txtLastNameInput.Text.Trim();
                string phoneNumber = this.mtxtPhoneNumberInput.Text.Trim();
                int collectorTypeID = (int)this.cbxTypeInput.SelectedValue;

                string status = "";

                if(String.IsNullOrEmpty(status = DBCollector.Validate(firstName, lastName, phoneNumber)))
                {
                    object insertedID = DBCollector.InsertCollector(collectorTypeID, firstName, lastName, phoneNumber);

                    if (insertedID != null)
                    {
                        status = "Collector " + firstName + " " + lastName + " has been added." + Environment.NewLine;

                        List<int> bookTagValues = DBControlHelper.GetValuesFromCheckedControls(this.tlpBookTagsSelection);
                        if (bookTagValues.Count > 0 && DBCollector.InsertInterests((int)insertedID, 1, bookTagValues))
                        {
                            status += "Book interests added." + Environment.NewLine;
                        }
                        List<int> mapTagValues = DBControlHelper.GetValuesFromCheckedControls(this.tlpMapTagsSelection);
                        if (mapTagValues.Count > 0 && DBCollector.InsertInterests((int)insertedID, 2, mapTagValues))
                        {
                            status += "Map interests added." + Environment.NewLine;
                        }
                        List<int> periodicalTagValues = DBControlHelper.GetValuesFromCheckedControls(this.tlpPeriodicalTagsSelection);
                        if (periodicalTagValues.Count > 0 && DBCollector.InsertInterests((int)insertedID, 3, periodicalTagValues))
                        {
                            status += "Periodical interests added." + Environment.NewLine;
                        }
                        
                    }
                }

                master.SetStatus(status);

            }
            catch (Exception ex)
            {
                master.SetStatus("Error! Add failed: " + ex.Message);
            }
        }
    }
}
