using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForReadingTables
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList msgList = new ArrayList();


            msgList = PaymentDAL.readEventMsgs();

            foreach (var msg in msgList)
            {



            }

            

        }
    }
}
