using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApplication
{
    public class EditTagsScreen : Screen
    {
        private TableLayoutPanel tlpTagsPanel;
        private TextBox txtEditTagName;
        private TextBox txtCreateTagName;
        private RadioButton rbSelectedTag;
        private Button btnUpdateTag;

        public EditTagsScreen(Screen backScreen) : base("Edit Tags", backScreen, 1, 2)
        {
            #region Init
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.Transparent;
            this.ColumnCount = 2;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.RowCount = 2;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.ParentChanged += EditTagsScreen_ParentChanged;
            #endregion

            #region Controls
            TableLayoutPanel tlpMainTagsPanel = new TableLayoutPanel();
            tlpMainTagsPanel.Dock = DockStyle.Fill;
            tlpMainTagsPanel.ColumnCount = 1;
            tlpMainTagsPanel.RowCount = 2;
            tlpMainTagsPanel.BackColor = Screen.PrimaryColor;
            tlpTagsPanel = new TableLayoutPanel();
            tlpTagsPanel.Dock = DockStyle.Fill;
            tlpTagsPanel.ColumnCount = 6;
            tlpTagsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            tlpTagsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            tlpTagsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            tlpTagsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            tlpTagsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            tlpTagsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8F));
            tlpTagsPanel.BackColor = Color.White;
            
            tlpTagsPanel.Margin = new Padding(10, 10, 10, 10);
            tlpTagsPanel.AutoScroll = true;

            Label lblMainTagsTitle = new Label();
            lblMainTagsTitle.Text = "Tags";
            tlpMainTagsPanel.Controls.Add(lblMainTagsTitle, 0, 0);
            tlpMainTagsPanel.SetColumnSpan(lblMainTagsTitle, 2);
            lblMainTagsTitle.Dock = DockStyle.Fill;
            lblMainTagsTitle.Anchor = AnchorStyles.Left & AnchorStyles.Right;

            DBControlHelper.PopulateWithControls<DBTag, RadioButton>(tlpTagsPanel, DBTag.GetTags(), "Description", "ID");
            foreach(Control c in tlpTagsPanel.Controls)
            {
                if(c is RadioButton)
                {
                    (c as RadioButton).CheckedChanged += Tag_CheckedChanged;
                }
            }
            tlpMainTagsPanel.Controls.Add(tlpTagsPanel, 0, 1);

            TableLayoutPanel tlpCreateTag = new TableLayoutPanel();
            tlpCreateTag.Dock = DockStyle.Fill;
            tlpCreateTag.BackColor = Color.White;
            tlpCreateTag.Margin = new Padding(10, 10, 10, 10);
            tlpCreateTag.ColumnCount = 3;
            tlpCreateTag.RowCount = 2;
            tlpCreateTag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpCreateTag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpCreateTag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            tlpCreateTag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpCreateTag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpCreateTag.Padding = new Padding(10, 10, 10, 10);

            Label lblCreateTagPrompt = new Label();
            lblCreateTagPrompt.Text = "Create New Tag";
            tlpCreateTag.Controls.Add(lblCreateTagPrompt, 0, 0);
            tlpCreateTag.SetColumnSpan(lblCreateTagPrompt, 3);
            lblCreateTagPrompt.Dock = DockStyle.Fill;
            lblCreateTagPrompt.Anchor = AnchorStyles.Left & AnchorStyles.Right;

            Label lblCreateTagNamePrompt = new Label();
            lblCreateTagNamePrompt.Text = "Tag Name:";
            lblCreateTagNamePrompt.Dock = DockStyle.None;
            lblCreateTagNamePrompt.Anchor = AnchorStyles.Right;

            txtCreateTagName = new TextBox();
            txtCreateTagName.Dock = DockStyle.None;
            txtCreateTagName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCreateTagName.MaxLength = DBControlHelper.MaximumTagNameLength;
            tlpCreateTag.Controls.Add(txtCreateTagName, 1, 1);

            Button btnAddTag = new Button();
            btnAddTag.Text = "Add";
            btnAddTag.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnAddTag.AutoSize = true;
            btnAddTag.Margin = new Padding(10, 0, 0, 0);
            btnAddTag.Click += BtnAddTag_Click;
            btnAddTag.BackColor = DefaultBackColor;
            tlpCreateTag.Controls.Add(btnAddTag, 2, 1);

            TableLayoutPanel tlpEditTag = new TableLayoutPanel();
            tlpEditTag.Dock = DockStyle.Fill;
            tlpEditTag.BackColor = Color.White;
            tlpEditTag.Margin = new Padding(10, 10, 10, 10);
            tlpEditTag.ColumnCount = 4;
            tlpEditTag.RowCount = 2;
            tlpEditTag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            tlpEditTag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tlpEditTag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tlpEditTag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tlpEditTag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpEditTag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpEditTag.Padding = new Padding(10, 10, 10, 10);

            Label lblEditTagPrompt = new Label();
            lblEditTagPrompt.Text = "Edit Selected Tag";
            tlpEditTag.Controls.Add(lblEditTagPrompt, 0, 0);
            tlpEditTag.SetColumnSpan(lblEditTagPrompt, 4);
            lblEditTagPrompt.Dock = DockStyle.Fill;
            lblEditTagPrompt.Anchor = AnchorStyles.Left & AnchorStyles.Right;

            Label lblEditTagNamePrompt = new Label();
            lblEditTagNamePrompt.Text = "Tag Name:";
            lblEditTagNamePrompt.Dock = DockStyle.None;
            lblEditTagNamePrompt.Anchor = AnchorStyles.Right;

            txtEditTagName = new TextBox();
            txtEditTagName.Dock = DockStyle.None;
            txtEditTagName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEditTagName.MaxLength = DBControlHelper.MaximumTagNameLength;
            tlpEditTag.Controls.Add(txtEditTagName, 1, 1);

            btnUpdateTag = new Button();
            btnUpdateTag.Text = "Update";
            btnUpdateTag.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnUpdateTag.AutoSize = true;
            btnUpdateTag.Margin = new Padding(10, 0, 0, 0);
            btnUpdateTag.Click += BtnUpdateTag_Click;
            btnUpdateTag.BackColor = DefaultBackColor;
            tlpEditTag.Controls.Add(btnUpdateTag, 2, 1);

            Button btnDeactivateTag = new Button();
            btnDeactivateTag.Text = "Deactivate";
            btnDeactivateTag.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnDeactivateTag.AutoSize = true;
            btnDeactivateTag.BackColor = DefaultBackColor;
            btnDeactivateTag.Click += BtnDeactivateTag_Click;
            tlpEditTag.Controls.Add(btnDeactivateTag, 3, 1);

            tlpCreateTag.Controls.Add(lblCreateTagNamePrompt, 0, 1);
            tlpEditTag.Controls.Add(lblEditTagNamePrompt, 0, 1);

            this.Controls.Add(tlpMainTagsPanel, 0, 0);
            this.SetColumnSpan(tlpMainTagsPanel, 2);
            this.Controls.Add(tlpCreateTag, 0, 1);
            this.Controls.Add(tlpEditTag, 1, 1);
            #endregion

            this.SetFontSizes(this.Controls);
        }

        private void EditTagsScreen_ParentChanged(object sender, EventArgs e)
        {
            if(this.Parent != null)
            {
                MasterForm master = (this.Parent.Parent as MasterForm);
                master.AcceptButton = btnUpdateTag;
                master.CancelButton = (master.Controls.Find("btnBack", true)[0] as Button);
            }
        }

        private void BtnUpdateTag_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);

            string tagName = this.txtEditTagName.Text.Trim();

            try
            {
                string status = "";

                if (this.txtEditTagName.Tag != null)
                {
                    if (this.tagExists(tagName))
                    {
                        status += "A tag with this name already exists." + Environment.NewLine;
                    }
                    else if (String.IsNullOrEmpty(status = DBTag.Validate(tagName)))
                    {
                        if (DBTag.UpdateTag(Int32.Parse(this.txtEditTagName.Tag.ToString()), tagName))
                        {
                            status += "Tag \"" + this.rbSelectedTag.Text + "\" has been updated successfully" + Environment.NewLine;
                            rbSelectedTag.Text = tagName;
                        }
                    }
                }
                else
                {
                    status += "A tag must be selected." + Environment.NewLine;
                }

                master.SetStatus(status);
            }
            catch(Exception ex)
            {
                master.SetStatus("Error! Failed to update tag: " + ex.Message);
            }
            
        }

        private void BtnDeactivateTag_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);
            if(this.txtEditTagName.Tag != null)
            {
                if(DBTag.DeactivateTag(Int32.Parse(this.txtEditTagName.Tag.ToString())))
                {
                    master.SetStatus("Tag \"" + this.rbSelectedTag.Text + "\" has been deactivated successfully");
                    this.tlpTagsPanel.Controls.Remove(this.rbSelectedTag);
                }
            }
            else
            {
                master.SetStatus("Error! A tag must be selected");
            }
        }

        private void BtnAddTag_Click(object sender, EventArgs e)
        {
            MasterForm master = (this.Parent.Parent as MasterForm);

            try
            {
                string tagName = this.txtCreateTagName.Text.Trim();

                string status = "";

                if (tagExists(tagName))
                {
                    status = "A tag with this name already exists." + Environment.NewLine;
                }
                else if (String.IsNullOrEmpty(status = DBTag.Validate(tagName)))
                {
                    object result = DBTag.InsertTag(tagName);

                    if (result != null)
                    {
                        status = "Tag \"" + tagName + "\" has been added successfully" + Environment.NewLine;
                        RadioButton rbTemp = new RadioButton()
                        {
                            Text = tagName,
                            Tag = Int32.Parse(result.ToString())
                        };
                        rbTemp.CheckedChanged += Tag_CheckedChanged;

                        this.tlpTagsPanel.Controls.Add(rbTemp);
                    }

                }

                master.SetStatus(status);
            }
            catch(Exception ex)
            {
                master.SetStatus("Error! Failed to add tag: " + ex.Message);
            }
            
        }

        private bool tagExists(string desc)
        {
            bool tagExists = false;
            foreach (Control c in this.tlpTagsPanel.Controls)
            {
                if (c.Text == desc)
                {
                    tagExists = true;

                }
            }

            return tagExists;
        }

        private void Tag_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as RadioButton).Checked)
            {
                this.rbSelectedTag = (sender as RadioButton);
                this.txtEditTagName.Text = this.rbSelectedTag.Text;
                this.txtEditTagName.Tag = this.rbSelectedTag.Tag;
            }
        }
    }
}
