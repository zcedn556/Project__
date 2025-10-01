using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Data.Entities;

namespace Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FilmsController : Controller
    {
        private readonly FilmsDbContext _ctx;

        public FilmsController(FilmsDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var model = _ctx.Films.Include(x => x.Genre).ToList();
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = _ctx.Genres.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Film film)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = _ctx.Genres.ToList();
                return View(film);
            }

            _ctx.Films.Add(film);
            _ctx.SaveChanges();

            TempData["Message"] = "Фільм успішно створено!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var film = _ctx.Films.Find(id);
            if (film == null)
                return NotFound();

            _ctx.Films.Remove(film);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var film = _ctx.Films.Find(id);
            if (film == null)
                return NotFound();

            ViewBag.Genres = _ctx.Genres.ToList();
            return View(film);
        }

        [HttpPost]
        public IActionResult Edit(Film film)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = _ctx.Genres.ToList();
                return View(film);
            }

            _ctx.Films.Update(film);
            _ctx.SaveChanges();

            TempData["Message"] = "Фільм оновлено";
            return RedirectToAction("Index");
        }
    }
}
