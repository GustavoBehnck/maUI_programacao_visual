using Microsoft.Maui.Controls.Shapes;
using System.Reflection;

namespace maUI_programacao_visual;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        GerarMenuDinamicamente();
    }

    private void GerarMenuDinamicamente()
    {
        ContainerAulas.Children.Clear();

        var assembly = Assembly.GetExecutingAssembly();

        string namespaceRaiz = "maUI_programacao_visual.Views";
        int profundidadeEsperada = namespaceRaiz.Split('.').Length + 1;

        var aulasAgrupadas = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ContentPage)))
            .Where(t => t.Namespace != null && t.Namespace.StartsWith(namespaceRaiz))
            .Where(t => t.Namespace.Split('.').Length == profundidadeEsperada)
            .GroupBy(t => t.Namespace.Split('.').Last())
            .OrderBy(g => g.Key);

        foreach (var aula in aulasAgrupadas)
        {
            var border = new Border
            {
                Padding = 15,
                Stroke = Colors.Gray,
                StrokeThickness = 1,
                StrokeShape = new RoundRectangle { CornerRadius = 10 }
            };

            var stackLayout = new VerticalStackLayout { Spacing = 10 };

            stackLayout.Children.Add(new Label { Text = aula.Key, FontSize = 22, FontAttributes = FontAttributes.Bold });

            foreach (var pagina in aula)
            {
                var btn = new Button
                {
                    Text = pagina.Name,
                    BackgroundColor = Color.FromArgb("#512BD4"),
                    TextColor = Colors.White
                };

                btn.Clicked += async (sender, args) =>
                {
                    if (Activator.CreateInstance(pagina) is Page pageInstance)
                    {
                        await Navigation.PushAsync(pageInstance);
                    }
                };

                stackLayout.Children.Add(btn);
            }

            border.Content = stackLayout;
            ContainerAulas.Children.Add(border);
        }
    }
}