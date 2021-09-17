using Business;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Employees
{
    
    public partial class frmEmpleados : Form
    {       
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public string IdUsuario ="";
        public string Nombre = "";
        public string Apellido = "";
        public string Acceso = "";
        public frmEmpleados()
        {
            InitializeComponent();
            

            lblHora.Text = DateTime.Now.ToLongDateString();

            this.ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre");
            this.ttMensaje.SetToolTip(txtNumero_Banca, "Ingrese numero de Banca");
            this.ttMensaje.SetToolTip(txtCedula, "Ingrese cedula");
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {

            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.habilitar(false);
            this.botones();
            BotonAdmin();
        }

        //Mensaje de confirmacion

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario

        private void limpiar()
        {
            txtID.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtNumero_Banca.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtSalario.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtSector.Text = string.Empty;
            txtLocal.Text = string.Empty;
            txtFechaSalida.Text = string.Empty;
            this.chkFecha_Salida.Checked = false;
            
            
        }

        //Mostrar datos de usuario en lbl



        //Habilitar las cajas de texto

        private void habilitar(bool valor)
        {
           this.txtID.ReadOnly = !valor;
            this.txtCodigo.ReadOnly = !valor;
            this.txtNumero_Banca.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtCedula.ReadOnly = !valor;
            this.txtSalario.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtSector.ReadOnly = !valor;
            this.txtLocal.ReadOnly = !valor;
            this.txtFechaSalida.Visible = false;   
           

        }

        //Habilitar botones

        private void botones()
        {
            if(this.IsNuevo || this.IsEditar)
            {
                this.habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                


            }
            else
            {
                this.habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false; 
            }
        }

        //Metodo Ocultar Columnas

        private void OcultarColumnas()
        {
            this.dgvEmpleados.Columns[0].Visible = false;
            this.dgvEmpleados.Columns[1].Visible = false;
        }

        //Metodo Mostrar

        private void Mostrar()
        {
            this.dgvEmpleados.DataSource = B_employees.Mostrar();
            this.OcultarColumnas();
            lblTotal.ForeColor = Color.Black;
            lblTotal.Text = "Total de registros: " + Convert.ToString(dgvEmpleados.Rows.Count);
        }

        //Metodo buscar por Nombre

        private void BuscarPorNombre()
        {
            this.dgvEmpleados.DataSource = B_employees.BuscarPorNombre(txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.ForeColor = Color.Black;
            lblTotal.Text = "Total de registros: " + Convert.ToString(dgvEmpleados.Rows.Count);
        }
        //Control boton Configuration Admin
        private void BotonAdmin()
        {
            if (Nombre == "DEWRY") btnAdminForm.Enabled = true;
            else btnAdminForm.Enabled = false;

        }
        

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarPorNombre();
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
                      

                        respuesta = B_employees.Insertar(Convert.ToInt32(this.txtNumero_Banca.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(),
                            this.txtCedula.Text.Trim(),Convert.ToDouble(this.txtSalario.Text.Trim()), this.txtTelefono.Text.Trim(), this.txtSector.Text.Trim().ToUpper(), this.txtLocal.Text.Trim().ToUpper(),
                            dtFecha_Entrada.Value, this.txtFechaSalida.Text
                            );
                    }
                    else
                    {
                        respuesta = B_employees.Editar(Convert.ToInt32(this.txtID.Text), this.txtCodigo.Text.Trim().ToUpper(),Convert.ToInt32(this.txtNumero_Banca.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(),
                            this.txtCedula.Text.Trim(),Convert.ToDouble(this.txtSalario.Text.Trim()), this.txtTelefono.Text.Trim(), this.txtSector.Text.Trim().ToUpper(), this.txtLocal.Text.Trim().ToUpper(),
                            dtFecha_Entrada.Value, this.txtFechaSalida.Text);
                    }

                    if(respuesta.Equals("OK"))
                    {
                        if(this.IsNuevo)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvEmpleados_DoubleClick(object sender, EventArgs e)
        {
            this.txtID.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["ID"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["CODIGO_EMPLEADO"].Value);
            this.txtNumero_Banca.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["NUMERO_BANCA"].Value);
            this.txtNombre.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["NOMBRE"].Value);
            this.txtApellido.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["APELLIDO"].Value);
            this.txtCedula.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["CEDULA"].Value);
            this.txtSalario.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["SALARIO"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["TELEFONO"].Value);
            this.txtSector.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["SECTOR"].Value);
            this.txtLocal.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["LOCAL"].Value);
            this.dtFecha_Entrada.Value = Convert.ToDateTime(this.dgvEmpleados.CurrentRow.Cells["FECHA_ENTRADA"].Value);
            this.txtFechaSalida.Text = Convert.ToString(this.dgvEmpleados.CurrentRow.Cells["FECHA_SALIDA"].Value);

            tabControl1.SelectedIndex = 1;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(!this.txtID.Text.Equals(""))
            {
                this.IsEditar = true;
                this.botones();
                this.habilitar(true);
            }
            else
            {
                MensajeError("Debe seleccionar primero el registro a Modificar");
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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEliminar.Checked)
            {
                this.dgvEmpleados.Columns[0].Visible = true;
            }
            else
            {
                this.dgvEmpleados.Columns[0].Visible=false;
            }
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvEmpleados.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dgvEmpleados.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Realmente desea eliminar los Registros", "MANTENIMIENTO DE EMPLEADOS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string respuesta = "";

                    foreach (DataGridViewRow row in dgvEmpleados.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            respuesta = B_employees.Eliminar(Convert.ToInt32(codigo));

                            if (respuesta.Equals("OK"))
                            {
                                MensajeOk("Se elimino correctamente el registro");
                            }
                            else
                            {
                                MensajeError(respuesta);
                            }
                        }
                    }
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }

        private void chkFecha_Salida_CheckedChanged(object sender, EventArgs e)
        {
            if(chkFecha_Salida.Checked)
            {
                txtFechaSalida.Visible = true;
                txtFechaSalida.Enabled = true;
            }
            else
            {
                txtFechaSalida.Visible = false;
               
            }

        }
        private void txtNumero_Banca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >=58 && e.KeyChar<=255))
            {
                MessageBox.Show("Solo numeros", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 67;
            }
            else
            {
                MenuVertical.Width = 250;
            }

        }
        private void txtFechaSalida_MouseEnter(object sender, EventArgs e)
        {
            txtFechaSalida.Text = string.Empty;
        }

        private void txtSector_MouseEnter(object sender, EventArgs e)
        {
            txtSector.BackColor = Color.White;
        }

        private void txtLocal_MouseEnter(object sender, EventArgs e)
        {
            txtLocal.BackColor = Color.White;
        }

        private void txtFechaSalida_KeyPress(object sender, KeyPressEventArgs e)
        {
                if ((e.KeyChar >= 32 && e.KeyChar <= 46) || (e.KeyChar >= 58 && e.KeyChar <= 255))
                {
                    MessageBox.Show("Solo numeros", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
        }


        private void timerEmp_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongDateString();
        }

        private void btnAdminForm_Click(object sender, EventArgs e)
        {
            Form frmAdmin = new ConfigurationAdmin();
            frmAdmin.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("¿Realmente desea salir de la aplicación?", "Consorcio de Bancas la Fortuna", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK) Application.Exit();

        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) WindowState = FormWindowState.Maximized;

            else if (WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Normal;
               
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) WindowState = FormWindowState.Minimized;
            else if (WindowState == FormWindowState.Minimized) WindowState = FormWindowState.Normal;
            else if (WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Minimized;
        }
    }

    
}
