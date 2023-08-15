using api_ingreso.src.Model;
using System.Data.SqlClient;

namespace api_ingreso.src.Service
{
    public class IngresoService {
    
        public IngresoService() { }

        public static string getIngreso() {

            string version = "";

            Console.WriteLine(DB.Conexion());


            // Utiliza el bloque using para asegurarte de que la conexión se cierre adecuadamente
            using (SqlConnection conn = new SqlConnection(DB.Conexion()))
            {
                conn.Open();

                string query = "SELECT @@VERSION;";

                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    version = reader.GetString(1);
                }


            }
            return version;
        }
        

    }
}
