using System;

namespace ProyectoEleventa
{
    public static class Sesion
    {
        public static int? IdUsuarioActual { get; private set; }
        public static string UsuarioActual { get; private set; }

        public static void Iniciar(int idUsuario, string usuario)
        {
            IdUsuarioActual = idUsuario > 0 ? (int?)idUsuario : null;
            UsuarioActual = usuario;
        }

        public static void Cerrar()
        {
            IdUsuarioActual = null;
            UsuarioActual = null;
        }
    }
}
