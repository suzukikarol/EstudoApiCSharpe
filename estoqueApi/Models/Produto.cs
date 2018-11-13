using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEstoque.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public int Quantidade { get; set; }
    }
}
