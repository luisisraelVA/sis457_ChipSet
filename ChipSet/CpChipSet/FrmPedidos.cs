using CadChipSet;
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
    public partial class FrmPedidos : Form
    {
        private bool esNuevo = false;
        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = PedidoCln.listarPa3(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;

            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["idCliente"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["nombreCliente"].HeaderText = "Cliente";
            dgvLista.Columns["fechaPedido"].HeaderText = "Fecha de Pedido";
            dgvLista.Columns["total"].HeaderText = "Total";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["fechaPedido"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }

        private void cargarClientes()
        {
            var lista = NombreCliente.listar();

            cbxCliente.DataSource = lista;
            cbxCliente.ValueMember = "id";
            cbxCliente.DisplayMember = "nombre";
            cbxCliente.SelectedIndex = -1;
        }



        private void FrmPedidos_Load(object sender, EventArgs e)
        {

            Size = new Size(1813, 705);
            listar();
            cargarClientes();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            pnlAcciones.Enabled = false;

            Size = new Size(1813, 967);

            limpiar();


            dtpFechaPedido.Focus();
        }

        private void limpiar()
        {
            dtpFechaPedido.Value = DateTime.Now;
            nudTotal.Value = 0;
            cbxCliente.SelectedIndex = -1;


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(1813, 705);
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
            Size = new Size(1813, 967);

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var pedido = PedidoCln.obtenerUno(id);

            dtpFechaPedido.Value = pedido.fechaPedido;
            nudTotal.Value = pedido.total;
            cbxCliente.SelectedValue = pedido.idCliente;



            dtpFechaPedido.Focus();
        }

        private bool validar()
        {
            bool esValido = true;
            erpTotal.Clear();
            erpCliente.Clear();


            if (nudTotal.Value < 0)
            {
                erpTotal.SetError(nudTotal, "El Total de pedido debe ser mayor a 0");
                esValido = false;
            }
            if (string.IsNullOrEmpty(cbxCliente.Text))
            {
                erpCliente.SetError(cbxCliente, "El Nombre del Cliente es obligatorio");
                esValido = false;
            }
            return esValido;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var pedido = new Pedido();
                pedido.fechaPedido = dtpFechaPedido.Value;
                pedido.idCliente = (int)cbxCliente.SelectedValue;
                pedido.total = nudTotal.Value;
                pedido.usuarioRegistro = Util.usuario.usuario1;

                if (esNuevo)
                {
                    try
                    {


                   
                        pedido.fechaRegistro = DateTime.Now;
                        pedido.estado = 1;

                        int idPedidoNuevo = PedidoCln.insertar(pedido);

                    

                        MessageBox.Show("Venta registrada exitosamente.", "::: Mensaje - ChipSet :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el pedido: " + ex.Message, "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    pedido.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                

                    PedidoCln.actualizar(pedido);
                    MessageBox.Show("Pedido actualizado correctamente", "::: Mensaje - ChipSet :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                listar();
                btnCancelar.PerformClick();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            DateTime fechaPedido = (DateTime)dgvLista.CurrentRow.Cells["fechapedido"].Value;
            string fechaFormateada = fechaPedido.ToShortDateString();
            DialogResult dialog = MessageBox.Show($"¿Está seguro de eliminar el pedido {fechaFormateada}?",
            "::: Mensaje - ChipSet :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                PedidoCln.eliminar(id, Util.usuario.usuario1);

                listar();

                MessageBox.Show("Pedido dado de baja correctamente", "::: Mensaje - ChipSet :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      
    }
}