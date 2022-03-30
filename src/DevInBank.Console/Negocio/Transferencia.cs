using DevInBank.classes.Enums;
using DevInBank.classes.Models;
using System.Linq;
public class Transferencias
{
    public static void Transferencia(Conta conta, List<Transacao> transacoes)
    {
        try
        {            
            Console.WriteLine($"Saldo disponivel: R$ {conta.Saldo}");
            bool isContaConrrente = conta.Tipo == Contas.Corrente;
            if (isContaConrrente) { 
                Console.WriteLine($"Valor disponível do Cheque especial: R$ {conta.ChequeEspecial}");
                Console.WriteLine($"Valor toal disponível para transferencia (Saldo + Cheque Especial): R$ {conta.Saldo + conta.ChequeEspecial}");
            }

            Console.WriteLine();
            Console.WriteLine($"Entre com o Valor da Tranferencia (Ex.: R$ 150.56):");
            Console.WriteLine();
            Console.Write("R$ ");

            decimal valor = InputHelper.ObterValorDecimal();

            Console.WriteLine($"Digite o CPF do destinatario");

            long valorCpf = InputHelper.ObterCpfValido(); 
            Console.WriteLine();

            if (valor > 0 && valor <= conta.Saldo)
            {
                bool chequeEspecialAtualizado = false;
                if (conta.Saldo >= valor) 
                    conta.Saldo -= valor ;
                else if (conta.Tipo == Contas.Corrente && (conta.Saldo + conta.ChequeEspecial >= valor))
                {
                    conta.ChequeEspecial -= valor - conta.Saldo;
                    chequeEspecialAtualizado = true;
                    conta.Saldo = 0;
                }
                               
                Console.WriteLine($"----------------------------");
                Console.WriteLine($"Novo saldo => R$ {conta.Saldo}");
                
                if (chequeEspecialAtualizado)
                    Console.WriteLine($"Novo saldo do Cheque Especial => R$ {conta.ChequeEspecial}");
                
                Console.WriteLine();

                //pegar a lista com todas as Contas dar loop nela
                //   verificar nela if (o valor dessa conta que voce estar percorrendo)
                //  elif o cpf é == ao cpf digitado
                //  passa o saldo para ele

                List<Transacao> transacoesDaConta = transacoes.Where(transacao =>
                transacao.ContaDestino.CPF == valorCpf ||
                transacao.ContaDestino.ContaID == conta.ContaID
                ).ToList();

                foreach (Transacao transacao in transacoesDaConta)
                {
                    string tipoTransacao = transacao.ContaDestino.CPF == valorCpf ? "Transferencia realizada" : "Cpf não encontrado";
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Console.WriteLine($"Transferência {tipoTransacao}; Valor: {transacao.valor}; Data: { transacao.Data}");

                    if (tipoTransacao == "Transferencia realizada")
                        Console.WriteLine($"De: {transacao.ContaOrigem.NomeTitular}; para CPF: {transacao.ContaDestino.CPF}");
                    else
                        Console.WriteLine($"{transacao.ContaOrigem.NomeTitular};Não foi possivel realizar a transferencia para o CPF: {transacao.valor}");
                }
             }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Transferencia não realizada!");
                Console.WriteLine($"O valor da transferencia deve ser maior que zero e menor que o valor total disponível");
                Console.WriteLine();
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao efetuar transferencia - {e.Message}");
        }
    }
}

