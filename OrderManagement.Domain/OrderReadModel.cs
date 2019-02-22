using OrderManagement.Domain.Events;
using ReactiveDomain.Foundation;
using ReactiveDomain.Messaging.Bus;
using System;
using System.Collections.Generic;

namespace OrderManagement.Domain
{
    public class OrderReadModel : ReadModelBase
        , IHandle<OrderCreatedEvent>
    {
        public List<Order> Orders = new List<Order>();
        public OrderReadModel(Func<IListener> getListener) : base(getListener)
        {
            EventStream.Subscribe<OrderCreatedEvent>(this);
            Start<OrderAggregate>();
        }

        public void Handle(OrderCreatedEvent message)
        {
            var order = new Order(message.Action,message.Quantity,message.Asset, message.Price);
            Orders.Add(order);
        }

        
    }
}
