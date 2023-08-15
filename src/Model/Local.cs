namespace api_ingreso.src.Model
{
     public class Local { 
        public int LocalId { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? TipoLocal { get; set; }
        public bool? Estado { get; set; }
        public int? NumeroPuertas { get; set; }
    } 
}

