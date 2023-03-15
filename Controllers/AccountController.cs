using Dapper;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DAL;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly DapperContext _context;

        public AccountController(DapperContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }







        [HttpPost]
        public IActionResult Register(RegisterDto model)
        {

            model.ID = Guid.NewGuid();

            //var user = new RegisterDto
            //{
            //    ID=Guid.NewGuid(),
            //    UserName=model.UserName,
            //    Email=model.Email,
            //    Password=model.Password,
            //    FirstName=model.FirstName,
            //    LastName=model.LastName,
            //    IsActive=model.IsActive
            //};

            var sql = @"INSERT INTO Users VALUES(@Id,@UserName,@Email,
                        @Password,@FirstName,@LastName,@IsActive)";

            if(_context.GetConnection.Execute(sql, model) > 0)
            {
                return Redirect("/Account/Login");
            }

            return View(model);
        }

        public IActionResult Index()
        {
            var users = _context.GetConnection.Query<RegisterDto>("SELECT * FROM users;", null);
            return View(users);
        }


    }
}
