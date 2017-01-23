using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Demo.Commons.DTO;

namespace Zorbek.Demo.Business.Interfaces
{
    public interface IUserService
    {
        int? Create(UserDTO user);

        UserDTO Get(int id);

        IEnumerable<UserDTO> GetByName(string name);
    }
}
