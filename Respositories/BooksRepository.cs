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
            string sql = "SELECT * FROM books WHERE isAvailabe = 1";
            return _db.Query<Book>(sql);
        }

        internal Book GetById(int id)
        {
            string sql = "SELECT * FROM books WHERE id = @Id";
            return _db.QueryFirstOrDefault<Book>(sql, new { id });
        }
        internal IEnumerable<Book> GetBooksByUserEmail(string creatorEmail)
        {
            string sql = "SELECT * FROM books WHERE creatorEmail = @CreatorEmail";
            return _db.Query<Book>(sql, new { creatorEmail });
        }

        internal IEnumerable<BookGenreViewModel> GetBooksByGenreId(int GenreId)
        {
            string sql = @"
            SELECT
            b.*
            g.title AS Genre,
            bg.id AS BookGenreId
            FROM bookgenres bg
            INNER JOIN books b ON b.id = bg.bookId
            INNER JOIN genres g ON g.id = bg.genreId
            WHERE genreId = @GenreId AND isAvailabe = 1";
            return _db.Query<BookGenreViewModel>(sql, new { GenreId });
        }

        // NOTE Create Request
        internal Book Create(Book newBook)
        {
            string sql = @"
            INSERT INTO books
            (title, author, description, price, isAvailable, creatorEmail)
            VALUES
            (@Title, @Author, @Description, @Price, @IsAvailable, @CreatorEmail);
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

        // NOTE Put Requests
        internal Book CheckOut(Book bookToUpdate)
        {
            string sql = @"
            UPDATE books
            SET
                isAvailable = @IsAvailable
            WHERE id = @Id";
            _db.Execute(sql, bookToUpdate);
            return bookToUpdate;
        }
    }
}