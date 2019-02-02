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
    public class ViewPurchasesScreen : Screen
    {
        private TableLayoutPanel tlpPurchaseStats;
        private Label lblCollectorIdPrompt;
        private Label lblNamePrompt;
        private Label lblPhoneNumberPrompt;
        private NumericUpDown nudCollectorId;
        private Label lblCollectorName;
        private MaskedTextBox mtxtPhoneNumber;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPurchases;
        private DataGridView dgvPurchaseStats;
        private DataGridViewTextBoxColumn ItemType;
        private DataGridViewTextBoxColumn PurchasePercentage;
        private DataGridViewTextBoxColumn TotalPaid;
        private Label lblPurchaseStatsTitle;
        private DBCollector collector;
        ViewPurchases cryRpt;

        public ViewPurchasesScreen(Screen backScreen) : base("View Purchases", backScreen, 1)
        {
            this.cryRpt = new ViewPurchases();
            this.tlpPurchaseStats = new System.Windows.Forms.TableLayoutPanel();
            this.lblCollectorIdPrompt = new System.Windows.Forms.Label();
            this.lblNamePrompt = new System.Windows.Forms.Label();
            this.lblPhoneNumberPrompt = new System.Windows.Forms.Label();
            this.nudCollectorId = new System.Windows.Forms.NumericUpDown();
            this.lblCollectorName = new System.Windows.Forms.Label();
            this.mtxtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.crvPurchases = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dgvPurchaseStats = new System.Windows.Forms.DataGridView();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPurchaseStatsTitle = new System.Windows.Forms.Label();
            // 
            // panel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(this.tlpPurchaseStats, 0, 0);
            this.Controls.Add(this.crvPurchases, 0, 1);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowCount = 2;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.05063F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.94936F));
            this.TabIndex = 0;
            this.ParentChanged += ViewPurchasesScreen_ParentChanged;
            //this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // tlpPurchaseStats
            // 
            this.tlpPurchaseStats.BackColor = System.Drawing.Color.White;
            this.tlpPurchaseStats.ColumnCount = 6;
            this.tlpPurchaseStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpPurchaseStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPurchaseStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPurchaseStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPurchaseStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPurchaseStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPurchaseStats.Controls.Add(this.mtxtPhoneNumber, 5, 0);
            this.tlpPurchaseStats.Controls.Add(this.lblCollectorIdPrompt, 0, 0);
            this.tlpPurchaseStats.Controls.Add(this.lblNamePrompt, 2, 0);
            this.tlpPurchaseStats.Controls.Add(this.lblPhoneNumberPrompt, 4, 0);
            this.tlpPurchaseStats.Controls.Add(this.nudCollectorId, 1, 0);
            this.tlpPurchaseStats.Controls.Add(this.lblCollectorName, 3, 0);
            this.tlpPurchaseStats.Controls.Add(this.dgvPurchaseStats, 1, 2);
            this.tlpPurchaseStats.Controls.Add(this.lblPurchaseStatsTitle, 0, 1);
            this.tlpPurchaseStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPurchaseStats.RowCount = 3;
            this.tlpPurchaseStats.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPurchaseStats.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPurchaseStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPurchaseStats.TabIndex = 0;
            // 
            // lblCollectorIdPrompt
            // 
            this.lblCollectorIdPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCollectorIdPrompt.AutoSize = true;
            this.lblCollectorIdPrompt.TabIndex = 0;
            this.lblCollectorIdPrompt.Text = "Collector ID:";
            // 
            // lblNamePrompt
            // 
            this.lblNamePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNamePrompt.AutoSize = true;
            this.lblNamePrompt.TabIndex = 1;
            this.lblNamePrompt.Text = "Name:";
            // 
            // lblPhoneNumberPrompt
            // 
            this.lblPhoneNumberPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPhoneNumberPrompt.AutoSize = true;
            this.lblPhoneNumberPrompt.TabIndex = 2;
            this.lblPhoneNumberPrompt.Text = "Phone Number:";
            // 
            // nudCollectorId
            // 
            this.nudCollectorId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCollectorId.TabIndex = 3;
            //this.nudCollectorId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCollectorId.ValueChanged += NudCollectorId_ValueChanged;
            this.nudCollectorId.Value = 1;
            // 
            // lblCollectorName
            // 
            this.lblCollectorName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCollectorName.AutoSize = true;
            this.lblCollectorName.TabIndex = 4;
            // 
            // lblPhoneNumber
            // 
            this.mtxtPhoneNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mtxtPhoneNumber.AutoSize = true;
            this.mtxtPhoneNumber.Size = new System.Drawing.Size(200, 33);
            this.mtxtPhoneNumber.TabIndex = 5;
            this.mtxtPhoneNumber.Mask = "(000) 000-0000";
            this.mtxtPhoneNumber.ReadOnly = true;
            this.mtxtPhoneNumber.BackColor = this.lblCollectorName.BackColor;
            this.mtxtPhoneNumber.BorderStyle = BorderStyle.None;
            this.mtxtPhoneNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // crvPurchases
            // 
            this.crvPurchases.ActiveViewIndex = -1;
            this.crvPurchases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPurchases.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPurchases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPurchases.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.crvPurchases.TabIndex = 1;
            this.crvPurchases.ReuseParameterValuesOnRefresh = true;
            this.crvPurchases.ReportRefresh += CrvPurchases_ReportRefresh;

            // 
            // dgvPurchaseStats
            // 
            this.dgvPurchaseStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemType,
            this.PurchasePercentage,
            this.TotalPaid});
            this.tlpPurchaseStats.SetColumnSpan(this.dgvPurchaseStats, 4);
            this.dgvPurchaseStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseStats.TabIndex = 6;
            // 
            // ItemType
            // 
            this.ItemType.HeaderText = "Item Type";
            this.ItemType.Name = "ItemType";
            // 
            // PurchasePercentage
            // 
            this.PurchasePercentage.HeaderText = "% of Purchases";
            this.PurchasePercentage.Name = "PurchasePercentage";
            // 
            // TotalPaid
            // 
            this.TotalPaid.HeaderText = "Total Paid";
            this.TotalPaid.Name = "TotalPaid";
            // 
            // lblPurchaseStatsTitle
            // 
            this.lblPurchaseStatsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPurchaseStatsTitle.AutoSize = true;
            this.tlpPurchaseStats.SetColumnSpan(this.lblPurchaseStatsTitle, 6);
            this.lblPurchaseStatsTitle.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.lblPurchaseStatsTitle.TabIndex = 7;
            this.lblPurchaseStatsTitle.Text = "Purchase Statistics";
            this.lblPurchaseStatsTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;

            this.SetFontSizes(this.Controls);
        }

        private void CrvPurchases_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            crvPurchases.ReportSource = null;
            this.cryRpt.SetParameterValue(0, (int)this.nudCollectorId.Value);
            crvPurchases.ReportSource = cryRpt;
        }

        private void ViewPurchasesScreen_ParentChanged(object sender, EventArgs e)
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
                        crvPurchases.ReportSource = cryRpt;

                        this.cryRpt.SetParameterValue(0, (int)this.nudCollectorId.Value);
                    }
                }
                catch(Exception ex)
                {
                    (this.Parent.Parent as MasterForm).SetStatus("Error! Failed to populate the report: " + ex.Message);
                }

            }
        }

        public void SetCollector(int id, int max)
        {
            collector = DBCollector.GetCollectorById(id);
            this.nudCollectorId.Maximum = max;
            this.nudCollectorId.Value = id;
        }

        private void NudCollectorId_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                collector = DBCollector.GetCollectorById((int)this.nudCollectorId.Value);
                this.lblCollectorName.Text = collector.FullName;
                this.mtxtPhoneNumber.Text = collector.PhoneNumber;
            }
            catch(Exception ex)
            {
                (this.Parent.Parent as MasterForm).SetStatus("Error! Failed to load collector: " + ex.Message); 
            }
        }
    }
}
