using DevInBank.classes.Enums;
using DevInBank.classes.Models;

public class Saques
{
    public static void Sacar(Conta conta)
    {
        try
        {            
            Console.WriteLine($"Saldo disponivel: R$ {conta.Saldo}");
            bool isContaConrrente = conta.Tipo == Contas.Corrente;
            if (isContaConrrente) { 
                Console.WriteLine($"Valor disponível do Cheque especial: R$ {conta.ChequeEspecial}");
                Console.WriteLine($"Valor total disponível para saque (Saldo + Cheque Especial): R$ {conta.Saldo + conta.ChequeEspecial}");
            }

            Console.WriteLine();
            Console.WriteLine($"Entre com o Valor do Saque (Ex.: R$ 150.56):");
            Console.WriteLine();
            Console.Write("R$ ");

            decimal valor = InputHelper.ObterValorDecimal();

            if (valor > 0 && valor <= conta.Saldo + Convert.ToDecimal(conta.ChequeEspecial))
            {
                bool chequeEspecialAtualizado = false;
                if (conta.Saldo >= valor) 
                    conta.Saldo -= valor;
                else if (conta.Tipo == Contas.Corrente && (conta.Saldo + conta.ChequeEspecial >= valor))
                {
                    conta.ChequeEspecial -= valor - conta.Saldo;
                    chequeEspecialAtualizado = true;
                    conta.Saldo = 0;
                }
                
                Console.WriteLine();
                Console.WriteLine($"Saque Realizado com Sucesso!");
                Console.WriteLine($"----------------------------");
                Console.WriteLine($"Novo saldo => R$ {conta.Saldo}");
                
                if (chequeEspecialAtualizado)
                    Console.WriteLine($"Novo saldo do Cheque Especial => R$ {conta.ChequeEspecial}");
                
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Saque não realizado!");
                Console.WriteLine($"O valor do saque deve ser maior que zero e menor que o valor total disponível para saques");
                Console.WriteLine();
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao efetuar Saque - {e.Message}");
        }
    }
}

