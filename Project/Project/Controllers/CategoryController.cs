﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models.Contexts;
using Project.Models.Entities;

namespace Project.Controllers
{
    public class CategoryController : Controller
    {
        private UserContext db;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id != null)
            {
                BookCategory category = await db.BookCategories.FirstOrDefaultAsync(p => p.Id == Id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BookCategory category)
        {
            db.BookCategories.Update(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? Id)
        {
            if (Id != null)
            {
                BookCategory category = await db.BookCategories.FirstOrDefaultAsync(p => p.Id == Id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id != null)
            {
                BookCategory category = await db.BookCategories.FirstOrDefaultAsync(p => p.Id == Id);
                if (category != null)
                {
                    db.BookCategories.Remove(category);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}