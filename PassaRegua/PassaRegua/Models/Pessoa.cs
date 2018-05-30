using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PassaRegua.Models
{
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nome { get; set; }
    }
}
