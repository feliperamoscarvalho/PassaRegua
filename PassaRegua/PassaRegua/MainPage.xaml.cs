using PassaRegua.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PassaRegua
{
	public partial class MainPage : ContentPage
	{

        public MainPage()
		{
			InitializeComponent();

            AcessoDados ac = new AcessoDados();

            ListView listPedidos = this.FindByName<ListView>("lstPedidos");

            //Obtém os pedidos cadastrados
            List<Pedido> listaPedidos = ac.ListPedido();

            //Converte a lista de pedidos em um ObservableCollection para atualizar automaticamente
            //ObservableCollection<Pedido> listaAtualizavel = new ObservableCollection<Pedido>(listaPedidos as List<Pedido>);

            listPedidos.ItemsSource = listaPedidos;

        }

        public void BotaoAddPessoa_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CadastroPessoa());
        }

        public void BotaoAddPedido_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CadastroPedido());
        }

        public void BotaoFecharConta_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new FechaPedido());
        }

    }
}
