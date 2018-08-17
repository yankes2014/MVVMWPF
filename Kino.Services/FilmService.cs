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
    public class FilmService: IFilmService
    {
        private IRepository<Film> _repository;

        public FilmService(IRepository<Film> repository)
        {
            _repository = repository;
        }

        public async Task<Film> GetFilm(string name)
        {
            var x = await _repository.GetSingleByFunc(f => f.Tytul == name);
            return x;
        }
    }

}
