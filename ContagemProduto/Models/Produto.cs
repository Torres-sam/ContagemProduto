using System;
using System.Globalization;

namespace ContagemProduto.Models
{
    public class Produto
    {
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
        private string _fornecedor;
        public string Fornecedor
        {
            get
            {
                return _fornecedor;
            }
            set
            {
                if (value == "")
                {
                    _fornecedor = "⚠ FORNECEDOR NÃO INFORMADO ⚠";

                }
                else
                {
                    _fornecedor = value.ToUpper();
                }
            }
        }
        private string _nomeProduto;
        public string NomeProduto
        {
            get
            {
                return _nomeProduto;                
            }
            set
            {
                if (value == "")
                {
                    _nomeProduto = "⚠ PRODUTO NÃO INFORMADO ⚠";
                }
                else
                {
                    _nomeProduto = value.ToUpper();
                }
            }
        }
        public double PesoBruto { get; set; }
        public int QuantidadeDePeca { get; set; }
        public double EmbalagemPeca { get; set; }
        public int QuantidadeDeCaixa { get; set; }
        public double PesoDaCaixa { get; set; }
        public double PesoDoPallet { get; set; }
        private string _nomeDoUsuario;
        public string NomeDoUsuario
        {
            get
            { 
                return _nomeDoUsuario.ToUpper();
            }
            set
            { 
                if (value == "")
                {
                    _nomeDoUsuario = "⚠ USUÁRIO NÃO INFORMADO ⚠";
                }
                else
                {
                    _nomeDoUsuario = value;
                }

            }
        }        

        public double PesoEmbalagem()
        {
            return ((QuantidadeDePeca * EmbalagemPeca) + PesoDaCaixa) * QuantidadeDeCaixa;
        }

        public double PesoLiquido()
        {
            double pesoDaEmbalagem = PesoEmbalagem();
            return PesoBruto - pesoDaEmbalagem - PesoDoPallet;
        }

        public void MostrarDadosResumidos()
        {
            Console.WriteLine($"📦 Produto: {NomeProduto} | ⚖ Peso Líquido: {PesoLiquido().ToString("F3", CultureInfo.InvariantCulture)} kg");
        }

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

            if (PesoDoPallet != 0.0)
                Console.WriteLine($"➡ Peso do Pallet: {PesoDoPallet.ToString("F3", CultureInfo.InvariantCulture)} kg");
            else
                Console.WriteLine("➡ Peso do Pallet: (não considerado)");

            Console.WriteLine("────────────────────────────────────────");
            Console.WriteLine($"📦 Peso da Embalagem: {PesoEmbalagem().ToString("F3", CultureInfo.InvariantCulture)} kg");
            Console.WriteLine($"⚖ Peso Líquido: {PesoLiquido().ToString("F3", CultureInfo.InvariantCulture)} kg");
            Console.WriteLine("────────────────────────────────────────");
            Console.WriteLine($"📅 Data de Pesagem: {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine($"⏰ Hora de Pesagem: {DateTime.Now:HH:mm:ss}");
            Console.WriteLine($"👤 Operador: {NomeDoUsuario}");
            Console.WriteLine("════════════════════════════════════════");
        }
    }
}
