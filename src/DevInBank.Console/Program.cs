using DevInBank.classes.Models;
using DevInBank.classes.Enums;
using DevInBank.Interfaces;

List<Conta> contas = new()
{
    new Conta
    {
        ContaID = "1",
        NomeTitular = "Sujeito1",
        CPF = 11111111111,
        Endereco = "Rua 1",
        RendaMensal = 1000,
        Agencia = Agencias.Florianopolis,
        Saldo = 5000,
        Tipo = Contas.Corrente,
        ChequeEspecial = 3000
    },
    new Conta
    {
        ContaID = "2",
        NomeTitular = "Sujeito2",
        CPF = 22222222222,
        Endereco = "Rua 2",
        RendaMensal = 2000,
        Agencia = Agencias.SaoJose,
        Saldo = 20000,
        Tipo = Contas.Poupanca
    },
    new Conta
    {
        ContaID = "3",
        NomeTitular = "Sujeito3",
        CPF = 33333333333,
        Endereco = "Rua 3",
        RendaMensal = 3000,
        Agencia = Agencias.Biguacu,
        Saldo = 30000,
        Tipo = Contas.Investimento
    },
    new Conta
    {
        ContaID = "4",
        NomeTitular = "Sujeito4",
        CPF = 44444444444,
        Endereco = "Rua 4",
        RendaMensal = 4000,
        Agencia = Agencias.Florianopolis,
        Saldo = 5000,
        Tipo = Contas.Corrente,
        ChequeEspecial = 3000
    },
    new Conta
    {
        ContaID = "5",
        NomeTitular = "Sujeito5",
        CPF = 55555555555,
        Endereco = "Rua 5",
        RendaMensal = 6000,
        Agencia = Agencias.SaoJose,
        Saldo = 50000,
        Tipo = Contas.Poupanca
    },
    new Conta
    {
        ContaID = "6",
        NomeTitular = "Sujeito6",
        CPF = 66666666666,
        Endereco = "Rua 6",
        RendaMensal = 8000,
        Agencia = Agencias.Biguacu,
        Saldo = 30000,
        Tipo = Contas.Investimento
    }
};

List<Transacao> transacoes = new()
{
     new Transacao{TransacaoID = "1", ContaOrigem = contas[0], ContaDestino = contas[1], valor = 1000, Data = new DateTime(01/01/2021) },
     new Transacao{TransacaoID = "2", ContaOrigem = contas[0], ContaDestino = contas[2], valor = 2000, Data = new DateTime(02/02/2021) },
     new Transacao{TransacaoID = "3", ContaOrigem = contas[2], ContaDestino = contas[0], valor = 1500, Data = new DateTime(01/03/2021) },
     new Transacao{TransacaoID = "4", ContaOrigem = contas[2], ContaDestino = contas[3], valor = 2500, Data = new DateTime(01/05/2021) },
     new Transacao{TransacaoID = "5", ContaOrigem = contas[3], ContaDestino = contas[0], valor = 3000, Data = new DateTime(01/06/2021) },
     new Transacao{TransacaoID = "6", ContaOrigem = contas[3], ContaDestino = contas[2], valor = 3500, Data = new DateTime(01/07/2021) }
};

Console.WriteLine("Bem vindo ao sistema DevInBank.");
Console.WriteLine();

bool sair = false;
bool contaSelecionada = false;
Conta contaEscolhida = new();

while (!sair && !contaSelecionada)
{
    Console.WriteLine("Escolha uma conta:");
    Console.WriteLine();
    int option = 0;

    foreach (Conta conta in contas)
    {
        Console.WriteLine($"{option + 1} - Conta: {conta.ContaID}, Titular: {conta.NomeTitular}, CPF: {conta.CPF}, Tipo: {conta.Tipo}");
        option++;
    }
    Console.WriteLine("0 - Sair.");
    Console.WriteLine();

    int opcaoEscolhida = InputHelper.ObterValorInt();

    if (opcaoEscolhida == 0){
       sair = true;
    }
    else if(opcaoEscolhida <= contas.Count){
        contaSelecionada = true;        
        contaEscolhida = contas[opcaoEscolhida - 1];
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine($"Escolha uma opção entre 1 e {contas.Count}.");
        Console.WriteLine();
    }
}

while (!sair)
{
    Console.WriteLine();
    Console.WriteLine($"Conta: { contaEscolhida.ContaID}, Titular: { contaEscolhida.NomeTitular}, CPF: {contaEscolhida.CPF}, Endereço: {contaEscolhida.Endereco}, ");
    Console.WriteLine($"Renda Mensal: {contaEscolhida.RendaMensal}, Agencia: {contaEscolhida.Agencia}, Tipo: {contaEscolhida.Tipo}");
    Console.WriteLine();
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
            Saques.Sacar(contaEscolhida);
            break;

        case 2:
            Console.WriteLine();
            Console.WriteLine($"{menuSelecionado}: Depositar:");
            Console.WriteLine();
            Depositos.Depositar(contaEscolhida);
            break;
    
        case 3:
            Console.WriteLine($"{menuSelecionado}: Saldo:");
            Console.WriteLine();
            Console.WriteLine($"O valor do seu saldo é: {contaEscolhida.Saldo}");
            Console.WriteLine();
            break;

        case 4:
            Console.WriteLine();
            Console.WriteLine($"{menuSelecionado}: Extrato:");
            Extratos.Extrato(contaEscolhida, transacoes);
            break;

        case 5:
            Console.WriteLine();
            Console.WriteLine($"{menuSelecionado}: Tranferências:");
            Transferencias.Transferencia(contaEscolhida, transacoes);
            break;

        case 6:
            Console.WriteLine();
            Console.WriteLine($"{menuSelecionado}: Dados Cadastrais:");
            DadosCadastrais.AlterarDados(contaEscolhida, ref contas);
            break;

        // SAIR
        case 7:
            sair = true;
            break;

        default:
            Console.WriteLine("Escolha uma opção entre 1 e 7.");
            break;
    }
}