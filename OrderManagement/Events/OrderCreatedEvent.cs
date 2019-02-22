using ReactiveDomain.Messaging;
using System;

namespace OrderManagement.Events
{
    public class OrderCreatedEvent : Message
    {
        public Guid Id { get; set; }
        public string Action { get; set; }
        public int Quantity { get; set; }
        public string Asset { get; set; }
        public float Price { get; set; }

        public OrderCreatedEvent(Guid id, string action, int quantity, string asset, float price)
        {
            Id = id;
            Action = action;
            Quantity = quantity;
            Asset = asset;
            Price = price;
        }
    }
}
