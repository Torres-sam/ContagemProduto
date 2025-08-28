using System;
using System.Globalization;

namespace ContagemProduto.Models
{
    public class Produto
    {
        public string Fornecedor { get; set; }
        public string NomeProduto { get; set; }
        public double PesoBruto { get; set; }
        public int QuantidadeDePeca { get; set; }
        public double EmbalagemPeca { get; set; }
        public int QuantidadeDeCaixa { get; set; }
        public double PesoDaCaixa { get; set; }
        public double PesoDoPallet { get; set; }
        public string NomeDoUsuario { get; set; }

        public void AdicionarInformacaoProduto()
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║📝 Cadastro de Informações do Produto ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.WriteLine();

            Console.Write("👉 Já foi tirado o peso do pallet? (S/N): ");
            string resposta = Console.ReadLine().ToUpper();
            Console.WriteLine("────────────────────────────────────────");

            if (resposta == "N")
            {
                Console.Write("➡ Informe o peso do Pallet: ");
                PesoDoPallet = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("✅ Peso do pallet registrado!");
            }
            else if (resposta == "S")
            {
                PesoDoPallet = 0.0;
                Console.WriteLine("⚠ Peso do pallet desconsiderado!");
            }
            else
            {
                PesoDoPallet = 0.0;
                Console.WriteLine("⚠ Resposta inválida! Peso do pallet considerado como 0.0");
            }

            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║        🔎 Dados do Produto           ║");
            Console.WriteLine("╚══════════════════════════════════════╝");

            Console.Write("➡ Fornecedor: ");
            Fornecedor = Console.ReadLine().ToUpper();

            Console.Write("➡ Produto: ");
            NomeProduto = Console.ReadLine().ToUpper();

            Console.Write("➡ Peso Bruto (kg): ");
            PesoBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("➡ Quantidade de Peças: ");
            QuantidadeDePeca = int.Parse(Console.ReadLine());

            Console.Write("➡ Peso da Embalagem por Peça (kg): ");
            EmbalagemPeca = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("➡ Quantidade de Caixas: ");
            QuantidadeDeCaixa = int.Parse(Console.ReadLine());

            Console.Write("➡ Peso da Caixa (kg): ");
            PesoDaCaixa = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("➡ Nome do Operador: ");
            NomeDoUsuario = Console.ReadLine();

            Console.WriteLine();
            
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
            Console.WriteLine("║        📑 Detalhes do Produto        ║");
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
