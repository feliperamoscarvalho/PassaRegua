using System;
using System.Collections.Generic;
using System.Text;

namespace PassaRegua.Models
{
    public class ItemConta
    {
        public int ID { get; set; }
        public Pessoa Pessoa { get; set; }
        public string Produto { get; set; }
        public decimal Valor { get; set; }
    }
}
