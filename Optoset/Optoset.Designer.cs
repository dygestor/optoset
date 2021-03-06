﻿using System;
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.suborStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.novyMesiacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otvoritMesiacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ulozitFakturuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ukoncitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zobrazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.zmluvyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lekariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pobockyPoistovniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cennikyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagnozyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.napovedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oAplikaciiOptosetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suborStripMenuItem1,
            this.zobrazToolStripMenuItem,
            this.napovedaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1250, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // suborStripMenuItem1
            // 
            this.suborStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novyMesiacToolStripMenuItem,
            this.otvoritMesiacToolStripMenuItem,
            this.ulozitFakturuToolStripMenuItem,
            this.toolStripSeparator4,
            this.ukoncitToolStripMenuItem});
            this.suborStripMenuItem1.Name = "suborStripMenuItem1";
            this.suborStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.suborStripMenuItem1.Text = "Súbor";
            // 
            // novyMesiacToolStripMenuItem
            // 
            this.novyMesiacToolStripMenuItem.Name = "novyMesiacToolStripMenuItem";
            this.novyMesiacToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.novyMesiacToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.novyMesiacToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.novyMesiacToolStripMenuItem.Text = "Nový mesiac";
            this.novyMesiacToolStripMenuItem.Click += new System.EventHandler(this.novyMesiacToolStripMenuItem_Click);
            // 
            // otvoritMesiacToolStripMenuItem
            // 
            this.otvoritMesiacToolStripMenuItem.Name = "otvoritMesiacToolStripMenuItem";
            this.otvoritMesiacToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.otvoritMesiacToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.otvoritMesiacToolStripMenuItem.Text = "Otvoriť mesiac";
            this.otvoritMesiacToolStripMenuItem.Click += new System.EventHandler(this.otvoritMesiacToolStripMenuItem_Click);
            // 
            // ulozitFakturuToolStripMenuItem
            // 
            this.ulozitFakturuToolStripMenuItem.Enabled = false;
            this.ulozitFakturuToolStripMenuItem.Name = "ulozitFakturuToolStripMenuItem";
            this.ulozitFakturuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.ulozitFakturuToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ulozitFakturuToolStripMenuItem.Text = "Uložiť mesiac";
            this.ulozitFakturuToolStripMenuItem.Click += new System.EventHandler(this.ulozitFakturuToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(192, 6);
            // 
            // ukoncitToolStripMenuItem
            // 
            this.ukoncitToolStripMenuItem.Name = "ukoncitToolStripMenuItem";
            this.ukoncitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ukoncitToolStripMenuItem.Text = "Ukončiť";
            this.ukoncitToolStripMenuItem.Click += new System.EventHandler(this.ukoncitToolStripMenuItem_Click);
            // 
            // zobrazToolStripMenuItem
            // 
            this.zobrazToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nastaveniaToolStripMenuItem,
            this.toolStripSeparator3,
            this.zmluvyToolStripMenuItem,
            this.lekariToolStripMenuItem,
            this.pobockyPoistovniToolStripMenuItem,
            this.toolStripSeparator2,
            this.cennikyToolStripMenuItem,
            this.diagnozyToolStripMenuItem});
            this.zobrazToolStripMenuItem.Name = "zobrazToolStripMenuItem";
            this.zobrazToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.zobrazToolStripMenuItem.Text = "Zobraz";
            this.zobrazToolStripMenuItem.Click += new System.EventHandler(this.zobrazToolStripMenuItem_Click);
            // 
            // nastaveniaToolStripMenuItem
            // 
            this.nastaveniaToolStripMenuItem.Name = "nastaveniaToolStripMenuItem";
            this.nastaveniaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.nastaveniaToolStripMenuItem.Text = "Nastavenia";
            this.nastaveniaToolStripMenuItem.Click += new System.EventHandler(this.nastaveniaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // zmluvyToolStripMenuItem
            // 
            this.zmluvyToolStripMenuItem.Name = "zmluvyToolStripMenuItem";
            this.zmluvyToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.zmluvyToolStripMenuItem.Text = "Zmluvy";
            this.zmluvyToolStripMenuItem.Click += new System.EventHandler(this.zmluvyToolStripMenuItem_Click);
            // 
            // lekariToolStripMenuItem
            // 
            this.lekariToolStripMenuItem.Name = "lekariToolStripMenuItem";
            this.lekariToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.lekariToolStripMenuItem.Text = "Lekári";
            this.lekariToolStripMenuItem.Click += new System.EventHandler(this.lekariToolStripMenuItem_Click);
            // 
            // pobockyPoistovniToolStripMenuItem
            // 
            this.pobockyPoistovniToolStripMenuItem.Name = "pobockyPoistovniToolStripMenuItem";
            this.pobockyPoistovniToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pobockyPoistovniToolStripMenuItem.Text = "Pobočky poisťovní";
            this.pobockyPoistovniToolStripMenuItem.Click += new System.EventHandler(this.pobockyPoistovniToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // cennikyToolStripMenuItem
            // 
            this.cennikyToolStripMenuItem.Name = "cennikyToolStripMenuItem";
            this.cennikyToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cennikyToolStripMenuItem.Text = "Cenníky";
            this.cennikyToolStripMenuItem.Click += new System.EventHandler(this.cennikyToolStripMenuItem_Click);
            // 
            // diagnozyToolStripMenuItem
            // 
            this.diagnozyToolStripMenuItem.Name = "diagnozyToolStripMenuItem";
            this.diagnozyToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.diagnozyToolStripMenuItem.Text = "Diagnózy";
            this.diagnozyToolStripMenuItem.Click += new System.EventHandler(this.diagnozyToolStripMenuItem_Click);
            // 
            // napovedaToolStripMenuItem
            // 
            this.napovedaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oAplikaciiOptosetToolStripMenuItem});
            this.napovedaToolStripMenuItem.Name = "napovedaToolStripMenuItem";
            this.napovedaToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.napovedaToolStripMenuItem.Text = "Nápoveda";
            // 
            // oAplikaciiOptosetToolStripMenuItem
            // 
            this.oAplikaciiOptosetToolStripMenuItem.Name = "oAplikaciiOptosetToolStripMenuItem";
            this.oAplikaciiOptosetToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.oAplikaciiOptosetToolStripMenuItem.Text = "O aplikácii Optoset";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1250, 604);
            this.tabControl1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "XML Files | *.xml";
            // 
            // Optoset
            // 
            this.ClientSize = new System.Drawing.Size(1250, 628);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Optoset";
            this.Text = "Optoset";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Optoset_Shown);
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
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl tabControl1;
        private BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem ulozitFakturuToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private OpenFileDialog openFileDialog1;
    }
}

