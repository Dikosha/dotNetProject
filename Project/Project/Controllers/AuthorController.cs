using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models.Contexts;
using Project.Models.Entities;

namespace Project.Controllers
{
    public class AuthorController : Controller
    {
        private AuthorContext db;


        public IActionResult Author()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id != null)
            {
                Author author = await db.Authors.FirstOrDefaultAsync(p => p.Id == Id);
                if (author != null)
                    return View(author);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Author author)
        {
            db.Authors.Update(author);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? Id)
        {
            if (Id != null)
            {
                Author author = await db.Authors.FirstOrDefaultAsync(p => p.Id == Id);
                if (author != null)
                    return View(author);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id != null)
            {
                Author author = await db.Authors.FirstOrDefaultAsync(p => p.Id == Id);
                if (author != null)
                {
                    db.Authors.Remove(author);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
       
    }
}