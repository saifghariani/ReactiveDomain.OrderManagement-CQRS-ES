﻿using System;
using OrderManagement.Domain.Events;
using ReactiveDomain;

namespace OrderManagement.Domain
{
    public class OrderAggregate : EventDrivenStateMachine
    {
        public string Action { get; set; }
        public int Quantity { get; set; }
        public string Asset { get; set; }
        public float Price { get; set; }

        public OrderAggregate()
        {
            setup();
        }

        public OrderAggregate(Guid id, string action, int quantity, string asset, float price):this()
        {
            Raise(new OrderCreatedEvent(id, action, quantity, asset, price));
        }

        private void setup()
        {
            Register<OrderCreatedEvent>(evt =>
            {
                Id = evt.Id;
                Action = evt.Action;
                Quantity = evt.Quantity;
                Asset = evt.Asset;
                Price = evt.Price;
            });
        }

    }
}
