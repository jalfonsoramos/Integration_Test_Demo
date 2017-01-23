using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Demo.Business.Interfaces;
using Zorbek.Demo.Commons.DTO;
using Zorbek.Demo.Storage.Interfaces;

namespace Zorbek.Demo.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public int? Create(UserDTO user)
        {
            if (string.IsNullOrEmpty(user.Account) ||
                string.IsNullOrEmpty(user.FirstName) ||
                string.IsNullOrEmpty(user.LastName) ||
                DateTime.Now.AddYears(-18) < user.DateOfBirth) return null;

            user.IsActive = true;

            int id = repository.Create(user);

            return id;
        }

        public UserDTO Get(int id)
        {
            if (id <= 0) return null;

            return repository.Get(id);
        }

        public IEnumerable<UserDTO> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return Enumerable.Empty<UserDTO>();

            return repository.GetByName(name);
        }
    }
}
