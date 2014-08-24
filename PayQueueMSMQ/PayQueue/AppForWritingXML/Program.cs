using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AppForWritingTables;
using MyMessages;

namespace AppForWritingXML
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"c:\Load_XML_Files\";

            /*****
             * 
             * If Diretory not there,
             * then create
             * 
             * *****/
           if(!Directory.Exists(path)) 
            {
                Directory.CreateDirectory(path); 
            }


            /*****
             * Create 5 Sample XML Files
             * *****/
            for (int index = 0; index < 5; index++)
            {
                string filename = @"temp" + (index + 1) + ".xml";
                EventMessage details = new EventMessage();
                details.EventId = Guid.NewGuid();
                details.paymentReq = new PaymentReq();
                details.paymentReq.billerGroupId = "ORDER";
                details.paymentReq.billerId = "USER";
                details.paymentReq.bankAccountNumber = "555555555";
                details.paymentReq.bankRoutingNumber = "444444444";
                details.paymentReq.firstName = "ATTN";
                details.paymentReq.lastName = "BILLING";
                details.paymentReq.companyName = "Money Company";
                details.paymentReq.nameOnAccount = "John Doe";
                details.paymentReq.phone = "3033333333";

                details.paymentReq.paymentReferenceId = Guid.NewGuid();
                details.paymentReq.address = new Address();
                details.paymentReq.address.streetAddress1 = "Accounting Building";
                details.paymentReq.address.streetAddress2 = "123 Gold Street";
                details.paymentReq.address.city = "Denver";
                details.paymentReq.address.state = "CO";


                SerializeEventMessage(path+filename, details);


            }


        }

        static public void SerializeEventMessage(string pathname, EventMessage details)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(EventMessage));
            using (TextWriter writer = new StreamWriter(pathname))
            {
                serializer.Serialize(writer, details);
            }
        }
    }
}
