using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class LoginScreen : Screen
    {
        private TextBox txtUsernameInput;
        private TextBox txtPasswordInput;
        private Button btnLogin;
        public LoginScreen(Screen backScreen) : base("Login", backScreen)
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            this.ColumnCount = 2;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.RowCount = 5;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ParentChanged += LoginScreen_ParentChanged;

            Label lblUsernamePrompt = new Label();
            lblUsernamePrompt.Text = "Username:";
            lblUsernamePrompt.Dock = DockStyle.None;
            lblUsernamePrompt.Anchor = AnchorStyles.Right;
            lblUsernamePrompt.TextAlign = ContentAlignment.MiddleCenter;
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
            lblPasswordPrompt.TextAlign = ContentAlignment.MiddleCenter;
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

            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Dock = DockStyle.None;
            //btnLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnLogin.Anchor = AnchorStyles.Left;
            btnLogin.AutoSize = true;
            btnLogin.Click += BtnLogin_Click;
            btnLogin.BackColor = DefaultBackColor;
            this.Controls.Add(btnLogin, 1, 3);

            this.SetFontSizes(this.Controls);
            
        }

        private void LoginScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnLogin;
                master.CancelButton = null;
                this.txtUsernameInput.Clear();
                this.txtPasswordInput.Clear();
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MasterForm parent = (this.Parent.Parent as MasterForm);
                if (DBUser.Login(this.txtUsernameInput.Text, this.txtPasswordInput.Text))
                {
                    //Login successful

                    //Attempt to update the last access date of the account to the database current date
                    if (!DBUser.UpdateLastAccess(this.txtUsernameInput.Text))
                    {
                        parent.SetStatus("Error! Failed to update last access date");
                    }

                    //Show introduction text welcoming the user and telling them their last access date
                    parent.screenMainMenu.SetIntroductionText("Welcome, " + DBUser.Employee.FullName + ". You last accessed the system on " + 
                        DBUser.LastAccess.ToLongDateString() + "." + Environment.NewLine + "Click the buttons below to navigate to your desired screen.");
                    parent.SetScreen(parent.screenMainMenu);
                }
                else
                {
                    //Login unsuccessful
                    parent.SetStatus("Login unsuccessful. No accounts matching the specified username and password were found.");
                }
            }
            catch(Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Error! Failed to login: " + ex.Message);
            }
        }
    }
}
