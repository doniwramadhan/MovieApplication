using Microsoft.AspNetCore.Mvc;
using MovieApplication.Models;
using MovieApplication.Service;

namespace MovieApplication.Controllers
{
    public class MovieController : Controller
    {
        IMovieService _movieservice;
        public MovieController(IMovieService movieservice)
        {
            _movieservice = movieservice;
        }

        HttpContext _httpcontext;

  

        //Method menampilkan semua data
        public async Task<IActionResult> Index()
        {
            var movies = await _movieservice.selectAllMovie();
            return View(movies);
        }

        

        //Method Details selectbyID
        public async Task<IActionResult> Detail(int? Id)
        {
            var select = await _movieservice.SelectMovieId(Id);
            if (select == null) return NotFound();
            return View(select);
        }

        //Method Get Create
        public IActionResult Create()
        {
            return View();
        }

        // Method POST CREATE Data baru
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                var createMovie = await _movieservice.insertMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET
        public async Task<IActionResult> Delete(int? Id)
        {
            var getMov = await _movieservice.SelectMovieId(Id);
            return View(getMov);
        }

        // POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            if (_movieservice == null)
            {
                return Problem(" is null.");
            }
            var moviedel = await _movieservice.deleteMovie(Id);
            return RedirectToAction(nameof(Index));
        }

        //Method GET Edit 
        public async Task<IActionResult> Edit(int Id)
        {
            var mov = await _movieservice.GetMovie(Id);
            return View(mov);
        }

        [HttpPost]
        public async Task<IActionResult> EditMovie(Movie movie)
        {
            var emov = await _movieservice.UpdateById(movie);
            return RedirectToAction(nameof(Index));
        }

    }
}
