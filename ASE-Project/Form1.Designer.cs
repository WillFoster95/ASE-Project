namespace ASE_Project
{
    partial class Form1
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
            this.codeArea = new System.Windows.Forms.RichTextBox();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.singleCommandLine = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // codeArea
            // 
            this.codeArea.Location = new System.Drawing.Point(12, 12);
            this.codeArea.Name = "codeArea";
            this.codeArea.Size = new System.Drawing.Size(407, 324);
            this.codeArea.TabIndex = 0;
            this.codeArea.Text = "";
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(12, 368);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(407, 70);
            this.consoleBox.TabIndex = 2;
            this.consoleBox.Text = "";
            // 
            // singleCommandLine
            // 
            this.singleCommandLine.Location = new System.Drawing.Point(12, 342);
            this.singleCommandLine.Name = "singleCommandLine";
            this.singleCommandLine.Size = new System.Drawing.Size(407, 20);
            this.singleCommandLine.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.singleCommandLine);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.codeArea);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeArea;
        private System.Windows.Forms.RichTextBox consoleBox;
        private System.Windows.Forms.TextBox singleCommandLine;
    }
}

