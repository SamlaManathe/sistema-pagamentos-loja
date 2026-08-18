
namespace sistema_pagamentos_loja.Pagamentos
{
    internal class PagamentoDinheiro : FormaPagamento
    {
        public override string Nome => "Dinheiro";

        public override decimal CalcularValorFinal(decimal valorCompra)
        {
            return valorCompra;
        }
    }
}
