using UberEATSClone.Models;

namespace UberEATSClone.Views
{
    internal class BrandDetailsPage : Page
    {
        private Brand selectedBrand;

        public BrandDetailsPage(Brand selectedBrand)
        {
            this.selectedBrand = selectedBrand;
        }
    }
}