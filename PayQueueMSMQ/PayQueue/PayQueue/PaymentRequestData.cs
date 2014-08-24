using System;
using NServiceBus.Saga;

namespace PayQueue
{
    class PaymentRequestData : IContainSagaData
    {
        /**
         * NServiceBsus Required
         * ***/
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        [Unique]
        public Guid RequestId { get; set; }
    }
}
