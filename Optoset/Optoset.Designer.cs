using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Optoset
{
    partial class Optoset
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.menuStrip1 = new MenuStrip();
            this.suborStripMenuItem1 = new ToolStripMenuItem();
            this.novyMesiacToolStripMenuItem = new ToolStripMenuItem();
            this.otvoritMesiacToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.ukoncitToolStripMenuItem = new ToolStripMenuItem();
            this.zobrazToolStripMenuItem = new ToolStripMenuItem();
            this.nastaveniaToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.zmluvyToolStripMenuItem = new ToolStripMenuItem();
            this.lekariToolStripMenuItem = new ToolStripMenuItem();
            this.pobockyPoistovniToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.cennikyToolStripMenuItem = new ToolStripMenuItem();
            this.diagnozyToolStripMenuItem = new ToolStripMenuItem();
            this.napovedaToolStripMenuItem = new ToolStripMenuItem();
            this.oAplikaciiOptosetToolStripMenuItem = new ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.backgroundWorker1 = new BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.suborStripMenuItem1,
            this.zobrazToolStripMenuItem,
            this.napovedaToolStripMenuItem});
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(1250, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // suborStripMenuItem1
            // 
            this.suborStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] {
            this.novyMesiacToolStripMenuItem,
            this.otvoritMesiacToolStripMenuItem,
            this.toolStripSeparator1,
            this.ukoncitToolStripMenuItem});
            this.suborStripMenuItem1.Name = "suborStripMenuItem1";
            this.suborStripMenuItem1.Size = new Size(50, 20);
            this.suborStripMenuItem1.Text = "Súbor";
            // 
            // novyMesiacToolStripMenuItem
            // 
            this.novyMesiacToolStripMenuItem.Name = "novyMesiacToolStripMenuItem";
            this.novyMesiacToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.novyMesiacToolStripMenuItem.ShortcutKeys = ((Keys)((Keys.Control | Keys.N)));
            this.novyMesiacToolStripMenuItem.Size = new Size(195, 22);
            this.novyMesiacToolStripMenuItem.Text = "Nový mesiac";
            this.novyMesiacToolStripMenuItem.Click += new EventHandler(this.novyMesiacToolStripMenuItem_Click);
            // 
            // otvoritMesiacToolStripMenuItem
            // 
            this.otvoritMesiacToolStripMenuItem.Name = "otvoritMesiacToolStripMenuItem";
            this.otvoritMesiacToolStripMenuItem.ShortcutKeys = ((Keys)((Keys.Control | Keys.O)));
            this.otvoritMesiacToolStripMenuItem.Size = new Size(195, 22);
            this.otvoritMesiacToolStripMenuItem.Text = "Otvoriť mesiac";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(192, 6);
            // 
            // ukoncitToolStripMenuItem
            // 
            this.ukoncitToolStripMenuItem.Name = "ukoncitToolStripMenuItem";
            this.ukoncitToolStripMenuItem.Size = new Size(195, 22);
            this.ukoncitToolStripMenuItem.Text = "Ukončiť";
            // 
            // zobrazToolStripMenuItem
            // 
            this.zobrazToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.nastaveniaToolStripMenuItem,
            this.toolStripSeparator3,
            this.zmluvyToolStripMenuItem,
            this.lekariToolStripMenuItem,
            this.pobockyPoistovniToolStripMenuItem,
            this.toolStripSeparator2,
            this.cennikyToolStripMenuItem,
            this.diagnozyToolStripMenuItem});
            this.zobrazToolStripMenuItem.Name = "zobrazToolStripMenuItem";
            this.zobrazToolStripMenuItem.Size = new Size(55, 20);
            this.zobrazToolStripMenuItem.Text = "Zobraz";
            this.zobrazToolStripMenuItem.Click += new EventHandler(this.zobrazToolStripMenuItem_Click);
            // 
            // nastaveniaToolStripMenuItem
            // 
            this.nastaveniaToolStripMenuItem.Name = "nastaveniaToolStripMenuItem";
            this.nastaveniaToolStripMenuItem.Size = new Size(173, 22);
            this.nastaveniaToolStripMenuItem.Text = "Nastavenia";
            this.nastaveniaToolStripMenuItem.Click += new EventHandler(this.nastaveniaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(170, 6);
            // 
            // zmluvyToolStripMenuItem
            // 
            this.zmluvyToolStripMenuItem.Name = "zmluvyToolStripMenuItem";
            this.zmluvyToolStripMenuItem.Size = new Size(173, 22);
            this.zmluvyToolStripMenuItem.Text = "Zmluvy";
            this.zmluvyToolStripMenuItem.Click += new EventHandler(this.zmluvyToolStripMenuItem_Click);
            // 
            // lekariToolStripMenuItem
            // 
            this.lekariToolStripMenuItem.Name = "lekariToolStripMenuItem";
            this.lekariToolStripMenuItem.Size = new Size(173, 22);
            this.lekariToolStripMenuItem.Text = "Lekári";
            this.lekariToolStripMenuItem.Click += new EventHandler(this.lekariToolStripMenuItem_Click);
            // 
            // pobockyPoistovniToolStripMenuItem
            // 
            this.pobockyPoistovniToolStripMenuItem.Name = "pobockyPoistovniToolStripMenuItem";
            this.pobockyPoistovniToolStripMenuItem.Size = new Size(173, 22);
            this.pobockyPoistovniToolStripMenuItem.Text = "Pobočky poisťovní";
            this.pobockyPoistovniToolStripMenuItem.Click += new EventHandler(this.pobockyPoistovniToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(170, 6);
            // 
            // cennikyToolStripMenuItem
            // 
            this.cennikyToolStripMenuItem.Name = "cennikyToolStripMenuItem";
            this.cennikyToolStripMenuItem.Size = new Size(173, 22);
            this.cennikyToolStripMenuItem.Text = "Cenníky";
            this.cennikyToolStripMenuItem.Click += new EventHandler(this.cennikyToolStripMenuItem_Click);
            // 
            // diagnozyToolStripMenuItem
            // 
            this.diagnozyToolStripMenuItem.Name = "diagnozyToolStripMenuItem";
            this.diagnozyToolStripMenuItem.Size = new Size(173, 22);
            this.diagnozyToolStripMenuItem.Text = "Diagnózy";
            this.diagnozyToolStripMenuItem.Click += new EventHandler(this.diagnozyToolStripMenuItem_Click);
            // 
            // napovedaToolStripMenuItem
            // 
            this.napovedaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.oAplikaciiOptosetToolStripMenuItem});
            this.napovedaToolStripMenuItem.Name = "napovedaToolStripMenuItem";
            this.napovedaToolStripMenuItem.Size = new Size(73, 20);
            this.napovedaToolStripMenuItem.Text = "Nápoveda";
            // 
            // oAplikaciiOptosetToolStripMenuItem
            // 
            this.oAplikaciiOptosetToolStripMenuItem.Name = "oAplikaciiOptosetToolStripMenuItem";
            this.oAplikaciiOptosetToolStripMenuItem.Size = new Size(174, 22);
            this.oAplikaciiOptosetToolStripMenuItem.Text = "O aplikácii Optoset";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(1250, 604);
            this.tabControl1.TabIndex = 4;
            // 
            // Optoset
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1250, 628);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Optoset";
            this.Text = "Optoset";
            this.WindowState = FormWindowState.Maximized;
            this.Shown += new EventHandler(this.Optoset_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem suborStripMenuItem1;
        private ToolStripMenuItem novyMesiacToolStripMenuItem;
        private ToolStripMenuItem otvoritMesiacToolStripMenuItem;
        private ToolStripMenuItem ukoncitToolStripMenuItem;
        private ToolStripMenuItem zobrazToolStripMenuItem;
        private ToolStripMenuItem napovedaToolStripMenuItem;
        private ToolStripMenuItem nastaveniaToolStripMenuItem;
        private ToolStripMenuItem zmluvyToolStripMenuItem;
        private ToolStripMenuItem lekariToolStripMenuItem;
        private ToolStripMenuItem pobockyPoistovniToolStripMenuItem;
        private ToolStripMenuItem cennikyToolStripMenuItem;
        private ToolStripMenuItem diagnozyToolStripMenuItem;
        private ToolStripMenuItem oAplikaciiOptosetToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl tabControl1;
        private BackgroundWorker backgroundWorker1;
    }
}

