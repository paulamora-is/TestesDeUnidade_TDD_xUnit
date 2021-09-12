using System.Linq;
using TestesDeUnidade.TDD.xUnit.Models;
using Xunit;

namespace TestesDeUnidade.TDD.xUnit.Testes
{
    public class LeilaoTeste
    {
        [Theory]
        [InlineData(3, new double[] { 800, 990, 1000 })]
        [InlineData(4, new double[] { 800, 990, 1000, 1200 })]
        public void ReceberLance_NaoAceitaNovosLances_QuandoLeilaoFinalizado(
            int lanceEsperado, double[] valoresOfertados)
        {
            //Arrange

            var leilao = new Leilao("Vincent van Gogh");
            leilao.IniciarPregao();

            var cliente = new Cliente("cliente", leilao);

            foreach (var valor in valoresOfertados)
            {
                leilao.ReceberLance(cliente, valor);
            }

            leilao.TerminarPregao();

            //Act
            leilao.ReceberLance(cliente, 1000);

            //Assert
            var valorExperado = lanceEsperado;
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(valorExperado, valorObtido);
        }
    }
}
