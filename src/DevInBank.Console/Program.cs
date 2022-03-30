using DevInBank.classes.Models;
using DevInBank.classes.Enums;
using DevInBank.Interfaces;
using DevInBank.Interfaces;

Conta contaCorrente = new Conta
{
    ContaID = "1",
    NomeTitular = "Sujeito1",
    CPF = 111111111-11,
    Endereco = "Rua 1",
    RendaMensal = 1000,
    Agencia = Agencias.Florianopolis,
    Saldo = 5000,
    Tipo = Contas.Corrente,
    ChequeEspecial = 3000
};
Conta contaPoupanca = new Conta
{
    ContaID = "2",
    NomeTitular = "Sujeito2",

    CPF = 22222222222,
    Endereco = "Rua 2",
    RendaMensal = 2000,
    Agencia = Agencias.SaoJose,
    Saldo = 20000,
    Tipo = Contas.Poupanca
};
Conta contaInvestimento = new Conta
{
    ContaID = "3",
    NomeTitular = "Sujeito3",
    CPF = 33333333333,
    Endereco = "Rua 3",
    RendaMensal = 3000,
    Agencia = Agencias.Biguacu,
    Saldo = 30000,
    Tipo = Contas.Investimento
};

List<Transacao> transacoes = new List<Transacao>();
transacoes.AddRange(
    new[] {
     new Transacao{TransacaoID = "1", ContaOrigem = contaCorrente, ContaDestino = contaPoupanca, valor = 1000, Data = new DateTime(01/01/2021) },
     new Transacao{TransacaoID = "2", ContaOrigem = contaCorrente, ContaDestino = contaInvestimento, valor = 2000, Data = new DateTime(02/02/2021) },
     new Transacao{TransacaoID = "3", ContaOrigem = contaPoupanca, ContaDestino = contaCorrente, valor = 1500, Data = new DateTime(01/03/2021) },
     new Transacao{TransacaoID = "4", ContaOrigem = contaPoupanca, ContaDestino = contaInvestimento, valor = 2500, Data = new DateTime(01/05/2021) },
     new Transacao{TransacaoID = "5", ContaOrigem = contaInvestimento, ContaDestino = contaCorrente, valor = 3000, Data = new DateTime(01/06/2021) },
     new Transacao{TransacaoID = "6", ContaOrigem = contaInvestimento, ContaDestino = contaPoupanca, valor = 3500, Data = new DateTime(01/07/2021) },

    }
);

List<Transacao> transferencia = new List<Transacao>();
transferencia.AddRange(
    new[] {
     new Transacao{TransacaoID = "1", ContaOrigem = contaCorrente, ContaDestino = contaPoupanca, valor = 1000, Data = new DateTime(01/01/2021) },
     new Transacao{TransacaoID = "2", ContaOrigem = contaCorrente, ContaDestino = contaInvestimento, valor = 2000, Data = new DateTime(02/02/2021) },
     new Transacao{TransacaoID = "3", ContaOrigem = contaPoupanca, ContaDestino = contaCorrente, valor = 1500, Data = new DateTime(01/03/2021) },
     new Transacao{TransacaoID = "4", ContaOrigem = contaPoupanca, ContaDestino = contaInvestimento, valor = 2500, Data = new DateTime(01/05/2021) },
     new Transacao{TransacaoID = "5", ContaOrigem = contaInvestimento, ContaDestino = contaCorrente, valor = 3000, Data = new DateTime(01/06/2021) },
     new Transacao{TransacaoID = "6", ContaOrigem = contaInvestimento, ContaDestino = contaPoupanca, valor = 3500, Data = new DateTime(01/07/2021) },

    }
);

Conta contaEscolida = contaCorrente;

Console.WriteLine("Bem vindo ao sistema DevInBank.");
Console.WriteLine();

var sair = false;

while (!sair)
 {
    Console.WriteLine("Escolha uma opção do menu:");
    Console.WriteLine("1 - Saques.");
    Console.WriteLine("2 - Depositar.");
    Console.WriteLine("3 - Saldo.");
    Console.WriteLine("4 - Extrato.");
    Console.WriteLine("5 - Transferências.");
    Console.WriteLine("6 - Dados Cadastrais.");
    Console.WriteLine("7 - Sair.");
    Console.WriteLine();

    int menuSelecionado = InputHelper.ObterValorInt();


    switch (menuSelecionado)
    {
        case 1:      
            Console.WriteLine();
            Console.WriteLine($"{menuSelecionado}: Saques:");
            Console.WriteLine();
            Saques.Sacar(contaEscolida);
            break;

        case 2:
            Console.WriteLine();
            Console.WriteLine($"{menuSelecionado}: Depositar:");
            Console.WriteLine();
            Depositos.Depositar(contaEscolida);
            break;
    
        case 3:
            Console.WriteLine($"{menuSelecionado}: Saldo:");
            Console.WriteLine();
            Console.WriteLine($"O valor do seu saldo é: {contaEscolida.Saldo}");
            Console.WriteLine();
            break;

        case 4:
            Console.WriteLine();
            Console.WriteLine($"{menuSelecionado}: Extrato:");
            Extratos.Extrato(contaEscolida, transacoes);
            break;

        case 5:
            Console.WriteLine();
            Console.WriteLine($"{menuSelecionado}: Tranferências:");
            Transferencias.Transferencia(contaEscolida, transacoes);
            break;

        case 6:
            Console.WriteLine($"{menuSelecionado}: Dados Cadastrais:");
            break;

        // SAIR
        case 7:
            sair = true;
            break;

        default:
            Console.WriteLine("Escolha uma opção entre 1 e 7.");
            sair = true;
            break;
    }
}