namespace maUI_programacao_visual.Views.Aula05;

public partial class Exercicio3 : ContentPage
{
	public Exercicio3()
	{
		InitializeComponent();
	}
    private void OnSliderTaxaChanged(object sender, ValueChangedEventArgs e)
    {
        LabelTaxa.Text = $"{e.NewValue:F0}%";
    }

    private void OnStepperAnosChanged(object sender, ValueChangedEventArgs e)
    {
        LabelAnos.Text = e.NewValue.ToString();
    }

    private async void OnSimularClicked(object sender, EventArgs e)
    {

        if (!double.TryParse(EditorPopInicial.Text, out double populacaoAtual))
        {
            await DisplayAlert("Erro", "Insira um número válido para a população inicial.", "OK");
            return;
        }

        int totalAnos = (int)StepperAnos.Value;
        double taxaCrescimento = SliderTaxa.Value / 100;

        BarraEvolucao.Progress = 0;
        LabelResultado.Text = "Simulando...";

        for (int ano = 1; ano <= totalAnos; ano++)
        {
            populacaoAtual += (populacaoAtual * taxaCrescimento);

            double progresso = (double)ano / totalAnos;
            await BarraEvolucao.ProgressTo(progresso, 100, Easing.Linear);


            await Task.Delay(50);
        }

        LabelResultado.Text = $"População Final após {totalAnos} anos:\n" +
                              $"{Math.Round(populacaoAtual):N0} habitantes";

    }
}