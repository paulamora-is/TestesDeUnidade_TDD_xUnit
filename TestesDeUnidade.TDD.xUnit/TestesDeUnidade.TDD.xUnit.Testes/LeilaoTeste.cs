using TestesDeUnidade.TDD.xUnit.Models;
using Xunit;

namespace TestesDeUnidade.TDD.xUnit.Testes
{
    public class LeilaoTeste
    {
        [Fact]
        public void TerminarPregao_UltimoLanceForMaiorValor()
        {
            //Arrange
            var leilao = new Leilao("Vincent van Gogh");
            var primeiroCliente = new Cliente("Maria", leilao);
            var segundoCliente = new Cliente("João", leilao);

            leilao.ReceberLance(primeiroCliente, 800);
            leilao.ReceberLance(segundoCliente, 900);
            leilao.ReceberLance(primeiroCliente, 1000);
            leilao.ReceberLance(segundoCliente, 1200);

            //Act
            leilao.TerminarPregao();

            //Assert
            var valorExperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;
            var clienteGanhador = segundoCliente;
            Assert.Equal(valorExperado, valorObtido);
            Assert.Equal(clienteGanhador, leilao.Ganhador.Cliente);
        }

        [Fact]
        public void TerminarPregao_QuandoExistirUnicoLance()
        {
            //Arrange
            var leilao = new Leilao("Vincent van Gogh");
            var unicoCliente = new Cliente("Maria", leilao);

            leilao.ReceberLance(unicoCliente, 800);

            //Act
            leilao.TerminarPregao();

            //Assert
            var valorExperado = 800;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorExperado, valorObtido);
        }

        [Fact]
        public void TerminarPregao_QuandoNãoExistirLances()
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
    }
}
