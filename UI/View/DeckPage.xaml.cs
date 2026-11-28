namespace UI;

public partial class DeckPage : ContentPage
{
    public DeckPage()
    {
        InitializeComponent();
        BindingContext = new DeckViewModel();
    }

    private async void OnBackToDecksTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}