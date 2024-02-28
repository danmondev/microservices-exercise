using Common.Dtos;

namespace Common.Contracts
{
    public record BooksRecommendationsRequested();
    public record BooksRecommendationsProvided(IList<BookDto> books);
}
