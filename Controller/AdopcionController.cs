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
    public class AdopcionController
    {
        AdopcionDao adopcionDao = new AdopcionDao();

        public DataTable ListarAdopcions(string cTexto)
        {
            return adopcionDao.listarAdopcions(cTexto);
        }
        public DataTable ListarAdopcionesVoluntarios()
        {
            return adopcionDao.ListarAdopcionesVoluntarios();
        }
        public DataTable ListarAdopcionPorIdUsuario(int id)
        {
            return adopcionDao.ListarAdopcionPorIdUsuario(id);
        }
        public void AgregarAdopcion(Adopcion adopcion)
        {
            this.adopcionDao.agregarAdopcion(adopcion);
        }
        public void EditarAdopcion(Adopcion adopcion)
        {
            this.adopcionDao.editarAdopcion(adopcion);
        }
        public void EliminarAdopcion(int idAdopcion)
        {
            this.adopcionDao.eliminarAdopcion(idAdopcion);
        }
    }
}
