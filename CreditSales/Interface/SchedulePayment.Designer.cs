namespace CreditSales.Interface
{
    partial class SchedulePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulePayment));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDebt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.datePayment = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbMustPay = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbPercents = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbPayment = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::CreditSales.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(341, 132);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 49);
            this.btnClose.TabIndex = 14;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::CreditSales.Properties.Resources.OK;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(286, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 49);
            this.btnSave.TabIndex = 13;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDebt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 54);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сумма долга";
            // 
            // tbDebt
            // 
            this.tbDebt.Location = new System.Drawing.Point(7, 20);
            this.tbDebt.Name = "tbDebt";
            this.tbDebt.ReadOnly = true;
            this.tbDebt.Size = new System.Drawing.Size(115, 20);
            this.tbDebt.TabIndex = 0;
            this.tbDebt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datePayment);
            this.groupBox2.Location = new System.Drawing.Point(149, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 54);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дата уплаты";
            // 
            // datePayment
            // 
            this.datePayment.Location = new System.Drawing.Point(6, 20);
            this.datePayment.Name = "datePayment";
            this.datePayment.Size = new System.Drawing.Size(119, 20);
            this.datePayment.TabIndex = 17;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbMustPay);
            this.groupBox3.Location = new System.Drawing.Point(286, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 54);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Обязат. платёж";
            // 
            // tbMustPay
            // 
            this.tbMustPay.Location = new System.Drawing.Point(7, 20);
            this.tbMustPay.Name = "tbMustPay";
            this.tbMustPay.Size = new System.Drawing.Size(115, 20);
            this.tbMustPay.TabIndex = 0;
            this.tbMustPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMustPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMustPay_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbPercents);
            this.groupBox4.Location = new System.Drawing.Point(423, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(131, 54);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Сумма процентов";
            // 
            // tbPercents
            // 
            this.tbPercents.Location = new System.Drawing.Point(7, 20);
            this.tbPercents.Name = "tbPercents";
            this.tbPercents.Size = new System.Drawing.Size(115, 20);
            this.tbPercents.TabIndex = 0;
            this.tbPercents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPercents.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMustPay_KeyPress);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbPayment);
            this.groupBox5.Location = new System.Drawing.Point(560, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(131, 54);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Взнос";
            // 
            // tbPayment
            // 
            this.tbPayment.Location = new System.Drawing.Point(7, 20);
            this.tbPayment.Name = "tbPayment";
            this.tbPayment.Size = new System.Drawing.Size(115, 20);
            this.tbPayment.TabIndex = 0;
            this.tbPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMustPay_KeyPress);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbComment);
            this.groupBox6.Location = new System.Drawing.Point(12, 72);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(679, 54);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Комментарий";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(7, 20);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(663, 20);
            this.tbComment.TabIndex = 0;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Подсказка";
            // 
            // SchedulePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 190);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SchedulePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменить платёж";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDebt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker datePayment;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbMustPay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbPercents;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbPayment;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.ToolTip toolTip;
    }
}