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
            this.codeWindow = new System.Windows.Forms.RichTextBox();
            this.console = new System.Windows.Forms.RichTextBox();
            this.commandLine = new System.Windows.Forms.TextBox();
            this.paintWindow = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeWindow
            // 
            this.codeWindow.Location = new System.Drawing.Point(12, 27);
            this.codeWindow.Name = "codeWindow";
            this.codeWindow.Size = new System.Drawing.Size(323, 309);
            this.codeWindow.TabIndex = 0;
            this.codeWindow.Text = "";
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(12, 368);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(323, 70);
            this.console.TabIndex = 2;
            this.console.Text = "";
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(12, 342);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(239, 20);
            this.commandLine.TabIndex = 3;
            // 
            // paintWindow
            // 
            this.paintWindow.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.paintWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paintWindow.Location = new System.Drawing.Point(341, 27);
            this.paintWindow.Name = "paintWindow";
            this.paintWindow.Size = new System.Drawing.Size(447, 411);
            this.paintWindow.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.paintWindow);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.console);
            this.Controls.Add(this.codeWindow);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Drawing";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeWindow;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.TextBox commandLine;
        private System.Windows.Forms.Panel paintWindow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    }
}

