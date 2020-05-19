
using System;
using System.Collections.Generic;
using crudLibrary.Models;
using crudLibrary.Repositories;
namespace crudLibrary.Services
{

    public class BooksService
    {
        private readonly BooksRepository _repo;

        public BooksService(BooksRepository repo)
        {
            _repo = repo;
        }

        // NOTE Get Requests
        public IEnumerable<Book> GetAll()
        {
            return _repo.GetAll();
        }

        internal Book GetById(int id)
        {
            Book foundBook = _repo.GetById(id);
            if (foundBook == null)
            {
                throw new Exception("Invalid ID");
            }
            return foundBook;
        }

        // NOTE Delete Request
        internal Book Delete(int id)
        {
            Book foundBook = GetById(id);
            if (_repo.Delete(id))
            {
                return foundBook;
            }
            throw new Exception("Invalid ID");
        }

        // NOTE Create Request
        internal Book Create(Book newBook)
        {
            Book createdBook = _repo.Create(newBook);
            return createdBook;
        }

        // NOTE Pute Requests
        internal Book CheckOut(int id, Book updatedBook)
        {
            Book foundBook = GetById(id);
            foundBook.IsAvailable = updatedBook.IsAvailable;
            return _repo.CheckOut(foundBook);
        }
    }
}