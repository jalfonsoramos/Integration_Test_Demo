using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Zorbek.Demo.WebApi;
using Zorbek.Demo.WebApiTests.Dependencies;

namespace Zorbek.Demo.WebApiTests.Helpers
{
    public class TestBase
    {
        protected ZorbekDemoDbTestContext dbContext;
        protected HttpClient apiClient;
        protected NinjectConfig ninjectConfig;

        public TestBase()
        {
            ninjectConfig = new NinjectConfig();

            var server = TestServer.Create((app) =>
            {
                var startup = new Startup(ninjectConfig);
                startup.Configuration(app);
            });

            apiClient = server.HttpClient;
        }

        [TestInitialize]
        public void Initialize()
        {
            dbContext = new ZorbekDemoDbTestContext();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (dbContext == null) return;

            dbContext.Cleanup();
            dbContext.Dispose();
        }
    }
}