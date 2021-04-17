using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using SharedKernel.ApiModels;
using SharedKernel.Models;
using SharedKernel.QueryableExtensions;
using SharedKernel.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Repositories.DefaultRepositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CoreDbContext _coreDbContext;
        private readonly IMapper _mapper;

        public MovieRepository(IMapper mapper, CoreDbContext coreDbContext)
        {
            _mapper = mapper;
            _coreDbContext = coreDbContext;
        }

        public async Task<MovieSummaryViewModel> GetMovies(string keyword,PagingInfo pagingInfo, CancellationToken cancellationToken = default)
        {
            var movieQuery = _coreDbContext.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(keyword) && keyword.Length >= 2)
                movieQuery = movieQuery.SearchByPhrase<Movie, RatingMovie>(keyword);

            movieQuery = movieQuery.OrderBy(x => x.Ratings.Average(r => r.Rating.Star.Count));

            var movies = await movieQuery
                .SkipAndTake(pagingInfo)
                .ProjectTo<MovieViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MovieSummaryViewModel
            {
                MovieViewModels = movies,
                PaginationInfo = new PaginationInfo { Page = pagingInfo.PageNumber, PageSize = pagingInfo.PageSize, Total = movieQuery.Count() }
            };
        }
    }

    public class PagingInfo
    {
        private const int DefaultPageSize = 50;
        private const int DefaultPageNumber = 1;

        public PagingInfo(PaginationInfo model)
        {
            PageNumber = model.Page;
            PageSize = model.PageSize;
            SetSkipSize();
        }

        public PagingInfo(int pageNumber = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SetSkipSize();
        }

        private int _pageNumber;
        public int PageNumber
        {
            get => _pageNumber;
            private init
            {
                if (value <= 0)
                    value = DefaultPageNumber;
                _pageNumber = value;
            }
        }

        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            private init
            {
                if (value <= 0)
                    value = DefaultPageSize;
                _pageSize = value;
            }
        }

        public int SkipSize { get; private set; }

        public int GetDefaultPageSize() => DefaultPageSize;
        public int GetDefaultPageNumber() => DefaultPageNumber;
        private int SetSkipSize() => SkipSize = _pageSize * (_pageNumber - 1);
    }

    public static class CommonQueryableExtensions
    {
        public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> queryable, PagingInfo pagingInfo = null)
        {
            pagingInfo ??= new PagingInfo();
            return queryable.Skip(pagingInfo.SkipSize).Take(pagingInfo.PageSize);
        }
    }
}