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

        public int IdPessoa { get; set; }

        public override string ToString()
        {
            return string.Format("Pessoa: {0}; Produto: {1}; Valor: {2}", this.IdPessoa, this.Produto, this.Valor);
        }
    }
}
