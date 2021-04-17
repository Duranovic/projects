using System;
using System.Linq;
using SharedKernel.Models;

namespace SharedKernel.QueryableExtensions
{
    public static class SearchQueryableExtension
    {
        public static IQueryable<T> SearchByPhrase<T, TReview>(this IQueryable<T> query, string phrase) where TReview : IRating where T : IMovieShow<TReview>
        {
            var numberFromPhrase = GetNumberFromPhrase(phrase);
            phrase = phrase.ToLower();

            if (numberFromPhrase is not null)
                query = query.FilterByKeywords<T, TReview>(phrase, numberFromPhrase!.Value);

            return query.FilterByText<T, TReview>(phrase);
        }

        private static IQueryable<T> FilterByKeywords<T, TReview>(this IQueryable<T> query, string phrase, int numberFromPhrase) where T : IMovieShow<TReview> where TReview : IRating
        {
            if (phrase.Contains("stars"))
                return query.FilterByStars<T, TReview>(phrase, numberFromPhrase);

            if (phrase.Contains("older than") || phrase.Contains("after"))
                return query.FilterByTime<T, TReview>(phrase, numberFromPhrase);

            return query;
        }

        private static IQueryable<T> FilterByText<T, TReview>(this IQueryable<T> query, string phrase) where T : IMovieShow<TReview> where TReview : IRating
        {
            return query.Where(x => x.Title.ToLower().Contains(phrase) || x.Description.ToLower().Contains(phrase));
        }

        #region Filter by time

        private static IQueryable<T> FilterByTime<T, TReview>(this IQueryable<T> query, string phrase, int numberFromPhrase) where T : IMovieShow<TReview> where TReview : IRating
        {
            if (phrase.Contains("older than"))
                return query.Where(x => GetYearsDifferenceInPast(x.ReleaseDate) > numberFromPhrase);

            return phrase.Contains("after") ? query.Where(x => x.ReleaseDate.Year > numberFromPhrase) : query;
        }

        private static int GetYearsDifferenceInPast(DateTime date)
        {
            TimeSpan timeDifference = DateTime.Now - date;
            var start = new DateTime(1, 1, 1);
            return (start + timeDifference).Year - 1;
        }

        #endregion

        #region Filtering by stars

        private static IQueryable<T> FilterByStars<T, TReview>(this IQueryable<T> query, String phrase, int numberFromPhrase) where T : IMovieShow<TReview> where TReview : IRating
        {
            return phrase.Contains("at least") ? query.FilterAtLeastStars<T, TReview>(numberFromPhrase) : query.FilterEqualStars<T, TReview>(numberFromPhrase);
        }

        private static IQueryable<T> FilterAtLeastStars<T, TReview>(this IQueryable<T> query, int numberFromPhrase) where T : IMovieShow<TReview> where TReview : IRating
        {
            return query.Where(x => x.Ratings.Average(r => r.Rating.Star.Count) >= numberFromPhrase);
        }

        private static IQueryable<T> FilterEqualStars<T, TReview>(this IQueryable<T> query, int numberFromPhrase) where T : IMovieShow<TReview> where TReview : IRating
        {
            return query.Where(x => x.Ratings.Average(r => r.Rating.Star.Count) == numberFromPhrase);
        }

        #endregion

        private static int? GetNumberFromPhrase(string phrase)
        {
            _ = int.TryParse(new string(phrase
                .SkipWhile(x => !char.IsDigit(x))
                .TakeWhile(char.IsDigit)
                .ToArray()), out var result);

            return result;
        }
    }
}