using OrderManagement.Commands;
using ReactiveDomain.Foundation;
using ReactiveDomain.Messaging;
using ReactiveDomain.Messaging.Bus;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement
{
    class OrderCommandHandler : IHandleCommand<CreateOrderCommand>
    {
        private IRepository _repo;
        public OrderCommandHandler(IRepository repo)
        {
            _repo = repo;
        }
        public CommandResponse Handle(CreateOrderCommand command)
        {
            try
            {
                if (_repo.TryGetById<OrderAggregate>(command.Id, out var _))
                    throw new ValidationException("An order with this ID already exists");

                var account = new OrderAggregate(command.Id, command.Action, command.Quantity, command.Asset, command.Price);

                _repo.Save(account);
                return command.Succeed();
            }
            catch (Exception e)
            {
                return command.Fail(e);
            }
        }
    }
}
