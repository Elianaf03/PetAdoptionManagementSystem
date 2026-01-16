using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ApadrinadoDetalle
    {
        public int IdApadrinadoDetalle { get; set; }
        public int IdMascota { get; set; }
        public int IdApadrinado { get; set; }

        public ApadrinadoDetalle(int idApadrinadoDetalle, int idMascota, int idApadrinado)
        {
            IdApadrinadoDetalle = idApadrinadoDetalle;
            IdMascota = idMascota;
            IdApadrinado = idApadrinado;
        }

        public ApadrinadoDetalle()
        {
        }
    }
}
