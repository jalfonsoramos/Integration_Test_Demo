using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Demo.Storage.Interfaces;
using Zorbek.Demo.Storage.Model;
using Zorbek.Demo.Storage.Repositories;

namespace Zorbek.Demo.Ninject
{
    public class StorageModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ZorbekDemoDbContext>().ToSelf();
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}
