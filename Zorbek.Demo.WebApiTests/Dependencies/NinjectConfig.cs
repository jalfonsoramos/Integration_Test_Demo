using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Demo.Storage.Model;
using Zorbek.Demo.WebApi.Dependencies;
using Zorbek.Demo.WebApiTests.Helpers;

namespace Zorbek.Demo.WebApiTests.Dependencies
{
    public class NinjectConfig : NinjectConfigBase
    {
        public override void LoadModules()
        {
            base.LoadModules();

            //Re-Bind db context to db test context
            kernel.Rebind<ZorbekDemoDbContext>().To<ZorbekDemoDbTestContext>();
        }

        public void Rebind<T>(T mock)
        {
            kernel.Rebind<T>().ToConstant(mock);
        }       
    }
}
