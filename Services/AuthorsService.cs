using ClaroTest.Data.Models;

namespace ClaroTest.Services
{
    public class AuthorsService
    {
        public async Task<Author[]> GetAllAuthors()
        {
            return await Author.GetAllAuthors();
        }

        public async Task<Author> GetAuthor(int id)
        {
            return await Author.GetAuthorById(id);
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            return await Author.DeleteAuthor(id);
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            return await Author.CreateAuthor(author);
        }

        public async Task<Author> UpdateAuthor(int id, Author authorData)
        {
            return await Author.UpdateAuthor(id, authorData);
        }
    }
}
