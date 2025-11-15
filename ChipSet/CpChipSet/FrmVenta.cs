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
    public partial class FrmVenta : Form
    {
        private List<DetallePedido> carrito = new List<DetallePedido>();

        private List<paProductoListar_Result> listaDeProductosCompleta;

        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            cargarClientes();

            listaDeProductosCompleta = ProductoCln.listarPa("");

            nudTotal.Maximum = 1000000;
            nudTotal.ReadOnly = true;

            limpiar();
            HabilitarControles(true, true);
            dtpFechaPedido.Focus();
        }

        private void cargarClientes()
        {
            var lista = NombreCliente.listar();
            cbxCliente.DataSource = lista;
            cbxCliente.ValueMember = "id";
            cbxCliente.DisplayMember = "nombre";
            cbxCliente.SelectedIndex = -1;
        }

        private void actualizarCarritoGrid()
        {
            dgvCarrito.DataSource = null;
            if (carrito.Count > 0)
            {
                var dataSource = carrito.Select(d =>
                {
                    var producto = listaDeProductosCompleta
                                        .FirstOrDefault(p => p.id == d.idProducto);

                    return new
                    {
                        IdProducto = d.idProducto,
                        Producto = (producto != null) ? producto.nombre : "No encontrado",
                        Cantidad = d.cantidad,
                        Precio = d.precioUnitario,
                        Subtotal = d.cantidad * d.precioUnitario
                    };
                }).ToList();

                dgvCarrito.DataSource = dataSource;

                if (dgvCarrito.Columns["IdProducto"] != null)
                {
                    dgvCarrito.Columns["IdProducto"].Visible = false;
                }
            }
        }

        private void actualizarTotal()
        {
            decimal totalCalculado = carrito.Sum(item => item.cantidad * item.precioUnitario);
            nudTotal.Value = totalCalculado;
        }

        private void limpiar()
        {
            dtpFechaPedido.Value = DateTime.Now;
            nudTotal.Value = 0;
            cbxCliente.SelectedIndex = -1;
            carrito.Clear();
            dgvCarrito.DataSource = null;
            erpCliente.Clear();
        }

        private bool validar()
        {
            bool esValido = true;
            erpCliente.Clear();

            if (string.IsNullOrWhiteSpace(cbxCliente.Text))
            {
                erpCliente.SetError(cbxCliente, "El Nombre del Cliente es obligatorio");
                esValido = false;
            }

            if (carrito.Count == 0)
            {
                MessageBox.Show("Debe añadir al menos un producto al pedido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                esValido = false;
            }
            return esValido;
        }

        private void HabilitarControles(bool cabecera, bool carrito)
        {
            dtpFechaPedido.Enabled = cabecera;
            cbxCliente.Enabled = cabecera;
            btnGuardar.Enabled = cabecera || carrito;

            btnBuscarProducto.Enabled = carrito;
            btnEliminarProducto.Enabled = carrito;
        }

        public void AnadirProductoAlCarrito(int idProducto, string nombreProducto, int cantidad, decimal precio)
        {
            var itemExistente = carrito.FirstOrDefault(p => p.idProducto == idProducto);

            if (itemExistente != null)
            {
                itemExistente.cantidad += cantidad;
            }
            else
            {
                var detalle = new DetallePedido
                {
                    idProducto = idProducto,
                    cantidad = cantidad,
                    precioUnitario = precio,
                    usuarioRegistro = Util.usuario.usuario1,
                    fechaRegistro = DateTime.Now,
                    estado = 1
                };
                carrito.Add(detalle);
            }

            actualizarCarritoGrid();
            actualizarTotal();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmBuscarProducto frmBuscar = new FrmBuscarProducto();
            frmBuscar.Owner = this;

            frmBuscar.ShowDialog();
        }

        // Evento del botón "Eliminar del Carrito"
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow != null)
            {
                int idProductoEliminar = (int)dgvCarrito.CurrentRow.Cells["IdProducto"].Value;

                var itemParaEliminar = carrito.FirstOrDefault(p => p.idProducto == idProductoEliminar);
                if (itemParaEliminar != null)
                {
                    carrito.Remove(itemParaEliminar);
                }

                actualizarCarritoGrid();
                actualizarTotal();
            }
            else
            {
                MessageBox.Show("Seleccione un producto del carrito para eliminar.");
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                int idClienteGuardar;
                string nombreCliente = cbxCliente.Text.Trim();

                if (cbxCliente.SelectedValue != null)
                {
                    idClienteGuardar = (int)cbxCliente.SelectedValue;
                }
                else
                {
                    idClienteGuardar = NombreCliente.ObtenerOcrear(nombreCliente, Util.usuario.usuario1);
                }

                var pedido = new Pedido();
                pedido.fechaPedido = dtpFechaPedido.Value;
                pedido.idCliente = idClienteGuardar;
                pedido.total = nudTotal.Value;
                pedido.usuarioRegistro = Util.usuario.usuario1;

                try
                {
                    pedido.fechaRegistro = DateTime.Now;
                    pedido.estado = 1;

                    bool exito = PedidoCln.insertarConDetalle(pedido, carrito);

                    if (exito)
                    {
                        MessageBox.Show("Venta registrada exitosamente.", "::: Mensaje - ChipSet :::", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FrmHistorialVentas frmHistorial = new FrmHistorialVentas();
                        frmHistorial.Show();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar la venta. (Causa probable: Stock insuficiente)", "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el pedido: " + ex.Message, "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            HabilitarControles(true, true);
        }
    }
}