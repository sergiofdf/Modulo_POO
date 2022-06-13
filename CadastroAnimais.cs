namespace Modulo_POO
{
    public class CadastroAnimais
    {
        public readonly static List<Animal> animais = new();
        private static void Cadastrar(Animal pet)
        {
            animais.Add(pet);
        }
        public static Animal PreencherFormularioCadastro()
        {
            Console.WriteLine("Cadastro de animal");
            Console.WriteLine("Qual o nome do animal?");
            string petNome = ConsoleSemVazio();
            Console.WriteLine("Qual a raça do animal?");
            string petRaca = ConsoleSemVazio();
            Console.WriteLine("Qual a cor do animal?");
            string petCor = ConsoleSemVazio();
            Console.WriteLine("Qual o peso do animal?");
            decimal petPeso = ConsoleDecimalPositivo();
            Console.WriteLine("Qual a data de nascimento do animal (dd-mm-aaaa)?");
            DateTime petNascimento = ConsoleData();
            Console.WriteLine("O animal é agressivo?");
            bool petAgressivo = ConsoleBool("Não é agressivo", "É agressivo");
            Console.WriteLine("Qual o sexo do animal?");
            char petSexo = ConsoleSexo();
            Console.WriteLine("O animal é castrado?");
            bool petCastrado = ConsoleBool("Não é castrado", "É castrado");
            Console.WriteLine("Qual a espécie do animal?");
            Especie petEspecie = ConsoleEspecie();
            Console.WriteLine("Qual o porte do animal?");
            Porte petPorte = ConsolePorte();

            Animal pet = new(petNome, petEspecie, petRaca, petCor, petPorte, petPeso, petNascimento, petAgressivo, petSexo, petCastrado);

            Console.WriteLine("O animal possui alguma doença ou alergia?");
            bool possuiAlergiaOuDoenca = ConsoleBool("Não possui", "Possui");
            if (possuiAlergiaOuDoenca)
            {
                Console.WriteLine("Digite as doenças e/ou alergias do animal.\nPara encerrar tecle enter com o campo vazio");
                ConsoleListaDoencas(pet);
            }
            Cadastrar(pet);
            return pet;
        }
        static string ConsoleSemVazio()
        {
            bool entradaValida = false;
            string entradaUsuario = "";
            while (!entradaValida)
            {
                entradaUsuario = Console.ReadLine();
                if (string.IsNullOrEmpty(entradaUsuario))
                {
                    Console.WriteLine("Informação Obrigatória. Digite algo...");
                }
                else
                {
                    entradaValida = true;
                }
            }
            return entradaUsuario;
        }
        static decimal ConsoleDecimalPositivo()
        {
            decimal numeroDigitado = 0;
            bool entradaDecimalValida = false;
            while (!entradaDecimalValida)
            {
                entradaDecimalValida = decimal.TryParse(ConsoleSemVazio(), out numeroDigitado);
                if (!entradaDecimalValida || numeroDigitado <= 0)
                {
                    Console.WriteLine("Digite um número válido...");
                    entradaDecimalValida = false;
                }
            }
            return numeroDigitado;
        }
        static DateTime ConsoleData()
        {
            DateTime dataDigitada = DateTime.MinValue;
            bool entradaDataValida = false;

            //Regex Data
            // \b([0-2]{0,1}[1-9]|(3)[0-1])(\/)(((0){0,1}[1-9])|((1)[0-2]))(\/)\d{4}\b

            while (!entradaDataValida)
            {
                entradaDataValida = DateTime.TryParse(ConsoleSemVazio(), out dataDigitada);
                if (!entradaDataValida)
                {
                    Console.WriteLine("Digite uma data válida no formato dd-mm-aaaa...");
                }
                if (dataDigitada >= DateTime.Now)
                {
                    Console.WriteLine("Data deve estar no passado...");
                    entradaDataValida = false;
                }
            }
            return dataDigitada;
        }
        static bool ConsoleBool(string opcaoFalse, string opcaoTrue)
        {
            Console.WriteLine($"0 - {opcaoFalse}");
            Console.WriteLine($"1 - {opcaoTrue}");

            bool numeroValido = false;
            int numeroEscolha = -1;

            while (!numeroValido)
            {
                string escolhaDigitada = Console.ReadLine();
                numeroValido = (int.TryParse(escolhaDigitada, out numeroEscolha) && numeroEscolha >= 0 && numeroEscolha <= 1);
                if (!numeroValido)
                {
                    Console.WriteLine("Digite 0 para false ou 1 para true ...");
                }
            }
            bool resposta = numeroEscolha == 0 ? false : true;
            return resposta;
        }
        static char ConsoleSexo()
        {
            Console.WriteLine("F - Fêmea");
            Console.WriteLine("M - Macho");
            char sexoDigitado = ' ';
            bool entradaSexoValida = false;
            while (!entradaSexoValida)
            {
                entradaSexoValida = char.TryParse(ConsoleSemVazio().ToUpper(), out sexoDigitado) && (sexoDigitado == 'F' || sexoDigitado == 'M');
                if (!entradaSexoValida)
                {
                    Console.WriteLine("Digite F para Fêmea ou M para Macho...");
                }
            }
            return sexoDigitado;
        }
        static Especie ConsoleEspecie()
        {
            int countEspecie = 0;
            foreach (var especie in Enum.GetValues(typeof(Especie)))
            {
                Console.WriteLine($"{countEspecie} - {especie}");
                countEspecie++;
            }
            int numeroDigitado = -1;
            bool entradaEnumValida = false;
            while (!entradaEnumValida)
            {
                entradaEnumValida = int.TryParse(ConsoleSemVazio(), out numeroDigitado) && numeroDigitado >= 0 && numeroDigitado < countEspecie;
                if (!entradaEnumValida)
                {
                    Console.WriteLine("Digite um número válido correspondente a Espécie...");
                }
            }
            return (Especie)Enum.Parse(typeof(Especie), numeroDigitado.ToString());
        }
        static Porte ConsolePorte()
        {
            int countPorte = 0;
            foreach (var porte in Enum.GetValues(typeof(Porte)))
            {
                Console.WriteLine($"{countPorte} - {porte}");
                countPorte++;
            }
            int numeroDigitado = -1;
            bool entradaEnumValida = false;
            while (!entradaEnumValida)
            {
                entradaEnumValida = int.TryParse(ConsoleSemVazio(), out numeroDigitado) && numeroDigitado >= 0 && numeroDigitado < countPorte;
                if (!entradaEnumValida)
                {
                    Console.WriteLine("Digite um número válido correspondente ao porte...");
                }
            }
            return (Porte)Enum.Parse(typeof(Porte), numeroDigitado.ToString());
        }
        static void ConsoleListaDoencas(Animal pet)
        {
            string doenca = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(doenca))
            {
                pet.AdicionarDoenca(doenca);
                doenca = Console.ReadLine();
            }
        }
    }
}
