using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using crudLibrary.Models;

namespace crudLibrary.Repositories
{

    public class BooksRepository
    {
        private readonly IDbConnection _db;

        public BooksRepository(IDbConnection db)
        {
            _db = db;
        }

        // NOTE Get Requests
        internal IEnumerable<Book> GetAll()
        {
            string sql = "SELECT * FROM books";
            return _db.Query<Book>(sql);
        }

        internal Book GetById(int id)
        {
            string sql = "SELECT * FROM books WHERE id = @Id";
            return _db.QueryFirstOrDefault<Book>(sql, new { id });
        }

        // NOTE Create Request
        internal Book Create(Book newBook)
        {
            string sql = @"
            INSERT INTO books
            (title, author, description, price, isAvailable)
            VALUES
            (@Title, @Author, @Description, @Price, @IsAvailable);
            SELECT LAST_INSERT_ID()";
            newBook.Id = _db.ExecuteScalar<int>(sql, newBook);
            return newBook;
        }

        // NOTE Delete Request
        internal bool Delete(int id)
        {
            string sql = "DELETE FROM books WHERE id = @Id limit 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}