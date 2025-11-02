using CadChipSet;
using ClnChipSet;
using CpChipSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpChipSet
{
    public partial class FrmProductos : Form
    {
        private bool esNuevo = false;
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ProductoCln.listarPa(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["idProveedor"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["nombre"].HeaderText = "Nombre";
            dgvLista.Columns["descripcion"].HeaderText = "Descripción";
            dgvLista.Columns["precioVenta"].HeaderText = "Precio de Venta";
            dgvLista.Columns["stock"].HeaderText = "Stock";
            dgvLista.Columns["nombreProveedor"].HeaderText = "Nombre del Proveedor";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["descripcion"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }
        private void cargarProveedores()
        {
           
            var lista = NombreProovedorCln.listar();

            cbxProveedor.DataSource = lista;
            cbxProveedor.ValueMember = "id";       
            cbxProveedor.DisplayMember = "nombre"; 
            cbxProveedor.SelectedIndex = -1;      
        }
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            Size = new Size(1165, 657);
            listar();
            cargarProveedores();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            pnlAcciones.Enabled = false;
            Size = new Size(1165, 963);
            txtNombre.Focus();

        }
        private void limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            nudPrecioVenta.Value = 0;
            nudStock.Value = 0;
            cbxProveedor.SelectedIndex = -1;
          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(1165, 657);
            pnlAcciones.Enabled = true;
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            pnlAcciones.Enabled = false;
            Size = new Size(1165, 963);

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var producto = ProductoCln.obtenerUno(id);
            txtNombre.Text = producto.nombre;
            txtDescripcion.Text = producto.descripcion;
            nudStock.Value = producto.stock;
            nudPrecioVenta.Value = producto.precioVenta;
            cbxProveedor.SelectedValue = producto.idProveedor;
            txtNombre.Focus();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }


        private bool validar()
        {
            bool esValido = true;
            erpNombre.Clear();   
            erpDescripcion.Clear();
            erpPrecioVenta.Clear();
            erpStock.Clear();
            erpProveedor.Clear();
            
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpNombre.SetError(txtNombre,"El Nombre es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                erpDescripcion.SetError(txtDescripcion, "El Nombre es obligatorio");
                esValido = false;
            }
            if (nudPrecioVenta.Value <0)
            {
                erpPrecioVenta.SetError(nudPrecioVenta, "El precio de venta debe ser mayor a 0");
                esValido=false;
            }
            if (nudStock.Value <0)
            {
                erpStock.SetError(nudStock, "El stock debe ser mayor a 0"); esValido=false;
                esValido = false; 
            }
            if (string .IsNullOrEmpty(cbxProveedor.Text ))
            {
                erpProveedor.SetError(cbxProveedor, "El Nombre del Proveedor es obligatorio"); 
                esValido = false;
            }
            return esValido;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var producto = new Producto();
                producto.nombre = txtNombre.Text.Trim();
                producto.descripcion= txtDescripcion.Text.Trim();
                producto.precioVenta = nudPrecioVenta.Value;
                producto.idProveedor = (int)cbxProveedor.SelectedValue;
                producto.stock= (int)nudStock.Value;
                producto.precioVenta = nudPrecioVenta.Value;
                producto.usuarioRegistro = Util.usuario.usuario1;
                if (esNuevo)
                {
                    producto.fechaRegistro = DateTime.Now;
                    producto.estado = 1;
                    ProductoCln.insertar(producto);
                }
                else
                {
                    producto.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                    ProductoCln.actualizar(producto);
                }
                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Producto guardado correctamente", "::: Mensaje - ChipSet :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            string nombre = dgvLista.CurrentRow.Cells["nombre"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"¿Está seguro de eliminar el producto {nombre}?",
                "::: Mensaje - Minerva :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                ProductoCln.eliminar(id ,Util.usuario.usuario1);
                listar();
                MessageBox.Show("Producto dado de baja correctamente", "::: Mensaje - Minerva :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
