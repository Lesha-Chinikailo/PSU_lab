
namespace lab_3
{
    partial class Show
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCancel = new Button();
            labName = new Label();
            labDisplacement = new Label();
            labShipType = new Label();
            labCabinCategories = new Label();
            CBShipNames = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 102);
            label1.Name = "label1";
            label1.Size = new Size(60, 25);
            label1.TabIndex = 0;
            label1.Text = "name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 168);
            label2.Name = "label2";
            label2.Size = new Size(126, 25);
            label2.TabIndex = 2;
            label2.Text = "displacement: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 241);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 4;
            label3.Text = "ship type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 358);
            label4.Name = "label4";
            label4.Size = new Size(142, 25);
            label4.TabIndex = 6;
            label4.Text = "cabinCategories:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(193, 499);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(156, 77);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // labName
            // 
            labName.AutoSize = true;
            labName.Location = new Point(221, 102);
            labName.Name = "labName";
            labName.Size = new Size(59, 25);
            labName.TabIndex = 11;
            labName.Text = "label5";
            // 
            // labDisplacement
            // 
            labDisplacement.AutoSize = true;
            labDisplacement.Location = new Point(221, 168);
            labDisplacement.Name = "labDisplacement";
            labDisplacement.Size = new Size(59, 25);
            labDisplacement.TabIndex = 12;
            labDisplacement.Text = "label6";
            // 
            // labShipType
            // 
            labShipType.AutoSize = true;
            labShipType.Location = new Point(221, 241);
            labShipType.Name = "labShipType";
            labShipType.Size = new Size(59, 25);
            labShipType.TabIndex = 13;
            labShipType.Text = "label7";
            // 
            // labCabinCategories
            // 
            labCabinCategories.AutoSize = true;
            labCabinCategories.Location = new Point(221, 358);
            labCabinCategories.Name = "labCabinCategories";
            labCabinCategories.Size = new Size(59, 25);
            labCabinCategories.TabIndex = 14;
            labCabinCategories.Text = "label8";
            // 
            // CBShipNames
            // 
            CBShipNames.FormattingEnabled = true;
            CBShipNames.Location = new Point(172, 28);
            CBShipNames.Name = "CBShipNames";
            CBShipNames.Size = new Size(247, 33);
            CBShipNames.TabIndex = 15;
            CBShipNames.SelectedIndexChanged += CBShipNames_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(56, 31);
            label5.Name = "label5";
            label5.Size = new Size(98, 25);
            label5.TabIndex = 16;
            label5.Text = "name ship:";
            label5.Click += label5_Click;
            // 
            // Show
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 628);
            Controls.Add(label5);
            Controls.Add(CBShipNames);
            Controls.Add(labCabinCategories);
            Controls.Add(labShipType);
            Controls.Add(labDisplacement);
            Controls.Add(labName);
            Controls.Add(btnCancel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Show";
            Text = "Show";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnCancel;
        private Label labName;
        private Label labDisplacement;
        private Label labShipType;
        private Label labCabinCategories;
        private ComboBox CBShipNames;
        private Label label5;
    }
}