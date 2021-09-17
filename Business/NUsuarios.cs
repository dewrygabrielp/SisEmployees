using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisEmpleados
{
    public class NUsuarios
    {

        //Llamando al metodo Datatable Login DE LA CLASE D_USUARIOS

        public  DataTable Login(string usuario, string password)
        {
            DUsuarios ObjUsuario = new DUsuarios();
            ObjUsuario.Usuario = usuario;
            ObjUsuario.Password = password;
            return ObjUsuario.Login(ObjUsuario);
        }
        //Metodo que llama al metodo MostrarUsuarios de la clase DUsuarios
        public static DataTable MostrarUsuarios()
        {

            return new DUsuarios().MostrarUsuarios();
        }

        //Metodo Insertar Usuarios que llama al metodo insertar de la clase DUsuarios

        public static string Insertar(string nombre, string apellido, string acceso,string usuario, string password)
        {
            DUsuarios ObjUsuario = new DUsuarios();
            // ObjUsuario.Idusuario = idusuario;
            ObjUsuario.Nombre = nombre;
            ObjUsuario.Apellido = apellido;
            ObjUsuario.Acceso = acceso; 
            ObjUsuario.Usuario = usuario;
            ObjUsuario.Password = password;
            return ObjUsuario.Insertar(ObjUsuario);
        }
        //Metodo Editar Usuarios que llama al metodo Editar de la clase DUsuarios
        public static string Editar(int idusuario, string nombre, string apellido, string acceso, string usuario, string password)
        {
            DUsuarios ObjUsuario = new DUsuarios();
            ObjUsuario.Idusuario = idusuario;
            ObjUsuario.Nombre = nombre;
            ObjUsuario.Apellido = apellido;
            ObjUsuario.Acceso = acceso;
            ObjUsuario.Usuario = usuario;
            ObjUsuario.Password = password;
            return ObjUsuario.Editar(ObjUsuario);
        }
        //Metodo Eliminar que hace transaccion con cuyo metodo de la clase DUsuarios

        public static string Eliminar(int idsuario)
        {
            DUsuarios ObjUsuario = new DUsuarios();
            ObjUsuario.Idusuario = idsuario;
            return ObjUsuario.Eliminar(ObjUsuario);
        }

        //Metodo para que el administrador visualice
        public  DataTable MostrarUsuariosAdmin()
        {
            return new DUsuarios().MostrarUsuariosAdmin();
        }
    }
}
