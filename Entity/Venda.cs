
using sistema_pagamentos_loja.Pagamentos;

namespace sistema_pagamentos_loja.Entity
{
    internal class Venda
    {
        public int Numero { get; }
        public Cliente Cliente { get; }
        public decimal ValorCompra { get; }
        public string Situacao { get; private set; }
        public decimal? ValorFinal { get; private set; }
        public string? FormaPagamento { get; private set; }

        public Venda(int numero, Cliente cliente, decimal valorCompra)
        {
            if(valorCompra <= 0)
            {
                throw new ArgumentException("O valor da compra inserido é menor ou igual a zero!");
            }

            Numero = numero;
            Cliente = cliente;
            ValorCompra = valorCompra;
            Situacao = "Pendente";
        }

        public void RealizarPagamento(FormaPagamento formaPagamento)
        {
            if (Situacao == "Pago")
            {
                throw new ArgumentException("Esta venda já foi paga.");
            }

            ValorFinal = formaPagamento.CalcularValorFinal(ValorCompra);
            FormaPagamento = formaPagamento.Nome;
            Situacao = "Pago";
        }
    }
}
