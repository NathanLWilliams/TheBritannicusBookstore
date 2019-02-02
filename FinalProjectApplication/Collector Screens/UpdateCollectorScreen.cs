using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class UpdateCollectorScreen : Screen
    {
        private NumericUpDown nudCollectorId;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private MaskedTextBox mtxtPhoneNumber;
        private ComboBox cbxType;
        private TableLayoutPanel tlpTagsBookSelection;
        private TableLayoutPanel tlpTagsPeriodicalSelection;
        private TableLayoutPanel tlpTagsMapSelection;
        private Button btnUpdate;

        public UpdateCollectorScreen(Screen backScreen) : base("Update Collector", backScreen, 1, 2, 3)
        {
            #region Init Screen
            this.Dock = DockStyle.Fill;
            this.ColumnCount = 1;
            this.RowCount = 3;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ParentChanged += UpdateCollectorScreen_ParentChanged;
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
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpCollector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));

            Label lblCollectorIdPrompt = new Label();
            lblCollectorIdPrompt.Text = "Collector ID:";
            lblCollectorIdPrompt.Dock = DockStyle.None;
            lblCollectorIdPrompt.Anchor = AnchorStyles.Right;
            lblCollectorIdPrompt.TextAlign = ContentAlignment.MiddleRight;
            lblCollectorIdPrompt.AutoSize = true;
            //lblCollectorIdPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(lblCollectorIdPrompt, 0, 1);

            nudCollectorId = new NumericUpDown();
            nudCollectorId.Anchor = AnchorStyles.Left;
            //nudCollectorIdInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nudCollectorId.Width = 150;
            nudCollectorId.ValueChanged += NudCollectorIdInput_ValueChanged;
            tlpCollector.Controls.Add(nudCollectorId, 1, 1);

            Label lblFirstNamePrompt = new Label();
            lblFirstNamePrompt.Text = "First Name:";
            lblFirstNamePrompt.Dock = DockStyle.None;
            lblFirstNamePrompt.Anchor = AnchorStyles.Right;
            lblFirstNamePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblFirstNamePrompt.AutoSize = true;
            //lblFirstNamePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(lblFirstNamePrompt, 0, 2);

            txtFirstName = new TextBox();
            txtFirstName.Anchor = AnchorStyles.Left;
            //txtFirstNameInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFirstName.Width = 150;
            txtFirstName.MaxLength = DBControlHelper.MaximumFirstNameLength;
            tlpCollector.Controls.Add(txtFirstName, 1, 2);

            Label lblLastNamePrompt = new Label();
            lblLastNamePrompt.Text = "Last Name:";
            lblLastNamePrompt.Dock = DockStyle.None;
            lblLastNamePrompt.Anchor = AnchorStyles.Right;
            lblLastNamePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblLastNamePrompt.AutoSize = true;
            //lblLastNamePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(lblLastNamePrompt, 0, 3);

            txtLastName = new TextBox();
            txtLastName.Anchor = AnchorStyles.Left;
            //txtLastNameInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtLastName.Width = 150;
            txtLastName.MaxLength = DBControlHelper.MaximumLastNameLength;
            tlpCollector.Controls.Add(txtLastName, 1, 3);

            Label lblPhoneNumberPrompt = new Label();
            lblPhoneNumberPrompt.Text = "Phone Number:";
            lblPhoneNumberPrompt.Dock = DockStyle.None;
            lblPhoneNumberPrompt.Anchor = AnchorStyles.Right;
            lblPhoneNumberPrompt.TextAlign = ContentAlignment.MiddleRight;
            lblPhoneNumberPrompt.AutoSize = true;
            //lblPhoneNumberPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(lblPhoneNumberPrompt, 0, 4);

            mtxtPhoneNumber = new MaskedTextBox();
            mtxtPhoneNumber.Anchor = AnchorStyles.Left;
            mtxtPhoneNumber.Width = 150;
            mtxtPhoneNumber.Mask = "(000) 000-0000";
            mtxtPhoneNumber.TabIndex = 5;
            mtxtPhoneNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //mtxtPhoneNumberInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(mtxtPhoneNumber, 1, 4);

            Label lblTypePrompt = new Label();
            lblTypePrompt.Text = "Type:";
            lblTypePrompt.Dock = DockStyle.None;
            lblTypePrompt.Anchor = AnchorStyles.Right;
            lblTypePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblTypePrompt.AutoSize = true;
            //lblTypePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlpCollector.Controls.Add(lblTypePrompt, 0, 5);

            cbxType = new ComboBox();
            cbxType.Anchor = AnchorStyles.Left;
            //cbxTypeInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cbxType.Width = 150;
            cbxType.DataSource = DBCollectorType.GetCollectorTypes();
            cbxType.DisplayMember = "Name";
            cbxType.ValueMember = "ID";
            cbxType.DropDownStyle = ComboBoxStyle.DropDownList;
            tlpCollector.Controls.Add(cbxType, 1, 5);
            #endregion

            #region Interests Panel
            //Holds the "interests" title, and all the different types of tag selections
            TableLayoutPanel tlpInterests = new TableLayoutPanel();
            tlpInterests.Dock = DockStyle.Fill;
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
            TableLayoutPanel tlpTagBookPanel = new TableLayoutPanel();
            tlpTagBookPanel.Dock = DockStyle.Fill;
            tlpTagBookPanel.BackColor = Color.White;
            tlpTagBookPanel.ColumnCount = 1;
            tlpTagBookPanel.RowCount = 2;
            tlpTagBookPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpTagBookPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            //The title above the tag selection
            Label lblTagsTypeTitle = new Label();
            lblTagsTypeTitle.Text = "Books";
            //lblTagsTypeTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTagsTypeTitle.Dock = DockStyle.Fill;
            lblTagsTypeTitle.Anchor = AnchorStyles.Left & AnchorStyles.Right;

            //The panel holding the tags to select from
            tlpTagsBookSelection = new TableLayoutPanel();
            tlpTagsBookSelection.Dock = DockStyle.Fill;
            tlpTagsBookSelection.ColumnCount = 2;
            tlpTagsBookSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpTagsBookSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //tagsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            //tagsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            //tagsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            tlpTagsBookSelection.BackColor = Color.White;
            tlpTagsBookSelection.Margin = new Padding(10, 10, 10, 10);
            tlpTagsBookSelection.AutoScroll = true;
            //DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpTagsBookSelection, DBTag.getTags(), "Description", "ID", DBCollector.getInterestsOfType((int)nudCollectorId.Value, 1));

            //Add the controls to the parent panel
            tlpTagBookPanel.Controls.Add(lblTagsTypeTitle, 0, 0);
            tlpTagBookPanel.Controls.Add(tlpTagsBookSelection, 0, 1);
            #endregion

            #region Periodicals Tags Panel
            //The main panel holding both the tags selection and the title
            TableLayoutPanel tlpTagPeriodicalPanel = new TableLayoutPanel();
            tlpTagPeriodicalPanel.Dock = DockStyle.Fill;
            tlpTagPeriodicalPanel.BackColor = Color.White;
            tlpTagPeriodicalPanel.ColumnCount = 1;
            tlpTagPeriodicalPanel.RowCount = 2;
            tlpTagPeriodicalPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpTagPeriodicalPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            //The title above the tag selection
            Label lblTagsPeriodicalTitle = new Label();
            lblTagsPeriodicalTitle.Text = "Periodicals";
            //lblTagsPeriodicalTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTagsPeriodicalTitle.Dock = DockStyle.Fill;
            lblTagsPeriodicalTitle.Anchor = AnchorStyles.Left & AnchorStyles.Right;

            //The panel holding the tags to select from
            tlpTagsPeriodicalSelection = new TableLayoutPanel();
            tlpTagsPeriodicalSelection.Dock = DockStyle.Fill;
            tlpTagsPeriodicalSelection.ColumnCount = 2;
            tlpTagsPeriodicalSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpTagsPeriodicalSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //tagsPeriodicalSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            //tagsPeriodicalSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            //tagsPeriodicalSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            tlpTagsPeriodicalSelection.BackColor = Color.White;
            tlpTagsPeriodicalSelection.Margin = new Padding(10, 10, 10, 10);
            tlpTagsPeriodicalSelection.AutoScroll = true;

            //DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpTagsPeriodicalSelection, DBTag.getTags(), "Description", "ID", DBCollector.getInterestsOfType((int)nudCollectorId.Value, 3));

            //Add the controls to the parent panel
            tlpTagPeriodicalPanel.Controls.Add(lblTagsPeriodicalTitle, 0, 0);
            tlpTagPeriodicalPanel.Controls.Add(tlpTagsPeriodicalSelection, 0, 1);
            #endregion

            #region Maps Tags Panel
            //The main panel holding both the tags selection and the title
            TableLayoutPanel tlpTagMapPanel = new TableLayoutPanel();
            tlpTagMapPanel.Dock = DockStyle.Fill;
            tlpTagMapPanel.BackColor = Color.White;
            tlpTagMapPanel.ColumnCount = 1;
            tlpTagMapPanel.RowCount = 2;
            tlpTagMapPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpTagMapPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            //The title above the tag selection
            Label lblTagsMapTitle = new Label();
            lblTagsMapTitle.Text = "Maps";
            //lblTagsMapTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTagsMapTitle.Dock = DockStyle.Fill;
            lblTagsMapTitle.Anchor = AnchorStyles.Left & AnchorStyles.Right;

            //The panel holding the tags to select from
            tlpTagsMapSelection = new TableLayoutPanel();
            tlpTagsMapSelection.Dock = DockStyle.Fill;
            tlpTagsMapSelection.ColumnCount = 2;
            tlpTagsMapSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpTagsMapSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //tagsMapSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            //tagsMapSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            //tagsMapSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            tlpTagsMapSelection.BackColor = Color.White;
            tlpTagsMapSelection.Margin = new Padding(10, 10, 10, 10);
            tlpTagsMapSelection.AutoScroll = true;

            //DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpTagsMapSelection, DBTag.getTags(), "Description", "ID", DBCollector.getInterestsOfType((int)nudCollectorId.Value, 2));

            //Add the controls to the parent panel
            tlpTagMapPanel.Controls.Add(lblTagsMapTitle, 0, 0);
            tlpTagMapPanel.Controls.Add(tlpTagsMapSelection, 0, 1);
            #endregion

            tlpInterests.Controls.Add(lblInterestsTitle, 1, 0);
            //tlpInterests.SetColumnSpan(lblInterestsTitle, 3);
            tlpInterests.Controls.Add(tlpTagBookPanel, 0, 1);
            tlpInterests.Controls.Add(tlpTagPeriodicalPanel, 1, 1);
            tlpInterests.Controls.Add(tlpTagMapPanel, 2, 1);
            #endregion

            #region Bottom Buttons Panel
            TableLayoutPanel buttonPanel = new TableLayoutPanel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.ColumnCount = 2;
            buttonPanel.RowCount = 1;
            buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Dock = DockStyle.None;
            //btnUpdate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnUpdate.Size = new Size(250, 30);
            btnUpdate.Anchor = AnchorStyles.Right;
            btnUpdate.BackColor = DefaultBackColor;
            btnUpdate.Click += BtnUpdate_Click;

            Button btnRemove = new Button();
            btnRemove.Text = "Remove from Collector List";
            btnRemove.Dock = DockStyle.None;
            //btnRemove.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnRemove.Size = new Size(250, 30);
            btnRemove.Anchor = AnchorStyles.Left;
            btnRemove.BackColor = DefaultBackColor;
            btnRemove.Click += BtnRemove_Click;

            buttonPanel.Controls.Add(btnUpdate, 0, 0);
            buttonPanel.Controls.Add(btnRemove, 1, 0);
            #endregion

            this.Controls.Add(tlpCollector, 0, 0);
            this.Controls.Add(tlpInterests, 0, 1);
            this.Controls.Add(buttonPanel, 0, 2);

            this.SetFontSizes(this.Controls);
        }

        private void UpdateCollectorScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnUpdate;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);

                try
                {
                    DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpTagsBookSelection, DBTag.GetTags(), "Description", "ID", DBCollector.GetInterestsOfType((int)nudCollectorId.Value, 1));
                    DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpTagsMapSelection, DBTag.GetTags(), "Description", "ID", DBCollector.GetInterestsOfType((int)nudCollectorId.Value, 2));
                    DBControlHelper.PopulateWithControls<DBTag, CheckBox>(tlpTagsPeriodicalSelection, DBTag.GetTags(), "Description", "ID", DBCollector.GetInterestsOfType((int)nudCollectorId.Value, 3));
                }
                catch(Exception ex)
                {
                    master.SetStatus("Error! Failed to load tags: " + ex.Message);
                }
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            try
            {
                if (DBCollector.DeleteCollector((int)this.nudCollectorId.Value))
                {
                    master.SetStatus("Collector " + this.txtFirstName.Text + " " + this.txtLastName.Text + " has been deleted.");
                    if (this.nudCollectorId.Value > this.nudCollectorId.Minimum)
                    {
                        this.nudCollectorId.Value--;
                    }
                }
            }
            catch (Exception ex)
            {
                master.SetStatus("Error! Deletion failed: " + ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            try
            {
                //Input data gathered here to improve readability and centralize any processing
                //that needs to be done before insertion
                int collectorID = (int)nudCollectorId.Value;
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                int collectorTypeID = (int)cbxType.SelectedValue;
                string phoneNumber = mtxtPhoneNumber.Text.Trim();

                string status = "";

                if(String.IsNullOrEmpty(status = DBCollector.Validate(firstName, lastName, phoneNumber)))
                {
                    if (DBCollector.UpdateCollector(collectorID, collectorTypeID, firstName, lastName, phoneNumber))
                    {
                        status = "Collector " + firstName + " " + lastName + " has been saved." + Environment.NewLine;
                    }
                }

                if(DBCollector.UpdateInterests(collectorID, 1, DBControlHelper.GetValuesFromCheckedControls(this.tlpTagsBookSelection)))
                {
                    status += "Book interests have been updated." + Environment.NewLine;
                }
                if(DBCollector.UpdateInterests(collectorID, 2, DBControlHelper.GetValuesFromCheckedControls(this.tlpTagsMapSelection)))
                {
                    status += "Map interests have been updated." + Environment.NewLine;
                }
                if(DBCollector.UpdateInterests(collectorID, 3, DBControlHelper.GetValuesFromCheckedControls(this.tlpTagsPeriodicalSelection)))
                {
                    status += "Periodical interests have been updated." + Environment.NewLine;
                }

                master.SetStatus(status);
            }
            catch (Exception ex)
            {
                master.SetStatus("Error! Save failed: " + ex.Message);
            }
        }

        private void NudCollectorIdInput_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.ShowCollector();
            }
            catch (Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Error! " + ex.Message);
            }
        }
        private void ShowCollector()
        {
            int collectorID = (int)this.nudCollectorId.Value;
            DBCollector tempCollector = DBCollector.GetCollectorById(collectorID);
            this.txtFirstName.Text = tempCollector.FirstName;
            this.txtLastName.Text = tempCollector.LastName;
            this.mtxtPhoneNumber.Text = tempCollector.PhoneNumber;
            this.cbxType.SelectedValue = tempCollector.CollectorTypeID;

            //Check the checkboxes of tags which this collector is interested in
            DBControlHelper.CheckControlsWithValues(this.tlpTagsBookSelection, DBCollector.GetInterestsOfType(collectorID, 1));
            DBControlHelper.CheckControlsWithValues(this.tlpTagsMapSelection, DBCollector.GetInterestsOfType(collectorID, 2));
            DBControlHelper.CheckControlsWithValues(this.tlpTagsPeriodicalSelection, DBCollector.GetInterestsOfType(collectorID, 3));
        }
        public void SetCollector(int id, int max)
        {
            this.nudCollectorId.Maximum = max;
            this.nudCollectorId.Value = id;
        }
    }
}
