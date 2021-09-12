namespace TestesDeUnidade.TDD.xUnit.Models
{
    public class Lance
    {
        public Lance(Cliente cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
        }

        public Cliente Cliente { get; }
        public double Valor { get; }
    }
}
