using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DianCaijiDerbyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var conn = new DerbyNET(@"F:\derby\db-derby-10.5.1.1-bin\bin\test1;create=true");
                //var cc = conn.openConnection();
                //var dt = conn.getRS("select * from ORDER_INFO");
                //conn.closeConnection();
                string str = zaihui.dbs.derby.derbynet.SayHello();
                Console.WriteLine(str);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }
    }
}
