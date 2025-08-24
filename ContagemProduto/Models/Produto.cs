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