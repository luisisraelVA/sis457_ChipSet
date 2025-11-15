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
            this.btnCaClientes = new C1.Win.C1Ribbon.RibbonButton();
            this.btnCaVentas = new C1.Win.C1Ribbon.RibbonButton();
            this.btnCaDetallesVenta = new C1.Win.C1Ribbon.RibbonButton();
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
            this.c1Ribbon1.Size = new System.Drawing.Size(1285, 232);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab1);
            this.c1Ribbon1.TopToolBarHolder = this.ribbonTopToolBar1;
            this.c1Ribbon1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Black;
            // 
            // ribbonApplicationMenu1
            // 
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
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Catalogos";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Items.Add(this.btnCaProductos);
            this.ribbonGroup1.Items.Add(this.btnCaClientes);
            this.ribbonGroup1.Items.Add(this.btnCaVentas);
            this.ribbonGroup1.Items.Add(this.btnCaDetallesVenta);
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Administracion de Catalogos";
            // 
            // btnCaProductos
            // 
            this.btnCaProductos.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCaProductos.LargeImage")));
            this.btnCaProductos.Name = "btnCaProductos";
            this.btnCaProductos.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCaProductos.SmallImage")));
            this.btnCaProductos.Text = "Productos";
            this.btnCaProductos.Click += new System.EventHandler(this.btnCaProductos_Click);
            // 
            // btnCaClientes
            // 
            this.btnCaClientes.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCaClientes.LargeImage")));
            this.btnCaClientes.Name = "btnCaClientes";
            this.btnCaClientes.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCaClientes.SmallImage")));
            this.btnCaClientes.Text = "Clientes";
            this.btnCaClientes.Click += new System.EventHandler(this.btnCaClientes_Click);
            // 
            // btnCaVentas
            // 
            this.btnCaVentas.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCaVentas.LargeImage")));
            this.btnCaVentas.Name = "btnCaVentas";
            this.btnCaVentas.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCaVentas.SmallImage")));
            this.btnCaVentas.Text = "Venta";
            this.btnCaVentas.Click += new System.EventHandler(this.btnCaVentas_Click);
            // 
            // btnCaDetallesVenta
            // 
            this.btnCaDetallesVenta.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCaDetallesVenta.LargeImage")));
            this.btnCaDetallesVenta.Name = "btnCaDetallesVenta";
            this.btnCaDetallesVenta.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCaDetallesVenta.SmallImage")));
            this.btnCaDetallesVenta.Text = "Detalles de Venta";
            this.btnCaDetallesVenta.Click += new System.EventHandler(this.btnCaDetallesVenta_Click);
            // 
            // ribbonTopToolBar1
            // 
            this.ribbonTopToolBar1.Name = "ribbonTopToolBar1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::CpChipSet.Properties.Resources.chipset;
            this.pictureBox1.Location = new System.Drawing.Point(0, 232);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1285, 539);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Principal - ChipSet :::";
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
        private C1.Win.C1Ribbon.RibbonButton btnCaClientes;
        private C1.Win.C1Ribbon.RibbonButton btnCaVentas;
        private C1.Win.C1Ribbon.RibbonButton btnCaDetallesVenta;
    }
}