using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Demo.Storage.Model;

namespace Zorbek.Demo.WebApiTests.Helpers
{
    public class ZorbekDemoDbTestContext : ZorbekDemoDbContext
    {
        public ZorbekDemoDbTestContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ZorbekDemoDbTestContext>());
        }

        public void Cleanup()
        {
            if (Database.Exists())
            {
                Database.Delete();
            }
        }

        public void Seed_When_getting_user_by_id()
        {
            Users.Add(new User
            {
                Account = "alfonso.ramos@zorbek.com",
                FirstName = "alfonso",
                LastName = "ramos",
                DateOfBirth = new DateTime(1984, 12, 12),
                IsActive = true
            });

            SaveChanges();
        }

        public void Seed_When_getting_users_by_name()
        {
            Users.Add(new User
            {
                Account = "alfonso.ramos@zorbek.com",
                FirstName = "alfonso",
                LastName = "ramos",
                DateOfBirth = new DateTime(1984, 12, 12),
                IsActive = true
            });

            Users.Add(new User
            {
                Account = "alfonso.smith@zorbek.com",
                FirstName = "alfonso",
                LastName = "smith",
                DateOfBirth = new DateTime(1980, 4, 12),
                IsActive = true
            });

            SaveChanges();
        }
    }
}
