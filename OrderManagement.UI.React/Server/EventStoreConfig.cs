using DynamicData.Annotations;

namespace OrderManagement.UI.React.Server
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class EventStoreConfig
    {
        public string IpAddress { get; set; } = "127.0.0.1";

        public int Port { get; set; } = 1113;

        public string ConnectionString { get; set; }

        public bool RunInMemory { get; set; }
    }
}
