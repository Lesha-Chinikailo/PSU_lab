namespace lab_3
{
    partial class Add
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
            label1 = new Label();
            txbName = new TextBox();
            txbDisplacement = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCancel = new Button();
            btnAccept = new Button();
            checkedListBox = new CheckedListBox();
            RBCargoShip = new RadioButton();
            RBPassengerShip = new RadioButton();
            RBIndustrialShip = new RadioButton();
            GroupShipTypes = new GroupBox();
            GroupShipTypes.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 54);
            label1.Name = "label1";
            label1.Size = new Size(60, 25);
            label1.TabIndex = 0;
            label1.Text = "name:";
            // 
            // txbName
            // 
            txbName.Location = new Point(174, 51);
            txbName.Name = "txbName";
            txbName.Size = new Size(353, 31);
            txbName.TabIndex = 1;
            // 
            // txbDisplacement
            // 
            txbDisplacement.Location = new Point(174, 120);
            txbDisplacement.Name = "txbDisplacement";
            txbDisplacement.Size = new Size(353, 31);
            txbDisplacement.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 120);
            label2.Name = "label2";
            label2.Size = new Size(126, 25);
            label2.TabIndex = 2;
            label2.Text = "displacement: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 193);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 4;
            label3.Text = "ship type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 371);
            label4.Name = "label4";
            label4.Size = new Size(142, 25);
            label4.TabIndex = 6;
            label4.Text = "cabinCategories:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(71, 516);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(156, 77);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(343, 516);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(156, 77);
            btnAccept.TabIndex = 10;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // checkedListBox
            // 
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Items.AddRange(new object[] { "InsideCabin", "OutsideCabinWithWindow", "OutsideCabinWithBalcony", "Luxury" });
            checkedListBox.Location = new Point(174, 371);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(232, 116);
            checkedListBox.TabIndex = 11;
            // 
            // RBCargoShip
            // 
            RBCargoShip.AutoSize = true;
            RBCargoShip.Location = new Point(22, 18);
            RBCargoShip.Name = "RBCargoShip";
            RBCargoShip.Size = new Size(120, 29);
            RBCargoShip.TabIndex = 12;
            RBCargoShip.TabStop = true;
            RBCargoShip.Text = "CargoShip";
            RBCargoShip.UseVisualStyleBackColor = true;
            RBCargoShip.CheckedChanged += RBCargoShip_CheckedChanged;
            // 
            // RBPassengerShip
            // 
            RBPassengerShip.AutoSize = true;
            RBPassengerShip.Location = new Point(22, 57);
            RBPassengerShip.Name = "RBPassengerShip";
            RBPassengerShip.Size = new Size(151, 29);
            RBPassengerShip.TabIndex = 13;
            RBPassengerShip.TabStop = true;
            RBPassengerShip.Text = "PassengerShip";
            RBPassengerShip.UseVisualStyleBackColor = true;
            RBPassengerShip.CheckedChanged += RBPassengerShip_CheckedChanged;
            // 
            // RBIndustrialShip
            // 
            RBIndustrialShip.AutoSize = true;
            RBIndustrialShip.Location = new Point(22, 92);
            RBIndustrialShip.Name = "RBIndustrialShip";
            RBIndustrialShip.Size = new Size(145, 29);
            RBIndustrialShip.TabIndex = 14;
            RBIndustrialShip.TabStop = true;
            RBIndustrialShip.Text = "IndustrialShip";
            RBIndustrialShip.UseVisualStyleBackColor = true;
            RBIndustrialShip.CheckedChanged += RBIndustrialShip_CheckedChanged;
            // 
            // GroupShipTypes
            // 
            GroupShipTypes.Controls.Add(RBCargoShip);
            GroupShipTypes.Controls.Add(RBIndustrialShip);
            GroupShipTypes.Controls.Add(RBPassengerShip);
            GroupShipTypes.Location = new Point(174, 167);
            GroupShipTypes.Name = "GroupShipTypes";
            GroupShipTypes.Size = new Size(300, 130);
            GroupShipTypes.TabIndex = 15;
            GroupShipTypes.TabStop = false;
            // 
            // Add
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 628);
            Controls.Add(GroupShipTypes);
            Controls.Add(checkedListBox);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txbDisplacement);
            Controls.Add(label2);
            Controls.Add(txbName);
            Controls.Add(label1);
            Name = "Add";
            Text = "Add";
            Load += Add_Load;
            GroupShipTypes.ResumeLayout(false);
            GroupShipTypes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txbName;
        private TextBox txbDisplacement;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnCancel;
        private Button btnAccept;
        private CheckedListBox checkedListBox;
        private RadioButton RBCargoShip;
        private RadioButton RBPassengerShip;
        private RadioButton RBIndustrialShip;
        private GroupBox GroupShipTypes;
    }
}