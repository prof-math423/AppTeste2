namespace Salario.Models
{
    public class SalarioModel
    {
        public decimal ValorHora { get; set; }
        public decimal HorasTrabalhadas { get; set; }

        public decimal CalcularSalario()
        {
            return (ValorHora * HorasTrabalhadas) * 22;
        }
    }
}
