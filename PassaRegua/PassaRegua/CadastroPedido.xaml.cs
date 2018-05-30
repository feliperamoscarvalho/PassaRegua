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
	public partial class CadastroPedido : ContentPage
	{
        AcessoDados ac;
        Pedido pedido;

		public CadastroPedido ()
		{
			InitializeComponent ();
            ac = new AcessoDados();
            Picker pkrPessoa = this.FindByName<Picker>("pkrPessoa");
            pkrPessoa.ItemsSource = ac.ListPessoa();
            pkrPessoa.ItemDisplayBinding = new Binding("Nome");

            //Instancia o objeto pedido da tela
            pedido = new Pedido();

        }

        public void OnPessoa_Change(object sender, EventArgs e)
        {
            Picker p = (Picker)sender;

            Pessoa pessoaSelecionada = null;

            if (p.SelectedIndex != -1)
            {
                pessoaSelecionada = (Pessoa)p.ItemsSource[p.SelectedIndex];
                pedido.IdPessoa = pessoaSelecionada.ID;
            }
        }

        public void BotaoGravarPedido_Clicked(object sender, EventArgs e)
        {
            Entry txtProduto = this.FindByName<Entry>("txtProduto");
            Entry txtValor = this.FindByName<Entry>("txtValor");
            Picker pkrPessoa = this.FindByName<Picker>("pkrPessoa");

            //Utiliza o objeto Pedido da tela
            pedido.Produto = txtProduto.Text;
            pedido.Valor = Convert.ToDecimal(txtValor.Text);
            //pedido.Pessoa = pkrPessoa.GetValue();

            AcessoDados ac = new AcessoDados();
            ac.InsertPedido(pedido);

            DisplayAlert("Sucesso", "Pedido inserido com sucesso!", "OK");
        }

    }
}