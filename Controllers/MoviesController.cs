using Microsoft.AspNetCore.Mvc;
using MovieApp.DAL;
using MovieApp.Models;
using System.Reflection.Metadata.Ecma335;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {

        private readonly MovieDataAccess _movie;

        public MoviesController(MovieDataAccess movie)
        {
            _movie = movie;
        }


        [HttpGet]
        public ViewResult Index()
        {
            var movies=_movie.GetsAllMovie();
            return View("Index",movies);
        }
        [HttpGet]
        public  ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult Store(Movie model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_movie.CreateMovie(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var movie = _movie.GetAMovie(id);

            return View(movie);
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _movie.GetAMovie(id);
            return View(movie);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Update(int id,Movie model)
        {
            var movie = _movie.GetAMovie(id);

            if (movie == null) return NotFound();

            if (ModelState.IsValid)
            {
                if (_movie.UpdateMovie(model))
                {
                    return Redirect("/Movies/Index");
                }
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_movie.DeleteAMovie(id)) return RedirectToAction(nameof(Index));
            return NotFound();
        }
    }
}
