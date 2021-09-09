using AcademyF.Week8.Esercitazione1.Core.Entities;
using AcademyF.Week8.Esercitazione1.Core.Interfaces;
using AcademyF.Week8.Esercitazione1.MVC.Helpers;
using AcademyF.Week8.Esercitazione1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyF.Week8.Esercitazione1.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMainBusinessLayer mainBL;

        public CategoryController(IMainBusinessLayer mainBL)
        {
            this.mainBL = mainBL;
        }
        public IActionResult Index()
        {
            var list=this.mainBL.FetchAllCategories();
            var model = list.ToListViewModel();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model == null)
            {
                ModelState.AddModelError(nameof(model), "Error Generating model");
                return View(model);
            }

            var categoryModel = model.ToCreateViewModel();
            var result = this.mainBL.CreateNewCategory(categoryModel);

            if (!result.Success)
            {
                ModelState.AddModelError(nameof(model), "Error Saving model");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
                return View();

            Category category = this.mainBL.GetCategorybyId(id);
            var model = category.ToDetailsCategory();

            return View(model);

        }

        public IActionResult Edit(int id)
        {
            if (id <= 0)
                return View();

            var category = this.mainBL.GetCategorybyId(id);

            var model = category.ToCreateViewModel();

            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(int id, CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id <= 0 && model==null)
            {
                ModelState.AddModelError("", "Error generating model");
                return View();
            }

            var category = model.ToCategory();
            var result = this.mainBL.UpdateCategory(category);

            if (!result.Success)
            {
                ModelState.AddModelError("", "Error saving model");
                return View(result);
            }

            return RedirectToAction(nameof(Index));
            
        }

        public IActionResult DeleteJs(int id)
        {
            if (id <= 0)
                return Json(false);

            var result = this.mainBL.DeleteCategory(id);

            return Json(result.Success);
        }
    }
}
