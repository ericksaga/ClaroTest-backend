using ClaroTest.Data.Models;
using ClaroTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaroTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<Book[]> Get()
        {
            Book[] books = await _booksService.GetAllBooks();
            return books;
        }

        [HttpPost]
        public async Task<Book> Create(Book bookData)
        {
            Book newBook = await _booksService.CreateBook(bookData);
            if (newBook == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return null;
            }
            return newBook;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Book> GetById(int id)
        {

            Book book = await _booksService.GetBook(id);
            if(book == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return null;
            }
            return book;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Book> Update(int id, Book bookData)
        {
            Book book = await _booksService.UpdateBook(id, bookData);
            if (book == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return null;
            }
            return book;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteBook(int id)
        {
            bool result = await _booksService.DeleteBook(id);
            if (!result)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return result;
            }
            return result;
        }

    }
}
