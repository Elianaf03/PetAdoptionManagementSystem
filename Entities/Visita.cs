using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Visita
    {
        public int IdVisita { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Descripcion { get; set; }

        public Visita(int idVisita, int idUsuario, string nombre, string apellido, int dni, string motivo, DateTime fecha, DateTime hora, string descripcion)
        {
            IdVisita = idVisita;
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Motivo = motivo;
            Fecha = fecha;
            Hora = hora;
            Descripcion = descripcion;
        }

        public Visita()
        {
        }
    }
}
