using ReactiveDomain.Messaging;
using System;

namespace OrderManagement.Commands
{
    public class CreateOrderCommand : Command
    {
        public CreateOrderCommand() : base(NewRoot())
        { }
        public Guid Id { get; set; }
        public string Action { get; set; }
        public int Quantity { get; set; }
        public string Asset { get; set; }
        public float Price { get; set; }
    }
}
