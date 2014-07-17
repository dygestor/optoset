namespace Optoset
{
    partial class ZmluvyForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cisloTextBox = new System.Windows.Forms.TextBox();
            this.nazovTextBox = new System.Windows.Forms.TextBox();
            this.icoTextBox = new System.Windows.Forms.TextBox();
            this.dicTextBox = new System.Windows.Forms.TextBox();
            this.icdphTextBox = new System.Windows.Forms.TextBox();
            this.adresaTextBox = new System.Windows.Forms.TextBox();
            this.ibanTextBox = new System.Windows.Forms.TextBox();
            this.bicTextBox = new System.Windows.Forms.TextBox();
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
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(948, 269);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Číslo zmluvy";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Názov";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IČO";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "DIČ";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "IČ-DPH";
            this.columnHeader5.Width = 110;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Adresa";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "IBAN";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "SWIFT";
            this.columnHeader8.Width = 100;
            // 
            // cisloTextBox
            // 
            this.cisloTextBox.Location = new System.Drawing.Point(12, 287);
            this.cisloTextBox.Name = "cisloTextBox";
            this.cisloTextBox.Size = new System.Drawing.Size(75, 20);
            this.cisloTextBox.TabIndex = 1;
            // 
            // nazovTextBox
            // 
            this.nazovTextBox.Location = new System.Drawing.Point(93, 287);
            this.nazovTextBox.Name = "nazovTextBox";
            this.nazovTextBox.Size = new System.Drawing.Size(105, 20);
            this.nazovTextBox.TabIndex = 2;
            // 
            // icoTextBox
            // 
            this.icoTextBox.Location = new System.Drawing.Point(204, 287);
            this.icoTextBox.Name = "icoTextBox";
            this.icoTextBox.Size = new System.Drawing.Size(105, 20);
            this.icoTextBox.TabIndex = 3;
            // 
            // dicTextBox
            // 
            this.dicTextBox.Location = new System.Drawing.Point(315, 287);
            this.dicTextBox.Name = "dicTextBox";
            this.dicTextBox.Size = new System.Drawing.Size(105, 20);
            this.dicTextBox.TabIndex = 4;
            // 
            // icdphTextBox
            // 
            this.icdphTextBox.Location = new System.Drawing.Point(426, 287);
            this.icdphTextBox.Name = "icdphTextBox";
            this.icdphTextBox.Size = new System.Drawing.Size(105, 20);
            this.icdphTextBox.TabIndex = 5;
            // 
            // adresaTextBox
            // 
            this.adresaTextBox.Location = new System.Drawing.Point(537, 287);
            this.adresaTextBox.Name = "adresaTextBox";
            this.adresaTextBox.Size = new System.Drawing.Size(150, 20);
            this.adresaTextBox.TabIndex = 6;
            // 
            // ibanTextBox
            // 
            this.ibanTextBox.Location = new System.Drawing.Point(693, 287);
            this.ibanTextBox.Name = "ibanTextBox";
            this.ibanTextBox.Size = new System.Drawing.Size(150, 20);
            this.ibanTextBox.TabIndex = 7;
            // 
            // bicTextBox
            // 
            this.bicTextBox.Location = new System.Drawing.Point(849, 287);
            this.bicTextBox.Name = "bicTextBox";
            this.bicTextBox.Size = new System.Drawing.Size(100, 20);
            this.bicTextBox.TabIndex = 8;
            // 
            // pridatButton
            // 
            this.pridatButton.Location = new System.Drawing.Point(966, 12);
            this.pridatButton.Name = "pridatButton";
            this.pridatButton.Size = new System.Drawing.Size(156, 23);
            this.pridatButton.TabIndex = 9;
            this.pridatButton.Text = "Pridať";
            this.pridatButton.UseVisualStyleBackColor = true;
            this.pridatButton.Click += new System.EventHandler(this.pridatButton_Click);
            // 
            // upravitButton
            // 
            this.upravitButton.Location = new System.Drawing.Point(967, 42);
            this.upravitButton.Name = "upravitButton";
            this.upravitButton.Size = new System.Drawing.Size(155, 23);
            this.upravitButton.TabIndex = 10;
            this.upravitButton.Text = "Upraviť";
            this.upravitButton.UseVisualStyleBackColor = true;
            this.upravitButton.Click += new System.EventHandler(this.upravitButton_Click);
            // 
            // zmazatButton
            // 
            this.zmazatButton.Location = new System.Drawing.Point(967, 72);
            this.zmazatButton.Name = "zmazatButton";
            this.zmazatButton.Size = new System.Drawing.Size(155, 23);
            this.zmazatButton.TabIndex = 11;
            this.zmazatButton.Text = "Zmazať";
            this.zmazatButton.UseVisualStyleBackColor = true;
            this.zmazatButton.Click += new System.EventHandler(this.zmazatButton_Click);
            // 
            // zavrietButton
            // 
            this.zavrietButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zavrietButton.Location = new System.Drawing.Point(966, 257);
            this.zavrietButton.Name = "zavrietButton";
            this.zavrietButton.Size = new System.Drawing.Size(156, 23);
            this.zavrietButton.TabIndex = 12;
            this.zavrietButton.Text = "Uložiť a zavrieť";
            this.zavrietButton.UseVisualStyleBackColor = true;
            this.zavrietButton.Click += new System.EventHandler(this.zavrietButton_Click);
            // 
            // ZmluvyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 544);
            this.Controls.Add(this.zavrietButton);
            this.Controls.Add(this.zmazatButton);
            this.Controls.Add(this.upravitButton);
            this.Controls.Add(this.pridatButton);
            this.Controls.Add(this.bicTextBox);
            this.Controls.Add(this.ibanTextBox);
            this.Controls.Add(this.adresaTextBox);
            this.Controls.Add(this.icdphTextBox);
            this.Controls.Add(this.dicTextBox);
            this.Controls.Add(this.icoTextBox);
            this.Controls.Add(this.nazovTextBox);
            this.Controls.Add(this.cisloTextBox);
            this.Controls.Add(this.listView1);
            this.Name = "ZmluvyForm";
            this.Text = "Zmluvy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZmluvyForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TextBox cisloTextBox;
        private System.Windows.Forms.TextBox nazovTextBox;
        private System.Windows.Forms.TextBox icoTextBox;
        private System.Windows.Forms.TextBox dicTextBox;
        private System.Windows.Forms.TextBox icdphTextBox;
        private System.Windows.Forms.TextBox adresaTextBox;
        private System.Windows.Forms.TextBox ibanTextBox;
        private System.Windows.Forms.TextBox bicTextBox;
        private System.Windows.Forms.Button pridatButton;
        private System.Windows.Forms.Button upravitButton;
        private System.Windows.Forms.Button zmazatButton;
        private System.Windows.Forms.Button zavrietButton;
    }
}