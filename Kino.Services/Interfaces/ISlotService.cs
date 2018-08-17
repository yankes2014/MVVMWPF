using Kino.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Services.Interfaces
{
    public interface ISlotService
    {
        Task<ICollection<Slot>> GetSlotsAsync(string name);
        Task<ICollection<Slot>> GetFreeSlotsAsync(string name);
        Task UpdateSLot(Slot slot);
    }
}
