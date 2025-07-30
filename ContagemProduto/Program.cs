using System;
using System.Globalization;
namespace ContagemProduto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{new String('=', 3)} Calculando o Liquido {new string('=',3)}");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Informe os dados do produto:");
            Console.WriteLine("----------------------------");
            Console.Write("Deseja por o peso do Pallet? S/N ");
            string resposta = Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------");
            double pesoPallet = 0.0;
            if (resposta == "S") {                
                Console.Write("Peso do Pallet: ");
                pesoPallet = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("----------------------------");
            }
            else if (resposta == "N")
            {
                pesoPallet = 0.0;
            }
            else
            {
                Console.WriteLine("Resposta inválida. Considerando peso do pallet como 0.");
            }
            Console.Write("Fornecedor: ");
            string fornecedor = Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------");
            Console.Write("Produto: ");
            string produto = Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------");
            Console.Write("Peso Bruto: ");
            double pesoBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("----------------------------");                      
            Console.Write("Quantidade de Peça: ");
            int quantidadePeca = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------");
            Console.Write("Embalagem Peça: ");
            double embalagemPeca = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("----------------------------");
            Console.Write("Quantidade de Caixa: ");
            int quantidadeCaixa = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------");
            Console.Write("Peso Caixa: ");
            double pesoCaixa = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("----------------------------");
            Console.Write("Nome da Pessoa: ");
            string nomeUsuario = Console.ReadLine();
            Console.WriteLine("============================");
            double totalEmbalagem =((embalagemPeca * quantidadePeca) + pesoCaixa) * quantidadeCaixa ;
            double pesoLiquido = pesoBruto - totalEmbalagem - pesoPallet;

            if (pesoPallet != 0.0)
            {
                pesoBruto -= pesoPallet;
                Console.WriteLine($"Fornecedor: {fornecedor}");
                Console.WriteLine($"Produto: {produto}");
                Console.WriteLine($"Peso Bruto: {pesoBruto.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine($"Quantidade de Peça: {quantidadePeca}");
                Console.WriteLine($"Embalagem Peça: {embalagemPeca.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine($"Quantidade de Caixa: {quantidadeCaixa}");
                Console.WriteLine($"Peso Caixa: {pesoCaixa.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine($"Peso do Pallet: {pesoPallet.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine($"Total de Embalagem: {totalEmbalagem.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine($"Peso Líquido: {pesoLiquido.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Data de Pesagem: {DateTime.Now.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Hora de Pesagem: {DateTime.Now.ToString("HH:mm:ss")}");
                Console.WriteLine($"Pesado por: {nomeUsuario}");
                Console.WriteLine("============================");
            }
            else
            {
                Console.WriteLine($"Fornecedor: {fornecedor}");
                Console.WriteLine($"Produto: {produto}");
                Console.WriteLine($"Peso Bruto: {pesoBruto.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine($"Quantidade de Peça: {quantidadePeca}");
                Console.WriteLine($"Embalagem Peça: {embalagemPeca.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine($"Quantidade de Caixa: {quantidadeCaixa}");
                Console.WriteLine($"Peso Caixa: {pesoCaixa.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine($"Total de Embalagem: {totalEmbalagem.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine($"Peso do Pallet: Não foi nescessario!!!");
                Console.WriteLine($"Peso Líquido: {pesoLiquido.ToString("F3", CultureInfo.InvariantCulture)} kg");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Data de Pesagem: {DateTime.Now.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Hora de Pesagem: {DateTime.Now.ToString("HH:mm:ss")}");
                Console.WriteLine($"Pesado por: {nomeUsuario}");
                Console.WriteLine("============================");
            }

        }
    }
}