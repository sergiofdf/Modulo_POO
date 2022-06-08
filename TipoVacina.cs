namespace Modulo_POO
{
    internal class TipoVacina
    {
        private Guid IdUnicoVacina = Guid.NewGuid();
        public string nome;
        public int mesesDuracao;
        public List<Especie> especies;

        public Guid ObterIdUnicoVacina()
        {
            return IdUnicoVacina;
        }
    }
}
