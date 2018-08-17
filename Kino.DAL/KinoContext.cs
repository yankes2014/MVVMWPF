using Kino.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.DAL
{
    public class KinoContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public DbSet<Slot> Slots { get; set; }
        public DbSet<User> Users { get; set; }
        public KinoContext() : base("Kino")
        {

        }
    }
}
