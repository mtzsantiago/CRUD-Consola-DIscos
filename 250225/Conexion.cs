using System;
using Microsoft.Data.SqlClient; // Usa Microsoft.Data.SqlClient para .NET 8

namespace _250225
{
    class Conexion
    {
        private readonly string connectionString;

        public Conexion()
        {
            connectionString = "Server=KITAGAWA;Database=Sony;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        }
        public string getConnectionString() => connectionString;

        public void ProbarConexion()
        {
            try
            {
                using var conexion = new SqlConnection(connectionString);
                conexion.Open();
                Console.WriteLine("✅ Conexión exitosa a SQL Server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al conectar: {ex.Message}");
            }
        }
    }
}
