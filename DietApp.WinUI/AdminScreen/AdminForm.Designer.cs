namespace DietApp.WinUI.AdminScreen
{
    partial class AdminForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yemekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öğünToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.kategoriToolStripMenuItem,
            this.yemekToolStripMenuItem,
            this.öğünToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.userToolStripMenuItem.Tag = "1";
            this.userToolStripMenuItem.Text = "Kullanıcı";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.Click);
            // 
            // kategoriToolStripMenuItem
            // 
            this.kategoriToolStripMenuItem.Name = "kategoriToolStripMenuItem";
            this.kategoriToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.kategoriToolStripMenuItem.Tag = "2";
            this.kategoriToolStripMenuItem.Text = "Kategori";
            this.kategoriToolStripMenuItem.Click += new System.EventHandler(this.Click);
            // 
            // yemekToolStripMenuItem
            // 
            this.yemekToolStripMenuItem.Name = "yemekToolStripMenuItem";
            this.yemekToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.yemekToolStripMenuItem.Tag = "3";
            this.yemekToolStripMenuItem.Text = "Yemek";
            this.yemekToolStripMenuItem.Click += new System.EventHandler(this.Click);
            // 
            // öğünToolStripMenuItem
            // 
            this.öğünToolStripMenuItem.Name = "öğünToolStripMenuItem";
            this.öğünToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.öğünToolStripMenuItem.Tag = "4";
            this.öğünToolStripMenuItem.Text = "Öğün";
            this.öğünToolStripMenuItem.Click += new System.EventHandler(this.Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem userToolStripMenuItem;
        private ToolStripMenuItem kategoriToolStripMenuItem;
        private ToolStripMenuItem yemekToolStripMenuItem;
        private ToolStripMenuItem öğünToolStripMenuItem;
    }
}