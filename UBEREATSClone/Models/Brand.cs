namespace UberEATSClone.Models
{
    public class Brand
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string DeliveryTime { get; set; }
        public string ImageUrl { get; set; }
    }

    public class MenuItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public int Quantity { get; set; } = 1;
    }
}