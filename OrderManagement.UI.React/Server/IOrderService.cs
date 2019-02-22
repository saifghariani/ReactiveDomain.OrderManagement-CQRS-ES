using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.UI.React.Server
{
    public interface IOrderService
    {
        IList<Order> GetAll();
        Order GetById(Guid id);
        Guid Add(Order record);
    }
}
