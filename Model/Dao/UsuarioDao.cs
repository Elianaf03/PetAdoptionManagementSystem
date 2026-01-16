using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UsuarioDao : Conexion
    {
        public bool login(string loginName, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@login", loginName);
                    command.Parameters.AddWithValue("@pass", password);
                    command.CommandText = "SELECT * FROM Usuario WHERE LoginName=@login AND Password=@pass";
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UsuarioCache.IdUsuario = reader.GetInt32(0);
                            UsuarioCache.Nombre = reader.GetString(1);
                            UsuarioCache.Apellido = reader.GetString(2);
                            UsuarioCache.Dni = reader.GetInt32(3);
                            UsuarioCache.Telefono = reader.GetInt64(4);
                            UsuarioCache.Correo = reader.GetString(5);
                            UsuarioCache.Direccion = reader.GetString(6);
                            UsuarioCache.LoginName = reader.GetString(7);
                            UsuarioCache.Password = reader.GetString(8);
                            UsuarioCache.Rol = reader.GetString(9);
                            byte[] imgData = (byte[])reader[10];
                            UsuarioCache.Foto = imgData;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }

        public DataTable listarUsuarios(string cTexto)
        {
            DataTable lstLibros = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ListarUsuarios";
                    command.Parameters.AddWithValue("@cTexto", cTexto);
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstLibros.Load(leerFilas);
                    leerFilas.Close();
                    return lstLibros;
                }
            }
        }

        public DataTable listarUsuariosAdoptantes(string cTexto)
        {
            DataTable lstLibros = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ListarUsuariosAdoptantes";
                    command.Parameters.AddWithValue("@cTexto", cTexto);
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstLibros.Load(leerFilas);
                    leerFilas.Close();
                    return lstLibros;
                }
            }
        }

        public void agregarUsuario(Usuario usuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@dni", usuario.Dni);
                    command.Parameters.AddWithValue("@telefono", usuario.Telefono);
                    command.Parameters.AddWithValue("@correo", usuario.Correo);
                    command.Parameters.AddWithValue("@direccion", usuario.Direccion);
                    command.Parameters.AddWithValue("@loginName", usuario.LoginName);
                    command.Parameters.AddWithValue("@password", usuario.Password);
                    command.Parameters.AddWithValue("@rol", usuario.Rol);
                    command.Parameters.AddWithValue("@foto", usuario.Foto);
                    command.CommandText = "sp_AgregarUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }
        public void editarUsuario(Usuario usuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
                    command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@dni", usuario.Dni);
                    command.Parameters.AddWithValue("@telefono", usuario.Telefono);
                    command.Parameters.AddWithValue("@correo", usuario.Correo);
                    command.Parameters.AddWithValue("@direccion", usuario.Direccion);
                    command.Parameters.AddWithValue("@loginName", usuario.LoginName);
                    command.Parameters.AddWithValue("@password", usuario.Password);
                    command.Parameters.AddWithValue("@rol", usuario.Rol);
                    command.Parameters.AddWithValue("@foto", usuario.Foto);
                    command.CommandText = "sp_EditarUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void eliminarUsuario(int idUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    command.CommandText = "sp_EliminarUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

        public byte[] obtenerFoto(int idUsuario)
        {
            byte[] fotoDB = null;
            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    command.CommandText = "sp_ObtenerFoto";
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    if (leerFilas.Read())
                    {
                        fotoDB = (byte[])leerFilas.GetValue(0);
                    }
                    leerFilas.Close();
                    return fotoDB;
                }
            }
        }

        public string NombreUsuario(int idUsuario)
        {
            string name = "";
            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", idUsuario);
                    command.CommandText = "sp_UsuarioPorId";
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    if (leerFilas.Read())
                    {
                        name = leerFilas.GetValue(0).ToString();
                    }
                    leerFilas.Close();
                    return name;
                }
            }
        }
    }
}
