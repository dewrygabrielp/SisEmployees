using System;
using System.Drawing;
using System.Windows.Forms;
using Business;

namespace Employees
{
    public partial class ConfigurationAdmin : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private string IdUsuario = "";
        public void Mostrar()
        {
            B_Users Obj = new B_Users();
            this.dtgUsuarios.DataSource = Obj.MostrarUsuariosAdmin();
            this.lblTotal.Text = "Total de Usuarios: " + dtgUsuarios.Rows.Count;
        }

        public ConfigurationAdmin()
        {
            InitializeComponent();
            this.Mostrar();
            this.ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre");
            this.ttMensaje.SetToolTip(txtApellido, "Ingrese el apellido del usuario");
            this.ttMensaje.SetToolTip(txtIDusuario, "Ingrese el nombre de usuario");
            this.ttMensaje.SetToolTip(txtPassword, "Ingrese su clave");
            this.ttMensaje.SetToolTip(txtAcceso, "Ingrese de el tipo de acceso del usuario");
        }

        private void ConfigurationAdmin_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.habilitar(false);
            this.botones();

        }
      

        private void dtgUsusarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dtgUsuarios.RowsDefaultCellStyle.BackColor = Color.MediumPurple;
        }

        private void dtgUsuarios_DoubleClick(object sender, EventArgs e)
        {
            
            this.txtNombre.Text = Convert.ToString(this.dtgUsuarios.CurrentRow.Cells["NOMBRE"].Value);
            this.txtApellido.Text = Convert.ToString(this.dtgUsuarios.CurrentRow.Cells["APELLIDO"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dtgUsuarios.CurrentRow.Cells["USUARIO"].Value);
            this.txtIDusuario.Text = Convert.ToString(this.dtgUsuarios.CurrentRow.Cells["IDusuario"].Value);
            this.txtAcceso.Text = Convert.ToString(this.dtgUsuarios.CurrentRow.Cells["ACCESO"].Value);
            this.txtPassword.Text = Convert.ToString(this.dtgUsuarios.CurrentRow.Cells["PASSWORD"].Value);

            tabControl1.SelectedIndex = 1;

        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Configuration Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Configuration Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void habilitar(bool valor)
        {
            txtNombre.ReadOnly = !valor;
            txtApellido.ReadOnly = !valor;
            txtUsuario.ReadOnly = !valor;
            txtPassword.ReadOnly = !valor;
            txtAcceso.ReadOnly = !valor;
        }
        private void limpiar()
        {
            this.txtIDusuario.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtAcceso.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;

        }
        private void botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;

            }
            else
            {
                habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos. Seran remarcados");
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {


                        respuesta = B_Users.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(), this.txtAcceso.Text.Trim().ToUpper(), this.txtUsuario.Text.Trim(),
                        this.txtPassword.Text.Trim());
                    }
                    else
                    {
                        respuesta = B_Users.Editar(Convert.ToInt32(this.txtIDusuario.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(), this.txtAcceso.Text.Trim().ToUpper(), this.txtUsuario.Text.Trim(),
                        this.txtPassword.Text.Trim());
                    }

                    if (respuesta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.botones();
                    this.limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIDusuario.Text.Equals(""))
            {
                this.IsEditar = true;
                this.botones();
                this.habilitar(true);
               
            }
            else
            {
                MessageBox.Show("Selecciona el usuario a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.botones();
            this.limpiar();
            this.habilitar(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.botones();
            this.limpiar();
            this.habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dtgUsuarios.SelectedRows.Count > 0)
                {
                    IdUsuario = dtgUsuarios.CurrentRow.Cells["IDusuario"].Value.ToString();
                    B_Users.Eliminar(Convert.ToInt32(IdUsuario));
                    this.MensajeOk("SE ELIMINO DE FORMA CORRECTA");

                }
                else
                {
                    this.MensajeError("NO SE PUDO ELIMINAR EL REGISTRO");
                }
               
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            this.Mostrar();
            this.limpiar();
        }

      

        
    }
}

