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
    public class VisitaController
    {
        VisitaDao visitaDao = new VisitaDao();
        public DataTable ListarVisitas()
        {
            return visitaDao.listarVisitas();
        }
        public DataTable VisitasPorAdoptante(int dni)
        {
            return visitaDao.VisitasPorAdoptante(dni);
        }
        public void AgregarVisita(Visita visita)
        {
            this.visitaDao.agregarVisita(visita);
        }
        public void EditarVisita(Visita visita)
        {
            this.visitaDao.editarVisita(visita);
        }
        public void EliminarVisita(int idVisita)
        {
            this.visitaDao.eliminarVisita(idVisita);
        }
    }
}
