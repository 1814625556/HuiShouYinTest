using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectExecrise
{
    public interface IAnimal
    {
        void Eat(string food);
        void Sleep();
    }
    public class Dog : IAnimal
    {
        private string _name { get; set; }

        public Dog(string name)
        {
            _name = name;
        }

        public void Eat(string food)
        {
            Console.WriteLine($"Dog is eat {food}");
        }

        public void Sleep()
        {
            Console.WriteLine($"{_name} sleep....");
        }
    }

    public interface IPlant
    {
        void Product(string name);
    }

    public class Tree : IPlant
    {
        public void Product(string name)
        {
            Console.WriteLine($"{name} is product....");
        }
    }
}
