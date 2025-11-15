namespace CpChipSet
{
    partial class FrmVenta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbxDatos = new System.Windows.Forms.GroupBox();
            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.lblFechaPedido = new System.Windows.Forms.Label();
            this.dtpFechaPedido = new System.Windows.Forms.DateTimePicker();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbxCliente = new System.Windows.Forms.ComboBox();
            this.gbxCarrito = new System.Windows.Forms.GroupBox();
            this.tlpCarrito = new System.Windows.Forms.TableLayoutPanel();
            this.flpBotonesCarrito = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.erpCliente = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpTotal = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpMain.SuspendLayout();
            this.gbxDatos.SuspendLayout();
            this.tlpDatos.SuspendLayout();
            this.gbxCarrito.SuspendLayout();
            this.tlpCarrito.SuspendLayout();
            this.flpBotonesCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.tlpFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            this.flpAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblTitulo, 0, 0);
            this.tlpMain.Controls.Add(this.gbxDatos, 0, 1);
            this.tlpMain.Controls.Add(this.gbxCarrito, 0, 2);
            this.tlpMain.Controls.Add(this.tlpFooter, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(10);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.Size = new System.Drawing.Size(900, 600);
            this.tlpMain.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(13, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(874, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Nueva Venta";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxDatos
            // 
            this.gbxDatos.Controls.Add(this.tlpDatos);
            this.gbxDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatos.Location = new System.Drawing.Point(13, 73);
            this.gbxDatos.Name = "gbxDatos";
            this.gbxDatos.Size = new System.Drawing.Size(874, 94);
            this.gbxDatos.TabIndex = 1;
            this.gbxDatos.TabStop = false;
            this.gbxDatos.Text = "Datos del Pedido";
            // 
            // tlpDatos
            // 
            this.tlpDatos.ColumnCount = 2;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDatos.Controls.Add(this.lblFechaPedido, 0, 0);
            this.tlpDatos.Controls.Add(this.dtpFechaPedido, 1, 0);
            this.tlpDatos.Controls.Add(this.lblCliente, 0, 1);
            this.tlpDatos.Controls.Add(this.cbxCliente, 1, 1);
            this.tlpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDatos.Location = new System.Drawing.Point(3, 24);
            this.tlpDatos.Name = "tlpDatos";
            this.tlpDatos.RowCount = 2;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.Size = new System.Drawing.Size(868, 67);
            this.tlpDatos.TabIndex = 0;
            // 
            // lblFechaPedido
            // 
            this.lblFechaPedido.AutoSize = true;
            this.lblFechaPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaPedido.Location = new System.Drawing.Point(3, 0);
            this.lblFechaPedido.Name = "lblFechaPedido";
            this.lblFechaPedido.Size = new System.Drawing.Size(147, 33);
            this.lblFechaPedido.TabIndex = 0;
            this.lblFechaPedido.Text = "Fecha de Pedido:";
            this.lblFechaPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpFechaPedido
            // 
            this.dtpFechaPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaPedido.Location = new System.Drawing.Point(156, 3);
            this.dtpFechaPedido.Name = "dtpFechaPedido";
            this.dtpFechaPedido.Size = new System.Drawing.Size(709, 28);
            this.dtpFechaPedido.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCliente.Location = new System.Drawing.Point(3, 33);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(147, 34);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxCliente
            // 
            this.cbxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCliente.FormattingEnabled = true;
            this.cbxCliente.Location = new System.Drawing.Point(156, 36);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(709, 30);
            this.cbxCliente.TabIndex = 3;
            // 
            // gbxCarrito
            // 
            this.gbxCarrito.Controls.Add(this.tlpCarrito);
            this.gbxCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCarrito.Location = new System.Drawing.Point(13, 173);
            this.gbxCarrito.Name = "gbxCarrito";
            this.gbxCarrito.Size = new System.Drawing.Size(874, 334);
            this.gbxCarrito.TabIndex = 2;
            this.gbxCarrito.TabStop = false;
            this.gbxCarrito.Text = "Carrito de Compras";
            // 
            // tlpCarrito
            // 
            this.tlpCarrito.ColumnCount = 1;
            this.tlpCarrito.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCarrito.Controls.Add(this.flpBotonesCarrito, 0, 0);
            this.tlpCarrito.Controls.Add(this.dgvCarrito, 0, 1);
            this.tlpCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCarrito.Location = new System.Drawing.Point(3, 24);
            this.tlpCarrito.Name = "tlpCarrito";
            this.tlpCarrito.RowCount = 2;
            this.tlpCarrito.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpCarrito.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCarrito.Size = new System.Drawing.Size(868, 307);
            this.tlpCarrito.TabIndex = 0;
            // 
            // flpBotonesCarrito
            // 
            this.flpBotonesCarrito.Controls.Add(this.btnBuscarProducto);
            this.flpBotonesCarrito.Controls.Add(this.btnEliminarProducto);
            this.flpBotonesCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBotonesCarrito.Location = new System.Drawing.Point(3, 3);
            this.flpBotonesCarrito.Name = "flpBotonesCarrito";
            this.flpBotonesCarrito.Size = new System.Drawing.Size(862, 44);
            this.flpBotonesCarrito.TabIndex = 0;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProducto.Location = new System.Drawing.Point(3, 3);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(200, 40);
            this.btnBuscarProducto.TabIndex = 0;
            this.btnBuscarProducto.Text = "Buscar Producto...";
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProducto.ForeColor = System.Drawing.Color.Red;
            this.btnEliminarProducto.Location = new System.Drawing.Point(209, 3);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(200, 40);
            this.btnEliminarProducto.TabIndex = 1;
            this.btnEliminarProducto.Text = "Eliminar del Carrito";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarrito.Location = new System.Drawing.Point(3, 53);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersWidth = 62;
            this.dgvCarrito.RowTemplate.Height = 28;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new System.Drawing.Size(862, 251);
            this.dgvCarrito.TabIndex = 1;
            // 
            // tlpFooter
            // 
            this.tlpFooter.ColumnCount = 4;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFooter.Controls.Add(this.lblTotal, 0, 0);
            this.tlpFooter.Controls.Add(this.nudTotal, 1, 0);
            this.tlpFooter.Controls.Add(this.flpAcciones, 3, 0);
            this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFooter.Location = new System.Drawing.Point(13, 513);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(874, 74);
            this.tlpFooter.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(115, 74);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "TOTAL:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudTotal
            // 
            this.nudTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.Location = new System.Drawing.Point(124, 15);
            this.nudTotal.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.ReadOnly = true;
            this.nudTotal.Size = new System.Drawing.Size(200, 44);
            this.nudTotal.TabIndex = 1;
            this.nudTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flpAcciones
            // 
            this.flpAcciones.Controls.Add(this.btnCerrar);
            this.flpAcciones.Controls.Add(this.btnCancelar);
            this.flpAcciones.Controls.Add(this.btnGuardar);
            this.flpAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAcciones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpAcciones.Location = new System.Drawing.Point(409, 3);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Size = new System.Drawing.Size(462, 68);
            this.flpAcciones.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(312, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(147, 60);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(159, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 60);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar Venta";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(6, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 60);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar Venta";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // erpCliente
            // 
            this.erpCliente.ContainerControl = this;
            // 
            // erpTotal
            // 
            this.erpTotal.ContainerControl = this;
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tlpMain);
            this.MinimumSize = new System.Drawing.Size(922, 656);
            this.Name = "FrmVenta";
            this.Text = "Registro de Venta";
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            this.tlpMain.ResumeLayout(false);
            this.gbxDatos.ResumeLayout(false);
            this.tlpDatos.ResumeLayout(false);
            this.tlpDatos.PerformLayout();
            this.gbxCarrito.ResumeLayout(false);
            this.tlpCarrito.ResumeLayout(false);
            this.flpBotonesCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.tlpFooter.ResumeLayout(false);
            this.tlpFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            this.flpAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbxDatos;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.Label lblFechaPedido;
        private System.Windows.Forms.DateTimePicker dtpFechaPedido;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbxCliente;
        private System.Windows.Forms.GroupBox gbxCarrito;
        private System.Windows.Forms.TableLayoutPanel tlpCarrito;
        private System.Windows.Forms.FlowLayoutPanel flpBotonesCarrito;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ErrorProvider erpCliente;
        private System.Windows.Forms.ErrorProvider erpTotal;
    }
}