using Access;
using System.Data;

namespace Business
{
     public class B_Users
     {
        public DataTable Login(string usuario, string password)
        {
            A_Users ObjUsuario = new A_Users();
            ObjUsuario.Usuario = usuario;
            ObjUsuario.Password = password;
            return ObjUsuario.Login(ObjUsuario);
        }

        public static DataTable MostrarUsuarios()
        {
            return new A_Users().MostrarUsuarios();
        }

        public static string Insertar(string nombre, string apellido, string acceso, string usuario, string password)
        {
            A_Users ObjUsuario = new A_Users();
            ObjUsuario.Nombre = nombre;
            ObjUsuario.Apellido = apellido;
            ObjUsuario.Acceso = acceso;
            ObjUsuario.Usuario = usuario;
            ObjUsuario.Password = password;
            return ObjUsuario.Insertar(ObjUsuario);
        }
        public static string Editar(int idusuario, string nombre, string apellido, string acceso, string usuario, string password)
        {
            A_Users ObjUsuario = new A_Users();
            ObjUsuario.Idusuario = idusuario;
            ObjUsuario.Nombre = nombre;
            ObjUsuario.Apellido = apellido;
            ObjUsuario.Acceso = acceso;
            ObjUsuario.Usuario = usuario;
            ObjUsuario.Password = password;
            return ObjUsuario.Editar(ObjUsuario);
        }
        public static string Eliminar(int idsuario)
        {
            A_Users ObjUsuario = new A_Users();
            ObjUsuario.Idusuario = idsuario;
            return ObjUsuario.Eliminar(ObjUsuario);
        }

        public DataTable MostrarUsuariosAdmin()
        {
            return new A_Users().MostrarUsuariosAdmin();
        }
    }
}
