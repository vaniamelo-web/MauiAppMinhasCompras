using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class Relatorio : ContentPage
{
	public Relatorio()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            DateTime dataInicial = (DateTime)dtpck_inicial.Date;
            DateTime dataFinal = (DateTime)dtpck_final.Date;

            List<Produto> produtos = await App.Db.GetByDate(dataInicial, dataFinal);

            lista_relatorio.ItemsSource = produtos;

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}