using ClaroTest.Data.Models;
using Microsoft.OpenApi.Any;

namespace ClaroTest.Services
{
    public class BooksService
    {

        public async Task<Book[]> GetAllBooks()
        {
            return await Book.GetAllBooks();
        }

        public async Task<Book> GetBook(int id)
        {
            return await Book.GetBookById(id);
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await Book.DeleteBook(id);
        }

        public async Task<Book> CreateBook(Book book)
        {
            return await Book.CreateBook(book);
        }

        public async Task<Book> UpdateBook(int id, Book bookData)
        {
            return await Book.UpdateBook(id, bookData);
        }
    }
}
