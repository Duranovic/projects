﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using SharedKernel.ApiModels;
using SharedKernel.Exceptions;
using SharedKernel.ViewModels;

namespace Repository.Repositories.DefaultRepositories
{
    public class TvShowRepository
    {
        private readonly CoreDbContext _coreDbContext;
        private readonly IMapper _mapper;

        public TvShowRepository(IMapper mapper, CoreDbContext coreDbContext)
        {
            _mapper = mapper;
            _coreDbContext = coreDbContext;
        }

        public async Task<MovieSummaryViewModel> GetTvShows(string keyword, int page, int pageSize,
            CancellationToken cancellationToken = default)
        {
            var tvShowsQuery = _coreDbContext.TvShows.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                tvShowsQuery = tvShowsQuery.SearchByPhrase(keyword);
            }

            tvShowsQuery = tvShowsQuery.OrderBy(x => x.Ratings.Sum(q => q.Rating.Star.Count) / x.Ratings.Count);

            var total = tvShowsQuery.Count();

            var movies = await tvShowsQuery
                .Take(pageSize)
                .ProjectTo<MovieViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MovieSummaryViewModel
            {
                MovieViewModels = movies,
                PaginationInfo = new PaginationInfo {Page = page, PageSize = pageSize, Total = total}
            };
        }
    }
}