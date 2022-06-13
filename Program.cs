namespace Modulo_POO
{
    internal class LetsPetMain
    {
        static void Main(string[] args)
        {
            Animal pet = CadastroAnimais.PreencherFormularioCadastro();
            pet.ImprimirAnimal();
            Animal pet2 = CadastroAnimais.PreencherFormularioCadastro();
            pet2.ImprimirAnimal();

            //Caixa caixaDoDia = new Caixa();
            //caixaDoDia.AbrirCaixa();

            //Console.WriteLine($"Caixa Aberto em { caixaDoDia.DataCaixa }");

            //Console.WriteLine(caixaDoDia.Saldo);

            //caixaDoDia.Deposita(10);

            //Console.WriteLine(caixaDoDia.Saldo);

            //caixaDoDia.Deposita(50);

            //Console.WriteLine(caixaDoDia.Saldo);

            //caixaDoDia.Saca(20);

            //Console.WriteLine(caixaDoDia.Saldo);

            //caixaDoDia.DevolverTroco(30, 50);
            //caixaDoDia.DevolverTroco(10, 80);

            //caixaDoDia.DevolverTroco(20, 100);

        }
    }
}