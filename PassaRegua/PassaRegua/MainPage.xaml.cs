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
        }

        protected override void OnAppearing()
        {
            //Executa o método sempre que mostra a tela, inclusive voltando de uma tela filha
            base.OnAppearing();
            RefreshList();
        }

        public void RefreshList()
        {

            ListView listPedidos = this.FindByName<ListView>("lstPedidos");
            Label lblCount = this.FindByName<Label>("lblCount");
            Label lblTotal = this.FindByName<Label>("lblTotal");

            //Obtém os pedidos cadastrados
            AcessoDados ac = new AcessoDados();
            List<Pedido> listaPedidos = ac.ListPedido();

            listPedidos.ItemsSource = listaPedidos;

            //Exibe os totais
            decimal count = ac.GetCountPedidos();
            decimal totalValue = ac.GetTotalValuePedidos();
            lblCount.Text = "Quantidade de itens pedidos: " + count.ToString();
            lblTotal.Text = "Valor total da conta: R$ " + totalValue.ToString();
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
