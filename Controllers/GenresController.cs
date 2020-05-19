using System.Collections.Generic;
using crudLibrary.Models;
using crudLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace crudLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly GenresService _gs;
        private readonly BooksService _bs;

        public GenresController(GenresService gs, BooksService bs)
        {
            _gs = gs;
            _bs = bs;
        }

        // NOTE Get Requests
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> GetAll()
        {
            try
            {
                return Ok(_gs.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}/books")]
        public ActionResult<IEnumerable<BookGenreViewModel>> GetBooksByGenreId(int id)
        {
            try
            {
                return Ok(_bs.GetBooksByGenreId(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        // NOTE Post Request
        [HttpPost]
        public ActionResult<Genre> Create([FromBody] Genre newGenre)
        {
            try
            {
                return Ok(_gs.Create(newGenre));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}