using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassaRegua
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FechaPedido : ContentPage
	{
		public FechaPedido ()
		{
			InitializeComponent ();

            AcessoDados ac = new AcessoDados();

            ListView listPedidos = this.FindByName<ListView>("lstPedidos");
            listPedidos.ItemsSource = ac.ListPedidoGroupByPessoa();

        }

        public void BotaoFechar_Clicked(object sender, EventArgs e)
        {
            AcessoDados ac = new AcessoDados();
            ac.DeletePedido();
            DisplayAlert("Sucesso", "Conta encerrada!", "OK");
        }

    }
}