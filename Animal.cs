namespace Modulo_POO
{
    public class Animal
    {
        private static int iteradorCodigo = 1;
        public int Codigo { get; }
        public string Nome { get; set; }
        public Especie Especie { get; set; }
        public string Raca { get; set; }
        public string Cor { get; set; }
        public Porte Porte { get; set; }
        public decimal Peso { get; set; }
        public int Idade { get; }
        public DateTime Nascimento { get; set; }
        public List<string> DoencasAlergias { get; set; } = new();
        public bool Agressivo { get; set; }
        public char Sexo { get; set; }
        public bool Castrado { get; set; }
        private DateTime DataCadastro { get; }
        //Construtor
        public Animal(string nome, Especie especie, string raca, string cor, Porte porte, decimal peso, DateTime nascimento, bool agressivo, char sexo, bool castrado)
        {
            Codigo = iteradorCodigo;
            iteradorCodigo++;
            Nome = nome;
            Especie = especie;
            Raca = raca;
            Cor = cor;
            Porte = porte;
            Peso = peso;
            Nascimento = nascimento;
            Agressivo = agressivo;
            Sexo = sexo;
            Castrado = castrado;
            DataCadastro = DateTime.Now;
            Idade = ObterIdade();
        }
        //Métodos
        public void AdicionarDoenca(string doenca)
        {
            DoencasAlergias.Add(doenca);
        }
        public bool NecessidadesEspeciais()
        {
            return this.DoencasAlergias.Any();
        }
        public int ObterIdade()
        {
            int idade = DateTime.Now.Year - Nascimento.Year;
            if (DateTime.Now.DayOfYear < Nascimento.DayOfYear)
            {
                idade--;
            }
            return idade;
        }
        public void ImprimirAnimal()
        {
            Console.Clear();
            Console.WriteLine("Imprimindo Pet");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Espécie: {Especie}");
            Console.WriteLine($"Raça: {Raca}");
            Console.WriteLine($"Cor: {Cor}");
            Console.WriteLine($"Porte: {Porte}");
            Console.WriteLine($"Peso: {Peso}");
            Console.WriteLine($"Idade: {Idade} ano(s)");
            Console.WriteLine($"Possui necessidades especiais: {NecessidadesEspeciais()}");
            if (this.NecessidadesEspeciais())
            {
                Console.WriteLine("\nDoenças e Alergias:");
                foreach (string doencaAlergia in DoencasAlergias)
                {
                    Console.WriteLine(doencaAlergia);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"É agressivo: {Agressivo}");
            Console.WriteLine($"Sexo: {Sexo}");
            Console.WriteLine($"É castrado: {Castrado}");
            Console.WriteLine($"Data de cadastro: {DataCadastro}");
            Console.WriteLine("");
        }
    }
}
