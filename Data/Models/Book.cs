namespace ClaroTest.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Excerpt { get; set; }
        public string PublishDate { get; set; }

        static HttpClient client = new HttpClient();
        public Book()
        {
            Id = 0;
            Title = "";
            Description = "";
            PageCount = 0;
            Excerpt = "";
            PublishDate = "";
        }

        public Book(int id, string title, string description, int pageCount, string excerpt, string publishDate)
        {
            Id = id;
            Title = title;
            Description = description;
            PageCount = pageCount;
            Excerpt = excerpt;
            PublishDate = publishDate;
        }

        public static async Task<Book[]> GetAllBooks()
        {
            HttpResponseMessage response = await client.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Book[]>();
        }

        public static async Task<Book> GetBookById(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}");
                response.EnsureSuccessStatusCode();
                Book book = await response.Content.ReadFromJsonAsync<Book>();
                return book;
            } catch {
                return null;
            }
        }

        public static async Task<Book> CreateBook(Book book)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync<Book>("https://fakerestapi.azurewebsites.net/api/v1/Books", book);
                response.EnsureSuccessStatusCode();
                Book createdBook = await response.Content.ReadFromJsonAsync<Book>();
                return createdBook;
            } catch
            {
                return null;
            }
        }

        public static async Task<bool> DeleteBook(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}");
                response.EnsureSuccessStatusCode();
                return true;
            } catch
            {
                return false;
            }
        }

        public static async Task<Book> UpdateBook(int id, Book book)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync<Book>($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}", book);
                response.EnsureSuccessStatusCode();
                Book updatedBook = await response.Content.ReadFromJsonAsync<Book>();
                return updatedBook;
            } catch
            {
                return null;
            }
        }
    }
}
