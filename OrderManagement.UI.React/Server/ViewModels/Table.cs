using DotNetify;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.UI.React.Server.ViewModels
{
    public class Table : BaseVM
    {
        private readonly IOrderService _orderService;

        public Table(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IEnumerable<Order> Orders => _orderService.GetAll();
            


        /*= new Order[]{new Order(Guid.NewGuid(),"buy",50,"pc",320), };*/
        public string Orders_itemKey => nameof(Order.Id);

        public Action<Order> Add => (order) =>
        {
            var newRecord = new Order(order.Action, order.Quantity, order.Asset, order.Price);

            this.AddList(nameof(Orders), new Order
            {
                Id = _orderService.Add(newRecord),
                Action = newRecord.Action,
                Quantity = newRecord.Quantity,
                Asset = newRecord.Asset,
                Price = newRecord.Price,
            });
        };



    }
}
