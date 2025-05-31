using System.Globalization;
using System.Text;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa>? Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public bool PossuiDesconto { get; set; } = false;

        public RegraDesconto RegraDesconto { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            Hospedes = hospedes;
            int totalHospedes = ObterQuantidadeHospedes();
            int capacidadeSuite = Suite.Capacidade;
            if (totalHospedes <= capacidadeSuite)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*                
                throw new Exception($"O a suite {Suite.TipoSuite} tem a capacidade de: {capacidadeSuite} o total de hospedes é: {totalHospedes} sendo maior que a capacidade!\n");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            int totalHospedes = Hospedes.Count;            
            return totalHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valorDiaria = Suite.ValorDiaria;
            decimal valor       = DiasReservados * valorDiaria;
            int diasDesconto    = RegraDesconto.DiasDesconto;
            decimal percentual  = RegraDesconto.PercentualDesconto;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= diasDesconto)
            {                
                valor = ValorComDesconto(valor);
                PossuiDesconto = true;
            }

            return valor;
        }

        public decimal calculaValorPorcentagem(decimal valor, decimal percentual)
        {

            return valor * (percentual / 100);
        }

        public decimal ValorComDesconto(decimal valor)
        {
            decimal percentual = RegraDesconto.PercentualDesconto;
            decimal valorDesconto   = calculaValorPorcentagem(valor, percentual);
            valor = valor - valorDesconto;
            return valor;
        }

        public string MensagemSobreDesconto()
        {
            string Mensagem = string.Empty;
            if (PossuiDesconto)
            {
                decimal valorDiaria = Suite.ValorDiaria;
                decimal valor = DiasReservados * valorDiaria;
                decimal valorDesconto = ValorComDesconto(valor);

                var cultura = new CultureInfo("pt-BR");
                StringBuilder sbuilder = new StringBuilder($"Os dias reservados são: {DiasReservados}, ");
                sbuilder.Append($"neles são aplicados {RegraDesconto.PercentualDesconto}% de desconto ");
                sbuilder.Append($"sendo assim o valor da diária seria {valorDiaria.ToString("C", cultura)} ");
                sbuilder.Append($"e {valor.ToString("C", cultura)} o valor total,mas com desconto ficou {valorDesconto.ToString("C", cultura)}!\n");
                Mensagem = sbuilder.ToString();
            }
            return Mensagem;
        }
    }
}