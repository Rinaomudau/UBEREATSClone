using System.Collections.ObjectModel;
using UberEATSClone.Models;

namespace UberEATSClone.Services
{
    public static class CartService
    {
        public static ObservableCollection<MenuItemModel> Items { get; }
            = new ObservableCollection<MenuItemModel>();

        public static void AddItem(MenuItemModel item)
        {
            var existingItem = Items.FirstOrDefault(
                x => x.Name == item.Name);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                item.Quantity = 1;
                Items.Add(item);
            }
        }

        public static void RemoveItem(MenuItemModel item)
        {
            Items.Remove(item);
        }

        public static void IncreaseQuantity(MenuItemModel item)
        {
            item.Quantity++;
        }

        public static void DecreaseQuantity(MenuItemModel item)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                Items.Remove(item);
            }
        }

        public static decimal GetSubtotal()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }

        public static void ClearCart()
        {
            Items.Clear();
        }
    }
}