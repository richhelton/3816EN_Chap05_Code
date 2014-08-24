using System;
using NServiceBus;
using NServiceBus.Config;


namespace PayQueue
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization, IWantToRunWhenBusStartsAndStops
    {
        public void Init()
        {


            // Log the Bus
 //           SetLoggingLibrary.NLog();

            UnicastBusConfig unicastBusCfg = Configure.GetConfigSection<UnicastBusConfig>();
            Logging loggingCfg = Configure.GetConfigSection<Logging>();
            TransportConfig transportCfg = Configure.GetConfigSection<TransportConfig>();
            SecondLevelRetriesConfig secondCfg = Configure.GetConfigSection<SecondLevelRetriesConfig>();
            AuditConfig auditCfg = Configure.GetConfigSection<AuditConfig>();
            MsmqSubscriptionStorageConfig endpoinsCfg = Configure.GetConfigSection<MsmqSubscriptionStorageConfig>();
             
            
            
            
            
            Configure.With()
                .DefaultBuilder()
                .UseTransport<Msmq>()
                .MsmqSubscriptionStorage()
                .InMemorySagaPersister()
                .UseInMemoryTimeoutPersister()
                .UnicastBus();
        }

        public void Start()
        {
            Console.WriteLine("This is the process hosting the saga.");
        }

        public void Stop()
        {
            Console.WriteLine("Stopped.");
        }
    }
}
