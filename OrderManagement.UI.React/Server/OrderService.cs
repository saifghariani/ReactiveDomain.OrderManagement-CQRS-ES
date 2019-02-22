using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.UI.React.Server
{
    public class OrderService : IOrderService
    {
        private List<Order> _orders;
        private ApplicationService app;

        public OrderService()
        {
            app = new ApplicationService();
            app.Bootstrap();
            _orders = app._readModel.Orders;
        }
        public  IList<Order> GetAll()
        {
            app = new ApplicationService();
            app.Bootstrap();
            _orders = app._readModel.Orders;
            return _orders;
        }


        public Order GetById(Guid id) => app.repo.GetById<OrderAggregate>(id).ToOrder();


        public Guid Add(Order record)
        {
            var orderId = Guid.NewGuid();
            app.repo.Save(new OrderAggregate(orderId, record.Action, record.Quantity, record.Asset, record.Price));
            return orderId;
        }
    }
}
