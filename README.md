# 🛒 Sistema de Pagamentos de uma Loja

Aplicação Console desenvolvida em **C#** para gerenciamento de vendas e pagamentos, utilizando os principais conceitos da **Programação Orientada a Objetos (POO)**.

---

## 📋 Sobre o Projeto

Uma pequena loja realiza vendas que podem ser pagas de diferentes formas:

* 💳 Cartão de Crédito
* 📱 PIX
* 💵 Dinheiro

Cada forma de pagamento possui uma regra específica para calcular o valor final da compra.

O sistema permite:

✅ Cadastrar vendas<br>
✅ Consultar vendas cadastradas<br>
✅ Realizar pagamentos<br>
✅ Calcular automaticamente o valor final conforme a forma de pagamento escolhida

---

## 🎯 Objetivo Acadêmico

Este projeto foi desenvolvido para praticar os **quatro pilares da Orientação a Objetos**:

### 🔒 Encapsulamento

Proteção dos dados da venda, impedindo alterações indevidas.

Exemplo:

```csharp
venda.Situacao = "Pago"; // Não permitido
```

A mudança de situação ocorre apenas através da operação de pagamento.

---

### 🧬 Herança

As formas de pagamento compartilham uma estrutura comum.

```text
FormaPagamento
│
├── PagamentoPix
├── PagamentoCartao
└── PagamentoDinheiro
```

---

### 🧩 Abstração

A classe abstrata `FormaPagamento` define um comportamento comum:

```csharp
public abstract decimal CalcularValorFinal(decimal valorCompra);
```

Cada tipo de pagamento implementa sua própria regra.

---

### 🔄 Polimorfismo

O sistema trabalha com qualquer forma de pagamento sem precisar identificar manualmente o tipo.

```csharp
FormaPagamento formaPagamento;

formaPagamento = new PagamentoPix();

decimal valorFinal =
    formaPagamento.CalcularValorFinal(valorVenda);
```

---

# 🏗 Estrutura do Projeto

```text
sistema_pagamentos_loja
│
├── Entity
│   ├── Cliente.cs
│   └── Venda.cs
│
├── Pagamentos
│   ├── FormaPagamento.cs
│   ├── PagamentoPix.cs
│   ├── PagamentoCartao.cs
│   └── PagamentoDinheiro.cs
│
└── Program.cs
```

---

# 👤 Cliente

Cada cliente possui:

| Atributo | Descrição            |
| -------- | -------------------- |
| Nome     | Nome do cliente      |
| CPF      | Documento do cliente |

### Regras

* O CPF é obrigatório na criação do cliente.
* O CPF não pode ser alterado posteriormente.

---

# 🧾 Venda

Cada venda possui:

| Atributo        | Descrição              |
| --------------- | ---------------------- |
| Número          | Identificador da venda |
| Cliente         | Cliente associado      |
| Valor da Compra | Valor original         |
| Situação        | Pendente ou Pago       |

### Regras

* O valor da compra deve ser maior que zero.
* Toda venda inicia como **Pendente**.
* Uma venda não pode ser paga duas vezes.
* O valor da compra não pode ser alterado diretamente.
* A situação não pode ser alterada diretamente.

---

# 💰 Formas de Pagamento

## 📱 PIX

Desconto de **5%** sobre o valor da compra.

### Exemplo

```text
Valor da compra: R$ 200,00
Desconto: 5%
Valor final: R$ 190,00
```

---

## 💳 Cartão de Crédito

Taxa de **3%** sobre o valor da compra.

### Exemplo

```text
Valor da compra: R$ 200,00
Taxa: 3%
Valor final: R$ 206,00
```

---

## 💵 Dinheiro

Não possui desconto nem acréscimo.

### Exemplo

```text
Valor da compra: R$ 200,00
Valor final: R$ 200,00
```

---

# 📌 Regras de Negócio

* O valor da venda deve ser maior que zero.
* A situação inicial é **Pendente**.
* Após o pagamento, a situação passa para **Pago**.
* Não é permitido pagar uma venda já paga.
* Cada forma de pagamento calcula seu valor final de maneira independente.
* O sistema não deve depender de verificações manuais do tipo de pagamento.

---

# 🖥 Menu da Aplicação

```text
================================
        SISTEMA DE VENDAS
================================

1 - Cadastrar venda
2 - Listar vendas
3 - Realizar pagamento
0 - Sair

================================
```

---

# ➕ Cadastro de Venda

### Dados solicitados

```text
Número da venda
Nome do cliente
CPF
Valor da compra
```

### Exemplo

```text
Número: 1
Cliente: Ana Souza
CPF: 12345678900
Valor: 500
```

### Resultado

```text
Venda cadastrada com sucesso!

Situação: Pendente
```

---

# 💳 Realização de Pagamento

O usuário informa o número da venda e escolhe a forma de pagamento.

```text
Escolha a forma de pagamento:

1 - PIX
2 - Cartão de crédito
3 - Dinheiro
```

### Exemplo - PIX

```text
Valor original: R$ 500,00
Forma de pagamento: PIX
Valor final: R$ 475,00

Pagamento realizado com sucesso.
```

---

### Exemplo - Cartão

```text
Valor original: R$ 500,00
Forma de pagamento: Cartão de crédito
Valor final: R$ 515,00

Pagamento realizado com sucesso.
```

---

# 📊 Consulta de Vendas

Exemplo de saída:

```text
Venda: 1
Cliente: Ana Souza
Valor original: R$ 500,00
Situação: Pago

Forma de pagamento: PIX
Valor final: R$ 475,00
```

---

# 🚀 Tecnologias Utilizadas

* C#
* .NET
* Programação Orientada a Objetos
* Coleções (`List<T>`)
* Tratamento de Exceções
* Herança
* Polimorfismo
* Abstração
* Encapsulamento

---

# 📚 Aprendizados

Durante o desenvolvimento deste projeto foram praticados conceitos fundamentais de desenvolvimento orientado a objetos, incluindo:

* Modelagem de classes
* Encapsulamento de regras de negócio
* Criação de classes abstratas
* Implementação de herança
* Uso de polimorfismo
* Tratamento de exceções
* Organização de projetos em camadas

---

⭐ Projeto desenvolvido para fins acadêmicos e prática de Programação Orientada a Objetos em C#.
