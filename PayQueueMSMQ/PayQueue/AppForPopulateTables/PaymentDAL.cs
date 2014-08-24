using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyMessages;

namespace AppForWritingTables
{
    public class PaymentDAL
    {

        public void writeEventMsg(EventMessage details)
        {
            using (var context = new PayQueueEntities())
            {

                // Get the payment rows
                var payment_rows = context.Payments;
                // Fluent API, check to see if there already is a payment with this EventId (PK)
                Payment payment = payment_rows.Where(x => (x.EventId == details.EventId)).FirstOrDefault();
                   /***
                 * If no payment in rows
                 * Add row
                 * Otherwise update row
                  * *****/
                if (payment == null)
                {
  
                    /**
                     * Walk through the details object
                     * USing Reflection
                     * ***/
                    Payment newPayment = new Payment();  // Create a new payment row
                    PropertyInfo[] newPayProperty = newPayment.GetType().GetProperties();
                    PropertyInfo[] mProperty = details.GetType().GetProperties();
   
                    /*****
                     * 
                     * Walk through all the fields in the details object
                     * 
                     * *******/
                    for (int index = 0; index < mProperty.Length; index++)
                    {
                        PropertyInfo mPropertyInformation = mProperty[index];
                        string mName = mPropertyInformation.Name.ToString();
                        switch (mName)
                        {
                            case "EventId":
                                Guid eventId = (Guid)mPropertyInformation.GetValue(details, null);
                                var field = newPayProperty.Where(x => (x.Name == mName)).FirstOrDefault();
                                field.SetValue(newPayment, eventId, null);
                                break;
                            case "paymentReq":
                                /****
                                 * Walk through the payment request object
                                 * setting in the values from this object into the table
                                 * *******/
                                PaymentReq paymentReq = (PaymentReq)mPropertyInformation.GetValue(details, null);
                                PropertyInfo[] payProperty = paymentReq.GetType().GetProperties();
                                for (int index2 = 0; index2 < payProperty.Length; index2++)
                                {
                                    PropertyInfo payPropertyInformation = payProperty[index2];
                                    string payName = payPropertyInformation.Name.ToString();
                                    // copy all the fileds, except the address fields, 
                                    // we will drill down one more level down the object
                                    if (payName != "address")
                                    {
                                        var payField = payPropertyInformation.GetValue(paymentReq, null);
                                        var field2 = newPayProperty.Where(x => (x.Name == payName)).FirstOrDefault();
                                        field2.SetValue(newPayment, payField, null);
                                    }
                                    else
                                    {
                                        /*****
                                         * Copy the values of the old Address object
                                         * to the address fields in the database
                                         * *******/
                                        Address address = (Address)payPropertyInformation.GetValue(paymentReq, null);
                                        PropertyInfo[] addressProperty = address.GetType().GetProperties();
                                        for (int index4 = 0; index4 < addressProperty.Length; index4++)
                                        {
                                            PropertyInfo addressPropertyInformation = addressProperty[index4];
                                            string addressName = addressPropertyInformation.Name.ToString();
                                            var addressField = addressPropertyInformation.GetValue(address, null);
                                            var field3 = newPayProperty.Where(x => (x.Name == addressName)).FirstOrDefault();
                                            field3.SetValue(newPayment, addressField, null);
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    payment_rows.Add(newPayment);
                    context.SaveChanges();
                }
                else
                {
                    /**
                     * Walk through the details object
                     * USing Reflection
                     * ***/
                     PropertyInfo[] newPayProperty = payment.GetType().GetProperties();
                    PropertyInfo[] mProperty = details.GetType().GetProperties();

                    /*****
                     * 
                     * Walk through all the fields in the details object
                     * 
                     * *******/
                    for (int index = 0; index < mProperty.Length; index++)
                    {
                        PropertyInfo mPropertyInformation = mProperty[index];
                        string mName = mPropertyInformation.Name.ToString();
                        switch (mName)
                        {
                            case "EventId":
                                Guid eventId = (Guid)mPropertyInformation.GetValue(details, null);
                                var field = newPayProperty.Where(x => (x.Name == mName)).FirstOrDefault();
                                field.SetValue(payment, eventId, null);
                                break;
                            case "paymentReq":
                                /****
                                 * Walk through the payment request object
                                 * setting in the values from this object into the table
                                 * *******/
                                PaymentReq paymentReq = (PaymentReq)mPropertyInformation.GetValue(details, null);
                                PropertyInfo[] payProperty = paymentReq.GetType().GetProperties();
                                for (int index2 = 0; index2 < payProperty.Length; index2++)
                                {
                                    PropertyInfo payPropertyInformation = payProperty[index2];
                                    string payName = payPropertyInformation.Name.ToString();
                                    // copy all the fileds, except the address fields, 
                                    // we will drill down one more level down the object
                                    if (payName != "address")
                                    {
                                        var payField = payPropertyInformation.GetValue(paymentReq, null);
                                        var field2 = newPayProperty.Where(x => (x.Name == payName)).FirstOrDefault();
                                        field2.SetValue(payment, payField, null);
                                    }
                                    else
                                    {
                                        /*****
                                         * 
                                         * Create an Address Object
                                         * Copy the values of the old Address object
                                         * to the new Address object
                                         * 
                                         * *******/
                                        Address address = (Address)payPropertyInformation.GetValue(paymentReq, null);
                                        PropertyInfo[] addressProperty = address.GetType().GetProperties();
                                        for (int index4 = 0; index4 < addressProperty.Length; index4++)
                                        {
                                            PropertyInfo addressPropertyInformation = addressProperty[index4];
                                            string addressName = addressPropertyInformation.Name.ToString();
                                            var addressField = addressPropertyInformation.GetValue(address, null);
                                            var field3 = newPayProperty.Where(x => (x.Name == addressName)).FirstOrDefault();
                                            field3.SetValue(payment, addressField, null);
                                        }

                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    context.SaveChanges();
                }
            }

        }

    
    
    
    }
}
