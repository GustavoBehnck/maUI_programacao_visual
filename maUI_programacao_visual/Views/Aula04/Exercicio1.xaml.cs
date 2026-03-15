namespace maUI_programacao_visual.Views.Aula04;

public partial class Exercicio1 : ContentPage
{
	public Exercicio1()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(10);

        var targetPage = new Views.Aula04.exercício1.Pagina1();
        await Navigation.PushAsync(targetPage);
        Navigation.RemovePage(this);
    }
}