
namespace OrderManagement.Domain
{
    public class Order
    {
        public string Action { get; set; }
        public int Quantity { get; set; }
        public string Asset { get; set; }
        public float Price { get; set; }

        public Order(string action, int quantity, string asset, float price)
        {
            Action = action;
            Quantity = quantity;
            Asset = asset;
            Price = price;
        }

        public override string ToString()
        {
            return $"Order to {Action} {Quantity} {Asset} at the price of {Price}";
        }
    }
}