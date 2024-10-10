namespace lab_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listShips = new ListBox();
            menuStrip1 = new MenuStrip();
            addToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuAdd = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            showToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonShow = new ToolStripButton();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listShips
            // 
            listShips.FormattingEnabled = true;
            listShips.ItemHeight = 25;
            listShips.Location = new Point(120, 80);
            listShips.Name = "listShips";
            listShips.Size = new Size(1077, 529);
            listShips.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1209, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuAdd, editToolStripMenuItem, deleteToolStripMenuItem, showToolStripMenuItem });
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(61, 29);
            addToolStripMenuItem.Text = "ship";
            // 
            // addToolStripMenuAdd
            // 
            addToolStripMenuAdd.Name = "addToolStripMenuAdd";
            addToolStripMenuAdd.Size = new Size(162, 34);
            addToolStripMenuAdd.Text = "add";
            addToolStripMenuAdd.Click += addToolStripMenuAdd_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(162, 34);
            editToolStripMenuItem.Text = "edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(162, 34);
            deleteToolStripMenuItem.Text = "delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(162, 34);
            showToolStripMenuItem.Text = "show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 80);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 2;
            label1.Text = "List ships:";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonShow });
            toolStrip1.Location = new Point(0, 33);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1209, 33);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonAdd.Image = (Image)resources.GetObject("toolStripButtonAdd.Image");
            toolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new Size(34, 28);
            toolStripButtonAdd.Text = "add";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEdit.Image = (Image)resources.GetObject("toolStripButtonEdit.Image");
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(34, 28);
            toolStripButtonEdit.Text = "edit";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDelete.Image = (Image)resources.GetObject("toolStripButtonDelete.Image");
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(34, 28);
            toolStripButtonDelete.Text = "delete";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // toolStripButtonShow
            // 
            toolStripButtonShow.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonShow.Image = (Image)resources.GetObject("toolStripButtonShow.Image");
            toolStripButtonShow.ImageTransparentColor = Color.Magenta;
            toolStripButtonShow.Name = "toolStripButtonShow";
            toolStripButtonShow.Size = new Size(34, 28);
            toolStripButtonShow.Text = "show";
            toolStripButtonShow.Click += toolStripButtonShow_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 666);
            Controls.Add(toolStrip1);
            Controls.Add(label1);
            Controls.Add(listShips);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listShips;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuAdd;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
        private Label label1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonShow;
    }
}
