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

        public void BotaoNovo_Clicked(object sender, EventArgs e)
        {
            //Método para abrir tela de criar nova conta
            this.Navigation.PushAsync(new CadastroConta());
        }

    }
}
