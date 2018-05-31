using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PassaRegua.Models
{
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Produto { get; set; }

        public decimal Valor { get; set; }

        public string Pessoa { get; set; }

        public string ProdutoPessoa { get { return Produto + " (" + Pessoa + ")"; } }

        public override string ToString()
        {
            return string.Format("Pessoa: {0}; Produto: {1}; Valor: {2}", this.Pessoa, this.Produto, this.Valor);
        }
    }
}
