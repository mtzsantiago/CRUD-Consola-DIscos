using _250225;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _250225
{
    public class DiscoRepository : IDiscoRepository
    {
        private readonly string connectionString;

        public DiscoRepository()
        {
            var conexion = new Conexion();
            connectionString = conexion.getConnectionString();
        }

        public void InsertarDisco(Disco disco)
        {
            using var conexion = new SqlConnection(connectionString);
            conexion.Open();

            using var comando = new SqlCommand("InsertarDisco", conexion)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            comando.Parameters.AddWithValue("@titulo", disco.nombre);
            comando.Parameters.AddWithValue("@artista", disco.artista);
            comando.Parameters.AddWithValue("@genero", disco.genero);
            comando.Parameters.AddWithValue("@anio", disco.anio);
            comando.Parameters.AddWithValue("@precio", disco.precio);

            comando.ExecuteNonQuery();
        }

        public void ActualizarDisco(Disco disco)
        {
            using var conexion = new SqlConnection(connectionString);
            conexion.Open();

            using var comando = new SqlCommand("ActualizarDisco", conexion)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            comando.Parameters.AddWithValue("@id", disco.id);
            comando.Parameters.AddWithValue("@nombre", disco.nombre);
            comando.Parameters.AddWithValue("@artista", disco.artista);
            comando.Parameters.AddWithValue("@genero", disco.genero);
            comando.Parameters.AddWithValue("@anio", disco.anio);
            comando.Parameters.AddWithValue("@precio", disco.precio);

            comando.ExecuteNonQuery();
        }

        public void EliminarDisco(int id)
        {
            using var conexion = new SqlConnection(connectionString);
            conexion.Open();

            using var comando = new SqlCommand("EliminarDisco", conexion)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
        }


        public List<Disco> ObtenerDisco()
        {
            var discos = new List<Disco>();

            using var conexion = new SqlConnection(connectionString);
            conexion.Open();

            using var comando = new SqlCommand("ObtenerDiscos", conexion)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                discos.Add(new Disco
                {
                    id = lector.GetInt32(0),
                    nombre = lector.GetString(1),
                    artista = lector.GetString(2),
                    genero = lector.GetString(3),
                    anio = lector.GetInt32(4),
                    precio = lector.GetDecimal(5)
                });
            }

            return discos;
        }
    }
}
