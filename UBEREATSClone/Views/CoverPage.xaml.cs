namespace UberEATSClone.Views;

public partial class CoverPage : ContentPage
{
    public CoverPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BrandsPage());
    }
}
