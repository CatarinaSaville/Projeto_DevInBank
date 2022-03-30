using DevInBank.classes.Enums;
using DevInBank.classes.Models;
using System.Linq;

public class Extratos
{
    public static void Extrato(Conta conta, List<Transacao> transacoes)
    {
        Console.WriteLine();

        List<Transacao> transacoesDaConta = transacoes.Where(transacao => 
            transacao.ContaDestino.ContaID == conta.ContaID || 
            transacao.ContaOrigem.ContaID == conta.ContaID
        ).ToList();

        foreach (Transacao transacao in transacoesDaConta)
        {
            string tipoTransacao = transacao.ContaOrigem.ContaID == conta.ContaID ? "Enviada" : "Recebida";
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine($"Transferência {tipoTransacao}; Valor: {transacao.valor}; Data: { transacao.Data}");

            if (tipoTransacao == "Enviada")
                Console.WriteLine($"Para: {transacao.ContaDestino.NomeTitular}; CPF: {transacao.ContaDestino.CPF}");
            else
                Console.WriteLine($"De: {transacao.ContaOrigem.NomeTitular}; CPF: {transacao.ContaOrigem.CPF}");
            
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
