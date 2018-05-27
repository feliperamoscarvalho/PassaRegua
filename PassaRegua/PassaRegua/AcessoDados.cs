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

        private SQLiteConnection _conexao;

        public void Dispose()
        {
            //Fecha a conexao
            _conexao.Dispose();
        }

        public AcessoDados()
        {
            //Obtem a implementacao da interface Config de acordo com o sistema operacional
            var config = DependencyService.Get<IConfig>();
            string databasePath = System.IO.Path.Combine(config.DiretorioDB, "passaRegua.db3");

            //Conecta no banco de dados
            _conexao = new SQLiteConnection(config.Plataforma, databasePath);

            //Cria as tabelas no banco de dados
            _conexao.CreateTable<Pessoa>();
            _conexao.CreateTable<Pedido>();
        }

        public void InsertPessoa(Pessoa pessoa)
        {
            _conexao.Insert(pessoa);
        }

        public List<Pessoa> ListPessoa()
        {
            return _conexao.Table<Pessoa>().OrderBy(p => p.Nome).ToList();
        }

        public Pessoa GetPessoaByName(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                return null;
            }
            return _conexao.Table<Pessoa>().Where(p => p.Nome == nome).FirstOrDefault();
        }

        public void InsertPedido(Pedido pedido)
        {
            _conexao.Insert(pedido);
        }

        public List<Pedido> ListPedido()
        {
            return _conexao.Table<Pedido>().OrderBy(p => p.ID).ToList();
        }

        public void DeletePedido()
        {
            _conexao.DeleteAll<Pedido>();
        }
    }
}
