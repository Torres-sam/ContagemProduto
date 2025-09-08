using System;
using System.Globalization;

namespace ContagemProduto.Models
{
    public class Produto
    {
        // Construtor da classe Produto
        // Recebe todos os dados necessários para criar o objeto
        public Produto(string fornecedor, string nomeProduto, double pesoBruto,
        int quantidadeDePeca, double embalagemPeca,
        int quantidadeDeCaixa, double pesoDaCaixa, string nomeDoUsuario, double pesoDoPallet = 0.0)
        {
            Fornecedor = fornecedor;
            NomeProduto = nomeProduto;
            PesoBruto = pesoBruto;
            QuantidadeDePeca = quantidadeDePeca;
            EmbalagemPeca = embalagemPeca;
            QuantidadeDeCaixa = quantidadeDeCaixa;
            PesoDaCaixa = pesoDaCaixa;
            NomeDoUsuario = nomeDoUsuario;
            PesoDoPallet = pesoDoPallet;
        }

        // Campo privado para armazenar fornecedor
        private string _fornecedor;
        public string Fornecedor
        {
            get { return _fornecedor; }
            set
            {
                // Se não for informado, atribui aviso
                if (value == "")
                    _fornecedor = "⚠ FORNECEDOR NÃO INFORMADO ⚠";
                else
                    _fornecedor = value.ToUpper(); // Sempre em maiúsculo
            }
        }

        // Campo privado para armazenar o nome do produto
        private string _nomeProduto;
        public string NomeProduto
        {
            get { return _nomeProduto; }
            set
            {
                // Se não for informado, atribui aviso
                if (value == "")
                    _nomeProduto = "⚠ PRODUTO NÃO INFORMADO ⚠";
                else
                    _nomeProduto = value.ToUpper();
            }
        }

        // Demais propriedades simples do produto
        public double PesoBruto { get; set; }
        public int QuantidadeDePeca { get; set; }
        public double EmbalagemPeca { get; set; }
        public int QuantidadeDeCaixa { get; set; }
        public double PesoDaCaixa { get; set; }
        public double PesoDoPallet { get; set; }

        // Campo privado para nome do usuário
        private string _nomeDoUsuario;
        public string NomeDoUsuario
        {
            get { return _nomeDoUsuario.ToUpper(); } // sempre retorna em maiúsculo
            set
            {
                if (value == "")
                    _nomeDoUsuario = "⚠ USUÁRIO NÃO INFORMADO ⚠";
                else
                    _nomeDoUsuario = value;
            }
        }

        // Método que calcula o peso total das embalagens
        public double PesoEmbalagem()
        {
            return ((QuantidadeDePeca * EmbalagemPeca) + PesoDaCaixa) * QuantidadeDeCaixa;
        }

        // Método que calcula o peso líquido do produto
        // Fórmula: PesoBruto - PesoEmbalagem - PesoDoPallet
        public double PesoLiquido()
        {
            double pesoDaEmbalagem = PesoEmbalagem();
            return PesoBruto - pesoDaEmbalagem - PesoDoPallet;
        }

        // Exibe os dados básicos do produto (resumidos)
        public void MostrarDadosResumidos()
        {
            Console.WriteLine($"📦 Produto: {NomeProduto} | ⚖ Peso Líquido: {PesoLiquido().ToString("F3", CultureInfo.InvariantCulture)} kg");
        }

        // Exibe os dados completos do produto (detalhados)
        public void MostrarDados()
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("         📑 Detalhes do Produto         ");
            Console.WriteLine("╚══════════════════════════════════════╝");

            Console.WriteLine($"➡ Fornecedor: {Fornecedor}");
            Console.WriteLine($"➡ Produto: {NomeProduto}");
            Console.WriteLine($"➡ Peso Bruto: {PesoBruto.ToString("F3", CultureInfo.InvariantCulture)} kg");
            Console.WriteLine($"➡ Quantidade de Peças: {QuantidadeDePeca}");
            Console.WriteLine($"➡ Embalagem por Peça: {EmbalagemPeca.ToString("F3", CultureInfo.InvariantCulture)} kg");
            Console.WriteLine($"➡ Quantidade de Caixas: {QuantidadeDeCaixa}");
            Console.WriteLine($"➡ Peso da Caixa: {PesoDaCaixa.ToString("F3", CultureInfo.InvariantCulture)} kg");

            // Só mostra o peso do pallet se foi informado
            if (PesoDoPallet != 0.0)
                Console.WriteLine($"➡ Peso do Pallet: {PesoDoPallet.ToString("F3", CultureInfo.InvariantCulture)} kg");
            else
                Console.WriteLine("➡ Peso do Pallet: (não considerado)");

            Console.WriteLine("────────────────────────────────────────");
            Console.WriteLine($"📦 Peso da Embalagem: {PesoEmbalagem().ToString("F3", CultureInfo.InvariantCulture)} kg");
            Console.WriteLine($"⚖ Peso Líquido: {PesoLiquido().ToString("F3", CultureInfo.InvariantCulture)} kg");
            Console.WriteLine("────────────────────────────────────────");

            // Exibe informações adicionais de contexto
            Console.WriteLine($"📅 Data de Pesagem: {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine($"⏰ Hora de Pesagem: {DateTime.Now:HH:mm:ss}");
            Console.WriteLine($"👤 Operador: {NomeDoUsuario}");
            Console.WriteLine("════════════════════════════════════════");
        }
    }
}
