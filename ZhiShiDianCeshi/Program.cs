using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ZhiShiDianCeshi
{
    class Program
    {
        static void Main(string[] args)
        {
            //CardWork cd = new CardWork(){CardName = "chenchang",Description = "ceshiyongli"};
            //Console.WriteLine();
            SelectManySelectTest();
            //Console.WriteLine(Convert.ToDecimal(0));
            Console.Read();
        }
        /// <summary>
        /// Select() 为每个源值生成一个结果值。因此，总体结果是一个与源集合具有相同元素数目的集合。
        /// 与之相反，SelectMany() 将生成单一总体结果，其中包含来自每个源值的串联子集合
        /// </summary>
        static void SelectManySelectTest()
        {
            Console.WriteLine("select-------------");
            string[] text = { "Albert was here", "Burke slept late", "Connor is happy" };
            var tokens = text.Select(s => s.Split(' '));
            foreach (var line in tokens)
                Console.WriteLine("{0}.", line);

            Console.WriteLine("selectMany-------------");


            //string[] text = { "Albert was here", "Burke slept late", "Connor is happy" };
            var tokenss = text.SelectMany(s => s.Split(' '));
            foreach (string token in tokenss)
                Console.WriteLine("{0}.", token);
        }

        public void ThreadTest()
        {
            Teacher teacher = new Teacher()
            {
                Name = "CHENCHANG",
                Age = 22,
            };
            Console.WriteLine("Main ThreadId: " + Thread.CurrentThread.ManagedThreadId);
            teacher.peoChanged += ProChange;
            teacher.Name = "meimei";
            Console.ReadKey();
        }

        public static string ProChange(string name)
        {
            Thread.Sleep(100);
            Console.WriteLine("ProChange ThreadId: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(name);
            return $"NameChanged:{name}";
        }
    }

    public abstract class Animal
    {
        public virtual void Run()
        {
            Console.WriteLine("Animal is running.....");
        }

        public abstract void Eat();

        public void Sing()
        {
            Console.WriteLine("Animal is Sing.....");
        }
    }

    public class Dog : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Dog is Eating.....");
        }

        public void Sing()
        {
            Console.WriteLine("Dog is Barking.....");
        }

        public override void Run()
        {
            base.Run();
            Console.WriteLine("Dog is running ......");
        }
    }

    public class CardWork
    {
        public string CardName { get; set; }
        public string Description { get; set; }
        public string Hobby { get; set; }
        public string this[string name] => SayName(name).FirstOrDefault();

        public IEnumerable<string> SayName(string name)
        {
            Console.WriteLine(name);
            return new List<string>();
        }

    }


}
