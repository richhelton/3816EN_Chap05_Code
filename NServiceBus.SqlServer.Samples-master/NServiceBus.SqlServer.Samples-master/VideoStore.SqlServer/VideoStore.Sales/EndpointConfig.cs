namespace VideoStore.Sales
{
    using System;
    using log4net.Appender;
    using log4net.Repository.Hierarchy;
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, UsingTransport<SqlServer>, IWantCustomInitialization
    {
        public void Init()
        {

            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);

  
            Configure.With()
                .DefaultBuilder()
                .RijndaelEncryptionService();
        }
    }


    public class MyClass:IWantToRunWhenBusStartsAndStops
    {
        public void Start()
        {
            Console.Out.WriteLine("The VideoStore.Sales endpoint is now started and ready to accept messages");
        }

        public void Stop()
        {
            
        }
    }
}
