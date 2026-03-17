using System.Text.RegularExpressions;

namespace maUI_programacao_visual.Views.Aula05;

public partial class Exercicio4 : ContentPage
{
	public Exercicio4()
	{
		InitializeComponent();
	}
    private void OnSliderChanged(object sender, ValueChangedEventArgs e)
    {
        LabelSlider.Text = ((int)e.NewValue).ToString();
    }

    private void OnStepperChanged(object sender, ValueChangedEventArgs e)
    {
        LabelStepper.Text = e.NewValue.ToString();
    }

    private async void OnAnalisarClicked(object sender, EventArgs e)
    {
        string textoBruto = EditorTexto.Text;

        if (string.IsNullOrWhiteSpace(textoBruto))
        {
            await DisplayAlert("Erro", "O texto está vazio!", "OK");
            return;
        }

        var matches = Regex.Matches(textoBruto, @"\w+");
        var todasAsPalavras = matches.Cast<Match>().Select(m => m.Value).ToList();

        int limiteAnalise = (int)StepperLimite.Value;
        int tamanhoMinimo = (int)SliderMinimo.Value;

        int palavrasParaProcessar = Math.Min(limiteAnalise, todasAsPalavras.Count);

        List<string> palavrasFiltradas = new List<string>();
        BarraProgresso.Progress = 0;

        for (int i = 0; i < palavrasParaProcessar; i++)
        {
            string palavraAtual = todasAsPalavras[i];

            if (palavraAtual.Length >= tamanhoMinimo)
            {
                palavrasFiltradas.Add(palavraAtual);
            }

            double progresso = (double)(i + 1) / palavrasParaProcessar;
            await BarraProgresso.ProgressTo(progresso, 10, Easing.Linear);
        }

        LabelContagem.Text = $"Total lido: {palavrasParaProcessar} | Maiores que {tamanhoMinimo} letras: {palavrasFiltradas.Count}";
        EditorResultado.Text = string.Join(", ", palavrasFiltradas);
    }
}