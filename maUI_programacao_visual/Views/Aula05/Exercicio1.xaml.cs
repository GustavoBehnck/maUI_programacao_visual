namespace maUI_programacao_visual.Views.Aula05;

public partial class Exercicio1 : ContentPage
{
	public Exercicio1()
	{
		InitializeComponent();
	}

    private void OnAlturaChanged(object sender, ValueChangedEventArgs e)
    {
        LabelAltura.Text = $"{e.NewValue:F2} m";
    }

    private void OnPesoChanged(object sender, ValueChangedEventArgs e)
    {
        LabelPeso.Text = $"{e.NewValue:F1} kg";
    }

    private void OnCalcularClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EntryNome.Text))
        {
            DisplayAlert("Erro", "Por favor, insira o nome.", "OK");
            return;
        }

        double altura = SliderAltura.Value;
        double peso = StepperPeso.Value;

        double imc = peso / Math.Pow(altura, 2);

        string classificacao = ObterClassificacao(imc);
        AtualizarInterface(imc, classificacao);
    }

    private string ObterClassificacao(double imc)
    {
        if (imc < 18.5) return "Abaixo do peso";
        if (imc < 25.0) return "Peso normal";
        if (imc < 30.0) return "Sobrepeso";
        if (imc < 35.0) return "Obesidade grau I";
        if (imc < 40.0) return "Obesidade grau II";
        return "Obesidade grau III";
    }

    private void AtualizarInterface(double imc, string classificacao)
    {
        double progresso = (imc - 15) / (45 - 15);
        ProgressImc.Progress = Math.Clamp(progresso, 0, 1);

        if (imc < 18.5 || imc >= 30) ProgressImc.ProgressColor = Colors.Red;
        else if (imc < 25) ProgressImc.ProgressColor = Colors.Green;
        else ProgressImc.ProgressColor = Colors.Orange;

        LabelResultado.Text = $"Olá {EntryNome.Text}!\n" +
                              $"Seu IMC é: {imc:F2}\n" +
                              $"Classificação: {classificacao}\n" +
                              $"Obs: {EditorObs.Text}";
    }
}