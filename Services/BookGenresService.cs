using System;
using System.Collections.Generic;
using crudLibrary.Models;
using crudLibrary.Repositories;

namespace crudLibrary.Services
{

    public class BookGenresService
    {
        private readonly BookGenresRepository _repo;

        public BookGenresService(BookGenresRepository repo)
        {
            _repo = repo;
        }

        internal BookGenre Create(BookGenre newBookGenre)
        {
            BookGenre createdBookGenre = _repo.Create(newBookGenre);
            return createdBookGenre;
        }
    }
}