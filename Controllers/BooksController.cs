using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudLibrary.Models;
using crudLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace crudLibrary.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _bs;

        public BooksController(BooksService bs)
        {
            _bs = bs;
        }

        // NOTE Get Requests 
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            try
            {
                return Ok(_bs.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Book> getById(int id)
        {
            try
            {
                return Ok(_bs.GetById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("user")]
        public ActionResult<Book> GetBooksByUserEmail()
        {
            try
            {
                string creatorEmail = "josh@josh.com"; ;
                return Ok(_bs.GetBooksByUserEmail(creatorEmail));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // NOTE Post Request
        [HttpPost]
        public ActionResult<Book> Create([FromBody] Book newBook)
        {
            try
            {
                newBook.CreatorEmail = "josh@josh.com";
                return Ok(_bs.Create(newBook));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // NOTE Delete Request
        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            try
            {
                return Ok(_bs.Delete(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // NOTE Put Request
        [HttpPut("{id}")]
        public ActionResult<Book> CheckOut(int id, [FromBody] Book updatedBook)
        {
            try
            {
                return Ok(_bs.CheckOut(id, updatedBook));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}