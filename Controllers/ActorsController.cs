using Dapper;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DAL;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MySqlContext sqlContext;

        public ActorsController(MySqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public IActionResult Index()
        {
            var actors = sqlContext.Connection.Query<Actor>("SELECT * FROM actor", null);

            return View(actors);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Actor model)
        {
            if (ModelState.IsValid)
            {
                var data = new
                {
                    model.Name,
                    model.Email,
                    model.Address
                };
                var sql = "INSERT INTO actor(Name,Email,Address) VALUES(@Name,@Email,@Address);";
                if (sqlContext.Connection.Execute(sql, param: data) > 0)
                    return Redirect("/Actors/Index");
            }
            return View();
        }
    }
}
