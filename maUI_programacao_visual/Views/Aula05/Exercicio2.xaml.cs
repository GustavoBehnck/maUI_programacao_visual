namespace maUI_programacao_visual.Views.Aula05;

public partial class Exercicio2 : ContentPage
{
	public Exercicio2()
	{
		InitializeComponent();
	}
    private void OnStepperChanged(object sender, ValueChangedEventArgs e)
    {
        LabelQtde.Text = e.NewValue.ToString();
    }

    private async void OnCalcularClicked(object sender, EventArgs e)
    {
        string texto = EditorNumeros.Text;

        if (string.IsNullOrWhiteSpace(texto))
        {
            await DisplayAlert("Erro", "Insira alguns números primeiro.", "OK");
            return;
        }

        string[] partes = texto.Split(',');
        List<double> numerosValidos = new List<double>();

        foreach (var p in partes)
        {
            if (double.TryParse(p.Trim(), out double num))
            {
                numerosValidos.Add(num);
            }
        }

        int quantidadeParaCalcular = (int)StepperQtde.Value;
        int totalEncontrado = numerosValidos.Count;

        if (totalEncontrado == 0)
        {
            await DisplayAlert("Erro", "Nenhum número válido foi detectado.", "OK");
            return;
        }

        if (quantidadeParaCalcular > totalEncontrado)
        {
            quantidadeParaCalcular = totalEncontrado;
        }

        double soma = 0;
        for (int i = 0; i < quantidadeParaCalcular; i++)
        {
            soma += numerosValidos[i];
        }

        double media = soma / quantidadeParaCalcular;

        double progresso = (double)quantidadeParaCalcular / totalEncontrado;
        await BarraProgresso.ProgressTo(progresso, 500, Easing.Linear);

        LabelResultado.Text = $"Média dos {quantidadeParaCalcular} primeiros valores: {media:F2}\n" +
                              $"(Total de números válidos lidos: {totalEncontrado})";
    }
}