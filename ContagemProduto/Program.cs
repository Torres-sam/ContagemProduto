using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ContagemProduto.Models;

namespace ContagemProduto
{
    internal class Program
    {
        static string caminhoArquivo = "produtos.json";

        static void SalvarProdutos(List<Produto> produtos)
        {
            string json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoArquivo, json);
        }

        static List<Produto> CarregarProdutos()
        {
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                return JsonSerializer.Deserialize<List<Produto>>(json);
            }
            return new List<Produto>();
        }

        static void Main(string[] args)
        {
            List<Produto> produtos = CarregarProdutos();
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

                            double pesoDoPallet = 0.0;
                            string respostaPallet;

                            while (true)
                            {
                                Console.Write("👉 Já foi tirado o peso do pallet? (S/N): ");
                                respostaPallet = Console.ReadLine().ToUpper();

                                if (respostaPallet == "N")
                                {
                                    while (true)
                                    {
                                        Console.Write("➡ Informe o peso do Pallet: ");
                                        string entradaPallet = Console.ReadLine();
                                        if (double.TryParse(entradaPallet, NumberStyles.Any, CultureInfo.InvariantCulture, out pesoDoPallet))
                                        {
                                            Console.WriteLine($"✅ Peso do Pallet registrado: {pesoDoPallet} kg");
                                            Console.WriteLine();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("⚠ Valor inválido! Digite apenas números (ex: 20.5).");
                                            Console.WriteLine();
                                        }
                                    }
                                    break;
                                }
                                else if (respostaPallet == "S")
                                {
                                    pesoDoPallet = 0.0;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(" ❌ Resposta inválida! Digite apenas S ou N.");
                                    Console.WriteLine();
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine("╔══════════════════════════════════════╗");
                            Console.WriteLine("          🔎 Dados do Produto           ");
                            Console.WriteLine("╚══════════════════════════════════════╝");

                            Console.Write("➡ Fornecedor: ");
                            string fornecedor = Console.ReadLine().ToUpper();

                            Console.Write("➡ Produto: ");
                            string nomeProduto = Console.ReadLine().ToUpper();

                            double pesoBruto;
                            while (true)
                            {
                                Console.Write("➡ Peso Bruto (kg): ");
                                string entradaPesoBruto = Console.ReadLine();

                                if (double.TryParse(entradaPesoBruto, NumberStyles.Any, CultureInfo.InvariantCulture, out pesoBruto))
                                    break;
                                else
                                    Console.WriteLine("⚠ Valor inválido! Digite apenas números (ex: 996.0 ou 996).");
                            }

                            int quantidadeDePeca;
                            while (true)
                            {
                                Console.Write("➡ Quantidade de Peças: ");
                                string entradaQuantidadeDePeca = Console.ReadLine();
                                if (int.TryParse(entradaQuantidadeDePeca, out quantidadeDePeca))
                                    break;
                                else
                                    Console.WriteLine("⚠ Valor inválido! Digite apenas números (ex: 6).");
                            }

                            double embalagemPeca;
                            while (true)
                            {
                                Console.Write("➡ Peso da Embalagem por Peça (kg): ");
                                string entradaEmbalagemPeca = Console.ReadLine();
                                if (double.TryParse(entradaEmbalagemPeca, NumberStyles.Any, CultureInfo.InvariantCulture, out embalagemPeca))
                                    break;
                                else
                                    Console.WriteLine("⚠ Valor inválido! Digite apenas números (ex: 0.014).");
                            }

                            int quantidadeDeCaixa;
                            while (true)
                            {
                                Console.Write("➡ Quantidade de Caixas: ");
                                string entradaQuantidadeDeCaixa = Console.ReadLine();
                                if (int.TryParse(entradaQuantidadeDeCaixa, out quantidadeDeCaixa))
                                    break;
                                else
                                    Console.WriteLine("⚠ Valor inválido! Digite apenas números (ex: 35).");
                            }

                            double pesoDaCaixa;
                            while (true)
                            {
                                Console.Write("➡ Peso da Caixa (kg): ");
                                string entradaPesoDaCaixa = Console.ReadLine();
                                if (double.TryParse(entradaPesoDaCaixa, NumberStyles.Any, CultureInfo.InvariantCulture, out pesoDaCaixa))
                                    break;
                                else
                                    Console.WriteLine("⚠ Valor inválido! Digite apenas números (ex: 0.850).");
                            }

                            Console.Write("➡ Nome do Operador: ");
                            string nomeDoUsuario = Console.ReadLine();

                            Produto novoProduto = new Produto(fornecedor, nomeProduto, pesoBruto,
                                                            quantidadeDePeca, embalagemPeca,
                                                            quantidadeDeCaixa, pesoDaCaixa,
                                                            nomeDoUsuario, pesoDoPallet);

                            produtos.Add(novoProduto);
                            SalvarProdutos(produtos);

                            Console.Clear();
                            Console.WriteLine("╔══════════════════════════════════════╗");
                            Console.WriteLine("          🔎 Prévia do Produto          ");
                            Console.WriteLine("╚══════════════════════════════════════╝");

                            novoProduto.MostrarDadosResumidos();


                            Console.WriteLine();
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

                            string opcao;
                            while (true)
                            {
                                Console.WriteLine("────────────────────────────────────");
                                Console.Write(" 👉 Deseja ver os detalhes de algum produto? (S/N): ");
                                opcao = Console.ReadLine().ToUpper();

                                if (opcao == "S")
                                {
                                    Console.Write("Digite o número do produto (ou 0 para sair): ");
                                    if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= produtos.Count)
                                    {
                                        Console.Clear();
                                        produtos[escolha - 1].MostrarDados();
                                        int a = 1;
                                        foreach (var p in produtos)
                                        {
                                            Console.Write($" #{a} ");
                                            //p.MostrarDadosResumidos();
                                            Console.WriteLine($"➡ Produto: {p.NomeProduto} | ⚖ Peso Líquido: {p.PesoLiquido().ToString("F3", CultureInfo.InvariantCulture)}");
                                            a++;
                                        }

                                    }
                                    else if (escolha == 0)
                                    {
                                        break;
                                    }
                                }
                                else if (opcao == "N")
                                    break;
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
                                Console.WriteLine($" #{i + 1} - {produtos[i].NomeProduto}");

                            Console.Write(" 👉 Digite o número do produto a remover (ou 0 para cancelar): ");
                            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= produtos.Count)
                            {
                                Console.Write($"⚠ Tem certeza que deseja remover \"{produtos[escolha - 1].NomeProduto}\"? (S/N): ");
                                if (Console.ReadLine().ToUpper() == "S")
                                {
                                    produtos.RemoveAt(escolha - 1);
                                    SalvarProdutos(produtos);
                                    Console.WriteLine("✅ Produto removido com sucesso!");
                                }
                            }
                        }
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case "4":
                        exibirMenu = false;
                        Console.WriteLine("👋 Encerrando o programa...");
                        break;

                    default:
                        Console.WriteLine(" ❌ Opção inválida!");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}