namespace RetailPOSA.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.picShopLogo = new System.Windows.Forms.PictureBox();
            this.pnlSystem = new System.Windows.Forms.Panel();
            this.navAdminPanel = new System.Windows.Forms.Button();
            this.navUsers = new System.Windows.Forms.Button();
            this.navReports = new System.Windows.Forms.Button();
            this.navSettings = new System.Windows.Forms.Button();
            this.pnlSale = new System.Windows.Forms.Panel();
            this.navReturn = new System.Windows.Forms.Button();
            this.navPOS = new System.Windows.Forms.Button();
            this.navInvoices = new System.Windows.Forms.Button();
            this.pnlInventory = new System.Windows.Forms.Panel();
            this.navPriceChange = new System.Windows.Forms.Button();
            this.navAdjustment = new System.Windows.Forms.Button();
            this.navGRN = new System.Windows.Forms.Button();
            this.navInventory = new System.Windows.Forms.Button();
            this.pnlCatalog = new System.Windows.Forms.Panel();
            this.navSuppliers = new System.Windows.Forms.Button();
            this.navCategories = new System.Windows.Forms.Button();
            this.navProducts = new System.Windows.Forms.Button();
            this.btnNavSystem = new System.Windows.Forms.Button();
            this.btnNavSales = new System.Windows.Forms.Button();
            this.btnNavHome = new System.Windows.Forms.Button();
            this.btnNavInventory = new System.Windows.Forms.Button();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.navDashboard = new System.Windows.Forms.Button();
            this.navProfile = new System.Windows.Forms.Button();
            this.btnNavCatalog = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.MenuTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShopLogo)).BeginInit();
            this.pnlSystem.SuspendLayout();
            this.pnlSale.SuspendLayout();
            this.pnlInventory.SuspendLayout();
            this.pnlCatalog.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.pnlSidebar.Controls.Add(this.picShopLogo);
            this.pnlSidebar.Controls.Add(this.pnlSystem);
            this.pnlSidebar.Controls.Add(this.pnlSale);
            this.pnlSidebar.Controls.Add(this.pnlInventory);
            this.pnlSidebar.Controls.Add(this.pnlCatalog);
            this.pnlSidebar.Controls.Add(this.btnNavSystem);
            this.pnlSidebar.Controls.Add(this.btnNavSales);
            this.pnlSidebar.Controls.Add(this.btnNavHome);
            this.pnlSidebar.Controls.Add(this.btnNavInventory);
            this.pnlSidebar.Controls.Add(this.pnlHome);
            this.pnlSidebar.Controls.Add(this.btnNavCatalog);
            this.pnlSidebar.Controls.Add(this.lblRole);
            this.pnlSidebar.Controls.Add(this.lblUsername);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(515, 871);
            this.pnlSidebar.TabIndex = 0;
            // 
            // picShopLogo
            // 
            this.picShopLogo.Location = new System.Drawing.Point(71, 21);
            this.picShopLogo.Name = "picShopLogo";
            this.picShopLogo.Size = new System.Drawing.Size(120, 120);
            this.picShopLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShopLogo.TabIndex = 26;
            this.picShopLogo.TabStop = false;
            // 
            // pnlSystem
            // 
            this.pnlSystem.Controls.Add(this.navAdminPanel);
            this.pnlSystem.Controls.Add(this.navUsers);
            this.pnlSystem.Controls.Add(this.navReports);
            this.pnlSystem.Controls.Add(this.navSettings);
            this.pnlSystem.Location = new System.Drawing.Point(168, 598);
            this.pnlSystem.Name = "pnlSystem";
            this.pnlSystem.Size = new System.Drawing.Size(250, 240);
            this.pnlSystem.TabIndex = 25;
            // 
            // navAdminPanel
            // 
            this.navAdminPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navAdminPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navAdminPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navAdminPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navAdminPanel.Location = new System.Drawing.Point(0, 180);
            this.navAdminPanel.Name = "navAdminPanel";
            this.navAdminPanel.Size = new System.Drawing.Size(250, 50);
            this.navAdminPanel.TabIndex = 24;
            this.navAdminPanel.Text = "Admin Panel";
            this.navAdminPanel.UseVisualStyleBackColor = false;
            this.navAdminPanel.Click += new System.EventHandler(this.navAdminPanel_Click);
            // 
            // navUsers
            // 
            this.navUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navUsers.Location = new System.Drawing.Point(0, 121);
            this.navUsers.Name = "navUsers";
            this.navUsers.Size = new System.Drawing.Size(250, 50);
            this.navUsers.TabIndex = 23;
            this.navUsers.Text = "Users";
            this.navUsers.UseVisualStyleBackColor = false;
            this.navUsers.Click += new System.EventHandler(this.navUsers_Click);
            // 
            // navReports
            // 
            this.navReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navReports.Location = new System.Drawing.Point(0, 3);
            this.navReports.Name = "navReports";
            this.navReports.Size = new System.Drawing.Size(250, 50);
            this.navReports.TabIndex = 21;
            this.navReports.Text = "Reports";
            this.navReports.UseVisualStyleBackColor = false;
            this.navReports.Click += new System.EventHandler(this.navReports_Click);
            // 
            // navSettings
            // 
            this.navSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navSettings.Location = new System.Drawing.Point(0, 62);
            this.navSettings.Name = "navSettings";
            this.navSettings.Size = new System.Drawing.Size(250, 50);
            this.navSettings.TabIndex = 22;
            this.navSettings.Text = "Settings";
            this.navSettings.UseVisualStyleBackColor = false;
            this.navSettings.Click += new System.EventHandler(this.navSettings_Click);
            // 
            // pnlSale
            // 
            this.pnlSale.Controls.Add(this.navReturn);
            this.pnlSale.Controls.Add(this.navPOS);
            this.pnlSale.Controls.Add(this.navInvoices);
            this.pnlSale.Location = new System.Drawing.Point(258, 480);
            this.pnlSale.Name = "pnlSale";
            this.pnlSale.Size = new System.Drawing.Size(250, 180);
            this.pnlSale.TabIndex = 23;
            // 
            // navReturn
            // 
            this.navReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navReturn.Location = new System.Drawing.Point(-1, 120);
            this.navReturn.Name = "navReturn";
            this.navReturn.Size = new System.Drawing.Size(250, 50);
            this.navReturn.TabIndex = 23;
            this.navReturn.Text = "Return";
            this.navReturn.UseVisualStyleBackColor = false;
            this.navReturn.Click += new System.EventHandler(this.navReturn_Click);
            // 
            // navPOS
            // 
            this.navPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navPOS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navPOS.Location = new System.Drawing.Point(0, 2);
            this.navPOS.Name = "navPOS";
            this.navPOS.Size = new System.Drawing.Size(250, 50);
            this.navPOS.TabIndex = 21;
            this.navPOS.Text = "POS";
            this.navPOS.UseVisualStyleBackColor = false;
            this.navPOS.Click += new System.EventHandler(this.navPOS_Click);
            // 
            // navInvoices
            // 
            this.navInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navInvoices.Location = new System.Drawing.Point(0, 61);
            this.navInvoices.Name = "navInvoices";
            this.navInvoices.Size = new System.Drawing.Size(250, 50);
            this.navInvoices.TabIndex = 22;
            this.navInvoices.Text = "Invoices";
            this.navInvoices.UseVisualStyleBackColor = false;
            this.navInvoices.Click += new System.EventHandler(this.navInvoices_Click);
            // 
            // pnlInventory
            // 
            this.pnlInventory.Controls.Add(this.navPriceChange);
            this.pnlInventory.Controls.Add(this.navAdjustment);
            this.pnlInventory.Controls.Add(this.navGRN);
            this.pnlInventory.Controls.Add(this.navInventory);
            this.pnlInventory.Location = new System.Drawing.Point(30, 603);
            this.pnlInventory.Name = "pnlInventory";
            this.pnlInventory.Size = new System.Drawing.Size(250, 240);
            this.pnlInventory.TabIndex = 24;
            // 
            // navPriceChange
            // 
            this.navPriceChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navPriceChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navPriceChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navPriceChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navPriceChange.Location = new System.Drawing.Point(0, 180);
            this.navPriceChange.Name = "navPriceChange";
            this.navPriceChange.Size = new System.Drawing.Size(250, 50);
            this.navPriceChange.TabIndex = 24;
            this.navPriceChange.Text = "Price Change";
            this.navPriceChange.UseVisualStyleBackColor = false;
            this.navPriceChange.Click += new System.EventHandler(this.navPriceChange_Click);
            // 
            // navAdjustment
            // 
            this.navAdjustment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navAdjustment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navAdjustment.Location = new System.Drawing.Point(0, 121);
            this.navAdjustment.Name = "navAdjustment";
            this.navAdjustment.Size = new System.Drawing.Size(250, 50);
            this.navAdjustment.TabIndex = 23;
            this.navAdjustment.Text = "Adjustments";
            this.navAdjustment.UseVisualStyleBackColor = false;
            this.navAdjustment.Click += new System.EventHandler(this.navAdjustment_Click);
            // 
            // navGRN
            // 
            this.navGRN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navGRN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navGRN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navGRN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navGRN.Location = new System.Drawing.Point(0, 3);
            this.navGRN.Name = "navGRN";
            this.navGRN.Size = new System.Drawing.Size(250, 50);
            this.navGRN.TabIndex = 21;
            this.navGRN.Text = "GRN";
            this.navGRN.UseVisualStyleBackColor = false;
            this.navGRN.Click += new System.EventHandler(this.navGRN_Click);
            // 
            // navInventory
            // 
            this.navInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navInventory.Location = new System.Drawing.Point(0, 62);
            this.navInventory.Name = "navInventory";
            this.navInventory.Size = new System.Drawing.Size(250, 50);
            this.navInventory.TabIndex = 22;
            this.navInventory.Text = "Inventory";
            this.navInventory.UseVisualStyleBackColor = false;
            this.navInventory.Click += new System.EventHandler(this.navInventory_Click);
            // 
            // pnlCatalog
            // 
            this.pnlCatalog.Controls.Add(this.navSuppliers);
            this.pnlCatalog.Controls.Add(this.navCategories);
            this.pnlCatalog.Controls.Add(this.navProducts);
            this.pnlCatalog.Location = new System.Drawing.Point(259, 294);
            this.pnlCatalog.Name = "pnlCatalog";
            this.pnlCatalog.Size = new System.Drawing.Size(250, 180);
            this.pnlCatalog.TabIndex = 23;
            // 
            // navSuppliers
            // 
            this.navSuppliers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navSuppliers.Location = new System.Drawing.Point(0, 121);
            this.navSuppliers.Name = "navSuppliers";
            this.navSuppliers.Size = new System.Drawing.Size(250, 50);
            this.navSuppliers.TabIndex = 23;
            this.navSuppliers.Text = "Suppliers";
            this.navSuppliers.UseVisualStyleBackColor = false;
            this.navSuppliers.Click += new System.EventHandler(this.navSuppliers_Click);
            // 
            // navCategories
            // 
            this.navCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navCategories.Location = new System.Drawing.Point(0, 3);
            this.navCategories.Name = "navCategories";
            this.navCategories.Size = new System.Drawing.Size(250, 50);
            this.navCategories.TabIndex = 21;
            this.navCategories.Text = "Categories";
            this.navCategories.UseVisualStyleBackColor = false;
            this.navCategories.Click += new System.EventHandler(this.navCategories_Click);
            // 
            // navProducts
            // 
            this.navProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navProducts.Location = new System.Drawing.Point(0, 62);
            this.navProducts.Name = "navProducts";
            this.navProducts.Size = new System.Drawing.Size(250, 50);
            this.navProducts.TabIndex = 22;
            this.navProducts.Text = "Products";
            this.navProducts.UseVisualStyleBackColor = false;
            this.navProducts.Click += new System.EventHandler(this.navProducts_Click);
            // 
            // btnNavSystem
            // 
            this.btnNavSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.btnNavSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavSystem.Image = ((System.Drawing.Image)(resources.GetObject("btnNavSystem.Image")));
            this.btnNavSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSystem.Location = new System.Drawing.Point(3, 511);
            this.btnNavSystem.Name = "btnNavSystem";
            this.btnNavSystem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavSystem.Size = new System.Drawing.Size(250, 80);
            this.btnNavSystem.TabIndex = 25;
            this.btnNavSystem.Text = "System";
            this.btnNavSystem.UseVisualStyleBackColor = false;
            this.btnNavSystem.Click += new System.EventHandler(this.btnNavSystem_Click);
            // 
            // btnNavSales
            // 
            this.btnNavSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.btnNavSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavSales.Image = ((System.Drawing.Image)(resources.GetObject("btnNavSales.Image")));
            this.btnNavSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSales.Location = new System.Drawing.Point(3, 426);
            this.btnNavSales.Name = "btnNavSales";
            this.btnNavSales.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavSales.Size = new System.Drawing.Size(250, 80);
            this.btnNavSales.TabIndex = 24;
            this.btnNavSales.Text = "Sales";
            this.btnNavSales.UseVisualStyleBackColor = false;
            this.btnNavSales.Click += new System.EventHandler(this.btnNavSales_Click);
            // 
            // btnNavHome
            // 
            this.btnNavHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.btnNavHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavHome.Image = ((System.Drawing.Image)(resources.GetObject("btnNavHome.Image")));
            this.btnNavHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavHome.Location = new System.Drawing.Point(3, 168);
            this.btnNavHome.Name = "btnNavHome";
            this.btnNavHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavHome.Size = new System.Drawing.Size(250, 80);
            this.btnNavHome.TabIndex = 20;
            this.btnNavHome.Text = "Home";
            this.btnNavHome.UseVisualStyleBackColor = false;
            this.btnNavHome.Click += new System.EventHandler(this.btnNavHome_Click);
            // 
            // btnNavInventory
            // 
            this.btnNavInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.btnNavInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnNavInventory.Image")));
            this.btnNavInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavInventory.Location = new System.Drawing.Point(3, 340);
            this.btnNavInventory.Name = "btnNavInventory";
            this.btnNavInventory.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavInventory.Size = new System.Drawing.Size(250, 80);
            this.btnNavInventory.TabIndex = 23;
            this.btnNavInventory.Text = "Inventory";
            this.btnNavInventory.UseVisualStyleBackColor = false;
            this.btnNavInventory.Click += new System.EventHandler(this.btnNavInventory_Click);
            // 
            // pnlHome
            // 
            this.pnlHome.Controls.Add(this.navDashboard);
            this.pnlHome.Controls.Add(this.navProfile);
            this.pnlHome.Location = new System.Drawing.Point(259, 168);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(250, 120);
            this.pnlHome.TabIndex = 19;
            // 
            // navDashboard
            // 
            this.navDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navDashboard.Location = new System.Drawing.Point(0, 2);
            this.navDashboard.Name = "navDashboard";
            this.navDashboard.Size = new System.Drawing.Size(250, 50);
            this.navDashboard.TabIndex = 21;
            this.navDashboard.Text = "Dashboard";
            this.navDashboard.UseVisualStyleBackColor = false;
            // 
            // navProfile
            // 
            this.navProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.navProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navProfile.Location = new System.Drawing.Point(0, 62);
            this.navProfile.Name = "navProfile";
            this.navProfile.Size = new System.Drawing.Size(250, 50);
            this.navProfile.TabIndex = 22;
            this.navProfile.Text = "Profile";
            this.navProfile.UseVisualStyleBackColor = false;
            // 
            // btnNavCatalog
            // 
            this.btnNavCatalog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.btnNavCatalog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNavCatalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavCatalog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavCatalog.Image = ((System.Drawing.Image)(resources.GetObject("btnNavCatalog.Image")));
            this.btnNavCatalog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCatalog.Location = new System.Drawing.Point(3, 254);
            this.btnNavCatalog.Name = "btnNavCatalog";
            this.btnNavCatalog.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavCatalog.Size = new System.Drawing.Size(250, 80);
            this.btnNavCatalog.TabIndex = 21;
            this.btnNavCatalog.Text = "Catalog";
            this.btnNavCatalog.UseVisualStyleBackColor = false;
            this.btnNavCatalog.Click += new System.EventHandler(this.btnNavCatalog_Click);
            // 
            // lblRole
            // 
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRole.Location = new System.Drawing.Point(12, 847);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(36, 16);
            this.lblRole.TabIndex = 14;
            this.lblRole.Text = "Role";
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblUsername.Location = new System.Drawing.Point(11, 826);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(70, 16);
            this.lblUsername.TabIndex = 13;
            this.lblUsername.Text = "Username";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(515, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(972, 871);
            this.pnlContent.TabIndex = 1;
            // 
            // MenuTimer
            // 
            this.MenuTimer.Interval = 10;
            this.MenuTimer.Tick += new System.EventHandler(this.MenuTimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 871);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(1500, 900);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nexora POS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShopLogo)).EndInit();
            this.pnlSystem.ResumeLayout(false);
            this.pnlSale.ResumeLayout(false);
            this.pnlInventory.ResumeLayout(false);
            this.pnlCatalog.ResumeLayout(false);
            this.pnlHome.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Button btnNavHome;
        private System.Windows.Forms.Button navProfile;
        private System.Windows.Forms.Button navDashboard;
        private System.Windows.Forms.Button btnNavCatalog;
        private System.Windows.Forms.Timer MenuTimer;
        private System.Windows.Forms.Button btnNavSystem;
        private System.Windows.Forms.Button btnNavSales;
        private System.Windows.Forms.Button btnNavInventory;
        private System.Windows.Forms.Panel pnlCatalog;
        private System.Windows.Forms.Button navSuppliers;
        private System.Windows.Forms.Button navCategories;
        private System.Windows.Forms.Button navProducts;
        private System.Windows.Forms.Panel pnlInventory;
        private System.Windows.Forms.Button navPriceChange;
        private System.Windows.Forms.Button navAdjustment;
        private System.Windows.Forms.Button navGRN;
        private System.Windows.Forms.Button navInventory;
        private System.Windows.Forms.Panel pnlSale;
        private System.Windows.Forms.Button navPOS;
        private System.Windows.Forms.Button navInvoices;
        private System.Windows.Forms.Panel pnlSystem;
        private System.Windows.Forms.Button navAdminPanel;
        private System.Windows.Forms.Button navUsers;
        private System.Windows.Forms.Button navReports;
        private System.Windows.Forms.Button navSettings;
        private System.Windows.Forms.PictureBox picShopLogo;
        private System.Windows.Forms.Button navReturn;
    }
}