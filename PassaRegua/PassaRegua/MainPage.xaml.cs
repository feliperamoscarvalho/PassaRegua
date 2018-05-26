using System;
using System.Collections.Generic;
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
            this.Navigation.PushAsync(new FechaConta());
        }

    }
}
