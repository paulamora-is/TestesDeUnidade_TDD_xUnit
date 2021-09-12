using System.Collections.Generic;
using System.Linq;

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
        }

        public string Peca { get; }
        public Lance Ganhador { get; private set; }

        public void ReceberLance(Cliente cliente, double valor)
        {
            _lances.Add(new Lance(cliente, valor));
        }

        public void IniciarPregao()
        {
        }

        public void TerminarPregao()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(l => l.Valor)
                .LastOrDefault();
        }
    }
}