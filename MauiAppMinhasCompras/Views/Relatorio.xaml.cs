using MauiAppMinhasCompras.Models; // Assuming you have a Models folder
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiAppMinhasCompras.Views
{
    public partial class Relatorio : ContentPage
    {
        ObservableCollection<TotalCategora> lista = new ObservableCollection<TotalCategora>();
        public Relatorio()
        {
            InitializeComponent();

            // Associar a CollectionView a lista de produtos
            Rel_produtos.ItemsSource = lista;
        }

        protected async override void OnAppearing()
        {
            try
            {
                lista.Clear();
                List<TotalCategora> tmp = await App.Db.GetCategoria();
                //await DisplayAlert("tmp", tmp, "Ok");
                tmp.ForEach(x => lista.Add(x));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }

}
