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
    public class AdopcionDao : Conexion
    {
        public DataTable listarAdopcions(string cTexto)
        {
            DataTable lstLibros = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ListarAdopciones";
                    command.Parameters.AddWithValue("@cTexto", cTexto);
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstLibros.Load(leerFilas);
                    leerFilas.Close();
                    return lstLibros;
                }
            }
        }

        public DataTable ListarAdopcionesVoluntarios()
        {
            DataTable lstLibros = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ListarAdopcionesVoluntarios";
                    //command.Parameters.AddWithValue("@cTexto", cTexto);
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstLibros.Load(leerFilas);
                    leerFilas.Close();
                    return lstLibros;
                }
            }
        }

        public DataTable ListarAdopcionPorIdUsuario(int id)
        {
            DataTable lstLibros = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ListarAdopcionPorIdUsuario";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstLibros.Load(leerFilas);
                    leerFilas.Close();
                    return lstLibros;
                }
            }
        }

        public void agregarAdopcion(Adopcion adopcion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idUsuario", adopcion.IdUsuario);
                    command.Parameters.AddWithValue("@idMascota", adopcion.IdMascota);
                    command.Parameters.AddWithValue("@estado", adopcion.Estado);
                    command.Parameters.AddWithValue("@comentario", adopcion.Comentario);
                    command.CommandText = "sp_AgregarAdopcion";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }
        public void editarAdopcion(Adopcion adopcion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idAdopcion", adopcion.IdAdopcion);
                    command.Parameters.AddWithValue("@idUsuario", adopcion.IdUsuario);
                    command.Parameters.AddWithValue("@idMascota", adopcion.IdMascota);
                    command.Parameters.AddWithValue("@estado", adopcion.Estado);
                    command.Parameters.AddWithValue("@comentario", adopcion.Comentario);
                    command.CommandText = "sp_EditarAdopcion";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void eliminarAdopcion(int idAdopcion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idAdopcion", idAdopcion);
                    command.CommandText = "sp_EliminarAdopcion";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
    }
}
