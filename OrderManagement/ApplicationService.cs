using EventStore.ClientAPI;
using ReactiveDomain;
using ReactiveDomain.EventStore;
using ReactiveDomain.Foundation;
using System;

namespace OrderManagement
{
    public class ApplicationService
    {
        private IStreamStoreConnection conn;
        public IRepository repo;
        public OrderReadModel _readModel;
        public void Bootstrap()
        {
            IEventStoreConnection esConnection = EventStoreConnection.Create("ConnectTo=tcp://admin:changeit@localhost:1113");
            conn = new EventStoreConnectionWrapper(esConnection);
            esConnection.Connected += (_, __) => Console.WriteLine("Connected");
            esConnection.ConnectAsync().Wait();
            IStreamNameBuilder namer = new PrefixedCamelCaseStreamNameBuilder();
            IEventSerializer ser = new JsonMessageSerializer();
            repo = new StreamStoreRepository(namer, conn, ser);
            OrderAggregate order = null;

            IListener listener = new StreamListener("Order", conn, namer, ser);
            _readModel = new OrderReadModel(() => listener);
        }
        public void Run()
        {
            var cmd = new[] { "" };
            OrderAggregate order;
            do
            {

                cmd = Console.ReadLine().Split(' ');
                switch (cmd[0].ToLower())
                {
                    case "sendorder":
                        try
                        {
                            repo.Save(new OrderAggregate(Guid.NewGuid(), cmd[1], int.Parse(cmd[2]), cmd[3],
                                float.Parse(cmd[4])));

                            Console.WriteLine($"order sent to {cmd[1]} {cmd[2]} of {cmd[3]} at the price of {cmd[4]}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(
                                "Command should be:\n\tsendorder {action} {quantity} {asset} {price}\n\taction : 'sell' or 'buy'\n\tquantity : number \n\tasset : string\n\tprice : float");
                        }

                        break;
                }
            } while (cmd[0].ToLower() != "exit");
        }
    }
}
