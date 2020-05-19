using crudLibrary.Models;
using crudLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace crudLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookGenresController : ControllerBase
    {
        private readonly BookGenresService _bgs;

        public BookGenresController(BookGenresService bgs)
        {
            _bgs = bgs;
        }

        // NOTE Post Request
        [HttpPost]
        public ActionResult<BookGenre> Create([FromBody] BookGenre newBookGenre)
        {
            try
            {
                return Ok(_bgs.Create(newBookGenre));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //NOTE Delete Request
        [HttpDelete("{id}")] 
        public ActionResult<BookGenre> Delete(int id)
        {
            try
            {
                return Ok(_bgs.Delete(id));
            }
            catch (System.Exception err)
            {
            return BadRequest(err.Message);  
            }
        }
    }

}