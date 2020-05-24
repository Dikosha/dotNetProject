using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models.Contexts;
using Project.Models.Entities;
using Project.ViewModels;

namespace Project.Controllers
{
    public class ProfileController : Controller
    {
        private UserContext db;
        public ProfileController(UserContext userContext)
        {
            db = userContext;
        }
        public async Task<IActionResult> Index()
        {
            string userEmail = User.Identity.Name;
            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            IEnumerable<ProfileModel> q2 = (from b in db.Books 
                     join ub in db.UserBook on b.Id equals ub.BookId
                     join a in db.Authors on b.AuthorId equals a.Id
                     where ub.UserId == user.Id
                     select new ProfileModel{ Id = b.Id, Title = b.Title, Author = a.FullName}).ToList();
            return View("Index", q2);
        }
    }
}