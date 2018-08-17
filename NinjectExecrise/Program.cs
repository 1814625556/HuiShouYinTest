using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace NinjectExecrise
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new ModuleTest());
            kernel.Bind<IPlant>().To<Tree>();

            //var dog = kernel.Get<IAnimal>();
            //dog.Sleep();
            //dog.Eat("apple");
            //var tree = kernel.Get<IPlant>();
            //tree.Product("xiaomin");
            kernel.Bind<INinjectTest>().ToConstant(NinjectTest.entity);
            var tt = kernel.Get<INinjectTest>();
            tt.Method();
            Console.ReadKey();
        }
    }

    public interface INinjectTest
    {
        void Method();
    }

    public class NinjectTest : INinjectTest
    { 

        public static NinjectTest entity = new NinjectTest();
        public void Method()
        {
            Console.WriteLine("test method...");
        }
    }
}
