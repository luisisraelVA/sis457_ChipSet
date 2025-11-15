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
    // Asegúrate que el nombre de la clase coincida: FrmHistorialVentas
    public partial class FrmHistorialVentas : Form
    {
        public FrmHistorialVentas()
        {
            InitializeComponent();
        }

        private void FrmHistorialVentas_Load(object sender, EventArgs e)
        {
            listarPedidos();
        }

        private void listarPedidos()
        {
            var lista = PedidoCln.listarPa3(txtParametro.Text.Trim());

            // 1. Asignar al DGV Maestro (dgvPedidos)
            dgvPedidos.DataSource = lista;

            dgvPedidos.Columns["id"].Visible = false;
            dgvPedidos.Columns["idCliente"].Visible = false;
            dgvPedidos.Columns["estado"].Visible = false;
            dgvPedidos.Columns["nombreCliente"].HeaderText = "Cliente";
            dgvPedidos.Columns["fechaPedido"].HeaderText = "Fecha de Pedido";
            dgvPedidos.Columns["total"].HeaderText = "Total";
            dgvPedidos.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvPedidos.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";

            if (lista.Count == 0)
            {
                dgvDetalles.DataSource = null;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarPedidos();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                listarPedidos();
            }
        }

        // Este es el evento que conecta los dos DataGridViews
        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null)
            {
                return;
            }

            int idPedido = (int)dgvPedidos.CurrentRow.Cells["id"].Value;

            // 2. Asignar al DGV Detalle (dgvDetalles)
            var listaDetalles = PedidoCln.listarDetallesSP(idPedido);
            dgvDetalles.DataSource = listaDetalles;

            // Configurar columnas del Detalle
            if (dgvDetalles.Columns["id"] != null)
                dgvDetalles.Columns["id"].Visible = false;

            if (dgvDetalles.Columns["idPedido"] != null)
                dgvDetalles.Columns["idPedido"].Visible = false;

            if (dgvDetalles.Columns["idProducto"] != null)
                dgvDetalles.Columns["idProducto"].Visible = false;

            if (dgvDetalles.Columns["nombreProducto"] != null)
                dgvDetalles.Columns["nombreProducto"].HeaderText = "Producto";

            if (dgvDetalles.Columns["cantidad"] != null)
                dgvDetalles.Columns["cantidad"].HeaderText = "Cantidad";

            if (dgvDetalles.Columns["precioUnitario"] != null)
                dgvDetalles.Columns["precioUnitario"].HeaderText = "Precio Unit.";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}