using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class RegisterScreen : Screen
    {
        private TextBox txtUsernameInput;
        private TextBox txtPasswordInput;
        private TextBox txtConfirmPasswordInput;
        private ComboBox cbxEmployee;
        private Button btnRegister;

        public RegisterScreen(Screen backScreen) : base("Register", backScreen, 1)
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
            this.ParentChanged += RegisterScreen_ParentChanged;

            Label lblUsernamePrompt = new Label();
            lblUsernamePrompt.Text = "Username:";
            lblUsernamePrompt.Dock = DockStyle.None;
            lblUsernamePrompt.Anchor = AnchorStyles.Right;
            lblUsernamePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblUsernamePrompt.AutoSize = true;
            //lblUsernamePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controls.Add(lblUsernamePrompt, 0, 1);

            txtUsernameInput = new TextBox();
            txtUsernameInput.Anchor = AnchorStyles.Left;
            //txtUsernameInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtUsernameInput.Width = 150;
            txtUsernameInput.MaxLength = DBControlHelper.MaximumUsernameLength;
            this.Controls.Add(txtUsernameInput, 1, 1);

            Label lblPasswordPrompt = new Label();
            lblPasswordPrompt.Text = "Password:";
            lblPasswordPrompt.Dock = DockStyle.None;
            lblPasswordPrompt.Anchor = AnchorStyles.Right;
            lblPasswordPrompt.TextAlign = ContentAlignment.MiddleRight;
            lblPasswordPrompt.AutoSize = true;
            //lblPasswordPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controls.Add(lblPasswordPrompt, 0, 2);

            txtPasswordInput = new TextBox();
            txtPasswordInput.Anchor = AnchorStyles.Left;
            //txtPasswordInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPasswordInput.Width = 150;
            txtPasswordInput.PasswordChar = '*';
            txtPasswordInput.MaxLength = DBControlHelper.MaximumPasswordLength;
            this.Controls.Add(txtPasswordInput, 1, 2);

            Label lblConfirmPasswordPrompt = new Label();
            lblConfirmPasswordPrompt.Text = "Confirm Password:";
            lblConfirmPasswordPrompt.Dock = DockStyle.None;
            lblConfirmPasswordPrompt.Anchor = AnchorStyles.Right;
            lblConfirmPasswordPrompt.TextAlign = ContentAlignment.MiddleRight;
            lblConfirmPasswordPrompt.AutoSize = true;
            //lblConfirmPasswordPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controls.Add(lblConfirmPasswordPrompt, 0, 3);

            txtConfirmPasswordInput = new TextBox();
            txtConfirmPasswordInput.Anchor = AnchorStyles.Left;
            //txtConfirmPasswordInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtConfirmPasswordInput.Width = 150;
            txtConfirmPasswordInput.PasswordChar = '*';
            txtConfirmPasswordInput.MaxLength = DBControlHelper.MaximumPasswordLength;
            this.Controls.Add(txtConfirmPasswordInput, 1, 3);

            Label lblEmployeePrompt = new Label();
            lblEmployeePrompt.Text = "Employee:";
            lblEmployeePrompt.Dock = DockStyle.None;
            lblEmployeePrompt.Anchor = AnchorStyles.Right;
            lblEmployeePrompt.TextAlign = ContentAlignment.MiddleRight;
            lblEmployeePrompt.AutoSize = true;
            //lblEmployeePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controls.Add(lblEmployeePrompt, 0, 4);

            cbxEmployee = new ComboBox();
            cbxEmployee.DataSource = DBEmployee.GetEmployees();
            cbxEmployee.ValueMember = "EmployeeID";
            cbxEmployee.DisplayMember = "ComboBoxDisplay";
            cbxEmployee.Anchor = AnchorStyles.Left;
            //cbxEmployee.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cbxEmployee.Width = 150;
            this.Controls.Add(cbxEmployee, 1, 4);

            btnRegister = new Button();
            btnRegister.Text = "Register";
            btnRegister.Dock = DockStyle.None;
            //btnRegister.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnRegister.AutoSize = true;
            btnRegister.Anchor = AnchorStyles.Left;
            btnRegister.BackColor = DefaultBackColor;
            btnRegister.Click += BtnRegister_Click;
            this.Controls.Add(btnRegister, 1, 5);

            this.SetFontSizes(this.Controls);
        }

        private void RegisterScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnRegister;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);

            try
            {
                
                //Input data gathered here to improve readability and centralize any processing
                //that needs to be done before insertion
                string username = this.txtUsernameInput.Text.Trim();
                string password = this.txtPasswordInput.Text.Trim();
                string confirmPassword = this.txtConfirmPasswordInput.Text.Trim();
                int employeeID = (int)this.cbxEmployee.SelectedValue;

                string status = "";

                if (String.IsNullOrEmpty(status = DBUser.Validate(username, password, confirmPassword)))
                {
                    if (DBUser.Register(username, password, employeeID))
                    {
                        status = "User " + username + " has successfully been created!";
                    }
                }

                master.SetStatus(status);

            }
            catch(Exception ex)
            {
                master.SetStatus("Error! " + ex.Message);
            }
        }
    }
}
