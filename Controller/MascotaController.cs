using Entities;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class MascotaController
    {
        MascotaDao mascotaDao = new MascotaDao();
        public DataTable ListarMascotas(string cTexto)
        {
            return mascotaDao.listarMascotas(cTexto);
        }

        public DataTable ListarMascotasPorEstado(string estado1, string estado2)
        {
            return mascotaDao.listarMascotasPorEstado(estado1, estado2);
        }

        public DataTable BuscarMascotaPorNombreOEspecie(string nombre, string especie)
        {
            return mascotaDao.buscarMascotaPorNombreOEspecie(nombre, especie);
        }

        public void AgregarMascota(Mascota mascota)
        {
            this.mascotaDao.agregarMascota(mascota);
        }
        public void EditarMascota(Mascota mascota)
        {
            this.mascotaDao.editarMascota(mascota);
        }
        public void EliminarMascota(int idMascota)
        {
            this.mascotaDao.eliminarMascota(idMascota);
        }
        public void EditarEstadoDeMascota(int idMascota, string estado)
        {
            this.mascotaDao.editarEstadoDeMascota(idMascota, estado);
        }
        public byte[] ObtenerFotoMascota(int idMascota)
        {
            return mascotaDao.obtenerFotoMascota(idMascota);
        }
        public Mascota MascotaPorId(int idMascota)
        {
            return this.mascotaDao.mascotaPorId(idMascota);
        }

        public DataTable ApadrinadosPorId(int idApadrinado)
        {
            return mascotaDao.apadrinadosPorId(idApadrinado);
        }
    }
}
