using Dapper;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DAL;
using MovieApp.Models;
using System.Data;
using BC = BCrypt.Net.BCrypt;
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
            if (string.IsNullOrEmpty(model.UserName))
            {
                ModelState.AddModelError("", "user name is not valid!");
            }
            if (model.UserName != null && model.UserName.Length < 3)
            {
                ModelState.AddModelError("", "User Name is at least 3 characters");
            }
            if (model.UserName != null && model.UserName.Length > 30)
            {
                ModelState.AddModelError(string.Empty, "User Name not exceed 100 characters");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.ID = Guid.NewGuid();
            model.Password=BC.HashPassword(model.Password);
            var sql = @"INSERT INTO Users VALUES(@Id,@UserName,@Email,
                        @Password,@FirstName,@LastName,@IsActive)";

            if(_context.GetConnection.Execute(sql,param:model) > 0)
            {
                return Redirect("/Account/Login");
            }

            ///await _context.GetConnection.ExecuteAsync(sql,param:model);
            return View(model);
        }

        public IActionResult Index()
        {
            var users = _context.GetConnection.Query<RegisterDto>("SELECT * FROM users;", null);
            
            ///await _context.GetConnection.QueryAsync("", new { });
            
            return View(users);
        }

        public IActionResult Login()
        {
            return View();
        }

        public JsonResult UserNameExist(string userName)
        {
                var user=_context.GetConnection.Query<RegisterDto>("SELECT * FROM users WHERE UserName=@UserName;",
                                                                                                        new { @UserName=userName }).FirstOrDefault();
            if(user != null)
            {
                  return Json(data:$"{user.UserName} already exist.");
            }
            return Json(data: true);
        }





    }
}
