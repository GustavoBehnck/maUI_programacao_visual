namespace maUI_programacao_visual.Views.Aula04;

public partial class Exercicio5 : ContentPage
{
	public Exercicio5()
	{
		InitializeComponent();
	}
    private async void OnConfirmarClicked(object sender, EventArgs e)
    {
        LimparValidacao();

        bool erro = false;
        string mensagemErro = "Campos obrigatórios: ";

        if (string.IsNullOrWhiteSpace(EntryNome.Text))
        {
            ContainerNome.BackgroundColor = Colors.Red;
            mensagemErro += "Nome, ";
            erro = true;
        }

        if (!RadM.IsChecked && !RadF.IsChecked && !RadO.IsChecked)
        {
            ContainerGenero.BackgroundColor = Colors.Red;
            mensagemErro += "Gênero, ";
            erro = true;
        }

        if (!CheckTec.IsChecked && !CheckArt.IsChecked && !CheckEsp.IsChecked)
        {
            ContainerInteresses.BackgroundColor = Colors.Red;
            mensagemErro += "Interesses, ";
            erro = true;
        }

        if (erro)
        {
            LabelErro.Text = mensagemErro.TrimEnd(' ', ',');
            LabelErro.IsVisible = true;
        }
        else
        {
            string genero = RadM.IsChecked ? "Masculino" : RadF.IsChecked ? "Feminino" : "Outro";
            string interesses = "";
            if (CheckTec.IsChecked) interesses += "Tecnologia ";
            if (CheckArt.IsChecked) interesses += "Artes ";
            if (CheckEsp.IsChecked) interesses += "Esportes ";

            string news = SwitchNews.IsToggled ? "Sim" : "Não";

            string resumo = $"Nome: {EntryNome.Text}\n" +
                           $"Gênero: {genero}\n" +
                           $"Interesses: {interesses}\n" +
                           $"Newsletter: {news}";

            await DisplayAlert("Sucesso!", resumo, "OK");
        }
    }

    private void LimparValidacao()
    {
        ContainerNome.BackgroundColor = Colors.Transparent;
        ContainerGenero.BackgroundColor = Colors.Transparent;
        ContainerInteresses.BackgroundColor = Colors.Transparent;
        LabelErro.IsVisible = false;
    }
}