namespace UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(DeckPage), typeof(DeckPage));
    }
}
