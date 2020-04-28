namespace CreditSales.Interface
{
    partial class PaymentGraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentGraph));
            this.btnSave = new System.Windows.Forms.Button();
            this.tbPercent = new System.Windows.Forms.TextBox();
            this.tbPenaltyPercent = new System.Windows.Forms.TextBox();
            this.tbMonths = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirstPayment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLastCreditNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbRound = new System.Windows.Forms.ComboBox();
            this.cbPaymentDay = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::CreditSales.Properties.Resources.OK;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(115, 193);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 48);
            this.btnSave.TabIndex = 7;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbPercent
            // 
            this.tbPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPercent.Location = new System.Drawing.Point(208, 64);
            this.tbPercent.Name = "tbPercent";
            this.tbPercent.Size = new System.Drawing.Size(75, 20);
            this.tbPercent.TabIndex = 32;
            this.tbPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstPayment_KeyPress);
            // 
            // tbPenaltyPercent
            // 
            this.tbPenaltyPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPenaltyPercent.Location = new System.Drawing.Point(208, 116);
            this.tbPenaltyPercent.Name = "tbPenaltyPercent";
            this.tbPenaltyPercent.Size = new System.Drawing.Size(75, 20);
            this.tbPenaltyPercent.TabIndex = 31;
            this.tbPenaltyPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPenaltyPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstPayment_KeyPress);
            // 
            // tbMonths
            // 
            this.tbMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMonths.Location = new System.Drawing.Point(208, 38);
            this.tbMonths.Name = "tbMonths";
            this.tbMonths.Size = new System.Drawing.Size(75, 20);
            this.tbMonths.TabIndex = 29;
            this.tbMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMonths.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstPayment_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Процент кредитования (годовых):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Процент пени:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "День уплаты по кредиту:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Количество месяцев кредитования:";
            // 
            // tbFirstPayment
            // 
            this.tbFirstPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFirstPayment.Location = new System.Drawing.Point(208, 12);
            this.tbFirstPayment.Name = "tbFirstPayment";
            this.tbFirstPayment.Size = new System.Drawing.Size(75, 20);
            this.tbFirstPayment.TabIndex = 24;
            this.tbFirstPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbFirstPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstPayment_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "% первоначального взноса:";
            // 
            // tbLastCreditNumber
            // 
            this.tbLastCreditNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastCreditNumber.Location = new System.Drawing.Point(208, 168);
            this.tbLastCreditNumber.Name = "tbLastCreditNumber";
            this.tbLastCreditNumber.Size = new System.Drawing.Size(75, 20);
            this.tbLastCreditNumber.TabIndex = 36;
            this.tbLastCreditNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbLastCreditNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstPayment_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Последний номер договора:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Взнос округлять до:";
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Подсказка";
            // 
            // cbRound
            // 
            this.cbRound.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRound.FormattingEnabled = true;
            this.cbRound.Items.AddRange(new object[] {
            "0",
            "1",
            "10",
            "100"});
            this.cbRound.Location = new System.Drawing.Point(208, 142);
            this.cbRound.Name = "cbRound";
            this.cbRound.Size = new System.Drawing.Size(75, 21);
            this.cbRound.TabIndex = 37;
            this.cbRound.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cb_DrawItem);
            // 
            // cbPaymentDay
            // 
            this.cbPaymentDay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPaymentDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentDay.FormattingEnabled = true;
            this.cbPaymentDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cbPaymentDay.Location = new System.Drawing.Point(208, 89);
            this.cbPaymentDay.Name = "cbPaymentDay";
            this.cbPaymentDay.Size = new System.Drawing.Size(75, 21);
            this.cbPaymentDay.TabIndex = 38;
            this.cbPaymentDay.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cb_DrawItem);
            // 
            // PaymentGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 253);
            this.Controls.Add(this.cbPaymentDay);
            this.Controls.Add(this.cbRound);
            this.Controls.Add(this.tbLastCreditNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPercent);
            this.Controls.Add(this.tbPenaltyPercent);
            this.Controls.Add(this.tbMonths);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFirstPayment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "График кредитования";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbPercent;
        private System.Windows.Forms.TextBox tbPenaltyPercent;
        private System.Windows.Forms.TextBox tbMonths;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFirstPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLastCreditNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cbRound;
        private System.Windows.Forms.ComboBox cbPaymentDay;
    }
}