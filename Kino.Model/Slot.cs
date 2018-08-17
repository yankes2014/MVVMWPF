using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Model
{
    public class Slot
    {
        public int ID { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public Film Film { get; set; }
        public bool IsFree { get; set; }
        public string Username { get; set; }

        //public User? User { get; set; }
    }
}
