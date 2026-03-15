namespace maUI_programacao_visual.Views.Aula04;

public partial class Exercicio2 : ContentPage
{
    List<string> opcoes = new List<string> { "C#", "Python", "Java", "JavaScript", "Bash" };
    List<string> selected = new List<string>();
    public Exercicio2()
	{
		InitializeComponent();
        GerarCheckBoxes();
    }
    private void GerarCheckBoxes()
    {
        foreach (var opcao in opcoes)
        {
            var stack = new HorizontalStackLayout { Spacing = 10 };

            var cb = new CheckBox();
            var lbl = new Label { Text = opcao, VerticalOptions = LayoutOptions.Center };

            cb.CheckedChanged += (s, e) =>
            {
                if (e.Value)
                {
                    if (selected.Count < 3)
                    {
                        selected.Add(opcao);
                    }
                    else
                    {

                        ((CheckBox)s).IsChecked = false;
                        DisplayAlert("Limite", "Você só pode selecionar 3 opções.", "OK");
                        return;
                    }
                }
                else
                {
                    selected.Remove(opcao);
                }

                UpdateLabel();
            };

            stack.Children.Add(cb);
            stack.Children.Add(lbl);

            ContainerCheckBoxes.Children.Add(stack);
        }
    }

    private void UpdateLabel()
    {
        if (selected.Count == 0)
            LabelResultado.Text = "Selecionados: Nenhum";
        else
            LabelResultado.Text = "Selecionados: " + string.Join(", ", selected);
    }
}