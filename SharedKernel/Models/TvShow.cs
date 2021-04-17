using System;
using System.Collections.Generic;
using System.Linq;
using SharedKernel.Domain;

namespace SharedKernel.Models
{
    public class TvShow : AggregateRoot<Guid>, IMovieShow<RatingTvShow>
    {
        public TvShow()
        {
            Id = new Guid();
        }

        public TvShow(string title, DateTime releaseDate) : this()
        {
            Title = title;
            ReleaseDate = releaseDate;
        }

        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public CastTvShow CastTvShow { get; set; }
        public ICollection<RatingTvShow> Ratings { get; set; }
    }
}