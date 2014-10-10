namespace Optoset
{
    partial class TabControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pridaťPomôckuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upraviťPomôckuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmazaťPomôckuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fakturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pridaťPoukazToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.upraviťPoukazToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zmazaťPoukazToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveniaFakturyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 621);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 33);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(594, 589);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.VirtualMode = true;
            this.listView1.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Poukaz";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "RČ pacienta";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "IČ poisťovne pacienta";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Kód lekára";
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "KPZS lekára";
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Diagnóza";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Dátum predpísania";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Dátum vydania";
            this.columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Suma poisťovňa";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Suma pacient";
            this.columnHeader11.Width = 80;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader1});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(603, 33);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(395, 589);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Pomôcka";
            this.columnHeader12.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Množstvo";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Hradí poisťovňa";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Hradí pacient";
            this.columnHeader15.Width = 100;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pridaťPomôckuToolStripMenuItem,
            this.upraviťPomôckuToolStripMenuItem,
            this.zmazaťPomôckuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(600, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(401, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pridaťPomôckuToolStripMenuItem
            // 
            this.pridaťPomôckuToolStripMenuItem.Name = "pridaťPomôckuToolStripMenuItem";
            this.pridaťPomôckuToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.pridaťPomôckuToolStripMenuItem.Text = "Pridať pomôcku";
            this.pridaťPomôckuToolStripMenuItem.Click += new System.EventHandler(this.pridaťPomôckuToolStripMenuItem_Click);
            // 
            // upraviťPomôckuToolStripMenuItem
            // 
            this.upraviťPomôckuToolStripMenuItem.Name = "upraviťPomôckuToolStripMenuItem";
            this.upraviťPomôckuToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.upraviťPomôckuToolStripMenuItem.Text = "Upraviť pomôcku";
            this.upraviťPomôckuToolStripMenuItem.Click += new System.EventHandler(this.upraviťPomôckuToolStripMenuItem_Click);
            // 
            // zmazaťPomôckuToolStripMenuItem
            // 
            this.zmazaťPomôckuToolStripMenuItem.Name = "zmazaťPomôckuToolStripMenuItem";
            this.zmazaťPomôckuToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.zmazaťPomôckuToolStripMenuItem.Text = "Zmazať pomôcku";
            this.zmazaťPomôckuToolStripMenuItem.Click += new System.EventHandler(this.zmazaťPomôckuToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fakturaToolStripMenuItem,
            this.pridaťPoukazToolStripMenuItem1,
            this.upraviťPoukazToolStripMenuItem1,
            this.zmazaťPoukazToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(600, 24);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fakturaToolStripMenuItem
            // 
            this.fakturaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nastaveniaFakturyToolStripMenuItem,
            this.toolStripSeparator1});
            this.fakturaToolStripMenuItem.Name = "fakturaToolStripMenuItem";
            this.fakturaToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.fakturaToolStripMenuItem.Text = "Faktúra";
            // 
            // pridaťPoukazToolStripMenuItem1
            // 
            this.pridaťPoukazToolStripMenuItem1.Name = "pridaťPoukazToolStripMenuItem1";
            this.pridaťPoukazToolStripMenuItem1.Size = new System.Drawing.Size(92, 20);
            this.pridaťPoukazToolStripMenuItem1.Text = "Pridať poukaz";
            this.pridaťPoukazToolStripMenuItem1.Click += new System.EventHandler(this.pridaťPoukazToolStripMenuItem1_Click);
            // 
            // upraviťPoukazToolStripMenuItem1
            // 
            this.upraviťPoukazToolStripMenuItem1.Name = "upraviťPoukazToolStripMenuItem1";
            this.upraviťPoukazToolStripMenuItem1.Size = new System.Drawing.Size(99, 20);
            this.upraviťPoukazToolStripMenuItem1.Text = "Upraviť poukaz";
            this.upraviťPoukazToolStripMenuItem1.Click += new System.EventHandler(this.upraviťPoukazToolStripMenuItem1_Click);
            // 
            // zmazaťPoukazToolStripMenuItem1
            // 
            this.zmazaťPoukazToolStripMenuItem1.Name = "zmazaťPoukazToolStripMenuItem1";
            this.zmazaťPoukazToolStripMenuItem1.Size = new System.Drawing.Size(100, 20);
            this.zmazaťPoukazToolStripMenuItem1.Text = "Zmazať poukaz";
            this.zmazaťPoukazToolStripMenuItem1.Click += new System.EventHandler(this.zmazaťPoukazToolStripMenuItem1_Click);
            // 
            // nastaveniaFakturyToolStripMenuItem
            // 
            this.nastaveniaFakturyToolStripMenuItem.Name = "nastaveniaFakturyToolStripMenuItem";
            this.nastaveniaFakturyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.nastaveniaFakturyToolStripMenuItem.Text = "Nastavenia faktúry";
            this.nastaveniaFakturyToolStripMenuItem.Click += new System.EventHandler(this.upraviťToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dodatočné informácie";
            // 
            // TabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TabControl";
            this.Size = new System.Drawing.Size(1001, 621);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fakturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pridaťPoukazToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem upraviťPoukazToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zmazaťPoukazToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pridaťPomôckuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upraviťPomôckuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmazaťPomôckuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastaveniaFakturyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
