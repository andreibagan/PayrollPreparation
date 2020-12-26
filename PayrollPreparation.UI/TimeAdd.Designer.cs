
namespace PayrollPreparation.UI
{
    partial class TimeAdd
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
            this.bunifuCustomTextbox1 = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDropdown4 = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuCustomLabel12 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuFlatButton20 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // bunifuCustomTextbox1
            // 
            this.bunifuCustomTextbox1.BorderColor = System.Drawing.Color.SeaGreen;
            this.bunifuCustomTextbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox1.Enabled = false;
            this.bunifuCustomTextbox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomTextbox1.Location = new System.Drawing.Point(16, 79);
            this.bunifuCustomTextbox1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuCustomTextbox1.MaxLength = 2;
            this.bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
            this.bunifuCustomTextbox1.Size = new System.Drawing.Size(341, 27);
            this.bunifuCustomTextbox1.TabIndex = 42;
            this.bunifuCustomTextbox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bunifuCustomTextbox1_KeyPress);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Enabled = false;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(15, 58);
            this.bunifuCustomLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(232, 21);
            this.bunifuCustomLabel2.TabIndex = 41;
            this.bunifuCustomLabel2.Text = "Введите количество часов";
            // 
            // bunifuDropdown4
            // 
            this.bunifuDropdown4.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuDropdown4.BorderRadius = 0;
            this.bunifuDropdown4.Color = System.Drawing.SystemColors.InactiveCaptionText;
            this.bunifuDropdown4.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.bunifuDropdown4.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDropdown4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bunifuDropdown4.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.bunifuDropdown4.DropDownHeight = 80;
            this.bunifuDropdown4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bunifuDropdown4.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuDropdown4.FillDropDown = false;
            this.bunifuDropdown4.FillIndicator = false;
            this.bunifuDropdown4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuDropdown4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuDropdown4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bunifuDropdown4.FormattingEnabled = true;
            this.bunifuDropdown4.Icon = null;
            this.bunifuDropdown4.IndicatorColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bunifuDropdown4.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuDropdown4.IntegralHeight = false;
            this.bunifuDropdown4.ItemBackColor = System.Drawing.Color.White;
            this.bunifuDropdown4.ItemBorderColor = System.Drawing.Color.White;
            this.bunifuDropdown4.ItemForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bunifuDropdown4.ItemHeight = 17;
            this.bunifuDropdown4.ItemHighLightColor = System.Drawing.Color.White;
            this.bunifuDropdown4.Items.AddRange(new object[] {
            "Количество часов",
            "Выходной",
            "Больничный",
            "Отпуск"});
            this.bunifuDropdown4.Location = new System.Drawing.Point(16, 30);
            this.bunifuDropdown4.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuDropdown4.MinimumSize = new System.Drawing.Size(132, 0);
            this.bunifuDropdown4.Name = "bunifuDropdown4";
            this.bunifuDropdown4.Size = new System.Drawing.Size(341, 23);
            this.bunifuDropdown4.TabIndex = 40;
            this.bunifuDropdown4.Text = null;
            this.bunifuDropdown4.SelectedIndexChanged += new System.EventHandler(this.bunifuDropdown4_SelectedIndexChanged);
            // 
            // bunifuCustomLabel12
            // 
            this.bunifuCustomLabel12.AutoSize = true;
            this.bunifuCustomLabel12.Enabled = false;
            this.bunifuCustomLabel12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomLabel12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuCustomLabel12.Location = new System.Drawing.Point(13, 9);
            this.bunifuCustomLabel12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel12.Name = "bunifuCustomLabel12";
            this.bunifuCustomLabel12.Size = new System.Drawing.Size(200, 21);
            this.bunifuCustomLabel12.TabIndex = 39;
            this.bunifuCustomLabel12.Text = "Выберите тип отметки";
            // 
            // bunifuFlatButton20
            // 
            this.bunifuFlatButton20.Active = false;
            this.bunifuFlatButton20.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.bunifuFlatButton20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.bunifuFlatButton20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton20.BorderRadius = 0;
            this.bunifuFlatButton20.ButtonText = "Добавить";
            this.bunifuFlatButton20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton20.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton20.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton20.Iconimage = null;
            this.bunifuFlatButton20.Iconimage_right = null;
            this.bunifuFlatButton20.Iconimage_right_Selected = null;
            this.bunifuFlatButton20.Iconimage_Selected = null;
            this.bunifuFlatButton20.IconMarginLeft = 0;
            this.bunifuFlatButton20.IconMarginRight = 0;
            this.bunifuFlatButton20.IconRightVisible = false;
            this.bunifuFlatButton20.IconRightZoom = 0D;
            this.bunifuFlatButton20.IconVisible = false;
            this.bunifuFlatButton20.IconZoom = 90D;
            this.bunifuFlatButton20.IsTab = false;
            this.bunifuFlatButton20.Location = new System.Drawing.Point(16, 125);
            this.bunifuFlatButton20.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.bunifuFlatButton20.Name = "bunifuFlatButton20";
            this.bunifuFlatButton20.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.bunifuFlatButton20.OnHovercolor = System.Drawing.Color.DodgerBlue;
            this.bunifuFlatButton20.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton20.selected = false;
            this.bunifuFlatButton20.Size = new System.Drawing.Size(341, 32);
            this.bunifuFlatButton20.TabIndex = 43;
            this.bunifuFlatButton20.Text = "Добавить";
            this.bunifuFlatButton20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton20.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton20.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuFlatButton20.Click += new System.EventHandler(this.bunifuFlatButton20_Click);
            // 
            // TimeAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 174);
            this.Controls.Add(this.bunifuFlatButton20);
            this.Controls.Add(this.bunifuCustomTextbox1);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuDropdown4);
            this.Controls.Add(this.bunifuCustomLabel12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TimeAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление отметки в табеле";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.BunifuCustomTextbox bunifuCustomTextbox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.UI.WinForms.BunifuDropdown bunifuDropdown4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel12;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton20;
    }
}