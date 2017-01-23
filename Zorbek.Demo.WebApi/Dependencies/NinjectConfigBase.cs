using Ninject;
using Ninject.Modules;
using Zorbek.Demo.Ninject;

namespace Zorbek.Demo.WebApi.Dependencies
{
    public abstract class NinjectConfigBase
    {
        protected StandardKernel kernel { get; set; }

        public StandardKernel GetKernel()
        {
            if (kernel != null) return kernel;

            kernel = new StandardKernel();

            LoadModules();

            return kernel;
        }

        public virtual void LoadModules()
        {
            kernel.Load(new INinjectModule[] { new BusinessModule(), new StorageModule() });
        }
    }
}