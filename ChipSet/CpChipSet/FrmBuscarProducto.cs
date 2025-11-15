using ClnChipSet;
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
    public partial class FrmBuscarProducto : Form
    {
        public FrmBuscarProducto()
        {
            InitializeComponent();
        }

        private void FrmBuscarProducto_Load(object sender, EventArgs e)
        {
            listarProductos();
        }

        private void listarProductos()
        {
            var lista = ProductoCln.listarPa(txtParametro.Text.Trim());
            dgvProductos.DataSource = lista;

            // Ocultamos las columnas que no nos interesan
            dgvProductos.Columns["id"].Visible = false;
            dgvProductos.Columns["idProveedor"].Visible = false;
            dgvProductos.Columns["usuarioRegistro"].Visible = false;
            dgvProductos.Columns["fechaRegistro"].Visible = false;
            dgvProductos.Columns["estado"].Visible = false;
            dgvProductos.Columns["nombreProveedor"].Visible = false;

            // Ajustamos las que sí nos interesan
            dgvProductos.Columns["nombre"].HeaderText = "Producto";
            dgvProductos.Columns["descripcion"].HeaderText = "Descripción";
            dgvProductos.Columns["precioVenta"].HeaderText = "Precio";
            dgvProductos.Columns["stock"].HeaderText = "Stock";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarProductos();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                listarProductos();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // *** ¡LA PARTE MÁS IMPORTANTE! ***
        private void btnAnadirAlPedido_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya una fila seleccionada
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.");
                return;
            }

            // 2. Obtener la cantidad
            int cantidad = (int)nudCantidadProducto.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.");
                return;
            }

            // 3. Obtener los datos de la fila seleccionada
            var fila = dgvProductos.CurrentRow;
            int id = (int)fila.Cells["id"].Value;
            string nombre = fila.Cells["nombre"].Value.ToString();
            decimal precio = (decimal)fila.Cells["precioVenta"].Value;
            int stock = (int)fila.Cells["stock"].Value;

            // 4. Validar Stock
            if (cantidad > stock)
            {
                MessageBox.Show($"Stock insuficiente. Stock actual: {stock}", "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Enviar los datos de vuelta al FrmVenta (el "Owner")
            FrmVenta frmVentaPrincipal = this.Owner as FrmVenta;
            if (frmVentaPrincipal != null)
            {
                // Llama al método PÚBLICO que creamos en FrmVenta
                frmVentaPrincipal.AnadirProductoAlCarrito(id, nombre, cantidad, precio);
            }

            // 6. Cierra este formulario de búsqueda
            this.Close();
        }
    }
}