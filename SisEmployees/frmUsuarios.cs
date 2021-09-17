using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Business;



namespace Employees
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToLongDateString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            btnIngresar.UseWaitCursor = true;
            B_Users ObjNU = new B_Users();
            DataTable Datos = ObjNU.Login(this.txtUsuario.Text, this.txtPassword.Text);

            //Evaluar si existe el usuario
            if(Datos.Rows.Count==0)
            {
                MessageBox.Show("NO TIENE ACCESO AL SISTEMA", "BANCAS DANILO LA FORTUNA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmEmpleados FrmEmp = new frmEmpleados();
                FrmEmp.IdUsuario = Datos.Rows[0][0].ToString();
                FrmEmp.Nombre = Datos.Rows[0][1].ToString();
                FrmEmp.Apellido = Datos.Rows[0][2].ToString();
                
                FrmEmp.Show();
                this.Hide();
            }
            
        }
      

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(txtPassword.Text=="PASSWORD")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if(txtPassword.Text=="")
            {
                txtPassword.Text = "PASSWORD";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text=="USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text=="")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void Linkpass_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("COMUNICATE CON DEWRY G. P\n" +
                "Para que la cambie cuanto antes","FORTUNA FAMILY",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                B_Users ObjNU = new B_Users();
                DataTable Datos = ObjNU.Login(this.txtUsuario.Text, this.txtPassword.Text);

                //Evaluar si existe el usuario
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("NO TIENE ACCESO AL SISTEMA", "BANCAS DANILO LA FORTUNA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    frmEmpleados FrmEmp = new frmEmpleados();
                    FrmEmp.IdUsuario = Datos.Rows[0][0].ToString();
                    FrmEmp.Nombre = Datos.Rows[0][1].ToString();
                    FrmEmp.Apellido = Datos.Rows[0][2].ToString();
                    FrmEmp.Show();
                    this.Hide();
                    if (FrmEmp.Apellido == "Peña" && FrmEmp.Nombre == "Dewry")
                        FrmEmp.Acceso = "Administrador";
                }
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                B_Users ObjNU = new B_Users();
                DataTable Datos = ObjNU.Login(this.txtUsuario.Text, this.txtPassword.Text);

                //Evaluar si existe el usuario
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("NO TIENE ACCESO AL SISTEMA", "BANCAS DANILO LA FORTUNA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    frmEmpleados FrmEmp = new frmEmpleados();
                    FrmEmp.IdUsuario = Datos.Rows[0][0].ToString();
                    FrmEmp.Nombre = Datos.Rows[0][1].ToString();
                    FrmEmp.Apellido = Datos.Rows[0][2].ToString();
                    FrmEmp.Show();
                    this.Hide();
                    if (FrmEmp.Apellido == "Peña" && FrmEmp.Nombre == "Dewry")
                        FrmEmp.Acceso = "Administrador";

                }
            }
        }

        private void timerUser_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongDateString();
        }
    }
}
