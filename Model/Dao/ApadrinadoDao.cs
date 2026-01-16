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
    public class ApadrinadoDao : Conexion
    {
        public DataTable listarApadrinados()
        {
            DataTable lstLibros = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ListarApadrinados";
                    //command.Parameters.AddWithValue("@cTexto", cTexto);
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lstLibros.Load(leerFilas);
                    leerFilas.Close();
                    return lstLibros;
                }
            }
        }

        public DataTable ListarApadrinadosPorIdUsuario(int id)
        {
            DataTable lst = new DataTable();

            using (var connection = GetConnection())
            {
                SqlDataReader leerFilas;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandText = "sp_ListarApadrinadosPorIdUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    leerFilas = command.ExecuteReader();
                    lst.Load(leerFilas);
                    leerFilas.Close();
                    return lst;
                }
            }
        }

        public void agregarApadrinados(Apadrinado apadrinado, List<ApadrinadoDetalle> lst)
        {
            //Definir tabla Detalle
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("IdMascota");

            int i = 1;
            //Recorrer y añadir al DataTable los datos de la lista
            foreach (var oElement in lst)
            {
                dt.Rows.Add(
                    i,
                    oElement.IdMascota);
                i++;
            }

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    var parametroLista = new SqlParameter("lstDetalle", SqlDbType.Structured); //definicion de un parametro como estructura
                    parametroLista.TypeName = "dbo.Detalle";    //le asigno el nombre del tipo de la BD
                    parametroLista.Value = dt;  //asignarle los datos que toma del DataTable por foreach
                    command.Parameters.Add(parametroLista);
                    command.Parameters.AddWithValue("@idUsuario", apadrinado.IdUsuario);
                    command.Parameters.AddWithValue("@monto", apadrinado.Monto);
                    command.Parameters.AddWithValue("@estado", apadrinado.Estado);
                    command.Parameters.AddWithValue("@comentario", apadrinado.Comentario);
                    command.CommandText = "sp_GuardarApadrinado";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

        
        public Apadrinado ListarApadrinadoPorId(int id)
        {
            Apadrinado a= new Apadrinado();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandText = "sp_ListarApadrinadoPorId";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            a.IdApadrinado = reader.GetInt32(0);
                            a.IdUsuario = reader.GetInt32(1);
                            a.Fecha = reader.GetDateTime(2);
                            a.Monto = reader.GetDecimal(3);
                            a.Estado = reader.GetString(4);
                            a.Comentario = reader.GetString(5);
                        }

                    }
                    return a;
                }
            }
        }

        

        public void cambiarEstadoDeApadrinado(int id, string estado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand()) 
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@estado", estado);
                    command.CommandText = "sp_EditarApadrinado";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

    }
}
