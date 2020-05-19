using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using crudLibrary.Models;

namespace crudLibrary.Services
{

    public class GenresRepository
    {
        private readonly IDbConnection _db;

        public GenresRepository(IDbConnection db)
        {
            _db = db;
        }

        // NOTE Get Requests
        internal IEnumerable<Genre> GetAll()
        {
            string sql = "SELECT * FROM genres";
            return _db.Query<Genre>(sql);
        }

        // NOTE Put Request
        internal Genre Create(Genre newGenre)
        {
            string sql = @"
            INSERT INTO genres
            (title)
            VALUES
            (@Title);
            SELECT LAST_INSERT_ID()";
            newGenre.Id = _db.ExecuteScalar<int>(sql, newGenre);
            return newGenre;
        }
    }
}