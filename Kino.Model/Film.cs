using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Model
{
    public class Film
    {
        public Film()
        {
            Slots = new HashSet<Slot>();
            //SlotsUsed = new HashSet<Slot>();
        }
        public int ID { get; set; }
        public string Tytul { get; set; }
        public string Description { get; set; }

        public string TimeOfStartFilm { get; set; }
        public DateTime DateOfFilm { get; set; }
        public ICollection<Slot> Slots { get; set; }
        //public ICollection<Slot> SlotsLeft { get; set; }
        //public ICollection<Slot> SlotsUsed { get; set; }
    }
}
