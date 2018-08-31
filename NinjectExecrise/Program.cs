using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using NUnit.Framework;

namespace NinjectExecrise
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var kernel = new StandardKernel(new ModuleTest());
                var lazyTree = kernel.Get<SumariTreeLazy>();
                lazyTree.Do();
                var tree = kernel.Get<SumariTree>();
            }
            catch (AssertionException e)
            {
                Console.WriteLine(e);
                
            }
            
            //NinjectCustomScopeExample.Test();
            Console.ReadKey();
        }

        public static void TestLiteDb()
        {
            LiteHelper.Test();
        }

        public void TestScopeNinject()
        {
            var kernel = new StandardKernel(new ViewModule());
            var e1 = kernel.Get<ScoptTest1>();
            var e2 = kernel.Get<ScoptTets2>();
            Assert.AreSame(e1._service, e2._service);
            Assert.AreSame(e1, e2);
        }

        static void Test1()
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
