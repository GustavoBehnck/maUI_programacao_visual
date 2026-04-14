namespace maUI_programacao_visual.Views.Revisao_para_Prova;
using System.Text.Json;

public class Pessoa
{
    public string nome { get; set; }
    public string nascimento { get; set; }
    public double peso { get; set; }
    public double altura { get; set; }
}

public partial class aula06_ex1 : ContentPage
{
    List<Pessoa> listaPessoas;

    public aula06_ex1()
	{
		InitializeComponent();
        CarregarDados();
    }

    private async Task CarregarDados()
    {
        try
        {
            string caminho = "C:\\Users\\behnck\\source\\repos\\maUI_programacao_visual\\maUI_programacao_visual\\Views\\Revisao_para_Prova\\aula06.json";

            string json = await File.ReadAllTextAsync(caminho);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            listaPessoas = JsonSerializer.Deserialize<List<Pessoa>>(json, options);

            if (listaPessoas != null && listaPessoas.Any())
            {
                pickerPessoas.ItemsSource = listaPessoas;
                CalcularEstatisticas();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        if (picker.SelectedIndex != -1)
        {
            var p = (Pessoa)picker.SelectedItem;
            LabelDetalhes.Text = $"Nome: {p.nome}\nPeso: {p.peso}kg\nAltura: {p.altura}m";
        }
    }

    private void CalcularEstatisticas()
    {
        if (listaPessoas == null || !listaPessoas.Any()) return;

        double mediaAltura = listaPessoas.Average(p => p.altura);

        double mediaIdade = listaPessoas.Average(p => {
            if (DateTime.TryParse(p.nascimento, out DateTime dataNasc))
            {
                int idade = DateTime.Now.Year - dataNasc.Year;
                if (DateTime.Now.DayOfYear < dataNasc.DayOfYear) idade--;
                return idade;
            }
            return 0;
        });

        var alturas = listaPessoas.Select(p => p.altura).OrderBy(a => a).ToList();
        int n = alturas.Count;
        double mediana = (n % 2 == 0)
            ? (alturas[(n / 2) - 1] + alturas[n / 2]) / 2
            : alturas[n / 2];

        double somaQuadrados = listaPessoas.Sum(p => Math.Pow(p.altura - mediaAltura, 2));
        double desvioPadrao = Math.Sqrt(somaQuadrados / n);

        LabelMediaAltura.Text = $"Média Altura: {mediaAltura:F2} m";
        LabelMediaIdade.Text = $"Média Idade: {mediaIdade:F1} anos";
        LabelMediana.Text = $"Mediana (Altura): {mediana:F2} m";
        LabelDesvioPadrao.Text = $"Desvio Padrão (Altura): {desvioPadrao:F4}";
    }
}