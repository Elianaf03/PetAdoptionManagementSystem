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
    public class MascotaDao : Conexion
    {
        public DataTable listarMascotas(string cTexto)
        {
            DataTable lstLibros = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ListarMascotas";
                    command.Parameters.AddWithValue("@cTexto", cTexto);
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstLibros.Load(leerFilas);
                    leerFilas.Close();
                    return lstLibros;
                }
            }
        }

        public DataTable listarMascotasPorEstado(string estado1, string estado2)
        {
            DataTable lstLibros = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ListarMascotasPorEstado";
                    command.Parameters.AddWithValue("@estado1", estado1);
                    command.Parameters.AddWithValue("@estado2", estado2);
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstLibros.Load(leerFilas);
                    leerFilas.Close();
                    return lstLibros;
                }
            }
        }

        public DataTable buscarMascotaPorNombreOEspecie(string nombre, string especie)
        {
            DataTable lstLibros = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_BuscarMascotaPorNombreOEspecie";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@especie", especie);
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstLibros.Load(leerFilas);
                    leerFilas.Close();
                    return lstLibros;
                }
            }
        }

        public void agregarMascota(Mascota mascota)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@nombre", mascota.Nombre);
                    command.Parameters.AddWithValue("@Especie", mascota.Especie);
                    command.Parameters.AddWithValue("@Sexo", mascota.Sexo);
                    command.Parameters.AddWithValue("@Edad", mascota.Edad);
                    command.Parameters.AddWithValue("@Castrado", mascota.Castrado);
                    command.Parameters.AddWithValue("@Descripcion", mascota.Descripcion);
                    command.Parameters.AddWithValue("@Situacion", mascota.Situacion);
                    command.Parameters.AddWithValue("@Estado", mascota.Estado);
                    command.Parameters.AddWithValue("@fechaIngreso", mascota.FechaIngreso);
                    command.Parameters.AddWithValue("@foto", mascota.Foto);
                    command.CommandText = "sp_AgregarMascota";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }
        public void editarMascota(Mascota mascota)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idMascota", mascota.IdMascota);
                    command.Parameters.AddWithValue("@nombre", mascota.Nombre);
                    command.Parameters.AddWithValue("@especie", mascota.Especie);
                    command.Parameters.AddWithValue("@sexo", mascota.Sexo);
                    command.Parameters.AddWithValue("@edad", mascota.Edad);
                    command.Parameters.AddWithValue("@castrado", mascota.Castrado);
                    command.Parameters.AddWithValue("@descripcion", mascota.Descripcion);
                    command.Parameters.AddWithValue("@situacion", mascota.Situacion);
                    command.Parameters.AddWithValue("@estado", mascota.Estado);
                    command.Parameters.AddWithValue("@fechaIngreso", mascota.FechaIngreso);
                    command.Parameters.AddWithValue("@foto", mascota.Foto);
                    command.CommandText = "sp_EditarMascota";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void editarEstadoDeMascota(int idMascota, string estado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idMascota", idMascota);
                    command.Parameters.AddWithValue("@estado", estado);
                    command.CommandText = "sp_EditarEstadoDeMascota";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

        public void eliminarMascota(int idMascota)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idMascota", idMascota);
                    command.CommandText = "sp_EliminarMascota";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

        public byte[] obtenerFotoMascota(int idMascota)
        {
            byte[] fotoDB = null;
            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idMascota", idMascota);
                    command.CommandText = "sp_ObtenerFotoMascota";
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
        
        public Mascota mascotaPorId(int idMascota)
        {
            Mascota mascota = new Mascota();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idMascota", idMascota);
                    command.CommandText = "sp_MascotaPorId";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            mascota.IdMascota = reader.GetInt32(0);
                            mascota.Nombre = reader.GetString(1);
                            mascota.Especie = reader.GetString(2);
                            mascota.Sexo = reader.GetString(3);
                            mascota.Edad = reader.GetString(4);
                            mascota.Castrado = reader.GetBoolean(5);
                            mascota.Descripcion = reader.GetString(6);
                            mascota.Situacion = reader.GetString(7);
                            mascota.Estado = reader.GetString(8);
                            mascota.FechaIngreso = reader.GetDateTime(9);
                            mascota.Foto = (byte[])reader.GetValue(10);
                        }

                    }
                    return mascota;
                }
            }
        }

        public DataTable apadrinadosPorId(int idApadrinado)
        {
            DataTable lst = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", idApadrinado);
                    command.CommandText = "sp_ApadrinadosPorId";
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lst.Load(leerFilas);
                    leerFilas.Close();
                    return lst;
                }
            }
        }
    }
}
