using Easy.Hosts.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Service.Interface
{
    public interface IEventService
    {
        Task InsertAsync(Event @event);
        Task<IEnumerable<Event>> FindAllAsync();
        Task<Event> GetByIdAsync(Guid id);
    }
}
