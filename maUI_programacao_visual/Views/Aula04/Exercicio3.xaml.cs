namespace maUI_programacao_visual.Views.Aula04;

public partial class Exercicio3 : ContentPage
{
	public Exercicio3()
	{
		InitializeComponent();
	}
    private void OnCorChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton rb && e.Value)
        {
            string corNome = rb.Content.ToString();
            LabelCorStatus.Text = corNome;

            switch (corNome)
            {
                case "Vermelho":
                    LabelCorStatus.TextColor = Colors.Red;
                    break;
                case "Azul":
                    LabelCorStatus.TextColor = Colors.Blue;
                    break;
                case "Verde":
                    LabelCorStatus.TextColor = Colors.Green;
                    break;
                default:
                    LabelCorStatus.TextColor = Colors.Black;
                    break;
            }
        }
    }
}