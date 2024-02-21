namespace WinFormsGet
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
            btn_downloadFile = new Button();
            SuspendLayout();
            // 
            // btn_downloadFile
            // 
            btn_downloadFile.Location = new Point(617, 404);
            btn_downloadFile.Name = "btn_downloadFile";
            btn_downloadFile.Size = new Size(171, 34);
            btn_downloadFile.TabIndex = 0;
            btn_downloadFile.Text = "download file";
            btn_downloadFile.UseVisualStyleBackColor = true;
            btn_downloadFile.Click += btn_downloadFile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_downloadFile);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_downloadFile;
    }
}
