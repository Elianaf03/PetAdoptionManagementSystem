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
    public class UsuarioController
    {
        UsuarioDao usuarioDao = new UsuarioDao();
        public bool Login(string loginname, string pass)
        {
            return usuarioDao.login(loginname, pass);
        }

        public DataTable ListarUsuarios(string cTexto)
        {
            return usuarioDao.listarUsuarios(cTexto);
        }

        public DataTable ListarUsuariosAdoptantes(string cTexto)
        {
            return usuarioDao.listarUsuariosAdoptantes(cTexto);
        }

        public void AgregarUsuario(Usuario usuario)
        {
            this.usuarioDao.agregarUsuario(usuario);
        }
        public void EditarUsuario(Usuario usuario)
        {
            this.usuarioDao.editarUsuario(usuario);
        }
        public void EliminarUsuario(int idUsuario)
        {
            this.usuarioDao.eliminarUsuario(idUsuario);
        }
        public byte[] ObtenerFoto(int idUsuario)
        {
            return usuarioDao.obtenerFoto(idUsuario);
        }
        public string NombreUsuario(int idUsuario)
        {
            return usuarioDao.NombreUsuario(idUsuario);
        }
    }
}
