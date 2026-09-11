using UberEATSClone.Services;

namespace UberEATSClone.Views
{
    public partial class CheckoutPage : ContentPage
    {
        private const decimal DeliveryFee = 15;

        public CheckoutPage()
        {
            InitializeComponent();

            UpdateSummary();
        }

        private void UpdateSummary()
        {
            decimal subtotal = CartService.GetSubtotal();

            decimal deliveryFee = DeliveryRadio.IsChecked ? DeliveryFee: 0;

            decimal total = subtotal + deliveryFee;

            SubtotalLabel.Text = $"Subtotal: R{subtotal:F2}";

            DeliveryFeeLabel.Text =  DeliveryRadio.IsChecked  ? $"Delivery: R{deliveryFee:F2}"  : "Pick Up: R0.00";

            TotalLabel.Text = $"Total: R{total:F2}";
        }

        // You have to choose between delivery or pick up 

        private void OrderType_CheckedChanged(object sender,CheckedChangedEventArgs e)
        {
            if (!e.Value)
                return;

            AddressLayout.IsVisible = DeliveryRadio.IsChecked;

            UpdateSummary();
        }

        

        private void PaymentMethod_CheckedChanged(object sender,CheckedChangedEventArgs e)
        {
            if (!e.Value)
                return;

            CardDetailsLayout.IsVisible = CardRadio.IsChecked;

            CashDetailsLayout.IsVisible = CashRadio.IsChecked;
        }

        private async void PlaceOrder_Clicked( object sender, EventArgs e)
        {
            // delivery address
            if (DeliveryRadio.IsChecked &&string.IsNullOrWhiteSpace(AddressEntry.Text))
            {
                await DisplayAlert( "Address Required", "Please enter your delivery address.", "OK");

                return;
            }

            // card
            if (CardRadio.IsChecked)
            {
                if (string.IsNullOrWhiteSpace( CardholderNameEntry.Text))
                {
                    await DisplayAlert( "Card Details Required", "Please enter the cardholder name.", "OK");

                    return;
                }

                if (string.IsNullOrWhiteSpace( CardNumberEntry.Text) || CardNumberEntry.Text.Length < 16)
                {
                    await DisplayAlert( "Invalid Card Number", "Please enter a 16-digit demo card number.", "OK");

                    return;
                }

                if (string.IsNullOrWhiteSpace(ExpiryEntry.Text))
                {
                    await DisplayAlert( "Expiry Date Required", "Please enter the card expiry date.","OK");

                    return;
                }

                if (string.IsNullOrWhiteSpace(CvvEntry.Text) || CvvEntry.Text.Length < 3)
                {
                    await DisplayAlert("CVV Required","Please enter a 3-digit demo CVV.", "OK");

                    return;
                }
            }

            decimal subtotal =CartService.GetSubtotal();

            decimal deliveryFee =  DeliveryRadio.IsChecked ? DeliveryFee : 0;

            decimal total = subtotal + deliveryFee;

            string orderType = DeliveryRadio.IsChecked ? "Delivery" : "Pick Up";

            string paymentMethod = CardRadio.IsChecked ? "Card" : "Cash";

            await Navigation.PushAsync(new OrderConfirmationPage( orderType, paymentMethod, total));
        }
    }
}