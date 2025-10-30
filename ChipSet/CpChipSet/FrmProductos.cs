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

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            Size = new Size(1165, 657);
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Size = new Size(1165, 963);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(1165, 657);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }
    }
}
