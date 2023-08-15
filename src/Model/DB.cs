using DotNetEnv;
using Microsoft.AspNetCore.Hosting.Server;
using System.Runtime.CompilerServices;

namespace api_ingreso.src.Model
{
    public class DB
    {
        public static string Conexion()
        {
            // Cargar variables de entorno desde el archivo .env
            Env.Load();

          
            string? server = Environment.GetEnvironmentVariable("SERVER");
            string? database = Environment.GetEnvironmentVariable("DATABASE");
            string? port = Environment.GetEnvironmentVariable("PORT");
            string?  user_db = Environment.GetEnvironmentVariable("USER_DB");
            string? pass_db = Environment.GetEnvironmentVariable("PASS_DB");


            // Construye la cadena de conexión
            //string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            string? connectionString = $"Server={server},{port};Database={database};User Id={user_db};Password={pass_db};";

            return connectionString ?? "error cadena" ;
        }

    }
}
