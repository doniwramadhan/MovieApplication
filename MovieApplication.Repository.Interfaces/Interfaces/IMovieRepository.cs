using MovieApplication.Models;

namespace MovieApplication.Repository
{
    public interface IMovieRepository
    {
        public Task<bool> insert(Movie Models);
        public Task<Movie> GetMovie(int? Id);
        public Task<bool> delete(int? Id);
        public Task<List<Movie>?> selectAll();

        public Task<Movie> selectById(int? Id);

        public Task<bool> Update(Movie movie);
    }
}
