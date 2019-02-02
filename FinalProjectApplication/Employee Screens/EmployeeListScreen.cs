using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class EmployeeListScreen : Screen
    {
        private System.Windows.Forms.TableLayoutPanel tlpSearchBar;
        private System.Windows.Forms.Label lblSearchPrompt;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label lblSelectedEmployeePrompt;
        private System.Windows.Forms.ComboBox cbxSelectedEmployee;
        private System.Windows.Forms.TableLayoutPanel tlpEditOptions;
        private System.Windows.Forms.Label lblEditOptionsPrompt;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnUpdateEmployee;
        private System.Windows.Forms.Button btnRemoveEmployee;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.MaskedTextBox mtxtPhoneNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhoneNumPrompt;
        private BindingList<DBEmployee> employees;

        public EmployeeListScreen(Screen backScreen) : base("Employee List", backScreen, 1)
        {
            #region Instantiate Controls
            this.tlpSearchBar = new System.Windows.Forms.TableLayoutPanel();
            this.lblSelectedEmployeePrompt = new System.Windows.Forms.Label();
            this.lblSearchPrompt = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.cbxSelectedEmployee = new System.Windows.Forms.ComboBox();
            this.tlpEditOptions = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.btnRemoveEmployee = new System.Windows.Forms.Button();
            this.lblEditOptionsPrompt = new System.Windows.Forms.Label();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.mtxtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblPhoneNumPrompt = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            #endregion

            #region Init Screen
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(this.tlpSearchBar, 0, 1);
            this.Controls.Add(this.tlpEditOptions, 0, 0);
            this.Controls.Add(this.dgvEmployees, 0, 2);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowCount = 3;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TabIndex = 0;
            this.ParentChanged += EmployeeListScreen_ParentChanged;
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
            this.tlpSearchBar.Controls.Add(this.lblSelectedEmployeePrompt, 3, 0);
            this.tlpSearchBar.Controls.Add(this.lblSearchPrompt, 0, 0);
            this.tlpSearchBar.Controls.Add(this.cbxSelectedEmployee, 4, 0);
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
            // lblSelectedEmployeePrompt
            // 
            this.lblSelectedEmployeePrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSelectedEmployeePrompt.AutoSize = true;
            //this.lblSelectedEmployeePrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearchBar.SetRowSpan(this.lblSelectedEmployeePrompt, 2);
            this.lblSelectedEmployeePrompt.TabIndex = 3;
            this.lblSelectedEmployeePrompt.Text = "Selected Employee:";
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
            // txtSearchInput
            // 
            this.txtSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtSearchName.TabIndex = 1;
            this.txtSearchName.MaxLength = DBControlHelper.MaximumFullNameLength;
            this.txtSearchName.TextChanged += Search_TextChanged;
            // 
            // cbxSelectedEmployee
            // 
            this.cbxSelectedEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectedEmployee.FormattingEnabled = true;
            this.cbxSelectedEmployee.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.tlpSearchBar.SetRowSpan(this.cbxSelectedEmployee, 2);
            this.cbxSelectedEmployee.TabIndex = 4;
            this.cbxSelectedEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // tlpEditOptions
            // 
            this.tlpEditOptions.BackColor = System.Drawing.Color.White;
            this.tlpEditOptions.ColumnCount = 6;
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpEditOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpEditOptions.Controls.Add(this.btnUpdateEmployee, 4, 0);
            this.tlpEditOptions.Controls.Add(this.btnRemoveEmployee, 3, 0);
            this.tlpEditOptions.Controls.Add(this.lblEditOptionsPrompt, 1, 0);
            this.tlpEditOptions.Controls.Add(this.btnAddEmployee, 2, 0);
            this.tlpEditOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEditOptions.RowCount = 1;
            this.tlpEditOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEditOptions.TabIndex = 1;
            this.tlpEditOptions.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.tlpEditOptions.AutoSize = true;
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.Dock = System.Windows.Forms.DockStyle.None;
            this.btnUpdateEmployee.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnUpdateEmployee.TabIndex = 4;
            this.btnUpdateEmployee.Text = "Update Employee";
            this.btnUpdateEmployee.AutoSize = true;
            this.btnUpdateEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnUpdateEmployee.UseVisualStyleBackColor = true;
            this.btnUpdateEmployee.BackColor = DefaultBackColor;
            this.btnUpdateEmployee.Click += BtnUpdateEmployee_Click;
            // 
            // btnRemoveEmployee
            // 
            this.btnRemoveEmployee.Dock = System.Windows.Forms.DockStyle.None;
            this.btnRemoveEmployee.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnRemoveEmployee.TabIndex = 3;
            this.btnRemoveEmployee.Text = "Remove Employee";
            this.btnRemoveEmployee.AutoSize = true;
            this.btnRemoveEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnRemoveEmployee.UseVisualStyleBackColor = true;
            this.btnRemoveEmployee.BackColor = DefaultBackColor;
            this.btnRemoveEmployee.Click += BtnRemoveEmployee_Click;
            // 
            // lblEditOptionsPrompt
            // 
            this.lblEditOptionsPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblEditOptionsPrompt.AutoSize = true;
            //this.lblEditOptionsPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditOptionsPrompt.TabIndex = 1;
            this.lblEditOptionsPrompt.Text = "Edit Options";
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Dock = System.Windows.Forms.DockStyle.None;
            this.btnAddEmployee.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnAddEmployee.TabIndex = 2;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.AutoSize = true;
            this.btnAddEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.BackColor = DefaultBackColor;
            this.btnAddEmployee.Click += BtnAddEmployee_Click;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployees.TabIndex = 2;
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // mtxtPhoneNumber
            // 
            this.mtxtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtxtPhoneNumber.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.mtxtPhoneNumber.Mask = "(000) 000-0000";
            this.mtxtPhoneNumber.TabIndex = 5;
            this.mtxtPhoneNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
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
            this.dgvEmployees.DataSourceChanged += DgvEmployees_DataSourceChanged;

            this.cbxSelectedEmployee.DisplayMember = "ComboBoxDisplay";
            this.cbxSelectedEmployee.ValueMember = "EmployeeID";

            this.SetFontSizes(this.Controls);
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            this.FilterEmployees(this.txtSearchName.Text, this.mtxtPhoneNumber.Text);
        }

        #region Methods
        private void ReloadData()
        {
            this.employees = DBEmployee.GetEmployees();
            //this.txtSearchName.DataBindings.Clear();
            //this.mtxtPhoneNumber.DataBindings.Clear();
            this.dgvEmployees.DataSource = this.employees;
            this.cbxSelectedEmployee.DataSource = this.employees;
            //this.txtSearchName.DataBindings.Add("Text", this.employees, "FullName", true, System.Windows.Forms.DataSourceUpdateMode.Never);
            //this.mtxtPhoneNumber.DataBindings.Add("Text", this.employees, "PhoneNumber", true, System.Windows.Forms.DataSourceUpdateMode.Never);
        }
        private void FilterEmployees(string name, string phoneNumber)
        {
            BindingList<DBEmployee> filteredEmployees = new BindingList<DBEmployee>();
            foreach (DBEmployee c in this.employees)
            {
                if (c.FullName.ToLower().Contains(name.Trim().ToLower()) && DBEmployee.IsPhoneNumberMatching(c.PhoneNumber, this.mtxtPhoneNumber.Text))
                {
                    filteredEmployees.Add(c);
                }
            }
            this.dgvEmployees.DataSource = filteredEmployees;
            this.cbxSelectedEmployee.DataSource = filteredEmployees;
        }
        #endregion

        #region Event Handlers
        private void DgvEmployees_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvEmployees.Columns["EmployeeID"].HeaderText = "Employee ID";
            this.dgvEmployees.Columns["PositionID"].Visible = false;
            this.dgvEmployees.Columns["PositionName"].HeaderText = "Position";
            this.dgvEmployees.Columns["FirstName"].Visible = false;
            this.dgvEmployees.Columns["LastName"].Visible = false;
            this.dgvEmployees.Columns["FullName"].HeaderText = "Name";
            this.dgvEmployees.Columns["PhoneNumber"].HeaderText = "Phone Number";
            this.dgvEmployees.Columns["ComboBoxDisplay"].Visible = false;
        }

        private void BtnRemoveEmployee_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            if (this.cbxSelectedEmployee.SelectedItem is DBEmployee)
            {
                try
                {
                    DBEmployee tempEmployee = (this.cbxSelectedEmployee.SelectedItem as DBEmployee);

                    //Attempt to delete from the database
                    if (tempEmployee.Delete())
                    {
                        //Deletion successful

                        master.SetStatus("Employee " + tempEmployee.FullName + " has been deleted.");

                        //Remove all related datagridview rows
                        for (var i = 0; i < this.dgvEmployees.Rows.Count; i++)
                        {
                            if ((int)this.dgvEmployees.Rows[i].Cells["EmployeeID"].Value == tempEmployee.EmployeeID)
                            {
                                this.dgvEmployees.Rows.RemoveAt(i);
                            }
                        }
                        this.employees.Remove(tempEmployee);
                    }
                }
                catch (Exception ex)
                {
                    master.SetStatus("Error! Deletion failed: " + ex.Message);
                }
            }
            else
            {
                master.SetStatus("Error! You must select an employee to remove");
            }
        }

        private void EmployeeListScreen_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnUpdateEmployee;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);

                this.ReloadData();
            }
        }

        private void BtnUpdateEmployee_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.screenUpdateEmployee.SetEmployee((int)this.cbxSelectedEmployee.SelectedValue, this.employees.Last().EmployeeID);
            master.SetScreen(master.screenUpdateEmployee, true);
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            master.SetScreen(master.screenAddEmployee, true);
        }
        #endregion
    }
}
