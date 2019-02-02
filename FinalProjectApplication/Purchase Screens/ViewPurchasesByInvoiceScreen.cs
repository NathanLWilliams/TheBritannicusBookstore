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
    public class ViewPurchasesByInvoiceScreen : Screen
    {
        private System.Windows.Forms.TableLayoutPanel tlpSearchBar;
        private System.Windows.Forms.Label lblSearchPrompt;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label lblSelectedInvoicePrompt;
        private System.Windows.Forms.ComboBox cbxSelectedInvoice;
        private System.Windows.Forms.MaskedTextBox mtxtPhoneNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhoneNumPrompt;
        private Button btnViewCollectorPurchases;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPurchasesByInvoice;
        private TableLayoutPanel tlpDatePanel;
        private Label lblDateFromPrompt;
        private DateTimePicker dtpDateTo;
        private DateTimePicker dtpDateFrom;
        private Label lblDateToPrompt;
        private ViewPurchasesByInvoice cryRpt;
        public ViewPurchasesByInvoiceScreen(Screen backScreen) : base("View Purchases by Invoice", backScreen, 1)
        {
            this.tlpSearchBar = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSelectedInvoicePrompt = new System.Windows.Forms.Label();
            this.lblSearchPrompt = new System.Windows.Forms.Label();
            this.cbxSelectedInvoice = new System.Windows.Forms.ComboBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.mtxtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblPhoneNumPrompt = new System.Windows.Forms.Label();
            this.btnViewCollectorPurchases = new System.Windows.Forms.Button();
            this.tlpDatePanel = new System.Windows.Forms.TableLayoutPanel();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateFromPrompt = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateToPrompt = new System.Windows.Forms.Label();
            this.crvPurchasesByInvoice = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            cryRpt = new ViewPurchasesByInvoice();

            this.BackColor = System.Drawing.Color.Transparent;
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //this.Controls.Add(this.tlpSearchBar, 0, 0);
            //this.Controls.Add(this.tlpDatePanel, 0, 1);
            this.Controls.Add(this.crvPurchasesByInvoice, 0, 2);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowCount = 1;
            //this.RowCount = 3;
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.Percent, 100F));
            this.TabIndex = 0;
            this.ParentChanged += ViewPurchasesByInvoiceScreen_ParentChanged;
            // 
            // tlpSearchBar
            // 
            //this.tlpSearchBar.AutoSize = true;
            this.tlpSearchBar.BackColor = System.Drawing.Color.White;
            this.tlpSearchBar.ColumnCount = 6;
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpSearchBar.Controls.Add(this.lblName, 1, 0);
            this.tlpSearchBar.Controls.Add(this.lblSelectedInvoicePrompt, 3, 0);
            this.tlpSearchBar.Controls.Add(this.lblSearchPrompt, 0, 0);
            this.tlpSearchBar.Controls.Add(this.cbxSelectedInvoice, 4, 0);
            this.tlpSearchBar.Controls.Add(this.txtSearchName, 1, 1);
            this.tlpSearchBar.Controls.Add(this.mtxtPhoneNumber, 2, 1);
            this.tlpSearchBar.Controls.Add(this.lblPhoneNumPrompt, 2, 0);
            this.tlpSearchBar.Controls.Add(this.btnViewCollectorPurchases, 5, 0);
            this.tlpSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearchBar.Padding = new System.Windows.Forms.Padding(10);
            this.tlpSearchBar.RowCount = 3;
            this.tlpSearchBar.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            // lblSelectedInvoicePrompt
            // 
            this.lblSelectedInvoicePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSelectedInvoicePrompt.AutoSize = true;
            //this.lblSelectedInvoicePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearchBar.SetRowSpan(this.lblSelectedInvoicePrompt, 2);
            this.lblSelectedInvoicePrompt.TabIndex = 3;
            this.lblSelectedInvoicePrompt.Text = "Selected Invoice:";
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
            this.cbxSelectedInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectedInvoice.FormattingEnabled = true;
            this.cbxSelectedInvoice.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.tlpSearchBar.SetRowSpan(this.cbxSelectedInvoice, 2);
            this.cbxSelectedInvoice.TabIndex = 4;
            this.cbxSelectedInvoice.DataSource = DBInvoice.GetInvoices();
            this.cbxSelectedInvoice.DisplayMember = "ComboBoxDisplay";
            this.cbxSelectedInvoice.ValueMember = "ID";
            this.cbxSelectedInvoice.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxSelectedInvoice.SelectedValueChanged += CbxSelectedInvoice_SelectedValueChanged;
            // 
            // txtSearchInput
            // 
            this.txtSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtSearchName.TabIndex = 1;
            this.txtSearchName.MaxLength = DBControlHelper.MaximumFullNameLength;
            // 
            // mtxtPhoneNumber
            // 
            this.mtxtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtxtPhoneNumber.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.mtxtPhoneNumber.Mask = "(000) 000-0000";
            this.mtxtPhoneNumber.TabIndex = 5;
            this.mtxtPhoneNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
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
            this.btnViewCollectorPurchases.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnViewCollectorPurchases.AutoSize = true;
            this.btnViewCollectorPurchases.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewCollectorPurchases.BackColor = System.Drawing.SystemColors.Control;
            this.tlpSearchBar.SetRowSpan(this.btnViewCollectorPurchases, 2);
            this.btnViewCollectorPurchases.TabIndex = 8;
            this.btnViewCollectorPurchases.Text = "View Collector Purchases";
            this.btnViewCollectorPurchases.UseVisualStyleBackColor = false;
            this.btnViewCollectorPurchases.Click += BtnViewDetails_Click;
            // 
            // tlpDatePanel
            // 
            this.tlpDatePanel.AutoSize = true;
            this.tlpDatePanel.ColumnCount = 4;
            this.tlpDatePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDatePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDatePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDatePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDatePanel.Controls.Add(this.dtpDateTo, 3, 0);
            this.tlpDatePanel.Controls.Add(this.lblDateFromPrompt, 0, 0);
            this.tlpDatePanel.Controls.Add(this.dtpDateFrom, 1, 0);
            this.tlpDatePanel.Controls.Add(this.lblDateToPrompt, 2, 0);
            this.tlpDatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDatePanel.RowCount = 1;
            this.tlpDatePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDatePanel.TabIndex = 9;
            this.tlpDatePanel.BackColor = this.tlpSearchBar.BackColor;
            // 
            // dtpDateTo
            // 
            //this.dtpDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateTo.TabIndex = 3;
            // 
            // lblDateFromPrompt
            // 
            this.lblDateFromPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDateFromPrompt.AutoSize = true;
            this.lblDateFromPrompt.TabIndex = 0;
            this.lblDateFromPrompt.Text = "From";
            // 
            // dtpDateFrom
            // 
            //this.dtpDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateFrom.TabIndex = 1;
            // 
            // lblDateToPrompt
            // 
            this.lblDateToPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateToPrompt.AutoSize = true;
            this.lblDateToPrompt.TabIndex = 2;
            this.lblDateToPrompt.Text = "to";
            // 
            // crvPurchasesByInvoice
            // 
            this.crvPurchasesByInvoice.ActiveViewIndex = -1;
            this.crvPurchasesByInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPurchasesByInvoice.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPurchasesByInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPurchasesByInvoice.TabIndex = 1;
            this.crvPurchasesByInvoice.ReuseParameterValuesOnRefresh = true;
            this.crvPurchasesByInvoice.ReportRefresh += CrvPurchasesByInvoice_ReportRefresh;

            this.SetFontSizes(this.Controls);
        }

        private void CrvPurchasesByInvoice_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            crvPurchasesByInvoice.ReportSource = null;
            if (this.cbxSelectedInvoice.SelectedValue != null)
            {
                this.cryRpt.SetParameterValue(0, (int)this.cbxSelectedInvoice.SelectedValue);
            }
            crvPurchasesByInvoice.ReportSource = cryRpt;
        }

        private void ViewPurchasesByInvoiceScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
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

                        string itemDiscountsQuery = "SELECT discountID, discountAmount, startDate, endDate FROM itemDiscounts";
                        SqlDataAdapter da4 = new SqlDataAdapter(itemDiscountsQuery, conn);
                        da4.Fill(ds, "itemDiscounts");
                        da4.Dispose();

                        string itemsQuery = "SELECT itemID, itemTypeID, price, edition FROM items";
                        SqlDataAdapter da5 = new SqlDataAdapter(itemsQuery, conn);
                        da5.Fill(ds, "items");
                        da5.Dispose();

                        string itemTagsQuery = "SELECT itemID, tagID FROM itemTags";
                        SqlDataAdapter da6 = new SqlDataAdapter(itemTagsQuery, conn);
                        da6.Fill(ds, "itemTags");
                        da6.Dispose();

                        string itemTypesQuery = "SELECT itemTypeID, itemTypeName FROM itemTypes";
                        SqlDataAdapter da7 = new SqlDataAdapter(itemTypesQuery, conn);
                        da7.Fill(ds, "itemTypes");
                        da7.Dispose();

                        string transactionQuery = "SELECT invoiceID, itemID, quantity, totalPrice FROM [transaction]";
                        SqlDataAdapter da8 = new SqlDataAdapter(transactionQuery, conn);
                        da8.Fill(ds, "transaction");
                        da8.Dispose();

                        cryRpt.SetDataSource(ds);
                        crvPurchasesByInvoice.ReportSource = cryRpt;

                        if(this.cbxSelectedInvoice.SelectedItem is DBInvoice)
                        {
                            //this.cryRpt.SetParameterValue(0, (int)this.cbxSelectedInvoice.SelectedValue);
                        }

                    }
                }
                catch(Exception ex)
                {
                    (this.Parent.Parent as MasterForm).SetStatus("Error! Failed to populate the report: " + ex.Message);
                }
                
            }

        }

        private void CbxSelectedInvoice_SelectedValueChanged(object sender, EventArgs e)
        {
            DBInvoice tempInvoice = (cbxSelectedInvoice.SelectedItem as DBInvoice);
            this.txtSearchName.Text = tempInvoice.Collector.FullName;
            this.mtxtPhoneNumber.Text = tempInvoice.Collector.PhoneNumber;
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            //DBInvoice tempInvoice = (cbxSelectedInvoice.SelectedItem as DBInvoice);
            //master.screenViewPurchases.SetCollector(tempInvoice.Collector.CollectorID);
            master.SetScreen(master.screenViewPurchases, true);
            master.screenViewPurchases.BackScreen = this;
        }
    }
}
