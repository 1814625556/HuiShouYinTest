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
            var _animal = new Dog();
            //_animal.Run();
            //_animal.Eat();
            _animal.Sing();
            Console.ReadKey();
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


}
