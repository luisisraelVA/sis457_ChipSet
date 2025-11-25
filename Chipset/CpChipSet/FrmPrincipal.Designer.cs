namespace CpChipSet
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.c1Ribbon1 = new C1.Win.C1Ribbon.C1Ribbon();
            this.ribbonApplicationMenu1 = new C1.Win.C1Ribbon.RibbonApplicationMenu();
            this.ribbonBottomToolBar1 = new C1.Win.C1Ribbon.RibbonBottomToolBar();
            this.ribbonConfigToolBar1 = new C1.Win.C1Ribbon.RibbonConfigToolBar();
            this.ribbonQat1 = new C1.Win.C1Ribbon.RibbonQat();
            this.ribbonTab1 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup1 = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnCaProductos = new C1.Win.C1Ribbon.RibbonButton();
            this.btnClientes = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup2 = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnCaClientes = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab3 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup3 = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnCrearVenta = new C1.Win.C1Ribbon.RibbonButton();
            this.btnDetalleVenta = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTopToolBar1 = new C1.Win.C1Ribbon.RibbonTopToolBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Ribbon1
            // 
            this.c1Ribbon1.ApplicationMenuHolder = this.ribbonApplicationMenu1;
            this.c1Ribbon1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.c1Ribbon1.BottomToolBarHolder = this.ribbonBottomToolBar1;
            this.c1Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar1;
            this.c1Ribbon1.Location = new System.Drawing.Point(0, 0);
            this.c1Ribbon1.Name = "c1Ribbon1";
            this.c1Ribbon1.QatHolder = this.ribbonQat1;
            this.c1Ribbon1.Size = new System.Drawing.Size(1285, 231);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab1);
            this.c1Ribbon1.Tabs.Add(this.btnClientes);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab3);
            this.c1Ribbon1.TopToolBarHolder = this.ribbonTopToolBar1;
            this.c1Ribbon1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Black;
            // 
            // ribbonApplicationMenu1
            // 
            this.ribbonApplicationMenu1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonApplicationMenu1.LargeImage")));
            this.ribbonApplicationMenu1.Name = "ribbonApplicationMenu1";
            // 
            // ribbonBottomToolBar1
            // 
            this.ribbonBottomToolBar1.Name = "ribbonBottomToolBar1";
            // 
            // ribbonConfigToolBar1
            // 
            this.ribbonConfigToolBar1.Name = "ribbonConfigToolBar1";
            // 
            // ribbonQat1
            // 
            this.ribbonQat1.Name = "ribbonQat1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.Add(this.ribbonGroup1);
            this.ribbonTab1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonTab1.Image")));
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Administracion";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Items.Add(this.btnCaProductos);
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Productos y stock";
            // 
            // btnCaProductos
            // 
            this.btnCaProductos.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCaProductos.LargeImage")));
            this.btnCaProductos.Name = "btnCaProductos";
            this.btnCaProductos.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCaProductos.SmallImage")));
            this.btnCaProductos.Text = "Productos";
            this.btnCaProductos.Click += new System.EventHandler(this.btnCaProductos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Groups.Add(this.ribbonGroup2);
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Text = "Registro";
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Items.Add(this.btnCaClientes);
            this.ribbonGroup2.Name = "ribbonGroup2";
            this.ribbonGroup2.Text = "Registro de Clientes";
            // 
            // btnCaClientes
            // 
            this.btnCaClientes.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCaClientes.LargeImage")));
            this.btnCaClientes.Name = "btnCaClientes";
            this.btnCaClientes.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCaClientes.SmallImage")));
            this.btnCaClientes.Text = "Clientes";
            this.btnCaClientes.Click += new System.EventHandler(this.btnCaClientes_Click_1);
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Groups.Add(this.ribbonGroup3);
            this.ribbonTab3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonTab3.Image")));
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Text = "Venta";
            // 
            // ribbonGroup3
            // 
            this.ribbonGroup3.Items.Add(this.btnCrearVenta);
            this.ribbonGroup3.Items.Add(this.btnDetalleVenta);
            this.ribbonGroup3.Name = "ribbonGroup3";
            this.ribbonGroup3.Text = "Ventas y Detalles";
            // 
            // btnCrearVenta
            // 
            this.btnCrearVenta.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCrearVenta.LargeImage")));
            this.btnCrearVenta.Name = "btnCrearVenta";
            this.btnCrearVenta.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCrearVenta.SmallImage")));
            this.btnCrearVenta.Text = "Crear Venta";
            this.btnCrearVenta.Click += new System.EventHandler(this.btnCrearVenta_Click);
            // 
            // btnDetalleVenta
            // 
            this.btnDetalleVenta.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDetalleVenta.LargeImage")));
            this.btnDetalleVenta.Name = "btnDetalleVenta";
            this.btnDetalleVenta.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDetalleVenta.SmallImage")));
            this.btnDetalleVenta.Text = "Detalles de Ventas";
            this.btnDetalleVenta.Click += new System.EventHandler(this.btnDetalleVenta_Click);
            // 
            // ribbonTopToolBar1
            // 
            this.ribbonTopToolBar1.Name = "ribbonTopToolBar1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::CpChipSet.Properties.Resources.chipset;
            this.pictureBox1.Location = new System.Drawing.Point(0, 231);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1285, 540);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 771);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.c1Ribbon1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Principal - ChipSet :::";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Ribbon.C1Ribbon c1Ribbon1;
        private C1.Win.C1Ribbon.RibbonApplicationMenu ribbonApplicationMenu1;
        private C1.Win.C1Ribbon.RibbonBottomToolBar ribbonBottomToolBar1;
        private C1.Win.C1Ribbon.RibbonConfigToolBar ribbonConfigToolBar1;
        private C1.Win.C1Ribbon.RibbonQat ribbonQat1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab1;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup1;
        private C1.Win.C1Ribbon.RibbonTopToolBar ribbonTopToolBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private C1.Win.C1Ribbon.RibbonButton btnCaProductos;
        private C1.Win.C1Ribbon.RibbonTab btnClientes;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup2;
        private C1.Win.C1Ribbon.RibbonButton btnCaClientes;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab3;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup3;
        private C1.Win.C1Ribbon.RibbonButton btnCrearVenta;
        private C1.Win.C1Ribbon.RibbonButton btnDetalleVenta;
    }
}