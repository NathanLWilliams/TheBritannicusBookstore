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
    public class Screen : TableLayoutPanel
    {
        public string Title { get; }

        private int[] authorizedRoles;
        public Screen BackScreen { get; set; }
        public static Color PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(73)))));

        public Screen(string title, Screen backScreen, params int[] authorizedRoles) //Null means any role is allowed
        {
            this.Title = title;
            this.BackScreen = backScreen;
            this.authorizedRoles = authorizedRoles;
            this.Margin = new Padding(10, 10, 10, 10);
        }
        public void SetFontSizes(ControlCollection controls)
        {
            foreach(Control c in controls)
            {
                if(c is Panel)
                {
                    SetFontSizes(c.Controls);
                }
                else if(c is Label || c is Button || c is TextBox || c is ComboBox || c is DateTimePicker || c is NumericUpDown || c is MaskedTextBox)
                {
                    c.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        public void HideUnauthorizedButtons(ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is Panel)
                {
                    HideUnauthorizedButtons(c.Controls);
                }
                else if (c is ProtectedButton)
                {
                    (c as ProtectedButton).CheckRole(DBUser.GetRole());
                }
            }
        }
        public bool IsAuthorized(int role)
        {
            //Check if user is authorized to access this page
            //Null means any role is authorized
            return (this.authorizedRoles.Length == 0 || role == 1 || this.authorizedRoles.Contains<int>(role));
        }

    }
}
