
using sistema_pagamentos_loja.Entity;
using System.Runtime.Intrinsics.X86;

List<Venda> vendas = new List<Venda>();

int opcao;

do
{
    Console.Write(
        "\n================================\n" +
                "\tSISTEMA DE VENDAS" +
        "\n================================\n" +

        "\n1 - Cadastrar venda" +
        "\n2 - Listar vendas" +
        "\n3 - Realizar pagamento" +
        "\n0 - Sair\n" +

        "\nOpção: "
    );

    if(!int.TryParse(Console.ReadLine(), out opcao))
    {
        Console.WriteLine("\nEntrada inválida, insira um número inteiro!");
        continue;
    }
    
    switch (opcao)
    {
        case 1:

            Console.WriteLine("\n=========== Cadastro ===========\n");

            Console.Write("Número: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("\nEntrada inválida, insira um número inteiro!");
                continue;
            }

            if (vendas.Any(v => v.Numero == numero))
            {
                Console.WriteLine("\nJá existe uma venda registrada com esse número.");
                continue;
            }

            Console.Write("Cliente: ");
            string? nome = Console.ReadLine();

            Console.Write("CPF: ");
            string? cpf = Console.ReadLine();


            Console.Write("Valor: R$");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valorCompra))
            {
                Console.WriteLine("\nEntrada inválida, insira um valor numérico!");
                continue;
            }

            try
            {
                Cliente cliente = new Cliente(nome, cpf);
                Venda venda = new Venda(numero, cliente, valorCompra);

                vendas.Add(venda);

                Console.WriteLine(
                    "\nVenda cadastrada com sucesso!\n" +
                    $"\nSituação: {venda.Situacao}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }

            break;

        case 2:
            break;

        case 3:
            break;

        case 0:
            break;

        default:
            Console.WriteLine("\nOpção inválida, insira uma das opções contidas no menu!");
            break;
    }

} while (opcao != 0);
