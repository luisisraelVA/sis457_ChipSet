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
    public partial class FrmCliente : Form
    {
        private bool esNuevo = false;
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ClienteCln.listarPa2(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["nombre"].HeaderText = "Nombre";
            dgvLista.Columns["email"].HeaderText = "Email";
            dgvLista.Columns["telefono"].HeaderText = "Telefono";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["nombre"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }


        private void limpiar()
        {
            txtNombre.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();

        }


        private bool validar()
        {
            bool esValido = true;
            erpNombre.Clear();
            erpEmail.Clear();
            erpTelefono.Clear();

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpNombre.SetError(txtNombre, "El Nombre es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                erpEmail.SetError(txtEmail, "El Email es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                erpTelefono.SetError(txtTelefono, "El Telefono es obligatorio");
                esValido = false;
            }

            return esValido;
        }



        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            esNuevo = false;
            pnlAcciones.Enabled = false;
            Size = new Size(1165, 963);

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var cliente = ClienteCln.obtenerUno(id);
            txtNombre.Text = cliente.nombre;
            txtEmail.Text = cliente.email;
            txtTelefono.Text = cliente.telefono;
            txtNombre.Focus();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            string nombre = dgvLista.CurrentRow.Cells["nombre"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"¿Está seguro de eliminar el cliente {nombre}?",
                "::: Mensaje - Minerva :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                ClienteCln.eliminar(id, Util.usuario.usuario1);
                listar();
                MessageBox.Show("Cliente dado de baja correctamente", "::: Mensaje - Minerva :::",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            esNuevo = true;
            pnlAcciones.Enabled = false;
            Size = new Size(1165, 963);
            txtNombre.Focus();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Size = new Size(1165, 657);
            pnlAcciones.Enabled = true;
            limpiar();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (validar())
            {
                var cliente = new Cliente();
                cliente.nombre = txtNombre.Text.Trim();
                cliente.email = txtEmail.Text.Trim();
                cliente.telefono = txtTelefono.Text.Trim();
                cliente.usuarioRegistro = Util.usuario.usuario1;
                if (esNuevo)
                {
                    cliente.fechaRegistro = DateTime.Now;
                    cliente.estado = 1;
                    ClienteCln.insertar(cliente);
                }
                else
                {
                    cliente.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                    ClienteCln.actualizar(cliente);
                }
                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Cliente guardado correctamente", "::: Mensaje - ChipSet :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            listar();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Size = new Size(1165, 657);
            listar();
        }

        private void txtParametro_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }
    }
}
