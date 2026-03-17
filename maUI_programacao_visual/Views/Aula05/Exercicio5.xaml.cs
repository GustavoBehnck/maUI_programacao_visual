namespace maUI_programacao_visual.Views.Aula05;

public partial class Exercicio5 : ContentPage
{
	public Exercicio5()
	{
		InitializeComponent();
	}
    private void OnSliderChanged(object sender, ValueChangedEventArgs e)
    {
        LabelVelocidade.Text = $"{(int)e.NewValue} MB/s";
        CalcularTempoEstimado();
    }

    private void OnStepperChanged(object sender, ValueChangedEventArgs e)
    {
        LabelTamanho.Text = $"{e.NewValue} MB";
        CalcularTempoEstimado();
    }

    private void CalcularTempoEstimado()
    {
        double tamanho = StepperTamanho.Value;
        double velocidade = SliderVelocidade.Value;
        double segundos = tamanho / velocidade;

        TimeSpan tempo = TimeSpan.FromSeconds(segundos);
        LabelTempoEstimado.Text = $"Tempo estimado: {tempo.Minutes}m {tempo.Seconds}s";
    }

    private async void OnIniciarDownloadClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EditorNome.Text))
        {
            await DisplayAlert("Atenção", "Digite o nome do arquivo primeiro.", "OK");
            return;
        }

        BtnDownload.IsEnabled = false;
        double tamanhoTotal = StepperTamanho.Value;
        double velocidade = SliderVelocidade.Value;
        double baixado = 0;

        BarraProgresso.Progress = 0;

        while (baixado < tamanhoTotal)
        {
            await Task.Delay(1);

            baixado += (velocidade / 10);

            double porcentagem = baixado / tamanhoTotal;
            await BarraProgresso.ProgressTo(Math.Min(porcentagem, 1), 100, Easing.Linear);

            LabelStatus.Text = $"Baixando: {baixado:F1} de {tamanhoTotal} MB";
        }

        LabelStatus.Text = "Download concluído com sucesso!";
        await DisplayAlert("Concluído", $"O arquivo '{EditorNome.Text}' foi baixado.", "OK");

        BtnDownload.IsEnabled = true;
    }
}