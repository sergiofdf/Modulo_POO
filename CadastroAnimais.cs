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
            Console.WriteLine("O animal já tomou alguma vacina que gostaria de cadastrar?");
            bool possuiVacina = ConsoleBool("Não tomou vacina ou não desejo cadastrar", "Sim, tomou vacina e gostaria de cadastrar");
            if (possuiVacina)
            {
                Console.WriteLine("Digite as informações das vacinas para cadastro.\n");
                RegistrarVacinas(pet);
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
        static void RegistrarVacinas(Animal pet)
        {
            string fimCadastro = "1";
            while (fimCadastro != "0")
            {
                Console.WriteLine("A vacina que deseja cadastrar é:");
                Console.WriteLine("1 - Antirrabica");
                Console.WriteLine("2 - V10");
                Console.WriteLine("3 - V4");
                Console.WriteLine("4 - Outra");
                int vacina = ConsoleIntIntervalo(1, 4);
                Console.WriteLine("Qual a data de aplicação?");
                DateTime dataAplicacao = ConsoleData();
                Console.WriteLine("Qual o lote da vacina?");
                string lote = Console.ReadLine();
                if (vacina == 1)
                {
                    Vacina vacinaRaiva = new(vacina, pet.Codigo, dataAplicacao, lote, "Antirrabica", 12);
                    pet.CarteiraVacinacao.Add(vacinaRaiva);
                }
                else if (vacina == 2)
                {
                    if (pet.Especie == Especie.Gato)
                    {
                        Console.WriteLine("V10 não é compatível com gato!");
                        continue;
                    }
                    Vacina vacinaV10 = new(vacina, pet.Codigo, dataAplicacao, lote, "V10", 12);
                    pet.CarteiraVacinacao.Add(vacinaV10);
                }
                else if (vacina == 3)
                {
                    if (pet.Especie == Especie.Cachorro)
                    {
                        Console.WriteLine("V4 não é compatível com cachorro!");
                        continue;
                    }
                    Vacina vacinaV4 = new(vacina, pet.Codigo, dataAplicacao, lote, "V4", 12);
                    pet.CarteiraVacinacao.Add(vacinaV4);
                }
                else if (vacina == 4)
                {
                    Console.WriteLine("Qual o nome da vacina?");
                    string nomeVacina = ConsoleSemVazio();
                    Console.WriteLine("Qual a duração em meses da vacina?");
                    int duracaoVacina = ConsoleIntIntervalo(1, 9999);
                    Vacina outrasVacinas = new(vacina, pet.Codigo, dataAplicacao, lote, nomeVacina, duracaoVacina);
                    pet.CarteiraVacinacao.Add(outrasVacinas);
                }
                Console.WriteLine("Deseja cadastrar outra vacina?  (0 - Não / 1 - Sim)");
                fimCadastro = Console.ReadLine();
                Console.Clear();
            }
        }
        static int ConsoleIntIntervalo(int limteInferior, int limiteSuperior)
        {
            int numeroDigitado = 0;
            bool entradaIntlValida = false;
            while (!entradaIntlValida)
            {
                entradaIntlValida = int.TryParse(ConsoleSemVazio(), out numeroDigitado);
                if (!entradaIntlValida || numeroDigitado < limteInferior || numeroDigitado > limiteSuperior)
                {
                    Console.WriteLine("Digite um número válido...");
                    entradaIntlValida = false;
                }
            }
            return numeroDigitado;
        }
    }
}
