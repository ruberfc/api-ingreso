using api_ingreso.src.Model;
using System.Data.SqlClient;


namespace api_ingreso.src.Service
{
    public class PuertaService
    {
        public PuertaService() { }

        public static List<Puerta> GetAllPuerta()
        {
            List<Puerta> listsPuertas = new List<Puerta>();

            using (SqlConnection conn = new SqlConnection(DB.Conexion()))
            {
                conn.Open();

                string query = "select * from Ingreso.TM_Puerta";

                using SqlCommand cmd = new(query, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Puerta puerta = new Puerta
                    {
                        Puerta_Id = reader.GetInt32(0),
                        Puerta_desc= reader.GetString(1),
                        Puerta_ip= reader.GetString(2),

                    };

                    listsPuertas.Add(puerta);
                }

            }

            return listsPuertas;
        }
    }
}
