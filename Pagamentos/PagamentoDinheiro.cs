

namespace sistema_pagamentos_loja.Pagamentos
{
    internal class PagamentoDinheiro : FormaPagamento
    {
        public override decimal CalcularValorFinal(decimal valorCompra)
        {
            return valorCompra;
        }
    }
}
