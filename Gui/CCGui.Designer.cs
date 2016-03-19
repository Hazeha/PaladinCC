namespace CustomClassTemplate.Gui
{
    partial class CCGui
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
            this.foodlb = new System.Windows.Forms.Label();
            this.drinklb = new System.Windows.Forms.Label();
            this.foodTb = new System.Windows.Forms.TextBox();
            this.drinkTb = new System.Windows.Forms.TextBox();
            this.meleelb = new System.Windows.Forms.Label();
            this.castlb = new System.Windows.Forms.Label();
            this.meleeNud = new System.Windows.Forms.NumericUpDown();
            this.castNud = new System.Windows.Forms.NumericUpDown();
            this.saveBtn = new System.Windows.Forms.Button();
            this.reloadBtn = new System.Windows.Forms.Button();
            this.cbWeaponEnh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBuff = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAura = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.meleeNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.castNud)).BeginInit();
            this.SuspendLayout();
            // 
            // foodlb
            // 
            this.foodlb.AutoSize = true;
            this.foodlb.Location = new System.Drawing.Point(12, 13);
            this.foodlb.Name = "foodlb";
            this.foodlb.Size = new System.Drawing.Size(68, 13);
            this.foodlb.TabIndex = 0;
            this.foodlb.Text = "Food Name: ";
            // 
            // drinklb
            // 
            this.drinklb.AutoSize = true;
            this.drinklb.Location = new System.Drawing.Point(11, 41);
            this.drinklb.Name = "drinklb";
            this.drinklb.Size = new System.Drawing.Size(69, 13);
            this.drinklb.TabIndex = 1;
            this.drinklb.Text = "Drink Name: ";
            // 
            // foodTb
            // 
            this.foodTb.Location = new System.Drawing.Point(86, 10);
            this.foodTb.Name = "foodTb";
            this.foodTb.Size = new System.Drawing.Size(100, 20);
            this.foodTb.TabIndex = 2;
            // 
            // drinkTb
            // 
            this.drinkTb.Location = new System.Drawing.Point(86, 38);
            this.drinkTb.Name = "drinkTb";
            this.drinkTb.Size = new System.Drawing.Size(100, 20);
            this.drinkTb.TabIndex = 3;
            // 
            // meleelb
            // 
            this.meleelb.AutoSize = true;
            this.meleelb.Location = new System.Drawing.Point(11, 66);
            this.meleelb.Name = "meleelb";
            this.meleelb.Size = new System.Drawing.Size(87, 13);
            this.meleelb.TabIndex = 4;
            this.meleelb.Text = "Melee Distance: ";
            // 
            // castlb
            // 
            this.castlb.AutoSize = true;
            this.castlb.Location = new System.Drawing.Point(12, 92);
            this.castlb.Name = "castlb";
            this.castlb.Size = new System.Drawing.Size(79, 13);
            this.castlb.TabIndex = 5;
            this.castlb.Text = "Cast Distance: ";
            // 
            // meleeNud
            // 
            this.meleeNud.Location = new System.Drawing.Point(121, 64);
            this.meleeNud.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.meleeNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.meleeNud.Name = "meleeNud";
            this.meleeNud.Size = new System.Drawing.Size(66, 20);
            this.meleeNud.TabIndex = 6;
            this.meleeNud.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // castNud
            // 
            this.castNud.Location = new System.Drawing.Point(121, 90);
            this.castNud.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.castNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.castNud.Name = "castNud";
            this.castNud.Size = new System.Drawing.Size(66, 20);
            this.castNud.TabIndex = 7;
            this.castNud.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(21, 251);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(102, 251);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(75, 23);
            this.reloadBtn.TabIndex = 9;
            this.reloadBtn.Text = "Reload";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // cbWeaponEnh
            // 
            this.cbWeaponEnh.FormattingEnabled = true;
            this.cbWeaponEnh.Items.AddRange(new object[] {
            "Seal of Righteousness",
            "Seal of Light",
            "Seal of the Crusader",
            "Seal of Justice",
            "Seal of Wisdom"});
            this.cbWeaponEnh.Location = new System.Drawing.Point(14, 135);
            this.cbWeaponEnh.Name = "cbWeaponEnh";
            this.cbWeaponEnh.Size = new System.Drawing.Size(172, 21);
            this.cbWeaponEnh.TabIndex = 10;
            this.cbWeaponEnh.SelectedIndexChanged += new System.EventHandler(this.cbWeaponEnh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Seal Buff";
            // 
            // cbBuff
            // 
            this.cbBuff.FormattingEnabled = true;
            this.cbBuff.Items.AddRange(new object[] {
            "Blessing of Might",
            "Blessing of Kings",
            "Blessing of Wisdom",
            "Blessing of Sanctuary",
            "Blessing of Light"});
            this.cbBuff.Location = new System.Drawing.Point(14, 175);
            this.cbBuff.Name = "cbBuff";
            this.cbBuff.Size = new System.Drawing.Size(172, 21);
            this.cbBuff.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Blessing Buff";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Aura Buff";
            // 
            // cbAura
            // 
            this.cbAura.FormattingEnabled = true;
            this.cbAura.Items.AddRange(new object[] {
            "Devotion Aura",
            "Retribution Aura",
            "Concentration Aura\t",
            "Shadow Resistance Aura",
            "Frost Resistance Aura",
            "Fire Resistance Aura"});
            this.cbAura.Location = new System.Drawing.Point(15, 215);
            this.cbAura.Name = "cbAura";
            this.cbAura.Size = new System.Drawing.Size(172, 21);
            this.cbAura.TabIndex = 16;
            // 
            // CCGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 286);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBuff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbWeaponEnh);
            this.Controls.Add(this.reloadBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.castNud);
            this.Controls.Add(this.meleeNud);
            this.Controls.Add(this.castlb);
            this.Controls.Add(this.meleelb);
            this.Controls.Add(this.drinkTb);
            this.Controls.Add(this.foodTb);
            this.Controls.Add(this.drinklb);
            this.Controls.Add(this.foodlb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CCGui";
            this.Text = "XhzPaladin";
            this.Load += new System.EventHandler(this.CCGui_Load);
            ((System.ComponentModel.ISupportInitialize)(this.meleeNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.castNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label foodlb;
        private System.Windows.Forms.Label drinklb;
        private System.Windows.Forms.TextBox foodTb;
        private System.Windows.Forms.TextBox drinkTb;
        private System.Windows.Forms.Label meleelb;
        private System.Windows.Forms.Label castlb;
        private System.Windows.Forms.NumericUpDown meleeNud;
        private System.Windows.Forms.NumericUpDown castNud;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button reloadBtn;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbWeaponEnh;
        public System.Windows.Forms.ComboBox cbBuff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbAura;
    }
}