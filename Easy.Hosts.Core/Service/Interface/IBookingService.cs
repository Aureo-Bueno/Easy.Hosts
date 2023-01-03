using Easy.Hosts.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Hosts.Core.Service.Interface
{
    public interface IBookingService
    {
        Task InsertAsync(Booking booking);
        Task<IEnumerable<Booking>> FindAllAsync();
        Task<Booking> GetByIdAsync(int id);
    }
}
