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
        private List<DetallePedido> carrito = new List<DetallePedido>();

        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            Size = new Size(1356, 700);
            listar();
            cargarClientes();
            cargarProductos();
            nudTotal.Maximum = 1000000;
            nudTotal.ReadOnly = true;
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

            bool hayDatos = lista.Count > 0;
            if (hayDatos) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["fechaPedido"];
            btnEliminar.Enabled = hayDatos;
            btnDetalle.Enabled = hayDatos;
        }

        private void cargarClientes()
        {
            var lista = NombreCliente.listar();
            cbxCliente.DataSource = lista;
            cbxCliente.ValueMember = "id";
            cbxCliente.DisplayMember = "nombre";
            cbxCliente.SelectedIndex = -1;
        }

        private void cargarProductos()
        {
            var lista = ProductoCln.listarPa("");
            cbxProducto.DataSource = lista;
            cbxProducto.ValueMember = "id";
            cbxProducto.DisplayMember = "nombre";
            cbxProducto.SelectedIndex = -1;
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (cbxProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoSeleccionado = (paProductoListar_Result)cbxProducto.SelectedItem;

            if (nudCantidad.Value > productoSeleccionado.stock)
            {
                MessageBox.Show($"No hay stock suficiente. Stock actual: {productoSeleccionado.stock}", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var itemExistente = carrito.FirstOrDefault(p => p.idProducto == productoSeleccionado.id);
            if (itemExistente != null)
            {
                itemExistente.cantidad += (int)nudCantidad.Value;
            }
            else
            {
                var detalle = new DetallePedido
                {
                    idProducto = productoSeleccionado.id,
                    cantidad = (int)nudCantidad.Value,
                    precioUnitario = productoSeleccionado.precioVenta,
                    usuarioRegistro = Util.usuario.usuario1,
                    fechaRegistro = DateTime.Now,
                    estado = 1
                };
                carrito.Add(detalle);
            }

            actualizarCarritoGrid();
            actualizarTotal();
        }

        private void actualizarCarritoGrid()
        {
            dgvCarrito.DataSource = null;
            if (carrito.Count > 0)
            {
                var dataSource = carrito.Select(d =>
                {
                    var producto = ((IEnumerable<paProductoListar_Result>)cbxProducto.DataSource)
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

                if (dgvCarrito.Columns["Producto"] != null)
                {
                    dgvCarrito.Columns["Producto"].Width = 200;
                }
            }
        }

        private void actualizarTotal()
        {
            decimal totalCalculado = carrito.Sum(item => item.cantidad * item.precioUnitario);
            nudTotal.Value = totalCalculado;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            pnlAcciones.Enabled = false;
            Size = new Size(1356, 979);
            limpiar();
            HabilitarControles(true, true);
            dtpFechaPedido.Focus();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null) return;

            esNuevo = false;
            pnlAcciones.Enabled = false;
            Size = new Size(1356, 979);

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var pedido = PedidoCln.obtenerUno(id);
            dtpFechaPedido.Value = pedido.fechaPedido;
            nudTotal.Value = pedido.total;
            cbxCliente.SelectedValue = pedido.idCliente;

            var detalles = PedidoCln.listarDetallesSP(id);
            dgvCarrito.DataSource = detalles;

            if (dgvCarrito.Columns["id"] != null)
                dgvCarrito.Columns["id"].Visible = false;

            if (dgvCarrito.Columns["idPedido"] != null)
                dgvCarrito.Columns["idPedido"].Visible = false;

            if (dgvCarrito.Columns["idProducto"] != null)
                dgvCarrito.Columns["idProducto"].Visible = false;

            HabilitarControles(false, false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(1356, 700);
            pnlAcciones.Enabled = true;
            limpiar();
            HabilitarControles(true, true);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
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

                if (esNuevo)
                {
                    try
                    {
                        pedido.fechaRegistro = DateTime.Now;
                        pedido.estado = 1;

                        bool exito = PedidoCln.insertarConDetalle(pedido, carrito);

                        if (exito)
                        {
                            MessageBox.Show("Venta registrada exitosamente.", "::: Mensaje - ChipSet :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarClientes();
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
                else
                {
                    pedido.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                    PedidoCln.actualizar(pedido);
                    MessageBox.Show("Pedido (encabezado) actualizado correctamente", "::: Mensaje - ChipSet :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                listar();
                btnCancelar.PerformClick();
            }
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

        private void limpiar()
        {
            dtpFechaPedido.Value = DateTime.Now;
            nudTotal.Value = 0;
            cbxCliente.SelectedIndex = -1;
            cbxProducto.SelectedIndex = -1;
            nudCantidad.Value = 0;
            carrito.Clear();
            dgvCarrito.DataSource = null;
        }

        private bool validar()
        {
            bool esValido = true;
            erpTotal.Clear();
            erpCliente.Clear();

            if (string.IsNullOrWhiteSpace(cbxCliente.Text))
            {
                erpCliente.SetError(cbxCliente, "El Nombre del Cliente es obligatorio");
                esValido = false;
            }

            if (carrito.Count == 0 && esNuevo)
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
            cbxProducto.Enabled = carrito;
            nudCantidad.Enabled = carrito;
            btnAnadir.Enabled = carrito;
        }
    }
}