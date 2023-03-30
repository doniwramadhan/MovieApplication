using MovieApplication.Models;

namespace MovieApplication.Service
{
    public interface IMovieService
    {
        public Task<bool> insertMovie(Movie Models);
        public Task<bool> deleteMovie(int? Id);
        public Task<List<Movie>?> selectAllMovie();
        public Task<Movie> SelectMovieId(int? Id);

        public Task<Movie> GetMovie(int? Id);
        public Task<bool> UpdateById(Movie movie);
    }
}
