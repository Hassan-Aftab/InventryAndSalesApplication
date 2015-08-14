namespace WindowsFormsApplication4
{
    partial class MDIParent1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.categaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertCategaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertProductInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categaryToolStripMenuItem,
            this.productToolStripMenuItem,
            this.modelToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // categaryToolStripMenuItem
            // 
            this.categaryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertCategaryToolStripMenuItem});
            resources.ApplyResources(this.categaryToolStripMenuItem, "categaryToolStripMenuItem");
            this.categaryToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.categaryToolStripMenuItem.Name = "categaryToolStripMenuItem";
            this.categaryToolStripMenuItem.Click += new System.EventHandler(this.categaryToolStripMenuItem_Click);
            // 
            // insertCategaryToolStripMenuItem
            // 
            this.insertCategaryToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.insertCategaryToolStripMenuItem.Name = "insertCategaryToolStripMenuItem";
            resources.ApplyResources(this.insertCategaryToolStripMenuItem, "insertCategaryToolStripMenuItem");
            this.insertCategaryToolStripMenuItem.Click += new System.EventHandler(this.insertCategaryToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertProductInfoToolStripMenuItem});
            resources.ApplyResources(this.productToolStripMenuItem, "productToolStripMenuItem");
            this.productToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            // 
            // insertProductInfoToolStripMenuItem
            // 
            this.insertProductInfoToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon;
            this.insertProductInfoToolStripMenuItem.Name = "insertProductInfoToolStripMenuItem";
            resources.ApplyResources(this.insertProductInfoToolStripMenuItem, "insertProductInfoToolStripMenuItem");
            this.insertProductInfoToolStripMenuItem.Click += new System.EventHandler(this.insertProductInfoToolStripMenuItem_Click);
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileEntryToolStripMenuItem});
            resources.ApplyResources(this.modelToolStripMenuItem, "modelToolStripMenuItem");
            this.modelToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            // 
            // profileEntryToolStripMenuItem
            // 
            this.profileEntryToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.profileEntryToolStripMenuItem.Name = "profileEntryToolStripMenuItem";
            resources.ApplyResources(this.profileEntryToolStripMenuItem, "profileEntryToolStripMenuItem");
            this.profileEntryToolStripMenuItem.Click += new System.EventHandler(this.profileEntryToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            resources.ApplyResources(this.salesToolStripMenuItem, "salesToolStripMenuItem");
            this.salesToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication4.Properties.Resources.happy_new_year;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MDIParent1
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.MaximizeBox = false;
            this.Name = "MDIParent1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem categaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertCategaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertProductInfoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem profileEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}



