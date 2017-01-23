using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Web.Http;
using Zorbek.Demo.Ninject;
using Zorbek.Demo.WebApi.Dependencies;

namespace Zorbek.Demo.WebApi
{
    public class Startup
    {
        private readonly NinjectConfigBase ninjectConfig;

        public Startup(NinjectConfigBase ninjectConfig)
        {
            this.ninjectConfig = ninjectConfig;
        }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            var kernel = ninjectConfig.GetKernel();

            app.UseNinjectMiddleware(() => kernel).UseNinjectWebApi(config);
        }
    }
}