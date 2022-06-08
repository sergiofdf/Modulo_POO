namespace Modulo_POO
{
    internal class Animal
    {
        private Guid codigo = Guid.NewGuid();
        public string nome;
        public Especie especie;
        public string raca;
        public string cor;
        public Porte porte;
        public decimal peso;
        public DateTime nascimento;
        public List<string> doencasAlergias = new();
        public bool agressivo;
        public char sexo;
        public bool castrado;
        private DateTime dataCadastro = DateTime.Now;
        public Guid ObterCodigo()
        {
            return this.codigo;
        }
        public void RegistrarNascimento(int ano, int mes, int dia = 1)  // outra opção seria usar o int? que permite que seja null
        {
            this.nascimento = new DateTime(ano, mes, dia);
        }
        public DateTime ObterDataCadastro()
        {
            return this.dataCadastro;
        }
        public void AdicionarDoenca(string doenca)
        {
            this.doencasAlergias.Add(doenca);
        }
        public bool NecessidadesEspeciais()
        {
            return this.doencasAlergias.Any();
        }
        public int ObterIdade()
        {
            int idade = DateTime.Now.Year - nascimento.Year;
            if (DateTime.Now.DayOfYear < nascimento.DayOfYear)
            {
                idade--;
            }
            return idade;
        }
        public void ImprimirAnimal()
        {
            Console.Clear();
            Console.WriteLine("Imprimindo Pet");
            Console.WriteLine($"Código: {this.codigo}");
            Console.WriteLine($"Nome: {this.nome}");
            Console.WriteLine($"Espécie: {this.especie}");
            Console.WriteLine($"Raça: {this.raca}");
            Console.WriteLine($"Cor: {this.cor}");
            Console.WriteLine($"Porte: {this.porte}");
            Console.WriteLine($"Peso: {this.peso}");
            Console.WriteLine($"Data nasc.: {this.nascimento.ToShortDateString()}");
            Console.WriteLine($"Possui necessidades especiais: {this.NecessidadesEspeciais()}");
            if (this.NecessidadesEspeciais())
            {
                Console.WriteLine("Doenças e Alergias:");
                foreach (string doencaAlergia in this.doencasAlergias)
                {
                    Console.WriteLine(doencaAlergia);
                }
            }
            Console.WriteLine($"É agressivo:{this.agressivo}");
            Console.WriteLine($"Sexo: {this.sexo}");
            Console.WriteLine($"É castrado: {this.castrado}");
            Console.WriteLine($"Data de cadastro: {this.ObterDataCadastro()}");
            Console.WriteLine("");
        }
    }
}
