namespace Modulo_POO
{
    internal class Animal
    {
        private Guid Codigo
        {
            get
            {
                return Guid.NewGuid();
            }
            set
            {
            }
        }
        public string Nome { get; set; }
        public Especie Especie { get; set; }
        public string Raca { get; set; }
        public string Cor { get; set; }
        public Porte Porte { get; set; }
        public decimal Peso { get; set; }
        public int Idade
        {
            get
            {
                return ObterIdade();
            }
        }
        public DateTime Nascimento { get; set; }
        public List<string> DoencasAlergias { get; set; } = new();
        public bool Agressivo { get; set; }
        public char Sexo { get; set; }
        public bool Castrado { get; set; }
        private DateTime DataCadastro
        {
            get
            {
                return DateTime.Now;
            }
            set
            {

            }
        }
        public Guid ObterCodigo()
        {
            return this.Codigo;
        }
        public void RegistrarNascimento(int ano, int mes, int dia = 1)  // outra opção seria usar o int? que permite que seja null
        {
            this.Nascimento = new DateTime(ano, mes, dia);
        }
        public DateTime ObterDataCadastro()
        {
            return this.DataCadastro;
        }
        public void AdicionarDoenca(string doenca)
        {
            this.DoencasAlergias.Add(doenca);
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
            Console.WriteLine($"Código: {this.Codigo}");
            Console.WriteLine($"Nome: {this.Nome}");
            Console.WriteLine($"Espécie: {this.Especie}");
            Console.WriteLine($"Raça: {this.Raca}");
            Console.WriteLine($"Cor: {this.Cor}");
            Console.WriteLine($"Porte: {this.Porte}");
            Console.WriteLine($"Peso: {this.Peso}");
            Console.WriteLine($"Idade: {this.Idade} ano(s)");
            Console.WriteLine($"Possui necessidades especiais: {this.NecessidadesEspeciais()}");
            if (this.NecessidadesEspeciais())
            {
                Console.WriteLine("\nDoenças e Alergias:");
                foreach (string doencaAlergia in this.DoencasAlergias)
                {
                    Console.WriteLine(doencaAlergia);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"É agressivo: {this.Agressivo}");
            Console.WriteLine($"Sexo: {this.Sexo}");
            Console.WriteLine($"É castrado: {this.Castrado}");
            Console.WriteLine($"Data de cadastro: {this.ObterDataCadastro()}");
            Console.WriteLine("");
        }
    }
}
