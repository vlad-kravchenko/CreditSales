namespace CreditSales.Interface
{
    partial class Products
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gridProducts = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.productsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStripNewProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripEditProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDeleteProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.gridCategories = new System.Windows.Forms.DataGridView();
            this.catName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripNewCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripEditCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            this.productsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).BeginInit();
            this.categoryContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.btnDeleteCategory);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEditCategory);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAddCategory);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 395);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 55);
            this.panel1.TabIndex = 0;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.BackgroundImage = global::CreditSales.Properties.Resources.delete;
            this.btnDeleteCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteCategory.Location = new System.Drawing.Point(1012, 3);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(49, 49);
            this.btnDeleteCategory.TabIndex = 14;
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::CreditSales.Properties.Resources.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.Location = new System.Drawing.Point(122, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 49);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.BackgroundImage = global::CreditSales.Properties.Resources.edit;
            this.btnEditCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditCategory.Location = new System.Drawing.Point(957, 3);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(49, 49);
            this.btnEditCategory.TabIndex = 13;
            this.btnEditCategory.UseVisualStyleBackColor = true;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::CreditSales.Properties.Resources.edit;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.Location = new System.Drawing.Point(67, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(49, 49);
            this.btnEdit.TabIndex = 25;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackgroundImage = global::CreditSales.Properties.Resources._new;
            this.btnAddCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddCategory.Location = new System.Drawing.Point(902, 3);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(49, 49);
            this.btnAddCategory.TabIndex = 12;
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::CreditSales.Properties.Resources._new;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Location = new System.Drawing.Point(12, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 49);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::CreditSales.Properties.Resources.OK;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(796, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 49);
            this.btnSave.TabIndex = 23;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridProducts
            // 
            this.gridProducts.AllowUserToAddRows = false;
            this.gridProducts.AllowUserToDeleteRows = false;
            this.gridProducts.AllowUserToResizeRows = false;
            this.gridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.Column1,
            this.colPrice,
            this.colAdd,
            this.colDiscount,
            this.colTotalPrice,
            this.Column6});
            this.gridProducts.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridProducts.Location = new System.Drawing.Point(0, 0);
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.RowHeadersVisible = false;
            this.gridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProducts.Size = new System.Drawing.Size(845, 395);
            this.gridProducts.TabIndex = 1;
            this.gridProducts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridProducts_MouseClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Width = 50;
            // 
            // colName
            // 
            this.colName.HeaderText = "Название";
            this.colName.Name = "colName";
            this.colName.Width = 200;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Категория";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // colPrice
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPrice.HeaderText = "Стоимость";
            this.colPrice.Name = "colPrice";
            // 
            // colAdd
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAdd.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAdd.HeaderText = "% надбавки";
            this.colAdd.Name = "colAdd";
            // 
            // colDiscount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDiscount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDiscount.HeaderText = "% скидки";
            this.colDiscount.Name = "colDiscount";
            // 
            // colTotalPrice
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTotalPrice.HeaderText = "Цена";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.Width = 130;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Подсказка";
            // 
            // productsContextMenu
            // 
            this.productsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripNewProduct,
            this.menuStripEditProduct,
            this.menuStripDeleteProduct,
            this.toolStripSeparator3,
            this.menuStripLoad});
            this.productsContextMenu.Name = "gridContextMenu";
            this.productsContextMenu.Size = new System.Drawing.Size(225, 98);
            // 
            // menuStripNewProduct
            // 
            this.menuStripNewProduct.Image = global::CreditSales.Properties.Resources._new;
            this.menuStripNewProduct.Name = "menuStripNewProduct";
            this.menuStripNewProduct.Size = new System.Drawing.Size(224, 22);
            this.menuStripNewProduct.Text = "Новый товар";
            this.menuStripNewProduct.Click += new System.EventHandler(this.menuStripNewProduct_Click);
            // 
            // menuStripEditProduct
            // 
            this.menuStripEditProduct.Image = global::CreditSales.Properties.Resources.edit;
            this.menuStripEditProduct.Name = "menuStripEditProduct";
            this.menuStripEditProduct.Size = new System.Drawing.Size(224, 22);
            this.menuStripEditProduct.Text = "Редактировать товар";
            this.menuStripEditProduct.Click += new System.EventHandler(this.menuStripEditProduct_Click);
            // 
            // menuStripDeleteProduct
            // 
            this.menuStripDeleteProduct.Image = global::CreditSales.Properties.Resources.delete;
            this.menuStripDeleteProduct.Name = "menuStripDeleteProduct";
            this.menuStripDeleteProduct.Size = new System.Drawing.Size(224, 22);
            this.menuStripDeleteProduct.Text = "Удалить товар";
            this.menuStripDeleteProduct.Click += new System.EventHandler(this.menuStripDeleteProduct_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // menuStripLoad
            // 
            this.menuStripLoad.Image = global::CreditSales.Properties.Resources.reportPayments;
            this.menuStripLoad.Name = "menuStripLoad";
            this.menuStripLoad.Size = new System.Drawing.Size(224, 22);
            this.menuStripLoad.Text = "Загрузить товары из файла";
            this.menuStripLoad.Click += new System.EventHandler(this.menuStripLoad_Click);
            // 
            // gridCategories
            // 
            this.gridCategories.AllowUserToAddRows = false;
            this.gridCategories.AllowUserToDeleteRows = false;
            this.gridCategories.AllowUserToResizeRows = false;
            this.gridCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.catName,
            this.dataGridViewTextBoxColumn7});
            this.gridCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCategories.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCategories.Location = new System.Drawing.Point(845, 0);
            this.gridCategories.MultiSelect = false;
            this.gridCategories.Name = "gridCategories";
            this.gridCategories.RowHeadersVisible = false;
            this.gridCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCategories.Size = new System.Drawing.Size(219, 395);
            this.gridCategories.TabIndex = 2;
            this.gridCategories.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridCategories_MouseClick);
            // 
            // catName
            // 
            this.catName.HeaderText = "Название";
            this.catName.Name = "catName";
            this.catName.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.HeaderText = "";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // categoryContextMenu
            // 
            this.categoryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNewCategory,
            this.toolStripEditCategory,
            this.toolStripDeleteCategory});
            this.categoryContextMenu.Name = "gridContextMenu";
            this.categoryContextMenu.Size = new System.Drawing.Size(217, 70);
            // 
            // toolStripNewCategory
            // 
            this.toolStripNewCategory.Image = global::CreditSales.Properties.Resources._new;
            this.toolStripNewCategory.Name = "toolStripNewCategory";
            this.toolStripNewCategory.Size = new System.Drawing.Size(216, 22);
            this.toolStripNewCategory.Text = "Новая категория";
            this.toolStripNewCategory.Click += new System.EventHandler(this.toolStripNewCategory_Click);
            // 
            // toolStripEditCategory
            // 
            this.toolStripEditCategory.Image = global::CreditSales.Properties.Resources._new;
            this.toolStripEditCategory.Name = "toolStripEditCategory";
            this.toolStripEditCategory.Size = new System.Drawing.Size(216, 22);
            this.toolStripEditCategory.Text = "Редактировать категорию";
            this.toolStripEditCategory.Click += new System.EventHandler(this.toolStripEditCategory_Click);
            // 
            // toolStripDeleteCategory
            // 
            this.toolStripDeleteCategory.Image = global::CreditSales.Properties.Resources.edit;
            this.toolStripDeleteCategory.Name = "toolStripDeleteCategory";
            this.toolStripDeleteCategory.Size = new System.Drawing.Size(216, 22);
            this.toolStripDeleteCategory.Text = "Удалить категорию";
            this.toolStripDeleteCategory.Click += new System.EventHandler(this.toolStripDeleteCategory_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(422, 13);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(202, 28);
            this.cbCategory.TabIndex = 27;
            this.cbCategory.TextChanged += new System.EventHandler(this.cbCategory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Выбрать товары из категории";
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 450);
            this.Controls.Add(this.gridCategories);
            this.Controls.Add(this.gridProducts);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Products";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник товаров";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            this.productsContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).EndInit();
            this.categoryContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridProducts;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip productsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuStripNewProduct;
        private System.Windows.Forms.ToolStripMenuItem menuStripEditProduct;
        private System.Windows.Forms.ToolStripMenuItem menuStripDeleteProduct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuStripLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView gridCategories;
        private System.Windows.Forms.ContextMenuStrip categoryContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripNewCategory;
        private System.Windows.Forms.ToolStripMenuItem toolStripEditCategory;
        private System.Windows.Forms.ToolStripMenuItem toolStripDeleteCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn catName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCategory;
    }
}