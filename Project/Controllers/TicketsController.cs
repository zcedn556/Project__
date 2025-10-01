using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Data.Entities;

namespace Project.Controllers
{
    public class TicketsController : Controller
    {
        private readonly FilmsDbContext _context;
        private readonly IEmailSender _emailSender;

        public TicketsController(FilmsDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public IActionResult Index(int id)
        {
            var film = _context.Films.FirstOrDefault(f => f.Id == id);
            if (film == null) return NotFound();
            return View(film);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int filmId, List<string> SelectedSeats, string UserEmail)
        {
            var film = _context.Films.FirstOrDefault(f => f.Id == filmId);
            if (film == null) return NotFound();

            if (SelectedSeats == null || !SelectedSeats.Any())
            {
                TempData["Error"] = "Виберіть хоча б одне місце!";
                return RedirectToAction("Index", new { id = filmId });
            }

            if (string.IsNullOrWhiteSpace(UserEmail))
            {
                TempData["Error"] = "Вкажіть свій email!";
                return RedirectToAction("Index", new { id = filmId });
            }

            string seats = string.Join(", ", SelectedSeats);

            await _emailSender.SendEmailAsync(
                UserEmail,
                "Ваші квитки",
                $"<h2>Фільм: {film.Title}</h2><p>Ви забронювали місця: {seats}</p>"
            );

            TempData["Success"] = $"Ви успішно купили квитки на {film.Title}. Місця: {seats}. Лист відправлено на {UserEmail}";
            return RedirectToAction("Index", new { id = filmId });
        }
    }
}
