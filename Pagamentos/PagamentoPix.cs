
namespace sistema_pagamentos_loja.Pagamentos
{
    internal class PagamentoPix : FormaPagamento
    {
        public override decimal CalcularValorFinal(decimal valorCompra)
        {
            decimal desconto = valorCompra * 0.05m;

            return valorCompra - desconto;
        }
    }
}
