using OrderManagement.Events;
using ReactiveDomain.Foundation;
using ReactiveDomain.Messaging.Bus;
using System;
using System.Collections.Generic;

namespace OrderManagement
{
    public class OrderReadModel : ReadModelBase
        , IHandle<OrderCreatedEvent>
    {
        public List<Order> Orders = new List<Order>();
        public OrderReadModel(Func<IListener> getListener) : base(getListener)
        {
            EventStream.Subscribe<OrderCreatedEvent>(this);
            Start<OrderAggregate>(null, true);
        }

        public void Handle(OrderCreatedEvent message)
        {
            var order = new Order(message.Id,message.Action,message.Quantity,message.Asset, message.Price);
            Orders.Add(order);
        }

        
    }
}
