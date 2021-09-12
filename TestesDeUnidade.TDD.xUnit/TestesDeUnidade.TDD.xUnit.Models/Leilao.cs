using System.Collections.Generic;
using System.Linq;
using TestesDeUnidade.TDD.xUnit.Models.Enum;

namespace TestesDeUnidade.TDD.xUnit.Models
{
    public class Leilao
    {
        private readonly IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
        }

        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        public void ReceberLance(Cliente cliente, double valor)
        {
            if (Estado == EstadoLeilao.LeilaoEmAndamento)
            {
                _lances.Add(new Lance(cliente, valor));
            }
        }

        public void IniciarPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminarPregao()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(l => l.Valor)
                .LastOrDefault();

            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}