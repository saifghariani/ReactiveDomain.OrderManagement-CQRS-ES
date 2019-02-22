
using System;
using Newtonsoft.Json;

namespace OrderManagement
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Action { get; set; }
        public int Quantity { get; set; }
        public string Asset { get; set; }
        public float Price { get; set; }

        public Order()
        {
            
        }
        [JsonConstructor]
        public Order(Guid id, string action, int quantity, string asset, float price)
        {
            Id = id;
            Action = action;
            Quantity = quantity;
            Asset = asset;
            Price = price;
        }
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