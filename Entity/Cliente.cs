
namespace sistema_pagamentos_loja.Entity
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; }

        public Cliente(string nome, string cpf)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome digitado é inválido!");

            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("O CPF digitado é inválido!");

            Nome = nome;
            CPF = cpf;
        }

    }
}
