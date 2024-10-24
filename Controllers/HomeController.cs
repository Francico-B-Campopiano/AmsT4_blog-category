using AmsT4_BLOG_2.Infrastructure.Data.Context;
using AmsT4_BLOG_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace AmsT4_BLOG_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context; // Mudança para DataContext

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context; // Inicializa o DataContext
        }

        public IActionResult Index()
        {
            var newsList = _context.News.ToList(); // Carrega todas as notícias do banco de dados
            return View(newsList); // Passa a lista de notícias para a view
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
