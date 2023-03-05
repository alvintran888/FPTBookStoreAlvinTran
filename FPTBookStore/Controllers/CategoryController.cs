using FPTBookStore.Data;
using FPTBookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FPTBookStore.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        public CategoryController(ApplicationDbContext dbContext)
        {
            context = dbContext;

        }
        [Authorize(Roles = "Owner")]
        public IActionResult Index()
        {
            var categories = context.Category.ToList();


            return View(categories);


        }
        [Authorize(Roles = "Owner")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult Create(WaitCategory category)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new WaitCategory
                {
                    Name = category.Name,
                    Description = category.Description,
                    Status = "Pending"
                };
                var newCategory2 = new Category
                {
                    Name = category.Name,
                    Description = category.Description,
                    Status = "Pending"
                };
                context.Category.Add(newCategory2);
                context.WaitCategory.Add(newCategory);
                context.SaveChanges();
                return Redirect("/Category");
            }
            return View();
        }

        [Authorize(Roles = "Owner")]
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var categories = context.Category.ToList();
            var item = categories.Find(p => p.Id == id);
            return View(item);
        }

        [Authorize(Roles = "Owner")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var categories = context.Category.ToList();
            var item = categories.Find(p => p.Id == id);



            return View(item);
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Category.Update(category);
                context.SaveChanges();
                return Redirect("/Category");
            }
            return View();
        }

        [Authorize(Roles = "Owner")]
        [HttpGet]
        public IActionResult Confirm(int? id)
        {
            var categories = context.Category.ToList();
            var item = categories.Find(p => p.Id == id);
            return View(item);
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult Delete(Category category)
        {

            var categories = context.WaitCategory.ToList();
            var item = categories.Find(p => p.Name == category.Name);

            if (item != null)
            {
                context.WaitCategory.Remove(item);
            }
            context.Category.Remove(category);

            context.SaveChanges();
            return Redirect("/Category");

        }

    }
}
