using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class CheckoutScreen : Screen
    {
        private Label lblCustomerBuying;
        private DataGridView dgvTransactions;
        private TableLayoutPanel tlpButtons;
        private Button btnCheckout;
        private Button btnSellAnotherItem;
        private TableLayoutPanel tlpEditOptions;
        private Button btnRemoveTransaction;
        private Label lblQuantityPrompt;
        private NumericUpDown nudQuantity;


        public CheckoutScreen(Screen backScreen) : base("Checkout", backScreen, 1, 2, 3)
        {
            this.lblCustomerBuying = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnSellAnotherItem = new System.Windows.Forms.Button();
            this.tlpEditOptions = new TableLayoutPanel();
            this.lblQuantityPrompt = new Label();
            this.nudQuantity = new NumericUpDown();
            this.btnRemoveTransaction = new Button();
            // 
            // panel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(this.tlpEditOptions, 0, 0);
            this.Controls.Add(this.dgvTransactions, 0, 1);
            this.Controls.Add(this.tlpButtons, 0, 2);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowCount = 3;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TabIndex = 0;
            this.ParentChanged += CheckoutScreen_ParentChanged;
            //this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // tlpEditOptions
            this.tlpEditOptions.Dock = DockStyle.Fill;
            this.tlpEditOptions.ColumnCount = 4;
            this.tlpEditOptions.RowCount = 1;
            this.tlpEditOptions.AutoSize = true;
            this.tlpEditOptions.BackColor = System.Drawing.Color.White;
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.Controls.Add(this.lblCustomerBuying, 0, 0);
            this.tlpEditOptions.Controls.Add(this.lblQuantityPrompt, 1, 0);
            this.tlpEditOptions.Controls.Add(this.nudQuantity, 2, 0);
            this.tlpEditOptions.Controls.Add(this.btnRemoveTransaction, 3, 0);

            lblQuantityPrompt.Text = "Quantity:";
            lblQuantityPrompt.Anchor = AnchorStyles.Right;
            lblQuantityPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lblQuantityPrompt.AutoSize = true;

            nudQuantity.Anchor = AnchorStyles.Left;
            nudQuantity.Minimum = 1;
            nudQuantity.ValueChanged += NudQuantity_ValueChanged;

            btnRemoveTransaction.Text = "Remove Transaction";
            btnRemoveTransaction.AutoSize = true;
            btnRemoveTransaction.BackColor = DefaultBackColor;
            btnRemoveTransaction.Anchor = AnchorStyles.Right;
            btnRemoveTransaction.Click += BtnRemoveTransaction_Click;

            // 
            // lblCustomerBuying
            // 
            this.lblCustomerBuying.Anchor = AnchorStyles.Left;
            this.lblCustomerBuying.AutoSize = true;
            this.lblCustomerBuying.TabIndex = 0;
            this.lblCustomerBuying.Text = "Anonymous Customer (0) is buying...";
            this.lblCustomerBuying.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.TabIndex = 1;
            this.dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.SelectionChanged += DgvTransactions_SelectionChanged;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 2;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Controls.Add(this.btnSellAnotherItem, 1, 0);
            this.tlpButtons.Controls.Add(this.btnCheckout, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpButtons.TabIndex = 2;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCheckout.AutoSize = true;
            this.btnCheckout.BackColor = System.Drawing.SystemColors.Control;
            this.btnCheckout.TabIndex = 0;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += BtnCheckout_Click;
            // 
            // btnSellAnotherItem
            // 
            this.btnSellAnotherItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSellAnotherItem.AutoSize = true;
            this.btnSellAnotherItem.BackColor = System.Drawing.SystemColors.Control;
            this.btnSellAnotherItem.TabIndex = 1;
            this.btnSellAnotherItem.Text = "Sell Another Item";
            this.btnSellAnotherItem.UseVisualStyleBackColor = false;
            this.btnSellAnotherItem.Click += BtnSellAnotherItem_Click;

            this.SetFontSizes(this.Controls);
        }

        private void BtnRemoveTransaction_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            try
            {
                if (this.dgvTransactions.SelectedCells.Count > 0)
                {
                    Cart.Invoice.Transactions.RemoveAt(this.dgvTransactions.CurrentCell.RowIndex);
                }
            }
            catch(Exception ex)
            {
                master.SetStatus("Error! Failed to remove transaction: " + ex.Message);
            }
        }

        private void DgvTransactions_SelectionChanged(object sender, EventArgs e)
        {
            if(this.dgvTransactions.SelectedCells.Count > 0)
            {
                nudQuantity.Maximum = Cart.Invoice.Transactions[this.dgvTransactions.CurrentCell.RowIndex].getItemStock();
                nudQuantity.Value = Cart.Invoice.Transactions[this.dgvTransactions.CurrentCell.RowIndex].Quantity;
            }
        }

        private void NudQuantity_ValueChanged(object sender, EventArgs e)
        {
            if(this.dgvTransactions.SelectedCells.Count > 0)
            {
                //Update the quantity of the transaction shown in the selected row
                Cart.Invoice.Transactions[this.dgvTransactions.CurrentCell.RowIndex].Quantity = (int)nudQuantity.Value;
                DataGridViewCell selectedCell = this.dgvTransactions.SelectedRows[0].Cells["Quantity"];
                selectedCell.Value = (int)nudQuantity.Value;

                //Update the total transaction price to take into account the updated quantity
                this.dgvTransactions.UpdateCellValue(selectedCell.ColumnIndex, selectedCell.RowIndex);
                DataGridViewCell totalPriceCell = this.dgvTransactions.SelectedRows[0].Cells["TotalPrice"];
                this.dgvTransactions.UpdateCellValue(totalPriceCell.ColumnIndex, totalPriceCell.RowIndex);
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            try
            {
                string errorMessage = Cart.Invoice.ValidateForCheckout();

                if(String.IsNullOrEmpty(errorMessage))
                {
                    int insertResult = Cart.Invoice.InsertInvoice();

                    if (insertResult == -1)
                    {
                        errorMessage = "Error! Failed to checkout. Reason unknown.";
                    }
                    else if (insertResult == 2)
                    {
                        Cart.Invoice.Transactions.Clear();
                        errorMessage = "Checkout completed successfully.";
                    }
                }

                master.SetStatus(errorMessage);

            }
            catch(Exception ex)
            {
                master.SetStatus("Error! Failed to checkout: " + ex.Message);
            }
        }

        private void CheckoutScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnCheckout;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);

                ShowTransactions();
                this.lblCustomerBuying.Text = Cart.Invoice.Collector.ComboBoxDisplay + " is buying...";
            }
        }

        public void ShowTransactions()
        {
            this.dgvTransactions.DataSource = Cart.Invoice.Transactions;
            this.dgvTransactions.Columns["ItemID"].HeaderText = "Item ID";
            this.dgvTransactions.Columns["ItemType"].HeaderText = "Item Type";
            this.dgvTransactions.Columns["TotalPrice"].HeaderText = "Total Price";
        }
        private void BtnSellAnotherItem_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenSellItem, true);
            master.screenSellItem.BackScreen = this;
        }
    }
}
