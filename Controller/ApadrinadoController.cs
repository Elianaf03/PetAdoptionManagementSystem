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
    public class ApadrinadoController
    {
        ApadrinadoDao apadrinadoDao = new ApadrinadoDao();
        public DataTable ListarApadrinados()
        {
            return apadrinadoDao.listarApadrinados();
        }
        public DataTable ListarApadrinadosPorIdUsuario(int id)
        {
            return apadrinadoDao.ListarApadrinadosPorIdUsuario(id);
        }
        public void AgregarApadrinado(Apadrinado apadrinado, List<ApadrinadoDetalle> lst)
        {
            apadrinadoDao.agregarApadrinados(apadrinado, lst);
        }
        
        public Apadrinado ListarApadrinadoPorId(int id)
        {
            return apadrinadoDao.ListarApadrinadoPorId(id);
        }

        public void cambiarEstadoDeApadrinado(int id, string estado)
        {
            apadrinadoDao.cambiarEstadoDeApadrinado(id, estado);
        }
        
    }
}
