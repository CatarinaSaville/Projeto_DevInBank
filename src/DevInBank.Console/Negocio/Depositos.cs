using DevInBank.classes.Enums;
using DevInBank.classes.Models;

public class Depositos
{
    public static void Depositar(Conta conta)
    {
           //MessageBox.Show("Operação realizada com sucesso");
            Console.WriteLine();
            Console.WriteLine($"Entre com o Valor do Deposito (Ex.: R$ 150.56):");
            Console.WriteLine();
            Console.Write("R$ ");

            decimal valor = InputHelper.ObterValorDecimal();
        //var  movimentacao  + sequ = valorDecimal ;
        //sequencia += Saquencia
        //movimentacao1 = valor


        if (valor > 0)
        {
            conta.Saldo += valor;

            Console.WriteLine();
            Console.WriteLine($"Deposito Realizado com Sucesso!");
            Console.WriteLine($"----------------------------");
            Console.WriteLine($"Novo saldo => R$ {conta.Saldo}");
        }
        else
        {
            Console.WriteLine($"Deposito não realizado!");
            Console.WriteLine($"O valor do Deposito deve ser maior que zero");
            Console.WriteLine();
        }
        }
       // catch (Exception e)
       //{
       //  throw new Exception($"Erro ao efetuar Saque - {e.Message}");
   
}
