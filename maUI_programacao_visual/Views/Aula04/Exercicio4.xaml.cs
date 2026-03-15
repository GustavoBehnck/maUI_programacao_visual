namespace maUI_programacao_visual.Views.Aula04;

public partial class Exercicio4 : ContentPage
{
	public Exercicio4()
	{
		InitializeComponent();
	}
    private void OnSwitchToggled(object sender, ToggledEventArgs e)
    {
        bool active_state = e.Value;

        Check1.IsEnabled = active_state;
        Check2.IsEnabled = active_state;
        Check3.IsEnabled = active_state;
    }
}