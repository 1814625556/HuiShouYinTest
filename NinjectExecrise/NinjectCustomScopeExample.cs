using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;
using NUnit.Framework;

namespace NinjectExecrise
{
    public interface IService
    {
        void CC();
    }

    public class Service : IService
    {
        public void CC()
        {

        }
    }

    public class IOC
    {
        public static IOC Instance = new IOC();
        public object SessionId { private set; get; } = new object();
    }

    public static class NinjectExtension
    {
        public static IBindingNamedWithOrOnSyntax<T> InSession<T>(this IBindingInSyntax<T> bis)
        {
            return bis.InScope(_ => IOC.Instance.SessionId);
        }
    }

    public class ViewModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService>().To<Service>().InSession();
        }
    }

    public class ScoptTest1
    {
        public IService _service;
        public ScoptTest1(IService service)
        {
            _service = service;
        }
    }

    public class ScoptTets2
    {
        public IService _service;
        public ScoptTets2(IService service)
        {
            _service = service;
        }
    }




    public class ScopeObject { }

    public static class ProcessingScope
    {
        public static ScopeObject Current { get; set; }
    }
    public class NinjectCustomScopeExample
    {
        public class TestService { }
        public static void Test()
        {
            var kernel = new StandardKernel();
            kernel.Bind<TestService>().ToSelf().InScope(x => ProcessingScope.Current);

            var ScopeA = new ScopeObject();
            var ScopeB = new ScopeObject();

            ProcessingScope.Current = ScopeA;
            var testA1 = kernel.Get<TestService>();
            var testA2 = kernel.Get<TestService>();

            Assert.AreSame(testA1, testA2);

            ProcessingScope.Current = ScopeB;
            var testB = kernel.Get<TestService>();

            Assert.AreSame(testB, testA1);

            ProcessingScope.Current = ScopeA;
            var testA3 = kernel.Get<TestService>();

            Assert.AreSame(testA1, testA3);
        }

    }
}
