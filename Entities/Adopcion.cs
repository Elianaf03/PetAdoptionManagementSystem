using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Adopcion
    {
        public int IdAdopcion { get; set; }
        public int IdUsuario { get; set; }
        public int IdMascota { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }

        public Adopcion(int idAdopcion, int idUsuario, int idMascota, DateTime fecha, string estado, string comentario)
        {
            IdAdopcion = idAdopcion;
            IdUsuario = idUsuario;
            IdMascota = idMascota;
            Fecha = fecha;
            Estado = estado;
            Comentario = comentario;
        }

        public Adopcion()
        {
        }
    }
}
