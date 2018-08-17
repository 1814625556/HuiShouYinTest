using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HuiShouYin._1_study
{
    public class DirectTest
    {
        public static void Test1()
        {
            var LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);//C:\Users\Administrator\AppData
            Console.WriteLine(Environment.SpecialFolder.LocalApplicationData);
            string path = Path.Combine(LocalAppData, @"Zaihui\Servant\Archer\Update");
        }
    }
}
