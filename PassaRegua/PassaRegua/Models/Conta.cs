using System;
using System.Collections.Generic;
using System.Text;

namespace PassaRegua.Models
{
    public class Conta
    {
        public int ID { get; set; }
        public string Data { get; set; }
        public StatusConta Status { get; set; }
        public List<ItemConta> ItensConta { get; set; }
    }
}
