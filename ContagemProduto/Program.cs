using System;
using System.Globalization;
using ContagemProduto.Models;
namespace ContagemProduto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Produto> produtos = new List<Produto>();

            bool exibirMenu = true;

            while (exibirMenu)
            {  
                Console.Clear();
                Console.WriteLine("= Bem vindo ao sistema de Conferência =");
                Console.WriteLine("=========================================");
                Console.WriteLine("=== Digite a sua opção: ==="); 
                Console.WriteLine("---------------------------");            
                Console.WriteLine("[1] - novo produto");
                Console.WriteLine("[2] - Ver produtos");
                Console.WriteLine("[3] - Apagar produto");                
                Console.WriteLine("[4] - Encerrar");
                Console.WriteLine("---------------------------");
                Console.Write("Opção: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Produto novoProduto = new Produto();                        
                        Console.WriteLine($"{new String('=', 3)} Calculando o Liquido {new string('=', 3)}");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Informe os dados do produto:");
                        Console.WriteLine("----------------------------");
                        novoProduto.AdicionarInformacaoProduto();
                        produtos.Add(novoProduto);
                        
                                                
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("=== LISTA DE PRODUTOS ===");
                        Console.WriteLine("-------------------------");
                        if (produtos.Count == 0)
                            Console.WriteLine("Nenhum produto cadastrado ainda!");
                        else
                        {
                            int i = 1;
                            foreach (var p in produtos)
                            {
                                Console.Write($"Produto #{i} ");
                                p.MostrarDadosResumidos();
                                i++;
                            }
                            Console.WriteLine("-------------------------");
                            Console.Write("Deseja ver os detalhes de algum produto? (S/N): ");                            
                            string opcao = Console.ReadLine().ToUpper();
                            Console.WriteLine("-------------------------");                            

                            if (opcao == "S")
                            {
                                bool escolhido = false;
                                while (!escolhido)
                                {
                                    Console.Write("Digite o número do produto (ou 0 para sair): ");                                    
                                    int escolha = int.Parse(Console.ReadLine()); 
                                    Console.WriteLine("-------------------------");
                                    

                                    if (escolha == 0)
                                    {
                                        Console.WriteLine("Voltando ao menu...");
                                        escolhido = true;
                                    }
                                    else if (escolha > 0 && escolha <= produtos.Count)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("=== DETALHES DO PRODUTO ===");
                                        produtos[escolha - 1].MostrarDados();
                                        Console.Write("Quer consultar outro produto? (S/N): ");                                                                              
                                        string repetir = Console.ReadLine().ToUpper();
                                        Console.WriteLine("-------------------------");
                                        if (repetir != "S")
                                            escolhido = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Número inválido, tente novamente!");
                                    }
                                }
                            }
                        }

                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case "3":

                        Console.Clear();
                        Console.WriteLine("=== APAGAR PRODUTO ===");
                        Console.WriteLine("----------------------");
                        if (produtos.Count == 0)
                        {
                            Console.WriteLine("Nenhum produto para apagar.");
                        }
                        else
                        {
                            for (int i = 0; i < produtos.Count; i++)
                            {
                                Console.WriteLine($"#{i + 1} - {produtos[i].NomeProduto}");
                            }
                            Console.WriteLine("Escolha o número do produto a remover: ");
                            Console.Write("Número: ");
                            int index = int.Parse(Console.ReadLine()) - 1;

                            if (index >= 0 && index < produtos.Count)
                            {
                                produtos.RemoveAt(index); 
                                Console.WriteLine("----------------------");                               
                                Console.WriteLine("Produto removido com sucesso!");
                            }
                            else
                            {

                                Console.WriteLine("Número inválido!");
                            }
                        }
                        Console.WriteLine("Pressione ENTER para continuar");
                        Console.ReadLine();
                        break;                   

                    case "4":
                        Console.WriteLine("Encerrando o programa...");
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