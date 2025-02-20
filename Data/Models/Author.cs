namespace ClaroTest.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public int IdBook { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        static HttpClient client = new HttpClient();
        public Author()
        {
            Id = 0;
            IdBook = 0;
            FirstName = "";
            LastName = "";
        }
        
        public Author(int id, int idBook, string firstName, string lastName)
        {
            Id = id;
            IdBook = idBook;
            FirstName = firstName;
            LastName = lastName;
        }
 
        public static async Task<Author[]> GetAllAuthors()
        {
            HttpResponseMessage response = await client.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Authors");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Author[]>();
        }

        public static async Task<Author> GetAuthorById(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://fakerestapi.azurewebsites.net/api/v1/Authors/{id}");
                response.EnsureSuccessStatusCode();
                Author author = await response.Content.ReadFromJsonAsync<Author>();
                return author;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<Author> CreateAuthor(Author author)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync<Author>("https://fakerestapi.azurewebsites.net/api/v1/Authors", author);
                response.EnsureSuccessStatusCode();
                Author createdAuthor= await response.Content.ReadFromJsonAsync<Author>();
                return createdAuthor;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<bool> DeleteAuthor(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://fakerestapi.azurewebsites.net/api/v1/Authors/{id}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<Author> UpdateAuthor(int id, Author author)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync<Author>($"https://fakerestapi.azurewebsites.net/api/v1/Authors/{id}", author);
                response.EnsureSuccessStatusCode();
                Author updatedAuthor= await response.Content.ReadFromJsonAsync<Author>();
                return updatedAuthor;
            }
            catch
            {
                return null;
            }
        }
    }
}
