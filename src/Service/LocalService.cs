using api_ingreso.src.Model;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;

namespace api_ingreso.src.Service
{
    public class LocalService
    {
        public LocalService() { }

        public static List<Local> GetAllLocal()
        {
            List<Local> listsLocales = new List<Local>();

            using (SqlConnection conn = new SqlConnection(DB.Conexion()))
            {
                conn.Open();

                string query = "select * from Ingreso.TM_Local";

                using SqlCommand cmd = new(query, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Local local = new Local
                    {
                        LocalId = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        FechaRegistro = reader.IsDBNull(2) ? null : (DateTime?)reader.GetDateTime(2),
                        TipoLocal = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Estado = reader.IsDBNull(4) ? null : (bool?)reader.GetBoolean(4),
                        NumeroPuertas = reader.IsDBNull(5) ? null : (short?)reader.GetInt16(5)
                    };

                    listsLocales.Add(local);
                }

            }

            return listsLocales;
        }

        public static Local GetLocalById(int localId)
        {
            Local local = new();

            using (SqlConnection conn = new(DB.Conexion()))
            {
                conn.Open();

                string query = $"select top 1  * from Ingreso.TM_Local where local_id={localId}";

                using SqlCommand cmd = new(query, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    local.LocalId = reader.GetInt32(0);
                    local.Nombre = reader.GetString(1);
                    local.FechaRegistro = reader.IsDBNull(2) ? null : (DateTime?)reader.GetDateTime(2);
                    local.TipoLocal = reader.IsDBNull(3) ? null : reader.GetString(3);
                    local.Estado = reader.IsDBNull(4) ? null : (bool?)reader.GetBoolean(4);
                    local.NumeroPuertas = reader.IsDBNull(5) ? null : (short?)reader.GetInt16(5);
                }

            }

            return local;
        }

        public static string InsertLocal(Local local)
        {

            using SqlConnection conn = new(DB.Conexion());
            conn.Open();

            SqlTransaction transac = conn.BeginTransaction();

            try
            {

           
                string query = "INSERT INTO Ingreso.TM_Local (Nombre, fecha_registro, TipoLocal, Estado, NumeroPuertas) " +
                                "VALUES (@Nombre, GETDATE(), @TipoLocal, @Estado, @NumeroPuertas)";

                using SqlCommand cmd = new(query, conn, transac);

                cmd.Parameters.AddWithValue("@Nombre", local.Nombre);
                cmd.Parameters.AddWithValue("@TipoLocal", local.TipoLocal);
                cmd.Parameters.AddWithValue("@Estado", local.Estado ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NumeroPuertas", local.NumeroPuertas ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
                transac.Commit();

                return "insert";
            }
            catch (Exception ex)
            {
                transac.Rollback();
                return ex.Message;
            }

        }

        public static string UpdateLocal(Local local)
        {
            using SqlConnection conn = new(DB.Conexion());
            conn.Open();

            SqlTransaction transac = conn.BeginTransaction();

            try
            {

                string query = "UPDATE Ingreso.TM_Local " +
                                   "SET Nombre = @Nombre, " +
                                   "    TipoLocal = @TipoLocal, " +
                                   "    Estado = @Estado, " +
                                   "    NumeroPuertas = @NumeroPuertas " +
                                   "WHERE LocalId = @LocalId";

                using SqlCommand cmd = new(query, conn, transac);

                cmd.Parameters.AddWithValue("@Nombre", local.Nombre);
                cmd.Parameters.AddWithValue("@TipoLocal", local.TipoLocal);
                cmd.Parameters.AddWithValue("@Estado", local.Estado ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NumeroPuertas", local.NumeroPuertas ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
                transac.Commit();

                return "update";
            }
            catch (Exception ex)
            {
                transac.Rollback();
                return ex.Message;
            }

        }

        public static string DeleteLocal(int localId)
        {
            using SqlConnection conn = new(DB.Conexion());
            conn.Open();

            SqlTransaction transac = conn.BeginTransaction();

            try
            {

                string query = "DELETE FROM Ingreso.TM_Local WHERE Local_Id = @LocalId";

                using SqlCommand cmd = new(query, conn, transac);

                cmd.Parameters.AddWithValue("@LocalId", localId);


                cmd.ExecuteNonQuery();
                transac.Commit();

                return "delete";
            }
            catch (Exception ex)
            {
                transac.Rollback();
                return ex.Message;
            }

        }

    }
}
