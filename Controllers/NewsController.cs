using Microsoft.AspNetCore.Mvc;
using Hermes.Models; // Substitua "Hermes" pelo nome do seu projeto, se necessário
using System.Linq;

namespace Hermes.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context; // Substitua "ApplicationDbContext" pelo nome do seu contexto de banco de dados, se necessário

        public NewsController(ApplicationDbContext context) // Substitua "ApplicationDbContext" pelo nome do seu contexto de banco de dados, se necessário
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var news = _context.News.ToList(); // Substitua "_context.News" pelo nome do seu DbSet de notícias, se necessário
            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                _context.News.Add(news);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }
    }
}