namespace CpChipSet
{
    partial class FrmAutenticacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutenticacion));
            this.erpUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpClave = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.tlpControles = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.flpBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.erpUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpClave)).BeginInit();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tlpControles.SuspendLayout();
            this.flpBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // erpUsuario
            // 
            this.erpUsuario.ContainerControl = this;
            // 
            // erpClave
            // 
            this.erpClave.ContainerControl = this;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Transparent;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblTitulo, 0, 0);
            this.tlpMain.Controls.Add(this.picLogo, 0, 1);
            this.tlpMain.Controls.Add(this.tlpControles, 1, 1);
            this.tlpMain.Controls.Add(this.flpBotones, 1, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.Size = new System.Drawing.Size(723, 301);
            this.tlpMain.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.tlpMain.SetColumnSpan(this.lblTitulo, 2);
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(13, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(697, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Iniciar Sesión";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = global::CpChipSet.Properties.Resources.security_lock;
            this.picLogo.Location = new System.Drawing.Point(13, 73);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(194, 155);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // tlpControles
            // 
            this.tlpControles.ColumnCount = 2;
            this.tlpControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControles.Controls.Add(this.lblUsuario, 0, 1);
            this.tlpControles.Controls.Add(this.txtUsuario, 1, 1);
            this.tlpControles.Controls.Add(this.lblClave, 0, 2);
            this.tlpControles.Controls.Add(this.txtClave, 1, 2);
            this.tlpControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControles.Location = new System.Drawing.Point(213, 73);
            this.tlpControles.Name = "tlpControles";
            this.tlpControles.RowCount = 4;
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpControles.Size = new System.Drawing.Size(497, 155);
            this.tlpControles.TabIndex = 2;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(3, 37);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(130, 40);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(139, 41);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txtUsuario.MaxLength = 100;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(338, 32);
            this.txtUsuario.TabIndex = 1;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.ForeColor = System.Drawing.Color.White;
            this.lblClave.Location = new System.Drawing.Point(3, 77);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(130, 40);
            this.lblClave.TabIndex = 2;
            this.lblClave.Text = "Contraseña:";
            this.lblClave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtClave
            // 
            this.txtClave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(139, 81);
            this.txtClave.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(338, 32);
            this.txtClave.TabIndex = 3;
            // 
            // flpBotones
            // 
            this.flpBotones.Controls.Add(this.btnSalir);
            this.flpBotones.Controls.Add(this.btnIngresar);
            this.flpBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBotones.Location = new System.Drawing.Point(213, 234);
            this.flpBotones.Name = "flpBotones";
            this.flpBotones.Size = new System.Drawing.Size(497, 54);
            this.flpBotones.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::CpChipSet.Properties.Resources.close;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(391, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(103, 48);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Image = global::CpChipSet.Properties.Resources.login_ok;
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.Location = new System.Drawing.Point(265, 3);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(120, 48);
            this.btnIngresar.TabIndex = 0;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // FrmAutenticacion
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BackgroundImage = global::CpChipSet.Properties.Resources.abstract_square_interface_modern_background_concept_fingerprint_digital_scanning_visual_security_system_authentication_login_vector;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(723, 301);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAutenticacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Iniciar Sesión - ChipSet :::";
            ((System.ComponentModel.ISupportInitialize)(this.erpUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpClave)).EndInit();
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tlpControles.ResumeLayout(false);
            this.tlpControles.PerformLayout();
            this.flpBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TableLayoutPanel tlpControles;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.FlowLayoutPanel flpBotones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ErrorProvider erpUsuario;
        private System.Windows.Forms.ErrorProvider erpClave;
    }
}