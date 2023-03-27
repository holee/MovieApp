using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DAL;
using MovieApp.Models;
using System.Data;

namespace MovieApp.Controllers
{


    public class GenresController : Controller
    {

        private readonly DapperContext _context;

        public GenresController(DapperContext context)
        {
            _context = context;
        }


        // GET: GenresController
        public async Task<ActionResult> Index()
        {
            var result =await _context.GetConnection.QueryAsync<Genres>("GetAllGenres",
                                                null,
                                                commandType:CommandType.StoredProcedure);

            return View(result);
        }

        // GET: GenresController/Details/5
        public async Task<ActionResult> Details(int id)
        {

            var result = await _context.GetConnection.QuerySingleAsync<Genres>("GetGenreById",
                                               new
                                               {
                                                   @id=id
                                               },
                                               commandType: CommandType.StoredProcedure);

            return View(result);
        }

        // GET: GenresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Genre","Description")] Genres model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.GetConnection.ExecuteAsync("spr_genre_insert", new
                    {
                        model.Genre,
                        model.Description
                    }, commandType: CommandType.StoredProcedure);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: GenresController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _context.GetConnection.QuerySingleAsync<Genres>("GetGenreById",
                                               new
                                               {
                                                   @id = id
                                               },
                                               commandType: CommandType.StoredProcedure);

            return View(result);
        }

        // POST: GenresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Genres model)
        {
            try
            {
                await _context.GetConnection.ExecuteAsync("spr_genre_update",
                    new
                    {
                        model.Id,
                        model.Genre,
                        model.Description
                    }, commandType: CommandType.StoredProcedure);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenresController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _context.GetConnection.QuerySingleAsync<Genres>("GetGenreById",
                                                new
                                                {
                                                    @id = id
                                                },
                                                commandType: CommandType.StoredProcedure);

            return View(result);
        }

        // POST: GenresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            try
            {
                await _context.GetConnection.ExecuteAsync("spr_genre_delete", new
                {
                    id = id
                }, commandType: CommandType.StoredProcedure);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
