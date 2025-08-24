using System;
using System.Globalization;
using ContagemProduto.Models;
namespace ContagemProduto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Produto produto1 = new Produto();
            Console.Clear();
            Console.WriteLine($"{new String('=', 3)} Calculando o Liquido {new string('=', 3)}");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Informe os dados do produto:");
            Console.WriteLine("----------------------------");
            string resposta;
            produto1.PesoDoPallet = 0.0;
            do
            {
                Console.Write("já foi tirado o peso do pallet? S/N ");
                resposta = Console.ReadLine().ToUpper();
                Console.WriteLine("----------------------------");
                if (resposta == "N")
                {
                    Console.Write("Peso do Pallet: ");
                    produto1.PesoDoPallet = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.WriteLine("----------------------------");
                }
                else if (resposta == "S")
                {
                    produto1.PesoDoPallet = 0.0;
                }
                else
                {
                    Console.WriteLine("Resposta inválida. Por favor, responda com 'S' ou 'N'.");
                }
            } while (resposta != "S" && resposta != "N");
            Console.Write("Fornecedor: ");
            produto1.Fornecedor = Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------");
            Console.Write("Produto: ");
            produto1.NomeProduto = Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------");
            Console.Write("Peso Bruto: ");
            produto1.PesoBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("----------------------------");
            Console.Write("Quantidade de Peça: ");
            produto1.QuantidadeDePeca = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------");
            Console.Write("Embalagem Peça: ");
            produto1.EmbalagemPeca = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("----------------------------");
            Console.Write("Quantidade de Caixa: ");
            produto1.QuantidadeDeCaixa = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------");
            Console.Write("Peso Caixa: ");
            produto1.PesoDaCaixa = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("----------------------------");
            Console.Write("Nome da Pessoa: ");
            produto1.NomeDoUsuario = Console.ReadLine();
            Console.WriteLine("============================");
            produto1.MostrarDados();
                      
            //Peso da Embalagem: 25,528 Peso Liquido: 994,472
        }
    }
}