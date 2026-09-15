using System.Collections.ObjectModel;
using UberEATSClone.Models;

namespace UberEATSClone.Views;

public partial class BrandsPage : ContentPage
{
    public ObservableCollection<Brand> Brands { get; set; } = new ObservableCollection<Brand>
    {
                new Brand { Name = "KFC", Category = "Fast Food", DeliveryTime = "20–30 min • R 15.00 delivery", ImageUrl = "kfc.png" },
                new Brand { Name = "Game", Category = "Retail & Electronics", DeliveryTime = "45–60 min • R 35.00 delivery", ImageUrl = "game.png" },
                new Brand { Name = "Pick n Pay", Category = "Groceries", DeliveryTime = "30–45 min • R 20.00 delivery", ImageUrl = "pickandpay.png" }
            };
    public BrandsPage()
    {
        InitializeComponent();
    }

    private async void BrandsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Brand selectedBrand)
        {
            await Navigation.PushAsync(new BrandDetailsPage(selectedBrand));
        }
    }
}