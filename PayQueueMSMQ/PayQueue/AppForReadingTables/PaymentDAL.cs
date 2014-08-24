using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyMessages;

namespace AppForReadingTables
{
    public class PaymentDAL
    {

        public static ArrayList readEventMsgs()
        {
            ArrayList returnList = new ArrayList();

            using (var context = new PayQueueEntities())
            {



            }
            return returnList;
        }
    }
}
