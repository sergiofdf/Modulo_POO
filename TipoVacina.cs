namespace Modulo_POO
{
    public class TipoVacina
    {
        public Guid IdUnicoVacina { get; }
        public string Nome { get; set; }
        public int MesesDuracao { get; set; }
        public List<Especie> Especies;

        public TipoVacina(string nome, int mesesDuracao, List<Especie> especieis)
        {
            IdUnicoVacina = Guid.NewGuid();
            Nome = nome;
            MesesDuracao = mesesDuracao;
            Especies = especieis;
        }
    }
}
