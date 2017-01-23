using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Demo.Commons.DTO;
using Zorbek.Demo.Storage.Interfaces;
using Zorbek.Demo.Storage.Model;

namespace Zorbek.Demo.Storage.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ZorbekDemoDbContext dbContext;

        public UserRepository(ZorbekDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Create(UserDTO dto)
        {
            var poco = new User
            {
                Account = dto.Account,
                DateOfBirth = dto.DateOfBirth,
                FirstName = dto.FirstName,
                IsActive = dto.IsActive,
                LastName = dto.LastName
            };

            dbContext.Users.Add(poco);
            dbContext.SaveChanges();
            return poco.Id;
        }

        public UserDTO Get(int id)
        {
            var poco = dbContext.Users.SingleOrDefault(x => x.Id == id);
            if (poco == null) return null;
            return Map(poco);
        }

        public IEnumerable<UserDTO> GetByName(string name)
        {
            var query = dbContext.Users.Where(x => x.FirstName.Contains(name));
            if (!query.Any()) return Enumerable.Empty<UserDTO>();
            return query.ToList().Select(x => Map(x));
        }

        private UserDTO Map(User user)
        {
            return new UserDTO
            {
                Account = user.Account,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                Id = user.Id,
                IsActive = user.IsActive,
                LastName = user.LastName
            };
        }
    }
}
