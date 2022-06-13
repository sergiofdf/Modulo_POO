namespace Modulo_POO
{
    public class Vacina
    {
        public int IdVacina { get; }
        public int IdAnimal { get; }
        public TipoVacina TipoVacina { get; }
        public DateTime DataAplicacao { get; }
        public string Lote { get; }
        public DateTime DataRegistro { get; }

        public Vacina(int idVacina, int codigoAnimal, DateTime dataAplicacao, string lote, string nome, int mesesDuracao)
        {
            IdVacina = idVacina;
            IdAnimal = codigoAnimal;
            DataAplicacao = dataAplicacao;
            Lote = lote;
            DataRegistro = DateTime.Now;
            TipoVacina = new(nome, mesesDuracao);
        }
    }
}
