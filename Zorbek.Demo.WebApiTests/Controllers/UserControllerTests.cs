using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using Zorbek.Demo.WebApiTests.Helpers;

namespace Zorbek.Demo.WebApi.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests : TestBase
    {
        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            dbContext.Seed_When_getting_user_by_id();

            var response = apiClient.GetAsync("api/users/1").Result;

            //Assert Http Status Code
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Read response content
            string json = response.Content.ReadAsStringAsync().Result;
            JObject user = JObject.Parse(json);

            //Set expected and actual values
            string expectedAccount = "alfonso.ramos@zorbek.com";
            string actualAccount = user.Value<string>("Account") ?? null;
            string expectedFirstName = "alfonso";
            string actualFirstName = user.Value<string>("FirstName") ?? null;
            string expectedLastName = "ramos";
            string actualLastName = user.Value<string>("LastName") ?? null;
            DateTime? expectedDateOfBirth = new DateTime(1984, 12, 12);
            DateTime? actualDateOfBirth = user.Value<DateTime?>("DateOfBirth") ?? null;

            //Assert values
            Assert.AreEqual(expectedAccount, actualAccount);
            Assert.AreEqual(expectedFirstName, actualFirstName);
            Assert.AreEqual(expectedLastName, expectedLastName);
            Assert.AreEqual(expectedDateOfBirth, expectedDateOfBirth);
        }

        [TestMethod()]
        public void GetByIdNotFoundTest()
        {
            var response = apiClient.GetAsync("api/users/1").Result;

            //Assert Http Status Code
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
           
        }

        [TestMethod()]
        public void GetByNameTest()
        {
            Assert.Fail();
        }
    }
}