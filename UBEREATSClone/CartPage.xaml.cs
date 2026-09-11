using UberEATSClone.Services;

namespace UberEATSClone.Views
{
    public partial class CartPage : ContentPage
    {
        private const decimal DeliveryFee = 15;

        public CartPage()
        {
            InitializeComponent();

            LoadCart();
        }

        private void LoadCart()
        {
            CartCollectionView.ItemsSource = null;
            CartCollectionView.ItemsSource = CartService.Items;

            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal subtotal = CartService.GetSubtotal();

            decimal total = subtotal;

            if (CartService.Items.Count > 0)
            {
                total += DeliveryFee;
            }

            SubtotalLabel.Text = $"R{subtotal:F2}";
            DeliveryLabel.Text = $"R{DeliveryFee:F2}";
            TotalLabel.Text = $"R{total:F2}";
        }

        private void IncreaseQuantity_Clicked(object sender,EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Models.MenuItemModel item)
            {
                CartService.IncreaseQuantity(item);

                LoadCart();
            }
        }

        private void DecreaseQuantity_Clicked( object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Models.MenuItemModel item)
            {
                CartService.DecreaseQuantity(item);

                LoadCart();
            }
        }

        private void RemoveItem_Clicked(object sender,EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Models.MenuItemModel item)
            {
                CartService.RemoveItem(item);

                LoadCart();
            }
        }

        private async void Checkout_Clicked( object sender, EventArgs e)
        {
            if (CartService.Items.Count == 0)
            {
                await DisplayAlert("Empty Cart","Please add an item before checking out.","OK");

                return;
            }

            await Navigation.PushAsync( new CheckoutPage());
        }
    }
}