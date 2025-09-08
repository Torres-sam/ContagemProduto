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
            // Lista onde serão armazenados todos os produtos cadastrados
            List<Produto> produtos = new List<Produto>();

            // Controla se o menu principal deve continuar aparecendo
            bool exibirMenu = true;

            // Loop principal do programa
            while (exibirMenu)
            {
                // Limpa a tela e mostra o menu principal
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

                // Lê a opção escolhida pelo usuário
                switch (Console.ReadLine())
                {
                    case "1": // Cadastro de um novo produto

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

                            // Pergunta sobre o peso do pallet
                            double pesoDoPallet = 0.0;
                            string respostaPallet;

                            while (true)
                            {
                                Console.Write("👉 Já foi tirado o peso do pallet? (S/N): ");
                                respostaPallet = Console.ReadLine().ToUpper();

                                if (respostaPallet == "N")
                                {
                                    // Se o peso do pallet ainda não foi descontado, o usuário deve informar
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
                                    // Se já foi tirado, o valor será zero
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

                            // Cadastro dos dados principais do produto
                            Console.Write("➡ Fornecedor: ");
                            string fornecedor = Console.ReadLine().ToUpper();

                            Console.Write("➡ Produto: ");
                            string nomeProduto = Console.ReadLine().ToUpper();                        
                        
                            // Peso Bruto
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

                            // Quantidade de peças
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
                        
                            // Peso da embalagem por peça
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
                        
                            // Quantidade de caixas
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
                                                            
                            // Peso da caixa
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

                            // Criação do objeto Produto com os dados informados
                            Produto novoProduto = new Produto(fornecedor, nomeProduto, pesoBruto,
                                                            quantidadeDePeca, embalagemPeca,
                                                            quantidadeDeCaixa, pesoDaCaixa,
                                                            nomeDoUsuario, pesoDoPallet);

                            // Adiciona o produto à lista
                            produtos.Add(novoProduto);

                            Console.WriteLine("✅ Produto cadastrado com sucesso!");
                            Console.WriteLine();

                            // Pergunta se deseja cadastrar outro produto
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

                    case "2": // Visualizar produtos
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
                            // Mostra a lista resumida de produtos
                            int i = 1;
                            foreach (var p in produtos)
                            {
                                Console.Write($" #{i} ");
                                p.MostrarDadosResumidos();
                                i++;
                            }

                            // Pergunta se o usuário quer ver os detalhes de algum produto
                            string opcao;
                            while (true)
                            {
                                Console.WriteLine("────────────────────────────────────");
                                Console.Write(" 👉 Deseja ver os detalhes de algum produto? (S/N): ");
                                opcao = Console.ReadLine().ToUpper();

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

                                            // Exibe todos os dados do produto escolhido
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
                                else if (opcao == "N")
                                {
                                    break;
                                }
                                else
                                { 
                                    Console.WriteLine(" ❌ Resposta inválida! Digite apenas S ou N.");
                                }
                            }
                        }

                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case "3": // Remover produto
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
                            // Lista os produtos com índice
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
                                    // Confirmação antes de remover
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

                    case "4": // Sair do programa
                        Console.WriteLine("👋 Encerrando o programa...");
                        exibirMenu = false;
                        break;

                    default: // Caso o usuário digite opção inválida
                        Console.WriteLine(" ❌ Opção inválida!");
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
