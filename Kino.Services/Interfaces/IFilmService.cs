using Kino.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Services.Interfaces
{
    public interface IFilmService
    {
        Task<Film> GetFilm(string name);
    }
}
