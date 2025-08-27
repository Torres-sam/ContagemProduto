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
            Console.WriteLine("----------------------------");
            Console.Write("já foi tirado o peso do pallet? S/N ");
            string resposta = Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------");
            double pesoPallet = 0.0;
            if (resposta == "N")
            {
                Console.Write("Peso do Pallet: ");
                pesoPallet = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("----------------------------");
            }
            else if (resposta == "S")
            {
                pesoPallet = 0.0;
            }
            else
            {
                Console.WriteLine("Resposta inválida. Considerando peso do pallet como 0.0");
            }
            Console.Write("Fornecedor: ");
            Fornecedor = Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------");
            Console.Write("Produto: ");
            NomeProduto = Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------");
            Console.Write("Peso Bruto: ");
            PesoBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("----------------------------");
            Console.Write("Quantidade de Peça: ");
            QuantidadeDePeca = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------");
            Console.Write("Embalagem Peça: ");
            EmbalagemPeca = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("----------------------------");
            Console.Write("Quantidade de Caixa: ");
            QuantidadeDeCaixa = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------");
            Console.Write("Peso Caixa: ");
            PesoDaCaixa = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("----------------------------");
            Console.Write("Nome da Pessoa: ");
            NomeDoUsuario = Console.ReadLine();
        }

        public double PesoEmbalagem()
        {
            return ((QuantidadeDePeca * EmbalagemPeca) + PesoDaCaixa) * QuantidadeDeCaixa;
        }

        public double PesoLiquido()
        {
            double pesoDaEmbalagem = PesoEmbalagem();
            if (PesoDoPallet != 0.0)
                return PesoBruto - pesoDaEmbalagem - PesoDoPallet;
            else
                return PesoBruto - pesoDaEmbalagem;
        }
        
        public void MostrarDadosResumidos()
        {
            Console.WriteLine($"Produto: {NomeProduto} - Peso Líquido: {PesoLiquido().ToString("F3", CultureInfo.InvariantCulture)}");
        }        

        public void MostrarDados()
        {

            Console.WriteLine($"Fornecedor: {Fornecedor}");
            Console.WriteLine($"Produto: {NomeProduto}");
            Console.WriteLine($"Peso Bruto: {PesoBruto.ToString("F3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Quantidade de Peça: {QuantidadeDePeca}");
            Console.WriteLine($"Embalagem Peça: {EmbalagemPeca.ToString("F3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Quantidade de Caixa: {QuantidadeDeCaixa}");
            Console.WriteLine($"Peso Caixa: {PesoDaCaixa.ToString("F3", CultureInfo.InvariantCulture)}");
            if (PesoDoPallet != 0.0)
            {
                Console.WriteLine($"Peso do Pallet: {PesoDoPallet.ToString("F3", CultureInfo.InvariantCulture)}");
            }
            else
            {
                Console.WriteLine($"Peso do Pallet: Não foi necessário!");
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Peso da Embalagem: {PesoEmbalagem().ToString("F3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Peso Líquido: {PesoLiquido().ToString("F3", CultureInfo.InvariantCulture)}");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Data de Pesagem: {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine($"Hora de Pesagem: {DateTime.Now:HH:mm:ss}");
            Console.WriteLine($"Pesado por: {NomeDoUsuario}");
            Console.WriteLine("============================");
        }
    }
}