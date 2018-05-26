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
	public partial class CadastroPessoa : ContentPage
	{
		public CadastroPessoa ()
		{
			InitializeComponent ();
		}

        public void BotaoGravarPessoa_Clicked(object sender, EventArgs e)
        {

        }
    }
}