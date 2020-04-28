namespace CreditSales.Interface
{
    partial class AddUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUserAdr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUserPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPaymentsInfo = new System.Windows.Forms.CheckBox();
            this.cbAddPayments = new System.Windows.Forms.CheckBox();
            this.cbAwaitablePayments = new System.Windows.Forms.CheckBox();
            this.cbPayments = new System.Windows.Forms.CheckBox();
            this.cbReportCredits = new System.Windows.Forms.CheckBox();
            this.cbRegistration = new System.Windows.Forms.CheckBox();
            this.cbBlackList = new System.Windows.Forms.CheckBox();
            this.cbUsers = new System.Windows.Forms.CheckBox();
            this.cbSchedule = new System.Windows.Forms.CheckBox();
            this.cbProducts = new System.Windows.Forms.CheckBox();
            this.cbMainInfo = new System.Windows.Forms.CheckBox();
            this.cbDeleteCredit = new System.Windows.Forms.CheckBox();
            this.cbEditCredit = new System.Windows.Forms.CheckBox();
            this.cbAddCredit = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::CreditSales.Properties.Resources.OK;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(58, 533);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 49);
            this.btnSave.TabIndex = 13;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::CreditSales.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(113, 533);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 49);
            this.btnClose.TabIndex = 23;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Логин:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(73, 12);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(154, 20);
            this.tbLogin.TabIndex = 25;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(73, 38);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(154, 20);
            this.tbPass.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Пароль:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(73, 64);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(154, 20);
            this.tbUser.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Ф.И.О.:";
            // 
            // tbUserAdr
            // 
            this.tbUserAdr.Location = new System.Drawing.Point(73, 90);
            this.tbUserAdr.Name = "tbUserAdr";
            this.tbUserAdr.Size = new System.Drawing.Size(154, 20);
            this.tbUserAdr.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Адрес:";
            // 
            // tbUserPhone
            // 
            this.tbUserPhone.Location = new System.Drawing.Point(73, 116);
            this.tbUserPhone.Name = "tbUserPhone";
            this.tbUserPhone.Size = new System.Drawing.Size(154, 20);
            this.tbUserPhone.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Телефон:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPaymentsInfo);
            this.groupBox1.Controls.Add(this.cbAddPayments);
            this.groupBox1.Controls.Add(this.cbAwaitablePayments);
            this.groupBox1.Controls.Add(this.cbPayments);
            this.groupBox1.Controls.Add(this.cbReportCredits);
            this.groupBox1.Controls.Add(this.cbRegistration);
            this.groupBox1.Controls.Add(this.cbBlackList);
            this.groupBox1.Controls.Add(this.cbUsers);
            this.groupBox1.Controls.Add(this.cbSchedule);
            this.groupBox1.Controls.Add(this.cbProducts);
            this.groupBox1.Controls.Add(this.cbMainInfo);
            this.groupBox1.Controls.Add(this.cbDeleteCredit);
            this.groupBox1.Controls.Add(this.cbEditCredit);
            this.groupBox1.Controls.Add(this.cbAddCredit);
            this.groupBox1.Location = new System.Drawing.Point(15, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 385);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Права пользователя";
            // 
            // cbPaymentsInfo
            // 
            this.cbPaymentsInfo.AutoSize = true;
            this.cbPaymentsInfo.Location = new System.Drawing.Point(6, 361);
            this.cbPaymentsInfo.Name = "cbPaymentsInfo";
            this.cbPaymentsInfo.Size = new System.Drawing.Size(152, 17);
            this.cbPaymentsInfo.TabIndex = 13;
            this.cbPaymentsInfo.Text = "Просматривать платежи";
            this.cbPaymentsInfo.UseVisualStyleBackColor = true;
            // 
            // cbAddPayments
            // 
            this.cbAddPayments.AutoSize = true;
            this.cbAddPayments.Location = new System.Drawing.Point(6, 338);
            this.cbAddPayments.Name = "cbAddPayments";
            this.cbAddPayments.Size = new System.Drawing.Size(128, 17);
            this.cbAddPayments.TabIndex = 12;
            this.cbAddPayments.Text = "Добавлять платежи";
            this.cbAddPayments.UseVisualStyleBackColor = true;
            // 
            // cbAwaitablePayments
            // 
            this.cbAwaitablePayments.AutoSize = true;
            this.cbAwaitablePayments.Location = new System.Drawing.Point(6, 305);
            this.cbAwaitablePayments.Name = "cbAwaitablePayments";
            this.cbAwaitablePayments.Size = new System.Drawing.Size(183, 17);
            this.cbAwaitablePayments.TabIndex = 11;
            this.cbAwaitablePayments.Text = "Отчёт об ожидаемых платежах";
            this.cbAwaitablePayments.UseVisualStyleBackColor = true;
            // 
            // cbPayments
            // 
            this.cbPayments.AutoSize = true;
            this.cbPayments.Location = new System.Drawing.Point(6, 282);
            this.cbPayments.Name = "cbPayments";
            this.cbPayments.Size = new System.Drawing.Size(182, 17);
            this.cbPayments.TabIndex = 10;
            this.cbPayments.Text = "Отчёт о платежах по кредитам";
            this.cbPayments.UseVisualStyleBackColor = true;
            // 
            // cbReportCredits
            // 
            this.cbReportCredits.AutoSize = true;
            this.cbReportCredits.Location = new System.Drawing.Point(6, 259);
            this.cbReportCredits.Name = "cbReportCredits";
            this.cbReportCredits.Size = new System.Drawing.Size(167, 17);
            this.cbReportCredits.TabIndex = 9;
            this.cbReportCredits.Text = "Отчёт о выданных кредитах";
            this.cbReportCredits.UseVisualStyleBackColor = true;
            // 
            // cbRegistration
            // 
            this.cbRegistration.AutoSize = true;
            this.cbRegistration.Location = new System.Drawing.Point(6, 226);
            this.cbRegistration.Name = "cbRegistration";
            this.cbRegistration.Size = new System.Drawing.Size(153, 17);
            this.cbRegistration.TabIndex = 8;
            this.cbRegistration.Text = "Регистрация программы";
            this.cbRegistration.UseVisualStyleBackColor = true;
            // 
            // cbBlackList
            // 
            this.cbBlackList.AutoSize = true;
            this.cbBlackList.Location = new System.Drawing.Point(6, 191);
            this.cbBlackList.Name = "cbBlackList";
            this.cbBlackList.Size = new System.Drawing.Size(155, 17);
            this.cbBlackList.TabIndex = 7;
            this.cbBlackList.Text = "Чёрный список клиентов";
            this.cbBlackList.UseVisualStyleBackColor = true;
            // 
            // cbUsers
            // 
            this.cbUsers.AutoSize = true;
            this.cbUsers.Location = new System.Drawing.Point(6, 168);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(166, 17);
            this.cbUsers.TabIndex = 6;
            this.cbUsers.Text = "Справочник пользователей";
            this.cbUsers.UseVisualStyleBackColor = true;
            // 
            // cbSchedule
            // 
            this.cbSchedule.AutoSize = true;
            this.cbSchedule.Location = new System.Drawing.Point(6, 145);
            this.cbSchedule.Name = "cbSchedule";
            this.cbSchedule.Size = new System.Drawing.Size(206, 17);
            this.cbSchedule.TabIndex = 5;
            this.cbSchedule.Text = "Справочник графика кредитования";
            this.cbSchedule.UseVisualStyleBackColor = true;
            // 
            // cbProducts
            // 
            this.cbProducts.AutoSize = true;
            this.cbProducts.Location = new System.Drawing.Point(6, 122);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(130, 17);
            this.cbProducts.TabIndex = 4;
            this.cbProducts.Text = "Справочник товаров";
            this.cbProducts.UseVisualStyleBackColor = true;
            // 
            // cbMainInfo
            // 
            this.cbMainInfo.AutoSize = true;
            this.cbMainInfo.Location = new System.Drawing.Point(6, 99);
            this.cbMainInfo.Name = "cbMainInfo";
            this.cbMainInfo.Size = new System.Drawing.Size(189, 17);
            this.cbMainInfo.TabIndex = 3;
            this.cbMainInfo.Text = "Справочник основных сведений";
            this.cbMainInfo.UseVisualStyleBackColor = true;
            // 
            // cbDeleteCredit
            // 
            this.cbDeleteCredit.AutoSize = true;
            this.cbDeleteCredit.Location = new System.Drawing.Point(6, 65);
            this.cbDeleteCredit.Name = "cbDeleteCredit";
            this.cbDeleteCredit.Size = new System.Drawing.Size(113, 17);
            this.cbDeleteCredit.TabIndex = 2;
            this.cbDeleteCredit.Text = "Удалять договор";
            this.cbDeleteCredit.UseVisualStyleBackColor = true;
            // 
            // cbEditCredit
            // 
            this.cbEditCredit.AutoSize = true;
            this.cbEditCredit.Location = new System.Drawing.Point(6, 42);
            this.cbEditCredit.Name = "cbEditCredit";
            this.cbEditCredit.Size = new System.Drawing.Size(121, 17);
            this.cbEditCredit.TabIndex = 1;
            this.cbEditCredit.Text = "Изменять договор";
            this.cbEditCredit.UseVisualStyleBackColor = true;
            // 
            // cbAddCredit
            // 
            this.cbAddCredit.AutoSize = true;
            this.cbAddCredit.Location = new System.Drawing.Point(6, 19);
            this.cbAddCredit.Name = "cbAddCredit";
            this.cbAddCredit.Size = new System.Drawing.Size(126, 17);
            this.cbAddCredit.TabIndex = 0;
            this.cbAddCredit.Text = "Добавлять договор";
            this.cbAddCredit.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Подсказка";
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 589);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbUserPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbUserAdr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователь";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUserAdr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUserPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbPaymentsInfo;
        private System.Windows.Forms.CheckBox cbAddPayments;
        private System.Windows.Forms.CheckBox cbAwaitablePayments;
        private System.Windows.Forms.CheckBox cbPayments;
        private System.Windows.Forms.CheckBox cbReportCredits;
        private System.Windows.Forms.CheckBox cbRegistration;
        private System.Windows.Forms.CheckBox cbBlackList;
        private System.Windows.Forms.CheckBox cbUsers;
        private System.Windows.Forms.CheckBox cbSchedule;
        private System.Windows.Forms.CheckBox cbProducts;
        private System.Windows.Forms.CheckBox cbMainInfo;
        private System.Windows.Forms.CheckBox cbDeleteCredit;
        private System.Windows.Forms.CheckBox cbEditCredit;
        private System.Windows.Forms.CheckBox cbAddCredit;
        private System.Windows.Forms.ToolTip toolTip;
    }
}