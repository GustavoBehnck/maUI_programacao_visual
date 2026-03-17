namespace maUI_programacao_visual.Views.Aula05;

public partial class Exercicio6 : ContentPage
{
	public Exercicio6()
	{
		InitializeComponent();
	}
    private void OnStepperChanged(object sender, ValueChangedEventArgs e)
    {
        LabelQtde.Text = e.NewValue.ToString();
    }

    private void OnSliderChanged(object sender, ValueChangedEventArgs e)
    {
        LabelMaximoSlider.Text = ((int)e.NewValue).ToString();
    }

    private async void OnGerarClicked(object sender, EventArgs e)
    {
        int quantidade = (int)StepperQtde.Value;
        int valorMaximo = (int)SliderIntervalo.Value;

        List<int> numeros = new List<int>();
        Random random = new Random();

        EditorNumeros.Text = string.Empty;
        BarraProgresso.Progress = 0;

        for (int i = 0; i < quantidade; i++)
        {
            int novoNumero = random.Next(0, valorMaximo + 1);
            numeros.Add(novoNumero);

            double progresso = (double)(i + 1) / quantidade;
            await BarraProgresso.ProgressTo(progresso, 50, Easing.Linear);
        }

        EditorNumeros.Text = string.Join(", ", numeros);

        if (numeros.Any())
        {
            double media = numeros.Average();
            int max = numeros.Max();
            int min = numeros.Min();

            LabelMedia.Text = $"Média: {media:F2}";
            LabelMax.Text = $"Valor Máximo: {max}";
            LabelMin.Text = $"Valor Mínimo: {min}";
        }
    }
}