namespace sistema_pagamentos_loja.Pagamentos
{
    internal abstract class FormaPagamento
    {
        public abstract decimal CalcularValorFinal(decimal valorCompra);

    }
}
