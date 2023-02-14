using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        [ActionName("List")]
        [HttpGet]
        public ViewResult Index()
        {

            ViewBag.movie = new Movie
            {
                Title = "The Way of the water.",
                Description = "The Way of the water.",
                Genre = Genre.Actions,
                Id = Guid.NewGuid(),
                ReleaseDate = new DateTime(2022, 12, 30)
            };
            ViewBag.MyName = "Ratha";
            ViewBag.Ex = new[] { 1, 2, 3, 4, 5, 6, 7 };

            ViewBag.movies = GetAllMovies();
            //using view data

            ViewData["newName"] = "Seyla";
            ViewData["arr"] = new[] { 2, 4, 6, 8, 10 };
            ViewData["mv"] = new Movie
            {
                Title = "The Way of the water01.",
                Description = "The Way of the water01.",
                Genre = Genre.Drama,
                Id = Guid.NewGuid(),
                ReleaseDate = new DateTime(2023, 1, 30)
            };
            ViewData["mvs"] = GetAllMovies();
            return View("Index");
        }

        private Movie[] GetAllMovies()
        {
            var movies = new Movie[]
            {
                 new Movie
                {
                    Id=Guid.NewGuid(),
                    Title="Avata 1",
                    ReleaseDate=new DateTime(2002,10,20),
                    Genre=Genre.Actions,
                    Description="Avata1"
                },
                new Movie
                {
                    Id=Guid.NewGuid(),
                    Title="Avata 2",
                    ReleaseDate=new DateTime(2003,10,20),
                    Genre=Genre.Actions,
                    Description="Avata2"
                },
                new Movie
                {
                    Id=Guid.NewGuid(),
                    Title="Avata 3",
                    ReleaseDate=new DateTime(2004,10,20),
                    Genre=Genre.Actions,
                    Description="Avata3"
                },
                new Movie
                {
                    Id=Guid.NewGuid(),
                    Title="Avata 4",
                    ReleaseDate=new DateTime(2005,10,20),
                    Genre=Genre.Actions,
                    Description="Avata4"
                },
                new Movie
                {
                    Id=Guid.NewGuid(),
                    Title="Avata 5",
                    ReleaseDate=new DateTime(2006,10,20),
                    Genre=Genre.Actions,
                    Description="Avata5"
                },
                new Movie
                {
                    Id=Guid.NewGuid(),
                    Title="Avata 6",
                    ReleaseDate=new DateTime(2007,10,20),
                    Genre=Genre.Actions,
                    Description="Avata6"
                },
                new Movie
                {
                    Id=Guid.NewGuid(),
                    Title="Avata 2",
                    ReleaseDate=new DateTime(2008,10,20),
                    Genre=Genre.Actions,
                    Description="Avata2"
                }

            };
            return movies;
        }




        [HttpGet]
        public  ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult Store(string title,string description,decimal price)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewBag.title = title;
            ViewBag.description = description;
            ViewBag.price = price;
            return Redirect("/Movies/List");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
