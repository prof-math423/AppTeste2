using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Salario.Commands;
using Salario.Models;

namespace Salario.ViewModels
{
    public class SalarioViewModel : INotifyPropertyChanged
    {
        private readonly SalarioModel _salario = new SalarioModel();
        private decimal _salarioCalculado;

        public decimal ValorHora
        {
            get => _salario.ValorHora;
            set
            {
                if (_salario.ValorHora != value)
                {
                    _salario.ValorHora = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SalarioCalculado));
                }
            }
        }

        public decimal HorasTrabalhadas
        {
            get => _salario.HorasTrabalhadas;
            set
            {
                if (_salario.HorasTrabalhadas != value)
                {
                    _salario.HorasTrabalhadas = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SalarioCalculado));
                }
            }
        }

        public decimal SalarioCalculado
        {
            get => _salarioCalculado;
            private set
            {
                if (_salarioCalculado != value)
                {
                    _salarioCalculado = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CalcularSalarioCommand { get; }

        public SalarioViewModel()
        {
            // RelayCommand espera Action<object?> e Func<object?, bool>
            CalcularSalarioCommand = new RelayCommand(
                param => CalcularSalario(param),
                param => PodeCalcular(param)
            );
        }

        private bool PodeCalcular(object? parameter)
        {
            return ValorHora > 0 && HorasTrabalhadas > 0;
        }

        private void CalcularSalario(object? parameter)
        {
            SalarioCalculado = _salario.CalcularSalario();
        }

        // Implementação do INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? nomePropriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }
    }
}
