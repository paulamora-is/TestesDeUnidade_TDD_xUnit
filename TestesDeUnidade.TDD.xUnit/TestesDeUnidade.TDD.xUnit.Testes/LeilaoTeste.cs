using System.Linq;
using TestesDeUnidade.TDD.xUnit.Models;
using Xunit;

namespace TestesDeUnidade.TDD.xUnit.Testes
{
    public class LeilaoTeste
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 500, 1000, 900 })]
        [InlineData(800, new double[] { 800 })]
        public void TerminarPregao_RetornaMaiorValor_QuandoExistirNoMinimoUmLance(double valorEsperado,
            double[] valoresOfertados)
        {
            //Arrange
            var leilao = new Leilao("Vincent van Gogh");
            var cliente = new Cliente("cliente", leilao);

            foreach (var valor in valoresOfertados)
            {
                leilao.ReceberLance(cliente, valor);
            }

            //Act
            leilao.TerminarPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void TerminarPregao_RetornaZero_QuandoNaoExistirLances()
        {
            //Arrange
            var leilao = new Leilao("Vincent van Gogh");

            leilao.ReceberLance(null, 0);

            //Act
            leilao.TerminarPregao();

            //Assert
            var valorExperado = 0;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorExperado, valorObtido);
        }

        [Theory]
        [InlineData(3, new double[] { 800, 990, 1000 })]
        public void TerminarPregao_NaoAceitaNovosLances_QuandoLeilaoFinalizado(
            int lanceEsperado, double[] valoresOfertados)
        {
            //Arrange
            var leilao = new Leilao("Vincent van Gogh");
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
