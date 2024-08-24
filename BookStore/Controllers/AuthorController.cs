using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService service;
        public AuthorController(IAuthorService service)
        {
            this.service = service;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Add(model);
            if (result)
            {
                TempData["Message"] = "Added Successfully..";
                return RedirectToAction(nameof(Add));
            }
            TempData["Message"] = "Invalid data..";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var data = service.FindById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var data = service.Update(model);
            if (data)
            {
                return RedirectToAction("GetAll");
            }
            TempData["Message"] = "Error has occured on server side";
            return View(model);
        }


        public IActionResult Delete(int id)
        {

            var data = service.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {

            var data = service.GetAll();
            return View(data);
        }

    }
}
