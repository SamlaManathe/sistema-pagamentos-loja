
using sistema_pagamentos_loja.Entity;
using sistema_pagamentos_loja.Pagamentos;

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

            Console.Write(
                "\n================================\n" +
                        "\tCadastro de venda" +
                "\n================================\n"
            );
            Console.Write("\nNúmero: ");
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
            Console.Write(
                "\n================================\n" +
                        "\tConsulta de vendas" +
                "\n================================\n"
            );

            foreach (Venda venda in vendas)
            {
                Console.WriteLine(
                    $"\nVenda: {venda.Numero}" +
                    $"\nCliente: {venda.Cliente.Nome}" +
                    $"\nValor original: R${venda.ValorCompra}" +
                    $"\nSituação: {venda.Situacao}"
                );

                if(venda.Situacao == "Pago")
                {
                    Console.WriteLine(
                        $"\nForma de pagamento: {venda.FormaPagamento}" +
                        $"\nValor final: R${venda.ValorFinal}"
                    );
                }
            }

            break;

        case 3:
            Console.Write(
                "\n================================\n" +
                        "\tRealizar pagamento" +
                "\n================================\n"
            );

            Console.Write("\nNúmero: ");
            if (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("\nEntrada inválida, insira um número inteiro!");
                continue;
            }

            Venda? vendaEncontrada = vendas.FirstOrDefault(v => v.Numero == numero);

            if (vendaEncontrada == null)
            {
                Console.WriteLine("\nA venda não foi encontrada.");
                continue;
            }

            Console.Write(
                "\nEscolha a forma de pagamento:\n" +

                "\n1 - PIX" +
                "\n2 - Cartão de crédito" +
                "\n3 - Dinheiro\n" +

                "\nOpção: "
            );

            if (!int.TryParse(Console.ReadLine(), out int opcaoPagamento))
            {
                Console.WriteLine("\nEntrada inválida, insira um número inteiro!");
                continue;
            }

            FormaPagamento? formaPagamento = null;

            switch (opcaoPagamento)
            {
                case 1:

                    formaPagamento = new PagamentoPix();
                    break;

                case 2:
                    formaPagamento = new PagamentoCartao();
                    break;

                case 3:
                    formaPagamento = new PagamentoDinheiro();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida!");
                    break;
            }

            if (formaPagamento == null)
            {
                continue;
            }

            try
            {
                vendaEncontrada.RealizarPagamento(formaPagamento);

                Console.WriteLine(
                    $"\nValor original: R${vendaEncontrada.ValorCompra}" +
                    $"\nForma de pagamento: {vendaEncontrada.FormaPagamento}" +
                    $"\nValor final: R${vendaEncontrada.ValorFinal}\n" +

                    $"\nPagamento de R${vendaEncontrada.ValorFinal} realizado com sucesso!"
                );
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }

            break;

        case 0:
            Console.WriteLine("\nSaindo...");
            break;

        default:
            Console.WriteLine("\nOpção inválida, insira uma das opções contidas no menu!");
            break;
    }

} while (opcao != 0);
