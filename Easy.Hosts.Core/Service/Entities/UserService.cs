using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Persistence.Context;
using Easy.Hosts.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Easy.Hosts.Core.Service.Entities
{
    public class UserService : IUserService
    {
        private readonly EasyHostsDbContext _context;

        public UserService(EasyHostsDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentException(nameof(user));
            }

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
