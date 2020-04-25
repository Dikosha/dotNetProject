using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models.Contexts;

namespace Project.Controllers
{
    public class BookController : Controller
    {
        private BookContext dbBookContext;
        private AuthorContext dbAuthorContext;
        private CategoryContext dbCategoryContext;

        public BookController(BookContext bookContext, AuthorContext authorContext)
        {
            dbBookContext = bookContext;
            dbAuthorContext = authorContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await dbBookContext.Books.ToListAsync();
            return View("Index", books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Add(Movie movie)
        //{


        //    dbBookContext.Movies.Add(movie);
        //    await dbBookContext.SaveChangesAsync();

        //    var movies = await dbBookContext.Movies.ToListAsync();

        //    return View("Index", movies);
        //

        /*public async Task<IActionResult> Search(string text)
        {
            text = text.ToLower();
            var searchedMovies = await dbBookContext.Movies.Where(movie => movie.Name.ToLower().Contains(text)
                                            || movie.Genre.ToLower().Contains(text)
                                            || movie.Author.ToLower().Contains(text))
                                        .ToListAsync();
            return View("Index", searchedMovies);
        }*/

    }
}