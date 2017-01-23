using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;
using Zorbek.Demo.Business.Interfaces;
using Zorbek.Demo.Commons.DTO;
using System.Linq;

namespace Zorbek.Demo.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [Route("users")]
        [HttpPost]
        public IHttpActionResult Create(JObject json)
        {
            UserDTO user = new UserDTO
            {
                Account = json.Value<string>("account") ?? string.Empty,
                FirstName = json.Value<string>("firstName") ?? string.Empty,
                LastName = json.Value<string>("lastName") ?? string.Empty,
                DateOfBirth = json.Value<DateTime?>("dateOfBirth") ?? DateTime.Parse("01/01/1900")
            };

            int? id = service.Create(user);

            if (id.HasValue)
            {
                dynamic result = new
                {
                    User = $"/api/users/{id.Value}"
                };
                return Ok(result);
            }

            return BadRequest();
        }

        [Route("users/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var user = service.Get(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [Route("users")]
        [HttpGet]
        public IHttpActionResult GetByName([FromUri]string name)
        {
            var users = service.GetByName(name);

            if (users == null || !users.Any()) return NotFound();

            return Ok(users);
        }
    }
}