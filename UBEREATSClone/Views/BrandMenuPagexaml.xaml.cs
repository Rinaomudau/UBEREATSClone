using UberEATSClone.Models;
using UberEATSClone.Services;

namespace UberEATSClone.Views
{
    public partial class BrandMenuPage : ContentPage
    {
        public BrandMenuPage(Brand brand)
        {
            InitializeComponent();

            BrandTitleLabel.Text = brand.Name;

            BrandSubtitleLabel.Text = $"{brand.Category} • {brand.DeliveryTime}";

            List<MenuItemModel> items;

            if (brand.Name == "KFC")
            {
                items = new List<MenuItemModel>
                {
                    new MenuItemModel
                    {
                        Name = "Original Chicken",
                        Description = "Crispy KFC chicken",
                        Price = 45,
                        ImageUrl = "kfc_chicken.jpg"
                    },

                    new MenuItemModel
                    {
                        Name = "Zinger Burger",
                        Description = "Spicy chicken burger",
                        Price = 55,
                        ImageUrl = "kfc_zinger.jpg"
                    },

                    new MenuItemModel
                    {
                        Name = "Regular Chips",
                        Description = "Crispy golden chips",
                        Price = 30,
                        ImageUrl = "kfc_chips.jpg"
                    }
                };
            }

            else if (brand.Name == "Game")
            {
                items = new List<MenuItemModel>
                {
                    new MenuItemModel
                    {
                        Name = "Smartphone",
                        Description = "Modern smartphone",
                        Price = 2499,
                        ImageUrl = "game_phone.jpg"
                    },

                    new MenuItemModel
                    {
                        Name = "Wireless Headphones",
                        Description = "Bluetooth headphones",
                        Price = 599,
                        ImageUrl = "game_headphones.jpg"
                    },

                    new MenuItemModel
                    {
                        Name = "Smart TV",
                        Description = "Large screen Smart TV",
                        Price = 4999,
                        ImageUrl = "game_tv.jpg"
                    }
                };
            }

            else
            {
                items = new List<MenuItemModel>
                {
                    new MenuItemModel
                    {
                        Name = "Fresh Fruit Pack",
                        Description = "Selection of fresh fruit",
                        Price = 49,
                        ImageUrl = "pnp_fruit.jpg"
                    },

                    new MenuItemModel
                    {
                        Name = "Full Cream Milk",
                        Description = "Fresh full cream milk",
                        Price = 25,
                        ImageUrl = "pnp_milk.jpg"
                    },

                    new MenuItemModel
                    {
                        Name = "White Bread",
                        Description = "Fresh white bread",
                        Price = 18,
                        ImageUrl = "pnp_bread.jpg"
                    }
                };
            }

            MenuItemsCollectionView.ItemsSource = items;
        }

        private async void AddToCart_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is MenuItemModel item)
            {
                CartService.AddItem(item);

                await DisplayAlert( "Added to Cart", $"{item.Name} was added to your cart.",   "OK");

                UpdateCartButton();
            }
        }

        private void UpdateCartButton()
        {
            int quantity = CartService.Items.Sum(x => x.Quantity);

            CartButton.Text = $"🛒 Cart ({quantity})";
        }

        private async void CartButton_Clicked( object sender, EventArgs e)
        {
            await Navigation.PushAsync( new CartPage());
        }
    }
}