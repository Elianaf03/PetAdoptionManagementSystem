using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public abstract class Conexion
    {
        private readonly string connectionString;
        public Conexion()
        {   //alt + 92 para barra invertida
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Acer\\Documents\\DB_TrabajoFinalIndividual.mdf;Integrated Security=True;Connect Timeout=30";

        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
