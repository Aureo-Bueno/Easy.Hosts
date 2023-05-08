using Easy.Hosts.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Repositories.Interface
{
    public interface IEventRepository
    {
        Task InsertAsync(Event @event);
        Task<IEnumerable<Event>> FindAllAsync();
        Task<Event> GetByIdAsync(Guid id);
    }
}
