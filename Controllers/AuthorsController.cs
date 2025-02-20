using ClaroTest.Data.Models;
using ClaroTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaroTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public async Task<Author[]> Get()
        {
            Author[] authors = await _authorsService.GetAllAuthors();
            return authors;
        }

        [HttpPost]
        public async Task<Author> Create(Author authorData)
        {
            Author newAuthor = await _authorsService.CreateAuthor(authorData);
            if (newAuthor == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return null;
            }
            return newAuthor;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Author> GetById(int id)
        {

            Author author = await _authorsService.GetAuthor(id);
            if (author == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return null;
            }
            return author;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Author> Update(int id, Author authorData)
        {
            Author author = await _authorsService.UpdateAuthor(id, authorData);
            if (author == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return null;
            }
            return author;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteAuthor(int id)
        {
            bool result = await _authorsService.DeleteAuthor(id);
            if (!result)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return result;
            }
            return result;
        }
    }
}
