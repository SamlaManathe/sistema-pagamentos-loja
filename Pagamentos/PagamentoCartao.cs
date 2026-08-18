
namespace sistema_pagamentos_loja.Pagamentos
{
    internal class PagamentoCartao : FormaPagamento
    {
        public override decimal CalcularValorFinal(decimal valorCompra)
        {
            decimal taxa = valorCompra * 0.03m;

            return valorCompra + taxa;
        }
    }
}
