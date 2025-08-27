using System;
using System.Globalization;
using ContagemProduto.Models;
namespace ContagemProduto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("= Bem vindo ao sistema de peso Liquido! =");
            Console.WriteLine("=========================================");
            Produto produto1 = new Produto();

            bool exibirMenu = true;

            while (exibirMenu)
            {  
                Console.WriteLine("=== Digite a sua opção: ==="); 
                Console.WriteLine("---------------------------");            
                Console.WriteLine("[1] - novo produto");
                Console.WriteLine("[2] - Ver produtos");
                Console.WriteLine("[3] - Apagar produto");
                Console.WriteLine("[4] - Peso do Pallet");
                Console.WriteLine("[5] - Encerrar");
                Console.WriteLine("---------------------------");
                Console.Write("Opção: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"{new String('=', 3)} Calculando o Liquido {new string('=', 3)}");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Informe os dados do produto:");
                        Console.WriteLine("----------------------------");
                        
                        
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
                        Console.Clear();
                        Console.WriteLine("Produto cadastrado com sucesso!");

                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("=== INFORMAÇÕES DO PRODUTO ===");
                        produto1.MostrarDados();
                        Console.WriteLine("Pressione uma tecla para continuar");
                        Console.ReadLine();
                        break;

                    case "3":

                        Console.WriteLine("Esta em construção, mas poderia apagar o produto");
                        Console.WriteLine("Pressione uma tecla para continuar");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("=== PESO DO PALLET ===");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"Peso do Pallet atual: {produto1.PesoDoPallet.ToString("F3", CultureInfo.InvariantCulture)}");
                                                             
                        bool menuPallet = true;
                        while (menuPallet)
                        {
                            Console.WriteLine("Escolha uma das opções abaixo:");
                            Console.WriteLine("----------------------------");
                            Console.WriteLine(" [1] - Novo peso do pallet:");
                            Console.WriteLine(" [2] - Zerar Peso do Pallet:");
                            Console.WriteLine(" [3] - Voltar ao menu principal");
                            Console.WriteLine("----------------------------");
                            Console.Write("Opção: ");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Write("Digite o Novo peso do pallet: ");
                                    produto1.PesoDoPallet = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                                    Console.WriteLine("----------------------------");
                                    break;
                                case "2":
                                    produto1.PesoDoPallet = 0.0;
                                    Console.WriteLine("Peso do pallet zerado com sucesso!");
                                    Console.WriteLine("----------------------------");
                                    break;
                                case "3":
                                    menuPallet = false;
                                    Console.Clear();
                                    break;
                               
                                default:
                                    Console.WriteLine("Opção inválida");
                                    Console.WriteLine("Pressione uma tecla para continuar");
                                    Console.ReadLine();
                                    break;
                            }
                            

                        } 
                        break;

                    case "5":
                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine("Pressione uma tecla para continuar");
                        Console.ReadLine();
                        break;
                }
                

            }
           

            //Peso da Embalagem: 25,528 Peso Liquido: 994,472
        }
    }
}