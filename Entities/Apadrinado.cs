using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Apadrinado
    {
        public int IdApadrinado { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Monto { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }

        public Apadrinado(int idApadrinado, int idUsuario, DateTime fecha, Decimal monto, string estado, string comentario)
        {
            IdApadrinado = idApadrinado;
            IdUsuario = idUsuario;
            Fecha = fecha;
            Monto = monto;
            Estado = estado;
            Comentario = comentario;
        }

        public Apadrinado()
        {
        }
    }
}
