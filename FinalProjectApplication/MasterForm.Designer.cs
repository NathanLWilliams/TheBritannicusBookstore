namespace FinalProjectApplication
{
    partial class MasterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.tlpMasterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.tlpNavbar = new System.Windows.Forms.TableLayoutPanel();
            this.btnNavEmployeeList = new ProtectedButton(1);
            this.btnNavCollectorList = new ProtectedButton(1, 2, 3);
            this.btnNavInventory = new ProtectedButton(1, 2, 3);
            this.btnNavPurchaseList = new ProtectedButton(1);
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblMasterTitle = new System.Windows.Forms.Label();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnBackToMainMenu = new System.Windows.Forms.Button();
            this.rtxtStatus = new System.Windows.Forms.RichTextBox();
            this.tlpMasterLayout.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            this.tlpNavbar.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMasterLayout
            // 
            this.tlpMasterLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(192)))));
            this.tlpMasterLayout.ColumnCount = 1;
            this.tlpMasterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMasterLayout.Controls.Add(this.tlpHeader, 0, 0);
            this.tlpMasterLayout.Controls.Add(this.tlpFooter, 0, 2);
            this.tlpMasterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMasterLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpMasterLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMasterLayout.Name = "tlpMasterLayout";
            this.tlpMasterLayout.RowCount = 3;
            this.tlpMasterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMasterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMasterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMasterLayout.Size = new System.Drawing.Size(1312, 1061);
            this.tlpMasterLayout.TabIndex = 0;
            // 
            // tlpHeader
            // 
            this.tlpHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpHeader.AutoSize = true;
            this.tlpHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(73)))));
            this.tlpHeader.ColumnCount = 1;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Controls.Add(this.tlpNavbar, 0, 2);
            this.tlpHeader.Controls.Add(this.lblPageTitle, 0, 1);
            this.tlpHeader.Controls.Add(this.lblMasterTitle, 0, 0);
            this.tlpHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 3;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlpHeader.Size = new System.Drawing.Size(1312, 172);
            this.tlpHeader.TabIndex = 1;
            // 
            // tlpNavbar
            // 
            this.tlpNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(35)))));
            this.tlpNavbar.ColumnCount = 4;
            this.tlpNavbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpNavbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpNavbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpNavbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpNavbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpNavbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpNavbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpNavbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpNavbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpNavbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpNavbar.Controls.Add(this.btnNavEmployeeList, 3, 0);
            this.tlpNavbar.Controls.Add(this.btnNavCollectorList, 2, 0);
            this.tlpNavbar.Controls.Add(this.btnNavInventory, 1, 0);
            this.tlpNavbar.Controls.Add(this.btnNavPurchaseList, 0, 0);
            this.tlpNavbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNavbar.Location = new System.Drawing.Point(0, 110);
            this.tlpNavbar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNavbar.Name = "tlpNavbar";
            this.tlpNavbar.RowCount = 1;
            this.tlpNavbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNavbar.Size = new System.Drawing.Size(1312, 62);
            this.tlpNavbar.TabIndex = 3;
            // 
            // btnNavEmployeeList
            // 
            this.btnNavEmployeeList.BackColor = System.Drawing.SystemColors.Control;
            this.btnNavEmployeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNavEmployeeList.Location = new System.Drawing.Point(997, 6);
            this.btnNavEmployeeList.Margin = new System.Windows.Forms.Padding(13, 6, 13, 6);
            this.btnNavEmployeeList.Name = "btnNavEmployeeList";
            this.btnNavEmployeeList.Size = new System.Drawing.Size(302, 50);
            this.btnNavEmployeeList.TabIndex = 3;
            this.btnNavEmployeeList.Text = "Employee List";
            this.btnNavEmployeeList.UseVisualStyleBackColor = false;
            this.btnNavEmployeeList.Click += new System.EventHandler(this.btnNavEmployeeList_Click);
            // 
            // btnNavCollectorList
            // 
            this.btnNavCollectorList.BackColor = System.Drawing.SystemColors.Control;
            this.btnNavCollectorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNavCollectorList.Location = new System.Drawing.Point(669, 6);
            this.btnNavCollectorList.Margin = new System.Windows.Forms.Padding(13, 6, 13, 6);
            this.btnNavCollectorList.Name = "btnNavCollectorList";
            this.btnNavCollectorList.Size = new System.Drawing.Size(302, 50);
            this.btnNavCollectorList.TabIndex = 2;
            this.btnNavCollectorList.Text = "Collector List";
            this.btnNavCollectorList.UseVisualStyleBackColor = false;
            this.btnNavCollectorList.Click += new System.EventHandler(this.btnNavCollectorList_Click);
            // 
            // btnNavInventory
            // 
            this.btnNavInventory.BackColor = System.Drawing.SystemColors.Control;
            this.btnNavInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNavInventory.Location = new System.Drawing.Point(341, 6);
            this.btnNavInventory.Margin = new System.Windows.Forms.Padding(13, 6, 13, 6);
            this.btnNavInventory.Name = "btnNavInventory";
            this.btnNavInventory.Size = new System.Drawing.Size(302, 50);
            this.btnNavInventory.TabIndex = 1;
            this.btnNavInventory.Text = "Inventory";
            this.btnNavInventory.UseVisualStyleBackColor = false;
            this.btnNavInventory.Click += new System.EventHandler(this.btnNavInventory_Click);
            // 
            // btnNavPurchaseList
            // 
            this.btnNavPurchaseList.BackColor = System.Drawing.SystemColors.Control;
            this.btnNavPurchaseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNavPurchaseList.Location = new System.Drawing.Point(13, 6);
            this.btnNavPurchaseList.Margin = new System.Windows.Forms.Padding(13, 6, 13, 6);
            this.btnNavPurchaseList.Name = "btnNavPurchaseList";
            this.btnNavPurchaseList.Size = new System.Drawing.Size(302, 50);
            this.btnNavPurchaseList.TabIndex = 0;
            this.btnNavPurchaseList.Text = "Purchase List";
            this.btnNavPurchaseList.UseVisualStyleBackColor = false;
            this.btnNavPurchaseList.Click += new System.EventHandler(this.btnNavPurchaseList_Click);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.Location = new System.Drawing.Point(4, 55);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(1304, 39);
            this.lblPageTitle.TabIndex = 1;
            this.lblPageTitle.Text = "[CURRENT PAGE NAME]";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMasterTitle
            // 
            this.lblMasterTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMasterTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterTitle.Location = new System.Drawing.Point(395, 0);
            this.lblMasterTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMasterTitle.Name = "lblMasterTitle";
            this.lblMasterTitle.Size = new System.Drawing.Size(521, 44);
            this.lblMasterTitle.TabIndex = 0;
            this.lblMasterTitle.Text = "Britannicus Reading Room";
            this.lblMasterTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpFooter
            // 
            this.tlpFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(35)))));
            this.tlpFooter.ColumnCount = 5;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFooter.Controls.Add(this.btnLogout, 0, 0);
            this.tlpFooter.Controls.Add(this.btnExit, 0, 0);
            this.tlpFooter.Controls.Add(this.btnBack, 3, 0);
            this.tlpFooter.Controls.Add(this.btnBackToMainMenu, 4, 0);
            this.tlpFooter.Controls.Add(this.rtxtStatus, 2, 0);
            this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFooter.Location = new System.Drawing.Point(0, 999);
            this.tlpFooter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(1312, 62);
            this.tlpFooter.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSize = true;
            this.btnLogout.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(200, 6);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(117, 50);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Visible = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(7, 6);
            this.btnExit.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(179, 50);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit Program";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(922, 6);
            this.btnBack.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(117, 50);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnBackToMainMenu
            // 
            this.btnBackToMainMenu.AutoSize = true;
            this.btnBackToMainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.btnBackToMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBackToMainMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToMainMenu.Location = new System.Drawing.Point(1053, 6);
            this.btnBackToMainMenu.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnBackToMainMenu.Name = "btnBackToMainMenu";
            this.btnBackToMainMenu.Size = new System.Drawing.Size(252, 50);
            this.btnBackToMainMenu.TabIndex = 5;
            this.btnBackToMainMenu.Text = "Back to Main Menu";
            this.btnBackToMainMenu.UseVisualStyleBackColor = false;
            this.btnBackToMainMenu.Click += new System.EventHandler(this.btnBackToMainMenu_Click);
            // 
            // rtxtStatus
            // 
            this.rtxtStatus.BackColor = System.Drawing.Color.Yellow;
            this.rtxtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtStatus.Location = new System.Drawing.Point(328, 4);
            this.rtxtStatus.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtStatus.Name = "rtxtStatus";
            this.rtxtStatus.ReadOnly = true;
            this.rtxtStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtStatus.Size = new System.Drawing.Size(583, 54);
            this.rtxtStatus.TabIndex = 6;
            this.rtxtStatus.TabStop = false;
            this.rtxtStatus.Text = "";
            // 
            // MasterForm
            // 
            this.AcceptButton = this.btnNavInventory;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(1312, 1061);
            this.Controls.Add(this.tlpMasterLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1325, 726);
            this.Name = "MasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tlpMasterLayout.ResumeLayout(false);
            this.tlpMasterLayout.PerformLayout();
            this.tlpHeader.ResumeLayout(false);
            this.tlpNavbar.ResumeLayout(false);
            this.tlpFooter.ResumeLayout(false);
            this.tlpFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblMasterTitle;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.TableLayoutPanel tlpNavbar;
        private System.Windows.Forms.Button btnExit;
        protected System.Windows.Forms.TableLayoutPanel tlpMasterLayout;
        private System.Windows.Forms.Button btnNavPurchaseList;
        private System.Windows.Forms.Button btnNavInventory;
        private System.Windows.Forms.Button btnNavEmployeeList;
        private System.Windows.Forms.Button btnNavCollectorList;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnBackToMainMenu;
        protected System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RichTextBox rtxtStatus;
    }
}

