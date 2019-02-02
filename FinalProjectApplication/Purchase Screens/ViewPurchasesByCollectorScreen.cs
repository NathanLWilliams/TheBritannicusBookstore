using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using FinalProjectApplication.CrystalReports;

namespace FinalProjectApplication
{
    public class ViewPurchasesByCollectorScreen : Screen
    {
        private System.Windows.Forms.TableLayoutPanel tlpSearchBar;
        private System.Windows.Forms.Label lblSearchPrompt;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label lblSelectedCollectorPrompt;
        private System.Windows.Forms.ComboBox cbxSelectedCollector;
        private System.Windows.Forms.MaskedTextBox mtxtPhoneNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhoneNumPrompt;
        private Button btnViewDetails;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPurchasesByCollector;
        private ViewPurchasesByCollector cryRpt;
        public ViewPurchasesByCollectorScreen(Screen backScreen) : base("View Purchases by Collector", backScreen, 1)
        {
            this.cryRpt = new ViewPurchasesByCollector();
            this.tlpSearchBar = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSelectedCollectorPrompt = new System.Windows.Forms.Label();
            this.lblSearchPrompt = new System.Windows.Forms.Label();
            this.cbxSelectedCollector = new System.Windows.Forms.ComboBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.mtxtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblPhoneNumPrompt = new System.Windows.Forms.Label();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.crvPurchasesByCollector = new CrystalDecisions.Windows.Forms.CrystalReportViewer();

            this.BackColor = System.Drawing.Color.Transparent;
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //this.Controls.Add(this.tlpSearchBar, 0, 0);
            this.Controls.Add(this.crvPurchasesByCollector, 0, 1);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.RowCount = 2;
            this.RowCount = 1;
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle());
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TabIndex = 0;
            this.ParentChanged += ViewPurchasesByCollectorScreen_ParentChanged;
            // 
            // tlpSearchBar
            // 
            this.tlpSearchBar.AutoSize = true;
            this.tlpSearchBar.BackColor = System.Drawing.Color.White;
            this.tlpSearchBar.ColumnCount = 7;
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            //this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpSearchBar.Controls.Add(this.lblName, 1, 0);
            this.tlpSearchBar.Controls.Add(this.lblSelectedCollectorPrompt, 4, 0);
            this.tlpSearchBar.Controls.Add(this.lblSearchPrompt, 0, 0);
            this.tlpSearchBar.Controls.Add(this.cbxSelectedCollector, 5, 0);
            this.tlpSearchBar.Controls.Add(this.txtSearchName, 1, 1);
            this.tlpSearchBar.Controls.Add(this.mtxtPhoneNumber, 2, 1);
            this.tlpSearchBar.Controls.Add(this.lblPhoneNumPrompt, 2, 0);
            this.tlpSearchBar.Controls.Add(this.btnViewDetails, 6, 0);
            this.tlpSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearchBar.Padding = new System.Windows.Forms.Padding(10);
            this.tlpSearchBar.RowCount = 2;
            this.tlpSearchBar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSearchBar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSearchBar.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectedCollectorPrompt
            // 
            this.lblSelectedCollectorPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSelectedCollectorPrompt.AutoSize = true;
            //this.lblSelectedCollectorPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearchBar.SetRowSpan(this.lblSelectedCollectorPrompt, 2);
            this.lblSelectedCollectorPrompt.TabIndex = 3;
            this.lblSelectedCollectorPrompt.Text = "Selected Collector:";
            // 
            // lblSearchPrompt
            // 
            this.lblSearchPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSearchPrompt.AutoSize = true;
            //this.lblSearchPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearchBar.SetRowSpan(this.lblSearchPrompt, 2);
            this.lblSearchPrompt.TabIndex = 0;
            this.lblSearchPrompt.Text = "Search:";
            // 
            // cbxSelectedCollector
            // 
            this.cbxSelectedCollector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectedCollector.FormattingEnabled = true;
            this.cbxSelectedCollector.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.tlpSearchBar.SetRowSpan(this.cbxSelectedCollector, 2);
            this.cbxSelectedCollector.TabIndex = 4;
            //this.cbxSelectedCollector.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSelectedCollector.DataSource = DBCollector.GetCollectors();
            this.cbxSelectedCollector.DisplayMember = "ComboBoxDisplay";
            this.cbxSelectedCollector.ValueMember = "CollectorID";
            this.cbxSelectedCollector.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxSelectedCollector.SelectedValueChanged += CbxSelectedCollector_SelectedValueChanged;
            this.cbxSelectedCollector.Size = new System.Drawing.Size(200, 30);
            // 
            // txtSearchInput
            // 
            this.txtSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtSearchName.TabIndex = 1;
            //this.txtSearchName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.MaxLength = DBControlHelper.MaximumFullNameLength;
            // 
            // mtxtPhoneNumber
            // 
            this.mtxtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtxtPhoneNumber.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.mtxtPhoneNumber.Mask = "(000) 000-0000";
            this.mtxtPhoneNumber.TabIndex = 5;
            this.mtxtPhoneNumber.Size = new System.Drawing.Size(150, 33);
            this.mtxtPhoneNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //this.mtxtPhoneNumber.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // btnViewDetails
            // 
            this.btnViewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewDetails.AutoSize = true;
            this.tlpSearchBar.SetRowSpan(this.btnViewDetails, 2);
            this.btnViewDetails.TabIndex = 8;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += BtnViewDetails_Click;
            // 
            // crvPurchasesByCollector
            //
            this.crvPurchasesByCollector.ActiveViewIndex = -1;
            this.crvPurchasesByCollector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPurchasesByCollector.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPurchasesByCollector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPurchasesByCollector.TabIndex = 1;

            this.SetFontSizes(this.Controls);
        }

        private void ViewPurchasesByCollectorScreen_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);

                try
                {
                    using (var conn = new SqlConnection(Properties.Settings.Default.Britannicus_DBConnectionString))
                    {
                        string conditionQuery = "SELECT conditionID, conditionType FROM conditions";
                        SqlDataAdapter da = new SqlDataAdapter(conditionQuery, conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "conditions");
                        da.Dispose();

                        string invoiceQuery = "SELECT invoiceID, customerID, invoiceDate FROM invoice";
                        SqlDataAdapter da2 = new SqlDataAdapter(invoiceQuery, conn);
                        da2.Fill(ds, "invoice");
                        da2.Dispose();

                        string inventoryQuery = "SELECT itemID, conditionID, quantity FROM inventory";
                        SqlDataAdapter da3 = new SqlDataAdapter(inventoryQuery, conn);
                        da3.Fill(ds, "inventory");
                        da3.Dispose();

                        string itemsQuery = "SELECT itemID, itemTypeID, price, edition FROM items";
                        SqlDataAdapter da5 = new SqlDataAdapter(itemsQuery, conn);
                        da5.Fill(ds, "items");
                        da5.Dispose();

                        string itemTypesQuery = "SELECT itemTypeID, itemTypeName FROM itemTypes";
                        SqlDataAdapter da7 = new SqlDataAdapter(itemTypesQuery, conn);
                        da7.Fill(ds, "itemTypes");
                        da7.Dispose();

                        string transactionQuery = "SELECT invoiceID, itemID, quantity, totalPrice FROM [transaction]";
                        SqlDataAdapter da8 = new SqlDataAdapter(transactionQuery, conn);
                        da8.Fill(ds, "transaction");
                        da8.Dispose();

                        string collectorsQuery = "SELECT customerID, customerTypeID, firstName, lastName, phoneNumber FROM customers";
                        SqlDataAdapter da9 = new SqlDataAdapter(collectorsQuery, conn);
                        da9.Fill(ds, "customers");
                        da9.Dispose();

                        string collectorTypes = "SELECT customerTypeID, customerTypeName FROM customerTypes";
                        SqlDataAdapter da10 = new SqlDataAdapter(collectorTypes, conn);
                        da10.Fill(ds, "customerTypes");
                        da10.Dispose();

                        cryRpt.SetDataSource(ds);
                        this.crvPurchasesByCollector.ReportSource = cryRpt;

                        if(this.cbxSelectedCollector.SelectedItem is DBCollector)
                        {
                            //this.cryRpt.SetParameterValue(0, (int)this.cbxSelectedCollector.SelectedValue);
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    (this.Parent.Parent as MasterForm).SetStatus("Error! Failed to populate the report: " + ex.Message);
                }
            }
        }

        private void CbxSelectedCollector_SelectedValueChanged(object sender, EventArgs e)
        {
            DBCollector tempCollector = (cbxSelectedCollector.SelectedItem as DBCollector);
            txtSearchName.Text = tempCollector.FullName;
            mtxtPhoneNumber.Text = tempCollector.PhoneNumber;
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            //TODO: Remove the controls on this screen and just use report parameters
            //master.screenViewPurchases.SetCollector((int)cbxSelectedCollector.SelectedValue);
            master.SetScreen(master.screenViewPurchases, true);
            master.screenViewPurchases.BackScreen = this;
        }
    }
}
