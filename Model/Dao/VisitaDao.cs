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
    public class VisitaDao : Conexion
    {
        public DataTable listarVisitas()
        {
            DataTable lstLibros = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ListarVisitas";
                    //command.Parameters.AddWithValue("@cTexto", cTexto);
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstLibros.Load(leerFilas);
                    leerFilas.Close();
                    return lstLibros;
                }
            }
        }

        public DataTable VisitasPorAdoptante(int dni)
        {
            DataTable lstVisitas = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@dni", dni);
                    command.CommandText = "sp_VisitasPorAdoptante";
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstVisitas.Load(leerFilas);
                    leerFilas.Close();
                    return lstVisitas;
                }
            }
        }

        public void agregarVisita(Visita visita)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idUsuario", visita.IdUsuario);
                    command.Parameters.AddWithValue("@nombre", visita.Nombre);
                    command.Parameters.AddWithValue("@apellido", visita.Apellido);
                    command.Parameters.AddWithValue("@dni", visita.Dni);
                    command.Parameters.AddWithValue("@motivo", visita.Motivo);
                    command.Parameters.AddWithValue("@Descripcion", visita.Descripcion);
                    
                    command.CommandText = "sp_AgregarVisita";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }
        public void editarVisita(Visita visita)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idVisita", visita.IdVisita);
                    command.Parameters.AddWithValue("@idUsuario", visita.IdUsuario);
                    command.Parameters.AddWithValue("@nombre", visita.Nombre);
                    command.Parameters.AddWithValue("@apellido", visita.Apellido);
                    command.Parameters.AddWithValue("@dni", visita.Dni);
                    command.Parameters.AddWithValue("@motivo", visita.Motivo);
                    command.Parameters.AddWithValue("@Descripcion", visita.Descripcion);
                    command.CommandText = "sp_EditarVisita";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void eliminarVisita(int idVisita)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idVisita", idVisita);
                    command.CommandText = "sp_EliminarVisita";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
    }
}
