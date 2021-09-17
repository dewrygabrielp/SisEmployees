using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access
{
    public class A_employees
    {

        private int _IDempleado;
        private string _Codigo;
        private int _Numero_Banca;
        private string _Nombre;
        private string _Apellido;
        private string _Cedula;
        private double _Salario;
        private string _Telefono;
        private string _Sector;
        private string _Local;
        private DateTime _Fecha_Entrada;
        private string _Fecha_Salida;
        private string _TextoBuscar;

        public int IDempleado { get => _IDempleado; set => _IDempleado = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public int Numero_Banca { get => _Numero_Banca; set => _Numero_Banca = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public double Salario { get => _Salario; set => _Salario = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Sector { get => _Sector; set => _Sector = value; }
        public string Local { get => _Local; set => _Local = value; }
        public DateTime Fecha_Entrada { get => _Fecha_Entrada; set => _Fecha_Entrada = value; }
        public string Fecha_Salida { get => _Fecha_Salida; set => _Fecha_Salida = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }



        //Constructor vacio
        public A_employees()
        {

        }
        //Instance to class connection

        Sqlconnection Connection = new Sqlconnection();

        //Constructor con parametros

        public A_employees(int idempleado, string codigo, int numero_bancas, string nombre, string apellido, string cedula,
            double salario, string telefono, string sector, string local, DateTime fecha_entrada, string fecha_salida, string textobuscar)
        {
            this.IDempleado = idempleado;
            this.Codigo = codigo;
            this.Numero_Banca = numero_bancas;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Cedula = cedula;
            this.Salario = salario;
            this.Telefono = telefono;
            this.Sector = sector;
            this.Local = local;
            this.Fecha_Entrada = fecha_entrada;
            this.Fecha_Salida = fecha_salida;

            this.TextoBuscar = textobuscar;
        }

        //Metodos

        //Metodo Insertar
        public string Insertar(A_employees Empleados)
        {
            string respuesta = "";

            try
            {
                //Codigo

                //Establecer Comandos
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.GetSqlConnection();
                SqlCmd.CommandText = "spinsertar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idempleado";
                ParIdEmpleado.DbType = DbType.Int32;
                ParIdEmpleado.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 6;
                ParCodigo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNumero_Banca = new SqlParameter();
                ParNumero_Banca.ParameterName = "@numerobanca";
                ParNumero_Banca.SqlDbType = SqlDbType.Int;
                ParNumero_Banca.Value = Empleados.Numero_Banca;
                SqlCmd.Parameters.Add(ParNumero_Banca);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Empleados.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 30;
                ParApellido.Value = Empleados.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@cedula";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Size = 20;
                ParCedula.Value = Empleados.Cedula;
                SqlCmd.Parameters.Add(ParCedula);

                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@salario";
                ParSalario.SqlDbType = SqlDbType.Money;
                ParSalario.Value = Empleados.Salario;
                SqlCmd.Parameters.Add(ParSalario);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 14;
                ParTelefono.Value = Empleados.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParSector = new SqlParameter();
                ParSector.ParameterName = "@sector";
                ParSector.SqlDbType = SqlDbType.VarChar;
                ParSector.Size = 30;
                ParSector.Value = Empleados.Sector;
                SqlCmd.Parameters.Add(ParSector);

                SqlParameter ParLocal = new SqlParameter();
                ParLocal.ParameterName = "@local";
                ParLocal.SqlDbType = SqlDbType.VarChar;
                ParLocal.Size = 30;
                ParLocal.Value = Empleados.Local;
                SqlCmd.Parameters.Add(ParLocal);

                SqlParameter ParFecha_Entrada = new SqlParameter();
                ParFecha_Entrada.ParameterName = "@fecha_e";
                ParFecha_Entrada.DbType = DbType.DateTime;
                //Daba error con SqlDbType Varchar
                ParFecha_Entrada.Value = Empleados.Fecha_Entrada;
                SqlCmd.Parameters.Add(ParFecha_Entrada);

                SqlParameter ParFecha_Salida = new SqlParameter();
                ParFecha_Salida.ParameterName = "@fecha_s";
                ParFecha_Salida.SqlDbType = SqlDbType.VarChar;
                //Daba error con SqlDbType Varchar
                ParFecha_Salida.Size = 20;
                ParFecha_Salida.Value = Empleados.Fecha_Salida;
                SqlCmd.Parameters.Add(ParFecha_Salida);

                //Ejecutamos el comando
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE INSERTO EL REGISTRO";

            }
            catch (Exception ex) { respuesta = ex.Message; }

            finally { Connection.CloseSqlConnection(); }

            return respuesta;
        }

        //Metodo Editar

        public string Editar(A_employees Empleados)
        {
            string respuesta = "";

            try
            {

                //Codigo
                //Establecer Comandos
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.GetSqlConnection();
                SqlCmd.CommandText = "speditar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idempleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleados.IDempleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 6;
                ParCodigo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNumero_Banca = new SqlParameter();
                ParNumero_Banca.ParameterName = "@numerobanca";
                ParNumero_Banca.SqlDbType = SqlDbType.Int;
                ParNumero_Banca.Value = Empleados.Numero_Banca;
                SqlCmd.Parameters.Add(ParNumero_Banca);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Empleados.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 30;
                ParApellido.Value = Empleados.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@cedula";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Size = 20;
                ParCedula.Value = Empleados.Cedula;
                SqlCmd.Parameters.Add(ParCedula);

                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@salario";
                ParSalario.SqlDbType = SqlDbType.Money;
                ParSalario.Value = Empleados.Salario;
                SqlCmd.Parameters.Add(ParSalario);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 14;
                ParTelefono.Value = Empleados.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParSector = new SqlParameter();
                ParSector.ParameterName = "@sector";
                ParSector.SqlDbType = SqlDbType.VarChar;
                //ParSector.Size = 30;
                ParSector.Value = Empleados.Sector;
                SqlCmd.Parameters.Add(ParSector);

                SqlParameter ParLocal = new SqlParameter();
                ParLocal.ParameterName = "@local";
                ParLocal.SqlDbType = SqlDbType.VarChar;
                //ParLocal.Size = 30;
                ParLocal.Value = Empleados.Local;
                SqlCmd.Parameters.Add(ParLocal);

                SqlParameter ParFecha_Entrada = new SqlParameter();
                ParFecha_Entrada.ParameterName = "@fecha_e";
                ParFecha_Entrada.DbType = DbType.DateTime;
                //ParFecha_Entrada.Size = 20;
                ParFecha_Entrada.Value = Empleados.Fecha_Entrada;
                SqlCmd.Parameters.Add(ParFecha_Entrada);

                SqlParameter ParFecha_Salida = new SqlParameter();
                ParFecha_Salida.ParameterName = "@fecha_s";
                ParFecha_Salida.SqlDbType = SqlDbType.VarChar;
                ParFecha_Salida.Size = 20;
                ParFecha_Salida.Value = Empleados.Fecha_Salida;
                SqlCmd.Parameters.Add(ParFecha_Salida);

                //Ejecutamos el comando
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE EDITO EL REGISTRO";

            }
            catch (Exception ex) { respuesta = ex.Message; }

            finally { Connection.CloseSqlConnection(); }

            return respuesta;

        }
        //Metodo Eliminar

        public string Eliminar(A_employees Empleados)
        {
            string respuesta = "";

            try
            {
                //Codigo
                //Establecer Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.GetSqlConnection();
                SqlCmd.CommandText = "speliminar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idempleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleados.IDempleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                //Ejecutamos el comando

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ELIMINO EL REGISTRO";

            }
            catch (Exception ex) { respuesta = ex.Message; }
            
            finally { Connection.CloseSqlConnection(); }

            return respuesta;
        }

        //Metodo Mostrar

        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("EMPLEADOS");
            try
            {
                //Codigo
                //Establecemos el comando

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.GetSqlConnection();
                SqlCmd.CommandText = "spmostrar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(dt);
            }
            catch (Exception) { dt = null; }

            finally { Connection.CloseSqlConnection(); }

            return dt;

        }

        //Metodo Buscar por Nombre

        public DataTable BuscarPorNombre(A_employees Empleados)
        {
            DataTable dt = new DataTable("EMPLEADOS");

            try
            {
                //Establecer Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.GetSqlConnection();
                SqlCmd.CommandText = "spbuscar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Insertar Parametros

                SqlParameter ParBuscarPorNombre = new SqlParameter();
                ParBuscarPorNombre.ParameterName = "@textobuscar";
                ParBuscarPorNombre.SqlDbType = SqlDbType.VarChar;
                ParBuscarPorNombre.Size = 50;
                ParBuscarPorNombre.Value = Empleados.TextoBuscar;
                SqlCmd.Parameters.Add(ParBuscarPorNombre);

                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(dt);
            }
            catch (Exception) { dt = null; }
    
            finally { Connection.CloseSqlConnection(); }
           
            return dt;

        }



    }

}
