using PassaRegua.Models;
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
            Entry txtNome = this.FindByName<Entry>("txtNome");

            Pessoa pessoa = new Pessoa();
            pessoa.Nome = txtNome.Text;

            AcessoDados ac = new AcessoDados();
            if(ac.GetPessoaByName(pessoa.Nome) != null)
            {
                //Mostra mensagem de erro
                DisplayAlert("Alerta", "Esta pessoa ja esta cadastrada!", "OK");
            }
            else
            {
                ac.InsertPessoa(pessoa);
                txtNome.Text = "";
                DisplayAlert("Sucesso", "Pessoa inserida com sucesso!", "OK");
            }
        }
    }
}