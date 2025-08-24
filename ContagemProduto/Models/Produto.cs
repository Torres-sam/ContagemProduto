using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContagemProduto.Models
{
    public class Produto
    {
        string Fornecedor { get; set; }
        string NomeProduto { get; set; }
        double PesoBruto { get; set; }
        int QuantidaDePeca { get; set; }
        double EmbalagemPeca { get; set; }
        int QuantidaDeCaixa { get; set; }
        double PesoDaCaixa { get; set; }
        double PesoDoPallet { get; set; }
        string NomeDoUsuario { get; set; }

    }
}