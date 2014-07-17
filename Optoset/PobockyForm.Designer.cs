namespace Optoset
{
    partial class PobockyForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cisloTextBox = new System.Windows.Forms.TextBox();
            this.nazovTextBox = new System.Windows.Forms.TextBox();
            this.pridatButton = new System.Windows.Forms.Button();
            this.upravitButton = new System.Windows.Forms.Button();
            this.zmazatButton = new System.Windows.Forms.Button();
            this.zavrietButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(538, 232);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Číslo pobočky";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Názov pobočky";
            this.columnHeader2.Width = 300;
            // 
            // cisloTextBox
            // 
            this.cisloTextBox.Location = new System.Drawing.Point(12, 250);
            this.cisloTextBox.Name = "cisloTextBox";
            this.cisloTextBox.Size = new System.Drawing.Size(100, 20);
            this.cisloTextBox.TabIndex = 1;
            // 
            // nazovTextBox
            // 
            this.nazovTextBox.Location = new System.Drawing.Point(118, 250);
            this.nazovTextBox.Name = "nazovTextBox";
            this.nazovTextBox.Size = new System.Drawing.Size(292, 20);
            this.nazovTextBox.TabIndex = 2;
            // 
            // pridatButton
            // 
            this.pridatButton.Location = new System.Drawing.Point(567, 12);
            this.pridatButton.Name = "pridatButton";
            this.pridatButton.Size = new System.Drawing.Size(129, 23);
            this.pridatButton.TabIndex = 3;
            this.pridatButton.Text = "Pridať";
            this.pridatButton.UseVisualStyleBackColor = true;
            this.pridatButton.Click += new System.EventHandler(this.pridatButton_Click);
            // 
            // upravitButton
            // 
            this.upravitButton.Location = new System.Drawing.Point(567, 41);
            this.upravitButton.Name = "upravitButton";
            this.upravitButton.Size = new System.Drawing.Size(129, 23);
            this.upravitButton.TabIndex = 4;
            this.upravitButton.Text = "Upraviť";
            this.upravitButton.UseVisualStyleBackColor = true;
            this.upravitButton.Click += new System.EventHandler(this.upravitButton_Click);
            // 
            // zmazatButton
            // 
            this.zmazatButton.Location = new System.Drawing.Point(567, 70);
            this.zmazatButton.Name = "zmazatButton";
            this.zmazatButton.Size = new System.Drawing.Size(129, 23);
            this.zmazatButton.TabIndex = 5;
            this.zmazatButton.Text = "Zmazať";
            this.zmazatButton.UseVisualStyleBackColor = true;
            this.zmazatButton.Click += new System.EventHandler(this.zmazatButton_Click);
            // 
            // zavrietButton
            // 
            this.zavrietButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zavrietButton.Location = new System.Drawing.Point(567, 221);
            this.zavrietButton.Name = "zavrietButton";
            this.zavrietButton.Size = new System.Drawing.Size(129, 23);
            this.zavrietButton.TabIndex = 6;
            this.zavrietButton.Text = "Uložiť a zavrieť";
            this.zavrietButton.UseVisualStyleBackColor = true;
            this.zavrietButton.Click += new System.EventHandler(this.zavrietButton_Click);
            // 
            // PobockyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(708, 281);
            this.Controls.Add(this.zavrietButton);
            this.Controls.Add(this.zmazatButton);
            this.Controls.Add(this.upravitButton);
            this.Controls.Add(this.pridatButton);
            this.Controls.Add(this.nazovTextBox);
            this.Controls.Add(this.cisloTextBox);
            this.Controls.Add(this.listView1);
            this.Name = "PobockyForm";
            this.Text = "Poisťovne";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PoistovneForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox cisloTextBox;
        private System.Windows.Forms.TextBox nazovTextBox;
        private System.Windows.Forms.Button pridatButton;
        private System.Windows.Forms.Button upravitButton;
        private System.Windows.Forms.Button zmazatButton;
        private System.Windows.Forms.Button zavrietButton;

    }
}