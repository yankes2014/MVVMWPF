using Kino.Model;
using Kino.Repository;
using Kino.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Services
{
    public class SlotService : ISlotService
    {
        private IRepository<Slot> _repository;

        public SlotService(IRepository<Slot> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Slot>> GetSlotsAsync(string name)
        {
            var x = await _repository.GetByFuncAsync(f => f.Film.Tytul == name);
            return x;
        }
        public async Task<ICollection<Slot>> GetFreeSlotsAsync(string name)
        {
            var x = await _repository.GetByFuncAsync(f => f.Film.Tytul == name && f.IsFree == true);
            return x;
        }

        public async Task UpdateSLot(Slot slot)
        {
            await _repository.UpdateAsync(slot, slot.ID);
        }

    }
}
