
using MovieApplication.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Web.Mvc;

namespace MovieApplication.Repository
{
    public class MovieRepository : IMovieRepository
    {

        //Membuat koneksi ke database
        private string connection;
        public MovieRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("SQLname");
        }

        //Membuat method insert data ke table movie
        [HttpPost()]
        public async Task<bool> insert(Movie Models)
        {
            using (var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                var sqlStatement = @" insert into movielist (title,ReleaseDate,Genre,Price,Rating) values (@title,@ReleaseDate,@Genre,@Price,@Rating)";
                await con.ExecuteAsync(sqlStatement, Models);
            }
            return true;
        }

        //Membuat method hapus data dari table movie
        public async Task<bool> delete(int? Id)
        {
            using (var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                var sql = "DELETE FROM movielist WHERE Id = @Id";
                var rowsAffected = con.Execute(sql, new { id = Id });
                if (rowsAffected == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Membuat method untuk menampilkan seluruh data movie 
        public async Task<List<Movie>> selectAll()
        {
            using (var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                var sqlStatement = await con.QueryAsync<Movie>($@"select * from movielist go");
                return sqlStatement.ToList();
            }
        }

        //Membuat method untuk memanggil informasi satu movie berdasarkan id
        public async Task<Movie> GetMovie(int? Id)
        {
            using (var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                var sqlStatement = ($@"select * from movielist where id=@id");
                var result = await con.QuerySingleOrDefaultAsync<Movie>(sqlStatement, new { id = Id });
                return result;
            }
        }

        //Membuat method untuk memanggil informasi satu movie berdasarkan id
        public async Task<Movie> selectById(int? Id)
        {
            using (var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                var sqlStatement = ($@"select * from movielist where id=@id");
                var result = await con.QuerySingleOrDefaultAsync<Movie>(sqlStatement, new { id = Id });
                return result;
            }
        }

        //Membuat method untuk update movie
        public async Task<bool> Update(Movie movie)
        {
            using (var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                var sql = $@"Update movielist set Title=@Title, ReleaseDate=@ReleaseDate, Genre=@Genre, Price=@Price, Rating=@Rating Where Id=@Id";
                await con.QueryAsync<Movie>(sql, movie);
                return true;
            }
        }
    }
}
