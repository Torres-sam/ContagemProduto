using System;
using System.Globalization;
using System.Collections.Generic;
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
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.WriteLine("     📦 Bem-vindo ao Sistema de Conferência    ");
                Console.WriteLine("╚══════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine(" Escolha uma opção:");
                Console.WriteLine(" ──────────────────────────────────────────────");
                Console.WriteLine(" [1] ➜ Novo Produto");
                Console.WriteLine(" [2] ➜ Ver Produtos");
                Console.WriteLine(" [3] ➜ Apagar Produto");
                Console.WriteLine(" [4] ➜ Encerrar");
                Console.WriteLine(" ──────────────────────────────────────────────");
                Console.Write(" 👉 Opção: ");

                switch (Console.ReadLine())
                {
                    case "1":

                        bool cadastrarOutro = true;
                        while (cadastrarOutro)
                        {   
                        Console.Clear();
                        Console.WriteLine("╔══════════════════════════════════════╗");                                                
                        Console.WriteLine("         ✨ Cadastro de Produto         ");                                               
                        Console.WriteLine("╚══════════════════════════════════════╝");                        
                        Console.WriteLine("╔══════════════════════════════════════╗");
                        Console.WriteLine(" 📝 Preencha as Informações do Produto ");
                        Console.WriteLine("╚══════════════════════════════════════╝");
                        Console.WriteLine();

                        Console.Write("👉 Já foi tirado o peso do pallet? (S/N): ");
                        string respostaPallet = Console.ReadLine().ToUpper();

                        double pesoDoPallet = 0.0;
                        if (respostaPallet == "N")
                        {
                            Console.Write("➡ Informe o peso do Pallet: ");
                            pesoDoPallet = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        }
                        else if (respostaPallet == "S")
                        {
                            pesoDoPallet = 0.0;
                        }
                        else
                        {
                            Console.WriteLine(" ❌ Resposta inválida. Considerando que o peso do pallet é 0.");
                            pesoDoPallet = 0.0;
                        }

                        Console.WriteLine();
                        Console.WriteLine("╔══════════════════════════════════════╗");
                        Console.WriteLine("          🔎 Dados do Produto           ");
                        Console.WriteLine("╚══════════════════════════════════════╝");

                        // Perguntando os dados no console
                        Console.Write("➡ Fornecedor: ");
                        string fornecedor = Console.ReadLine().ToUpper();

                        Console.Write("➡ Produto: ");
                        string nomeProduto = Console.ReadLine().ToUpper();

                        Console.Write("➡ Peso Bruto (kg): ");
                        double pesoBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        Console.Write("➡ Quantidade de Peças: ");
                        int quantidadeDePeca = int.Parse(Console.ReadLine());

                        Console.Write("➡ Peso da Embalagem por Peça (kg): ");
                        double embalagemPeca = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        Console.Write("➡ Quantidade de Caixas: ");
                        int quantidadeDeCaixa = int.Parse(Console.ReadLine());

                        Console.Write("➡ Peso da Caixa (kg): ");
                        double pesoDaCaixa = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        Console.Write("➡ Nome do Operador: ");
                        string nomeDoUsuario = Console.ReadLine();

                        

                        // Criando o produto usando o construtor
                        Produto novoProduto = new Produto(fornecedor, nomeProduto, pesoBruto,
                                                        quantidadeDePeca, embalagemPeca,
                                                        quantidadeDeCaixa, pesoDaCaixa,
                                                        nomeDoUsuario, pesoDoPallet);

                        produtos.Add(novoProduto);

                        Console.WriteLine("✅ Produto cadastrado com sucesso!");
                        Console.WriteLine();
                        // Pergunta se quer cadastrar outro
                        Console.Write("Deseja cadastrar outro produto? (S/N): ");
                        string resposta = Console.ReadLine().ToUpper();
                            if (resposta != "S")
                            {
                                cadastrarOutro = false;
                                Console.WriteLine("↩ Voltando ao menu...");
                            }
                        
                        }
                        Console.WriteLine("Pressione ENTER para voltar ao menu...");
                        Console.ReadLine();
                        break;


                    case "2":
                        Console.Clear();
                        Console.WriteLine("╔══════════════════════════════════════╗");
                        Console.WriteLine("         📋 Lista de Produtos           ");
                        Console.WriteLine("╚══════════════════════════════════════╝");

                        if (produtos.Count == 0)
                        {
                            Console.WriteLine(" ⚠ Nenhum produto cadastrado ainda!");
                        }
                        else
                        {
                            int i = 1;
                            foreach (var p in produtos)
                            {
                                Console.Write($" #{i} ");
                                p.MostrarDadosResumidos();
                                i++;
                            }

                            Console.WriteLine("────────────────────────────────────");
                            Console.Write(" 👉 Deseja ver os detalhes de algum produto? (S/N): ");
                            string opcao = Console.ReadLine().ToUpper();

                            if (opcao == "S")
                            {
                                bool escolhido = false;
                                while (!escolhido)
                                {
                                    Console.Write("Digite o número do produto (ou 0 para sair): ");
                                    int escolha = int.Parse(Console.ReadLine());

                                    if (escolha == 0)
                                    {
                                        Console.WriteLine("↩ Voltando ao menu...");
                                        escolhido = true;
                                    }
                                    else if (escolha > 0 && escolha <= produtos.Count)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("╔══════════════════════════════════════╗");
                                        Console.WriteLine("          🔎 Detalhes do Produto        ");
                                        Console.WriteLine("╚══════════════════════════════════════╝");

                                        produtos[escolha - 1].MostrarDados();

                                        Console.Write(" 👉 Quer consultar outro produto? (S/N): ");
                                        string repetir = Console.ReadLine().ToUpper();
                                        if (repetir != "S")
                                            escolhido = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine(" ❌ Número inválido, tente novamente!");
                                    }
                                }
                            }
                        }

                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("╔══════════════════════════════════════╗");
                        Console.WriteLine("             🗑 Apagar Produto           ");
                        Console.WriteLine("╚══════════════════════════════════════╝");

                        if (produtos.Count == 0)
                        {
                            Console.WriteLine(" ⚠ Nenhum produto para apagar.");
                        }
                        else
                        {
                            for (int i = 0; i < produtos.Count; i++)
                            {
                                Console.WriteLine($" #{i + 1} - {produtos[i].NomeProduto}");
                            }

                            Console.Write(" 👉 Digite o número do produto a remover (ou 0 para cancelar): ");
                            int escolha = int.Parse(Console.ReadLine());
                            Console.WriteLine("────────────────────────────────────");

                            if (escolha == 0)
                            {
                                Console.WriteLine("↩ Operação cancelada. Nenhum produto foi removido.");
                            }
                            else
                            {
                                int index = escolha - 1;
                                if (index >= 0 && index < produtos.Count)
                                {
                                    Console.WriteLine($"⚠ Tem certeza que deseja remover o produto \"{produtos[index].NomeProduto}\"? (S/N): ");
                                    string confirmacao = Console.ReadLine().ToUpper();

                                    if (confirmacao == "S")
                                    {
                                        produtos.RemoveAt(index);
                                        Console.WriteLine("✅ Produto removido com sucesso!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("↩ Remoção cancelada.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(" ❌ Número inválido!");
                                }
                            }
                        }

                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("👋 Encerrando o programa...");
                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine(" ❌ Opção inválida!");
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
