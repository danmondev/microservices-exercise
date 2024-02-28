using Common.Contracts;
using Common.Dtos;
using MassTransit;
using System.Text.Json;

namespace ReadersService.Consumers
{
    public class BooksRecommendationsProvidedConsumer : IConsumer<BooksRecommendationsProvided>
    {
        public async Task Consume(ConsumeContext<BooksRecommendationsProvided> context)
        {
            LogContext.Current.Logger.Log(LogLevel.Debug, JsonSerializer.Serialize(context.Message.books));
        }
    }
}
