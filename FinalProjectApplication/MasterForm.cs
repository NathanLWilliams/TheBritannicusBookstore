using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Icon Found here: https://www.cradlecincinnati.org/wp-content/uploads/2016/06/

//TODO:
//-Add a help button to link to our created documentation?

namespace FinalProjectApplication
{
    public partial class MasterForm : Form
    {

        #region Screens
        private Screen currentScreen;
        public MainMenuScreen screenMainMenu;
        public LoginScreen screenLogin;
        public ViewPurchasesByCollectorScreen screenViewPurchasesByCollector;
        public InventoryScreen screenInventory;
        public EmployeeListScreen screenEmployeeList;
        public AddEmployeeScreen screenAddEmployee;
        public UpdateEmployeeScreen screenUpdateEmployee;
        public EditTagsScreen screenEditTags;
        public RegisterScreen screenRegister;
        public ViewPurchasesByInvoiceScreen screenViewPurchasesByInvoice;
        public ViewPurchasesScreen screenViewPurchases;
        public CollectorListScreen screenCollectorList;
        public UpdateCollectorScreen screenUpdateCollector;
        public AddCollectorScreen screenAddCollector;
        public AddItemScreen screenAddItem;
        public SellItemScreen screenSellItem;
        public UpdateItemScreen screenUpdateItem;
        public CheckoutScreen screenCheckout;
        #endregion

        public MasterForm()
        {
            InitializeComponent();
            
            InitializeScreens();

            //Show the first screen
            this.SetScreen(screenLogin, false);
        }
        public void InitializeScreens()
        {
            screenLogin = new LoginScreen(null);
            screenMainMenu = new MainMenuScreen(null);
            screenInventory = new InventoryScreen(screenMainMenu);
            screenViewPurchasesByCollector = new ViewPurchasesByCollectorScreen(screenMainMenu);
            screenCollectorList = new CollectorListScreen(screenMainMenu);
            screenEmployeeList = new EmployeeListScreen(screenMainMenu);
            screenSellItem = new SellItemScreen(screenInventory);
            screenEditTags = new EditTagsScreen(screenMainMenu);
            screenRegister = new RegisterScreen(screenMainMenu);
            screenViewPurchasesByInvoice = new ViewPurchasesByInvoiceScreen(screenMainMenu);
            screenViewPurchases = new ViewPurchasesScreen(screenCollectorList);
            screenAddEmployee = new AddEmployeeScreen(screenEmployeeList);
            screenUpdateEmployee = new UpdateEmployeeScreen(screenEmployeeList);
            screenAddCollector = new AddCollectorScreen(screenCollectorList);
            screenUpdateCollector = new UpdateCollectorScreen(screenCollectorList);
            screenAddItem = new AddItemScreen(screenInventory);
            screenUpdateItem = new UpdateItemScreen(screenInventory);
            screenCheckout = new CheckoutScreen(screenSellItem);
        }
        public void SetScreen(Screen screen, bool isExtendedForm = true)
        {
            //Check if the current user is allowed to access the passed screen
            if(screen.IsAuthorized(DBUser.GetRole()))
            {
                //Clear the status text
                this.SetStatus("");

                //Set the forms title to the screen title
                this.lblPageTitle.Text = screen.Title;

                //Only show the back button if it makes sense for there to be a screen before it
                this.btnBack.Visible = screen.BackScreen != null;

                //Don't show the back to main menu button if the current screen is the main menu or login screen
                this.btnBackToMainMenu.Visible = !(screen is MainMenuScreen || screen is LoginScreen);

                //Include additional master page options if true
                this.SetExtended(isExtendedForm);

                //Remove the current screen and replace it with the passed screen
                this.tlpMasterLayout.Controls.Remove(currentScreen);
                this.currentScreen = screen;
                this.tlpMasterLayout.Controls.Add(currentScreen, 0, 1);

                this.currentScreen.HideUnauthorizedButtons(this.Controls);

                //Set the active control to null so no buttons are auto-focused
                //and the accept button is prioritized
                this.ActiveControl = null;
            }
            else
            {
                //TODO: Log failed access attempt
                this.SetStatus("Error! You do not have access to the requested screen");
            }
        }
        public void SetExtended(bool isExtended)
        {
            this.btnLogout.Visible = isExtended;
            this.btnNavInventory.Visible = isExtended;
            this.btnNavPurchaseList.Visible = isExtended;
            this.btnNavEmployeeList.Visible = isExtended;
            this.btnNavCollectorList.Visible = isExtended;
        }
        public void SetStatus(string status)
        {
            this.rtxtStatus.Text = status;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Are you sure you wish to exit?", "Exit", MessageBoxButtons.YesNo);
            if(choice == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DBUser.Logout();
            this.SetScreen(this.screenLogin, false);
        }

        private void btnNavPurchaseList_Click(object sender, EventArgs e)
        {
            this.SetScreen(this.screenViewPurchasesByCollector, true);
        }

        private void btnNavInventory_Click(object sender, EventArgs e)
        {
            this.SetScreen(this.screenInventory, true);
        }

        private void btnNavCollectorList_Click(object sender, EventArgs e)
        {
            this.SetScreen(this.screenCollectorList, true);
        }

        private void btnNavEmployeeList_Click(object sender, EventArgs e)
        {
            this.SetScreen(this.screenEmployeeList, true);
        }

        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            this.SetScreen(this.screenMainMenu, true);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.SetScreen(this.currentScreen.BackScreen);
        }
    }
}
