using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Mascota
    {
        public int IdMascota { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Edad { get; set; }
        public bool Castrado { get; set; }
        public string Descripcion { get; set; }
        public string Situacion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public byte[] Foto { get; set; }

        public Mascota(int idMascota, string nombre, string especie, string sexo, string edad, bool castrado, string descripcion, string situacion, string estado, DateTime fechaIngreso, byte[] foto)
        {
            IdMascota = idMascota;
            Nombre = nombre;
            Especie = especie;
            Sexo = sexo;
            Edad = edad;
            Castrado = castrado;
            Descripcion = descripcion;
            Situacion = situacion;
            Estado = estado;
            FechaIngreso = fechaIngreso;
            Foto = foto;
        }

        public Mascota()
        {
        }
    }
}
