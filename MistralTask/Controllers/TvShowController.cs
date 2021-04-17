using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MistralTask.Business.Commands;
using MistralTask.Business.Queries;
using SharedKernel.Extensions;

namespace MistralTask.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TvShowController : Controller
    {
        private readonly IMediator _dispatcher;

        public TvShowController(IMediator dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string keyword, int page, int pageSize)
        {
            var response =
                await _dispatcher.Send(new GetMovies.Query(page, pageSize, keyword));

            return response.ToActionResult();
        }

        [HttpPost("{movieId}")]
        public async Task<IActionResult> AddStars(Guid movieId, AddStarsForMovie.Command command)
        {
            command.MovieId = movieId;

            var response =
                await _dispatcher.Send(command);

            return response.ToActionResult();
        }
    }
}