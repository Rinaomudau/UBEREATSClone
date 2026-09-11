using System.Collections.ObjectModel;
using UberEATSClone.Models;
using UberEATSClone.Views;

namespace UberEATSClone
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Brand> Brands { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // My stores and restuarant 
            Brands = new ObservableCollection<Brand>
            {
                new Brand { Name = "KFC", Category = "Fast Food", DeliveryTime = "20–30 min • R 15.00 delivery", ImageUrl ="kfc.png" },
                
                new Brand { Name = "Game", Category = "Retail & Electronics", DeliveryTime = "45–60 min • R 35.00 delivery", ImageUrl = "game.png" },
                new Brand { Name = "Pick n Pay", Category = "Groceries", DeliveryTime = "30–45 min • R 20.00 delivery", ImageUrl = 
                "pickandpay.png" }
            };

            
            BrandsCollectionView.ItemsSource = Brands;
        }

        private async void OnBrandSelected(object sender, SelectionChangedEventArgs e)
        {
            
            if (e.CurrentSelection.FirstOrDefault() is Brand selectedBrand)
            {
                await Navigation.PushAsync(new BrandMenuPage(selectedBrand));
                BrandsCollectionView.SelectedItem = null; 
            }
        }
    }
}