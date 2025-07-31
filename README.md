# 🧮 Contagem de Produto - Cálculo de Peso Líquido

Aplicação de console desenvolvida em **C# (.NET)** que realiza o cálculo do **peso líquido de produtos** com base em dados de entrada como peso bruto, embalagens, caixas e palete. É ideal para contextos de logística, controle de estoque e conferência de mercadoria.

---

## 📦 Objetivo

Ajudar operadores e responsáveis logísticos a calcular de forma precisa o **peso líquido real** dos produtos, subtraindo pesos adicionais como:
- Peso das embalagens por peça
- Peso das caixas
- Peso do palete (opcional)

---

## ✅ Funcionalidades

- Entrada de dados via console
- Cálculo automático do peso líquido
- Verificação do peso do pallet (se já foi retirado ou não)
- Exibição detalhada dos dados formatados
- Informações de rastreabilidade (data, hora e nome do responsável)

---

## 🧾 Exemplo de execução

=== Calculando o Líquido ===
Informe os dados do produto:
----------------------------
Já foi tirado o peso do pallet? (S/N): N
Peso do Pallet: 15.000
Fornecedor: NESTLE
Produto: CHOCOLATE
Peso Bruto: 100.000
Quantidade de Peça: 50
Peso da Embalagem por Peça: 0.050
Quantidade de Caixa: 2
Peso de Cada Caixa: 1.000
Nome da Pessoa Responsável: João

============================
Fornecedor: NESTLE
Produto: CHOCOLATE
Peso Bruto: 100.000 kg
Quantidade de Peça: 50
Embalagem por Peça: 0.050 kg
Quantidade de Caixa: 2
Peso por Caixa: 1.000 kg
Peso do Pallet: 15.000 kg
Total de Embalagem: 7.000 kg
Peso Líquido: 78.000 kg
----------------------------
Data de Pesagem: 30/07/2025
Hora de Pesagem: 14:22:17
Pesado por: João
============================
🧠 Fórmula utilizada

totalEmbalagem = ((embalagemPeca * quantidadePeca) + pesoCaixa) * quantidadeCaixa;
pesoLiquido = pesoBruto - totalEmbalagem - pesoPallet;

🚀 Como executar

Clone o repositório:

git clone https://github.com/seu-usuario/ContagemProduto.git
Compile e execute com o .NET CLI:
cd ContagemProduto
dotnet run

💡 Certifique-se de ter o SDK do .NET 6.0 ou superior instalado.

📂 Estrutura do projeto

ContagemProduto/
│
├── Program.cs         # Código principal
├── ContagemProduto.csproj
└── README.md          # Este arquivo
✍️ Autor
Desenvolvido por [Samuel Torres]

📃 Licença
Este projeto está licenciado sob os termos da Licença MIT.
Você é livre para usar, modificar e distribuir, desde que preserve os créditos e o aviso de direitos autorais.
