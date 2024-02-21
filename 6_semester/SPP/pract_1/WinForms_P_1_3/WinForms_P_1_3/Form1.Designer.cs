namespace WinForms_P_1_3
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label_text = new Label();
            textBox1 = new TextBox();
            btn_getText = new Button();
            btn_loadFile = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(206, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(582, 370);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(245, 413);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "get image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label_text
            // 
            label_text.AutoSize = true;
            label_text.Location = new Point(206, 9);
            label_text.Name = "label_text";
            label_text.Size = new Size(59, 25);
            label_text.TabIndex = 2;
            label_text.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 37);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(188, 370);
            textBox1.TabIndex = 3;
            // 
            // btn_getText
            // 
            btn_getText.Location = new Point(363, 413);
            btn_getText.Name = "btn_getText";
            btn_getText.Size = new Size(112, 34);
            btn_getText.TabIndex = 4;
            btn_getText.Text = "get text";
            btn_getText.UseVisualStyleBackColor = true;
            btn_getText.Click += btn_getText_Click;
            // 
            // btn_loadFile
            // 
            btn_loadFile.Location = new Point(481, 413);
            btn_loadFile.Name = "btn_loadFile";
            btn_loadFile.Size = new Size(152, 34);
            btn_loadFile.TabIndex = 5;
            btn_loadFile.Text = "download json";
            btn_loadFile.UseVisualStyleBackColor = true;
            btn_loadFile.Click += btn_loadFile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_loadFile);
            Controls.Add(btn_getText);
            Controls.Add(textBox1);
            Controls.Add(label_text);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Label label_text;
        private TextBox textBox1;
        private Button btn_getText;
        private Button btn_loadFile;
    }
}
