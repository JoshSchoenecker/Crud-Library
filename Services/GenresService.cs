using System;
using System.Collections.Generic;
using crudLibrary.Models;
using crudLibrary.Repositories;

namespace crudLibrary.Services
{
    
    public class GenresService
    {
        private readonly GenresRepository _repo;

        public GenresService(GenresRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Genre> GetAll()
        {
            return _repo.GetAll();
        }

        internal Genre Create(Genre newGenre)
        {
            return _repo.Create(newGenre);
        }
    }
}