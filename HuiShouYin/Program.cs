using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HuiShouYin
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime st = ConvertStringToDateTime("1541579803647");
            Expression<Func<string,string,string>> func2_0 = (name,age)=> $"{name}'s age is {age}";
            func2_0 = (meimei, dudu) => $"{meimei}---{dudu}";
            Func<string, string, string> func2 = (param1, param2) => $"{param1},{param2}";
            func2 += (lala, feifie) => $"{lala}----$$$$-----{feifie}";
            Console.WriteLine(func2("zhangsan","26"));
            Console.WriteLine(func2_0.Compile()("meimei","dydyyd"));
            Console.ReadKey();
        }
        private static DateTime ConvertStringToDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        static void AnonyMousMethod(int sum) => Console.WriteLine(sum);
    }
}
