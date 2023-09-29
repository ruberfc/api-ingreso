namespace api_ingreso.src.Model
{
    public class Puerta
    {
        public int Puerta_Id { get; set; }
        public string Puerta_desc { get; set; }
        public string Puerta_ip { get; set; }

        public Puerta()
        {
            Puerta_desc = "Puerta por defecto";
            Puerta_ip = "0.0.0.0";
        }

    }
}
