namespace maUI_programacao_visual.Views.Aula04.exercício1;

public partial class Pagina2 : ContentPage
{
    public Pagina2(string textoDigitado)
    {
        InitializeComponent();
        LabelExibicao.Text = textoDigitado;
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}