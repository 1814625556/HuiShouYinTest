using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace NinjectExecrise
{
    public class ModuleTest : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnimal>().To<Dog>().WithConstructorArgument("name","jiabao");
            Bind<IPlant>().To<Tree>();
        }
    }
}
