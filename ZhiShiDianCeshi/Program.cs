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
            Teacher teacher = new Teacher()
            {
                Name = "CHENCHANG",
                Age = 22,
            };
            Console.WriteLine("Main ThreadId: "+Thread.CurrentThread.ManagedThreadId);
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
