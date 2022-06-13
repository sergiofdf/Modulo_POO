namespace Modulo_POO
{
    public class TipoVacina
    {
        public Guid IdUnicoVacina { get; }
        public string Nome { get; }
        public int MesesDuracao { get; }

        public TipoVacina(string nome, int mesesDuracao)
        {
            IdUnicoVacina = Guid.NewGuid();
            Nome = nome;
            MesesDuracao = mesesDuracao;
        }
    }
}
