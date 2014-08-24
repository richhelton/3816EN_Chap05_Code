using System;
using NServiceBus;

namespace MyMessages
{
    public class EventMessage : IMessage
    {
        public Guid EventId { get; set; }
        public PaymentReq paymentReq { get; set; }
    }

    public class PaymentReq
    {
        public string billerGroupId { get; set; }
        public string billerId { get; set; }
        public string bankRoutingNumber { get; set; } // 9-digits
        public string bankAccountNumber { get; set; } // 9-digits
        public string firstName { get; set; }
        public string lastName { get; set; } // 9-digits
        public Address address { get; set; }
        public string nameOnAccount { get; set; }
        public string phone { get; set; }  // 10 digits
        public string companyName { get; set; }  // 50 characters
        public Guid paymentReferenceId { get; set; }
        public string paymentChannel { get; set; } // Usually WEB
        public string paymentAmount { get; set; } // of the form 201.10
    }

    public class Address
    {
        public string streetAddress1 { get; set; }
        public string streetAddress2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }  // 2-chars
        public string zip { get; set; }  // 5-digits
    }

}

