using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public long Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public byte[] Foto { get; set; }

        public Usuario(int idUsuario, string nombre, string apellido, int dni, long telefono, string correo, string direccion, string loginName, string password, string rol, byte[] foto)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            LoginName = loginName;
            Password = password;
            Rol = rol;
            Foto = foto;
        }

        public Usuario()
        {
        }
    }
}
