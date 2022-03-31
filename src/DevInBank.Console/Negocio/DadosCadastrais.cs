using DevInBank.classes.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using DevInBank.classes.Enums;

public class DadosCadastrais
{
    public static void AlterarDados(Conta conta, ref List<Conta> contas)
    {
        Console.WriteLine();
        Console.WriteLine($"Conta: { conta.ContaID}, Titular: { conta.NomeTitular}, CPF: {conta.CPF}, Endereço: {conta.Endereco}, ");
        Console.WriteLine($"Renda Mensal: {conta.RendaMensal}, Agencia: {conta.Agencia}, Tipo: {conta.Tipo}");
        Console.WriteLine();
        Console.WriteLine("Qual dado deseja alterar");
        Console.WriteLine("1 - Nome do titular.");
        Console.WriteLine("2 - Endereço.");
        Console.WriteLine("3 - Renda Mensal.");
        Console.WriteLine("4 - Agencia.");
        Console.WriteLine("5 - Tipo.");
        Console.WriteLine();

        int itemSelecionado = InputHelper.ObterValorInt();

        switch (itemSelecionado)
        {
            case 1: 
                Console.WriteLine();
                Console.WriteLine("Insira um novo nome: ");
                Console.WriteLine();
                string novoNome = Console.ReadLine();
                contas.First(c => c.ContaID == conta.ContaID).NomeTitular = novoNome;
                conta.NomeTitular = novoNome;
                break;
            case 2:
                Console.WriteLine();
                Console.WriteLine("Insira um novo endereço: ");
                Console.WriteLine();
                string novoEndereco = Console.ReadLine();
                contas.First(c => c.ContaID == conta.ContaID).Endereco = novoEndereco;
                conta.Endereco = novoEndereco;
                break;
            case 3:
                Console.WriteLine();
                Console.WriteLine("Insira uma nova renda mensal: ");
                Console.WriteLine();
                decimal novaRenda = InputHelper.ObterValorDecimal();
                contas.First(c => c.ContaID == conta.ContaID).RendaMensal = novaRenda;
                conta.RendaMensal = novaRenda;
                break;
            case 4:
                Console.WriteLine();
                Console.WriteLine("Insira uma nova agencia: ");
                Console.WriteLine();

                bool opcaoValida = false;
                Agencias novaAgencia = Agencias.Florianopolis;
                while (!opcaoValida)
                {
                    Console.WriteLine($"1 - {Agencias.Florianopolis}.");
                    Console.WriteLine($"2 - {Agencias.SaoJose}.");
                    Console.WriteLine($"3 - {Agencias.Biguacu}.");
                    Console.WriteLine();
                    int opcaoSelecionada = InputHelper.ObterValorInt();
                    switch (opcaoSelecionada)
                    {
                        case 1:
                            novaAgencia = Agencias.Florianopolis;
                            opcaoValida = true;
                            break;
                        case 2:
                            novaAgencia = Agencias.SaoJose;
                            opcaoValida = true;
                            break;
                        case 3:
                            novaAgencia = Agencias.Biguacu;
                            opcaoValida = true;
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Escolha uma opção entre 1 e 3.");
                            Console.WriteLine();
                            break;
                    }
                }
                contas.First(c => c.ContaID == conta.ContaID).Agencia = novaAgencia;
                conta.Agencia = novaAgencia;
                break;
            case 5:
                Console.WriteLine();
                Console.WriteLine("Insira o tipo de conta: ");
                Console.WriteLine();

                bool opcValida = false;
                Contas novoTipo = Contas.Corrente;

                while (!opcValida)
                {
                    Console.WriteLine($"1 - {Contas.Corrente}.");
                    Console.WriteLine($"2 - {Contas.Poupanca}.");
                    Console.WriteLine($"3 - {Contas.Investimento}.");
                    Console.WriteLine();
                    int opcaoSelecionada = InputHelper.ObterValorInt();

                    switch (opcaoSelecionada)
                    {
                        case 1:
                            novoTipo = Contas.Corrente;
                            opcValida = true;
                            break;
                        case 2:
                            novoTipo = Contas.Poupanca;
                            opcValida = true;
                            break;
                        case 3:
                            novoTipo = Contas.Investimento;
                            opcValida = true;
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Escolha uma opção entre 1 e 3.");
                            Console.WriteLine();
                            break;
                    }
                }
                contas.First(c => c.ContaID == conta.ContaID).Tipo = novoTipo;
                conta.Tipo = novoTipo;
                break;
            default:
                Console.WriteLine();
                Console.WriteLine("Escolha uma opção entre 1 e 5.");
                Console.WriteLine();
                break;
        }
    }
}