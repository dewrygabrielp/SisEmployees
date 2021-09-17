using System;
using System.Data;
using System.Data.SqlClient;

namespace Access
{
   public class A_Users
   {
        private int idusuario;
        private string usuario;
        private string password;
        private string nombre;
        private string apellido;
        private string acceso;

        public int Idusuario { get => idusuario; set => idusuario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Acceso { get => acceso; set => acceso = value; }

        //Constructor vacio
        public A_Users()
        {

        }
        //Instance to class connection

        Sqlconnection Connection = new Sqlconnection();
        //Constructor con parametros

        public A_Users(int idusuario, string nombre, string apellido, string usuario, string password, string acceso)
        {
            this.Idusuario = idusuario;
            this.Usuario = usuario;
            this.Password = password;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Acceso = acceso;
        }

        //Metodos para leer la tabla Usuarios de la BD

        public DataTable Login(A_Users Users)
        {
            DataTable dt = new DataTable("USUARIOS");
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.GetSqlConnection(); 
                SqlCmd.CommandText = "sp_login";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Users.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Users.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;

        }

        //Metodo Insertar Usuarios
        public string Insertar(A_Users User)
        {
            string respuesta = "";
            try
            {
                //Establecemos el comando

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.GetSqlConnection();

                SqlCmd.CommandText = "spinsertar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuarios = new SqlParameter();
                ParIdUsuarios.ParameterName = "@idusuario";
                ParIdUsuarios.SqlDbType = SqlDbType.Int;
                ParIdUsuarios.Direction = ParameterDirection.Output;
                ParIdUsuarios.Value = User.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuarios);


                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = User.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 40;
                ParApellido.Value = User.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = User.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = User.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = User.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);


                //Ejecutamos el comando

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Usuario";
            }
            catch (Exception ex)
            {
                respuesta = (ex.Message);

            }
            finally
            {
                Connection.CloseSqlConnection();
            }
            return respuesta;
        }

        //Metodo para mostrar usuarios








        //Metodo editar
        public string Editar(A_Users User)
        {
            string respuesta = "";
            try
            {

                //Establecemos el comando

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.GetSqlConnection();

                SqlCmd.CommandText = "speditar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuarios = new SqlParameter();
                ParIdUsuarios.ParameterName = "@idusuario";
                ParIdUsuarios.SqlDbType = SqlDbType.Int;
                ParIdUsuarios.Value = User.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuarios);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = User.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 40;
                ParApellido.Value = User.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = User.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = User.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = User.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);


                //Ejecutamos el comando

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Edito el Usuario";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;

            }
            finally
            {
                Connection.CloseSqlConnection();
            }
            return respuesta;
        }
        //Metodo Eliminar Usuarios

        public string Eliminar(A_Users User)
        {
            string respuesta = "";
            try
            {
                
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.GetSqlConnection();
                SqlCmd.CommandText = "spelimiar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParEliminar = new SqlParameter();
                ParEliminar.ParameterName = "@idusuario";
                ParEliminar.SqlDbType = SqlDbType.Int;
                ParEliminar.Value = User.Idusuario;
                SqlCmd.Parameters.Add(ParEliminar);

                //Ejecutamos el comando

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ELIMINO EL REGISTRO";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                Connection.CloseSqlConnection();
            }
            return respuesta;
        }
        public DataTable MostrarUsuarios()
        {
            {
                DataTable dt = new DataTable("USUARIOS");
                try
                {

                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = Connection.GetSqlConnection();
                    SqlCmd.CommandText = "spmostrar_usuarios";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);

                    SqlDa.Fill(dt);

                }
                catch (Exception)
                {
                    dt = null;
              

                }
                finally
                {
                    Connection.CloseSqlConnection();
                }
                return dt;
            }
            //Metodo para que el admin visualice

        }
        public DataTable MostrarUsuariosAdmin()
        {
            DataTable dt = new DataTable("USUARIOS");

            try
            { 
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.GetSqlConnection();
                SqlCmd.CommandText = "spmostrar_usuarios_administrador";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                
            }
            finally
            {
                Connection.CloseSqlConnection();
            }
            return dt;
        }
    }
}
