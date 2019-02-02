using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class MainMenuScreen : Screen
    {
        private Label lblIntroduction;

        public MainMenuScreen(Screen backScreen) : base("Main Menu", backScreen)
        {
            //Set this screens properties, it is a tablelayoutpanel as well
            this.Dock = DockStyle.Fill;
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RowCount = 5;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ParentChanged += MainMenuScreen_ParentChanged;

            lblIntroduction = new Label();
            lblIntroduction.Text = "";
            lblIntroduction.AutoSize = true;
            lblIntroduction.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblIntroduction.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblIntroduction, 0, 1);

            //Panel within a panel so that the group of buttons can be it's own thing
            TableLayoutPanel buttons = new TableLayoutPanel();
            buttons.Dock = DockStyle.Fill;
            buttons.BackColor = Screen.PrimaryColor;
            buttons.ColumnCount = 3;
            buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            buttons.RowCount = 3;
            buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));

            //Create and add the buttons to the screen (the tablelayoutpanel)
            ProtectedButton btnInventory = new ProtectedButton(1, 2, 3);
            btnInventory.Text = "Inventory";
            btnInventory.Click += BtnInventory_Click;
            buttons.Controls.Add(btnInventory, 0, 0); //This adds it to column 0, row 0

            ProtectedButton btnCollectorList = new ProtectedButton(1, 2, 3);
            btnCollectorList.Text = "Collector List";
            btnCollectorList.Click += BtnCollectorList_Click;
            buttons.Controls.Add(btnCollectorList, 1, 0);

            ProtectedButton btnEmployeeList = new ProtectedButton(1);
            btnEmployeeList.Text = "Employee List";
            btnEmployeeList.Click += BtnEmployeeList_Click;
            buttons.Controls.Add(btnEmployeeList, 2, 0);

            ProtectedButton btnViewPurchases = new ProtectedButton(1);
            btnViewPurchases.Text = "View Purchases";
            btnViewPurchases.Click += BtnViewPurchases_Click;
            buttons.Controls.Add(btnViewPurchases, 0, 1);

            ProtectedButton btnViewPurchasesByCollector = new ProtectedButton(1);
            btnViewPurchasesByCollector.Text = "View Purchases by Collector";
            btnViewPurchasesByCollector.Click += BtnViewPurchasesByCollector_Click;
            buttons.Controls.Add(btnViewPurchasesByCollector, 1, 1);

            ProtectedButton btnViewPurchasesByInvoice = new ProtectedButton(1);
            btnViewPurchasesByInvoice.Text = "View Purchases by Invoice";
            btnViewPurchasesByInvoice.Click += BtnViewPurchasesByInvoice_Click;
            buttons.Controls.Add(btnViewPurchasesByInvoice, 2, 1);

            ProtectedButton btnRegister = new ProtectedButton(1);
            btnRegister.Text = "Register";
            btnRegister.Click += BtnRegister_Click;
            buttons.Controls.Add(btnRegister, 0, 2);

            ProtectedButton btnEditTags = new ProtectedButton(1, 2);
            btnEditTags.Text = "Edit Tags";
            btnEditTags.Click += BtnEditTags_Click;
            buttons.Controls.Add(btnEditTags, 1, 2);

            //Make all the buttons have the same appearance
            foreach(Control c in buttons.Controls)
            {
                c.BackColor = Color.White;
                c.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                c.Dock = DockStyle.Fill;
                (c as Button).AutoSize = true;
            }

            this.Controls.Add(buttons, 0, 2);

            SetFontSizes(this.Controls);

        }

        private void MainMenuScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = null;
                master.CancelButton = (master.Controls.Find("btnLogout", true)[0] as Button);
            }
        }

        public void SetIntroductionText(string text)
        {
            this.lblIntroduction.Text = text;
        }

        private void BtnEditTags_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenEditTags, true);
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenRegister, true);
        }

        private void BtnViewPurchasesByInvoice_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenViewPurchasesByInvoice, true);
        }

        private void BtnViewPurchasesByCollector_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenViewPurchasesByCollector, true);
        }

        private void BtnViewPurchases_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenViewPurchases, true);
            master.screenViewPurchases.BackScreen = this;
        }

        private void BtnEmployeeList_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenEmployeeList, true);
        }

        private void BtnCollectorList_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenCollectorList, true);
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenInventory, true);
        }
    }
}
