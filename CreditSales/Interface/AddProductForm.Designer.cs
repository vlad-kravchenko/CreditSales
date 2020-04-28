namespace CreditSales.Interface
{
    partial class AddProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbProduct = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tbAdd = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tbDisc = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCategory);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Категория";
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(6, 19);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(362, 21);
            this.cbCategory.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbProduct);
            this.groupBox2.Location = new System.Drawing.Point(105, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Название товара";
            // 
            // tbProduct
            // 
            this.tbProduct.Location = new System.Drawing.Point(6, 19);
            this.tbProduct.Name = "tbProduct";
            this.tbProduct.Size = new System.Drawing.Size(261, 20);
            this.tbProduct.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbPrice);
            this.groupBox3.Location = new System.Drawing.Point(12, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(87, 49);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Стоимость";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(6, 19);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(75, 20);
            this.tbPrice.TabIndex = 0;
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            this.tbPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPrice_KeyUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.tbAdd);
            this.groupBox4.Location = new System.Drawing.Point(105, 122);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(87, 49);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "% наценки";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Location = new System.Drawing.Point(87, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(87, 49);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Стоимость";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 19);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(75, 20);
            this.textBox4.TabIndex = 0;
            // 
            // tbAdd
            // 
            this.tbAdd.Location = new System.Drawing.Point(6, 19);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(75, 20);
            this.tbAdd.TabIndex = 0;
            this.tbAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            this.tbAdd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPrice_KeyUp);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.tbDisc);
            this.groupBox6.Location = new System.Drawing.Point(198, 122);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(87, 49);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "% скидки";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox5);
            this.groupBox7.Location = new System.Drawing.Point(87, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(87, 49);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Стоимость";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 19);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(75, 20);
            this.textBox5.TabIndex = 0;
            // 
            // tbDisc
            // 
            this.tbDisc.Location = new System.Drawing.Point(6, 19);
            this.tbDisc.Name = "tbDisc";
            this.tbDisc.Size = new System.Drawing.Size(75, 20);
            this.tbDisc.TabIndex = 0;
            this.tbDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDisc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            this.tbDisc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPrice_KeyUp);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tbTotal);
            this.groupBox8.Location = new System.Drawing.Point(291, 122);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(95, 49);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Цена";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(6, 19);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(75, 20);
            this.tbTotal.TabIndex = 0;
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::CreditSales.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(192, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 49);
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::CreditSales.Properties.Resources.OK;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(137, 177);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 49);
            this.btnSave.TabIndex = 7;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Подсказка";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tbNumber);
            this.groupBox9.Location = new System.Drawing.Point(12, 67);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(87, 49);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "ID товара";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(6, 19);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(75, 20);
            this.tbNumber.TabIndex = 1;
            this.tbNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 233);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Товар";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbProduct;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox tbAdd;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox tbDisc;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tbNumber;
    }
}