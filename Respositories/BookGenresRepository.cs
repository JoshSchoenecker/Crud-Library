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
    }
}