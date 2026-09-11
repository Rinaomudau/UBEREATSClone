using UberEATSClone.Services;

namespace UberEATSClone.Views
{
    public partial class OrderConfirmationPage : ContentPage
    {
        public OrderConfirmationPage( string orderType, string paymentMethod, decimal total)
        {
            InitializeComponent();

            OrderTypeLabel.Text = $"Order Type: {orderType}";

            PaymentLabel.Text =  $"Payment: {paymentMethod}";

            TotalLabel.Text = $"Total Paid: R{total:F2}";
        }

        private async void Home_Clicked( object sender,EventArgs e)
        {
            CartService.ClearCart();

            await Navigation.PopToRootAsync();
        }
    }
}