using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class ProtectedButton : Button
    {
        private int[] authorizedRoles;
        public ProtectedButton(params int[] authorizedRoles)
        {
            this.authorizedRoles = authorizedRoles;
        }
        public void CheckRole(int role)
        {
            this.Enabled = (this.authorizedRoles.Length == 0 || role == 1 || this.authorizedRoles.Contains<int>(role));
        }
    }
}
