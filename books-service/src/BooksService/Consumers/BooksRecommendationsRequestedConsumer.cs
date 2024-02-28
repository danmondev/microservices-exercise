using BooksService.Repository;
using Common.Contracts;
using MassTransit;

namespace BooksService.Consumers
{
    public class BooksRecommendationsRequestedConsumer : IConsumer<BooksRecommendationsRequested>
    {
        public async Task Consume(ConsumeContext<BooksRecommendationsRequested> context)
        {
            context.Publish(new BooksRecommendationsProvided(Books.List));
        }
    }
}
