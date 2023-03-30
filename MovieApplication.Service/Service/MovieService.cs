using MovieApplication.Models;
using MovieApplication.Repository;

namespace MovieApplication.Service
{
    
        public class MovieService : IMovieService
        {

            private readonly IMovieRepository _movie;

            public MovieService(IMovieRepository movie)
            {
                _movie = movie;
            }
            public Task<bool> insertMovie(Movie Models)
            {
                return _movie.insert(Models);

            }

            public Task<bool> deleteMovie(int? Id)
            {
                return _movie.delete(Id);

            }
            public Task<List<Movie>> selectAllMovie()
            {
                return _movie.selectAll();

            }
            public Task<Movie> GetMovie(int? Id)
            {
                return _movie.GetMovie(Id);
            }

            public Task<Movie> SelectMovieId(int? Id)
            {
                return _movie.selectById(Id);
            }

            public Task<bool> UpdateById(Movie movie)
            {
                return _movie.Update(movie);
            }
        }
}
