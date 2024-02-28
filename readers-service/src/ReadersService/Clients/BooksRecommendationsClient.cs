using Common.Dtos;

namespace ReadersService.Clients
{
    public class BooksRecommendationsClient
    {
        private readonly HttpClient _httpClient;

        public BooksRecommendationsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IReadOnlyCollection<BookDto>> GetBooksRecommendationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IReadOnlyCollection<BookDto>>("/books/recommendations");
        }
    }
}
