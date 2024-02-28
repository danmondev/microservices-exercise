using System.Text.Json;
using BooksService.Repository;
using Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace BooksService.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        [Route("recommendations")]
        public IList<BookDto> GetBooksRecommendations()
        {
            return Books.List;
        }
    }
}
