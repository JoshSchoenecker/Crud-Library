using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using crudLibrary.Models;

namespace crudLibrary.Repositories
{
    public class BookGenresRepository
    {
        private readonly IDbConnection _db;

        public BookGenresRepository(IDbConnection db)
        {
            _db = db;
        }

// NOTE Post Request
        internal BookGenre Create(BookGenre newBookGenre)
        {
            string sql = @"
            INSERT INTO bookgenre
            (bookId, genreId)
            VALUES
            (@BookId, @GenreId);
            SELECT LAST_INSERT_ID";
            newBookGenre.Id = _db.ExecuteScalar<int>(sql, newBookGenre);
            return newBookGenre;
        }

        internal bool Delete(int id)
        {
            string sql = " DELETE FROM bookgenres WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}