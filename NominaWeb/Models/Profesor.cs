using System.ComponentModel.DataAnnotations;

namespace NominaWeb.Models
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public double PrecioHora { get; set; }
        public int CantidadHoras { get; set; }
        public double MontoGanado { get; set; } //PrecioHora * CantidadHoras
        public double Incentivos { get; set; }
        public double TotalGanado { get; set; } //MontoGanado + Incentivos
        public double ISR { get; set; }
        public double Avances { get; set; }
        public double TotalDeducciones { get; set; } // ISR + Avances
        public double TotalRecibir { get; set; } //Total Ganado - TotalDeducciones
    }
}
