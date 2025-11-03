// Salario.cs
using System;

namespace AppTeste.Models // Garanta que este namespace esteja correto (AppTeste.Models)
{
    public class Salario
    {
        // Propriedades usadas para o cálculo
        public decimal ValorHora { get; set; }
        public decimal HorasTrabalhadas { get; set; }

        // Método chamado pelo ViewModel (CalcularSalario)
        public decimal CalcularSalario()
        {
            return ValorHora * HorasTrabalhadas;
        }
    }
}