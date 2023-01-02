using Easy.Hosts.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Service.Interface
{
    public interface IUserService
    {
        Task InsertAsync(User user);
        Task<IEnumerable<User>> FindAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> LoginUser(User user);
    }
}
