namespace CreditSales.Interface
{
    partial class BlackList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackList));
            this.panel = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gridUsers = new System.Windows.Forms.DataGridView();
            this.colFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addUser = new System.Windows.Forms.ToolStripMenuItem();
            this.editUser = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            this.gridContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnDelete);
            this.panel.Controls.Add(this.btnEdit);
            this.panel.Controls.Add(this.btnAdd);
            this.panel.Controls.Add(this.btnSave);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 386);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(779, 58);
            this.panel.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::CreditSales.Properties.Resources.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.Location = new System.Drawing.Point(122, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 49);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::CreditSales.Properties.Resources.edit;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.Location = new System.Drawing.Point(67, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(49, 49);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::CreditSales.Properties.Resources._new;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Location = new System.Drawing.Point(12, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 49);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::CreditSales.Properties.Resources.OK;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(353, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 49);
            this.btnSave.TabIndex = 12;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridUsers
            // 
            this.gridUsers.AllowUserToAddRows = false;
            this.gridUsers.AllowUserToDeleteRows = false;
            this.gridUsers.AllowUserToResizeRows = false;
            this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFIO,
            this.colAdr,
            this.colDoc,
            this.colPhone,
            this.Column6});
            this.gridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridUsers.Location = new System.Drawing.Point(0, 0);
            this.gridUsers.MultiSelect = false;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.RowHeadersVisible = false;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Size = new System.Drawing.Size(779, 386);
            this.gridUsers.TabIndex = 2;
            this.gridUsers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridUsers_MouseClick);
            // 
            // colFIO
            // 
            this.colFIO.HeaderText = "Ф.И.О. пользователя";
            this.colFIO.Name = "colFIO";
            this.colFIO.Width = 250;
            // 
            // colAdr
            // 
            this.colAdr.HeaderText = "Адрес";
            this.colAdr.Name = "colAdr";
            this.colAdr.Width = 200;
            // 
            // colDoc
            // 
            this.colDoc.HeaderText = "Документ";
            this.colDoc.Name = "colDoc";
            this.colDoc.Width = 200;
            // 
            // colPhone
            // 
            this.colPhone.HeaderText = "Телефон";
            this.colPhone.Name = "colPhone";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            // 
            // gridContextMenu
            // 
            this.gridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUser,
            this.editUser,
            this.deleteUser});
            this.gridContextMenu.Name = "gridContextMenu";
            this.gridContextMenu.Size = new System.Drawing.Size(221, 70);
            // 
            // addUser
            // 
            this.addUser.Image = global::CreditSales.Properties.Resources._new;
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(220, 22);
            this.addUser.Text = "Добавить покупателя";
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // editUser
            // 
            this.editUser.Image = global::CreditSales.Properties.Resources.edit;
            this.editUser.Name = "editUser";
            this.editUser.Size = new System.Drawing.Size(220, 22);
            this.editUser.Text = "Редактировать покупателя";
            this.editUser.Click += new System.EventHandler(this.editUser_Click);
            // 
            // deleteUser
            // 
            this.deleteUser.Image = global::CreditSales.Properties.Resources.delete;
            this.deleteUser.Name = "deleteUser";
            this.deleteUser.Size = new System.Drawing.Size(220, 22);
            this.deleteUser.Text = "Удалить покупателя";
            this.deleteUser.Click += new System.EventHandler(this.deleteUser_Click);
            // 
            // BlackList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 444);
            this.Controls.Add(this.gridUsers);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BlackList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чёрный список";
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            this.gridContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip gridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addUser;
        private System.Windows.Forms.ToolStripMenuItem editUser;
        private System.Windows.Forms.ToolStripMenuItem deleteUser;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
    }
}