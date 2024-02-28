using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Common.Contracts;
using ReadersService.Clients;
using System.Text.Json;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging.Console;

namespace ReadersService.AddControllers
{
    [ApiController]
    [Route("readers")]
    public class ReadersControllers : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly BooksRecommendationsClient _booksRecommendationsClient;

        public ReadersControllers(IPublishEndpoint publishEndpoint, BooksRecommendationsClient booksRecommendationsClient)
        {
            _publishEndpoint = publishEndpoint;
            _booksRecommendationsClient = booksRecommendationsClient;
        }
        [HttpGet]
        [Route("getrecommendationscoupled")]
        public async Task<ActionResult> RequestBooksRecommendationsCoupled()
        {
            var recommendations = await _booksRecommendationsClient.GetBooksRecommendationsAsync();
            Console.WriteLine(JsonSerializer.Serialize(recommendations));
            return Ok(recommendations);
        }
        [HttpGet]
        [Route("getrecommendationsasync")]
        public async Task<ActionResult> RequestBooksRecommendations()
        {
            await _publishEndpoint.Publish(new BooksRecommendationsRequested());
            return Ok();
        }
    }
}
