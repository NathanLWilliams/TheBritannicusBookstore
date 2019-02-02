using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class AddEmployeeScreen : Screen
    {
        private TextBox txtFirstNameInput;
        private TextBox txtLastNameInput;
        private MaskedTextBox mtxtPhoneNumberInput;
        private ComboBox cbxRoleInput;
        private Button btnAdd;

        public AddEmployeeScreen(Screen backScreen) : base("Add Employee", backScreen, 1)
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            this.ColumnCount = 2;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.RowCount = 7;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ParentChanged += AddEmployeeScreen_ParentChanged;

            Label lblFirstNamePrompt = new Label();
            lblFirstNamePrompt.Text = "First Name:";
            lblFirstNamePrompt.Dock = DockStyle.None;
            lblFirstNamePrompt.Anchor = AnchorStyles.Right;
            lblFirstNamePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblFirstNamePrompt.AutoSize = true;
            this.Controls.Add(lblFirstNamePrompt, 0, 1);

            txtFirstNameInput = new TextBox();
            txtFirstNameInput.Anchor = AnchorStyles.Left;
            txtFirstNameInput.Width = 150;
            txtFirstNameInput.MaxLength = DBControlHelper.MaximumFirstNameLength;
            this.Controls.Add(txtFirstNameInput, 1, 1);

            Label lblLastNamePrompt = new Label();
            lblLastNamePrompt.Text = "Last Name:";
            lblLastNamePrompt.Dock = DockStyle.None;
            lblLastNamePrompt.Anchor = AnchorStyles.Right;
            lblLastNamePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblLastNamePrompt.AutoSize = true;
            this.Controls.Add(lblLastNamePrompt, 0, 2);

            txtLastNameInput = new TextBox();
            txtLastNameInput.Anchor = AnchorStyles.Left;
            txtLastNameInput.Width = 150;
            txtLastNameInput.MaxLength = DBControlHelper.MaximumLastNameLength;
            this.Controls.Add(txtLastNameInput, 1, 2);

            Label lblPhoneNumberPrompt = new Label();
            lblPhoneNumberPrompt.Text = "Phone Number:";
            lblPhoneNumberPrompt.Dock = DockStyle.None;
            lblPhoneNumberPrompt.Anchor = AnchorStyles.Right;
            lblPhoneNumberPrompt.TextAlign = ContentAlignment.MiddleRight;
            lblPhoneNumberPrompt.AutoSize = true;
            this.Controls.Add(lblPhoneNumberPrompt, 0, 3);

            mtxtPhoneNumberInput = new MaskedTextBox();
            mtxtPhoneNumberInput.Anchor = AnchorStyles.Left;
            mtxtPhoneNumberInput.Width = 150;
            mtxtPhoneNumberInput.Mask = "(000) 000-0000";
            mtxtPhoneNumberInput.TabIndex = 5;
            mtxtPhoneNumberInput.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            this.Controls.Add(mtxtPhoneNumberInput, 1, 3);

            Label lblRolePrompt = new Label();
            lblRolePrompt.Text = "Role:";
            lblRolePrompt.Dock = DockStyle.None;
            lblRolePrompt.Anchor = AnchorStyles.Right;
            lblRolePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblRolePrompt.AutoSize = true;
            this.Controls.Add(lblRolePrompt, 0, 4);

            cbxRoleInput = new ComboBox();
            cbxRoleInput.Anchor = AnchorStyles.Left;
            cbxRoleInput.Width = 150;
            cbxRoleInput.DataSource = DBEmployeePosition.GetEmployeePositions();
            cbxRoleInput.DisplayMember = "Name";
            cbxRoleInput.ValueMember = "ID";
            cbxRoleInput.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbxRoleInput, 1, 4);

            btnAdd = new Button();
            btnAdd.Text = "Add";
            btnAdd.Dock = DockStyle.None;
            btnAdd.AutoSize = true;
            btnAdd.Anchor = AnchorStyles.Left;
            btnAdd.BackColor = DefaultBackColor;
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd, 1, 5);

            this.SetFontSizes(this.Controls);
        }

        private void AddEmployeeScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnAdd;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            try
            {
                //Input data gathered here to improve readability and centralize any processing
                //that needs to be done before insertion
                int roleID = (int)this.cbxRoleInput.SelectedValue;
                string firstName = this.txtFirstNameInput.Text.Trim();
                string lastName = this.txtLastNameInput.Text.Trim();
                string phoneNumber = this.mtxtPhoneNumberInput.Text.Trim();

                string status = "";

                if(String.IsNullOrEmpty(status = DBEmployee.Validate(firstName, lastName, phoneNumber)))
                {
                    if (DBEmployee.InsertEmployee(roleID, firstName, lastName, phoneNumber))
                    {
                        status = "Employee " + firstName + " " + lastName + " has been added.";
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
