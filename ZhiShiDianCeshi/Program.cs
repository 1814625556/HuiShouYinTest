using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhiShiDianCeshi
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new S();
        }
    }

    public class S
    {
        private string name;

        static S()
        {
            Console.WriteLine("static...");
        }

        //public S()
        //{
        //    name = "zhangsna";
        //}
    }
}
