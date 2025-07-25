# 🧮 Contagem de Produto - Cálculo de Peso Líquido

Este é um projeto em C# que calcula o **peso líquido de produtos**, subtraindo o peso das embalagens e caixas do peso bruto informado. Útil para controle logístico, conferência de mercadoria e organização de estoque.

## 📋 Funcionalidades

- Entrada de dados via terminal (console)
- Cálculo automático do peso líquido com base em:
  - Peso bruto
  - Quantidade de peças
  - Peso da embalagem por peça
  - Quantidade de caixas
  - Peso das caixas
- Exibição dos dados formatados e organizados no console

## 📌 Exemplo de uso

Fornecedor: NESTLE
Produto: CHOCOLATE
Peso Bruto: 100.000
Quantidade de Peça: 50
Embalagem Peça: 0.050
Quantidade de Caixa: 2
Peso Caixa: 1.000

Total de Embalagem: 7.000 kg
Peso Líquido: 93.000 kg

🧠 Fórmula utilizada

totalEmbalagem = ((embalagemPeca * quantidadePeca) + pesoCaixa) * quantidadeCaixa
pesoLiquido = pesoBruto - totalEmbalagem

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
