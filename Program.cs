using Modulo_POO;
namespace LetsCodePOO
{
    internal class AdventureGame
    {
        static void Main(string[] args)
        {
            Animal pet = new Animal();
            Console.WriteLine("Cadastro de animal");
            Console.WriteLine("Qual o nome do animal?");
            pet.nome = Console.ReadLine();
            Console.WriteLine("Qual a raça do animal?");
            pet.raca = Console.ReadLine();
            Console.WriteLine("Qual a cor do animal?");
            pet.cor = Console.ReadLine();
            Console.WriteLine("Qual o peso do animal?");
            pet.peso = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Qual a data de nascimento do animal?");
            pet.nascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("O animal é agressivo?");
            pet.agressivo = bool.Parse(Console.ReadLine());
            Console.WriteLine("Qual o sexo do animal?");
            pet.sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("O animal é castrado?");
            pet.castrado = bool.Parse(Console.ReadLine());
            Console.WriteLine("Qual a espécie do animal?");
            int countEspecie = 0;
            foreach (var especie in Enum.GetValues(typeof(Especie)))
            {
                Console.WriteLine($"{countEspecie} - {especie}");
                countEspecie++;
            }
            pet.especie = (Especie)Enum.Parse(typeof(Especie), Console.ReadLine());

            Console.WriteLine("Qual o porte do animal?");
            int countPorte = 0;
            foreach (var porte in Enum.GetValues(typeof(Porte)))
            {
                Console.WriteLine($"{countPorte} - {porte}");
                countPorte++;
            }
            pet.porte = (Porte)Enum.Parse(typeof(Porte), Console.ReadLine());
            pet.ImprimirAnimal();
        }
    }
}