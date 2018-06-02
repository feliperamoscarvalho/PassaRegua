using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite.Net;
using System.Linq;
using PassaRegua.Models;

namespace PassaRegua
{
    class AcessoDados : IDisposable
    {
        //Implementa a interface IDisposable para habilitar a remocao de tempos em tempos da conexao, para nao precisar fechar essa conexao

        private SQLiteConnection _connection;

        public void Dispose()
        {
            //Fecha a conexao
            _connection.Dispose();
        }

        public AcessoDados()
        {
            //Obtem a implementacao da interface Config de acordo com o sistema operacional
            var config = DependencyService.Get<IConfig>();
            string databasePath = System.IO.Path.Combine(config.DiretorioDB, "passaRegua.db3");

            //Conecta no banco de dados
            _connection = new SQLiteConnection(config.Plataforma, databasePath);

            //Cria as tabelas no banco de dados
            _connection.CreateTable<Pessoa>();
            _connection.CreateTable<Pedido>();
        }

        public void InsertPessoa(Pessoa pessoa)
        {
            _connection.Insert(pessoa);
        }

        public List<Pessoa> ListPessoa()
        {
            return _connection.Table<Pessoa>().OrderBy(p => p.Nome).ToList();
        }

        public Pessoa GetPessoaByName(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                return null;
            }
            return _connection.Table<Pessoa>().Where(p => p.Nome == nome).FirstOrDefault();
        }

        public Pessoa GetPessoaById(int? Id)
        {
            if (!Id.HasValue)
            {
                return null;
            }
            return _connection.Table<Pessoa>().Where(p => p.ID == Id).FirstOrDefault();
        }

        public void InsertPedido(Pedido pedido)
        {
            _connection.Insert(pedido);
        }

        public List<Pedido> ListPedido()
        {
            return _connection.Table<Pedido>().OrderByDescending(p => p.ID).ToList();
        }

        public void DeletePedido()
        {
            _connection.DeleteAll<Pedido>();
        }

        public List<Pedido> ListPedidoGroupByPessoa()
        {
            var results = _connection.Table<Pedido>().GroupBy(p => p.Pessoa)
                .Select(group => new Pedido
                {
                    Pessoa = group.Key,
                    Valor = group.Sum(v => v.Valor)
                }
                ).ToList();
            return results;
        }

        public decimal GetCountPedidos()
        {
            decimal count = _connection.Table<Pedido>().Count();
            return count;
        }

        public decimal GetTotalValuePedidos()
        {
            decimal totalValue = _connection.Table<Pedido>().Sum(v => v.Valor);
            return totalValue;
        }
    }
}
