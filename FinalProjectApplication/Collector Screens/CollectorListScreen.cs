using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class CollectorListScreen : Screen
    {
        private System.Windows.Forms.TableLayoutPanel tlpSearchBar;
        private System.Windows.Forms.Label lblSearchPrompt;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label lblSelectedCollectorPrompt;
        private System.Windows.Forms.ComboBox cbxSelectedCollector;
        private System.Windows.Forms.TableLayoutPanel tlpEditOptions;
        private System.Windows.Forms.Label lblEditOptionsPrompt;
        private System.Windows.Forms.Button btnAddCollector;
        private System.Windows.Forms.Button btnUpdateCollector;
        private System.Windows.Forms.Button btnRemoveCollector;
        private System.Windows.Forms.DataGridView dgvCollectors;
        private System.Windows.Forms.MaskedTextBox mtxtPhoneNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhoneNumPrompt;
        private ProtectedButton btnViewPurchases;
        private System.Windows.Forms.Button btnSellToSelected;
        private BindingList<DBCollector> collectors;

        public CollectorListScreen(Screen backScreen) : base("Collector List", backScreen, 1, 2, 3)
        {

            #region Instantiation
            this.tlpSearchBar = new System.Windows.Forms.TableLayoutPanel();
            this.lblSelectedCollectorPrompt = new System.Windows.Forms.Label();
            this.lblSearchPrompt = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.cbxSelectedCollector = new System.Windows.Forms.ComboBox();
            this.tlpEditOptions = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdateCollector = new System.Windows.Forms.Button();
            this.btnRemoveCollector = new System.Windows.Forms.Button();
            this.lblEditOptionsPrompt = new System.Windows.Forms.Label();
            this.btnAddCollector = new System.Windows.Forms.Button();
            this.dgvCollectors = new System.Windows.Forms.DataGridView();
            this.mtxtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblPhoneNumPrompt = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnViewPurchases = new ProtectedButton(1);
            this.btnSellToSelected = new System.Windows.Forms.Button();
            #endregion

            #region Init Screen
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(this.tlpEditOptions, 0, 0);
            this.Controls.Add(this.tlpSearchBar, 0, 1);
            this.Controls.Add(this.dgvCollectors, 0, 2);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowCount = 3;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TabIndex = 0;
            this.ParentChanged += CollectorListScreen_ParentChanged;
            #endregion

            #region Controls
            // 
            // tlpSearchBar
            // 
            this.tlpSearchBar.BackColor = System.Drawing.Color.White;
            this.tlpSearchBar.ColumnCount = 5;
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearchBar.Controls.Add(this.lblName, 1, 0);
            this.tlpSearchBar.Controls.Add(this.lblSelectedCollectorPrompt, 3, 0);
            this.tlpSearchBar.Controls.Add(this.lblSearchPrompt, 0, 0);
            this.tlpSearchBar.Controls.Add(this.cbxSelectedCollector, 4, 0);
            this.tlpSearchBar.Controls.Add(this.txtSearchName, 1, 1);
            this.tlpSearchBar.Controls.Add(this.mtxtPhoneNumber, 2, 1);
            this.tlpSearchBar.Controls.Add(this.lblPhoneNumPrompt, 2, 0);
            this.tlpSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearchBar.RowCount = 2;
            this.tlpSearchBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpSearchBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpSearchBar.TabIndex = 0;
            this.tlpSearchBar.AutoSize = true;
            this.tlpSearchBar.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            // 
            // lblSelectedCollectorPrompt
            // 
            this.lblSelectedCollectorPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSelectedCollectorPrompt.AutoSize = true;
            this.tlpSearchBar.SetRowSpan(this.lblSelectedCollectorPrompt, 2);
            this.lblSelectedCollectorPrompt.TabIndex = 3;
            this.lblSelectedCollectorPrompt.Text = "Selected Collector:";
            // 
            // lblSearchPrompt
            // 
            this.lblSearchPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSearchPrompt.AutoSize = true;
            this.tlpSearchBar.SetRowSpan(this.lblSearchPrompt, 2);
            this.lblSearchPrompt.TabIndex = 0;
            this.lblSearchPrompt.Text = "Search:";
            // 
            // txtSearchInput
            // 
            this.txtSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtSearchName.TabIndex = 1;
            this.txtSearchName.MaxLength = DBControlHelper.MaximumFullNameLength;
            this.txtSearchName.TextChanged += Search_TextChanged;
            // 
            // cbxSelectedCollector
            // 
            this.cbxSelectedCollector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectedCollector.FormattingEnabled = true;
            this.cbxSelectedCollector.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.tlpSearchBar.SetRowSpan(this.cbxSelectedCollector, 2);
            this.cbxSelectedCollector.TabIndex = 4;
            this.cbxSelectedCollector.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // tlpEditOptions
            // 
            this.tlpEditOptions.BackColor = System.Drawing.Color.White;
            this.tlpEditOptions.ColumnCount = 8;
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpEditOptions.Controls.Add(this.lblEditOptionsPrompt, 1, 0);
            this.tlpEditOptions.Controls.Add(this.btnAddCollector, 2, 0);
            this.tlpEditOptions.Controls.Add(this.btnViewPurchases, 3, 0);
            this.tlpEditOptions.Controls.Add(this.btnRemoveCollector, 4, 0);
            this.tlpEditOptions.Controls.Add(this.btnUpdateCollector, 5, 0);
            this.tlpEditOptions.Controls.Add(this.btnSellToSelected, 6, 0);
            this.tlpEditOptions.Dock = DockStyle.Fill;
            this.tlpEditOptions.RowCount = 1;
            this.tlpEditOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEditOptions.TabIndex = 1;
            this.tlpEditOptions.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.tlpEditOptions.AutoSize = true;
            // 
            // lblEditOptionsPrompt
            // 
            this.lblEditOptionsPrompt.Dock = System.Windows.Forms.DockStyle.None;
            this.lblEditOptionsPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblEditOptionsPrompt.AutoSize = true;
            this.lblEditOptionsPrompt.Anchor = AnchorStyles.Right;
            this.lblEditOptionsPrompt.TabIndex = 1;
            this.lblEditOptionsPrompt.Text = "Edit Options";
            // 
            // btnAddCollector
            // 
            this.btnAddCollector.TabIndex = 2;
            this.btnAddCollector.Text = "Add Collector";
            this.btnAddCollector.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnAddCollector.Dock = DockStyle.None;
            this.btnAddCollector.UseVisualStyleBackColor = true;
            this.btnAddCollector.BackColor = DefaultBackColor;
            this.btnAddCollector.Click += BtnAddCollector_Click;
            this.btnAddCollector.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnAddCollector.AutoSize = true;
            // 
            // btnViewPurchases
            // 
            this.btnViewPurchases.TabIndex = 2;
            this.btnViewPurchases.Text = "View Purchases";
            this.btnViewPurchases.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnViewPurchases.Dock = DockStyle.None;
            this.btnViewPurchases.UseVisualStyleBackColor = true;
            this.btnViewPurchases.BackColor = DefaultBackColor;
            this.btnViewPurchases.Click += BtnViewPurchases_Click;
            this.btnViewPurchases.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnViewPurchases.AutoSize = true;
            // 
            // btnRemoveCollector
            // 
            this.btnRemoveCollector.TabIndex = 3;
            this.btnRemoveCollector.Text = "Remove Collector";
            this.btnRemoveCollector.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnRemoveCollector.Dock = DockStyle.None;
            this.btnRemoveCollector.UseVisualStyleBackColor = true;
            this.btnRemoveCollector.BackColor = DefaultBackColor;
            this.btnRemoveCollector.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnRemoveCollector.AutoSize = true;
            this.btnRemoveCollector.Click += BtnRemoveCollector_Click;
            // 
            // btnUpdateCollector
            // 
            this.btnUpdateCollector.TabIndex = 4;
            this.btnUpdateCollector.Text = "Update Collector";
            this.btnUpdateCollector.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnUpdateCollector.Dock = DockStyle.None;
            this.btnUpdateCollector.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnUpdateCollector.UseVisualStyleBackColor = true;
            this.btnUpdateCollector.BackColor = DefaultBackColor;
            this.btnUpdateCollector.Click += BtnUpdateCollector_Click;
            this.btnUpdateCollector.AutoSize = true;
            // 
            // btnUpdateCollector
            // 
            this.btnSellToSelected.TabIndex = 4;
            this.btnSellToSelected.Text = "Sell to Selected";
            this.btnSellToSelected.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnSellToSelected.Dock = DockStyle.None;
            this.btnSellToSelected.UseVisualStyleBackColor = true;
            this.btnSellToSelected.BackColor = DefaultBackColor;
            this.btnSellToSelected.Click += BtnSellToSelected_Click;
            this.btnSellToSelected.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnSellToSelected.AutoSize = true;
            // 
            // dgvCollectors
            // 
            this.dgvCollectors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCollectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCollectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCollectors.TabIndex = 2;
            this.dgvCollectors.ReadOnly = true;
            this.dgvCollectors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // mtxtPhoneNumber
            // 
            this.mtxtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtxtPhoneNumber.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.mtxtPhoneNumber.Mask = "(000) 000-0000";
            this.mtxtPhoneNumber.TabIndex = 5;
            this.mtxtPhoneNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            this.mtxtPhoneNumber.TextChanged += Search_TextChanged;
            // 
            // lblPhoneNumPrompt
            // 
            this.lblPhoneNumPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhoneNumPrompt.AutoSize = true;
            this.lblPhoneNumPrompt.TabIndex = 6;
            this.lblPhoneNumPrompt.Text = "Phone Number";
            this.lblPhoneNumPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            #endregion

            this.ReloadData();
            this.dgvCollectors.DataSourceChanged += DgvCollectors_DataSourceChanged;

            this.cbxSelectedCollector.DisplayMember = "ComboBoxDisplay";
            this.cbxSelectedCollector.ValueMember = "CollectorID";

            this.SetFontSizes(this.Controls);
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            this.FilterCollectors();
        }
        private void FilterCollectors()
        {
            BindingList<DBCollector> filteredCollectors = DBControlHelper.GetFilteredCollectors(this.collectors,
                this.txtSearchName.Text, this.mtxtPhoneNumber.Text);
            this.dgvCollectors.DataSource = filteredCollectors;
            this.cbxSelectedCollector.DataSource = filteredCollectors;
        }

        #region Methods
        private void ReloadData()
        {
            this.collectors = DBCollector.GetCollectors();
            //this.txtSearchName.DataBindings.Clear();
            //this.mtxtPhoneNumber.DataBindings.Clear();
            this.dgvCollectors.DataSource = this.collectors;
            this.cbxSelectedCollector.DataSource = this.collectors;
            //this.txtSearchName.DataBindings.Add("Text", this.collectors, "FullName", true, DataSourceUpdateMode.Never);
            //this.mtxtPhoneNumber.DataBindings.Add("Text", this.collectors, "PhoneNumber", true, DataSourceUpdateMode.Never);
            this.FilterCollectors();
        }
        #endregion

        #region Event Handlers
        private void DgvCollectors_DataSourceChanged(object sender, EventArgs e)
        {
            //This is done here because the columns aren't generated immediately after
            //the datasource is set for some reason
            this.dgvCollectors.Columns["CollectorID"].HeaderText = "Collector ID";
            this.dgvCollectors.Columns["CollectorType"].HeaderText = "Type";
            this.dgvCollectors.Columns["CollectorTypeID"].Visible = false;
            this.dgvCollectors.Columns["PhoneNumber"].HeaderText = "Phone Number";
            this.dgvCollectors.Columns["ComboBoxDisplay"].Visible = false;
            this.dgvCollectors.Columns["FirstName"].Visible = false;
            this.dgvCollectors.Columns["LastName"].Visible = false;
            this.dgvCollectors.Columns["FullName"].HeaderText = "Full Name";
        }

        private void BtnRemoveCollector_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            if (this.cbxSelectedCollector.SelectedItem is DBCollector)
            {
                try
                {
                    DBCollector tempCollector = (this.cbxSelectedCollector.SelectedItem as DBCollector);

                    //Attempt to delete from the database
                    if (tempCollector.Delete())
                    {
                        //Deletion successful

                        master.SetStatus("Collector " + tempCollector.FullName + " has been deleted.");

                        //Remove all related datagridview rows
                        for (var i = 0; i < this.dgvCollectors.Rows.Count; i++)
                        {
                            if ((int)this.dgvCollectors.Rows[i].Cells["CollectorID"].Value == tempCollector.CollectorID)
                            {
                                this.dgvCollectors.Rows.RemoveAt(i);
                            }
                        }
                        this.collectors.Remove(tempCollector);
                    }
                }
                catch (Exception ex)
                {
                    master.SetStatus("Error! Deletion failed: " + ex.Message);
                }
            }
            else
            {
                master.SetStatus("Error! You must select a collector to remove");
            }
            
        }

        private void CollectorListScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnUpdateCollector;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);

                this.ReloadData();
            }
        }

        private void BtnSellToSelected_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            if(cbxSelectedCollector.SelectedItem is DBCollector)
            {
                Cart.Invoice.Collector = (cbxSelectedCollector.SelectedItem as DBCollector);
            }
            master.SetScreen(master.screenSellItem, true);
            master.screenSellItem.BackScreen = this;
        }

        private void BtnViewPurchases_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.screenViewPurchases.SetCollector((int)cbxSelectedCollector.SelectedValue, this.collectors.Last().CollectorID);
            master.SetScreen(master.screenViewPurchases, true);
            master.screenViewPurchases.BackScreen = this;
        }

        private void BtnAddCollector_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenAddCollector, true);
        }

        private void BtnUpdateCollector_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.screenUpdateCollector.SetCollector((int)cbxSelectedCollector.SelectedValue, this.collectors.Last().CollectorID);
            master.SetScreen(master.screenUpdateCollector, true);
        }
        #endregion
    }
}
