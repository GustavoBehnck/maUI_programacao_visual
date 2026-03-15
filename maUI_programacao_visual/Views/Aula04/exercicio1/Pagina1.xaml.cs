namespace maUI_programacao_visual.Views.Aula04.exercício1;

public partial class Pagina1 : ContentPage
{
    public Pagina1()
    {
        InitializeComponent();
    }

    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        string texto = EntryTexto.Text;
        await Navigation.PushAsync(new Pagina2(texto));
    }
}