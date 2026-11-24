namespace UI;

public partial class DeckPage : ContentPage
{
    public DeckPage()
    {
        InitializeComponent();
    }

    private async void OnBackToDecksTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}