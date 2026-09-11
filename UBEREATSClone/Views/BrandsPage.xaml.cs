using System.Collections.ObjectModel;
using UberEATSClone.Models;

namespace UberEATSClone.Views;

public partial class BrandsPage : ContentPage
{
    public ObservableCollection<Brand> Brands { get; set; } = new ObservableCollection<Brand>
    {
                new Brand { Name = "KFC", Category = "Fast Food", DeliveryTime = "20–30 min • R 15.00 delivery", ImageUrl = "https://images.unsplash.com/photo-1626082927389-6cd097cdc6ec" },
                new Brand { Name = "Game", Category = "Retail & Electronics", DeliveryTime = "45–60 min • R 35.00 delivery", ImageUrl = "https://images.unsplash.com/photo-1555529771-835f59fc5efe" },
                new Brand { Name = "Pick n Pay", Category = "Groceries", DeliveryTime = "30–45 min • R 20.00 delivery", ImageUrl = "https://images.unsplash.com/photo-1542838132-92c53300491e" }
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