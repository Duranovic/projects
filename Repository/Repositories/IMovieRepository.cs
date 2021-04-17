using System.Threading;
using System.Threading.Tasks;
using Repository.Repositories.DefaultRepositories;
using SharedKernel.ViewModels;

namespace Repository.Repositories
{
    public interface IMovieRepository
    {
        Task<MovieSummaryViewModel> GetMovies(string keyword, PagingInfo pagingInfo, CancellationToken cancellationToken = default);
    }
}