namespace TestesDeUnidade.TDD.xUnit.Models
{
    public class Cliente
    {
        public Cliente(string nome, Leilao leilao)
        {
            Nome = nome;
            Leilao = leilao;
        }

        public string Nome { get; }
        public Leilao Leilao { get; }
    }
}
