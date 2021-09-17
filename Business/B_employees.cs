using System;
using System.Data;
using Access;

namespace Business
{
    public class B_employees
    {
        //Metodo insertar que se comunica con el metodo insertar de la clase Dempleados

        public static string Insertar(int numero_bancas, string nombre, string apellido, string cedula,
            double salario, string telefono, string sector, string local, DateTime fecha_entrada, string fecha_salida)
        {
            A_employees Obj = new A_employees();
            Obj.Numero_Banca = numero_bancas;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Cedula = cedula;
            Obj.Salario = salario;
            Obj.Telefono = telefono;
            Obj.Sector = sector;
            Obj.Local = local;
            Obj.Fecha_Entrada = fecha_entrada;
            Obj.Fecha_Salida = fecha_salida;


            return Obj.Insertar(Obj);
        }
        //Metodo Editar que se comunica con el metodo Editar de la clase Dempleados
        public static string Editar(int idempleado, string codigo, int numero_bancas, string nombre, string apellido, string cedula,
            double salario, string telefono, string sector, string local, DateTime fecha_entrada, string fecha_salida)
        {
            A_employees Obj = new A_employees();
            Obj.IDempleado = idempleado;
            Obj.Codigo = codigo;
            Obj.Numero_Banca = numero_bancas;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Cedula = cedula;
            Obj.Salario = salario;
            Obj.Telefono = telefono;
            Obj.Sector = sector;
            Obj.Local = local;
            Obj.Fecha_Entrada = fecha_entrada;
            Obj.Fecha_Salida = fecha_salida;

            return Obj.Editar(Obj);
        }
        public static string Eliminar(int idempleado)
        {
            A_employees Obj = new A_employees();
            Obj.IDempleado = idempleado;

            return Obj.Eliminar(Obj);

        }
        public static DataTable Mostrar()
        {
            return new A_employees().Mostrar();
        }
        public static DataTable BuscarPorNombre(string textobuscar)
        {
            A_employees Obj = new A_employees();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarPorNombre(Obj);
        }


    }
}
