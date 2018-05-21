using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite.Net;
using System.Linq;

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
            //ADICIONAR TABELAS AQUI
            //_conexao.CreateTable<Contato>();
        }

        //Implementar metodos de persistencia e busca nas tabelas desejadas
    }
}
