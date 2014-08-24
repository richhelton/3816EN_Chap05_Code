using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AppForWritingTables;
using log4net.Appender;
using log4net.Core;
using MyMessages;
using NServiceBus;

namespace AppForReadinXML
{
    class Program
    {

        private static IBus bus;

        static void Main(string[] args)
        {

            ArrayList myXMLlist = new ArrayList(); 
            
            
            /*****
             * Open the temp files in this directory
             * *****/
            string[] dirs = Directory.GetFiles(@"c:\Load_XML_Files\", "temp?.xml" );
            foreach (string filename in dirs)
            {
                /***
                 * De-serialize the XML into the objects
                 * *****/
                EventMessage details = DeserializeEventMessage(filename);
                PaymentDAL payDAL = new PaymentDAL();
                /*****
                 * Save to the database
                 * *****/
                payDAL.writeEventMsg(details);


                /***
                 *  Add to my list for later use
                 * ****/
                myXMLlist.Add(details);

            }
            // Set the log4net
            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);
            // Configure the Bus 
            bus = Configure.With()
                     .DefaultBuilder()
                     .UseTransport<SqlServer>()
                     .UnicastBus()
                     .CreateBus();
            /****
              * Send it to the Queue
              * ****/
            foreach (var msg in myXMLlist)
            {
                bus.Send(msg);
            }




        }
        static public EventMessage DeserializeEventMessage(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(EventMessage));
            using (TextReader reader = new StreamReader(filename))
            {
                EventMessage eventMsg = (EventMessage)serializer.Deserialize(reader);
                return eventMsg;
            }
         }
    }
}
