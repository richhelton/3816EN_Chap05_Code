using System;
using MyMessages;
using NServiceBus;
using NServiceBus.Saga;

namespace PayQueue
{
    class PaymentRequestSaga  : Saga<PaymentRequestData>,
         IAmStartedByMessages<EventMessage>
    {

        public void Handle(EventMessage message)
        {
 //           if (DebugFlagMutator.Debug)
 //           {
 //               Debugger.Break();
 //           }

  //          Data.OrderNumber = message.OrderNumber;
  //          Data.VideoIds = message.VideoIds;
  //          Data.ClientId = message.ClientId;

 //           RequestTimeout(TimeSpan.FromSeconds(20), new BuyersRemorseIsOver());
 //           Console.Out.WriteLine("Starting cool down period for order #{0}.", Data.OrderNumber);
        }



    }
}
