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
    public class UpdateEmployeeScreen : Screen
    {
        private TextBox txtFirstNameInput;
        private TextBox txtLastNameInput;
        private MaskedTextBox mtxtPhoneNumberInput;
        private ComboBox cbxRoleInput;
        private NumericUpDown nudEmployeeIdInput;
        private BindingList<DBEmployeePosition> employeePositions;
        private Button btnUpdate;

        public UpdateEmployeeScreen(Screen backScreen) : base("Update Employee", backScreen, 1)
        {

            //TODO: Consider whether this needs exception handling
            employeePositions = DBEmployeePosition.GetEmployeePositions();
            
            #region Init Screen
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            this.ColumnCount = 2;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.RowCount = 8;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ParentChanged += UpdateEmployeeScreen_ParentChanged;
            #endregion

            #region Controls
            Label lblEmployeeIdPrompt = new Label();
            lblEmployeeIdPrompt.Text = "Employee ID:";
            lblEmployeeIdPrompt.Dock = DockStyle.None;
            lblEmployeeIdPrompt.Anchor = AnchorStyles.Right;
            lblEmployeeIdPrompt.TextAlign = ContentAlignment.MiddleRight;
            lblEmployeeIdPrompt.AutoSize = true;
            this.Controls.Add(lblEmployeeIdPrompt, 0, 1);

            nudEmployeeIdInput = new NumericUpDown();
            nudEmployeeIdInput.Anchor = AnchorStyles.Left;
            nudEmployeeIdInput.Width = 150;
            nudEmployeeIdInput.ValueChanged += NudEmployeeIdInput_ValueChanged;
            this.Controls.Add(nudEmployeeIdInput, 1, 1);

            Label lblFirstNamePrompt = new Label();
            lblFirstNamePrompt.Text = "First Name:";
            lblFirstNamePrompt.Dock = DockStyle.None;
            lblFirstNamePrompt.Anchor = AnchorStyles.Right;
            lblFirstNamePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblFirstNamePrompt.AutoSize = true;
            this.Controls.Add(lblFirstNamePrompt, 0, 2);

            txtFirstNameInput = new TextBox();
            txtFirstNameInput.Anchor = AnchorStyles.Left;
            txtFirstNameInput.Width = 150;
            txtFirstNameInput.MaxLength = DBControlHelper.MaximumFirstNameLength;
            this.Controls.Add(txtFirstNameInput, 1, 2);

            Label lblLastNamePrompt = new Label();
            lblLastNamePrompt.Text = "Last Name:";
            lblLastNamePrompt.Dock = DockStyle.None;
            lblLastNamePrompt.Anchor = AnchorStyles.Right;
            lblLastNamePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblLastNamePrompt.AutoSize = true;
            this.Controls.Add(lblLastNamePrompt, 0, 3);

            txtLastNameInput = new TextBox();
            txtLastNameInput.Anchor = AnchorStyles.Left;
            txtLastNameInput.Width = 150;
            txtLastNameInput.MaxLength = DBControlHelper.MaximumLastNameLength;
            this.Controls.Add(txtLastNameInput, 1, 3);

            Label lblPhoneNumberPrompt = new Label();
            lblPhoneNumberPrompt.Text = "Phone Number:";
            lblPhoneNumberPrompt.Dock = DockStyle.None;
            lblPhoneNumberPrompt.Anchor = AnchorStyles.Right;
            lblPhoneNumberPrompt.TextAlign = ContentAlignment.MiddleRight;
            lblPhoneNumberPrompt.AutoSize = true;
            this.Controls.Add(lblPhoneNumberPrompt, 0, 4);

            mtxtPhoneNumberInput = new MaskedTextBox();
            mtxtPhoneNumberInput.Anchor = AnchorStyles.Left;
            mtxtPhoneNumberInput.Width = 150;
            mtxtPhoneNumberInput.Mask = "(000) 000-0000";
            mtxtPhoneNumberInput.TabIndex = 5;
            mtxtPhoneNumberInput.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            this.Controls.Add(mtxtPhoneNumberInput, 1, 4);

            Label lblRolePrompt = new Label();
            lblRolePrompt.Text = "Role:";
            lblRolePrompt.Dock = DockStyle.None;
            lblRolePrompt.Anchor = AnchorStyles.Right;
            lblRolePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblRolePrompt.AutoSize = true;
            this.Controls.Add(lblRolePrompt, 0, 5);

            cbxRoleInput = new ComboBox();
            cbxRoleInput.Anchor = AnchorStyles.Left;
            cbxRoleInput.Width = 150;
            cbxRoleInput.DataSource = employeePositions;
            cbxRoleInput.DisplayMember = "Name";
            cbxRoleInput.ValueMember = "ID";
            cbxRoleInput.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbxRoleInput, 1, 5);

            btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Dock = DockStyle.None;
            btnUpdate.AutoSize = true;
            btnUpdate.Anchor = AnchorStyles.Right;
            btnUpdate.BackColor = DefaultBackColor;
            btnUpdate.Click += BtnUpdate_Click;
            this.Controls.Add(btnUpdate, 0, 6);

            Button btnRemove = new Button();
            btnRemove.Text = "Remove from Employee List";
            btnRemove.Dock = DockStyle.None;
            btnRemove.AutoSize = true;
            btnRemove.Anchor = AnchorStyles.Left;
            btnRemove.BackColor = DefaultBackColor;
            btnRemove.Click += BtnRemove_Click;
            this.Controls.Add(btnRemove, 1, 6);
            #endregion

            this.SetFontSizes(this.Controls);
        }

        private void UpdateEmployeeScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnUpdate;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            try
            {
                if(DBEmployee.DeleteEmployee((int)this.nudEmployeeIdInput.Value))
                {
                    master.SetStatus("Employee " + this.txtFirstNameInput.Text + " " + this.txtLastNameInput.Text + " has been deleted.");
                    if(this.nudEmployeeIdInput.Value > this.nudEmployeeIdInput.Minimum)
                    {
                        this.nudEmployeeIdInput.Value--;
                    }
                }
            }
            catch(Exception ex)
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
                int employeeID = (int)this.nudEmployeeIdInput.Value;
                int roleID = (int)this.cbxRoleInput.SelectedValue;
                string firstName = this.txtFirstNameInput.Text.Trim();
                string lastName = this.txtLastNameInput.Text.Trim();
                string phoneNumber = this.mtxtPhoneNumberInput.Text.Trim();

                string status = "";

                if(String.IsNullOrEmpty(status = DBEmployee.Validate(firstName, lastName, phoneNumber)))
                {
                    if (DBEmployee.UpdateEmployee(employeeID, roleID, firstName, lastName, phoneNumber))
                    {
                        status = "Employee " + firstName + " " + lastName + " has been saved.";
                    }
                }

                master.SetStatus(status);
                
            }
            catch(Exception ex)
            {
                master.SetStatus("Error! Save failed: " + ex.Message);
            }
        }

        private void NudEmployeeIdInput_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.ShowEmployee();
            }
            catch(Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Error! " + ex.Message);
            }
        }
        private void ShowEmployee()
        {
            DBEmployee tempEmployee = DBEmployee.GetEmployee((int)this.nudEmployeeIdInput.Value);
            this.txtFirstNameInput.Text = tempEmployee.FirstName;
            this.txtLastNameInput.Text = tempEmployee.LastName;
            this.mtxtPhoneNumberInput.Text = tempEmployee.PhoneNumber;
            this.cbxRoleInput.SelectedValue = tempEmployee.PositionID;
        }
        public void SetEmployee(int id, int max)
        {
            this.nudEmployeeIdInput.Maximum = max;
            this.nudEmployeeIdInput.Value = id;
        }
    }
}
