namespace Modulo_POO
{
    public class Caixa
    {
        public DateTime DataCaixa { get; private set; }
        public decimal Saldo { get; private set; }
        public void AbrirCaixa(decimal saldoInicial = 0)
        {
            DataCaixa = DateTime.Now;
            Saldo += saldoInicial;
        }
        public void Deposita(decimal valor)
        {
            Saldo += valor;
        }
        public void Saca(decimal valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
                Console.WriteLine($"O saldo atual é de R${Saldo}");
            }
        }
        public decimal CalcularTroco(decimal valorVenda, decimal valorCliente)
        {
            if (valorCliente < valorVenda)
            {
                Console.WriteLine("Valor inferior a venda. Pagamento não realizado!");
                return 0;
            }
            if (valorVenda < 0 || valorCliente < 0)
            {
                Console.WriteLine("Valor inválido.");
                return 0;
            }
            decimal troco = valorCliente - valorVenda;
            return troco;
        }
        public void DevolverTroco(decimal valorVenda, decimal valorCliente)
        {
            decimal troco = CalcularTroco(valorVenda, valorCliente);
            if (troco > Saldo)
            {
                Console.WriteLine("Troco indisponível!");
                return;
            }
            Deposita(valorVenda);
            Saca(troco);
        }
    }
}
