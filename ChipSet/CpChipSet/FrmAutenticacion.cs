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
    public partial class FrmAutenticacion : Form
    {
        public FrmAutenticacion()
        {
            InitializeComponent();
            // txtUsuario.Text = Util.Encrypt("hola123");
        }

        private bool validar()
        {
            bool esValido = true;
            erpUsuario.Clear();
            erpClave.Clear();

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                erpUsuario.SetError(txtUsuario, "El usuario es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                erpClave.SetError(txtClave, "La contraseña es obligatoria");
                esValido = false;
            }

            return esValido;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var usuario = UsuarioCln.validar(txtUsuario.Text, Util.Encrypt(txtClave.Text));
                if (usuario != null)
                {
                    Util.usuario = usuario;
                    txtClave.Clear();
                    Hide();

                    new FrmPrincipal(this).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrecto", "::: Mensaje - ChipSet :::",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);


                    txtUsuario.Focus();
                    txtUsuario.SelectAll();
                }
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}