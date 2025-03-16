using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>(); 
	public ListaProduto()
	{
		InitializeComponent();

        lst_produtos.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
        List<Produto> tmp = await App.Db.GetAll();

        tmp.ForEach( x => lista.Add(x));
    }
    private void Somar_Clicked(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Total);

        string msg = $"O total é {soma:C}";

        DisplayAlert("Total dos Produtos", msg, "OK");
    }

    private void Adicionar_Clicked(object sender, EventArgs e)
    {
        try {
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Ok");
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;

        lista.Clear();

        List<Produto> tmp = await App.Db.Search(q);

        tmp.ForEach(x => lista.Add(x));
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}