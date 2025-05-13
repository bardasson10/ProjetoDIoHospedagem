namespace Hospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva(int diasReservados) {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                throw new Exception("Reserva não pode ser feita sem uma suite");
            }

            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException($"O número de hóspedes ({hospedes.Count}) excede a capacidade da suíte ({Suite.Capacidade}).");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = 0;
            decimal desconto = 0;
            if (DiasReservados > 0)
            {
                if (DiasReservados >= 10)
                {
                    desconto = Suite.ValorDiaria * DiasReservados * 0.1m; 
                    return valor = Suite.ValorDiaria * DiasReservados - desconto;
                }
                else
                {
                    return valor = Suite.ValorDiaria * DiasReservados;
                }
            }
            return valor;
        }
    }
}